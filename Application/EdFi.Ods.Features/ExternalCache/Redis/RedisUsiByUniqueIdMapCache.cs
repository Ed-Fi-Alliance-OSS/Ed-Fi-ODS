// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Features.Services.Redis;
using StackExchange.Redis;

namespace EdFi.Ods.Features.ExternalCache.Redis;

public class RedisUsiByUniqueIdMapCache : RedisPersonIdentifierMapCache<string, int>
{
    public RedisUsiByUniqueIdMapCache(
        IRedisConnectionProvider redisConnectionProvider,
        RedisCacheResilience resilience,
        TimeSpan? absoluteExpirationPeriod,
        TimeSpan? slidingExpirationPeriod,
        int batchSize)
        : base(redisConnectionProvider, resilience, absoluteExpirationPeriod, slidingExpirationPeriod, batchSize) { }

    protected override RedisValue ConvertMapKeyToRedisValue(string mapKey) => mapKey;

    protected override RedisValue ConvertMapValueToRedisValue(int mapValue) => mapValue;

    protected override int ConvertRedisValue(RedisValue hashValue) => (int)hashValue;

    protected override void ValidateMapKey(string mapKey) => ArgumentNullException.ThrowIfNull(mapKey, nameof(mapKey));
}
