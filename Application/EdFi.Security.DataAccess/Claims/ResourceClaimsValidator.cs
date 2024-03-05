// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Security.DataAccess.Claims;

public class ResourceClaimsValidator : IResourceClaimsValidator
{
    private readonly ISecurityTableGateway _securityTableGateway;
    
    public ResourceClaimsValidator(ISecurityTableGateway securityTableGateway)
    {
        _securityTableGateway = securityTableGateway ?? throw new ArgumentNullException(nameof(securityTableGateway));
    }
    
    public void ValidateResourceClaimLineageForResourceClaim(string resourceClaimUri)
    {
        ResourceClaim resourceClaim;
        HashSet<int> visitedResourceClaimIds = new();
        
        try
        {
            resourceClaim = _securityTableGateway.GetResourceClaims()
                .SingleOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.OrdinalIgnoreCase));
        }
        catch (InvalidOperationException ex)
        {
            // Use InvalidOperationException wrapper with custom message over InvalidOperationException
            // thrown by Linq to communicate back to caller the problem with the configuration.
            throw new InvalidOperationException($"Multiple resource claims with a claim name of '{resourceClaimUri}' were found in the Ed-Fi API's security configuration. Authorization cannot be performed.", ex);
        }
        
        if(resourceClaim == null)
            return;

        visitedResourceClaimIds.Add(resourceClaim.ResourceClaimId);
        
        while(resourceClaim.ParentResourceClaimId != null)
        { 
            resourceClaim = _securityTableGateway
                    .GetResourceClaims().SingleOrDefault(rc => rc.ResourceClaimId == resourceClaim.ParentResourceClaimId);
            
            if (visitedResourceClaimIds.Contains(resourceClaim.ResourceClaimId))
            {
                throw new InvalidOperationException($"The lineage for resource claim '{resourceClaimUri}' is not well-formed. A cycle was detected in the resource claim lineage.");
            }
            
            visitedResourceClaimIds.Add(resourceClaim.ResourceClaimId);
        }
    }
}
