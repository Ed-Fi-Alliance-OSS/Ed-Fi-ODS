// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Data.SqlClient;

namespace EdFi.Admin.DataAccess.Utils
{
    public class DatabaseNameBuilder
    {
        private const string TemplatePrefix = "Ods_";
        private const string SandboxPrefix = TemplatePrefix + "Sandbox_";

        private const string TemplateEmptyDatabase = TemplatePrefix + "Empty_Template";
        private const string TemplateMinimalDatabase = TemplatePrefix + "Minimal_Template";
        private const string TemplateSampleDatabase = TemplatePrefix + "Populated_Template";
        public const string CodeGenDatabase = "EdFi_Ods";

        private static string _databaseNameTemplate;

        private static string DatabaseNameTemplate
        {
            get
            {
                return _databaseNameTemplate ??
                       (_databaseNameTemplate =
                           ConfigurationManager.ConnectionStrings["EdFi_Ods"] != null
                               ? new SqlConnectionStringBuilder(
                                   ConfigurationManager.ConnectionStrings["EdFi_Ods"]
                                                       .ConnectionString).InitialCatalog
                               : string.Empty);
            }
        }

        public static string EmptyDatabase
        {
            get { return DatabaseName(TemplateEmptyDatabase); }
        }

        public static string MinimalDatabase
        {
            get { return DatabaseName(TemplateMinimalDatabase); }
        }

        public static string SampleDatabase
        {
            get { return DatabaseName(TemplateSampleDatabase); }
        }

        private static string DatabaseName(string databaseName)
        {
            return DatabaseNameTemplate.Contains("{0}")
                ? string.Format(DatabaseNameTemplate, databaseName)
                : DatabaseNameTemplate;
        }

        public static string SandboxNameForKey(string key)
        {
            return DatabaseName(SandboxPrefix + key);
        }

        public static string YearSpecificOdsDatabaseName(int year)
        {
            return DatabaseName(TemplatePrefix + year);
        }

        public static string KeyFromSandboxName(string sandboxName)
        {
            return sandboxName.Replace(DatabaseName(SandboxPrefix), string.Empty);
        }
    }
}
