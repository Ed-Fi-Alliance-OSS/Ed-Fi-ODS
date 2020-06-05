#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Gets the connection string using a configured named connection string as a prototype for the connection string
    /// with an injected <see cref="IDatabaseNameReplacementTokenProvider"/> to replace token in database name.
    /// </summary>
    public class PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;
        private readonly Func<IDbConnectionStringBuilderAdapter> _dbConnectionStringBuilderAdapterFactory;

        private readonly ConcurrentDictionary<Tuple<string, string>, string> _connectionStringsByNames
            = new ConcurrentDictionary<Tuple<string, string>, string>();
        private readonly IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;
        private readonly string _prototypeConnectionStringName;

        private string _prototypeConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider"/> class using
        /// the specified "prototype" named connection string from the application configuration file and the supplied database name replacement token provider.
        /// </summary>
        /// <param name="prototypeConnectionStringName">The named connection string to use as the basis for building the connection string.</param>
        /// <param name="databaseNameReplacementTokenProvider">The provider that builds the database name replacement token for use in the resulting connection string.</param>
        /// <param name="configConnectionStringsProvider"></param>
        /// <param name="dbConnectionStringBuilderAdapterFactory"></param>
        public PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider(
            string prototypeConnectionStringName,
            IDatabaseNameReplacementTokenProvider databaseNameReplacementTokenProvider,
            IConfigConnectionStringsProvider configConnectionStringsProvider,
            Func<IDbConnectionStringBuilderAdapter> dbConnectionStringBuilderAdapterFactory)
        {
            _prototypeConnectionStringName = prototypeConnectionStringName;
            _databaseNameReplacementTokenProvider = databaseNameReplacementTokenProvider;
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _dbConnectionStringBuilderAdapterFactory = dbConnectionStringBuilderAdapterFactory;
        }

        private string PrototypeConnectionString
        {
            get
            {
                if (_prototypeConnectionString == null)
                {
                    if (_configConnectionStringsProvider.Count == 0)
                    {
                        throw new ConfigurationErrorsException("No connection strings were found in the configuration file.");
                    }

                    if (string.IsNullOrWhiteSpace(_prototypeConnectionStringName))
                    {
                        throw new ArgumentNullException("prototypeConnectionStringName");
                    }

                    var connectionString = _configConnectionStringsProvider.GetConnectionString(_prototypeConnectionStringName);

                    if (connectionString == null)
                    {
                        throw new ConfigurationErrorsException(
                            $"No connection string named '{_prototypeConnectionStringName}' was found in the 'connectionStrings' section of the application configuration file.");
                    }

                    _prototypeConnectionString = connectionString;
                }

                return _prototypeConnectionString;
            }
        }

        /// <summary>
        /// Gets the connection string using a configured named connection string with the database replaced using the specified database name replacement token provider.
        /// </summary>
        /// <returns>The connection string.</returns>
        public string GetConnectionString()
        {
            var connectionStringBuilder = _dbConnectionStringBuilderAdapterFactory();
            connectionStringBuilder.ConnectionString = PrototypeConnectionString;

            // Override the Database Name, format if string coming in has a format replacement token,
            // otherwise use database name set in the Initial Catalog.
            connectionStringBuilder.DatabaseName = connectionStringBuilder.DatabaseName.IsFormatString()
                ? string.Format(
                    connectionStringBuilder.DatabaseName,
                    _databaseNameReplacementTokenProvider.GetReplacementToken())
                : connectionStringBuilder.DatabaseName;

            return _connectionStringsByNames.GetOrAdd(
                Tuple.Create(_prototypeConnectionStringName, connectionStringBuilder.DatabaseName),
                x => connectionStringBuilder.ConnectionString);
        }
    }
}
#endif