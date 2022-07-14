// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public class CacheSettings
    {
        public CacheConfiguration Configuration { get; set; } = new CacheConfiguration();
        public ExternalCacheSettings ExternalCaching { get; set; } = new ExternalCacheSettings();

        public class CacheConfiguration
        {
            public DescriptorsCacheConfiguration Descriptors { get; set; } = new DescriptorsCacheConfiguration();
            public PersonUniqueIdToUsiCacheConfiguration PersonUniqueIdToUsi { get; set; } = new PersonUniqueIdToUsiCacheConfiguration();
            public SecurityCacheConfiguration Security { get; set; } = new SecurityCacheConfiguration();

            public class DescriptorsCacheConfiguration
            {
                public int AbsoluteExpirationSeconds { get; set; }
            }

            public class PersonUniqueIdToUsiCacheConfiguration
            {
                public int AbsoluteExpirationSeconds { get; set; }
                public int SlidingExpirationSeconds { get; set; }
                public bool SuppressStudentCache { get; set; }
                public bool SuppressStaffCache { get; set; }
                public bool SuppressParentCache { get; set; }
            }

            public class SecurityCacheConfiguration
            {
                public int AbsoluteExpirationMinutes { get; set; }
            }
        }

        public class ExternalCacheSettings
        {
            public bool EnableExternalCache { get; set; }
            public string ExternalCacheProvider { get; set; }
            public bool UseExternalCacheForApiClientDetailsCache { get; set; }
            public bool UseExternalCacheForDescriptorsCache { get; set; }
            public bool UseExternalCachePersonUniqueIdToUsiCache { get; set; }
            public RedisCacheSettings Redis { get; set; }
            public SqlServerCacheSettings SQLServer { get; set; }
        }

        public class RedisCacheSettings
        {
            public string Configuration { get; set; }
            public string Password { get; set; }

        }
        public class SqlServerCacheSettings
        {
            public string ConnectionString { get; set; }
            public string SchemaName { get; set; }
            public string TableName { get; set; }
        }
    }    
}