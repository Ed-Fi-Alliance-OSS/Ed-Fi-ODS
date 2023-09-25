// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Defines methods for managing entries of cached maps in batch.
/// </summary>
/// <typeparam name="TKey">The type of the key of the entry for the map in the cache.</typeparam>
/// <typeparam name="TMapKey">The type of the key of the cached map.</typeparam>
/// <typeparam name="TMapValue">The type of the value of the cached map.</typeparam>
public interface IMapCache<TKey, TMapKey, TMapValue>
{
    /// <summary>
    /// Set an array of map entries at the specified key.
    /// </summary>
    /// <param name="key">The key of the map.</param>
    /// <param name="mapEntries">The key/value pairs of the entries to store.</param>
    /// <returns>The number of values stored.</returns>
    Task SetMapEntriesAsync(TKey key, (TMapKey key, TMapValue value)[] mapEntries);

    /// <summary>
    /// Gets an array of matched values in the map corresponding to the supplied array of keys.
    /// </summary>
    /// <param name="key">The key of the map.</param>
    /// <param name="mapKeys">The keys of the entries of the map to return.</param>
    /// <returns>An array of matched values where each entry matches the array position of the corresponding key.</returns>
    Task<TMapValue[]> GetMapEntriesAsync(TKey key, TMapKey[] mapKeys);

    /// <summary>
    /// Deletes an entry from the specified cached map.
    /// </summary>
    /// <param name="key">The key of the entry containing the cached map.</param>
    /// <param name="mapKey">The key of the map entry to be deleted.</param>
    /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
    Task<bool> DeleteMapEntryAsync(TKey key, TMapKey mapKey);
}
