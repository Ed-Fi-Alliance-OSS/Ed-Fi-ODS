// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Security.DataAccess.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization.Repositories;

public class EntityAuthorizer : IEntityAuthorizer
{
    private readonly IAuthorizationContextProvider _authorizationContextProvider;
    private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
    private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
    private readonly IExplicitObjectValidator[] _explicitObjectValidators;
    private readonly IApiClientContextProvider _apiClientContextProvider;
    private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
    private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IContextProvider<ViewBasedAuthorizationQueryContext> _viewBasedAuthorizationQueryContextProvider;
    private readonly IAuthorizationViewHintProvider[] _authorizationViewHintProviders;
    private readonly ISessionFactory _sessionFactory;

    private readonly Lazy<Dictionary<string, Actions>> _bitValuesByAction;

    [Flags]
    private enum Actions
    {
        Create = 0x1,
        Read = 0x2,
        Update = 0x4,
        Delete = 0x8,
    }

    public EntityAuthorizer(
        IAuthorizationContextProvider authorizationContextProvider,
        IAuthorizationFilteringProvider authorizationFilteringProvider,
        IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
        IExplicitObjectValidator[] explicitObjectValidators,
        IApiClientContextProvider apiClientContextProvider,
        IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
        ISessionFactory sessionFactory,
        ISecurityRepository securityRepository,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IContextProvider<ViewBasedAuthorizationQueryContext> viewBasedAuthorizationQueryContextProvider,
        IAuthorizationViewHintProvider[] authorizationViewHintProviders)
    {
        _authorizationContextProvider = authorizationContextProvider;
        _authorizationFilteringProvider = authorizationFilteringProvider;
        _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
        _explicitObjectValidators = explicitObjectValidators;
        _apiClientContextProvider = apiClientContextProvider;
        _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
        _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _viewBasedAuthorizationQueryContextProvider = viewBasedAuthorizationQueryContextProvider;
        _authorizationViewHintProviders = authorizationViewHintProviders;
        _sessionFactory = sessionFactory;
        
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

    /// <inheritdoc cref="IEntityAuthorizer.AuthorizeEntityAsync" />
    public async Task AuthorizeEntityAsync(object entity, string actionUri, AuthorizationPhase authorizationPhase, CancellationToken cancellationToken)
    {
        // Make sure Authorization context is present before proceeding
        _authorizationContextProvider.VerifyAuthorizationContextExists();

        // Build the AuthorizationContext
        var apiClientContext = _apiClientContextProvider.GetApiClientContext();
        string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
        var resource = _dataManagementResourceContextProvider.Get().Resource;

        var authorizationContext = new EdFiAuthorizationContext(
            apiClientContext,
            resource,
            resourceClaimUris,
            actionUri,
            entity,
            authorizationPhase);

        var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
            apiClientContext.ClaimSetName, resourceClaimUris, actionUri);

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
                    string validationResultsText = string.Join(".", validationResults.Select(vr => vr.ToString()));

                    throw new ValidationException(
                        $"Validation of '{requestData.GetType().Name}' failed. {validationResultsText}");
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
                                    Result = x.FilterDefinition.AuthorizeInstance(authorizationContext1, x.FilterContext, s.AuthorizationStrategyName)
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
        // Before building and executing authorization SQL, check for null values on subject endpoints
        var parameterDetails = resultsWithPendingExistenceChecks.SelectMany(
                x => x.FilterResults.Select(f => (ParameterName: f.FilterContext.SubjectEndpointName, ParameterValue: f.FilterContext.SubjectEndpointValue)))
            .GroupBy(x => x.ParameterName)
            .Select(x => x.First())
            .ToArray();

        int? validationResult = 0;

        // Ensure all the parameter values actually have values before hitting the database...
        if (parameterDetails.All(pd => pd.ParameterValue != null))
        {
            validationResult = await ExecuteSingleItemAuthorizationQuery();
        }

        // Result will be null if it's redundant with an earlier check already performed in this call context
        if (validationResult == null)
        {
            return;
        }

        if (validationResult == 0)
        {
            var authorizationViewNames = resultsWithPendingExistenceChecks.SelectMany(
                    x => x.FilterResults.Select(f => f.FilterDefinition)
                        .OfType<ViewBasedAuthorizationFilterDefinition>()
                        .Select(f => f.ViewName))
                .Distinct();

            var hints = authorizationViewNames.SelectMany(
                    v => _authorizationViewHintProviders.Select(p => p.GetFailureHint(v)).Where(h => !string.IsNullOrEmpty(h)))
                .Distinct()
                .ToArray();

            if (hints.Any())
            {
                throw new SecurityAuthorizationException(
                    $"{SecurityAuthorizationException.DefaultDetail} Hint: {string.Join(" ", hints)}",
                    GetAuthorizationFailureMessage());
            }

            throw new SecurityAuthorizationException(SecurityAuthorizationException.DefaultDetail, GetAuthorizationFailureMessage());
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
                ?.ClaimEndpointValues.OrderBy(Convert.ToInt64).ToArray();

            string claimOrClaims = Inflector.Inflect("claim", claimEndpointValues?.Length ?? 0);

            const int MaximumEdOrgClaimValuesToDisplay = 5;

            var claimEndpointValuesAsStrings =
                claimEndpointValues?.Select(v => v.ToString()).Take(MaximumEdOrgClaimValuesToDisplay + 1).ToArray()
                ?? Array.Empty<string>();

            string claimEndpointValuesText = GetClaimEndpointValuesText(claimEndpointValuesAsStrings, MaximumEdOrgClaimValuesToDisplay);

            if (subjectEndpointNames.Length == 1)
            {
                return $"No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and the resource item's {subjectEndpointNamesText} value.";
            }

            return $"No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and one or more of the following properties of the resource item: {subjectEndpointNamesText}.";
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

        async Task<int?> ExecuteSingleItemAuthorizationQuery()
        {
            string sql = BuildExistenceCheckSql(resultsWithPendingExistenceChecks);

            // Execute the query
            using var sessionScope = new SessionScope(_sessionFactory);

            await using var cmd = sessionScope.Session.Connection.CreateCommand();
            sessionScope.Session.GetCurrentTransaction()?.Enlist(cmd);

            // Assign the command text
            cmd.CommandText = sql;

            // Assign all parameters
            var parameters = parameterDetails.Select(pd => {
                    var parameter = cmd.CreateParameter();
                    parameter.ParameterName = pd.ParameterName;
                    parameter.Value = pd.ParameterValue;

                    return parameter;
                })
                .ToArray();

            cmd.Parameters.AddRange(parameters);

            // Check for previous identical execution in current context
            var viewBasedAuthorizationQueryContext = _viewBasedAuthorizationQueryContextProvider.Get();

            if (IsRedundantAuthorizationForCurrentContext())
            {
                return null;
            }

            _viewBasedSingleItemAuthorizationQuerySupport.ApplyClaimsParametersToCommand(cmd, authorizationContext);

            // Process the pending AND SQL checks to get a result (0 for failure, 1 for success)
            validationResult = (int?) await cmd.ExecuteScalarAsync(cancellationToken) ?? 0;

            // Save the SQL and parameters for this query execution into the current context (if context is present but uninitialized)
            if (viewBasedAuthorizationQueryContext is { Sql: null })
            {
                viewBasedAuthorizationQueryContext.Sql = cmd.CommandText;
                viewBasedAuthorizationQueryContext.Parameters = parameters;
            }

            return validationResult;
            
            bool IsRedundantAuthorizationForCurrentContext()
            {
                // Has the context been set (indicating we're upserting) and is the current SQL already present? 
                if (viewBasedAuthorizationQueryContext != null && viewBasedAuthorizationQueryContext.Sql == sql)
                {
                    // Check the parameters for equality
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        // Do parameter values differ?
                        if (!parameters[i].Value.Equals(viewBasedAuthorizationQueryContext.Parameters[i].Value))
                        {
                            // Authorization is not redundant
                            return false;
                        }
                    }

                    // SQL and parameters match - authorization is redundant
                    return true;
                }

                // No context present, or SQL doesn't match -- not redundant
                return false;
            }
        }
    }
}
