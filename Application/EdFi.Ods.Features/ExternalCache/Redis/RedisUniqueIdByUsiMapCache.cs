// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Features.Services.Redis;
using StackExchange.Redis;

namespace EdFi.Ods.Features.ExternalCache.Redis;

public class RedisUniqueIdByUsiMapCache : RedisPersonIdentifierMapCache<int, string>
{
    public RedisUniqueIdByUsiMapCache(IRedisConnectionProvider redisConnectionProvider, TimeSpan? absoluteExpirationPeriod, TimeSpan? slidingExpirationPeriod)
        : base(redisConnectionProvider, absoluteExpirationPeriod, slidingExpirationPeriod) { }

    protected override string ConvertRedisValue(RedisValue hashValue) => hashValue;

    protected override void ValidateMapKey(int mapKey)
    {
        if (mapKey == default)
        {
            throw new ArgumentException($"{nameof(mapKey)} is required.", nameof(mapKey));
        }
    }
}
