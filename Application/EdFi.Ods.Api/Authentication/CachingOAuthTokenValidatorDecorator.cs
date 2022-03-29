// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Api.Authentication
{
    /// <summary>
    /// Provides local caching behavior for OAuth token validation.
    /// </summary>
    public class CachingOAuthTokenValidatorDecorator : IOAuthTokenValidator
    {
        private const string CacheKeyFormat = "OAuthTokenValidator.ApiClientDetails.{0}";

        private readonly ApiSettings _apiSettings;
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;

        // Lazy initialized fields
        private readonly Lazy<int> _bearerTokenTimeoutMinutes;
        private readonly ICacheProvider _cacheProvider;

        // Dependencies
        private readonly IOAuthTokenValidator _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingOAuthTokenValidatorDecorator"/> class.
        /// </summary>
        /// <param name="next">The decorated implementation.</param>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="configuration"></param>
        /// <param name="apiSettings"></param>
        /// <param name="instanceIdContextProvider"></param>
        public CachingOAuthTokenValidatorDecorator(
            IOAuthTokenValidator next,
            ICacheProvider cacheProvider,
            IConfigurationRoot configuration,
            ApiSettings apiSettings,
            IInstanceIdContextProvider instanceIdContextProvider = null)
        {
            _apiSettings = apiSettings;
            _instanceIdContextProvider = instanceIdContextProvider;

            _next = next;
            _cacheProvider = cacheProvider;

            // Lazy initialization
            _bearerTokenTimeoutMinutes = new Lazy<int>(
                () => int.TryParse(configuration.GetSection("BearerTokenTimeoutMinutes").Value, out int bearerTokenTimeoutMinutes)
                    ? bearerTokenTimeoutMinutes
                    : 30);
        }

        /// <summary>
        /// Checks the cache for an existing value, and if not found, calls through to decorated implementation to retrieve the details (which is then cached).
        /// </summary>
        /// <param name="token">The OAuth security token.</param>
        /// <returns>The <see cref="ApiClientDetails"/> associated with the token.</returns>
        public async Task<ApiClientDetails> GetClientDetailsForTokenAsync(string token)
        {
            string cacheKey;

            if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
            {
                const string InstanceCacheKeyFormat = "OAuthTokenValidator.ApiClientDetails.{0}.{1}";
                var instanceId = _instanceIdContextProvider.GetInstanceId();

                if (string.IsNullOrEmpty(instanceId))
                {
                    throw new InvalidOperationException("Expected instanceId is null or empty.");
                }

                cacheKey = string.Format(InstanceCacheKeyFormat, instanceId, token);
            }
            else
            {
                cacheKey = string.Format(CacheKeyFormat, token);
            }

            // Try to load API client details from cache
            if (_cacheProvider.TryGetCachedObject(cacheKey, out object apiClientDetailsAsObject))
            {
                var apiClientDetailsFromCache = (ApiClientDetails) apiClientDetailsAsObject;

                if (apiClientDetailsFromCache.IsTokenValid)
                {
                    return apiClientDetailsFromCache;
                }

                return null;
            }

            // No entry present, so pass call through to implementation
            var apiClientDetails = await _next.GetClientDetailsForTokenAsync(token);

            // If token is valid, insert API client details into the cache for **half** the duration of the externally managed expiration period
            if (apiClientDetails.IsTokenValid)
            {
                _cacheProvider.Insert(
                    cacheKey, apiClientDetails, apiClientDetails.ExpiresUtc, TimeSpan.Zero);
            }

            return apiClientDetails;
        }
    }
}