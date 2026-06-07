// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Features.ExternalCache;
using FakeItEasy;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache;

[TestFixture]
public class TieredCacheProviderTests
{
    [Test]
    public void TryGetCachedObject_ShouldPopulateL1CacheFromDistributedCache()
    {
        // Arrange
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCacheProvider = A.Fake<ICacheProvider<string>>();
        object outValue;

        A.CallTo(() => distributedCacheProvider.TryGetCachedObject("cache-key", out outValue))
            .Returns(true)
            .AssignsOutAndRefParameters("cached-value");

        var tieredCacheProvider = new global::EdFi.Ods.Features.ExternalCache.TieredCacheProvider<string>(
            memoryCache,
            distributedCacheProvider,
            TimeSpan.FromMinutes(1));

        // Act
        var foundOnFirstAccess = tieredCacheProvider.TryGetCachedObject("cache-key", out var firstValue);
        var foundOnSecondAccess = tieredCacheProvider.TryGetCachedObject("cache-key", out var secondValue);

        // Assert
        foundOnFirstAccess.ShouldBeTrue();
        foundOnSecondAccess.ShouldBeTrue();
        firstValue.ShouldBe("cached-value");
        secondValue.ShouldBe("cached-value");

        A.CallTo(() => distributedCacheProvider.TryGetCachedObject("cache-key", out outValue))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task TryGetCachedObjectAsync_ShouldUseAsyncDistributedCacheProviderOnL1Miss()
    {
        // Arrange
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCacheProvider = A.Fake<ICacheProvider<string>>();
        var asyncDistributedCacheProvider = A.Fake<IAsyncCacheProvider<string>>();

        A.CallTo(() => asyncDistributedCacheProvider.TryGetCachedObjectAsync("cache-key"))
            .Returns(Task.FromResult<(bool found, object value)>((true, "cached-value")));

        var tieredCacheProvider = new global::EdFi.Ods.Features.ExternalCache.TieredCacheProvider<string>(
            memoryCache,
            distributedCacheProvider,
            TimeSpan.FromMinutes(1),
            asyncDistributedCacheProvider);

        // Act
        var firstResult = await tieredCacheProvider.TryGetCachedObjectAsync("cache-key");
        var secondResult = await tieredCacheProvider.TryGetCachedObjectAsync("cache-key");

        // Assert
        firstResult.found.ShouldBeTrue();
        secondResult.found.ShouldBeTrue();
        firstResult.value.ShouldBe("cached-value");
        secondResult.value.ShouldBe("cached-value");

        A.CallTo(() => asyncDistributedCacheProvider.TryGetCachedObjectAsync("cache-key"))
            .MustHaveHappenedOnceExactly();

        object ignoredValue = null;

        A.CallTo(() => distributedCacheProvider.TryGetCachedObject("cache-key", out ignoredValue))
            .MustNotHaveHappened();
    }

    [Test]
    public void Clear_ShouldRemoveL1CachedEntries()
    {
        // Arrange
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCacheProvider = A.Fake<ICacheProvider<string>>();

        object missingValue = null;

        A.CallTo(() => distributedCacheProvider.TryGetCachedObject("cache-key", out missingValue))
            .Returns(false);

        var tieredCacheProvider = new global::EdFi.Ods.Features.ExternalCache.TieredCacheProvider<string>(
            memoryCache,
            distributedCacheProvider,
            TimeSpan.FromMinutes(1));

        tieredCacheProvider.SetCachedObject("cache-key", "cached-value");

        // Act
        tieredCacheProvider.Clear();
        object ignoredValueAfterClear = null;
        var found = tieredCacheProvider.TryGetCachedObject("cache-key", out ignoredValueAfterClear);

        // Assert
        found.ShouldBeFalse();
    }

    [Test]
    public void Clear_ShouldNotRemoveUnrelatedEntries_FromSharedMemoryCache()
    {
        // Arrange
        using var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var distributedCacheProvider = A.Fake<ICacheProvider<string>>();
        memoryCache.Set("unrelated-key", "unrelated-value");

        object missingValue = null;

        A.CallTo(() => distributedCacheProvider.TryGetCachedObject("cache-key", out missingValue))
            .Returns(false);

        var tieredCacheProvider = new global::EdFi.Ods.Features.ExternalCache.TieredCacheProvider<string>(
            memoryCache,
            distributedCacheProvider,
            TimeSpan.FromMinutes(1));

        tieredCacheProvider.SetCachedObject("cache-key", "cached-value");

        // Act
        tieredCacheProvider.Clear();
        var foundTieredEntry = tieredCacheProvider.TryGetCachedObject("cache-key", out _);
        var foundUnrelatedEntry = memoryCache.TryGetValue("unrelated-key", out var unrelatedValue);

        // Assert
        foundTieredEntry.ShouldBeFalse();
        foundUnrelatedEntry.ShouldBeTrue();
        unrelatedValue.ShouldBe("unrelated-value");
    }
}
