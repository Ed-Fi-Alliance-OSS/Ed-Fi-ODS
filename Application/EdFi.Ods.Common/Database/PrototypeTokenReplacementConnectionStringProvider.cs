// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Common.Extensions;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Gets the connection string using a configured named connection string as a prototype for the connection string
    /// with an injected <see cref="IDatabaseReplacementTokenProvider"/> to replace token in database name and server name.
    /// </summary>
    public class PrototypeTokenReplacementConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;

        private readonly string _prototypeConnectionStringName;
        private readonly string _readOnlyPrototypeConnectionStringName;
        private readonly IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;
        private readonly IDbConnectionStringBuilderAdapterFactory _dbConnectionStringBuilderAdapterFactory;
        
        private readonly Lazy<string> _protoTypeConnectionString;
        private readonly Lazy<string> _protoTypeReadOnlyConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrototypeTokenReplacementConnectionStringProvider"/> class using
        /// the specified "prototype" named connection string from the application configuration file.
        /// </summary>
        /// <param name="prototypeConnectionStringName">The named connection string to use as the basis for building the connection string.</param>
        /// <param name="readOnlyPrototypeConnectionStringName">The named connection string to use as the basis for building the connection string for read-only data.</param>
        /// <param name="databaseReplacementTokenProvider">The provider that builds the database replacement token for use in the resulting connection string.</param>
        /// <param name="configConnectionStringsProvider"></param>
        /// <param name="dbConnectionStringBuilderAdapterFactory"></param>
        public PrototypeTokenReplacementConnectionStringProvider(
            string prototypeConnectionStringName,
            string readOnlyPrototypeConnectionStringName,
            IDatabaseReplacementTokenProvider databaseReplacementTokenProvider,
            IConfigConnectionStringsProvider configConnectionStringsProvider,
            IDbConnectionStringBuilderAdapterFactory dbConnectionStringBuilderAdapterFactory)
        {
            _prototypeConnectionStringName = prototypeConnectionStringName;
            _readOnlyPrototypeConnectionStringName = readOnlyPrototypeConnectionStringName;
            _databaseReplacementTokenProvider = databaseReplacementTokenProvider;
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _dbConnectionStringBuilderAdapterFactory = dbConnectionStringBuilderAdapterFactory;

            _protoTypeConnectionString = new Lazy<string>(() => PrototypeConnectionString(_prototypeConnectionStringName));
            _protoTypeReadOnlyConnectionString = new Lazy<string>(() => PrototypeConnectionString(_readOnlyPrototypeConnectionStringName) ?? _protoTypeConnectionString.Value);

            string PrototypeConnectionString(string connectionStringName)
            {
                if (_configConnectionStringsProvider.Count == 0)
                {
                    throw new ArgumentException("No connection strings were found in the configuration file.");
                }

                if (string.IsNullOrWhiteSpace(connectionStringName))
                {
                    throw new ArgumentNullException(nameof(connectionStringName));
                }

                if (_configConnectionStringsProvider.ConnectionStringProviderByName.TryGetValue(connectionStringName, out var connectionString))
                {
                    return connectionString;
                }
                
                return null;
            }
        }

        /// <summary>
        /// Gets the connection string with the tokens already replaced using a configured named connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        public string GetConnectionString()
        {
            return ProcessTokenReplacements(_protoTypeConnectionString.Value, _prototypeConnectionStringName);
        }

        /// <summary>
        /// Gets the connection string for read-only database requests with the tokens already replaced using a configured named connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        public string GetReadOnlyConnectionString()
        {
            return ProcessTokenReplacements(_protoTypeReadOnlyConnectionString.Value, _readOnlyPrototypeConnectionStringName);
        }

        private string ProcessTokenReplacements(string prototypeConnectionString, string prototypeConnectionStringName)
        {
            var connectionStringBuilder = _dbConnectionStringBuilderAdapterFactory.Get();

            if (string.IsNullOrEmpty(prototypeConnectionString))
            {
                throw new ArgumentException(
                    $"No connection string named '{prototypeConnectionStringName}' was found in the 'connectionStrings' section of the application configuration file.");
            }

            connectionStringBuilder.ConnectionString = prototypeConnectionString;

            // Override the Database Name, format if string coming in has a format replacement token,
            // otherwise use database name set in the Initial Catalog.
            if (connectionStringBuilder.DatabaseName.IsFormatString())
            {
                connectionStringBuilder.DatabaseName = string.Format(
                    connectionStringBuilder.DatabaseName,
                    _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken());
            }

            // Override the Server Name, format if string coming in has a format replacement token,
            // otherwise use server name set in the Data Source.
            if (connectionStringBuilder.ServerName.IsFormatString())
            {
                connectionStringBuilder.ServerName = string.Format(
                    connectionStringBuilder.ServerName,
                    _databaseReplacementTokenProvider.GetServerNameReplacementToken());
            }

            return connectionStringBuilder.ConnectionString;
        }
    }
}
