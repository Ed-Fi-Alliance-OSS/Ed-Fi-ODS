// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Common.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Common
{
    [SetUpFixture]
    public abstract class OneTimeGlobalDatabaseSetupBase
    {
        public IConfigurationRoot Configuration { get; private set; }
        public DatabaseEngine DatabaseEngine { get; private set; }
        public virtual string[] OdsTokens { get; set; } = { "0" };
        protected abstract string DatabaseCopyPrefix { get; }

        private string _dbCopyConnectionString;
        private IDatabaseHelper _databaseHelper;

        [OneTimeSetUp]
        public virtual async Task OneTimeSetUpAsync()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables(DatabaseCopyPrefix)
                .Build();

            var strDatabaseEngine = Configuration.GetSection("ApiSettings").GetValue<string>("Engine");

            if (strDatabaseEngine == null)
            {
                throw new ApplicationException("Missing configuration entry: Engine");
            }

            DatabaseEngine = DatabaseEngine.TryParseEngine(strDatabaseEngine);

            var isStrictMode = Configuration.GetValue<bool?>("StrictMode");
            if (isStrictMode is null)
            {
                throw new ApplicationException("Missing configuration entry: StrictMode");
            }

            var maintenanceConnectionString = Configuration.GetConnectionString("EdFi_Master");
            if (string.IsNullOrWhiteSpace(maintenanceConnectionString))
            {
                throw new ApplicationException(
                    $"Missing configuration entry: ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Master");
            }

            var odsConnectionString = Configuration.GetConnectionString("EdFi_Ods");
            if (string.IsNullOrWhiteSpace(odsConnectionString))
            {
                throw new ApplicationException(
                    $"Missing configuration entry: ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Ods");
            }

            if (odsConnectionString.Contains('{') || odsConnectionString.Contains('}'))
            {
                throw new ApplicationException(
                    $"ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Ods can't have template strings in the database name. Specify the database that should be copied for this test execution.");
            }

            var odsImplementationFolderPath = Configuration.GetValue<string>("ODSImplementationFolderPath");
            if (string.IsNullOrWhiteSpace(odsImplementationFolderPath))
            {
                throw new ApplicationException($"Missing configuration entry: ODSImplementationFolderPath");
            }

            IDbConnectionStringBuilderAdapter connectionStringBuilder;

            if (DatabaseEngine == DatabaseEngine.SqlServer)
            {
                connectionStringBuilder = new SqlConnectionStringBuilderAdapter();
                _databaseHelper = new MsSqlDatabaseHelper(Configuration);
            }
            else
            {
                connectionStringBuilder = new NpgsqlConnectionStringBuilderAdapter();
                _databaseHelper = new PgSqlDatabaseHelper(Configuration);
            }

            connectionStringBuilder.ConnectionString = odsConnectionString;

            try
            {
                BuildConnection(maintenanceConnectionString).Dispose();
            }
            catch
            {
                // TODO implement [ODS-5110 Create Test Container] here

                var reason =
                    $"Couldn't connect to database server, verify ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Master";
                if (isStrictMode.Value)
                {
                    Assert.Fail(reason);
                }
                else
                {
                    Assert.Ignore(reason);
                }
            }

            try
            {
                BuildConnection(odsConnectionString).Dispose();
            }
            catch
            {
                try
                {
                    // Couldn't connect to the configured template DB, restore it now using EdFi's populated template
                    _databaseHelper.DownloadAndRestoreDatabase(Path.GetFullPath(Configuration.GetValue<string>("ODSImplementationFolderPath")));
                }
                catch (InvalidOperationException ex)
                {
                    if (isStrictMode.Value)
                    {
                        Assert.Fail(ex.Message);
                    }
                    else
                    {
                        Assert.Ignore(ex.Message);
                    }
                }
            }

            var prefix = $"{DatabaseCopyPrefix}_{Guid.NewGuid().ToString().Substring(0, 5)}";

            foreach (var odsToken in OdsTokens)
            {
                var dbCopyName = $"{prefix}_{odsToken}";
                _databaseHelper.CopyDatabase(connectionStringBuilder.DatabaseName, dbCopyName);

                if (OdsTokens.Length == 1)
                {
                    connectionStringBuilder.DatabaseName = dbCopyName;
                }
            }

            if (OdsTokens.Length > 1)
            {
                connectionStringBuilder.DatabaseName = $"{prefix}_{{0}}";
            }

            _dbCopyConnectionString = connectionStringBuilder.ConnectionString;
            Configuration.GetSection("ConnectionStrings").GetSection("EdFi_Ods").Value = _dbCopyConnectionString;
        }

        [OneTimeTearDown]
        public virtual async Task OneTimeTearDownAsync()
        {
            _databaseHelper.DropMatchingDatabases(DatabaseCopyPrefix + "%");
        }

        public IDbConnection BuildOdsConnection(string token = null) => BuildConnection(GetConnectionString(token));

        public string GetConnectionString(string token = null)
        {
            if (OdsTokens.Length > 1 && string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Specify a replacement token for the ODS database name.", paramName: nameof(token));
            }

            if (!string.IsNullOrEmpty(token) && !OdsTokens.Contains(token))
            {
                throw new ArgumentException("The specified ODS replacement token doesn't exist.", paramName: nameof(token));
            }

            return OdsTokens.Length > 1
                ? string.Format(_dbCopyConnectionString, token)
                : _dbCopyConnectionString;
        }

        private IDbConnection BuildConnection(string connectionString)
        {
            var connection = DatabaseEngine == DatabaseEngine.SqlServer ?
                (IDbConnection)new SqlConnection(connectionString)
                : new NpgsqlConnection(connectionString);

            connection.Open();
            return connection;
        }
    }
}