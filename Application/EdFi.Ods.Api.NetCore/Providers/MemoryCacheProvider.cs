// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Common.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public class MemoryCacheProvider : ICacheProvider
    {
        private static readonly object _nullObject = new object();
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool TryGetCachedObject(string key, out object value) => _memoryCache.TryGetValue(key, out value);

        public void SetCachedObject(string keyName, object obj)
            => _memoryCache.Set(
                keyName,
                obj ?? _nullObject,
                new MemoryCacheEntryOptions {AbsoluteExpiration = DateTimeOffset.MaxValue});

        public void Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
            => _memoryCache.Set(
                key,
                value,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = absoluteExpiration == DateTime.MaxValue
                        ? DateTimeOffset.MaxValue
                        : absoluteExpiration,
                    SlidingExpiration = slidingExpiration == TimeSpan.Zero ? (TimeSpan?) null : slidingExpiration
                });
    }
}
