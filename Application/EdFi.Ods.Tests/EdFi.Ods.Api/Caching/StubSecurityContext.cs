// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using FakeItEasy;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    public class SecurityContextMock
    {
        /// <summary>
        /// Sets up a queryable fake security context with minimal data
        /// </summary>
        /// <returns></returns>
        public static ISecurityContext GetMockedSecurityContext()
        {
            var securityContext = A.Fake<ISecurityContext>();
            
            securityContext.Applications = null!;
            securityContext.Actions = null!;
            securityContext.ClaimSets = null!;
            securityContext.ResourceClaims = null!;
            securityContext.AuthorizationStrategies = null!;
            securityContext.ClaimSetResourceClaimActions = null!;
            securityContext.ResourceClaimActionAuthorizationStrategies = null!;
            securityContext.ResourceClaimActions = null!;

            return securityContext;
        }
    }
}
