// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Features.ExternalCache.Redis;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace EdFi.Ods.Features.UnitTests.PersonMapCache;

public static class MapCacheTestHelper
{
    private const string RedisConfiguration = "localhost:6379";
    private static bool? _isRedisAvailable;
    
    public static IEnumerable<IMapCache<(ulong, string, PersonMapType), string, int>> GetUsiByUniqueIdMapCaches(
        int absoluteExpirationMs, 
        int slidingExpirationMs)
    {
        yield return new InMemoryMapCache<(ulong, string, PersonMapType), string, int>(
            new MemoryCache(new MemoryCacheOptions()),
            absoluteExpirationPeriod: TimeSpan.FromMilliseconds(absoluteExpirationMs),
            slidingExpirationPeriod: TimeSpan.FromMilliseconds(slidingExpirationMs));

        if (IsRedisAvailable())
        {
            yield return new RedisUsiByUniqueIdMapCache(
                RedisConfiguration,
                absoluteExpirationPeriod: TimeSpan.FromMilliseconds(absoluteExpirationMs),
                slidingExpirationPeriod: TimeSpan.FromMilliseconds(slidingExpirationMs));
        }
    }

    public static IEnumerable<IMapCache<(ulong, string, PersonMapType), int, string>> GetUniqueIdByUsiMapCaches(
        int absoluteExpirationMs, 
        int slidingExpirationMs)
    {
        yield return new InMemoryMapCache<(ulong, string, PersonMapType), int, string>(
            new MemoryCache(new MemoryCacheOptions()),
            absoluteExpirationPeriod: TimeSpan.FromMilliseconds(absoluteExpirationMs),
            slidingExpirationPeriod: TimeSpan.FromMilliseconds(slidingExpirationMs));

        if (IsRedisAvailable())
        {
            yield return new RedisUniqueIdByUsiMapCache(
                RedisConfiguration,
                absoluteExpirationPeriod: TimeSpan.FromMilliseconds(absoluteExpirationMs),
                slidingExpirationPeriod: TimeSpan.FromMilliseconds(slidingExpirationMs));
        }
    }

    private static bool IsRedisAvailable()
    {
        if (_isRedisAvailable == null)
        {
            try
            {
                using var connection = ConnectionMultiplexer.ConnectAsync(RedisConfiguration)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                _isRedisAvailable = connection.IsConnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WARNING: Redis connection failed. Skipping tests: {ex}");
                _isRedisAvailable = false;
            }
        }

        return _isRedisAvailable.Value;
    }
}
