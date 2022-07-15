// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Features.Redis
{
    public interface IRedisCacheProvider : ICacheProvider
    {
        bool TryGetCachedObjectFromHash<T>(string key, string hashField, out T value);

        void InsertToHash(string key, string hashField, object value);

        void Insert<T>(
            string key,
            IDictionary<string, T> dictionary,
            DateTime absoluteExpiration,
            TimeSpan slidingExpiration);

        bool KeyExists(string key);

        bool TryGetCachedObject<T>(string key, out T value, int db = 0);

        void Insert(
            string key,
            object value,
            DateTime absoluteExpiration,
            TimeSpan slidingExpiration,
            int db = 0);
    }
}
