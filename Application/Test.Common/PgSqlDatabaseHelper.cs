// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Linq;

namespace Test.Common
{
    public class PgSqlDatabaseHelper
    {
        private const int CommandTimeout = 120;

        private readonly string _connectionString;

        public PgSqlDatabaseHelper(IConfigurationRoot config)
        {
            _connectionString = config.GetConnectionString("EdFi_master");
        }

        public void CopyDatabase(string originalDatabaseName, string newDatabaseName)
        {
            var createDatabaseSql = $"CREATE DATABASE \"{newDatabaseName}\" WITH TEMPLATE \"{originalDatabaseName}\";";
            var killProcesses = "SET client_min_messages TO ERROR;"
                                + $"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname='{originalDatabaseName}';";

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Execute(killProcesses, commandTimeout: CommandTimeout);
            conn.Execute(createDatabaseSql, commandTimeout: CommandTimeout);

            NpgsqlConnection.ClearAllPools();
        }

        public void DropDatabase(string databaseName)
        {
            var dropDatabaseSql = $"DROP DATABASE IF EXISTS \"{databaseName}\";";
            var killProcesses = "SET client_min_messages TO ERROR;"
                                + $"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname='{databaseName}';";

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Execute(killProcesses, commandTimeout: CommandTimeout);
            conn.Execute(dropDatabaseSql, commandTimeout: CommandTimeout);

            NpgsqlConnection.ClearAllPools();
        }

        public void DropMatchingDatabases(string databaseNamePattern)
        {
            using var conn = new NpgsqlConnection(_connectionString);

            var sql = $"SELECT datname FROM pg_database WHERE datname LIKE '{databaseNamePattern}'" +
                      " AND datistemplate = false;";

            var databaseNames = conn.Query<string>(sql).ToList();

            foreach (var databaseName in databaseNames)
            {
                DropDatabase(databaseName);
            }

            NpgsqlConnection.ClearAllPools();
        }
    }
}
