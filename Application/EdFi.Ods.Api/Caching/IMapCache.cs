// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Caching;

public interface IMapCache<TKey, TMapKey, TMapValue>
{
    bool SetMapEntry(TKey key, TMapKey mapKey, TMapValue mapValue);

    long SetMapEntries(TKey key, (TMapKey key, TMapValue value)[] mapEntries);
    
    TMapValue GetMapEntry(TKey key, TMapKey mapKey);

    /// <summary>
    /// Gets an array of matched values in the map corresponding to the supplied array of keys.
    /// </summary>
    /// <param name="key">The key of the map.</param>
    /// <param name="mapKeys">The keys of the entries of the map to return.</param>
    /// <returns>An array of matched values where each entry matches the array position of the corresponding key.</returns>
    TMapValue[] GetMapEntries(TKey key, TMapKey[] mapKeys);

    bool DeleteMapEntry(TKey key, TMapKey mapKey);
}
