// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Microsoft.Extensions.Caching.Distributed;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Implements asynchronous distributed cache access for descriptor cache entries.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AsyncExternalCacheProvider"/> class.
/// </remarks>
/// <param name="distributedCache">The distributed cache.</param>
/// <param name="slidingExpiration">The sliding expiration to apply to set operations.</param>
/// <param name="absoluteExpiration">The absolute expiration to apply to set operations.</param>
public class AsyncExternalCacheProvider(
    IDistributedCache distributedCache,
    TimeSpan slidingExpiration,
    TimeSpan absoluteExpiration) : AsyncExternalCacheProvider<ulong>(distributedCache, slidingExpiration, absoluteExpiration)
{
}
