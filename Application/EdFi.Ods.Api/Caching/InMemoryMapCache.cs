// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Implements a map cache backed by the <see cref="IMemoryCache" /> implementation.
/// </summary>
/// <typeparam name="TKey">The type of the cache entry.</typeparam>
/// <typeparam name="TMapKey">The type of the map's keys.</typeparam>
/// <typeparam name="TMapValue">The type of the map's values.</typeparam>
public class InMemoryMapCache<TKey, TMapKey, TMapValue> : IMapCache<TKey, TMapKey, TMapValue>
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;

    public InMemoryMapCache(
        IMemoryCache memoryCache,
        TimeSpan slidingExpiration,
        TimeSpan absoluteExpirationPeriod)
    {
        if (slidingExpiration < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(slidingExpiration), "TimeSpan cannot be a negative value.");
        }

        if (absoluteExpirationPeriod < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(absoluteExpirationPeriod), "TimeSpan cannot be a negative value.");
        }

        _memoryCache = memoryCache;
        
        _memoryCacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationPeriod <= TimeSpan.Zero ? null : absoluteExpirationPeriod,
            SlidingExpiration = slidingExpiration <= TimeSpan.Zero ? null : slidingExpiration,
        };
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.SetMapEntriesAsync" />
    public Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
        var map = GetOrAddMap(key);

        foreach (var kvp in mapEntries)
        {
            map[kvp.key] = kvp.value;
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.GetMapEntriesAsync" />
    public Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys)
    {
        var map = GetOrAddMap(key);

        var values = new TMapValue[mapKeys.Length];
        
        mapKeys.ForEach((k, i, args) =>
        {
            if (args.map.TryGetValue(k, out var value))
            {
                args.values[i] = value;
            }
        }, (map, values));

        return Task.FromResult(values);
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.DeleteMapEntryAsync" />
    public Task<bool> DeleteMapEntryAsync(TKey key, TMapKey mapKey)
    {
        var map = GetOrAddMap(key);

        return Task.FromResult(map.TryRemove(mapKey, out var ignored));
    }

    private ConcurrentDictionary<TMapKey, TMapValue> GetOrAddMap(TKey key)
    {
        if (!_memoryCache.TryGetValue(key, out var mapAsObject))
        {
            mapAsObject = new ConcurrentDictionary<TMapKey, TMapValue>();
            _memoryCache.Set(key, mapAsObject, _memoryCacheEntryOptions);
        }

        return (ConcurrentDictionary<TMapKey, TMapValue>) mapAsObject;
    }
}
