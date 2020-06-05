// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Database;
using NHibernate.Connection;

namespace EdFi.Ods.Api.Common.Infrastructure.ConnectionProviders
{
    /// <summary>
    /// An NHibernate <see cref="ConnectionProvider"/> implementation that uses the registered ODS 
    /// connection string provider (using the key "IDatabaseConnectionStringProvider.Ods") to obtain 
    /// the connection string for opening a connection to the database.
    /// </summary>
    public class EdFiOdsConnectionProvider : DriverConnectionProvider
    {
        private readonly IDatabaseConnectionStringProvider _connectionStringProvider;

        public EdFiOdsConnectionProvider(IDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        /// <summary>
        /// Create and open a connection to the Ed-Fi ODS for NHibernate.
        /// </summary>
        /// <returns>An open database connection.</returns>
        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = _connectionStringProvider.GetConnectionString();
                connection.Open();
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }

            return connection;
        }

        public override Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken)
            => Task.FromResult(GetConnection());
    }
}
