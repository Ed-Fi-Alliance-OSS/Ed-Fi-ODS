// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Features.Services.Redis;
using StackExchange.Redis;

namespace EdFi.Ods.Features.ExternalCache.Redis;

/// <summary>
/// Provides a general-purpose implementation of IMapCache{{TKey}, {TMapKey}, {TMapValue}} with no consideration given to boxing/unboxing
/// of value types.
/// </summary>
/// <typeparam name="TKey">The type of the cache key.</typeparam>
/// <typeparam name="TMapKey">The type of the hash's key.</typeparam>
/// <typeparam name="TMapValue">The type of the hash's value.</typeparam>
public class RedisMapCache<TKey, TMapKey, TMapValue> : IMapCache<TKey, TMapKey, TMapValue>
{
    private readonly TimeSpan? _absoluteExpirationPeriod;
    private readonly TimeSpan? _slidingExpirationPeriod;

    private readonly IDatabase _cache;

    protected RedisMapCache(
        IRedisConnectionProvider redisConnectionProvider,
        TimeSpan? absoluteExpirationPeriod,
        TimeSpan? slidingExpirationPeriod)
    {
        _absoluteExpirationPeriod = absoluteExpirationPeriod;
        _slidingExpirationPeriod = slidingExpirationPeriod;

        _cache = redisConnectionProvider.Get();
    }

    public async Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
        // Maximum number of items per batch
        const int BatchSize = 524000;

        ValidateKey(key);

        if (mapEntries == null || mapEntries.Length == 0)
        {
            return;
        }

        var hashEntries = mapEntries
            .Select(entry =>
            {
                if (!TryParse(entry.key, out RedisValue redisHashKey))
                {
                    throw new ArgumentException($"Unable to convert '{nameof(entry.key)}' of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
                }

                if (!TryParse(entry.value, out RedisValue redisHashValue))
                {
                    throw new ArgumentException($"Unable to convert '{nameof(entry.value)}' of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
                }

                return new HashEntry(redisHashKey, redisHashValue);
            })
            .ToArray();

        string cacheKey = GetCacheKey(key);

        // Break the hash entries into batches and send each batch separately to avoid the ~1M parameter limit for Redis commands
        for (int i = 0; i < hashEntries.Length; i += BatchSize)
        {
            var batchEntries = hashEntries.Skip(i).Take(BatchSize).ToArray();
            await _cache.HashSetAsync(cacheKey, batchEntries);
        }

        // Handle initial expiration
        ApplyInitialExpiration(cacheKey);
    }

    public async Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys)
    {
        ValidateKey(key);

        if (mapKeys == null || mapKeys.Length == 0)
        {
            return Array.Empty<TMapValue>();
        }

        var redisHashKeys = mapKeys
            .Select(mapKey =>
            {
                if (!TryParse(mapKey, out RedisValue redisHashKey))
                {
                    throw new ArgumentException($"Unable to convert '{nameof(mapKey)}' of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
                }

                return redisHashKey;
            });

        string cacheKey = GetCacheKey(key);

        var keys = redisHashKeys.ToArray();
        var hashValues = await _cache.HashGetAsync(cacheKey, keys);

        // Handle sliding expiration refresh of the cache entry
        ApplySlidingExpiration(cacheKey);

        return hashValues.Select(ConvertRedisValue).ToArray();
    }

    public async Task<bool> DeleteMapEntryAsync(TKey key, TMapKey mapKey)
    {
        ValidateKey(key);
        ValidateMapKey(mapKey);

        if (!TryParse(mapKey, out RedisValue redisHashKey))
        {
            throw new ArgumentException($"Unable to convert '{nameof(mapKey)}' of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
        }

        string cacheKey = GetCacheKey(key);
        var deleteResult = await _cache.HashDeleteAsync(cacheKey, redisHashKey);

        // Handle sliding expiration refresh of the cache entry
        ApplySlidingExpiration(cacheKey);

        return deleteResult;
    }

    private void ApplyInitialExpiration(string cacheKey)
    {
        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            // Set the initial expiration using the sliding expiration period
            long slidingExpirationMs = (long) _slidingExpirationPeriod.Value.TotalMilliseconds;

            // Set initial sliding expiration for the key
            _cache.ExecuteAsync(
                $"PEXPIRE",
                new object[]
                {
                    cacheKey,
                    slidingExpirationMs
                },
                CommandFlags.FireAndForget);
        }
        else if (_absoluteExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            // Set the initial expiration using the absolute expiration period
            long absoluteExpirationMs = (long) _absoluteExpirationPeriod.Value.TotalMilliseconds;

            // Set initial absolute expiration for the key (but only if expiration hasn't been set yet)
            _cache.Execute(
                $"PEXPIRE",
                new object[]
                {
                    cacheKey,
                    absoluteExpirationMs,
                    "NX"
                },
                CommandFlags.FireAndForget);
        }
    }

    private void ApplySlidingExpiration(string cacheKey)
    {
        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            // Slide the expiration
            _cache.Execute(
                $"PEXPIRE",
                new object[]
                {
                    cacheKey,
                    (long) _slidingExpirationPeriod.Value.TotalMilliseconds
                },
                CommandFlags.FireAndForget);
        }
    }

    // Utility functions that can be overridden in derived implementations to optimize behavior (such as avoid boxing/unboxing of arguments).
    protected virtual string GetCacheKey(TKey key) => key.ToString();

    protected virtual void ValidateKey(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
    }

    protected virtual void ValidateMapKey(TMapKey mapKey)
    {
        ArgumentNullException.ThrowIfNull(mapKey, nameof(mapKey));
    }

    protected virtual TMapValue ConvertRedisValue(RedisValue hashValue)
    {
        return (TMapValue) Convert.ChangeType(hashValue, typeof(TMapValue));
    }

    private static bool TryParse<T>(T obj, out RedisValue value)
    {
        // Generic version of similar function defined internally in RedisValue
        value = obj switch
        {
            string v => v,
            int v => v,
            uint v => v,
            double v => v,
            byte[] v => v,
            bool v => v,
            long v => v,
            ulong v => v,
            float v => v,
            ReadOnlyMemory<byte> v => v,
            Memory<byte> v => v,
            RedisValue v => v,
            _ => RedisValue.Null,
        };

        return (value != RedisValue.Null);
    }
}
