// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Defines a method for obtaining the cache entry key for denoting the initiation of the background cache initialization.
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface ICacheInitializationMarkerKeyProvider<out TKey>
{
    /// <summary>
    /// Gets the cache entry key for denoting the initiation of the background cache initialization.
    /// </summary>
    /// <returns>The cache key.</returns>
    TKey CacheKey { get; }
}
