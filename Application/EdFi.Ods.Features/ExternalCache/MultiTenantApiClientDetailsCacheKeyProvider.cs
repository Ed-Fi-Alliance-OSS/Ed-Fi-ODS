// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Implements a cache key provider for caching API client details in multi-tenant deployments, including the tenant
/// identifier in the key so that a token cached for one tenant is never returned for a request to another tenant.
/// </summary>
public class MultiTenantApiClientDetailsCacheKeyProvider : IApiClientDetailsCacheKeyProvider
{
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public MultiTenantApiClientDetailsCacheKeyProvider(IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <inheritdoc cref="IApiClientDetailsCacheKeyProvider.GetCacheKey" />
    public string GetCacheKey(string token)
    {
        var tenantIdentifier = _tenantConfigurationContextProvider.Get()?.TenantIdentifier;

        // Same exception as the in-process caching interceptor, so a request without a tenant fails authentication
        // and is logged at Debug instead of Error
        if (string.IsNullOrEmpty(tenantIdentifier))
        {
            throw new CachingInterceptorCacheKeyGenerationException(
                "Unable to build the API client details cache key because no tenant is available in the current context.");
        }

        return $"{ApiClientDetailsCacheKeyProvider.CacheKeyPrefix}{tenantIdentifier}.{ApiClientDetailsCacheKeyProvider.HashToken(token)}";
    }
}
