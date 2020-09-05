// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Configuration
{
    public class DatabaseEngine : Enumeration<DatabaseEngine, string>
    {
        public static readonly DatabaseEngine SqlServer = new DatabaseEngine(ApiConfigurationConstants.SqlServer, "SQL Server", "MsSql");
        public static readonly DatabaseEngine Postgres = new DatabaseEngine(ApiConfigurationConstants.PostgreSQL, "PostgreSQL", "PgSql");

        public DatabaseEngine(string value, string displayName, string scriptsFolderName)
            : base(value, displayName)
        {
            ScriptsFolderName = scriptsFolderName;
        }

        public string ScriptsFolderName { get; private set; }

        public static DatabaseEngine CreateFromProviderName(string databaseProviderName)
        {
            if (databaseProviderName.EqualsIgnoreCase(ApiConfigurationConstants.SqlServerProviderName))
            {
                return SqlServer;
            }

            if (databaseProviderName.EqualsIgnoreCase(ApiConfigurationConstants.PostgresProviderName))
            {
                return Postgres;
            }

            throw new ArgumentException(
                $"{databaseProviderName} is an unsupported database provider", nameof(databaseProviderName));
        }
    }
}
#endif
