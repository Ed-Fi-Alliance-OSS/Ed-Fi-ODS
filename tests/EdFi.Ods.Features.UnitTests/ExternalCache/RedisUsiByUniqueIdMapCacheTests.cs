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
public class RedisUsiByUniqueIdMapCacheTests
{
    private RedisUsiByUniqueIdMapCache _mapCache;
    private (ulong, string, PersonMapType UsiByUniqueId) _cacheKey;

    private const int AbsoluteExpirationSeconds = 2;
    private const int AbsoluteExpirationMs = AbsoluteExpirationSeconds * 1000;
    
    private const int SlidingExpirationSeconds = 1;
    private const int SlidingExpirationMs = SlidingExpirationSeconds * 1000;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mapCache = new RedisUsiByUniqueIdMapCache(
            "localhost:6379",
            absoluteExpirationPeriod: TimeSpan.FromSeconds(AbsoluteExpirationSeconds),
            slidingExpirationPeriod: TimeSpan.FromSeconds(SlidingExpirationSeconds));
        
        _cacheKey = (123456UL, "Student", PersonMapType.UsiByUniqueId);
    }

    [Test]
    public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntries()
    {
        // Arrange
        var mapEntries = new[] { ("Value1", 1), ("Value2", 2), ("Value3", 3), ("Extra value", 4) };

        // Act
        await _mapCache.SetMapEntriesAsync(_cacheKey, mapEntries);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3" });

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { 1, 2, 3 });
    }

    [Test]
    public async Task GetMapEntries_ShouldReturnDefaultsForNotFoundKeys()
    {
        // Arrange
        var mapKeys = new[] { "Value7", "Value8", "Value9" };

        // Act
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, mapKeys);

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { 0, 0, 0 });
    }

    [Test]
    public async Task DeleteMapEntry_ShouldRemoveMapEntry()
    {
        // Arrange
        var mapKey = "Value100";
        
        await _mapCache.SetMapEntriesAsync(_cacheKey, new[] {(mapKey, 100)});

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
        var mapKey = "NonExisting";

        // Act
        var deleted = await _mapCache.DeleteMapEntryAsync(_cacheKey, mapKey);

        // Assert
        deleted.ShouldBeFalse();
    }
    
    [Test]
    public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntriesUntilAbsoluteExpiration()
    {
        // Arrange
        var mapEntries = new[] { ("Value1", 1), ("Value2", 2), ("Value3", 3), ("Extra value", 4) };

        // Act I
        await _mapCache.SetMapEntriesAsync(_cacheKey, mapEntries);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3" });

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { 1, 2, 3 });
        
        // Wait for values to expire absolutely
        Thread.Sleep(AbsoluteExpirationMs);
        
        // Act II
        var retrievedValues2 = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3" });

        // Assert
        retrievedValues2.ShouldBeEquivalentTo(new[] { 0, 0, 0 });
    }

    [Test]
    public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntriesPastAbsoluteExpirationWithSlidingExpiration()
    {
        // Arrange
        var mapEntries = new[] { ("Value1", 1), ("Value2", 2), ("Value3", 3), ("Extra value", 4) };

        // Act I
        await _mapCache.SetMapEntriesAsync(_cacheKey, mapEntries);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3" });

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { 1, 2, 3 });
        
        // Wait for 200ms past the point where the sliding expiration equals the absolute expiration
        Thread.Sleep(AbsoluteExpirationMs - SlidingExpirationMs + 200);
        
        // Act II
        // Delete also extends the sliding expiration
        var deleteResult = await _mapCache.DeleteMapEntryAsync(_cacheKey, "Value2");

        // Assert
        deleteResult.ShouldBeTrue();

        // Wait past original absolute expiration, allowing them to *almost* expire through sliding expiration
        Thread.Sleep(SlidingExpirationMs - 100);

        // Act III
        var retrievedValues3 = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3" });

        // Assert
        retrievedValues3.ShouldBeEquivalentTo(new[] { 1, 0, 3 });

        // Now wait for them to expire (past the last sliding expiration)
        Thread.Sleep(1025);
        
        // Act IV
        var retrievedValues4 = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { "Value1", "Value2", "Value3"  });

        // Assert
        retrievedValues4.ShouldBeEquivalentTo(new[] { 0, 0, 0 });
    }
}