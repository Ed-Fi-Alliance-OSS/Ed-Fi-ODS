// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class DbHelper
    {
        public static IDbConnection GetConnection(DatabaseEngine databaseEngine, string connectionString)
        {
            var connection = databaseEngine == DatabaseEngine.SqlServer ?
                (IDbConnection)new SqlConnection(connectionString)
                : new NpgsqlConnection(connectionString);

            return connection;
        }

        public static IDbConnection GetConnection(string connectionString)
        {
            var databaseEngine = GetDatabaseEngine();

            var connection = databaseEngine == DatabaseEngine.SqlServer ?
                (IDbConnection)new SqlConnection(connectionString)
                : new NpgsqlConnection(connectionString);

            return connection;
        }

        public static DatabaseEngine GetDatabaseEngine()
        {
            var engineConfiguration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var engine = engineConfiguration.GetValue<string>("Engine");
            return DatabaseEngine.TryParseEngine(engine);
        }

    }
}