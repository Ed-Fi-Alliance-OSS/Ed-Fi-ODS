// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public class SqlServerSandboxProvisioner : SandboxProvisionerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SqlServerSandboxProvisioner));
        private SqlServerHostPlatform _sqlServerHostPlatform;

        public SqlServerSandboxProvisioner(IConfiguration configuration,
            IConfigConnectionStringsProvider connectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
            : base(configuration, connectionStringsProvider, databaseNameBuilder) { }

        protected override DbConnection CreateConnection() => new SqlConnection(ConnectionString);

        public override async Task<string[]> GetSandboxDatabasesAsync()
        {
            using (var conn = CreateConnection())
            {
                var results = await conn.QueryAsync<string>(
                        $"SELECT name FROM sys.databases WHERE name like @DbName;",
                        new { DbName = _databaseNameBuilder.SandboxNameForKey("%") }, commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);

                return results.ToArray();
            }
        }

        public override async Task RenameSandboxAsync(string oldName, string newName)
        {
            using (var conn = CreateConnection())
            {
                await conn.ExecuteAsync($"ALTER DATABASE {oldName} MODIFY Name = {newName};")
                    .ConfigureAwait(false);
            }
        }

        public override async Task<SandboxStatus> GetSandboxStatusAsync(string clientKey)
        {
            using (var conn = CreateConnection())
            {
                var results = await conn.QueryAsync<SandboxStatus>(
                        $"SELECT name as Name, state as Code, state_desc as Description FROM sys.databases WHERE name = @DbName;",
                        new { DbName = _databaseNameBuilder.SandboxNameForKey(clientKey) },
                        commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);

                return results.SingleOrDefault() ?? SandboxStatus.ErrorStatus();
            }
        }

        public override async Task DeleteSandboxesAsync(params string[] deletedClientKeys)
        {
            using (var conn = CreateConnection())
            {
                foreach (string key in deletedClientKeys)
                {
                    await conn.ExecuteAsync($@"
                         IF EXISTS (SELECT name from sys.databases WHERE (name = '{_databaseNameBuilder.SandboxNameForKey(key)}'))
                        BEGIN
                            ALTER DATABASE [{_databaseNameBuilder.SandboxNameForKey(key)}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            DROP DATABASE [{_databaseNameBuilder.SandboxNameForKey(key)}];
                        END;
                        ", commandTimeout: CommandTimeout)
                        .ConfigureAwait(false);
                }
            }
        }

        public override async Task CopySandboxAsync(string originalDatabaseName, string newDatabaseName)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    await conn.OpenAsync();

                    string backupDirectory = await GetBackupDirectoryAsync()
                        .ConfigureAwait(false);

                    _logger.Debug($"backup directory = {backupDirectory}");

                    string backup = await PathCombine(backupDirectory, originalDatabaseName + ".bak");
                    _logger.Debug($"backup file = {backup}");

                    var sqlFileInfo = await GetDatabaseFilesAsync(originalDatabaseName, newDatabaseName)
                        .ConfigureAwait(false);

                    await BackUpAndRestoreSandbox()
                        .ConfigureAwait(false);

                    // NOTE: these helper functions are using the same connection now.
                    async Task BackUpAndRestoreSandbox()
                    {
                        _logger.Debug($"backing up {originalDatabaseName} to file {backup}");

                        await conn.ExecuteAsync(
                            $@"BACKUP DATABASE [{originalDatabaseName}] TO DISK = '{backup}' WITH INIT;",
                            commandTimeout: CommandTimeout).ConfigureAwait(false);

                        string logicalName = null;

                        _logger.Debug($"restoring files from {backup}.");

                        using (var reader = await conn.ExecuteReaderAsync($@"RESTORE FILELISTONLY FROM DISK = '{backup}';", commandTimeout: CommandTimeout)
                            .ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                logicalName = reader.GetString(0);
                                _logger.Debug($"logical name = {logicalName}");
                            }
                        }

                        _logger.Debug($"Restoring database {newDatabaseName} from {backup}");

                        await conn.ExecuteAsync(
                                $@"RESTORE DATABASE [{newDatabaseName}] FROM DISK = '{backup}' WITH REPLACE, MOVE '{logicalName}' TO '{sqlFileInfo.Data}', MOVE '{logicalName}_log' TO '{sqlFileInfo.Log}';", commandTimeout: CommandTimeout)
                            .ConfigureAwait(false);


                        var changeLogicalDataName = $"ALTER DATABASE[{newDatabaseName}] MODIFY FILE(NAME='{logicalName}', NEWNAME='{newDatabaseName}')";
                        await conn.ExecuteAsync(changeLogicalDataName, commandTimeout: CommandTimeout)
                                  .ConfigureAwait(false);

                        var changeLogicalLogName = $"ALTER DATABASE[{newDatabaseName}] MODIFY FILE(NAME='{logicalName}_log', NEWNAME='{newDatabaseName}_log')";
                        await conn.ExecuteAsync(changeLogicalLogName, commandTimeout: CommandTimeout)
                                  .ConfigureAwait(false);
                    }

                    async Task<string> GetBackupDirectoryAsync()
                    {
                        return await GetSqlRegistryValueAsync(
                                @"HKEY_LOCAL_MACHINE", @"Software\Microsoft\MSSQLServer\MSSQLServer", @"BackupDirectory")
                            .ConfigureAwait(false);
                    }

                    async Task<string> GetSqlRegistryValueAsync(string subtree, string folder, string key)
                    {
                        var sql = $@"EXEC master.dbo.xp_instance_regread N'{subtree}', N'{folder}',N'{key}'";
                        string path = null;

                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.CommandTimeout = CommandTimeout;

                            _logger.Debug($"running stored procedure = {sql}");

                            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                            {
                                if (await reader.ReadAsync().ConfigureAwait(false))
                                {
                                    path = reader.GetString(1);
                                }
                            }
                        }

                        _logger.Debug($"path from registry = {path}");
                        return path;
                    }

                    async Task<SqlFileInfo> GetDatabaseFilesAsync(string originalName, string newName)
                    {
                        string dataPath = await GetSqlDataPathAsync(originalName, DataPathType.Data).ConfigureAwait(false);
                        string logPath = await GetSqlDataPathAsync(originalName, DataPathType.Log).ConfigureAwait(false);

                        return new SqlFileInfo
                        {
                            Data = await PathCombine(dataPath, $"{newName}.mdf"),
                            Log = await PathCombine(logPath, $"{newName}.ldf")
                        };
                    }

                    async Task<string> GetSqlDataPathAsync(string originalName, DataPathType dataPathType)
                    {
                        var type = (int)dataPathType;

                        // Since we know we have an existing database, use its data file location to figure out where to put new databases
                        var sql =
                            $"use [{originalName}];DECLARE @default_data_path nvarchar(1000);DECLARE @sqlexec nvarchar(200);SET @sqlexec = N'select TOP 1 @data_path=physical_name from sys.database_files where type={type};';EXEC sp_executesql @sqlexec, N'@data_path nvarchar(max) OUTPUT',@data_path = @default_data_path OUTPUT;SELECT @default_data_path;";

                        string fullPath = await conn.ExecuteScalarAsync<string>(sql, commandTimeout: CommandTimeout)
                            .ConfigureAwait(false);

                        return await GetDirectoryName(fullPath);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                    throw;
                }
            }
        }

        private async Task<SqlServerHostPlatform> GetSqlServerHostPlatform()
        {
            if (_sqlServerHostPlatform is null)
            {
                using (var conn = CreateConnection())
                {
                    // Get SQL Server OS; sys.dm_os_host_info was introduced in SQL Server 2017 (alongside Linux support)
                    // if the table doesn't exist we can assume that the OS is Windows

                    const string Windows = "Windows";

                    var getHostPlatformSql = $"IF OBJECT_ID('sys.dm_os_host_info') IS NOT NULL SELECT host_platform FROM sys.dm_os_host_info ELSE SELECT '{Windows}'";

                    string hostPlatform = await conn.ExecuteScalarAsync<string>(getHostPlatformSql, commandTimeout: CommandTimeout)
                        .ConfigureAwait(false);

                    var isWindows = hostPlatform.Equals(Windows, StringComparison.InvariantCultureIgnoreCase);

                    _sqlServerHostPlatform = new SqlServerHostPlatform()
                    {
                        OsPlatform = isWindows ? OSPlatform.Windows : OSPlatform.Linux,
                        DirectorySeparatorChar = isWindows ? '\\' : '/',
                        VolumeSeparatorChar = isWindows ? ':' : '/'
                    };
                }
            }

            return _sqlServerHostPlatform;
        }

        private async Task<string> PathCombine(string path1, string path2)
        {
            var hostPlatform = await GetSqlServerHostPlatform();

            // Based on https://github.com/mono/mono/blob/main/mcs/class/corlib/System.IO/Path.cs#L99

            if (path1.Length == 0)
                return path2;

            if (path2.Length == 0)
                return path1;

            char p1end = path1[path1.Length - 1];
            if (p1end != hostPlatform.DirectorySeparatorChar && p1end != hostPlatform.VolumeSeparatorChar)
                return path1 + hostPlatform.DirectorySeparatorChar + path2;

            return path1 + path2;
        }

        private async Task<string> GetDirectoryName(string path)
        {
            var hostPlatform = await GetSqlServerHostPlatform();

            // Based on: https://github.com/mono/mono/blob/main/mcs/class/corlib/System.IO/Path.cs#L203

            int nLast = path.LastIndexOf(hostPlatform.DirectorySeparatorChar);
            if (nLast == 0)
                nLast++;

            if (nLast > 0)
            {
                string ret = path.Substring(0, nLast);
                int l = ret.Length;

                if (l >= 2 && hostPlatform.DirectorySeparatorChar == '\\' && ret[l - 1] == hostPlatform.VolumeSeparatorChar)
                    return ret + hostPlatform.DirectorySeparatorChar;
                else if (l == 1 && hostPlatform.DirectorySeparatorChar == '\\' && path.Length >= 2 && path[nLast] == hostPlatform.VolumeSeparatorChar)
                    return ret + hostPlatform.VolumeSeparatorChar;
                else
                {
                    return ret;
                }
            }

            return String.Empty;
        }

        private class SqlFileInfo
        {
            public string Data { get; set; }

            public string Log { get; set; }
        }

        private class SqlServerHostPlatform
        {
            public OSPlatform OsPlatform { get; set; }

            public char DirectorySeparatorChar { get; set; }

            public char VolumeSeparatorChar { get; set; }
        }

        private enum DataPathType
        {
            Data = 0,
            Log = 1
        }
    }
}