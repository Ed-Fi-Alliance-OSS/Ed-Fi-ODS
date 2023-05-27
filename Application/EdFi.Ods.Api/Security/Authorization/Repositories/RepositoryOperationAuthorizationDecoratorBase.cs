// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Security.DataAccess.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract base class for authorization decorators to use for invoking 
    /// authorization.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entity/request.</typeparam>
    public abstract class RepositoryOperationAuthorizationDecoratorBase<TEntity>
        where TEntity : class
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
        private readonly IExplicitObjectValidator[] _explicitObjectValidators;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
        private readonly ISessionFactory _sessionFactory;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly IClaimSetClaimsProvider _claimSetClaimsProvider;

        private readonly Lazy<Dictionary<string, Actions>> _bitValuesByAction;

        [Flags]
        private enum Actions
        {
            Create = 0x1,
            Read = 0x2,
            Update = 0x4,
            Delete = 0x8,
        }
        
        protected RepositoryOperationAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IExplicitObjectValidator[] explicitObjectValidators,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            ISecurityRepository securityRepository,
            ISessionFactory sessionFactory,
            IApiKeyContextProvider apiKeyContextProvider,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IClaimSetClaimsProvider claimSetClaimsProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _authorizationFilteringProvider = authorizationFilteringProvider;
            _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
            _explicitObjectValidators = explicitObjectValidators;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _sessionFactory = sessionFactory;
            _apiKeyContextProvider = apiKeyContextProvider;
            _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _claimSetClaimsProvider = claimSetClaimsProvider;

            // Lazy initialization
            _bitValuesByAction = new Lazy<Dictionary<string, Actions>>(
                () => new Dictionary<string, Actions>
                {
                    { securityRepository.GetActionByName("Create").ActionUri, Actions.Create },
                    { securityRepository.GetActionByName("Read").ActionUri, Actions.Read },
                    { securityRepository.GetActionByName("Update").ActionUri, Actions.Update },
                    { securityRepository.GetActionByName("Delete").ActionUri, Actions.Delete }
                });
        }

        /// <summary>
        /// Invokes authorization of the request using the resource/action currently in context.
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var action = _authorizationContextProvider.GetAction();

            await AuthorizeSingleItemAsync(entity, action, cancellationToken);
        }

        /// <summary>
        /// Invokes authorization of the request using the resource currently in context but wit 
        /// an override action (e.g. for converting the "Upsert" action to either "Create" or "Update").
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="actionUri">The action being performed with the request/entity.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, string actionUri, CancellationToken cancellationToken)
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();

            // Build the AuthorizationContext
            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();
            string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
            var claimSetClaims = _claimSetClaimsProvider.GetClaims(apiKeyContext.ClaimSetName);
            var resource = _dataManagementResourceContextProvider.Get().Resource;

            var authorizationContext = new EdFiAuthorizationContext(
                apiKeyContext,
                claimSetClaims,
                resource,
                resourceClaimUris,
                actionUri,
                entity);

            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                apiKeyContext.ClaimSetName, resourceClaimUris, actionUri);

            ExecuteAuthorizationValidationRules(authorizationBasisMetadata, authorizationContext.Action, authorizationContext.Data);

            // Get the authorization filtering information
            var authorizationFiltering =
                _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);

            var andResults = PerformInstanceBasedAuthorization(authorizationFiltering, authorizationContext, FilterOperator.And);
            
            // If any failures occurred with the AND strategies, throw the first exception now
            ThrowInstanceBasedFailureFromResults(andResults);

            // For remaining pending authorizations requiring database access, get the existence checks SQL fragments  
            var pendingAndStrategies = andResults
                // Only check any strategies that have no failures
                .Where(x => x.FilterResults.Any(f => f.Result.State == AuthorizationState.NotPerformed))
                .Select(x => 
                    new AuthorizationStrategyFilterResults
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        FilterResults = x.FilterResults
                            .Where(y => y.Result.State == AuthorizationState.NotPerformed)
                            .ToArray(),
                    })
                .ToArray();
                
            var orResults = PerformInstanceBasedAuthorization(authorizationFiltering, authorizationContext, FilterOperator.Or);

            bool orConditionAlreadySatisfied = orResults
                .Any(r => r.FilterResults.All(f => f.Result.State == AuthorizationState.Success));

            if (orConditionAlreadySatisfied || !orResults.Any())
            {
                // Check for pending ANDs
                if (pendingAndStrategies.Any())
                {
                    // Execute SQL to determine AND results
                    await PerformViewBasedAuthorizationAsync(pendingAndStrategies, authorizationContext, cancellationToken);
                }

                // We're authorized...
                return;
            }

            // We'll need to go to the database to check for relationship existence 
            var pendingOrStrategies = orResults
                // Only check any strategies that have no failures
                .Where(x => x.FilterResults.All(f => f.Result.State != AuthorizationState.Failed))
                .Select(
                    x => new AuthorizationStrategyFilterResults
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        FilterResults = x.FilterResults
                            .Where(y => y.Result.State == AuthorizationState.NotPerformed)
                            .ToArray(),
                    });

            var allPendingExistenceChecks = 
                pendingAndStrategies.Where(x => x.FilterResults.Any())
                .Concat(pendingOrStrategies.Where(x => x.FilterResults.Any()))
                .ToArray();

            // If there are no pending view-based checks to be performed and we're still here, the authorization failure is held in the orResults
            if (!allPendingExistenceChecks.Any())
            {
                ThrowInstanceBasedFailureFromResults(orResults);
            }
            
            await PerformViewBasedAuthorizationAsync(allPendingExistenceChecks, authorizationContext, cancellationToken);

            bool IsCreateUpdateOrDelete(string requestAction)
            {
                return (_bitValuesByAction.Value[requestAction] 
                    & (Actions.Create | Actions.Update | Actions.Delete)) != 0;
            }

            void ExecuteAuthorizationValidationRules(
                AuthorizationBasisMetadata authorizationBasisMetadata1,
                string requestAction,
                object requestData)
            {
                // If there are explicit object validators, and we're modifying data
                if (_explicitObjectValidators.Any() && IsCreateUpdateOrDelete(requestAction))
                {
                    // Validate the object using explicit validation
                    var validationResults = _explicitObjectValidators.ValidateObject(
                        requestData,
                        authorizationBasisMetadata1.ValidationRuleSetName);

                    if (!validationResults.IsValid())
                    {
                        throw new ValidationException(
                            string.Format(
                                "Validation of '{0}' failed.\n{1}",
                                requestData.GetType().Name,
                                string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))));
                    }
                }
            }

            AuthorizationStrategyFilterResults[] PerformInstanceBasedAuthorization(
                IReadOnlyList<AuthorizationStrategyFiltering> authorizationStrategyFilterings,
                EdFiAuthorizationContext authorizationContext1,
                FilterOperator filterOperator)
            {
                var andResults = authorizationStrategyFilterings
                    .Where(asf => asf.Operator == filterOperator)
                    .Select(
                        s => new AuthorizationStrategyFilterResults
                        {
                            AuthorizationStrategyName = s.AuthorizationStrategyName,
                            Operator = s.Operator,
                            FilterResults = s.Filters
                                .Select(
                                    f => new
                                    {
                                        FilterDefinition = _authorizationFilterDefinitionProvider.GetFilterDefinition(f.FilterName),
                                        FilterContext = f
                                    })
                                .Select(
                                    x => new FilterAuthorizationResult
                                    {
                                        FilterDefinition = x.FilterDefinition,
                                        FilterContext = x.FilterContext,
                                        Result = x.FilterDefinition.AuthorizeInstance(authorizationContext1, x.FilterContext)
                                    })
                                .ToArray()
                        })
                    .ToArray();

                return andResults;
            }

            void ThrowInstanceBasedFailureFromResults(AuthorizationStrategyFilterResults[] results)
            {
                results.SelectMany(x => x.FilterResults)
                    .Where(fr => fr.Result.State == AuthorizationState.Failed)
                    .ForEach(fr => throw fr.Result.Exception);
            }
        }

        private async Task PerformViewBasedAuthorizationAsync(
            AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks,
            EdFiAuthorizationContext authorizationContext,
            CancellationToken cancellationToken)
        {
            string sql = BuildExistenceCheckSql(resultsWithPendingExistenceChecks);

            // Execute the query
            using var sessionScope = new SessionScope(_sessionFactory);

            await using var cmd = sessionScope.Session.Connection.CreateCommand();

            // Assign the command text
            cmd.CommandText = sql;

            // Assign all parameters
            cmd.Parameters.AddRange(
                resultsWithPendingExistenceChecks.SelectMany(
                        x => x.FilterResults.Select(
                            f =>
                            {
                                var parameter = cmd.CreateParameter();
                                parameter.ParameterName = f.FilterContext.SubjectEndpointName;
                                parameter.Value = f.FilterContext.SubjectEndpointValue;

                                return parameter;
                            }))
                    .GroupBy(x => x.ParameterName)
                    .Select(x => x.First())
                    .ToArray());

            _viewBasedSingleItemAuthorizationQuerySupport.ApplyClaimsParametersToCommand(cmd, authorizationContext);

            // Process the pending AND SQL checks, ensure that they are all 1, or throw an exception
            var result = (int?)await cmd.ExecuteScalarAsync(cancellationToken);

            if (result == 0)
            {
                throw new EdFiSecurityException(GetAuthorizationFailureMessage());
            }

            string BuildExistenceCheckSql(AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks)
            {
                // Build the existence check SQL
                StringBuilder sql = new();

                sql.Append("SELECT CASE WHEN ");

                resultsWithPendingExistenceChecks.ForEach(
                    (x, i, s) =>
                    {
                        if (i > 0)
                        {
                            if (x.Operator == FilterOperator.And)
                            {
                                s.Append(" AND ");
                            }
                            else
                            {
                                s.Append(" OR ");
                            }
                        }

                        s.Append('(');

                        x.FilterResults.ForEach(
                            (y, j, s) =>
                            {
                                var viewBasedFilterDefinition = y.FilterDefinition as ViewBasedAuthorizationFilterDefinition
                                    ?? throw new InvalidOperationException(
                                        "Expected a ViewBasedAuthorizationFilterDefinition instance for performing existence checks.");

                                var viewSqlSupport = viewBasedFilterDefinition.ViewBasedSingleItemAuthorizationQuerySupport;
                                
                                if (j > 0)
                                {
                                    // NOTE: Individual filters (segments) are always combined with AND
                                    s.Append(" AND ");
                                }

                                s.Append("EXISTS (");
                                s.Append(viewSqlSupport.GetItemExistenceCheckSql(viewBasedFilterDefinition, y.FilterContext));
                                s.Append(')');
                            }, s);

                        s.Append(')');
                    }, sql);

                sql.Append(" THEN 1 ELSE 0 END AS IsAuthorized");

                return sql.ToString();
            }

            string GetAuthorizationFailureMessage()
            {
                // NOTE: Embedded convention - UniqueId is suffix used for external representation of USI values
                string[] subjectEndpointNames = resultsWithPendingExistenceChecks
                    .SelectMany(asf => asf.FilterResults
                        .Select(f => f.FilterContext.SubjectEndpointName.ReplaceSuffix("USI", "UniqueId")))
                    .Distinct()
                    .OrderBy(n => n)
                    .ToArray();

                string subjectEndpointNamesText = $"'{string.Join("', '", subjectEndpointNames)}'";

                object[] claimEndpointValues = resultsWithPendingExistenceChecks.SelectMany(x => x.FilterResults.Select(f => f.FilterContext))
                    .FirstOrDefault()
                    ?.ClaimEndpointValues.OrderBy(Convert.ToInt32).ToArray();

                string claimOrClaims = Inflector.Inflect("claim", claimEndpointValues?.Length ?? 0);

                const int MaximumEdOrgClaimValuesToDisplay = 5;

                var claimEndpointValuesAsStrings =
                    claimEndpointValues?.Select(v => v.ToString()).Take(MaximumEdOrgClaimValuesToDisplay + 1).ToArray()
                    ?? Array.Empty<string>();

                string claimEndpointValuesText = GetClaimEndpointValuesText(claimEndpointValuesAsStrings, MaximumEdOrgClaimValuesToDisplay);

                if (subjectEndpointNames.Length == 1)
                {
                    return $"Authorization denied. No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and the resource item's {subjectEndpointNamesText} value.";
                }

                return $"Authorization denied. No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and one or more of the following properties of the resource item: {subjectEndpointNamesText}.";
            }

            string GetClaimEndpointValuesText(string[] claimEndpointValuesAsStrings, int maximumEdOrgClaimValuesToDisplay)
            {
                if (claimEndpointValuesAsStrings == null || claimEndpointValuesAsStrings.Length == 0)
                {
                    return "none";
                }
                
                var claimEndpointValuesForDisplayText = claimEndpointValuesAsStrings?.Take(maximumEdOrgClaimValuesToDisplay).ToList();

                if (claimEndpointValuesAsStrings.Length > maximumEdOrgClaimValuesToDisplay)
                {
                    claimEndpointValuesForDisplayText.Add("...");
                }

                string claimEndpointValuesText = string.Join(", ", claimEndpointValuesForDisplayText);

                return claimEndpointValuesText;
            }
        }

        protected IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering()
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();

            // Build the AuthorizationContext
            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();
            var claimSetClaims = _claimSetClaimsProvider.GetClaims(apiKeyContext.ClaimSetName);
            var resource = _dataManagementResourceContextProvider.Get().Resource;
            string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
            string requestActionUri = _authorizationContextProvider.GetAction();

            var authorizationContext = new EdFiAuthorizationContext(
                apiKeyContext,
                claimSetClaims,
                resource,
                resourceClaimUris,
                requestActionUri,
                typeof(TEntity));

            // Get authorization filters
            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                apiKeyContext.ClaimSetName,
                resourceClaimUris,
                requestActionUri);

            return _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);
        }
    }
    
    public class FilterAuthorizationResult
    {
        public AuthorizationFilterDefinition FilterDefinition { get; set; }

        public AuthorizationFilterContext FilterContext { get; set; }

        public InstanceAuthorizationResult Result { get; set; }
    }

    public class AuthorizationStrategyFilterResults
    {
        public string AuthorizationStrategyName { get; set; }

        public FilterOperator Operator { get; set; }

        public FilterAuthorizationResult[] FilterResults { get; set; }
    }
}
