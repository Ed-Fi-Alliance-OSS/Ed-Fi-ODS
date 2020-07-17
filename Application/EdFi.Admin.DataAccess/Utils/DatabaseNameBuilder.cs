// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Admin.DataAccess.Utils
{
    public static class DatabaseNameBuilder
    {
        private const string EdFi = "EdFi_";
        private const string TemplatePrefix = "Ods_";
        private const string SandboxPrefix = TemplatePrefix + "Sandbox_";

        public const string TemplateEmptyDatabase = TemplatePrefix + "Empty_Template";
        public const string TemplateMinimalDatabase = TemplatePrefix + "Minimal_Template";
        public const string TemplateSampleDatabase = TemplatePrefix + "Populated_Template";
        public const string DemoSandboxDatabase = "EdFi_Ods";

        public static string EmptyDatabase
        {
            get => EdFi + TemplateEmptyDatabase;
        }

        public static string MinimalDatabase
        {
            get => EdFi + TemplateMinimalDatabase;
        }

        public static string SampleDatabase
        {
            get => EdFi + TemplateSampleDatabase;
        }

        public static string SandboxNameForKey(string key) => EdFi + SandboxPrefix + key;

        public static string KeyFromSandboxName(string sandboxName) => sandboxName.Replace(SandboxPrefix, string.Empty);
    }
}
