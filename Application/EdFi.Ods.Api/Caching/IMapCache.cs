// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Api.Caching;

public interface IMapCache<TKey, TMapKey, TMapValue>
{
    bool SetMapItem(TKey key, TMapKey mapKey, TMapValue mapValue);

    long SetMapItems(TKey key, (TMapKey key, TMapValue value)[] mapEntries);
    
    TMapValue GetMapItem(TKey key, TMapKey mapKey);

    /// <summary>
    /// Gets an array of matched values in the map corresponding to the supplied array of keys.
    /// </summary>
    /// <param name="key">The key of the map.</param>
    /// <param name="mapKeys">The keys of the entries of the map to return.</param>
    /// <returns>An array of matched values where each entry matches the array position of the corresponding key.</returns>
    TMapValue[] GetMapItems(TKey key, TMapKey[] mapKeys);

    bool DeleteMapItem(TKey key, TMapKey mapKey);

    bool ContainsMap(TKey key);
}
