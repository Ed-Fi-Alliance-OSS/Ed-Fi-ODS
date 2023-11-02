// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Implements a marker cache key provider for the cache keyed by UniqueId values.
/// </summary>
public class UniqueIdCacheInitializationMarkerKeyProvider : ICacheInitializationMarkerKeyProvider<string>
{
    /// <inheritdoc cref="ICacheInitializationMarkerKeyProvider{TKey}.CacheKey" />
    public string CacheKey
    {
        get => CacheInitializationConstants.InitializationMarkerKeyForUniqueId;
    }
}
