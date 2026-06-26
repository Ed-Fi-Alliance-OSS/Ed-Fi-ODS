// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using log4net;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Provides a two-tier map cache with a short-lived in-process L1 map cache in front of a distributed L2 map cache.
/// </summary>
/// <typeparam name="TKey">The type of the key of the entry for the map in the cache.</typeparam>
/// <typeparam name="TMapKey">The type of the key of the cached map.</typeparam>
/// <typeparam name="TMapValue">The type of the value of the cached map.</typeparam>
public class TieredMapCache<TKey, TMapKey, TMapValue> : IMapCache<TKey, TMapKey, TMapValue>
{
    private static readonly EqualityComparer<TMapValue> ValueComparer = EqualityComparer<TMapValue>.Default;
    private static readonly ILog _logger = LogManager.GetLogger(typeof(TieredMapCache<TKey, TMapKey, TMapValue>));

    private readonly IMapCache<TKey, TMapKey, TMapValue> _l1MapCache;
    private readonly IMapCache<TKey, TMapKey, TMapValue> _l2MapCache;

    /// <summary>
    /// Initializes a new instance of the <see cref="TieredMapCache{TKey,TMapKey,TMapValue}"/> class.
    /// </summary>
    /// <param name="l1MapCache">The in-process L1 map cache.</param>
    /// <param name="l2MapCache">The distributed L2 map cache.</param>
    public TieredMapCache(
        IMapCache<TKey, TMapKey, TMapValue> l1MapCache,
        IMapCache<TKey, TMapKey, TMapValue> l2MapCache)
    {
        _l1MapCache = l1MapCache;
        _l2MapCache = l2MapCache;
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.SetMapEntriesAsync" />
    public Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries)
    {
        // Write-through to L2 only. Bulk initialization (PersonMapCacheInitializer) can load
        // very large maps through this method; populating L1 here would defeat the purpose of a
        // small, short-lived L1 tier. L1 is populated lazily on read instead.
        return _l2MapCache.SetMapEntriesAsync(key, mapEntries);
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.GetMapEntriesAsync" />
    public async Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys)
    {
        var l1Values = await _l1MapCache.GetMapEntriesAsync(key, mapKeys).ConfigureAwait(false);

        int missCount = 0;

        for (int i = 0; i < l1Values.Length; i++)
        {
            if (IsMiss(l1Values[i]))
            {
                missCount++;
            }
        }

        if (missCount == 0)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"[Hybrid] All {l1Values.Length} map entries served from L1 (in-memory) for key '{CacheKeyLogSanitizer.SanitizeKeyForLogging(key)}'.");
            }

            return l1Values;
        }

        var missingKeys = new TMapKey[missCount];
        var missingIndexes = new int[missCount];
        int m = 0;

        for (int i = 0; i < l1Values.Length; i++)
        {
            if (IsMiss(l1Values[i]))
            {
                missingKeys[m] = mapKeys[i];
                missingIndexes[m] = i;
                m++;
            }
        }

        var l2Values = await _l2MapCache.GetMapEntriesAsync(key, missingKeys).ConfigureAwait(false);

        int foundCount = 0;

        for (int j = 0; j < l2Values.Length; j++)
        {
            if (!IsMiss(l2Values[j]))
            {
                foundCount++;
            }
        }

        if (foundCount > 0)
        {
            var foundEntries = new (TMapKey key, TMapValue value)[foundCount];
            int f = 0;

            for (int j = 0; j < l2Values.Length; j++)
            {
                if (!IsMiss(l2Values[j]))
                {
                    l1Values[missingIndexes[j]] = l2Values[j];
                    foundEntries[f++] = (missingKeys[j], l2Values[j]);
                }
            }

            // Backfill only the entries actually found in L2 (do not negatively cache misses).
            await _l1MapCache.SetMapEntriesAsync(key, foundEntries).ConfigureAwait(false);
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"[Hybrid] {l1Values.Length - missCount} of {l1Values.Length} map entries served from L1 (in-memory); "
                + $"{foundCount} of {missCount} L1 misses served from L2 (external) and backfilled to L1 for key '{CacheKeyLogSanitizer.SanitizeKeyForLogging(key)}'.");
        }

        return l1Values;
    }

    /// <inheritdoc cref="IMapCache{TKey,TMapKey,TMapValue}.DeleteMapEntryAsync" />
    public async Task<bool> DeleteMapEntryAsync(TKey key, TMapKey mapKey)
    {
        bool deleted = await _l2MapCache.DeleteMapEntryAsync(key, mapKey).ConfigureAwait(false);

        // Always evict from L1 to avoid serving a stale value after deletion.
        await _l1MapCache.DeleteMapEntryAsync(key, mapKey).ConfigureAwait(false);

        return deleted;
    }

    private static bool IsMiss(TMapValue value)
    {
        return ValueComparer.Equals(value, default);
    }
}
