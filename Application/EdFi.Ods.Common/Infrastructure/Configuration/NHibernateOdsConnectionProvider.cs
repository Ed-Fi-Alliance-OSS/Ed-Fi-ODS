// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Connection;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateOdsConnectionProvider : DriverConnectionProvider
    {
        public const string UseReadWriteConnectionCacheKey = "UseReadWriteConnection";
        
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IContextStorage _contextStorage;
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        public NHibernateOdsConnectionProvider(
            IOdsDatabaseConnectionStringProvider connectionStringProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IContextStorage contextStorage)
        {
            _connectionStringProvider = connectionStringProvider;
            _authorizationContextProvider = authorizationContextProvider;
            _contextStorage = contextStorage;
        }

        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                if (IsReadRequest(_authorizationContextProvider.GetAction()) 
                    && !(_contextStorage.GetValue<bool?>(UseReadWriteConnectionCacheKey) ?? false))
                {
                    connection.ConnectionString = _connectionStringProvider.GetReadReplicaConnectionString();
                }
                else
                {
                    connection.ConnectionString = _connectionStringProvider.GetConnectionString();
                }

                connection.Open();
            }
            catch (Exception ex)
            {
                connection.Dispose();

                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }

        public override async Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken)
        {
            var connection = Driver.CreateConnection();

            try
            {
                if (IsReadRequest(_authorizationContextProvider.GetAction()) 
                    && !(_contextStorage.GetValue<bool?>(UseReadWriteConnectionCacheKey) ?? false))
                {
                    connection.ConnectionString = _connectionStringProvider.GetReadReplicaConnectionString();
                }
                else
                {
                    connection.ConnectionString = _connectionStringProvider.GetConnectionString();
                }

                await connection.OpenAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                connection.Dispose();

                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }

        private bool IsReadRequest(string actionUri)
        {
            if (actionUri == null)
            {
                return false;
            }

            int lastSlashPos = actionUri.LastIndexOf('/');

            // Use a convention of the action URI name starting with "read" for all read-related operations (e.g. read, readChange, readHistory, etc)
            return lastSlashPos >= 0 && actionUri.AsSpan(lastSlashPos + 1).StartsWith("read");
        }
    }
}
