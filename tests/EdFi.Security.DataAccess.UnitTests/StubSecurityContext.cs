// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using FakeItEasy;
using MockQueryable.FakeItEasy;

namespace EdFi.Security.DataAccess.UnitTests
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
            securityContext.Actions = GetFakeDbSet<Action>().AsQueryable().BuildMockDbSet();
            securityContext.AuthorizationStrategies = GetFakeDbSet<AuthorizationStrategy>().AsQueryable().BuildMockDbSet();
            securityContext.ClaimSets = GetFakeDbSet<ClaimSet>().AsQueryable().BuildMockDbSet();
            securityContext.ClaimSetResourceClaimActions = GetFakeDbSet<ClaimSetResourceClaimAction>().AsQueryable().BuildMockDbSet();
            securityContext.ResourceClaims = GetFakeDbSet<ResourceClaim>().AsQueryable().BuildMockDbSet();
            securityContext.ResourceClaimActions = GetFakeDbSet<ResourceClaimAction>().AsQueryable().BuildMockDbSet();
            securityContext.ClaimSetResourceClaimActionAuthorizationStrategyOverrides = GetFakeDbSet<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>().AsQueryable().BuildMockDbSet();
            securityContext.ResourceClaimActionAuthorizationStrategies = GetFakeDbSet<ResourceClaimActionAuthorizationStrategies>().AsQueryable().BuildMockDbSet();

            return securityContext;
        }

        private static DbSet<T> GetFakeDbSet<T>() where T : class
        {
            return A.Fake<DbSet<T>>(o => o.Implements(typeof(IQueryable<T>)).Implements(typeof(IDbAsyncEnumerable<T>)));
        }
    }
}
