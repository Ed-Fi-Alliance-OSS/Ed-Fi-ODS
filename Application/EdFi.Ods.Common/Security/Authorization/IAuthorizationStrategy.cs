// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Defines methods for authorizing both single-item requests, and multiple item requests (requiring filtering).
    /// </summary>
    public interface IAuthorizationStrategy
    {
        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The list of filters to be applied to the query for authorization.</returns>
        AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext);
    }
}
