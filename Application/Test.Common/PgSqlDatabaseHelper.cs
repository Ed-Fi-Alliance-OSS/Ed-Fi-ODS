// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace Test.Common
{
    public class PgSqlDatabaseHelper : IDatabaseHelper
    {
        private const int CommandTimeout = 120;

        private readonly string _connectionString;
        private readonly string _odsConnectionString;
        private readonly string _psqlExecutable;

        public PgSqlDatabaseHelper(IConfigurationRoot config)
        {
            _connectionString = config.GetConnectionString("EdFi_master");
            _odsConnectionString = config.GetConnectionString("EdFi_Ods");
            _psqlExecutable = config.GetSection("PsqlExecutable").Value;
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

        public void DownloadAndRestoreDatabase(string uri, string packageName, string fileName, string databaseName)
        {
            var downloadPath = "C:/Downloads";
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            var backupZip = Path.Combine(downloadPath, packageName + ".zip");
            var sqlFile = Path.Combine(downloadPath, databaseName + ".sql");

            if (!File.Exists(backupZip))
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(uri, backupZip);
                }
            }

            GetSQLFileFromPackage(backupZip, sqlFile, fileName);

            var createDatabaseSql = $"CREATE DATABASE \"{databaseName}\";";

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Execute(createDatabaseSql, commandTimeout: CommandTimeout);

            var builder = new NpgsqlConnectionStringBuilder(_odsConnectionString);

            var arguments =
                $"-P pager=off --tuples-only --echo-errors --no-password --host={builder.Host} --port={builder.Port} --username={builder.Username} --dbname={builder.Database} --file={sqlFile}";

            NpgsqlConnection.ClearAllPools();

            var psqlExecutable = EnsurePsqlExecutablePathExists(downloadPath);

            var info = new ProcessStartInfo(psqlExecutable, arguments)
            {
                RedirectStandardInput = true,
                RedirectStandardError = true
            };

            using var process = new Process { StartInfo = info };

            process.Start();

            process.WaitForExit();
        }

        private static void GetSQLFileFromPackage(string sourcePath, string destinationPath, string sqlFileName)
        {
            if (File.Exists(sourcePath))
            {
                var unzipFolderName = sourcePath.Replace(".zip", "");

                ZipFile.ExtractToDirectory(sourcePath, unzipFolderName, true);
                File.Copy($"{unzipFolderName}/{sqlFileName}", destinationPath, true);

                Directory.Delete(unzipFolderName, true);
            }
        }

        private string EnsurePsqlExecutablePathExists(string path)
        {
            var toolsPath = Path.GetFullPath(Path.Combine(path, "tool"));

            if (!Directory.Exists(toolsPath))
            {
                Directory.CreateDirectory(toolsPath);
            }

            var pslExecutable = Path.Combine(toolsPath, "psql.exe");

            if (File.Exists(pslExecutable))
            {
                return pslExecutable;
            }

            var tempDirectory = Path.Combine(path, "temp");

            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }

            Directory.CreateDirectory(tempDirectory);

            var zipFileName = Path.Combine(tempDirectory, $"psql.binaries.zip");

            // Download the nuget package as a .zip
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(_psqlExecutable, zipFileName);
            }

            ZipFile.ExtractToDirectory(zipFileName, tempDirectory);

            var files = Directory.GetFiles(Path.Combine(tempDirectory, "tools"));

            foreach (var file in files)
            {
                File.Move(file, Path.Combine(toolsPath, Path.GetFileName(file)));
            }

            return pslExecutable;
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
