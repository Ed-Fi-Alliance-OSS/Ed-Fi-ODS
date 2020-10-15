// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Entity;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using Npgsql;

namespace EdFi.Ods.Api.Configuration
{
    public class DatabaseEngineDbConfiguration : DbConfiguration
    {
        public DatabaseEngineDbConfiguration(DatabaseEngine databaseEngine)
        {
            if (databaseEngine != DatabaseEngine.Postgres)
            {
                return;
            }

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
