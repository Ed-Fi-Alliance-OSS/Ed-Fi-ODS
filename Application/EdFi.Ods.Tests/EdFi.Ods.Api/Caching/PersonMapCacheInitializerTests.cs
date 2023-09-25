// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class PersonMapCacheInitializerTests
{
    [Test]
    public void EnsurePersonMapsInitialized_ShouldInitializeCache_WhenNotAlreadyInitialized()
    {
        // Arrange
        var personType = "Student";
        var odsInstanceHashId = 123456UL;

        var fakePersonIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var fakeUniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var fakeUsiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();

        var personIdentifiers = new List<PersonIdentifiersValueMap>
        {
            new() { Usi = 1, UniqueId = "UniqueId1" },
            new() { Usi = 2, UniqueId = "UniqueId2" }
        };

        A.CallTo(() => fakePersonIdentifiersProvider.GetAllPersonIdentifiersAsync(personType))
            .Returns(Task.FromResult<IEnumerable<PersonIdentifiersValueMap>>(personIdentifiers));

        var initializer = new PersonMapCacheInitializer(
            fakePersonIdentifiersProvider,
            fakeUniqueIdByUsiMapCache,
            fakeUsiByUniqueIdMapCache);

        // Act
        var initializationTask = initializer.EnsurePersonMapsInitialized(odsInstanceHashId, personType);
        initializationTask?.ConfigureAwait(false).GetAwaiter().GetResult(); 
        
        // Assert
        A.CallTo(() => fakePersonIdentifiersProvider.GetAllPersonIdentifiersAsync(personType))
            .MustHaveHappenedOnceExactly();

        var uniqueIdByUsiTuple = (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi);
        
        A.CallTo(() => fakeUniqueIdByUsiMapCache.SetMapEntriesAsync(uniqueIdByUsiTuple,
                A<(int, string)[]>.That.Matches(entries => TwoEntriesContainingUniqueId1And2(entries))))
            .MustHaveHappenedOnceExactly();

        var usiByUniqueIdTuple = (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId);
        
        A.CallTo(() => fakeUsiByUniqueIdMapCache.SetMapEntriesAsync(usiByUniqueIdTuple,
                A<(string, int)[]>.That.Matches(entries => TwoEntriesContainingUniqueId1And2(entries))))
            .MustHaveHappenedOnceExactly();

        // Task should be completed when not already initialized
        initializationTask.Status.ShouldBe(TaskStatus.RanToCompletion);
    }

    private static bool TwoEntriesContainingUniqueId1And2((int, string)[] entries) => entries.Length == 2 && entries[0] == (1, "UniqueId1") && entries[1] == (2, "UniqueId2");
    private static bool TwoEntriesContainingUniqueId1And2((string, int)[] entries) => entries.Length == 2 && entries[0] == ("UniqueId1", 1) && entries[1] == ("UniqueId2", 2);

    [Test]
    public void EnsurePersonMapsInitialized_ShouldNotReinitializeCache_WhenAlreadyInitialized()
    {
        // Arrange
        var personType = "Student";
        var odsInstanceHashId = 123456UL;
    
        var fakePersonIdentifiersProvider = A.Fake<IPersonIdentifiersProvider>();
        var fakeUniqueIdByUsiMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), int, string>>();
        var fakeUsiByUniqueIdMapCache = A.Fake<IMapCache<(ulong, string, PersonMapType), string, int>>();
    
        // Simulate that the cache is already initialized
        var uniqueIdByUsiTuple = (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi);
        
        A.CallTo(() => fakeUniqueIdByUsiMapCache.SetMapEntriesAsync(
                uniqueIdByUsiTuple,
                A<(int, string)[]>.Ignored))
            .DoesNothing();

        var usiByUniqueIdTuple = (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId);
        
        A.CallTo(() => fakeUsiByUniqueIdMapCache.SetMapEntriesAsync(
                usiByUniqueIdTuple,
                A<(string, int)[]>.Ignored))
            .DoesNothing();
    
        var initializer = new PersonMapCacheInitializer(
            fakePersonIdentifiersProvider,
            fakeUniqueIdByUsiMapCache,
            fakeUsiByUniqueIdMapCache);
    
        // Act
        var initializationTask = initializer.EnsurePersonMapsInitialized(odsInstanceHashId, personType);
        initializationTask.ConfigureAwait(false).GetAwaiter().GetResult();

        // Repeat the same initialization
        var initializationTask2 = initializer.EnsurePersonMapsInitialized(odsInstanceHashId, personType);
        
        // Task should be set to null once it's completed from previous initialization
        initializationTask2.ShouldBeNull();
        
        // Assert
        A.CallTo(() => fakePersonIdentifiersProvider.GetAllPersonIdentifiersAsync(personType))
            .MustHaveHappenedOnceExactly();
    }
}
