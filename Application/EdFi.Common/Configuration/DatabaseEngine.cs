// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Extensions;

namespace EdFi.Common.Configuration
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

        public static DatabaseEngine TryParseEngine(string value)
        {
            if (TryParse(x => x.Value.EqualsIgnoreCase(value), out DatabaseEngine engine))
            {
                return engine;
            }

            throw new NotSupportedException(
                $"Not supported DatabaseEngine \"{value}\". Supported engines: {ApiConfigurationConstants.SqlServer}, and {ApiConfigurationConstants.PostgreSQL}.");
        }
    }
}
