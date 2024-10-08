// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using NHibernate.Connection;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateOdsConnectionProvider : DriverConnectionProvider
    {
        public const string UseReadWriteConnectionCacheKey = "UseReadWriteConnection";
        
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        public NHibernateOdsConnectionProvider(IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = _connectionStringProvider.GetConnectionString();

                connection.Open();
            }
            catch (EdFiProblemDetailsExceptionBase)
            {
                connection.Dispose();

                // Throw the problem details exception, as-is
                throw;
            }
            catch (Exception ex)
            {
                connection.Dispose();

                // Wrap the underlying exception with a user-facing exception. 
                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }

        public override async Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken)
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString =  _connectionStringProvider.GetConnectionString();

                await connection.OpenAsync(cancellationToken);
            }
            catch (EdFiProblemDetailsExceptionBase)
            {
                connection.Dispose();

                // Throw the problem details exception, as-is
                throw;
            }
            catch (Exception ex)
            {
                connection.Dispose();

                // Wrap the underlying exception with a user-facing exception. 
                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }
    }
}