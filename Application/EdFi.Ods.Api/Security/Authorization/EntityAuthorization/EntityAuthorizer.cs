// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using log4net;

namespace EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

public class EntityAuthorizer : IEntityAuthorizer
{
    private readonly IDataManagementAuthorizationPlanFactory _dataManagementAuthorizationPlanFactory;
    private readonly IEntityInstanceDelegateFilterAuthorizer _entityInstanceDelegateFilterAuthorizer;
    private readonly IEntityInstanceAuthorizationValidator _entityInstanceAuthorizationValidator;
    private readonly IEntityInstanceViewBasedFilterAuthorizer _entityInstanceViewBasedFilterAuthorizer;

    public EntityAuthorizer(
        IDataManagementAuthorizationPlanFactory dataManagementAuthorizationPlanFactory,
        IEntityInstanceDelegateFilterAuthorizer entityInstanceDelegateFilterAuthorizer,
        IEntityInstanceAuthorizationValidator entityInstanceAuthorizationValidator,
        IEntityInstanceViewBasedFilterAuthorizer entityInstanceViewBasedFilterAuthorizer)
    {
        _entityInstanceDelegateFilterAuthorizer = entityInstanceDelegateFilterAuthorizer;
        _entityInstanceAuthorizationValidator = entityInstanceAuthorizationValidator;
        _entityInstanceViewBasedFilterAuthorizer = entityInstanceViewBasedFilterAuthorizer;
        _dataManagementAuthorizationPlanFactory = dataManagementAuthorizationPlanFactory;
    }

    /// <inheritdoc cref="IEntityAuthorizer.AuthorizeEntityAsync" />
    public async Task AuthorizeEntityAsync(
        object entity,
        string actionUri,
        AuthorizationPhase authorizationPhase,
        CancellationToken cancellationToken)
    {
        if (actionUri == null)
        {
            throw new AuthorizationContextException(
                "Authorization cannot be performed because the action being performed has not been identified.");
        }

        // Get the authorization filtering information
        var authorizationPlan = _dataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(
            actionUri,
            entity,
            authorizationPhase);

        _entityInstanceAuthorizationValidator.Validate(
            authorizationPlan.RequestContext.Data,
            authorizationPlan.RequestContext.Action,
            authorizationPlan.AuthorizationBasisMetadata.ValidationRuleSetName);

        var andResults = _entityInstanceDelegateFilterAuthorizer.PerformInstanceBasedAuthorization(
            FilterOperator.And,
            authorizationPlan.Filtering,
            authorizationPlan.RequestContext);

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

        var orResults = _entityInstanceDelegateFilterAuthorizer.PerformInstanceBasedAuthorization(
            FilterOperator.Or,
            authorizationPlan.Filtering,
            authorizationPlan.RequestContext);

        bool orConditionAlreadySatisfied = orResults
            .Any(r => r.FilterResults.All(f => f.Result.State == AuthorizationState.Success));

        if (orConditionAlreadySatisfied || !orResults.Any())
        {
            // Check for pending ANDs
            if (pendingAndStrategies.Any())
            {
                // Execute SQL to determine AND results
                await _entityInstanceViewBasedFilterAuthorizer.PerformViewBasedAuthorizationAsync(
                    pendingAndStrategies,
                    authorizationPlan.RequestContext.ApiClientContext.EducationOrganizationIds,
                    authorizationPlan.RequestContext.AuthorizationPhase);
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

        await _entityInstanceViewBasedFilterAuthorizer.PerformViewBasedAuthorizationAsync(
            allPendingExistenceChecks,
            authorizationPlan.RequestContext.ApiClientContext.EducationOrganizationIds,
            authorizationPlan.RequestContext.AuthorizationPhase);

        void ThrowInstanceBasedFailureFromResults(AuthorizationStrategyFilterResults[] results)
        {
            results.SelectMany(x => x.FilterResults)
                .Where(fr => fr.Result.State == AuthorizationState.Failed)
                .ForEach(fr => throw fr.Result.Exception);
        }
    }
}
