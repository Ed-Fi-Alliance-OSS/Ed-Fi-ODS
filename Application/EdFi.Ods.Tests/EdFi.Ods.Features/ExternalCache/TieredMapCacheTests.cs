// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Features.ExternalCache;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache;

[TestFixture]
public class TieredMapCacheTests
{
    private const string Key = "map-key";

    private static IMapCache<string, string, int> FakeMapCacheBackedBy(Dictionary<string, int> data)
    {
        var fake = A.Fake<IMapCache<string, string, int>>();

        A.CallTo(() => fake.GetMapEntriesAsync(Key, A<string[]>._))
            .ReturnsLazily(
                (string _, string[] mapKeys) =>
                    Task.FromResult(mapKeys.Select(k => data.TryGetValue(k, out var v) ? v : default).ToArray()));

        A.CallTo(() => fake.SetMapEntriesAsync(Key, A<(string key, int value)[]>._))
            .Returns(Task.CompletedTask);

        A.CallTo(() => fake.DeleteMapEntryAsync(Key, A<string>._))
            .Returns(Task.FromResult(true));

        return fake;
    }

    [Test]
    public async Task GetMapEntriesAsync_WhenAllEntriesAreInL1_DoesNotQueryL2()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 });
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int>());

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var result = await tiered.GetMapEntriesAsync(Key, new[] { "a", "b" });

        result.ShouldBe(new[] { 1, 2 });
        A.CallTo(() => l2.GetMapEntriesAsync(Key, A<string[]>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task GetMapEntriesAsync_OnL1Miss_FetchesFromL2AndBackfillsL1()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int>());
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int> { ["a"] = 42 });

        (string key, int value)[] backfilled = null;

        A.CallTo(() => l1.SetMapEntriesAsync(Key, A<(string key, int value)[]>._))
            .Invokes((string _, (string key, int value)[] entries) => backfilled = entries)
            .Returns(Task.CompletedTask);

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var result = await tiered.GetMapEntriesAsync(Key, new[] { "a" });

        result.ShouldBe(new[] { 42 });
        A.CallTo(() => l2.GetMapEntriesAsync(Key, A<string[]>._)).MustHaveHappenedOnceExactly();
        backfilled.ShouldNotBeNull();
        backfilled.ShouldBe(new[] { ("a", 42) });
    }

    [Test]
    public async Task GetMapEntriesAsync_OnPartialMiss_MergesL1AndL2ByPosition()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int> { ["b"] = 2 });
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int> { ["a"] = 1, ["c"] = 3 });

        string[] l2QueriedKeys = null;

        A.CallTo(() => l2.GetMapEntriesAsync(Key, A<string[]>._))
            .Invokes((string _, string[] mapKeys) => l2QueriedKeys = mapKeys)
            .ReturnsLazily(
                (string _, string[] mapKeys) =>
                    Task.FromResult(mapKeys.Select(k => k == "a" ? 1 : k == "c" ? 3 : default).ToArray()));

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var result = await tiered.GetMapEntriesAsync(Key, new[] { "a", "b", "c" });

        result.ShouldBe(new[] { 1, 2, 3 });

        // Only the L1 misses should be queried from L2.
        l2QueriedKeys.ShouldBe(new[] { "a", "c" });
    }

    [Test]
    public async Task GetMapEntriesAsync_WhenL2AlsoMisses_DoesNotBackfillL1()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int>());
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int>());

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var result = await tiered.GetMapEntriesAsync(Key, new[] { "a" });

        result.ShouldBe(new[] { 0 });
        A.CallTo(() => l1.SetMapEntriesAsync(Key, A<(string key, int value)[]>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task SetMapEntriesAsync_WritesToL2Only()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int>());
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int>());

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var entries = new[] { ("a", 1), ("b", 2) };
        await tiered.SetMapEntriesAsync(Key, entries);

        A.CallTo(() => l2.SetMapEntriesAsync(Key, entries)).MustHaveHappenedOnceExactly();
        A.CallTo(() => l1.SetMapEntriesAsync(Key, A<(string key, int value)[]>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task DeleteMapEntryAsync_DeletesFromBothTiers()
    {
        var l1 = FakeMapCacheBackedBy(new Dictionary<string, int>());
        var l2 = FakeMapCacheBackedBy(new Dictionary<string, int>());

        var tiered = new TieredMapCache<string, string, int>(l1, l2);

        var deleted = await tiered.DeleteMapEntryAsync(Key, "a");

        deleted.ShouldBeTrue();
        A.CallTo(() => l2.DeleteMapEntryAsync(Key, "a")).MustHaveHappenedOnceExactly();
        A.CallTo(() => l1.DeleteMapEntryAsync(Key, "a")).MustHaveHappenedOnceExactly();
    }
}
