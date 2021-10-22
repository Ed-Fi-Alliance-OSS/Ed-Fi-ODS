// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Test.Common
{
    public class MsSqlDatabaseHelper : IDatabaseHelper
    {
        private const int CommandTimeout = 120;

        private readonly string _connectionString;
        private readonly string _odsConnectionString;

        public MsSqlDatabaseHelper(IConfigurationRoot config)
        {
            _connectionString = config.GetConnectionString("EdFi_master");
            _odsConnectionString = config.GetConnectionString("EdFi_Ods");
        }

        public void CopyDatabase(string originalDatabaseName, string newDatabaseName)
        {
            string datafile, logfile;
            var backup = Path.Combine(GetBackupDirectory(), originalDatabaseName + ".bak");
            GetDatabaseFiles(originalDatabaseName, newDatabaseName, out datafile, out logfile);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                BackupDatabase(originalDatabaseName, backup, conn);
                var logicalName = RestoreFileList(backup, conn);
                RestoreDatabase(newDatabaseName, backup, logicalName, datafile, logfile, conn);
            }
        }

        public void DownloadAndRestoreDatabase(string path)
        {
            var psScript = @"
                $ErrorActionPreference = 'Stop'

                .\Initialize-PowershellForDevelopment.ps1

                $settings = @{ 
                    ApiSettings = @{ Engine = 'SQLServer' } 
                    ConnectionStrings = @{ EdFi_Ods = '" + _odsConnectionString + @"' } 
                }
                Set-DeploymentSettings $settings

                Reset-TestPopulatedTemplateDatabase
            ";

            var info = new ProcessStartInfo("powershell", psScript)
            {
                WorkingDirectory = path,
            };

            using var process = Process.Start(info);
            process.WaitForExit();

            if(process.ExitCode != 0)
            {
                throw new InvalidOperationException("Couldn't download template database or restore failed");
            }
        }

        private static void BackupDatabase(string originalDatabaseName, string backup, SqlConnection conn)
        {
            if (CheckForBackup(backup))
            {
                return;
            }

            // Adding FORMAT, SKIP, and COMPRESSION speeds up backup time
            var sql = string.Format(
                @"BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT, INIT, SKIP;",
                originalDatabaseName,
                backup);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandTimeout = CommandTimeout;
                cmd.ExecuteNonQuery();
            }
        }

        private static bool CheckForBackup(string backup)
        {
            if (!File.Exists(backup))
            {
                return false;
            }

            var fileInfo = new FileInfo(backup);
            return (DateTime.Now - fileInfo.LastWriteTime).TotalMinutes <= 10;
        }

        private static string RestoreFileList(string backup, SqlConnection conn)
        {
            var sql = string.Format(@"RESTORE FILELISTONLY FROM DISK = '{0}';", backup);
            string logicalName = null;

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandTimeout = CommandTimeout;

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        logicalName = reader.GetString(0);
                    }
                }
            }

            return logicalName;
        }

        private static void RestoreDatabase(
            string newDatabaseName,
            string backup,
            string logicalName,
            string datafile,
            string logfile,
            SqlConnection conn)
        {
            // WITH MOVE slows down restore time, but it's necessary for now
            var sql = string.Format(
                @"RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH MOVE '{2}' TO '{3}', MOVE '{2}_log' TO '{4}';",
                newDatabaseName,
                backup,
                logicalName,
                datafile,
                logfile);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandTimeout = CommandTimeout;
                cmd.ExecuteNonQuery();
            }
        }

        public void DropDatabase(string databaseName)
        {
            var sql = string.Format(
                @"ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{0}]", databaseName);

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = CommandTimeout;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DropMatchingDatabases(string databaseNamePattern)
        {
            var sql = string.Format(@"SELECT [name] FROM sys.databases where [name] like '{0}'", databaseNamePattern);
            var databaseNames = new List<string>();

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = CommandTimeout;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                databaseNames.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }

            foreach (var databaseName in databaseNames)
            {
                DropDatabase(databaseName);
            }
        }

        private string GetBackupDirectory()
        {
            return GetSqlRegistryValue(@"HKEY_LOCAL_MACHINE", @"Software\Microsoft\MSSQLServer\MSSQLServer", @"BackupDirectory");
        }

        private string GetSqlRegistryValue(string subtree, string folder, string key)
        {
            var sql = string.Format(@"EXEC master.dbo.xp_instance_regread N'{0}', N'{1}',N'{2}'", subtree, folder, key);
            string path = null;

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            path = reader.GetString(1);
                        }
                    }
                }
            }

            return path;
        }

        private string GetSqlDataPath(string originalDatabaseName, DataPathType dataPathType)
        {
            var type = (int) dataPathType;

            // Since we know we have an existing database, use its data file location to figure out where to put new databases
            var sql =
                "use [" + originalDatabaseName + "];" +
                "DECLARE @default_data_path nvarchar(1000);" +
                "DECLARE @sqlexec nvarchar(200);" +
                "SET @sqlexec = N'select TOP 1 @data_path=physical_name from sys.database_files where type=" + type + ";';" +
                "EXEC sp_executesql @sqlexec, N'@data_path nvarchar(max) OUTPUT',@data_path = @default_data_path OUTPUT;" +
                "SELECT @default_data_path;";

            string path;

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    conn.Open();
                    var fullPath = (string) cmd.ExecuteScalar();
                    path = Path.GetDirectoryName(fullPath);
                }
            }

            return path;
        }

        private void GetDatabaseFiles(string originalDatabaseName, string newDatabaseName, out string data, out string log)
        {
            var dataPath = GetSqlDataPath(originalDatabaseName, DataPathType.Data);
            var logPath = GetSqlDataPath(originalDatabaseName, DataPathType.Log);
            data = Path.Combine(dataPath, string.Format("{0}.mdf", newDatabaseName));
            log = Path.Combine(logPath, string.Format("{0}.ldf", newDatabaseName));
        }

        private enum DataPathType
        {
            Data = 0,
            Log = 1
        }
    }
}