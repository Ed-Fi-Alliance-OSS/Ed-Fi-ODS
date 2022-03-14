// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Filtering;

/// <summary>
/// Provides authorization filtering for the current authorization decision.
/// </summary>
public class AuthorizationFilteringProvider : IAuthorizationFilteringProvider
{
    // TODO: GKM - Review for possible removal of authorizationBasisMetadata from the GetAuthorizationFiltering signature.
    // private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
    //
    // public AuthorizationFilteringProvider(IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector)
    // {
    //     _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
    // }
    
    /// <summary>
    /// Authorizes a multiple-item read request using the claims, resource, and action supplied in the <see cref="EdFiAuthorizationContext"/>.
    /// </summary>
    /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
    /// <param name="authorizationBasisMetadata">The authorization metadata that is the basis for making the authorization decision.</param>
    /// <returns>The list of authorization strategy-based filters to be applied to the query for authorization.</returns>
    public IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering(
        EdFiAuthorizationContext authorizationContext, 
        AuthorizationBasisMetadata authorizationBasisMetadata)
    {
        // TODO: GKM - Review for possible removal of authorizationBasisMetadata from the GetAuthorizationFiltering signature.
        // authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext)
        
        var relevantClaims = new[] { authorizationBasisMetadata.RelevantClaim };

        var authorizationFiltering = authorizationBasisMetadata.AuthorizationStrategies
            .Distinct()
            .Select(x => x.GetAuthorizationStrategyFiltering(relevantClaims, authorizationContext))
            .ToArray();

        return authorizationFiltering;
    }
}
