// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Common.Caching;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class SharedMemoryCacheEvictionTests
{
    [Test]
    public async Task Tiered_Caches_Should_Not_Share_Memory_Cache_Instance()
    {
        // Arrange
        var sharedMemoryCache = new MemoryCache(new MemoryCacheOptions());

        // Both tiered caches use the SAME memory cache instance
        var usiByUniqueIdCache = new InMemoryMapCache<(ulong, string, PersonMapType), string, int>(
            sharedMemoryCache,
            slidingExpirationPeriod: TimeSpan.FromHours(4),
            absoluteExpirationPeriod: TimeSpan.FromDays(1));

        var uniqueIdByUsiCache = new InMemoryMapCache<(ulong, string, PersonMapType), int, string>(
            sharedMemoryCache,
            slidingExpirationPeriod: TimeSpan.FromHours(4),
            absoluteExpirationPeriod: TimeSpan.FromDays(1));

        var cacheKey = (123456UL, "Student", PersonMapType.UsiByUniqueId);
        var inverseKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);

        // Act - Set entries in first cache
        await usiByUniqueIdCache.SetMapEntriesAsync(
            cacheKey,
            new[] { ("UniqueId1", 1), ("UniqueId2", 2) });

        // Set entries in second cache
        await uniqueIdByUsiCache.SetMapEntriesAsync(
            inverseKey,
            new[] { (1, "UniqueId1"), (2, "UniqueId2") });

        // Verify both have data
        var usiResult1 = await usiByUniqueIdCache.GetMapEntriesAsync(cacheKey, new[] { "UniqueId1", "UniqueId2" });
        var uniqueIdResult1 = await uniqueIdByUsiCache.GetMapEntriesAsync(inverseKey, new[] { 1, 2 });

        usiResult1.ShouldContain(1);
        usiResult1.ShouldContain(2);
        uniqueIdResult1.ShouldContain("UniqueId1");
        uniqueIdResult1.ShouldContain("UniqueId2");

        // Act - Clear one cache (simulating external cache override)
        await usiByUniqueIdCache.DeleteMapEntryAsync(cacheKey, "UniqueId1");

        // Assert - The OTHER cache should NOT be affected by clearing one cache
        // In the current BUGGY implementation, clearing shared cache affects both
        var uniqueIdResult2 = await uniqueIdByUsiCache.GetMapEntriesAsync(inverseKey, new[] { 1, 2 });

        // This FAILS with shared memory cache because clearing UsiByUniqueId cache
        // also clears entries from UniqueIdByUsi cache (they share the same underlying cache)
        uniqueIdResult2.ShouldContain("UniqueId1", "Cache eviction in one tiered cache should not affect the other");
        uniqueIdResult2.ShouldContain("UniqueId2");
    }

    [Test]
    public async Task Dedicated_Memory_Caches_Prevent_Cross_Module_Eviction()
    {
        // Arrange - Each cache gets its OWN dedicated memory cache instance
        var usiByUniqueIdMemoryCache = new MemoryCache(new MemoryCacheOptions());
        var uniqueIdByUsiMemoryCache = new MemoryCache(new MemoryCacheOptions());

        var usiByUniqueIdCache = new InMemoryMapCache<(ulong, string, PersonMapType), string, int>(
            usiByUniqueIdMemoryCache,
            slidingExpirationPeriod: TimeSpan.FromHours(4),
            absoluteExpirationPeriod: TimeSpan.FromDays(1));

        var uniqueIdByUsiCache = new InMemoryMapCache<(ulong, string, PersonMapType), int, string>(
            uniqueIdByUsiMemoryCache,
            slidingExpirationPeriod: TimeSpan.FromHours(4),
            absoluteExpirationPeriod: TimeSpan.FromDays(1));

        var cacheKey = (123456UL, "Student", PersonMapType.UsiByUniqueId);
        var inverseKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);

        // Act - Set entries in first cache
        await usiByUniqueIdCache.SetMapEntriesAsync(
            cacheKey,
            new[] { ("UniqueId1", 1), ("UniqueId2", 2) });

        // Set entries in second cache
        await uniqueIdByUsiCache.SetMapEntriesAsync(
            inverseKey,
            new[] { (1, "UniqueId1"), (2, "UniqueId2") });

        // Verify both have data
        var usiResult1 = await usiByUniqueIdCache.GetMapEntriesAsync(cacheKey, new[] { "UniqueId1", "UniqueId2" });
        var uniqueIdResult1 = await uniqueIdByUsiCache.GetMapEntriesAsync(inverseKey, new[] { 1, 2 });

        usiResult1.ShouldContain(1);
        usiResult1.ShouldContain(2);
        uniqueIdResult1.ShouldContain("UniqueId1");
        uniqueIdResult1.ShouldContain("UniqueId2");

        // Act - Clear one cache
        await usiByUniqueIdCache.DeleteMapEntryAsync(cacheKey, "UniqueId1");

        // Assert - With dedicated memory caches, the OTHER cache is NOT affected
        var uniqueIdResult2 = await uniqueIdByUsiCache.GetMapEntriesAsync(inverseKey, new[] { 1, 2 });

        // This should PASS with dedicated memory caches
        uniqueIdResult2.ShouldContain("UniqueId1", "Dedicated caches should not cross-evict");
        uniqueIdResult2.ShouldContain("UniqueId2");
    }
}
