// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;
using EdFi.Ods.Api.Security.Extensions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

public interface IEntityInstanceViewBasedFilterAuthorizer
{
    Task PerformViewBasedAuthorizationAsync(
        AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks,
        IList<long> claimEducationOrganizationIds,
        AuthorizationPhase authorizationPhase);
}

public class EntityInstanceViewBasedFilterAuthorizer : IEntityInstanceViewBasedFilterAuthorizer
{
    private readonly IEntityAuthorizationSqlBuilder _entityAuthorizationSqlBuilder;
    private readonly IEntityAuthorizationQueryExecutor _entityAuthorizationQueryExecutor;
    private readonly IAuthorizationViewHintProvider[] _authorizationViewHintProviders;

    public EntityInstanceViewBasedFilterAuthorizer(
        IEntityAuthorizationSqlBuilder entityAuthorizationSqlBuilder,
        IEntityAuthorizationQueryExecutor entityAuthorizationQueryExecutor,
        IAuthorizationViewHintProvider[] authorizationViewHintProviders)
    {
        _entityAuthorizationSqlBuilder = entityAuthorizationSqlBuilder;
        _entityAuthorizationQueryExecutor = entityAuthorizationQueryExecutor;
        _authorizationViewHintProviders = authorizationViewHintProviders;
    }

    public async Task PerformViewBasedAuthorizationAsync(
        AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks,
        IList<long> claimEducationOrganizationIds,
        AuthorizationPhase authorizationPhase)
    {
        // Before building and executing authorization SQL, check for null values on subject endpoints
        var parameterDetails = resultsWithPendingExistenceChecks.SelectMany(
                x => x.FilterResults.SelectMany(f => 
                    f.FilterContext.SubjectEndpointNames.Select((n, i) => 
                        new KeyValuePair<string, object>(n, f.FilterContext.SubjectEndpointValues[i])
                        // (ParameterName: n, ParameterValue: f.FilterContext.SubjectEndpointValues[i])
                        )))
            .GroupBy(x => x.Key)
            .Select(x => x.First())
            .ToArray();

        int? validationResult = 0;

        // Ensure all the parameter values actually have values before hitting the database...
        if (parameterDetails.All(pd => pd.Value != null))
        {
            string sql = _entityAuthorizationSqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks);

            validationResult = await _entityAuthorizationQueryExecutor.ExecuteAsync(
                sql,
                parameterDetails,
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds);
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

            string GetAuthorizationFailureMessage()
            {
                // NOTE: Embedded convention - UniqueId is suffix used for external representation of USI values
                string[] subjectEndpointNames = resultsWithPendingExistenceChecks
                    .SelectMany(asf => asf.FilterResults
                        .SelectMany(f => 
                            f.FilterContext.SubjectEndpointNames.Select(n => n.ReplaceSuffix("USI", "UniqueId"))))
                    .Distinct()
                    .OrderBy(n => n)
                    .ToArray();

                string subjectEndpointNamesText = $"'{string.Join("', '", subjectEndpointNames)}'";

                object[] claimEndpointValues = resultsWithPendingExistenceChecks
                    .SelectMany(x => x.FilterResults.Select(f => f.FilterContext))
                    .FirstOrDefault()
                    ?.ClaimEndpointValues
                    ?.OrderBy(Convert.ToInt64)
                    .ToArray();

                if (claimEndpointValues == null)
                {
                    // Custom view support introduced usage scenario here where no claims are relevant
                    if (subjectEndpointNames.Length == 1)
                    {
                        return $"The caller is not authorized to perform the requested operation on the item based on the {authorizationPhase.GetPhaseText("existing", "proposed")} value of the {subjectEndpointNamesText} property of the item.";
                    }

                    return $"The caller is not authorized to perform the requested operation on the item based on the {authorizationPhase.GetPhaseText("existing", "proposed")} values of one or more of the following properties of the item: {subjectEndpointNamesText}.";
                }

                // Assumption: Claims are always EdOrgIds, if present.
                string claimOrClaims = Inflector.Inflect("claim", claimEndpointValues?.Length ?? 0);

                const int MaximumEdOrgClaimValuesToDisplay = 5;

                var claimEndpointValuesAsStrings =
                    claimEndpointValues?.Select(v => v.ToString()).Take(MaximumEdOrgClaimValuesToDisplay + 1).ToArray()
                    ?? Array.Empty<string>();

                string claimEndpointValuesText = GetClaimEndpointValuesText(
                    claimEndpointValuesAsStrings,
                    MaximumEdOrgClaimValuesToDisplay);

                if (subjectEndpointNames.Length == 1)
                {
                    return $"No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and the resource item's {subjectEndpointNamesText} value.";
                }

                return $"No relationships have been established between the caller's education organization id {claimOrClaims} ({claimEndpointValuesText}) and one or more of the following properties of the resource item: {subjectEndpointNamesText}.";

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
        }
    }
}
