// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Api.Database
{
    public class InstanceSecurityDatabaseNameTokenReplacementConnectionStringProvider : ISecurityDatabaseConnectionStringProvider
    {
        private const string ConnectionStringName = "EdFi_Security";
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;
        private readonly IDbConnectionStringBuilderAdapterFactory _connectionStringBuilderFactory;
        private readonly ISecurityDatabaseNameReplacementTokenProvider _securityDatabaseNameReplacementTokenProvider;

        public InstanceSecurityDatabaseNameTokenReplacementConnectionStringProvider(IConfigConnectionStringsProvider configConnectionStringsProvider, IDbConnectionStringBuilderAdapterFactory connectionStringBuilderFactory, ISecurityDatabaseNameReplacementTokenProvider securityDatabaseNameReplacementTokenProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _connectionStringBuilderFactory = connectionStringBuilderFactory;
            _securityDatabaseNameReplacementTokenProvider = securityDatabaseNameReplacementTokenProvider;
        }

        public string GetConnectionString()
        {
            var securityConnectionString = SecurityConnectionString();

            if (string.IsNullOrEmpty(securityConnectionString))
            {
                throw new ArgumentException($"No connection string named '{ConnectionStringName}' was found in the 'connectionStrings' section of the application configuration file.");
            }

            var connectionStringBuilder = _connectionStringBuilderFactory.Get();
            connectionStringBuilder.ConnectionString = securityConnectionString;

            // Override the Database Name, format if string coming in has a format replacement token,
            // otherwise use database name set in the Initial Catalog.
            connectionStringBuilder.DatabaseName = connectionStringBuilder.DatabaseName.IsFormatString()
                ? string.Format(
                    connectionStringBuilder.DatabaseName,
                    _securityDatabaseNameReplacementTokenProvider.GetReplacementToken())
                : connectionStringBuilder.DatabaseName;

            return connectionStringBuilder.ConnectionString;

            string SecurityConnectionString()
            {
                if (_configConnectionStringsProvider.Count == 0)
                {
                    throw new ArgumentException("No connection strings were found in the configuration file.");
                }

                return _configConnectionStringsProvider.GetConnectionString(ConnectionStringName);
            }
        }
    }
}