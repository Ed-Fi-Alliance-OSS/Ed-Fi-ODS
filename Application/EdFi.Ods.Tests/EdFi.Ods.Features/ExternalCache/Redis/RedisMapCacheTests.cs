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
    private RedisMapCache<string, string, string> _mapCache;

    [SetUp]
    public void SetUp()
    {
        _redisConnectionProvider = A.Fake<IRedisConnectionProvider>();
        _cache = A.Fake<IDatabase>();
        A.CallTo(() => _redisConnectionProvider.Get()).Returns(_cache);

        _mapCache = A.Fake<RedisMapCache<string, string, string>>(opts =>
            opts.WithArgumentsForConstructor(new object[] { _redisConnectionProvider, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5) })
                .CallsBaseMethods());
    }

    [Test]
    public async Task SetMapEntriesAsync_ShouldCallHashSetAsyncInBatches()
    {
        // Arrange
        string key = "test-key";
        var mapEntries = Enumerable.Range(0, 600000)
            .Select(i => ($"key{i}", $"value{i}"))
            .ToArray();
        const int BatchSize = 524000;
        var redisKey = (RedisKey)key;

        // Act
        await _mapCache.SetMapEntriesAsync(key, mapEntries);

        // Assert
        // Verify the first batch
        A.CallTo(() => _cache.HashSetAsync(
                redisKey,
                A<HashEntry[]>.That.Matches(entries => entries.Length == BatchSize),
                CommandFlags.None))
            .MustHaveHappenedOnceExactly();

        // Verify the remaining items in the second batch
        A.CallTo(() => _cache.HashSetAsync(
                redisKey,
                A<HashEntry[]>.That.Matches(entries => entries.Length == mapEntries.Length - BatchSize),
                CommandFlags.None))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task GetMapEntriesAsync_ShouldReturnCorrectValues()
    {
        // Arrange
        string key = "test-key";
        string[] mapKeys = ["key1", "key2"];
        
        // Convert mapKeys to RedisValue array
        var redisKeys = mapKeys.Select(k => (RedisValue) k).ToArray();
        
        RedisValue[] redisValues = [ "value1", "value2" ];

        A.CallTo(() => _cache.HashGetAsync(key, redisKeys, CommandFlags.None))
            .Returns(Task.FromResult(redisValues));

        // Act
        var result = await _mapCache.GetMapEntriesAsync(key, mapKeys);

        // Assert
        result.ShouldBe(new[] { "value1", "value2" });
        A.CallTo(() => _cache.HashGetAsync(key, redisKeys, CommandFlags.None))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task GetMapEntriesAsync_ShouldReturnEmptyArray_WhenMapKeysAreNullOrEmpty()
    {
        // Arrange
        string key = "test-key";

        // Act
        var resultWhenNull = await _mapCache.GetMapEntriesAsync(key, null);
        var resultWhenEmpty = await _mapCache.GetMapEntriesAsync(key, Array.Empty<string>());

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
        string mapKey = "map-key";

        A.CallTo(() => _cache.HashDeleteAsync(key, mapKey, CommandFlags.None))
            .Returns(Task.FromResult(true));

        // Act
        var result = await _mapCache.DeleteMapEntryAsync(key, mapKey);

        // Assert
        result.ShouldBeTrue();
        A.CallTo(() => _cache.HashDeleteAsync(key, mapKey, CommandFlags.None))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task DeleteMapEntryAsync_ShouldThrowArgumentExceptionWhenTryParseFails()
    {
        // Arrange
        string key = "test-key"; // Using string for TKey
        short mapKey = 456; // Using short for TMapKey
        var mapCache = A.Fake<RedisMapCache<string, short, string>>(opts =>
            opts.WithArgumentsForConstructor(new object[] { _redisConnectionProvider, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5) })
                .CallsBaseMethods());

        // Act
        var exception = await Should.ThrowAsync<ArgumentException>(async () => await mapCache.DeleteMapEntryAsync(key, mapKey));

        // Assert
        exception.Message.ShouldContain($"Unable to convert '{nameof(mapKey)}' of type 'Int16' to a 'RedisValue'.");
    }

    [Test]
    public void SetMapEntriesAsync_ShouldThrowForNullKey()
    {
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(async () => await _mapCache.SetMapEntriesAsync(null, new[] { ("key", "value") }));
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
        await _mapCache.SetMapEntriesAsync(key, Array.Empty<(string, string)>());

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
        var exception = Should.Throw<ArgumentNullException>(() => _mapCache.GetMapEntriesAsync(null, new[] { "key1" }));
        exception.ParamName.ShouldBe("key");
    }

    [Test]
    public void DeleteMapEntryAsync_ShouldThrowForNullKey()
    {
        // Act & Assert
        var exception = Should.Throw<ArgumentNullException>(() => _mapCache.DeleteMapEntryAsync(null, "map-key"));
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

        _mapCache = A.Fake<RedisMapCache<string, string, string>>(opts =>
            opts.WithArgumentsForConstructor([_redisConnectionProvider, _absoluteExpirationPeriod, _slidingExpirationPeriod])
                .CallsBaseMethods());
    }

    [Test]
    public async Task SetMapEntriesAsync_ShouldRespectExpirationPeriods()
    {
        // Arrange
        string key = "test-key";
        var mapEntries = new[] { ("key1", "value1") };
        var redisKey = (RedisKey)key;

        // Act
        await _mapCache.SetMapEntriesAsync(key, mapEntries);

        // Assert
        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            A.CallTo(() => _cache.ExecuteAsync(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string) args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_slidingExpirationPeriod.Value.TotalMilliseconds),
                    CommandFlags.FireAndForget))
                .MustHaveHappened();

            A.CallTo(() => _cache.Execute(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string) args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_absoluteExpirationPeriod.Value.TotalMilliseconds &&
                        args[2].Equals("NX")),
                    CommandFlags.FireAndForget))
                .MustNotHaveHappened();
        }

        if (_absoluteExpirationPeriod is { TotalMilliseconds: > 0 } && _slidingExpirationPeriod is not { TotalMilliseconds: > 0 })
        {
            A.CallTo(() => _cache.Execute(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string)args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_absoluteExpirationPeriod.Value.TotalMilliseconds &&
                        args[2].Equals("NX")),
                    CommandFlags.FireAndForget))
                .MustHaveHappened();

            A.CallTo(() => _cache.ExecuteAsync(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string) args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_slidingExpirationPeriod.Value.TotalMilliseconds),
                    CommandFlags.FireAndForget))
                .MustNotHaveHappened();
        }

        if (_absoluteExpirationPeriod is not { TotalMilliseconds: > 0 }
            && _slidingExpirationPeriod is not { TotalMilliseconds: > 0 })
        {
            A.CallTo(() => _cache.ExecuteAsync(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string) args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_slidingExpirationPeriod.Value.TotalMilliseconds),
                    CommandFlags.FireAndForget))
                .MustNotHaveHappened();
            
            A.CallTo(() => _cache.Execute(
                    "PEXPIRE",
                    A<object[]>.That.Matches(args =>
                        ((string) args[0]).Equals(redisKey) &&
                        (long)args[1] == (long)_absoluteExpirationPeriod.Value.TotalMilliseconds &&
                        args[2].Equals("NX")),
                    CommandFlags.FireAndForget))
                .MustNotHaveHappened();
        }
    }
}

