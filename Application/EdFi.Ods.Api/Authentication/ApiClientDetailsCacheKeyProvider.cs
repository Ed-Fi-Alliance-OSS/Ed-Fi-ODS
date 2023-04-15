// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Authentication;

/// <summary>
/// Implements a cache key provider for caching API client details (for single-tenant deployments).
/// </summary>
public class ApiClientDetailsCacheKeyProvider : IApiClientDetailsCacheKeyProvider
{
    public const string CacheKeyPrefix = "ApiClientDetails.";
    
    private const string CacheKeyFormat = $"{CacheKeyPrefix}{{0}}";

    /// <inheritdoc cref="IApiClientDetailsCacheKeyProvider.GetCacheKey" />
    public string GetCacheKey(string token)
    {
        string cacheKey = string.Format(CacheKeyFormat, token);

        return cacheKey;
    }
}
