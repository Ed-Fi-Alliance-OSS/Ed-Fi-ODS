﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NoFurtherAuthorization
{
    /// <summary>
    /// Implements an authorization strategy that performs no additional authorization.
    /// </summary>
    [AuthorizationStrategyName(AuthorizationStrategyName)]
    public class NoFurtherAuthorizationRequiredAuthorizationStrategy : IAuthorizationStrategy
    {
        private const string AuthorizationStrategyName = "NoFurtherAuthorizationRequired";

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            ClaimSetResourceClaimMetadata[] relevantClaims,
            DataManagementRequestContext authorizationContext)
        {
            // Note: all claim checks are done in the implementation of the IEdFiAuthorizationProvider.
            // Do nothing because the resource authorization metadata provider should have returned claims for the
            // requested action and the EdFi authorization provider should have validated.
            return new AuthorizationStrategyFiltering()
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = Array.Empty<AuthorizationFilterContext>(),
            };
        }
    }
}
