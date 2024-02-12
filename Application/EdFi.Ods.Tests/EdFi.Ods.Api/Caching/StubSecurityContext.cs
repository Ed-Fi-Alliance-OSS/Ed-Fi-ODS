// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;

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
            // The underlying SecurityRepository implementation expects this application, so force it to be there in the fake
            securityContext.Applications = GetFakeDbSet<Application>();
            securityContext.Actions = GetFakeDbSet<Action>();
            securityContext.ClaimSets = GetFakeDbSet<ClaimSet>();
            securityContext.ResourceClaims = GetFakeDbSet<ResourceClaim>();
            securityContext.AuthorizationStrategies = GetFakeDbSet<AuthorizationStrategy>();
            securityContext.ClaimSetResourceClaimActions = GetFakeDbSet<ClaimSetResourceClaimAction>();
            securityContext.ResourceClaimActionAuthorizationStrategies = GetFakeDbSet<ResourceClaimActionAuthorizationStrategies>();
            securityContext.ResourceClaimActions = GetFakeDbSet<ResourceClaimAction>();

            return securityContext;
        }

        private static DbSet<T> GetFakeDbSet<T>() where T : class
        {
            return null;
        }
    }
}
