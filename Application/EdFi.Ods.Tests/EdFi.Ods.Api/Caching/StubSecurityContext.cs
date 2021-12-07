// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
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
            // The underlying SecurityRepository implementation expects this application, so force it to be there in the fake
            securityContext.Applications = GetFakeDbSet<Application>().SetupData(new List<Application> { new Application { ApplicationId = 1, ApplicationName = "Ed-Fi ODS API" } });
            securityContext.Actions = GetFakeDbSet<Action>().SetupData();
            securityContext.AuthorizationStrategies = GetFakeDbSet<AuthorizationStrategy>().SetupData();
            securityContext.ClaimSets = GetFakeDbSet<ClaimSet>().SetupData();
            securityContext.ClaimSetResourceClaimActions = GetFakeDbSet<ClaimSetResourceClaimAction>().SetupData();
            securityContext.ResourceClaims = GetFakeDbSet<ResourceClaim>().SetupData();
            securityContext.ResourceClaimActions = GetFakeDbSet<ResourceClaimAction>().SetupData();

            return securityContext;
        }

        private static DbSet<T> GetFakeDbSet<T>() where T : class
        {
            return A.Fake<DbSet<T>>(o => o.Implements(typeof(IQueryable<T>)).Implements(typeof(IDbAsyncEnumerable<T>)));
        }
    }
}
