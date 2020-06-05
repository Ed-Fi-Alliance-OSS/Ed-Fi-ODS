#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    /// <summary>
    /// Provides access to a specific external configuration file by filename.
    /// </summary>
    public class ExternalConfigFileSectionProvider : IConfigSectionProvider
    {
        private readonly string fileName;

        /// <summary>
        /// Creates and initializes an instance of the <see cref="ExternalConfigFileSectionProvider"/> using the specified configuration file.
        /// </summary>
        /// <param name="fileName">The path to the configuration file to be used (relative to the execution path).</param>
        public ExternalConfigFileSectionProvider(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Gets the configuration section by name.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section to be retrieved.</param>
        /// <returns>The specified configuration section if found; otherwise <b>null</b>.</returns>
        public object GetSection(string sectionName)
        {
            var configMap = new ExeConfigurationFileMap
                            {
                                ExeConfigFilename = fileName
                            };

            System.Configuration.Configuration externalConfiguration =
                ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            return externalConfiguration.GetSection(sectionName);
        }
    }
}
#endif