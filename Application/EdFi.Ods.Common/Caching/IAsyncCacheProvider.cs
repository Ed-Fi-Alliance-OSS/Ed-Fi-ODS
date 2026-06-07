// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Defines asynchronous cache operations.
/// </summary>
/// <typeparam name="TKey">The type of cache key.</typeparam>
public interface IAsyncCacheProvider<in TKey>
{
    /// <summary>
    /// Attempts to retrieve a cached object asynchronously.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <returns>A tuple indicating whether a value was found and the cached value.</returns>
    Task<(bool found, object value)> TryGetCachedObjectAsync(TKey key);

    /// <summary>
    /// Stores an object in the cache asynchronously.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="obj">The object to cache.</param>
    Task SetCachedObjectAsync(TKey key, object obj);

    /// <summary>
    /// Inserts an object in the cache asynchronously using the supplied expiration settings.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="value">The value to cache.</param>
    /// <param name="absoluteExpiration">The absolute expiration.</param>
    /// <param name="slidingExpiration">The sliding expiration.</param>
    Task InsertAsync(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration);
}
