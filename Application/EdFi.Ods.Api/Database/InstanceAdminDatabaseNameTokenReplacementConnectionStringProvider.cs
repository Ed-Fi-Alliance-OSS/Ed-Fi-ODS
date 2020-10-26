// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.Database
{
    public class InstanceAdminDatabaseNameTokenReplacementConnectionStringProvider : IAdminDatabaseConnectionStringProvider
    {
        private const string ConnectionStringName = "EdFi_Admin";
        private readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;
        private readonly IDbConnectionStringBuilderAdapterFactory _connectionStringBuilderFactory;
        private readonly IAdminDatabaseNameReplacementTokenProvider _adminDatabaseNameReplacementTokenProvider;

        public InstanceAdminDatabaseNameTokenReplacementConnectionStringProvider(IConfigConnectionStringsProvider configConnectionStringsProvider, IDbConnectionStringBuilderAdapterFactory connectionStringBuilderFactory, IAdminDatabaseNameReplacementTokenProvider adminDatabaseNameReplacementTokenProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _connectionStringBuilderFactory = connectionStringBuilderFactory;
            _adminDatabaseNameReplacementTokenProvider = adminDatabaseNameReplacementTokenProvider;
        }

        public string GetConnectionString()
        {
            var adminConnectionString = AdminConnectionString();

            if (string.IsNullOrEmpty(adminConnectionString))
            {
                throw new ArgumentException($"No connection string named '{ConnectionStringName}' was found in the 'connectionStrings' section of the application configuration file.");
            }

            var connectionStringBuilder = _connectionStringBuilderFactory.Get();
            connectionStringBuilder.ConnectionString = adminConnectionString;

            // Override the Database Name, format if string coming in has a format replacement token,
            // otherwise use database name set in the Initial Catalog.
            connectionStringBuilder.DatabaseName = connectionStringBuilder.DatabaseName.IsFormatString()
                ? string.Format(
                    connectionStringBuilder.DatabaseName,
                    _adminDatabaseNameReplacementTokenProvider.GetReplacementToken())
                : connectionStringBuilder.DatabaseName;

            return connectionStringBuilder.ConnectionString;

            string AdminConnectionString()
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