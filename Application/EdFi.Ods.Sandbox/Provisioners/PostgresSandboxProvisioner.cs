// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using log4net;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public class PostgresSandboxProvisioner : SandboxProvisionerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(PostgresSandboxProvisioner));

        public PostgresSandboxProvisioner(IConfiguration configuration,
            IConfigConnectionStringsProvider connectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
            : base(configuration, connectionStringsProvider, databaseNameBuilder) { }

        public override async Task RenameSandboxAsync(string oldName, string newName)
        {
            using (var conn = CreateConnection())
            {
                 string sql =
                    $"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname='{oldName}';ALTER DATABASE \"{oldName}\" RENAME TO \"{newName}\";";

                await conn.ExecuteAsync(sql,commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);
            }
        }

        public override async Task DeleteSandboxesAsync(params string[] deletedClientKeys)
        {
            using (var conn = CreateConnection())
            {
                foreach (string key in deletedClientKeys)
                {
                   await conn.ExecuteAsync($@"
                        SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname='{_databaseNameBuilder.SandboxNameForKey(key)}'; 
                        DROP DATABASE IF EXISTS ""{_databaseNameBuilder.SandboxNameForKey(key)}"";
                        ", commandTimeout: CommandTimeout)
                        .ConfigureAwait(false);
                }
            }
        }

        public override async Task CopySandboxAsync(string originalDatabaseName, string newDatabaseName)
        {
            using (var conn = CreateConnection())
            {
                string sql = @$"
                    SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname='{originalDatabaseName}'; 
                    CREATE DATABASE ""{newDatabaseName}"" TEMPLATE ""{originalDatabaseName}""
                ";

                await conn.ExecuteAsync(sql, commandTimeout: CommandTimeout).ConfigureAwait(false);
            }
        }

        protected override DbConnection CreateConnection() => new NpgsqlConnection(ConnectionString);

        public override async Task<SandboxStatus> GetSandboxStatusAsync(string clientKey)
        {
            using (var conn = CreateConnection())
            {
                var results = await conn.QueryAsync<SandboxStatus>(
                        $"SELECT datname as Name, 0 as Code, 'ONLINE' Description FROM pg_database WHERE datname = \'{_databaseNameBuilder.SandboxNameForKey(clientKey)}\';",
                        commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);

                return results.SingleOrDefault() ?? SandboxStatus.ErrorStatus();
            }
        }

        public override async Task<string[]> GetSandboxDatabasesAsync()
        {
            using (var conn = CreateConnection())
            {
                var results = await conn.QueryAsync<string>(
                        $"SELECT datname as name FROM pg_database WHERE datname like \'{_databaseNameBuilder.SandboxNameForKey("%")}\';",
                        commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);

                return results.ToArray();
            }
        }
    }
}