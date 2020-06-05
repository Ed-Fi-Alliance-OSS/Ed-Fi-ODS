// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public class SqlSandboxProvisioner : AzureSandboxProvisioner
    {
        protected override void CopySandbox(string originalDatabaseName, string newDatabaseName)
        {
            string datafile, logfile;
            var backup = Path.Combine(GetBackupDirectory(), originalDatabaseName + ".bak");
            GetDatabaseFiles(originalDatabaseName, newDatabaseName, out datafile, out logfile);

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var sql = string.Format(
                    @"BACKUP DATABASE [{0}] TO DISK = '{1}' WITH INIT;",
                    originalDatabaseName,
                    backup);

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = CommandTimeout;
                    cmd.ExecuteNonQuery();
                }

                sql = string.Format(@"RESTORE FILELISTONLY FROM DISK = '{0}';", backup);
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

                sql =
                    string.Format(
                        @"RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE, MOVE '{2}' TO '{4}', MOVE '{3}_log' TO '{5}';",
                        newDatabaseName,
                        backup,
                        logicalName,
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
        }

        private string GetBackupDirectory()
        {
            return GetSqlRegistryValue(@"HKEY_LOCAL_MACHINE", @"Software\Microsoft\MSSQLServer\MSSQLServer", @"BackupDirectory");
        }

        private string GetSqlRegistryValue(string subtree, string folder, string key)
        {
            var sql = string.Format(@"EXEC master.dbo.xp_instance_regread N'{0}', N'{1}',N'{2}'", subtree, folder, key);
            string path = null;

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = CommandTimeout;
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

            string path = null;

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = CommandTimeout;
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
