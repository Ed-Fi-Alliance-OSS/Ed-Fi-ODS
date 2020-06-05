#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Configuration
{
    /// <summary>
    /// Provides access to the configured connections strings using the <see cref="ConfigurationManager"/>.
    /// </summary>
    public class AppConfigConnectionStringsProvider : IConfigConnectionStringsProvider
    {
        private readonly IDictionary<string, string> _connectionStringProviderByName;
        private readonly IDictionary<string, string> _connectionStringByName;

        public AppConfigConnectionStringsProvider()
        {
            _connectionStringProviderByName = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            _connectionStringByName = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            foreach (ConnectionStringSettings connectionStringSettings in ConfigurationManager.ConnectionStrings)
            {
                _connectionStringByName.Add(connectionStringSettings.Name, connectionStringSettings.ConnectionString);
                _connectionStringProviderByName.Add(connectionStringSettings.Name, connectionStringSettings.ProviderName);
            }
        }

        /// <summary>
        /// Gets the number of connection strings defined.
        /// </summary>
        public int Count
        {
            get => ConfigurationManager.ConnectionStrings.Count;
        }

        /// <summary>
        /// Get a configured connection string by name.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <returns>The configured connection string.</returns>
        public string GetConnectionString(string name) => _connectionStringByName[name];

        public IDictionary<string, string> ConnectionStringProviderByName
        {
            get => _connectionStringProviderByName;
        }
    }
}
#endif