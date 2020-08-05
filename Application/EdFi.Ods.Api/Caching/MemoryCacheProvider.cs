// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Caching;

namespace EdFi.Ods.Api.Caching
{
    public class MemoryCacheProvider : ICacheProvider
    {
        private static readonly object NullObject = new object();
        private static readonly CacheItemPolicy NeverExpireCacheItemPolicy = new CacheItemPolicy
                                                                             {
                                                                                 AbsoluteExpiration = DateTimeOffset.MaxValue
                                                                             };

        public MemoryCache MemoryCache { get; set; } = MemoryCache.Default;

        public bool TryGetCachedObject(string key, out object value)
        {
            value = MemoryCache.Get(key);

            if (value == NullObject)
            {
                value = null;
                return true;
            }

            return value != null;
        }

        public void SetCachedObject(string key, object value)
        {
            MemoryCache.Set(key, value ?? NullObject, NeverExpireCacheItemPolicy);
        }

        public void Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            MemoryCache.Set(
                key,
                value ?? NullObject,
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
