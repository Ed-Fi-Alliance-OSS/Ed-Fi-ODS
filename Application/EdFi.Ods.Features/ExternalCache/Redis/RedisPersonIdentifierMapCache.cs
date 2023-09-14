// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Ods.Api.Caching;
using StackExchange.Redis;

namespace EdFi.Ods.Features.ExternalCache.Redis;

/// <summary>
/// Provides a base class for person UniqueId/USI caching in Redis that optimizes the string allocations by storing the
/// cache key string representations in a dictionary, and avoids boxing while validating the cache key. 
/// </summary>
/// <typeparam name="TMapKey">The type of the hash's key.</typeparam>
/// <typeparam name="TMapValue">The type of the hash's value.</typeparam>
public abstract class RedisPersonIdentifierMapCache<TMapKey, TMapValue>
    : RedisMapCache<(ulong odsInstanceHashId, string personType, PersonMapType personMapType), TMapKey, TMapValue>
{
    private readonly ConcurrentDictionary<(ulong odsInstanceHashId, string personType, PersonMapType personMapType), string>
        _cacheKeyAsStringByKey = new();

    protected RedisPersonIdentifierMapCache(string configuration)
        : base(configuration) { }

    protected override void ValidateKey((ulong odsInstanceHashId, string personType, PersonMapType personMapType) key)
    {
        if (key == default)
        {
            throw new ArgumentException($"{nameof(key)} is required.", nameof(key));
        }
    }

    protected override string GetCacheKey((ulong odsInstanceHashId, string personType, PersonMapType personMapType) key)
        => _cacheKeyAsStringByKey.GetOrAdd(key, key1 => key1.ToString());
}
