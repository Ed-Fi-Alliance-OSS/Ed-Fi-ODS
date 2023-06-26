// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

public class ClaimSetClaimsProvider : IClaimSetClaimsProvider
{
    private readonly ISecurityRepository _securityRepository;

    public ClaimSetClaimsProvider(ISecurityRepository securityRepository)
    {
        _securityRepository = securityRepository;
    }
    
    public IList<EdFiResourceClaim> GetClaims(string claimSetName)
    {
        var resourceClaims = _securityRepository.GetClaimsForClaimSet(claimSetName);

        // Group the resource claims by name to combine actions (and by claim set name if multiple claim sets are supported in the future)
        var resourceClaimsByClaimName = resourceClaims
            .GroupBy(c => c.ResourceClaim.ClaimName);
        
        // Create a list of resource claims to be issued.
        var claims = resourceClaimsByClaimName.Select(
                g => new EdFiResourceClaim(g.Key,
                    new EdFiResourceClaimValue
                    {
                        Actions = g.Select(
                                x => new ResourceAction(
                                    x.Action.ActionUri,
                                    x.AuthorizationStrategyOverrides
                                        ?.Select(y => y.AuthorizationStrategy.AuthorizationStrategyName)
                                        .ToArray(),
                                    x.ValidationRuleSetNameOverride))
                            .ToArray()
                    }))
            .ToList();

        return claims;
    }
}
