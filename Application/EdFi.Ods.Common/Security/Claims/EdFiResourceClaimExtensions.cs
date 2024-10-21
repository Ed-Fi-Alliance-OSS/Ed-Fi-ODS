// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Security.Claims;

public static class EdFiResourceClaimExtensions
{
    /// <summary>
    /// Gets the names of authorization strategy overrides for the specified action, if present.
    /// </summary>
    /// <param name="claim"></param>
    /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
    /// <returns>The authorization strategy overrides for the specified action; otherwise <b>null</b>.</returns>
    public static IReadOnlyList<string> GetAuthorizationStrategyNameOverrides(this ClaimSetResourceClaimMetadata claim, string action)
    {
        return claim.Actions
            .FirstOrDefault(x => x.Name == action)
            ?.AuthorizationStrategyNameOverrides;
    }

    /// <summary>
    /// Gets the names of the authorization strategy overrides for the specified action, if present.
    /// </summary>
    /// <param name="claim"></param>
    /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
    /// <returns>The authorization validation rule set name override for the specified action; otherwise <b>null</b>.</returns>
    public static string GetAuthorizationValidationRuleSetNameOverride(this ClaimSetResourceClaimMetadata claim, string action)
    {
        return claim.Actions
            .Where(x => x.Name == action)
            .Select(x => x.ValidationRuleSetNameOverride)
            .FirstOrDefault();
    }
}
