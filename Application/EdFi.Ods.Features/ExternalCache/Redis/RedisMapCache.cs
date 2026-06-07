// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Features.Services.Redis;
using log4net;
using Polly.CircuitBreaker;
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
    private readonly IRedisConnectionProvider _redisConnectionProvider;
    private readonly RedisCacheResilience _resilience;
    private readonly ILog _logger = LogManager.GetLogger(typeof(RedisMapCache<,,>).Name);

    protected RedisMapCache(
        IRedisConnectionProvider redisConnectionProvider,
        RedisCacheResilience resilience,
        TimeSpan? absoluteExpirationPeriod,
        TimeSpan? slidingExpirationPeriod)
    {
        _redisConnectionProvider = redisConnectionProvider ?? throw new ArgumentNullException(nameof(redisConnectionProvider));
        _resilience = resilience ?? throw new ArgumentNullException(nameof(resilience));
        _absoluteExpirationPeriod = absoluteExpirationPeriod;
        _slidingExpirationPeriod = slidingExpirationPeriod;
    }

    /// <summary>
    /// Sets one or more map entries for the specified cache key.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="mapEntries">The map entries to store.</param>
    public async Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
        const int BatchSize = 5000;

        ValidateKey(key);

        if (mapEntries is null || mapEntries.Length == 0)
        {
            return;
        }

        var hashEntries = new HashEntry[mapEntries.Length];

        for (int i = 0; i < mapEntries.Length; i++)
        {
            hashEntries[i] = new HashEntry(
                ConvertMapKeyToRedisValue(mapEntries[i].key),
                ConvertMapValueToRedisValue(mapEntries[i].value));
        }

        string cacheKey = GetCacheKey(key);

        try
        {
            await _resilience.Pipeline.ExecuteAsync(
                    async _ =>
                    {
                        var cache = _redisConnectionProvider.Get();

                        for (int i = 0; i < hashEntries.Length; i += BatchSize)
                        {
                            int remaining = hashEntries.Length - i;
                            int currentBatchSize = Math.Min(BatchSize, remaining);
                            var batchEntries = new HashEntry[currentBatchSize];
                            Array.Copy(hashEntries, i, batchEntries, 0, currentBatchSize);
                            bool isLastBatch = i + currentBatchSize >= hashEntries.Length;
                            var batch = cache.CreateBatch();
                            var setTask = batch.HashSetAsync(cacheKey, batchEntries);
                            Task<bool> expireTask = isLastBatch ? ApplyInitialExpirationBatched(batch, cacheKey) : null;
                            batch.Execute();
                            await setTask.ConfigureAwait(false);

                            if (expireTask is not null)
                            {
                                await LogExpirationFailureAsync(expireTask, cacheKey).ConfigureAwait(false);
                            }
                        }
                    },
                    CancellationToken.None)
                .ConfigureAwait(false);
        }
        catch (BrokenCircuitException ex)
        {
            LogOpenCircuit(nameof(SetMapEntriesAsync), cacheKey, ex);
        }
        catch (Exception ex) when (IsRedisUnavailable(ex))
        {
            _logger.Warn($"Redis cache set failed for key '{cacheKey}'. Falling back to uncached behavior.", ex);
        }
    }

    /// <summary>
    /// Gets map entries for the specified cache key.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="mapKeys">The map keys to retrieve.</param>
    /// <returns>The values associated with the supplied map keys.</returns>
    public async Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys)
    {
        ValidateKey(key);

        if (mapKeys is null || mapKeys.Length == 0)
        {
            return Array.Empty<TMapValue>();
        }

        var redisHashKeys = new RedisValue[mapKeys.Length];

        for (int i = 0; i < mapKeys.Length; i++)
        {
            redisHashKeys[i] = ConvertMapKeyToRedisValue(mapKeys[i]);
        }

        string cacheKey = GetCacheKey(key);

        try
        {
            TMapValue[] mapValues = null;

            await _resilience.Pipeline.ExecuteAsync(
                    async _ =>
                    {
                        var cache = _redisConnectionProvider.Get();
                        var batch = cache.CreateBatch();
                        var hashValuesTask = batch.HashGetAsync(cacheKey, redisHashKeys);
                        Task<bool> expireTask = null;

                        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
                        {
                            expireTask = batch.KeyExpireAsync(cacheKey, _slidingExpirationPeriod.Value);
                        }

                        batch.Execute();

                        var hashValues = await hashValuesTask.ConfigureAwait(false);

                        if (expireTask is not null)
                        {
                            await LogExpirationFailureAsync(expireTask, cacheKey).ConfigureAwait(false);
                        }

                        mapValues = new TMapValue[hashValues.Length];

                        for (int i = 0; i < hashValues.Length; i++)
                        {
                            mapValues[i] = ConvertRedisValue(hashValues[i]);
                        }
                    },
                    CancellationToken.None)
                .ConfigureAwait(false);

            return mapValues ?? new TMapValue[mapKeys.Length];
        }
        catch (BrokenCircuitException ex)
        {
            LogOpenCircuit(nameof(GetMapEntriesAsync), cacheKey, ex);
            return new TMapValue[mapKeys.Length];
        }
        catch (Exception ex) when (IsRedisUnavailable(ex))
        {
            _logger.Warn($"Redis cache get failed for key '{cacheKey}'. Falling back to uncached behavior.", ex);
            return new TMapValue[mapKeys.Length];
        }
    }

    /// <summary>
    /// Deletes a map entry for the specified cache key.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="mapKey">The map key to delete.</param>
    /// <returns><see langword="true"/> if the map entry was deleted; otherwise, <see langword="false"/>.</returns>
    public async Task<bool> DeleteMapEntryAsync(TKey key, TMapKey mapKey)
    {
        ValidateKey(key);
        ValidateMapKey(mapKey);

        RedisValue redisHashKey = ConvertMapKeyToRedisValue(mapKey);

        string cacheKey = GetCacheKey(key);

        try
        {
            bool deleteResult = false;

            await _resilience.Pipeline.ExecuteAsync(
                    async _ =>
                    {
                        var cache = _redisConnectionProvider.Get();
                        var batch = cache.CreateBatch();
                        var deleteResultTask = batch.HashDeleteAsync(cacheKey, redisHashKey);
                        Task<bool> expireTask = null;

                        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
                        {
                            expireTask = batch.KeyExpireAsync(cacheKey, _slidingExpirationPeriod.Value);
                        }

                        batch.Execute();

                        deleteResult = await deleteResultTask.ConfigureAwait(false);

                        if (expireTask is not null)
                        {
                            await LogExpirationFailureAsync(expireTask, cacheKey).ConfigureAwait(false);
                        }
                    },
                    CancellationToken.None)
                .ConfigureAwait(false);

            return deleteResult;
        }
        catch (BrokenCircuitException ex)
        {
            LogOpenCircuit(nameof(DeleteMapEntryAsync), cacheKey, ex);
            return false;
        }
        catch (Exception ex) when (IsRedisUnavailable(ex))
        {
            _logger.Warn($"Redis cache delete failed for key '{cacheKey}'. Falling back to uncached behavior.", ex);
            return false;
        }
    }

    private Task<bool> ApplyInitialExpirationBatched(IBatch batch, string cacheKey)
    {
        if (_slidingExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            return batch.KeyExpireAsync(cacheKey, _slidingExpirationPeriod.Value);
        }

        if (_absoluteExpirationPeriod is { TotalMilliseconds: > 0 })
        {
            return batch.KeyExpireAsync(cacheKey, _absoluteExpirationPeriod.Value, ExpireWhen.HasNoExpiry);
        }

        return null;
    }

    private async Task LogExpirationFailureAsync(Task<bool> expireTask, string cacheKey)
    {
        try
        {
            var result = await expireTask.ConfigureAwait(false);

            if (!result && _logger.IsDebugEnabled)
            {
                _logger.Debug($"PEXPIRE returned false for key '{cacheKey}' — key may not exist.");
            }
        }
        catch (Exception ex)
        {
            _logger.Warn($"Failed to set expiration for cache key '{cacheKey}'.", ex);
        }
    }

    private void LogOpenCircuit(string operationName, string cacheKey, BrokenCircuitException ex)
    {
        if (_logger.IsDebugEnabled)
        {
            _logger.Debug($"Skipping Redis cache operation '{operationName}' for key '{cacheKey}' because the circuit is open.", ex);
        }
    }

    private static bool IsRedisUnavailable(Exception ex)
    {
        return ex is RedisException or TimeoutException;
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

    protected virtual RedisValue ConvertMapKeyToRedisValue(TMapKey mapKey)
    {
        if (!TryParse(mapKey, out RedisValue value))
        {
            throw new ArgumentException($"Unable to convert map key of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
        }

        return value;
    }

    protected virtual RedisValue ConvertMapValueToRedisValue(TMapValue mapValue)
    {
        if (!TryParse(mapValue, out RedisValue value))
        {
            throw new ArgumentException($"Unable to convert map value of type '{typeof(TMapValue).Name}' to a '{nameof(RedisValue)}'.");
        }

        return value;
    }

    private static bool TryParse<T>(T obj, out RedisValue value)
    {
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

        return value != RedisValue.Null;
    }
}
