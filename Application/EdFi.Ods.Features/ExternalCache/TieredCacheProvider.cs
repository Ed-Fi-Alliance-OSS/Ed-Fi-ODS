// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Provides a short-lived in-process cache in front of the distributed descriptor cache.
/// </summary>
public class TieredCacheProvider : TieredCacheProvider<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TieredCacheProvider"/> class.
    /// </summary>
    /// <param name="memoryCache">The in-process L1 cache.</param>
    /// <param name="distributedCache">The distributed cache.</param>
    /// <param name="l1CacheDuration">The duration for L1 cache entries.</param>
    /// <param name="slidingExpiration">The sliding expiration to apply to L2 set operations.</param>
    /// <param name="absoluteExpiration">The absolute expiration to apply to L2 set operations.</param>
    public TieredCacheProvider(
        IMemoryCache memoryCache,
        IDistributedCache distributedCache,
        TimeSpan l1CacheDuration,
        TimeSpan slidingExpiration,
        TimeSpan absoluteExpiration)
        : base(
            memoryCache,
            new ExternalCacheProvider<ulong>(distributedCache, slidingExpiration, absoluteExpiration),
            l1CacheDuration,
            new AsyncExternalCacheProvider<ulong>(distributedCache, slidingExpiration, absoluteExpiration))
    {
    }
}
