// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.Caching;

public class InProcessMapCache<TKey, TMapKey, TMapValue> : IMapCache<TKey, TMapKey, TMapValue>
{
    private readonly ICacheProvider<TKey> _cacheProvider;
    private readonly TimeSpan _slidingExpiration;
    private readonly TimeSpan _absoluteExpirationPeriod;
    private readonly Dictionary<string, bool> _cacheSuppression;

    public InProcessMapCache(
        ICacheProvider<TKey> cacheProvider,
        TimeSpan slidingExpiration,
        TimeSpan absoluteExpirationPeriod,
        Dictionary<string, bool> cacheSuppression)
    {
        if (slidingExpiration < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(slidingExpiration), "TimeSpan cannot be a negative value.");
        }

        if (absoluteExpirationPeriod < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(absoluteExpirationPeriod), "TimeSpan cannot be a negative value.");
        }

        // Use sliding expiration value, if both are set.
        if (slidingExpiration > TimeSpan.Zero && absoluteExpirationPeriod > TimeSpan.Zero)
        {
            absoluteExpirationPeriod = TimeSpan.Zero;
        }

        _cacheProvider = cacheProvider;
        _slidingExpiration = slidingExpiration;
        _absoluteExpirationPeriod = absoluteExpirationPeriod;
        _cacheSuppression = cacheSuppression;
        
        // TODO: Implement cache suppression behavior appropriately
    }

    public bool SetMapItem(TKey key, TMapKey mapKey, TMapValue value)
    {
        var map = GetOrAddMap(key);

        map[mapKey] = value;

        return true;
    }

    public long SetMapItems(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
        var map = GetOrAddMap(key);

        foreach (var kvp in mapEntries)
        {
            map[kvp.key] = kvp.value;
        }

        return mapEntries.Length;
    }

    public TMapValue GetMapItem(TKey key, TMapKey mapKey)
    {
        var map = GetOrAddMap(key);

        return map.TryGetValue(mapKey, out var value)
            ? value
            : default;
    }

    public TMapValue[] GetMapItems(TKey key, TMapKey[] mapKeys)
    {
        var map = GetOrAddMap(key);

        var values = new TMapValue[mapKeys.Length];
        
        mapKeys.ForEach((k, i) =>
        {
            if (map.TryGetValue(k, out var value))
            {
                values[i] = value;
            }
        });

        return values;
    }

    public bool DeleteMapItem(TKey key, TMapKey mapKey)
    {
        var map = GetOrAddMap(key);

        return map.TryRemove(mapKey, out var ignored);
    }

    public bool ContainsMap(TKey key) => _cacheProvider.TryGetCachedObject(key, out var ignored);

    private ConcurrentDictionary<TMapKey, TMapValue> GetOrAddMap(TKey key)
    {
        if (!_cacheProvider.TryGetCachedObject(key, out var mapAsObject))
        {
            mapAsObject = new ConcurrentDictionary<TMapKey, TMapValue>();
            _cacheProvider.Insert(key, mapAsObject, DateTime.UtcNow.Add(_absoluteExpirationPeriod), _slidingExpiration);
        }

        return (ConcurrentDictionary<TMapKey, TMapValue>)mapAsObject;
    }
}
