// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Caching;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class InMemoryMapCacheTests
{
    private IMemoryCache _memoryCache;
    private InMemoryMapCache<string, int, string> _mapCache;

    [SetUp]
    public void SetUp()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _mapCache = new InMemoryMapCache<string, int, string>(_memoryCache, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(60));
    }

    [Test]
    public async Task SetMapEntries_ShouldSetAndRetrieveMultipleMapEntries()
    {
        // Arrange
        var key = "TestKey";
        var mapEntries = new[] { (1, "Value1"), (2, "Value2"), (3, "Value3"), (4, "Extra value") };

        // Act
        await _mapCache.SetMapEntriesAsync(key, mapEntries);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(key, new[] { 1, 2, 3 });

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { "Value1", "Value2", "Value3" });
    }

    [Test]
    public async Task GetMapEntries_ShouldReturnDefaultsForNotFoundKeys()
    {
        // Arrange
        var key = "TestKey";
        var mapKeys = new[] { 1, 2, 3 };

        // Act
        var retrievedValues = await _mapCache.GetMapEntriesAsync(key, mapKeys);

        // Assert
        retrievedValues.ShouldBeEquivalentTo(new[] { default(string), default(string), default(string) });
    }

    [Test]
    public async Task DeleteMapEntry_ShouldRemoveMapEntry()
    {
        // Arrange
        var key = "TestKey";
        var mapKey = 1;
        
        await _mapCache.SetMapEntriesAsync(key, new[] {(mapKey, "Value")});

        // Act
        var deleted = await _mapCache.DeleteMapEntryAsync(key, mapKey);
        var retrievedValues = await _mapCache.GetMapEntriesAsync(key, new[] {mapKey});

        // Assert
        deleted.ShouldBeTrue();
        retrievedValues.Length.ShouldBe(1);
        retrievedValues[0].ShouldBe(default);
    }

    [Test]
    public async Task DeleteMapEntry_ShouldReturnFalseForNonexistentEntry()
    {
        // Arrange
        var key = "TestKey";
        var mapKey = 1;

        // Act
        var deleted = await _mapCache.DeleteMapEntryAsync(key, mapKey);

        // Assert
        deleted.ShouldBeFalse();
    }
}
