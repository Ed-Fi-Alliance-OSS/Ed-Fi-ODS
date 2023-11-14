// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using NUnit.Framework;
using Shouldly;

// ---------------------------------------------------------------
// Docker command to run Redis in a container for testing:
// ---------------------------------------------------------------
// docker run --name my-redis -d -p 6379:6379 redis:alpine
// ---------------------------------------------------------------

namespace EdFi.Ods.Features.UnitTests.PersonMapCache;

[TestFixture]
public class UniqueIdByUsiMapCacheTests
{
    [TestFixtureSource(nameof(MapCaches))]
    public class BothAbsoluteAndSlidingExpirationTests
    {
        private IMapCache<(ulong, string, PersonMapType), int, string>? _mapCache;

        private (ulong, string, PersonMapType UsiByUniqueId) _cacheKey;

        private const int AbsoluteExpirationMs = 50;
        private const int SlidingExpirationMs = 100;

        public BothAbsoluteAndSlidingExpirationTests(IMapCache<(ulong, string, PersonMapType), int, string> mapCache)
        {
            _mapCache = mapCache;
        }

        private static IMapCache<(ulong, string, PersonMapType), int, string>[] MapCaches
        {
            get => MapCacheTestHelper.GetUniqueIdByUsiMapCaches(AbsoluteExpirationMs, SlidingExpirationMs).ToArray();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _cacheKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);
        }

        [Test]
        public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntries()
        {
            // Arrange
            var mapEntries = new[] { (1, "Value1"), (2, "Value2"), (3, "Value3"), (4, "Extra value") };

            // Act
            await _mapCache!.SetMapEntriesAsync(_cacheKey, mapEntries);
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
            var retrievedValues = await _mapCache!.GetMapEntriesAsync(_cacheKey, mapKeys);

            // Assert
            retrievedValues.ShouldBeEquivalentTo(new string?[] { null, null, null });
        }

        [Test]
        public async Task DeleteMapEntry_ShouldRemoveMapEntry()
        {
            // Arrange
            var mapKey = 100;
            
            await _mapCache!.SetMapEntriesAsync(_cacheKey, new[] {(mapKey, "Value100")});

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
            var deleted = await _mapCache!.DeleteMapEntryAsync(_cacheKey, mapKey);

            // Assert
            deleted.ShouldBeFalse();
        }
    }

    [TestFixtureSource(nameof(MapCaches))]
    public class OnlyAbsoluteExpirationTests
    {
        private IMapCache<(ulong, string, PersonMapType), int, string>? _mapCache;

        private (ulong, string, PersonMapType UsiByUniqueId) _cacheKey;

        private const int AbsoluteExpirationMs = 200;
        
        // No sliding expiration
        private const int SlidingExpirationMs = 0;

        public OnlyAbsoluteExpirationTests(IMapCache<(ulong, string, PersonMapType), int, string> mapCache)
        {
            _mapCache = mapCache;
        }

        private static IMapCache<(ulong, string, PersonMapType), int, string>[] MapCaches
        {
            get => MapCacheTestHelper.GetUniqueIdByUsiMapCaches(AbsoluteExpirationMs, SlidingExpirationMs).ToArray();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _cacheKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);
        }

        [Test]
        public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntriesUntilAbsoluteExpiration()
        {
            // Arrange
            var mapEntries = new[] { (1, "Value1"), (2, "Value2"), (3, "Value3"), (4, "Extra value") };

            // Act I
            await _mapCache!.SetMapEntriesAsync(_cacheKey, mapEntries);

            var sw = new Stopwatch();
            sw.Start();

            // Fetch values repeatedly until cache should have expired
            while (sw.ElapsedMilliseconds < AbsoluteExpirationMs)
            {
                var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { 1, 2, 3 });

                // Assert
                retrievedValues.ShouldBeEquivalentTo(new[] { "Value1", "Value2", "Value3" });

                // Put a slight delay in calls
                Thread.Sleep(20);
            }

            // Put a slight delay before final call
            Thread.Sleep(10);

            // Act II
            var retrievedValues2 = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { 1, 2, 3 });

            // Assert II
            retrievedValues2.ShouldBeEquivalentTo(new string?[] { null, null, null });
        }
    }

    [TestFixtureSource(nameof(MapCaches))]
    public class OnlySlidingExpirationTests
    {
        private readonly IMapCache<(ulong, string, PersonMapType), int, string>? _mapCache;
        private (ulong, string, PersonMapType UsiByUniqueId) _cacheKey;

        // No absolute expiration
        private const int AbsoluteExpirationMs = 0;
        private const int SlidingExpirationMs = 50;

        public OnlySlidingExpirationTests(IMapCache<(ulong, string, PersonMapType), int, string> mapCache)
        {
            _mapCache = mapCache;
        }

        private static IMapCache<(ulong, string, PersonMapType), int, string>[] MapCaches
        {
            get => MapCacheTestHelper.GetUniqueIdByUsiMapCaches(AbsoluteExpirationMs, SlidingExpirationMs).ToArray();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _cacheKey = (123456UL, "Student", PersonMapType.UniqueIdByUsi);
        }

        [Test]
        public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntriesUntilSlidingExpiration()
        {
            // Arrange
            var mapEntries = new[] { (1, "Value1"), (2, "Value2"), (3, "Value3"), (4, "Extra value") };

            // Act I
            await _mapCache!.SetMapEntriesAsync(_cacheKey, mapEntries);

            // Fetch values repeatedly ensuring that the sliding cache prevents expiration
            for (int i = 0; i < 6; i++)
            {
                var retrievedValues = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { 1, 2, 3 });

                // Assert
                retrievedValues.ShouldBeEquivalentTo(new[] { "Value1", "Value2", "Value3" });

                // Put a slight delay in calls
                Thread.Sleep(SlidingExpirationMs / 5);
            }

            // Wait for sliding expiration to expire
            Thread.Sleep(SlidingExpirationMs);

            // Act II
            var retrievedValues2 = await _mapCache.GetMapEntriesAsync(_cacheKey, new[] { 1, 2, 3 });

            // Assert II
            retrievedValues2.ShouldBeEquivalentTo(new string?[] { null, null, null });
        }
    }
}
