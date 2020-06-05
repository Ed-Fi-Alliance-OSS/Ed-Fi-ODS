#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    /// <summary>
    /// Provides access to config values from a specific external configuration file.
    /// </summary>
    public class ExternalConfigFileConfigValueProvider : IConfigValueProvider
    {
        private readonly ExternalConfigFileSectionProvider _configFileSectionProvider;

        /// <summary>
        /// Creates and initializes an instance of the <see cref="ExternalConfigFileConfigValueProvider"/> using
        /// the supplied <see cref="ExternalConfigFileSectionProvider"/> instance.
        /// </summary>
        /// <param name="configFileSectionProvider">The previously initialized config section provider that provides
        /// access to a specific external configuration file by path.</param>
        public ExternalConfigFileConfigValueProvider(ExternalConfigFileSectionProvider configFileSectionProvider)
        {
            _configFileSectionProvider = configFileSectionProvider;
        }

        /// <summary>
        /// Gets the specified appSettings value by name.
        /// </summary>
        /// <param name="name">The name of the appSettings value to be retrieved.</param>
        /// <returns>The value of appSettings entry.</returns>
        public string GetValue(string name)
        {
            var appSettingsSection = _configFileSectionProvider.GetSection("appSettings") as AppSettingsSection;

            // ReSharper disable once PossibleNullReferenceException - in reality it does not return null.
            // Thus no way to unit test (right now) if a null check were added.
            return appSettingsSection.Settings[name]
                                     ?.Value;
        }
    }
}
#endif