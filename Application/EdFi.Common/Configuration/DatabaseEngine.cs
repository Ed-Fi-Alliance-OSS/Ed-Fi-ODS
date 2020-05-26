// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
namespace EdFi.Ods.Common.Configuration
{
    public class DatabaseEngine : Enumeration<DatabaseEngine, string>
    {
        public static readonly DatabaseEngine SqlServer = new DatabaseEngine(ApiConfigurationConstants.SqlServerProviderName, "SQL Server");
        public static readonly DatabaseEngine Postgres = new DatabaseEngine(ApiConfigurationConstants.PostgresProviderName, "PostgreSQL" );

        public DatabaseEngine(string value, string displayName)
            : base(value, displayName) { }

        public string ResolvedFolderName()
            => Value.Equals(ApiConfigurationConstants.SqlServerProviderName)
                ? "MsSql"
                : "PgSql";
    }
}
