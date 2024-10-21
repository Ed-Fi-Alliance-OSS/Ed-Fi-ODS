// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public interface IRequestEvaluationStrategiesSelector
{
    bool TryGetAuthorizationStrategyNames(
        ClaimSetRequestEvaluation requestEvaluation,
        out IReadOnlyList<string> authorizationStrategyNames);
}

public class RequestEvaluationStrategiesSelector : IRequestEvaluationStrategiesSelector
{
    public bool TryGetAuthorizationStrategyNames(
        ClaimSetRequestEvaluation requestEvaluation,
        out IReadOnlyList<string> authorizationStrategyNames)
    {
        // Look for an authorization strategy override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        var authorizationStrategyOverrideNames = requestEvaluation.ClaimSetResourceClaimLineage
            .Select(rpc => rpc.GetAuthorizationStrategyNameOverrides(requestEvaluation.RequestedAction))
            .FirstOrDefault(x => x != null);

        var metadataAuthorizationStrategyNames = requestEvaluation.DefaultResourceClaimLineage
            .Where(s => s.AuthorizationStrategies != null && s.AuthorizationStrategies.Any())
            .Select(s => s.AuthorizationStrategies);

        // Use the claim's override, if present
        var resultAuthorizationStrategyNames = authorizationStrategyOverrideNames ?? metadataAuthorizationStrategyNames.FirstOrDefault();

        if (resultAuthorizationStrategyNames is { Count: > 0 })
        {
            authorizationStrategyNames = resultAuthorizationStrategyNames;
            return true;
        }

        authorizationStrategyNames = null;
        return false;
    }
}
