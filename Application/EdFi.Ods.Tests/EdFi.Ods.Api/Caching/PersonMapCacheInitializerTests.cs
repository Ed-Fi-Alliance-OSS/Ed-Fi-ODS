// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Tests._Extensions;
using log4net;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class PersonMapCacheInitializerTests
{
    [Test]
    public async Task InitializePersonMapAsync_ShouldInitializeCache_WhenCalled()
    {
        // Arrange
        var personType = "TestPerson";
        var odsInstanceHashId = 12345UL;
        var personIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var usiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var uniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();

        var personIdentifiersValueMaps = new List<PersonIdentifiersValueMap>
        {
            new() { Usi = 1, UniqueId = "UniqueId1" },
            new() { Usi = 2, UniqueId = "UniqueId2" }
        };

        A.CallTo(() => personIdentifiersProvider.GetAllPersonIdentifiersAsync(personType))
            .Returns(TaskHelpers.FromResultWithDelay<IEnumerable<PersonIdentifiersValueMap>>(personIdentifiersValueMaps, 100));

        var personMapCacheInitializer = new PersonMapCacheInitializer(
            personIdentifiersProvider,
            usiByUniqueIdMapCache,
            uniqueIdByUsiMapCache);

        // Act
        await personMapCacheInitializer.InitializePersonMapAsync(odsInstanceHashId, personType);

        // Assert
        var uniqueIdByUsiTuple = (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi);
        
        A.CallTo(() => usiByUniqueIdMapCache.SetMapEntriesAsync(
            uniqueIdByUsiTuple,
            A<(int, string)[]>.That.Matches(entries => 
                entries.Count() == 3
                && entries[0].Item1 == 1 && entries[0].Item2 == "UniqueId1"
                && entries[1].Item1 == 2 && entries[1].Item2 == "UniqueId2"
                // Cache initialization marker entry is present at the end
                && entries[2].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUsi 
                && entries[2].Item2 == CacheInitializationConstants.InitializationMarkerKeyForUniqueId)))
            .MustHaveHappenedOnceExactly();

        var usiByUniqueIdTuple = (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId);

        A.CallTo(() => uniqueIdByUsiMapCache.SetMapEntriesAsync(
            usiByUniqueIdTuple,
            A<(string, int)[]>.That.Matches(entries => 
                entries.Count() == 3
                && entries[0].Item1 == "UniqueId1" && entries[0].Item2 == 1 
                && entries[1].Item1 == "UniqueId2" && entries[1].Item2 == 2
                // Cache initialization marker entry is present at the end
                && entries[2].Item1 == CacheInitializationConstants.InitializationMarkerKeyForUniqueId 
                && entries[2].Item2 == CacheInitializationConstants.InitializationMarkerKeyForUsi)))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InitializePersonMapAsync_ShouldNotSetAnyCacheMapEntriesOrThrowException_WhenIdentifierProviderFails()
    {
        // Arrange
        var personType = "TestPerson";
        var odsInstanceHashId = 12345UL;
        var personIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var usiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var uniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();

        A.CallTo(() => personIdentifiersProvider.GetAllPersonIdentifiersAsync(personType))
            .Throws(new Exception("Failed to fetch identifiers"));

        var personMapCacheInitializer = new PersonMapCacheInitializer(
            personIdentifiersProvider,
            usiByUniqueIdMapCache,
            uniqueIdByUsiMapCache);

        // Act
        await personMapCacheInitializer.InitializePersonMapAsync(odsInstanceHashId, personType);

        // Assert
        A.CallTo(() => uniqueIdByUsiMapCache.SetMapEntriesAsync(
            A<(ulong, string, PersonMapType)>.Ignored, A<(string, int)[]>.Ignored))
            .MustNotHaveHappened();
        
        A.CallTo(() => usiByUniqueIdMapCache.SetMapEntriesAsync(
                A<(ulong, string, PersonMapType)>.Ignored, A<(int, string)[]>.Ignored))
            .MustNotHaveHappened();
    }
}
