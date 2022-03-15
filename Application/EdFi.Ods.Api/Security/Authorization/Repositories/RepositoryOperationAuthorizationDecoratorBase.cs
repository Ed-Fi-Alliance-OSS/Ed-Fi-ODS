// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
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
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Filtering;
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
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
        private readonly IExplicitObjectValidator[] _explicitObjectValidators;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
        private readonly ISessionFactory _sessionFactory;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

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
            IApiKeyContextProvider apiKeyContextProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _authorizationFilteringProvider = authorizationFilteringProvider;
            _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
            _explicitObjectValidators = explicitObjectValidators;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _sessionFactory = sessionFactory;
            _apiKeyContextProvider = apiKeyContextProvider;

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
            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current, // TODO: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
                _authorizationContextProvider.GetResourceUris(),
                actionUri,
                entity);

            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext);

            ExecuteAuthorizationValidationRules(authorizationContext, authorizationBasisMetadata);

            // Get the authorization filtering information
            var authorizationFiltering =
                _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);

            var andResults = authorizationFiltering
                .Where(asf => asf.Operator == FilterOperator.And)
                .Select(
                    s => 
                        new
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
                                    x => new
                                    {
                                        FilterDefinition = x.FilterDefinition,
                                        Result = x.FilterDefinition.AuthorizeInstance(authorizationContext, x.FilterContext),
                                    })
                                .ToArray()
                        })
                .Select(x => 
                    new
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        FilterResults = x.FilterResults,
                        AuthorizationExceptions = x.FilterResults.Where(f => f.Result.State == AuthorizationState.Failed).Select(f => f.Result.Exception),
                    })

                .ToArray();
            
            // If any failures occurred with the AND strategies, throw the first exception now
            andResults
                .SelectMany(x => x.FilterResults)
                .Where(fr => fr.Result.State == AuthorizationState.Failed)
                .ForEach(fr => throw fr.Result.Exception);

            // For remaining pending authorizations requiring database access, get the existence checks SQL fragments  
            var pendingAndStrategies = andResults.Select(
                    x => new
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        PendingExistenceChecks = x.FilterResults
                            .Where(y => y.Result.State == AuthorizationState.NotPerformed)
                            .ToArray(),
                        AuthorizationExceptions = x.AuthorizationExceptions,
                    });
                
            var orResults = authorizationFiltering
                .Where(f => f.Operator == FilterOperator.Or)
                .Select(s => 
                    new
                    {
                        AuthorizationStrategyName = s.AuthorizationStrategyName,
                        Operator = s.Operator,
                        FilterResults = s.Filters
                            .Select(f => new
                            {
                                FilterDefinition = _authorizationFilterDefinitionProvider.GetFilterDefinition(f.FilterName),
                                FilterContext = f
                            })
                            .Select(x => new
                            { 
                                FilterDefinition = x.FilterDefinition,
                                Result = x.FilterDefinition.AuthorizeInstance(authorizationContext, x.FilterContext),
                            })
                            .ToArray()
                    })
                .Select(x => 
                    new
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        FilterResults = x.FilterResults,
                        AuthorizationExceptions = x.FilterResults.Where(f => f.Result.State == AuthorizationState.Failed).Select(f => f.Result.Exception),
                    })
                .ToArray();

            bool orConditionAlreadySatisfied = orResults
                .Any(r => r.FilterResults.All(f => f.Result.State == AuthorizationState.Success));

            if (orConditionAlreadySatisfied)
            {
                // Check for pending ANDs
                if (pendingAndStrategies.Any())
                {
                    // Execute SQL to determine AND results
                    throw new NotImplementedException("Strategies combined with 'OR' satisfied, but 'AND' SQL existence checks are not yet supported.");
                }

                return;
            }
            
            // We'll need to go to the database to check for relationship existence 
            var pendingOrStrategies = orResults
                // Only check any strategies that have no failures
                .Where(x => x.FilterResults.All(f => f.Result.State != AuthorizationState.Failed))
                .Select(
                    x => new
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        Operator = x.Operator,
                        PendingExistenceChecks = x.FilterResults
                            .Where(y => y.Result.State == AuthorizationState.NotPerformed)
                            .ToArray(),
                        AuthorizationExceptions = x.AuthorizationExceptions,
                    });

            var allPendingExistenceCheckStrategies = 
                pendingAndStrategies.Where(x => x.PendingExistenceChecks.Any())
                .Concat(pendingOrStrategies.Where(x => x.PendingExistenceChecks.Any()));

            // Build the existence check SQL
            StringBuilder sql = new();

            sql.Append("SELECT CASE WHEN ");

            allPendingExistenceCheckStrategies
                .ForEach(
                (x, i) =>
                {
                    if (i > 0)
                    {
                        if (x.Operator == FilterOperator.And)
                        {
                            sql.Append(" AND ");
                        }
                        else
                        {
                            sql.Append(" OR ");
                        }
                    }

                    sql.Append('(');

                    x.PendingExistenceChecks.ForEach(
                        (y, j) =>
                        {
                            if (j > 0)
                            {
                                // NOTE: Individual filters (segments) are always combined with AND
                                sql.Append(" AND ");
                            }

                            sql.Append("EXISTS (");
                            sql.Append((y.FilterDefinition as ViewBasedAuthorizationFilterDefinition)?.ItemExistenceSql 
                                ?? throw new InvalidOperationException("Expected a ViewBasedAuthorizationFilterDefinition instance for performing existence checks."));
                            sql.Append(')');
                        });

                    sql.Append(')');
                });

            sql.Append(" THEN 1 ELSE 0 END AS IsAuthorized");

            // Execute the query
            using var sessionScope = new SessionScope(_sessionFactory);

            await using var cmd = sessionScope.Session.Connection.CreateCommand();

            // Assign the command text
            cmd.CommandText = sql.ToString();

            // Assign all parameters
            cmd.Parameters.AddRange(
            authorizationFiltering.SelectMany(
                x => x.Filters.Select(
                    f =>
                    {
                        var parameter = cmd.CreateParameter();
                        parameter.ParameterName = f.SubjectEndpointName;
                        parameter.Value = f.SubjectEndpointValue;

                        return parameter;
                    }))
                .GroupBy(x => x.ParameterName)
                .Select(x => x.First())
                .ToArray());

            // Assign EdOrgId claims
            // TODO: GKM - Should this be added to the EdFiAuthorizationContext so that it can be retrieved once and passed along?
            var claimEdOrgIds= _apiKeyContextProvider.GetApiKeyContext().EducationOrganizationIds;

            // TODO: GKM - Need seam here for database-specific implementations
            if (cmd is SqlCommand)
            {
                var sqlParameter = cmd.CreateParameter() as SqlParameter;

                DataTable dt = new();
                dt.Columns.Add("Id", typeof(int));

                foreach (int claimEdOrgId in claimEdOrgIds)
                {
                    dt.Rows.Add(claimEdOrgId);
                }

                sqlParameter!.ParameterName = "ClaimEducationOrganizationIds";
                sqlParameter.SqlDbType = SqlDbType.Structured;
                sqlParameter.TypeName = "dbo.IntTable";
                sqlParameter.Value = dt;

                cmd.Parameters.Add(sqlParameter);
            }
            else
            {
                throw new NotImplementedException("PostgreSQL support for view-based single-item authorization is not yet implemented.");
            }
            
            // Process the pending AND SQL checks, ensure that they are all 1, or throw an exception
            var result = (int?) await cmd.ExecuteScalarAsync(cancellationToken);

            if (result == 0)
            {
                throw new Exception(
                    "Authorization denied. No relationships have been established between the caller's education organization id claims and the requested resource.");
            }
            
            // TODO: GKM - Need to work through generating the same message as before
            // string GetAuthorizationFailureMessage()
            // {
            //     // TODO: GKM - This is inefficient because it gets *all* claim endpoint names and applies distinct -- may include more endpoint names than relationship-based ones with multiple auth strategies in place
            //     string[] claimEndpointNames = authorizationFiltering
            //         .SelectMany(asf => asf.Filters.SelectMany(f => f.ClaimEndpointNames))
            //         .Distinct()
            //         .ToArray();
            //     
            //         // authorizationSegments.FirstOrDefault()?.ClaimsEndpoints.Select(x => x.Name)
            //         //     .Distinct()
            //         //     .ToArray()
            //         // ?? Array.Empty<string>();
            //
            //     // NOTE: Embedded convention - UniqueId is suffix used for external representation of USI values
            //     // TODO: GKM - This is inefficient because it gets *all* subject endpoint names and applies distinct -- may include more endpoint names than relationship-based ones with multiple auth strategies in place
            //     string[] subjectEndpointNames = authorizationFiltering
            //         .SelectMany(asf => asf.Filters.Select(f => f.SubjectEndpointName.ReplaceSuffix("USI", "UniqueId")))
            //         .Distinct()
            //         .ToArray();
            //     
            //         // authorizationSegments
            //         // .Select(x => x.SubjectEndpoint.Name.ReplaceSuffix("USI", "UniqueId"))
            //         // .Distinct()
            //         // .ToArray();
            //
            //     string claimEndpointNamesText = $"'{string.Join("', '", claimEndpointNames)}'";
            //     string subjectEndpointNamesText = $"'{string.Join("', '", subjectEndpointNames)}'";
            //     
            //     string typeOrTypes = Inflector.Inflect("type", claimEndpointNames.Length);
            //     string claimOrClaims = Inflector.Inflect("claim", claimEndpointNames.Length);
            //
            //     string claimValueOrValues = Inflector.Inflect(
            //         "value", authorizationSegments.FirstOrDefault()?.ClaimsEndpoints.Count ?? 0);
            //
            //     const int MaximumEdOrgClaimValuesToDisplay = 5;
            //
            //     var claimEndpointValues =
            //         (authorizationSegments.FirstOrDefault()?.ClaimsEndpoints.Select(x => x.Value.ToString())
            //             ?? Array.Empty<string>())
            //         .Take(MaximumEdOrgClaimValuesToDisplay + 1)
            //         .ToArray();
            //
            //     var claimEndpointValuesForDisplayText = claimEndpointValues
            //         ?.Take(MaximumEdOrgClaimValuesToDisplay)
            //         .ToList();
            //
            //     if (claimEndpointValues.Length > MaximumEdOrgClaimValuesToDisplay)
            //     {
            //         claimEndpointValuesForDisplayText.Add("...");
            //     }
            //     
            //     string claimEndpointValuesText = string.Join(", ", claimEndpointValuesForDisplayText);
            //     
            //     if (subjectEndpointNames.Length == 1)
            //     {
            //         return $"Authorization denied. No relationships have been established between the caller's education "
            //             + $"organization id {claimOrClaims} ({claimValueOrValues} {claimEndpointValuesText} of {typeOrTypes} {claimEndpointNamesText}) and the requested resource's "
            //             + $"{subjectEndpointNamesText} value.";
            //     }
            //
            //     return $"Authorization denied. No relationships have been established between the caller's education "
            //         + $"organization id {claimOrClaims} ({claimValueOrValues} {claimEndpointValuesText} of {typeOrTypes} {claimEndpointNamesText}) and one of the following properties of "
            //         + $"the requested resource: {subjectEndpointNamesText}.";
            // }

            bool IsCreateUpdateOrDelete(EdFiAuthorizationContext authorizationContext)
            {
                return (_bitValuesByAction.Value[authorizationContext.Action.Single().Value] 
                    & (Actions.Create | Actions.Update | Actions.Delete)) != 0;
            }

            void ExecuteAuthorizationValidationRules(
                EdFiAuthorizationContext edFiAuthorizationContext,
                AuthorizationBasisMetadata authorizationBasisMetadata1)
            {
                // If there are explicit object validators, and we're modifying data
                if (_explicitObjectValidators.Any() && IsCreateUpdateOrDelete(edFiAuthorizationContext))
                {
                    // Validate the object using explicit validation
                    var validationResults = _explicitObjectValidators.ValidateObject(
                        edFiAuthorizationContext.Data,
                        authorizationBasisMetadata1.ValidationRuleSetName);

                    if (!validationResults.IsValid())
                    {
                        throw new ValidationException(
                            string.Format(
                                "Validation of '{0}' failed.\n{1}",
                                edFiAuthorizationContext.Data.GetType().Name,
                                string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))));
                    }
                }
            }
        }

        protected IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering()
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();
        
            // Build the AuthorizationContext
            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current,
                _authorizationContextProvider.GetResourceUris(),
                _authorizationContextProvider.GetAction(),
                typeof(TEntity));
        
            // Get authorization filters
            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext);

            return _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);
        }
    }
}
