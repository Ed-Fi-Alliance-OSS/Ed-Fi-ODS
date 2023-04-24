// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using Npgsql;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using Microsoft.Data.SqlClient;

namespace EdFi.Admin.DataAccess.DbConfigurations
{
    public class DatabaseEngineDbConfiguration : DbConfiguration
    {
        public DatabaseEngineDbConfiguration(DatabaseEngine databaseEngine)
        {
            if (databaseEngine == DatabaseEngine.SqlServer)
            {
                SetProviderFactory(
                    providerInvariantName: SqlProviderServices.ProviderInvariantName,
                    providerFactory: SqlClientFactory.Instance);

                SetProviderServices(
                    providerInvariantName: SqlProviderServices.ProviderInvariantName,
                    provider: SqlProviderServices.Instance);
                SetDefaultConnectionFactory(connectionFactory: new SqlConnectionFactory());
            }
            else if (databaseEngine == DatabaseEngine.Postgres)
            {
                const string name = "Npgsql";

                SetProviderFactory(
                    providerInvariantName: name,
                    providerFactory: NpgsqlFactory.Instance);

                SetProviderServices(
                    providerInvariantName: name,
                    provider: NpgsqlServices.Instance);

                SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
            }
        }
    }
}
