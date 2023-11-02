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
using EdFi.Ods.Api.Caching.Person;
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
        private IMapCache<(ulong, string, PersonMapType), string, int> _fakeReverseMapCache;
        private Dictionary<string, bool> _fakeCacheSuppressionByPersonType;
        private IPersonMapCacheInitializer _fakePersonMapCacheInitializer;
        private IContextProvider<OdsInstanceConfiguration> _fakeOdsInstanceConfigurationContextProvider;

        [SetUp]
        public void Arrange()
        {
            _fakePersonIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
            _fakeMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
            _fakeReverseMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();
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
            var usiByUniqueIdTuple = (123456UL, personType, PersonMapType.UsiByUniqueId);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<int[]>.That.Matches(x => 
                    x.Length == 3 
                    && x[0] == 1 
                    && x[1] == 2
                    // Resolver should append the marker key for checking cache initialization state
                    && x[2] == CacheInitializationConstants.InitializationMarkerKeyForUsi
                    )))
                .Returns(new[] { "UniqueId1", "UniqueId2", CacheInitializationConstants.InitializationMarkerKeyForUniqueId });

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeReverseMapCache,
                new UsiCacheInitializationMarkerKeyProvider(),
                new UniqueIdCacheInitializationMarkerKeyProvider(),
                _fakeCacheSuppressionByPersonType,
                useProgressiveLoading: false);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            lookups.ShouldSatisfyAllConditions(
                () => lookups.Count.ShouldBe(2),
                () => lookups[1].ShouldBe("UniqueId1"),
                () => lookups[2].ShouldBe("UniqueId2"));

            // No loading from the ODS
            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType, A<int[]>.Ignored))
                .MustNotHaveHappened();
            
            // No additional entries set in cache
            A.CallTo(() => _fakeMapCache.SetMapEntriesAsync(
                    uniqueIdByUsiTuple, A<(int, string)[]>.Ignored))
                .MustNotHaveHappened();
            
            // No additional entries set in cache
            A.CallTo(() => _fakeReverseMapCache.SetMapEntriesAsync(
                    usiByUniqueIdTuple, A<(string, int)[]>.Ignored))
                .MustNotHaveHappened();
        }

        [TestCase(false)] // Using background full cache initialization
        [TestCase(true)] // Using progressive loading
        public async Task ResolveUniqueIds_ShouldLoadFromOds_WhenCacheIsNotInitialized(bool useProgressiveLoading)
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
            var usiByUniqueIdTuple = (123456UL, personType, PersonMapType.UsiByUniqueId);

            if (useProgressiveLoading)
            {
                A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                        uniqueIdByUsiTuple,
                        A<int[]>.That.Matches(x => 
                            x.Length == 2 
                            && x[0] == 1 
                            && x[1] == 2
                        )))
                    .Returns(new string[2]);
            }
            else
            {
                A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(
                        uniqueIdByUsiTuple,
                        A<int[]>.That.Matches(x => 
                            x.Length == 3 
                            && x[0] == 1 
                            && x[1] == 2
                            // Resolver should append the marker key for checking cache initialization state
                            && x[2] == CacheInitializationConstants.InitializationMarkerKeyForUsi
                        )))
                    // Cache is not initialized
                    .Returns(new string[3]);
            }

            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType,
                A<int[]>.That.Matches(x => 
                    x.Length == 2 
                    && x[0] == 1 
                    && x[1] == 2)))
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
                _fakeReverseMapCache,
                new UsiCacheInitializationMarkerKeyProvider(),
                new UniqueIdCacheInitializationMarkerKeyProvider(),
                _fakeCacheSuppressionByPersonType,
                useProgressiveLoading);

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
            
            // Loaded entries should be set to cache
            A.CallTo(() => _fakeMapCache.SetMapEntriesAsync(
                    uniqueIdByUsiTuple, A<(int key, string value)[]>.That.Matches(x => 
                        x.Length == 2 
                        && x[0].key == 1 && x[0].value == "UniqueId1"
                        && x[1].key == 2 && x[1].value == "UniqueId2")))
                .MustHaveHappenedOnceExactly();
            
            // Loaded entries should be set to cache
            A.CallTo(() => _fakeReverseMapCache.SetMapEntriesAsync(
                    usiByUniqueIdTuple, A<(string key, int value)[]>.That.Matches(x => 
                        x.Length == 2 
                        && x[0].key == "UniqueId1" && x[0].value == 1 
                        && x[1].key == "UniqueId2" && x[1].value == 2)))
                .MustHaveHappenedOnceExactly();

            // Cache initialization marker entry should be set
            var cacheInitializationMarkerForUsiCall = A.CallTo(() => _fakeMapCache.SetMapEntriesAsync(
                    uniqueIdByUsiTuple, A<(int key, string value)[]>.That.Matches(x => 
                        x.Length == 1 
                        && x[0].key == CacheInitializationConstants.InitializationMarkerKeyForUsi 
                        && x[0].value == CacheInitializationConstants.InitializationMarkerKeyForUniqueId)));

            if (useProgressiveLoading)
            {
                cacheInitializationMarkerForUsiCall.MustNotHaveHappened();
            }
            else
            {
                cacheInitializationMarkerForUsiCall.MustHaveHappenedOnceExactly();
            }

            // Cache initialization marker entry should be set
            var cacheInitializationMarkerForUniqueIdCall = A.CallTo(() => _fakeReverseMapCache.SetMapEntriesAsync(
                    usiByUniqueIdTuple, A<(string key, int value)[]>.That.Matches(x => 
                        x.Length == 1 
                        && x[0].key == CacheInitializationConstants.InitializationMarkerKeyForUniqueId 
                        && x[0].value == CacheInitializationConstants.InitializationMarkerKeyForUsi)));

            if (useProgressiveLoading)
            {
                cacheInitializationMarkerForUniqueIdCall.MustNotHaveHappened();
            }
            else
            {
                cacheInitializationMarkerForUniqueIdCall.MustHaveHappenedOnceExactly();
            }

            // Background initialization should have been initiated
            var backgroundCacheInitializationCall = A.CallTo(() => _fakePersonMapCacheInitializer.InitializePersonMapAsync(123456UL, personType));

            if (useProgressiveLoading)
            {
                backgroundCacheInitializationCall.MustNotHaveHappened();
            }
            else
            {
                backgroundCacheInitializationCall.MustHaveHappenedOnceExactly();
            }
        }

        [Test]
        public async Task ResolveUniqueIds_ShouldLoadFromOds_WhenCacheInitializationFails()
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
                A<int[]>.That.Matches(x => 
                    x.Length == 3 
                    && x[0] == 1 
                    && x[1] == 2
                    // Resolver should append the marker key for checking cache initialization state
                    && x[2] == CacheInitializationConstants.InitializationMarkerKeyForUsi)))
                .Returns(new string[3]);

            A.CallTo(() => _fakePersonMapCacheInitializer.InitializePersonMapAsync(
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
                _fakeReverseMapCache,
                new UsiCacheInitializationMarkerKeyProvider(),
                new UniqueIdCacheInitializationMarkerKeyProvider(),
                _fakeCacheSuppressionByPersonType,
                useProgressiveLoading: false);

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
        public async Task ResolveUniqueIds_ShouldLoadSpecificUnresolvedIdentifiersFromOds_WhenCacheInitializationAlreadyInitiated()
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
                A<int[]>.That.Matches(x => 
                    x.Length == 3 
                    && x[0] == 1 
                    && x[1] == 2
                    // Resolver should append the marker key for checking cache initialization state
                    && x[2] == CacheInitializationConstants.InitializationMarkerKeyForUsi)))
                // Simulate that cache initialization has already been initiated
                .Returns(new[] { null, null, CacheInitializationConstants.InitializationMarkerKeyForUniqueId });

            var resolver = new PersonUniqueIdResolver(
                _fakePersonMapCacheInitializer,
                _fakePersonIdentifiersProvider,
                _fakeOdsInstanceConfigurationContextProvider,
                _fakeMapCache,
                _fakeReverseMapCache,
                new UsiCacheInitializationMarkerKeyProvider(),
                new UniqueIdCacheInitializationMarkerKeyProvider(),
                _fakeCacheSuppressionByPersonType,
                useProgressiveLoading: false);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            
            // Should load from the ODS
            A.CallTo(() => _fakePersonIdentifiersProvider.GetPersonUniqueIdsAsync(
                personType,
                A<int[]>.That.Matches(x => x.Length == 2 && x[0] == 1 && x[1] == 2)))
                .MustHaveHappenedOnceExactly();

            // There should be no attempt to initialize the cache
            A.CallTo(() => _fakePersonMapCacheInitializer.InitializePersonMapAsync(A<ulong>.Ignored, A<string>.Ignored))
                .MustNotHaveHappened();
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
                _fakeReverseMapCache,
                new UsiCacheInitializationMarkerKeyProvider(),
                new UniqueIdCacheInitializationMarkerKeyProvider(),
                _fakeCacheSuppressionByPersonType,
                useProgressiveLoading: false);

            // Act
            await resolver.ResolveUniqueIdsAsync(personType, lookups);

            // Assert
            var uniqueIdByUsiTuple = (123456UL, personType, PersonMapType.UniqueIdByUsi);

            A.CallTo(() => _fakeMapCache.GetMapEntriesAsync(uniqueIdByUsiTuple, A<int[]>.Ignored))
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
