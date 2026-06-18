// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Configuration
{
    public class CacheSettings
    {
        public string ExternalCacheProvider { get; set; } = string.Empty;

        internal ExternalCacheProviderOption ExternalCacheProviderOption
        {
            get => Enum.TryParse<ExternalCacheProviderOption>(ExternalCacheProvider, ignoreCase: true, out var parsed)
                ? parsed : default;
        }

        public DescriptorsCacheConfiguration Descriptors { get; set; } = new();
        public PersonUniqueIdToUsiCacheConfiguration PersonUniqueIdToUsi { get; set; } = new();
        public ApiClientDetailsConfiguration ApiClientDetails { get; set; } = new();
        public SecurityCacheConfiguration Security { get; set; } = new();
        public ProfilesCacheConfiguration Profiles { get; set; } = new();
        public OdsInstancesCacheConfiguration OdsInstances { get; set; } = new();

        public class DescriptorsCacheConfiguration
        {
            public bool UseExternalCache { get; set; }

            /// <summary>
            /// When external cache is enabled, selects whether the L2 external cache is used directly
            /// (<see cref="CachingMode.External"/>) or fronted by an in-process L1 cache
            /// (<see cref="CachingMode.Hybrid"/>). Defaults to Hybrid to preserve historical behavior.
            /// </summary>
            public CachingMode CachingMode { get; set; } = CachingMode.Hybrid;

            public int AbsoluteExpirationSeconds { get; set; } = 1800;
            public int L1CacheDurationSeconds { get; set; } = 10;
        }

        public class PersonUniqueIdToUsiCacheConfiguration
        {
            public bool UseExternalCache { get; set; }

            /// <summary>
            /// When external cache is enabled, selects whether the L2 external (Redis) map cache is used
            /// directly (<see cref="CachingMode.External"/>) or fronted by an in-process L1 map cache
            /// (<see cref="CachingMode.Hybrid"/>). Defaults to External to preserve historical behavior.
            /// </summary>
            public CachingMode CachingMode { get; set; } = CachingMode.External;

            public int AbsoluteExpirationSeconds { get; set; } = 0; //Will be set to 0 during instantiation of PersonUniqueIdToUsiCache if SlidingExpirationSeconds > 0
            public int SlidingExpirationSeconds { get; set; } = (int) TimeSpan.FromHours(4).TotalSeconds;

            /// <summary>
            /// The L1 (in-process) cache duration, in seconds, used only when <see cref="CachingMode"/> is Hybrid.
            /// </summary>
            public int L1CacheDurationSeconds { get; set; } = 60;

            public bool UseProgressiveLoading { get; set; } = false;

            public Dictionary<string, bool> CacheSuppression { get; set; } = new(StringComparer.OrdinalIgnoreCase);

            public int BatchSize { get; set; } = 5000;
        }

        public class ApiClientDetailsConfiguration
        {
            public bool UseExternalCache { get; set; }

            /// <summary>
            /// When external cache is enabled, selects whether the L2 external cache is used directly
            /// (<see cref="CachingMode.External"/>) or fronted by an in-process L1 cache
            /// (<see cref="CachingMode.Hybrid"/>). Defaults to Hybrid to preserve historical behavior.
            /// </summary>
            public CachingMode CachingMode { get; set; } = CachingMode.Hybrid;

            public int AbsoluteExpirationSeconds { get; set; } = (int)TimeSpan.FromMinutes(15).TotalSeconds;
            public int L1CacheDurationSeconds { get; set; } = 30;
        }

        public class SecurityCacheConfiguration
        {
            public int AbsoluteExpirationMinutes { get; set; } = 10;
        }

        public class ProfilesCacheConfiguration
        {
            public int AbsoluteExpirationSeconds { get; set; } = 1800;
        }

        public class OdsInstancesCacheConfiguration
        {
            public int AbsoluteExpirationSeconds { get; set; } = 300;
        }
    }

    public enum ExternalCacheProviderOption
    {
        Redis = 1,
    }

    /// <summary>
    /// Selects how a cache type uses the external cache when external caching is enabled.
    /// </summary>
    public enum CachingMode
    {
        /// <summary>
        /// Use the external (L2) cache directly, with no in-process L1 tier.
        /// </summary>
        External,

        /// <summary>
        /// Front the external (L2) cache with a short-lived in-process L1 cache.
        /// </summary>
        Hybrid,
    }
}
