// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Caching;
#if NETSTANDARD
using EdFi.Ods.Api.Common.Configuration;
#elif NETFRAMEWORK
using EdFi.Ods.Common.Configuration;
#endif

namespace EdFi.Ods.Api.Common.Authentication
{
    /// <summary>
    /// Provides local caching behavior for OAuth token validation.
    /// </summary>
    public class CachingOAuthTokenValidatorDecorator : IOAuthTokenValidator
    {
        private const string CacheKeyFormat = "OAuthTokenValidator.ApiClientDetails.{0}";
#if NETFRAMEWORK
        private const string ConfigBearerTokenTimeoutMinutes = "BearerTokenTimeoutMinutes";
#endif

        // Lazy initialized fields
        private readonly Lazy<int> _bearerTokenTimeoutMinutes;
        private readonly ICacheProvider _cacheProvider;

        // Dependencies
        private readonly IOAuthTokenValidator _next;

#if NETFRAMEWORK
        /// <summary>
        /// Initializes a new instance of the <see cref="CachingOAuthTokenValidatorDecorator"/> class.
        /// </summary>
        /// <param name="next">The decorated implementation.</param>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="configValueProvider">The configuration value provider.</param>
        public CachingOAuthTokenValidatorDecorator(
            IOAuthTokenValidator next,
            ICacheProvider cacheProvider,
            IConfigValueProvider configValueProvider)
        {
            _next = next;
            _cacheProvider = cacheProvider;

            // Lazy initialization
            _bearerTokenTimeoutMinutes = new Lazy<int>(
                () =>
                    Convert.ToInt32(configValueProvider.GetValue(ConfigBearerTokenTimeoutMinutes) ?? "30"));
        }
#elif NETSTANDARD
        /// <summary>
        /// Initializes a new instance of the <see cref="CachingOAuthTokenValidatorDecorator"/> class.
        /// </summary>
        /// <param name="next">The decorated implementation.</param>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="apiSettings"></param>
        public CachingOAuthTokenValidatorDecorator(
            IOAuthTokenValidator next,
            ICacheProvider cacheProvider,
            ApiSettings apiSettings)
        {
            _next = next;
            _cacheProvider = cacheProvider;

            // Lazy initialization
            _bearerTokenTimeoutMinutes = new Lazy<int>(
                () => apiSettings.BearerTokenTimeoutMinutes ?? 30);
        }
#endif
        /// <summary>
        /// Checks the cache for an existing value, and if not found, calls through to decorated implementation to retrieve the details (which is then cached).
        /// </summary>
        /// <param name="token">The OAuth security token.</param>
        /// <returns>The <see cref="ApiClientDetails"/> associated with the token.</returns>
        public async Task<ApiClientDetails> GetClientDetailsForTokenAsync(string token)
        {
            string cacheKey = string.Format(CacheKeyFormat, token);

            // Try to load API client details from cache
            if (_cacheProvider.TryGetCachedObject(cacheKey, out object apiClientDetailsAsObject))
            {
                return (ApiClientDetails) apiClientDetailsAsObject;
            }

            // Pass call through to implementation
            var apiClientDetails = await _next.GetClientDetailsForTokenAsync(token);

            // If token is valid, insert API client details into the cache for **half** the duration of the externally managed expiration period
            if (apiClientDetails.IsTokenValid)
            {
                _cacheProvider.Insert(cacheKey, apiClientDetails, DateTime.Now.AddMinutes(_bearerTokenTimeoutMinutes.Value / 2.0), TimeSpan.Zero);
            }

            return apiClientDetails;
        }
    }
}
