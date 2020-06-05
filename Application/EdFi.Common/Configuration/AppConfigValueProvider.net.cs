#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Configuration;

namespace EdFi.Ods.Common.Configuration
{
    /// <summary>
    /// Provides access to config values from the application configuration file.
    /// </summary>
    public class AppConfigValueProvider : IConfigValueProvider
    {
        /// <summary>
        /// Gets the specified appSettings value by name.
        /// </summary>
        /// <param name="name">The name of the appSettings value to be retrieved.</param>
        /// <returns>The value of appSettings entry.</returns>
        public string GetValue(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
#endif