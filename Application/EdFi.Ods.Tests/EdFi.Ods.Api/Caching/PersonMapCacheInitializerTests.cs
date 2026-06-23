// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Api.IdentityValueMappers;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class PersonMapCacheInitializerTests
{
    [Test]
    public async Task InitializePersonMapAsync_ShouldInitializeCache_WhenCalled()
    {
        // Arrange
        const string personType = "TestPerson";
        const ulong odsInstanceHashId = 12345UL;
        const string lockKey = "cache-init-lock";

        var personIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var uniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var usiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();
        var distributedLockProvider = A.Fake<IDistributedLockProvider>();

        A.CallTo(() => personIdentifiersProvider.GetAllPersonIdentifiersAsync(personType, A<CancellationToken>.Ignored))
            .Returns(new List<PersonIdentifiersValueMap>
            {
                new() { Usi = 1, UniqueId = "UniqueId1" },
                new() { Usi = 2, UniqueId = "UniqueId2" }
            });

        var personMapCacheInitializer = new PersonMapCacheInitializer(
            personIdentifiersProvider,
            uniqueIdByUsiMapCache,
            usiByUniqueIdMapCache,
            distributedLockProvider);

        // Act
        await personMapCacheInitializer.InitializePersonMapAsync(odsInstanceHashId, personType, lockKey);

        // Assert
        var uniqueIdByUsiTuple = (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi);

        A.CallTo(() => uniqueIdByUsiMapCache.SetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<(int, string)[]>.That.Matches(entries =>
                    entries.Count() == 3
                    && entries[0].Item1 == 1 && entries[0].Item2 == "UniqueId1"
                    && entries[1].Item1 == 2 && entries[1].Item2 == "UniqueId2"
                    && entries[2].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUsi
                    && entries[2].Item2 == CacheInitializationConstants.InitializationMarkerKeyForUniqueId)))
            .MustHaveHappenedOnceExactly();

        var usiByUniqueIdTuple = (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId);

        A.CallTo(() => usiByUniqueIdMapCache.SetMapEntriesAsync(
                usiByUniqueIdTuple,
                A<(string, int)[]>.That.Matches(entries =>
                    entries.Count() == 3
                    && entries[0].Item1 == "UniqueId1" && entries[0].Item2 == 1
                    && entries[1].Item1 == "UniqueId2" && entries[1].Item2 == 2
                    && entries[2].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUniqueId
                    && entries[2].Item2 == CacheInitializationConstants.InitializationMarkerKeyForUsi)))
            .MustHaveHappenedOnceExactly();

        A.CallTo(() => distributedLockProvider.ReleaseLockAsync(lockKey))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InitializePersonMapAsync_ShouldResetInitializationMarkers_WhenIdentifierProviderFails()
    {
        // Arrange
        const string personType = "TestPerson";
        const ulong odsInstanceHashId = 12345UL;
        const string lockKey = "cache-init-lock";

        var personIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var uniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var usiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();
        var distributedLockProvider = A.Fake<IDistributedLockProvider>();

        A.CallTo(() => personIdentifiersProvider.GetAllPersonIdentifiersAsync(personType, A<CancellationToken>.Ignored))
            .Throws(new Exception("Failed to fetch identifiers"));

        var personMapCacheInitializer = new PersonMapCacheInitializer(
            personIdentifiersProvider,
            uniqueIdByUsiMapCache,
            usiByUniqueIdMapCache,
            distributedLockProvider);

        // Act
        await personMapCacheInitializer.InitializePersonMapAsync(odsInstanceHashId, personType, lockKey);

        // Assert
        var uniqueIdByUsiTuple = (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi);
        var usiByUniqueIdTuple = (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId);

        A.CallTo(() => uniqueIdByUsiMapCache.SetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<(int, string)[]>.That.Matches(entries =>
                    entries.Length == 1
                    && entries[0].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUsi
                    && entries[0].Item2 == null)))
            .MustHaveHappenedOnceExactly();

        A.CallTo(() => usiByUniqueIdMapCache.SetMapEntriesAsync(
                usiByUniqueIdTuple,
                A<(string, int)[]>.That.Matches(entries =>
                    entries.Length == 1
                    && entries[0].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUniqueId
                    && entries[0].Item2 == default)))
            .MustHaveHappenedOnceExactly();

        A.CallTo(() => distributedLockProvider.ReleaseLockAsync(lockKey))
            .MustHaveHappenedOnceExactly();
    }
}
