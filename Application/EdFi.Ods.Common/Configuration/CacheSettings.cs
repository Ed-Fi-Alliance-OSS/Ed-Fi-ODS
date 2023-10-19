// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace EdFi.Ods.Common.Configuration
{
    public class CacheSettings
    {
        public const string ProviderNameRedis = "Redis";
        private readonly List<string> _availableExternalProviders = new() { ProviderNameRedis };

        public string ExternalCacheProvider { get; set; } = string.Empty;
        public RedisCacheSettings Redis { get; set; }
        public DescriptorsCacheConfiguration Descriptors { get; set; } = new();
        public PersonUniqueIdToUsiCacheConfiguration PersonUniqueIdToUsi { get; set; } = new();
        public ApiClientDetailsConfiguration ApiClientDetails { get; set; } = new();
        public SecurityCacheConfiguration Security { get; set; } = new();
        public ProfilesCacheConfiguration Profiles { get; set; } = new();
        public OdsInstancesCacheConfiguration OdsInstances { get; set; } = new();

        public TenantsCacheConfiguration Tenants { get; set; } = new();

        /// <summary>
        /// Validates the `ExternalCacheProvider` setting when any of the "use
        /// cache" settings are true.
        /// </summary>
        /// <exception cref="InvalidConfigurationException" />
        public void Validate()
        {
            var usingExternalCache = Descriptors.UseExternalCache || PersonUniqueIdToUsi.UseExternalCache || ApiClientDetails.UseExternalCache;
            var externalProviderIsValid = _availableExternalProviders.Where(x => string.Equals(x, ExternalCacheProvider, StringComparison.OrdinalIgnoreCase)).Any();

            if (usingExternalCache & !externalProviderIsValid)
            {
                throw new ConfigurationErrorsException($"External caching has been enabled, but the specified cache provider \"{ExternalCacheProvider}\" is not valid.");
            }

            var cacheProviderIsRedis = string.Equals(ProviderNameRedis, ExternalCacheProvider, StringComparison.OrdinalIgnoreCase);
            var redisConfigNotProvider = string.IsNullOrWhiteSpace(Redis.Configuration);
            if (usingExternalCache && cacheProviderIsRedis && redisConfigNotProvider)
            {
                throw new ConfigurationErrorsException($"External caching has been enabled with Redis, but the Redis configuration string has not been provided.");
            }
        }

        public class DescriptorsCacheConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; } = 1800;
        }

        public class PersonUniqueIdToUsiCacheConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; } = 0; //Will be set to 0 during instantiation of PersonUniqueIdToUsiCache if SlidingExpirationSeconds > 0
            public int SlidingExpirationSeconds { get; set; } = 14400;

            public Dictionary<string, bool> CacheSuppression { get; set; } = new(StringComparer.OrdinalIgnoreCase);
        }

        public class ApiClientDetailsConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; } = (int)TimeSpan.FromMinutes(15).TotalSeconds;
        }

        public class SecurityCacheConfiguration
        {
            public int AbsoluteExpirationMinutes { get; set; } = 10;
        }

        public class RedisCacheSettings
        {
            public string Configuration { get; set; }
            public string Password { get; set; }

        }

        public class ProfilesCacheConfiguration
        {
            public int AbsoluteExpirationSeconds { get; set; } = 1800;
        }

        public class OdsInstancesCacheConfiguration
        {
            public int AbsoluteExpirationSeconds { get; set; } = 300;
        }

        public class TenantsCacheConfiguration
        {
            public int AbsoluteExpirationSeconds { get; set; } = 0; // No expiration by default (tenants are defined in static configuration)
        }
    }
}
