// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using log4net;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Diagnostics;
using System.Linq;

namespace Test.Common
{
    public class PgSqlDatabaseHelper : IDatabaseHelper
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(PgSqlDatabaseHelper));

        private const int CommandTimeout = 120;

        private readonly string _connectionString;
        private readonly string _odsConnectionString;

        public PgSqlDatabaseHelper(IConfigurationRoot config)
        {
            _connectionString = config.GetConnectionString("EdFi_master");
            _odsConnectionString = config.GetConnectionString("EdFi_Ods");
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

        public void DownloadAndRestoreDatabase(string path)
        {
            var psScript = @"
                $ErrorActionPreference = 'Stop'

                ./Initialize-PowershellForDevelopment.ps1

                $settings = @{ 
                    ApiSettings = @{ Engine = 'PostgreSQL' } 
                    ConnectionStrings = @{ EdFi_Ods = '" + _odsConnectionString + @"' } 
                }
                Set-DeploymentSettings $settings

                Reset-TestPopulatedTemplateDatabase
            ";

            var info = new ProcessStartInfo("powershell", psScript)
            {
                WorkingDirectory = path,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using var process = Process.Start(info);

            process.OutputDataReceived += (sender, e) => { _logger.Info($"Output: {e.Data}"); };
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (sender, e) => { _logger.Error($"Error: {e.Data}"); };
            process.BeginErrorReadLine();

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException("Couldn't download template database or restore failed");
            }
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
