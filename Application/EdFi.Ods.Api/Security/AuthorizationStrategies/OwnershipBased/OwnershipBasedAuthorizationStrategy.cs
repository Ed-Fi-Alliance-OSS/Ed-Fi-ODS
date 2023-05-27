// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationStrategy : IAuthorizationStrategy
    {
        private const string AuthorizationStrategyName = "OwnershipBased";

        /// <summary>
        /// Get authorization filtering context for a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        AuthorizationStrategyFiltering IAuthorizationStrategy.GetAuthorizationStrategyFiltering(
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var ownershipTokens = authorizationContext.ClaimSetClaims
                .Where(c => c.ClaimName == EdFiOdsApiClaimTypes.OwnershipTokenId)
                .Select(x => (object) x.ClaimValue)
                .ToArray();

            return new AuthorizationStrategyFiltering()
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = new[]
                {
                    new AuthorizationFilterContext
                    {
                        FilterName = "CreatedByOwnershipTokenId",
                        ClaimEndpointValues = ownershipTokens,
                        SubjectEndpointName = "CreatedByOwnershipTokenId",
                        ClaimParameterName = "CreatedByOwnershipTokenId",
                    }
                },
                Operator = FilterOperator.And,
                UsesSystemAssignedValues = true
            };
        }
    }
}
