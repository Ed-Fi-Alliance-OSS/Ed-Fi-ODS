// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Utils;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Providers;
using EdFi.Security.DataAccess.Caching;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using FakeItEasy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    [TestFixture]
    public class InstanceSecurityRepositoryCacheTest
    {
        protected const string InitializedKeyPrefix = "SecurityRepositoriesCache.Initialized";
        protected const string LastSyncedKey = "SecurityRepositoriesCache.LastSynced";

        protected const string TestInstanceId = "Instance1";

        protected MemoryCacheProvider CacheProvider { get; set; }

        protected InstanceSecurityRepositoryCache InstanceSecurityRepositoryCache;

        private IInstanceSecurityRepositoryCache MockInstanceSecurityRepositoryCallsAndInitializeCache(ISecurityContextFactory securityContextFactory)
        {
            InstanceSecurityRepositoryCacheObject values = new InstanceSecurityRepositoryCacheObject
            (
                 new Application { ApplicationId = 20, ApplicationName = "Ed-Fi ODS API" },
                null,
                null,
                null,
                null,
                null,
                null
            );

            var memoryCacheOption = A.Fake<IOptions<MemoryCacheOptions>>();

            MemoryCache memoryCache = new MemoryCache(memoryCacheOption);

            CacheProvider = new MemoryCacheProvider(memoryCache);

            CacheProvider.SetCachedObject(TestInstanceId, values);
            CacheProvider.SetCachedObject(GetLastSynchedKey(TestInstanceId), SystemClock.Now());
            CacheProvider.SetCachedObject(GetCurrentCacheInitializedKey(TestInstanceId), true);

            InstanceSecurityRepositoryCache = new InstanceSecurityRepositoryCache(securityContextFactory, CacheProvider);

            return InstanceSecurityRepositoryCache;
        }
        private string GetCurrentCacheInitializedKey(string instanceId)
        {
            return InitializedKeyPrefix + "." + instanceId;
        }

        private string GetLastSynchedKey(string instanceId)
        {
            return LastSyncedKey + "." + instanceId;
        }

        [Test]
        public void GetSecurityRepository_ForInstanceSecurityRepositoryCacheObject_Finds_Cache_Object_And_Does_Not_Need_To_Call_SecurityContextFactory()
        {
            // Fake securityContextFactory

            ISecurityContextFactory securityContextFactory = A.Fake<ISecurityContextFactory>();

            var cache = MockInstanceSecurityRepositoryCallsAndInitializeCache(securityContextFactory);
            var repositoryCacheObject = cache.GetSecurityRepository(TestInstanceId);

            int ApplicationId = 20;

            Assert.AreEqual(repositoryCacheObject.Application.ApplicationId, ApplicationId);

            // Asserting that the call to securityContextFactory.CreateContext() was not used due to cache object being present
            A.CallTo(() => securityContextFactory.CreateContext()).MustNotHaveHappened();
        }

        [Test]
        public void GetSecurityRepository_ForInstanceSecurityRepositoryCacheObject_Does_Not_Finds_Cache_Object_And_Calls_SecurityContextFactory()
        {
            ISecurityContextFactory securityContextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => securityContextFactory.CreateContext()).Returns(SecurityContextMock.GetMockedSecurityContext()).Once();

            var cache = MockInstanceSecurityRepositoryCallsAndInitializeCache(securityContextFactory);

            var repositoryCacheObject = cache.GetSecurityRepository("Instance2");

            int ApplicationId = 1;

            Assert.AreEqual(repositoryCacheObject.Application.ApplicationId, ApplicationId);
        }
    }
}