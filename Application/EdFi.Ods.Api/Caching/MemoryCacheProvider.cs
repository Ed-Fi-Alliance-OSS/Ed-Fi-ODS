// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Runtime.Caching;
using EdFi.Ods.Api.Common.Caching;

namespace EdFi.Ods.Api.Caching
{
    public class MemoryCacheProvider : ICacheProvider
    {
        private static readonly object _nullObject = new object();
        private static readonly CacheItemPolicy _neverExpireCacheItemPolicy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.MaxValue
        };

        public MemoryCache MemoryCache { get; set; } = MemoryCache.Default;

        public bool TryGetCachedObject(string key, out object value)
        {
            value = MemoryCache.Get(key);

            if (value == _nullObject)
            {
                value = null;
                return true;
            }

            return value != null;
        }

        public void SetCachedObject(string key, object value)
        {
            MemoryCache.Set(key, value ?? _nullObject, _neverExpireCacheItemPolicy);
        }

        public void Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            MemoryCache.Set(
                key,
                value ?? _nullObject,
                new CacheItemPolicy
                {
                    AbsoluteExpiration = absoluteExpiration == DateTime.MaxValue
                        ? DateTimeOffset.MaxValue
                        : absoluteExpiration,
                    SlidingExpiration = slidingExpiration
                });
        }
    }
}
