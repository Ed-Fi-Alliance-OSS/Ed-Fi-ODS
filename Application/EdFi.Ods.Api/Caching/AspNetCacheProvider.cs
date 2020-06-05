// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using EdFi.Ods.Api.Common.Caching;

namespace EdFi.Ods.Api.Caching
{
    public class AspNetCacheProvider : ICacheProvider
    {
        private static readonly object NullObject = new object();

        public bool TryGetCachedObject(string key, out object value)
        {
            value = HttpRuntime.Cache[key];

            if (value == NullObject)
            {
                value = null;
                return true;
            }

            return value != null;
        }

        public void SetCachedObject(string keyName, object value)
        {
            HttpRuntime.Cache[keyName] = value ?? NullObject;
        }

        public void Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(key, value ?? NullObject, null, absoluteExpiration, slidingExpiration);
        }
    }
}
