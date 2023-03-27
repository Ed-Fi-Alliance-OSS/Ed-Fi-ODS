// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class ExtensionVersionsPathProvider : IExtensionVersionsPathProvider
    {
        private readonly string _extensionVersionsPath;
        private readonly string _extensionDefaultVersionsPath;

        public ExtensionVersionsPathProvider(string extensionVersion)
        {
            _extensionVersionsPath = $"Versions{Path.DirectorySeparatorChar}{extensionVersion}";
            _extensionDefaultVersionsPath = $"Versions{Path.DirectorySeparatorChar}1.0.0";
        }

        public string ExtensionVersionsPath(string basePath = null)
        {
            if (basePath == null)
                return _extensionVersionsPath;

            switch (Directory.GetDirectories(basePath, "Versions/*", SearchOption.AllDirectories))
            {
                // When path contains version passed as param
                case string[] d when d.Any(x => x.Contains(_extensionVersionsPath)):
                    return Path.Combine(basePath, _extensionVersionsPath);

                // If path contains default version (1.0.0)
                case string[] d when d.Any(x => x.Contains(_extensionDefaultVersionsPath)):
                    return Path.Combine(basePath, _extensionDefaultVersionsPath);

                // When path is a plugin not following standard and extension versions
                default:
                    return Path.Combine(basePath);
            }
        }
    }
}
