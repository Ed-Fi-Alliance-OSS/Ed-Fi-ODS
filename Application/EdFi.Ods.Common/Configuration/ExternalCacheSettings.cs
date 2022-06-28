// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public class ExternalCacheSettings
    {
        public ExternalCacheProviders CacheProvider { get; set; }
        public string Configuration { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public int DefaultExpirationSeconds { get; set; }
        public bool EnableForApiClientDetailsCache { get; set; }
        public bool EnableForAvailableChangeVersionCache { get; set; }
        public bool EnableForDescriptorsCache { get; set; }
        public bool EnablePersonUniqueIdToUsiCache { get; set; }
        public bool EnableForSecurityCache { get; set; }
    }

    public enum ExternalCacheProviders
    {
        NCache,
        Redis,
        SqlServer
    }
}