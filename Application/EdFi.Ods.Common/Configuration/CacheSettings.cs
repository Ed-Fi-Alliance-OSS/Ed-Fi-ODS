// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public class CacheSettings
    {
        public string ExternalCacheProvider { get; set; }
        public RedisCacheSettings Redis { get; set; }
        public SqlServerCacheSettings SQLServer { get; set; }
        public DescriptorsCacheConfiguration Descriptors { get; set; } = new DescriptorsCacheConfiguration();
        public PersonUniqueIdToUsiCacheConfiguration PersonUniqueIdToUsi { get; set; } = new PersonUniqueIdToUsiCacheConfiguration();
        public ApiClientDetailsConfiguration ApiClientDetails { get; set; } = new ApiClientDetailsConfiguration();
        public SecurityCacheConfiguration Security { get; set; } = new SecurityCacheConfiguration();

        public class DescriptorsCacheConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; }
        }

        public class PersonUniqueIdToUsiCacheConfiguration
        {
            public bool UseExternalCache { get; set; }
            public int AbsoluteExpirationSeconds { get; set; }
            public int SlidingExpirationSeconds { get; set; }
            public bool SuppressStudentCache { get; set; }
            public bool SuppressStaffCache { get; set; }
            public bool SuppressParentCache { get; set; }
        }

        public class ApiClientDetailsConfiguration
        {
            public bool UseExternalCache { get; set; }
        }

        public class SecurityCacheConfiguration
        {
            public int AbsoluteExpirationMinutes { get; set; }
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