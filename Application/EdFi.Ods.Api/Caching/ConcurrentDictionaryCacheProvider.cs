// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.Caching
{
    [Serializable]
    public class ConcurrentDictionaryCacheProvider<TKey> : ICacheProvider<TKey>
    {
        private readonly IDictionary<TKey, object> _cacheDictionary = new ConcurrentDictionary<TKey, object>();

        public bool TryGetCachedObject(TKey key, out object value)
        {
            return _cacheDictionary.TryGetValue(key, out value);
        }

        public void SetCachedObject(TKey key, object obj)
        {
            _cacheDictionary[key] = obj;
        }

        public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cacheDictionary[key] = value;
        }
    }
}
