// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.Authentication
{
    /// <summary>
    /// Caches the API client details associated with a particular API client's bearer token.
    /// </summary>
    public class CachingApiClientDetailsProviderDecorator : IApiClientDetailsProvider
    {
        // Dependencies
        private readonly ICacheProvider _cacheProvider;
        private readonly IApiClientDetailsCacheKeyProvider _apiClientDetailsCacheKeyProvider;
        private readonly IApiClientDetailsProvider _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingApiClientDetailsProviderDecorator"/> class.
        /// </summary>
        /// <param name="next">The decorated implementation.</param>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="apiClientDetailsCacheKeyProvider">The cache key provider.</param>
        public CachingApiClientDetailsProviderDecorator(
            IApiClientDetailsProvider next,
            ICacheProvider cacheProvider,
            IApiClientDetailsCacheKeyProvider apiClientDetailsCacheKeyProvider)
        {
            _next = next;
            _cacheProvider = cacheProvider;
            _apiClientDetailsCacheKeyProvider = apiClientDetailsCacheKeyProvider;
        }

        /// <summary>
        /// Checks the cache for an existing value, and if not found, calls through to decorated implementation to retrieve the details (which is then cached).
        /// </summary>
        /// <param name="token">The OAuth security token.</param>
        /// <returns>The <see cref="ApiClientDetails"/> associated with the token.</returns>
        public async Task<ApiClientDetails> GetClientDetailsForTokenAsync(string token)
        {
            string cacheKey = _apiClientDetailsCacheKeyProvider.GetCacheKey(token);

            // Try to load API client details from cache
            if (_cacheProvider.TryGetCachedObject(cacheKey, out object apiClientDetailsAsObject))
            {
                return (ApiClientDetails) apiClientDetailsAsObject;
            }

            // No entry present, so pass call through to implementation to get the API client details
            var apiClientDetails = await _next.GetClientDetailsForTokenAsync(token);

            // Insert API client details returned into the cache, for at least 15 minutes to avoid unnecessary roundtrips to underlying store
            var absoluteExpiration = apiClientDetails.ExpiresUtc < DateTime.UtcNow
                ? DateTime.UtcNow.AddMinutes(15)
                : apiClientDetails.ExpiresUtc.AddMinutes(15);
            
            _cacheProvider.Insert(cacheKey, apiClientDetails, absoluteExpiration, TimeSpan.Zero);

            return apiClientDetails;
        }
    }
}