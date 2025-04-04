// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using log4net;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Sandbox.Provisioners
{
    /// <summary>
    /// Provisioner for Azure SQL.
    /// Not to be confused with Azure SQL Managed Instance which isn't supported yet.
    /// </summary>
    public class AzureSqlServerSandboxProvisioner : SqlServerSandboxProvisioner
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AzureSqlServerSandboxProvisioner));

        public AzureSqlServerSandboxProvisioner(IConfiguration configuration,
            IConfigConnectionStringsProvider connectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
            : base(configuration, connectionStringsProvider, databaseNameBuilder) { }

        public override async Task DeleteSandboxesAsync(params string[] deletedClientKeys)
        {
            await using var conn = CreateConnection();

            foreach (string key in deletedClientKeys)
            {
                // No need to manually drop active connections since Azure does it automatically.
                await conn.ExecuteAsync($@"
                        IF EXISTS (SELECT name from sys.databases WHERE (name = '{_databaseNameBuilder.SandboxNameForKey(key)}'))
                        BEGIN
                            DROP DATABASE [{_databaseNameBuilder.SandboxNameForKey(key)}];
                        END;
                        ", commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);
            }
        }

        public override async Task CopySandboxAsync(string originalDatabaseName, string newDatabaseName)
        {
            try
            {
                await using var conn = CreateConnection();
                
                await conn.ExecuteAsync($@"
                        CREATE DATABASE {newDatabaseName} AS COPY OF {originalDatabaseName};
                        DECLARE @wait BIT = 1
                        DECLARE @nextWait BIT
                        DECLARE @state_desc NVARCHAR(60)
                        WHILE @wait = 1
                        BEGIN
                            SELECT @nextWait = 1 FROM sys.databases WHERE name = '{newDatabaseName}'
                            IF @nextWait = 1
                            BEGIN
                                SELECT @state_desc = state_desc FROM sys.databases WHERE name = '{newDatabaseName}'
                                IF @state_desc = 'ONLINE'
                                    SET @wait = 0
                                ELSE
                                    WAITFOR DELAY '00:00:05'
                            END
                            ELSE
                                SET @wait = 0
                            SET @nextWait = NULL
                        END
                        ", commandTimeout: CommandTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}
