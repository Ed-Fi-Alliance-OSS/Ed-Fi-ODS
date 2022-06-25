// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public class ApiCacheSettings
    {
        public CacheProviders CacheProvider { get; set; }
        public string Configuration { get; set; }
        public bool EnableForApiClientDetailsCache { get; set; }
        public bool EnableForAvailableChangeVersionCache { get; set; }
        public bool EnableForDescriptorsCache { get; set; }
        public bool EnablePersonUniqueIdToUsiCache { get; set; }
        public bool EnableForSecurityCache { get; set; }
    }

    public enum CacheProviders
    {
        Default,
        Redis
    }
}