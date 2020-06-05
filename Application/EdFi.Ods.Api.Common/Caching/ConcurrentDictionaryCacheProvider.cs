// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Common.Caching
{
    [Serializable]
    public class ConcurrentDictionaryCacheProvider : ICacheProvider
    {
        private readonly IDictionary<string, object> _cacheDictionary = new ConcurrentDictionary<string, object>();

        public bool TryGetCachedObject(string key, out object value)
        {
            return _cacheDictionary.TryGetValue(key, out value);
        }

        public void SetCachedObject(string keyName, object obj)
        {
            _cacheDictionary[keyName] = obj;
        }

        public void Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cacheDictionary[key] = value;
        }
    }
}
