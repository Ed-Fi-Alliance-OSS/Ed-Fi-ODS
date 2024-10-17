// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public interface IRequestEvaluationValidationRuleSetSelector
{
    string GetValidationRuleSetName(ClaimSetRequestEvaluation requestEvaluation);
}

public class RequestEvaluationValidationRuleSetSelector : IRequestEvaluationValidationRuleSetSelector
{
    public string GetValidationRuleSetName(ClaimSetRequestEvaluation requestEvaluation)
    {
        // Look for an authorization validation rule set name override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        string ruleSetNameOverride = requestEvaluation.ClaimSetResourceClaimLineage
            .Select(rpc => rpc.GetAuthorizationValidationRuleSetNameOverride(requestEvaluation.RequestedAction))
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        var metadataRuleSetNames = requestEvaluation.DefaultResourceClaimLineage.Select(rcas => rcas.ValidationRuleSetName);

        string ruleSetName = ruleSetNameOverride ?? metadataRuleSetNames.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        return ruleSetName;
    }
}
