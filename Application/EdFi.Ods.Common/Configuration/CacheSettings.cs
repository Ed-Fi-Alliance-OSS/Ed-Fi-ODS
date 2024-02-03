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
                ? parsed : ExternalCacheProviderOption.Undetermined;
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
            public int AbsoluteExpirationSeconds { get; set; } = 1800;
        }

        public class PersonUniqueIdToUsiCacheConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; } = 0; //Will be set to 0 during instantiation of PersonUniqueIdToUsiCache if SlidingExpirationSeconds > 0
            public int SlidingExpirationSeconds { get; set; } = (int) TimeSpan.FromHours(4).TotalSeconds;

            public bool UseProgressiveLoading { get; set; } = false;

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
        Undetermined,
        Redis,
    }
}
