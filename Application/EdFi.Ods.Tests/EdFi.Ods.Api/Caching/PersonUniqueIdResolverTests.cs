// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    [TestFixture]
    public class PersonUniqueIdResolverTests
    {
        private IPersonIdentifiersProvider _fakePersonIdentifiersProvider;
        private IMapCache<(ulong, string, PersonMapType), int, string> _fakeMapCache;
        private Dictionary<string, bool> _fakeCacheSuppressionByPersonType;
        private IPersonMapCacheInitializer _fakePersonMapCacheInitializer;
        private IContextProvider<OdsInstanceConfiguration> _fakeOdsInstanceConfigurationContextProvider;

        [SetUp]
        public void Arrange()
        {
            _fakePersonIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
            _fakeMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
            _fakeCacheSuppressionByPersonType = new Dictionary<string, bool>();
            _fakePersonMapCacheInitializer = A.Fake<IPersonMapCacheInitializer>();

            var odsInstanceConfiguration = new OdsInstanceConfiguration(
                1,
                123456UL,
                "conn",
                new Dictionary<string, string>(),
                new Dictionary<DerivativeType, string>());

            _fakeOdsInstanceConfigurationContextProvider =
                new TestContextProvider<OdsInstanceConfiguration>(odsInstanceConfiguration);
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromCache_WhenCacheIsInitialized()
        {
            // Arrange
            var personType = "Student";
            var lookups = new Dictionary<int, string>
            {
                { 1, null },
                { 2, null }
            };

            // Simulate that the cache is already initialized
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);
            
            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new[] { "UniqueId1", "UniqueId2" });

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeCacheSuppressionByPersonType);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            lookups.ShouldSatisfyAllConditions(
                () => lookups.Count.ShouldBe(2),
                () => lookups[1].ShouldBe("UniqueId1"),
                () => lookups[2].ShouldBe("UniqueId2"));

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType, A<int[]>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromOds_WhenCacheIsNotInitialized()
        {
            // Arrange
            var personType = "Student";
            var lookups = new Dictionary<int, string>
            {
                { 1, null },
                { 2, null }
            };

            // Simulate that the cache is not yet initialized
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new string[2]);

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new[]
                {
                    new PersonIdentifiersValueMap { Usi = 1, UniqueId = "UniqueId1" },
                    new PersonIdentifiersValueMap { Usi = 2, UniqueId = "UniqueId2" }
                });

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeCacheSuppressionByPersonType);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            lookups.ShouldSatisfyAllConditions(
                () => lookups.Count.ShouldBe(2),
                () => lookups[1].ShouldBe("UniqueId1"),
                () => lookups[2].ShouldBe("UniqueId2"));

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType, A<int[]>.Ignored))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromOdsOnce_WhenCacheInitializationFails()
        {
            // Arrange
            var personType = "Student";
            var lookups = new Dictionary<int, string>
            {
                { 1, null },
                { 2, null }
            };

            // Simulate that cache initialization fails
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new string[2]);

            A.CallTo(() => _fakePersonMapCacheInitializer.EnsurePersonMapsInitialized(
                123456UL, personType))
                .Returns(Task.FromException(new Exception("Cache initialization failed")));

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType, 
            A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new[]
                {
                    new PersonIdentifiersValueMap { Usi = 1, UniqueId = "UniqueId1" },
                    new PersonIdentifiersValueMap { Usi = 2, UniqueId = "UniqueId2" }
                });

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeCacheSuppressionByPersonType);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            lookups.ShouldSatisfyAllConditions(
                () => lookups.Count.ShouldBe(2),
                () => lookups[1].ShouldBe("UniqueId1"),
                () => lookups[2].ShouldBe("UniqueId2"));

            lookups.ShouldSatisfyAllConditions(
                () => lookups.Count.ShouldBe(2),
                () => lookups[1].ShouldBe("UniqueId1"),
                () => lookups[2].ShouldBe("UniqueId2"));

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType, A<int[]>.Ignored))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromOds_WhenCacheInitializationInProgress()
        {
            // Arrange
            var personType = "Student";
            var lookups = new Dictionary<int, string>
            {
                { 1, null },
                { 2, null }
            };

            // Simulate that cache initialization is in progress
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .Returns(new string[2]);

            A.CallTo(() => _fakePersonMapCacheInitializer.EnsurePersonMapsInitialized(
                123456UL, personType))
                .Returns(Task.Delay(100));

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeCacheSuppressionByPersonType);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromOds_WhenCacheIsSuppressed()
        {
            // Arrange
            var personType = "Student";
            var lookups = new Dictionary<int, string>
            {
                { 1, null },
                { 2, null }
            };

            // Simulate cache suppression for the person type
            _fakeCacheSuppressionByPersonType[personType] = true;

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeCacheSuppressionByPersonType);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .MustNotHaveHappened();

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .MustHaveHappenedOnceExactly();
        }
    }

    public class TestContextProvider<TContext> : IContextProvider<TContext>
    {
        private readonly TContext _context;

        public TestContextProvider(TContext context)
        {
            _context = context;
        }

        public TContext Get()
        {
            return _context;
        }

        public void Set(TContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
