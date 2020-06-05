// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Common.Caching;

namespace EdFi.Ods.Api.Caching
{
    public static class CacheProviderExtensions
    {
        public static bool TryGetCachedObject<T>(this ICacheProvider cacheProvider, string key, out T value)
        {
            object objectValue;

            if (cacheProvider.TryGetCachedObject(key, out objectValue) && objectValue is T)
            {
                //object was found in the cacheProvider and was of the type T. return the cached value and true
                value = (T) objectValue;
                return true;
            }

            // the cacheProvider was not able to Get the cached object or the object returned was not of the type T then return false with the default value for the type T
            value = default(T);
            return false;
        }
    }
}
