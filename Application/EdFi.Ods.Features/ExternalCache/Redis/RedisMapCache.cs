// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using Microsoft.Extensions.Caching.StackExchangeRedis;
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
    private readonly RedisCacheOptions _options;
    private volatile IConnectionMultiplexer _connection;
    private readonly SemaphoreSlim _connectionLock = new(initialCount: 1, maxCount: 1);
    private IDatabase _cache;

    // TODO: Handle expiration of the cache entry
    private const string AbsoluteExpirationKey = "absexp";
    private const string SlidingExpirationKey = "sldexp";
    private RedisValue[] _expirationKeys = new RedisValue[]
    {
        AbsoluteExpirationKey,
        SlidingExpirationKey
    };
    
    // public RedisMapCache(ConfigurationOptions configurationOptions)
    // {
    //     ArgumentNullException.ThrowIfNull(configurationOptions, nameof(configurationOptions));
    //     _options = new RedisCacheOptions() { ConfigurationOptions = configurationOptions };
    // }

    public RedisMapCache(string configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        _options = new RedisCacheOptions() { Configuration = configuration };
    }

    public async Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
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
            // TODO: Handle sliding expiration refresh of the cache entry
            // .Concat(new []
            // {
            //     new HashEntry(AbsoluteExpirationKey, 12435),
            //     new HashEntry(SlidingExpirationKey, 12435),
            // })
            .ToArray();

        await ConnectAsync().ConfigureAwait(false);
        
        await _cache.HashSetAsync(GetCacheKey(key), hashEntries);
    }

    public async Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys)
    {
        ValidateKey(key);

        if (mapKeys == null || mapKeys.Length == 0)
        {
            return Array.Empty<TMapValue>();
        }

        // TODO: Conditionally add keys for obtaining expiration metadata
        var redisHashKeys = mapKeys
            .Select(mapKey =>
            {
                if (!TryParse(mapKey, out RedisValue redisHashKey))
                {
                    throw new ArgumentException($"Unable to convert '{nameof(mapKey)}' of type '{typeof(TMapKey).Name}' to a '{nameof(RedisValue)}'.");
                }

                return redisHashKey;
            });

        await ConnectAsync().ConfigureAwait(false);

        string cacheKey = GetCacheKey(key);
        
        var keys = redisHashKeys.ToArray();
        var hashValues = await _cache.HashGetAsync(cacheKey, keys);
        
        // TODO: Handle sliding expiration refresh of the cache entry
        // _cache.HashSetAsync(cacheKey, ...);

        foreach (RedisValue hashValue in hashValues)
        {
            Console.WriteLine(hashValue.ToString());
        }
        
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

        await ConnectAsync().ConfigureAwait(false);

        var deleteResult = await _cache.HashDeleteAsync(GetCacheKey(key), redisHashKey);
        
        // TODO: Handle sliding expiration refresh of the cache entry
        // _cache.HashSetAsync(cacheKey, ...);

        return deleteResult;
    }

    private async Task ConnectAsync() //CancellationToken token = default(CancellationToken))
    {
        // CheckDisposed();
        // token.ThrowIfCancellationRequested();

        if (_cache != null)
        {
            return;
        }

        await _connectionLock.WaitAsync().ConfigureAwait(false);
        try
        {
            if (_cache == null)
            {
                if(_options.ConnectionMultiplexerFactory is null)
                {
                    if (_options.ConfigurationOptions is not null)
                    {
                        _connection = await ConnectionMultiplexer.ConnectAsync(_options.ConfigurationOptions).ConfigureAwait(false);
                    }
                    else
                    {
                        _connection = await ConnectionMultiplexer.ConnectAsync(_options.Configuration).ConfigureAwait(false);
                    }
                }
                else
                {
                    _connection = await _options.ConnectionMultiplexerFactory();
                }

                TryRegisterProfiler();
                _cache = _connection.GetDatabase();
            }
        }
        finally
        {
            _connectionLock.Release();
        }
    }

    private void TryRegisterProfiler()
    {
        if (_connection == null)
        {
            throw new InvalidOperationException($"{nameof(_connection)} cannot be null.");
        }

        if (_options.ProfilingSession != null)
        {
            _connection.RegisterProfiler(_options.ProfilingSession);
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
        return (TMapValue)Convert.ChangeType(hashValue, typeof(TMapValue));
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