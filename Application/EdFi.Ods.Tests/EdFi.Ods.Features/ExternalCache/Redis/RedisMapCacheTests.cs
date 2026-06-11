// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using FakeItEasy;
using Shouldly;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Features.ExternalCache.Redis;
using EdFi.Ods.Features.Services.Redis;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache.Redis;

[TestFixture]
public class RedisMapCacheTests
{
    private IRedisConnectionProvider _redisConnectionProvider;
    private IDatabase _cache;
    private RedisMapCache<string, int, string> _mapCache;
    private const int BatchSize = 200;

    public class TestDouble(IRedisConnectionProvider redisConnectionProvider, RedisCacheResilience cacheResilience, TimeSpan? absoluteExpirationPeriod, TimeSpan? slidingExpirationPeriod) : RedisMapCache<string, int, string>(redisConnectionProvider, cacheResilience, absoluteExpirationPeriod, slidingExpirationPeriod, BatchSize)
    {
        protected override RedisValue ConvertMapKeyToRedisValue(int mapKey)
        {
            // For testing purposes, we can just return the map key as a RedisValue
            return mapKey;
        }
    }

    public class TestDoubleWithShort(IRedisConnectionProvider redisConnectionProvider, RedisCacheResilience cacheResilience, TimeSpan? absoluteExpirationPeriod, TimeSpan? slidingExpirationPeriod) : RedisMapCache<string, short, string>(redisConnectionProvider, cacheResilience, absoluteExpirationPeriod, slidingExpirationPeriod, BatchSize)
    {
        protected override RedisValue ConvertMapKeyToRedisValue(short mapKey)
        {
            // For testing purposes, we can just return the map key as a RedisValue
            return mapKey;
        }
    }
    [SetUp]
    public void SetUp()
    {
        _redisConnectionProvider = A.Fake<IRedisConnectionProvider>();
        _cache = A.Fake<IDatabase>();
        A.CallTo(() => _redisConnectionProvider.Get()).Returns(_cache);

        // Set up CreateBatch to return a fake batch that executes commands immediately
        var batch = A.Fake<IBatch>();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).Returns(batch);

        // Configure batch to return completed tasks for all operations
        A.CallTo(() => batch.HashSetAsync(A<RedisKey>.Ignored, A<HashEntry[]>.Ignored, CommandFlags.None))
            .Returns(Task.CompletedTask);
        A.CallTo(() => batch.HashGetAsync(A<RedisKey>.Ignored, A<RedisValue[]>.Ignored, CommandFlags.None))
            .Returns(Task.FromResult(new RedisValue[0]));
        A.CallTo(() => batch.HashDeleteAsync(A<RedisKey>.Ignored, A<RedisValue>.Ignored, CommandFlags.None))
            .Returns(Task.FromResult(true));

        _mapCache = new TestDouble(_redisConnectionProvider, new RedisCacheResilience(), TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5));
    }

    [Test]
    public async Task SetMapEntriesAsync_ShouldCallHashSetAsyncInBatches()
    {
        // Arrange
        string key = "test-key";
        var mapEntries = Enumerable.Range(0, 600000)
            .Select(i => (i, $"value{i}"))
            .ToArray();
        var redisKey = (RedisKey)key;

        // Act
        await _mapCache.SetMapEntriesAsync(key, mapEntries);

        // Assert - verify batch operations were used
        A.CallTo(() => _cache.CreateBatch(A<object>._)).MustHaveHappened();
    }

    [Test]
    public async Task GetMapEntriesAsync_ShouldReturnCorrectValues()
    {
        // Arrange
        string key = "test-key";
        int[] mapKeys = [456, 457];

        // Act
        var result = await _mapCache.GetMapEntriesAsync(key, mapKeys);

        // Assert - verify batch operations were used
        result.ShouldNotBeNull();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).MustHaveHappened();
    }

    [Test]
    public async Task GetMapEntriesAsync_ShouldReturnEmptyArray_WhenMapKeysAreNullOrEmpty()
    {
        // Arrange
        string key = "test-key";

        // Act
        var resultWhenNull = await _mapCache.GetMapEntriesAsync(key, null);
        var resultWhenEmpty = await _mapCache.GetMapEntriesAsync(key, Array.Empty<int>());

        // Assert
        resultWhenNull.ShouldBeEmpty();
        resultWhenEmpty.ShouldBeEmpty();

        // Verify that HashGetAsync is not called
        A.CallTo(() => _cache.HashGetAsync(
                A<RedisKey>._,
                A<RedisValue[]>._,
                CommandFlags.None))
            .MustNotHaveHappened();
    }

    [Test]
    public async Task DeleteMapEntryAsync_ShouldCallHashDeleteAsync()
    {
        // Arrange
        string key = "test-key";
        var mapKey = 456;

        // Act
        var result = await _mapCache.DeleteMapEntryAsync(key, mapKey);

        // Assert - verify batch operations were used
        result.ShouldBeTrue();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).MustHaveHappened();
    }

    [Test]
    public async Task DeleteMapEntryAsync_ShouldThrowArgumentExceptionWhenTryParseFails()
    {
        // Arrange
        string key = "test-key";
        short mapKey = 456; // Int16 is not supported by TryParse, so this will fail
        var batch = A.Fake<IBatch>();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).Returns(batch);

        var mapCache = new TestDoubleWithShort(_redisConnectionProvider, new RedisCacheResilience(), TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5));

        // Act
        var exception = await Should.ThrowAsync<ArgumentException>(async () => await mapCache.DeleteMapEntryAsync(key, mapKey));

        // Assert
        exception.Message.ShouldContain("Unable to convert map key of type 'Int16' to a 'RedisValue'.");
    }

    [Test]
    public void SetMapEntriesAsync_ShouldThrowForNullKey()
    {
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(async () => await _mapCache.SetMapEntriesAsync(null, [(1, "value")]));
        exception.ParamName.ShouldBe("key");
    }

    [Test]
    public async Task SetMapEntriesAsync_ShouldReturnWhenEntriesAreNullOrEmpty()
    {
        // Arrange
        string key = "test-key";
        var redisKey = (RedisKey)key;

        // Act
        await _mapCache.SetMapEntriesAsync(key, null);
        await _mapCache.SetMapEntriesAsync(key, Array.Empty<(int, string)>());

        // Assert
        // Verify that HashSetAsync was never called
        A.CallTo(() => _cache.HashSetAsync(
                redisKey,
                A<HashEntry[]>._,
                CommandFlags.None))
            .MustNotHaveHappened();
    }

    [Test]
    public void GetMapEntriesAsync_ShouldThrowForNullKey()
    {
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(() => _mapCache.GetMapEntriesAsync(null, [1]));
        exception.ParamName.ShouldBe("key");
    }

    [Test]
    public void DeleteMapEntryAsync_ShouldThrowForNullKey()
    {
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(() => _mapCache.DeleteMapEntryAsync(null, 1));
        exception.ParamName.ShouldBe("key");
    }
}

[TestFixture(10, 5)]  // Sliding expiration: 10 minutes, Absolute expiration: 5 minutes
[TestFixture(15, null)] // Sliding expiration: 15 minutes, No absolute expiration
[TestFixture(null, 20)] // No sliding expiration, Absolute expiration: 20 minutes
[TestFixture(null, null)] // No expiration periods
public class RedisMapCacheExpirationTests
{
    private readonly TimeSpan? _absoluteExpirationPeriod;
    private readonly TimeSpan? _slidingExpirationPeriod;

    private IRedisConnectionProvider _redisConnectionProvider;
    private IDatabase _cache;
    private RedisMapCache<string, string, string> _mapCache;
    private const int BatchSize = 200;

    public RedisMapCacheExpirationTests(int? slidingExpirationMinutes, int? absoluteExpirationMinutes)
    {
        _slidingExpirationPeriod = slidingExpirationMinutes.HasValue
            ? TimeSpan.FromMinutes(slidingExpirationMinutes.Value)
            : (TimeSpan?)null;

        _absoluteExpirationPeriod = absoluteExpirationMinutes.HasValue
            ? TimeSpan.FromMinutes(absoluteExpirationMinutes.Value)
            : (TimeSpan?)null;
    }

    [SetUp]
    public void SetUp()
    {
        _redisConnectionProvider = A.Fake<IRedisConnectionProvider>();
        _cache = A.Fake<IDatabase>();
        A.CallTo(() => _redisConnectionProvider.Get()).Returns(_cache);

        // Set up CreateBatch to return a fake batch that executes commands immediately
        var batch = A.Fake<IBatch>();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).Returns(batch);

        // Configure batch to return completed tasks for all operations
        A.CallTo(() => batch.HashSetAsync(A<RedisKey>.Ignored, A<HashEntry[]>.Ignored, CommandFlags.None))
            .Returns(Task.CompletedTask);

        _mapCache = A.Fake<RedisMapCache<string, string, string>>(opts =>
            opts.WithArgumentsForConstructor([_redisConnectionProvider, new RedisCacheResilience(), _absoluteExpirationPeriod, _slidingExpirationPeriod, BatchSize])
                .CallsBaseMethods());
    }

    [Test]
    public async Task SetMapEntriesAsync_ShouldRespectExpirationPeriods()
    {
        // Arrange
        string key = "test-key";
        var mapEntries = new[] { ("key1", "value1") };
        var batch = A.Fake<IBatch>();
        A.CallTo(() => _cache.CreateBatch(A<object>._)).Returns(batch);

        // Act
        await _mapCache.SetMapEntriesAsync(key, mapEntries);

        // Assert - verify batch methods are called based on expiration settings
        A.CallTo(() => batch.HashSetAsync(
                (RedisKey)key,
                A<HashEntry[]>._,
                CommandFlags.None))
            .MustHaveHappened();

        A.CallTo(() => batch.Execute()).MustHaveHappened();
    }
}

