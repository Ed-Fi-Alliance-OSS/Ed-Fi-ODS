// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Caching;
using EdFi.Ods.Features.ExternalCache.Redis;
using NUnit.Framework;
using Shouldly;

// ---------------------------------------------------------------
// Docker command to run Redis in a container for testing:
// ---------------------------------------------------------------
// docker run --name my-redis -d -p 6379:6379 redis:alpine
// ---------------------------------------------------------------

namespace EdFi.Ods.Features.UnitTests.ExternalCache;

[TestFixture, Explicit]
public class RedisUniqueIdByUsiMapCacheTests
{
    private RedisUniqueIdByUsiMapCache _mapCache;
    private (ulong, string, PersonMapType UsiByUniqueId) _cacheKey;

    [SetUp]
    public void SetUp()
    {
        _mapCache = new RedisUniqueIdByUsiMapCache("localhost:6379");
        _cacheKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);
    }

    [Test]
    public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntries()
    {
        // Arrange
        var mapEntries = new[] { (1, "Value1"), (2, "Value2"), (3, "Value3"), (4, "Extra value") };

        // Act
        await _mapCache.SetMapEntriesAsync(_cacheKey, mapEntries);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { 1, 2, 3 });

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { "Value1", "Value2", "Value3" });
    }

    [Test]
    public async Task GetMapEntries_ShouldReturnDefaultsForNotFoundKeys()
    {
        // Arrange
        var mapKeys = new[] { 7, 8, 9 };

        // Act
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, mapKeys);

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new string?[] { null, null, null });
    }

    [Test]
    public async Task DeleteMapEntry_ShouldRemoveMapEntry()
    {
        // Arrange
        var mapKey = 100;
        
        await _mapCache.SetMapEntriesAsync(_cacheKey, new[] {(mapKey, "Value100")});

        // Act
        var deleted = await _mapCache.DeleteMapEntryAsync(_cacheKey, mapKey);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] {mapKey});

        // Assert
        deleted.ShouldBeTrue();
        retrievedValues.Length.ShouldBe(1);
        retrievedValues[0].ShouldBe(default);
    }

    [Test]
    public async Task DeleteMapEntry_ShouldReturnFalseForNonexistentEntry()
    {
        // Arrange
        var mapKey = 99; // Non Existing

        // Act
        var deleted = await _mapCache.DeleteMapEntryAsync(_cacheKey, mapKey);

        // Assert
        deleted.ShouldBeFalse();
    }
}