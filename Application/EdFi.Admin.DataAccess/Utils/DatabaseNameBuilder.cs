// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Common.Extensions;

namespace EdFi.Admin.DataAccess.Utils
{
    public class DatabaseNameBuilder : IDatabaseNameBuilder
    {
        private const string TemplatePrefix = "Ods_";
        private const string SandboxPrefix = TemplatePrefix + "Sandbox_";

        private const string TemplateEmptyDatabase = TemplatePrefix + "Empty_Template";
        private const string TemplateMinimalDatabase = TemplatePrefix + "Minimal_Template";
        private const string TemplateSampleDatabase = TemplatePrefix + "Populated_Template";

        private readonly Lazy<string> _databaseNameTemplate;

        public DatabaseNameBuilder(IConfigConnectionStringsProvider connectionStringsProvider, IDbConnectionStringBuilderAdapterFactory connectionStringBuilderFactory)
        {
            _databaseNameTemplate = new Lazy<string>(
                () =>
                {
                    if (!connectionStringsProvider.ConnectionStringProviderByName.ContainsKey("EdFi_Ods"))
                    {
                        return string.Empty;
                    }

                    var connectionStringBuilder = connectionStringBuilderFactory.Get();

                    connectionStringBuilder.ConnectionString = connectionStringsProvider.GetConnectionString("EdFi_Ods");

                    return connectionStringBuilder.DatabaseName;
                });
        }

        public string DemoSandboxDatabase
        {
            get => "EdFi_Ods";
        }

        public string EmptyDatabase
        {
            get => DatabaseName(TemplateEmptyDatabase);
        }

        public string MinimalDatabase
        {
            get => DatabaseName(TemplateMinimalDatabase);
        }

        public string SampleDatabase
        {
            get => DatabaseName(TemplateSampleDatabase);
        }

        public string SandboxNameForKey(string key) => DatabaseName(SandboxPrefix + key);

        public string KeyFromSandboxName(string sandboxName) => sandboxName.Replace(DatabaseName(SandboxPrefix), string.Empty);

        public string TemplateSandboxNameForKey(string key) => SandboxPrefix + key;

        private string DatabaseName(string databaseName) => _databaseNameTemplate.Value.IsFormatString()
            ? string.Format(_databaseNameTemplate.Value, databaseName)
            : _databaseNameTemplate.Value;
    }
}
