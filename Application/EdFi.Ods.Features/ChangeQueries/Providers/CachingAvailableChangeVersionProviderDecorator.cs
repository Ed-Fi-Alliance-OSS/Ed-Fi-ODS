// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Features.ChangeQueries.Providers
{
    public class CachingAvailableChangeVersionProviderDecorator : IAvailableChangeVersionProvider
    {
        private const string AvailableChangeVersionCacheKey = "AvailableChangeVersion";
        private readonly ICacheProvider _availableChangeVersionCache;
        private readonly IAvailableChangeVersionProvider _availableChangeVersionProvider;
        private readonly object _cacheLock = new object();

        public CachingAvailableChangeVersionProviderDecorator(
            IAvailableChangeVersionProvider availableChangeVersionProvider,
            ICacheProvider availableChangeVersionCache)
        {
            _availableChangeVersionProvider = availableChangeVersionProvider;
            _availableChangeVersionCache = availableChangeVersionCache;
        }

        public AvailableChangeVersion GetAvailableChangeVersion()
        {
            object availableChangeEvents;

            _availableChangeVersionCache.TryGetCachedObject(AvailableChangeVersionCacheKey, out availableChangeEvents);

            if (availableChangeEvents != null)
            {
                return (AvailableChangeVersion) availableChangeEvents;
            }

            lock (_cacheLock)
            {
                // in the case that another thread has inserted data we should return with that list
                _availableChangeVersionCache.TryGetCachedObject(AvailableChangeVersionCacheKey, out availableChangeEvents);

                if (availableChangeEvents != null)
                {
                    return (AvailableChangeVersion) availableChangeEvents;
                }

                availableChangeEvents = _availableChangeVersionProvider.GetAvailableChangeVersion();
                _availableChangeVersionCache.SetCachedObject(AvailableChangeVersionCacheKey, availableChangeEvents);
            }

            return (AvailableChangeVersion) availableChangeEvents;
        }
    }
}
