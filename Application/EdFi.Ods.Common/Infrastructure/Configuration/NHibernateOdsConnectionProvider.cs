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

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateOdsConnectionProvider : DriverConnectionProvider
    {
        public static IOdsDatabaseConnectionStringProvider ConnectionStringProvider { get; set; }

        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = ConnectionStringProvider.GetConnectionString();
                connection.Open();
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }

            return connection;
        }

        public override async Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken)
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = ConnectionStringProvider.GetConnectionString();
                await connection.OpenAsync(cancellationToken);
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }

            return connection;
        }
    }
}
