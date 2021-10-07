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
using Test.Common;

namespace EdFi.Ods.Api.IntegrationTests
{
    [SetUpFixture]
    public class OneTimeGlobalDatabaseSetup
    {
        private const string TestDbPrefix = "EdFi_Integration_Test_";
        private const string ConfigEnvironmentVariablesPrefix = "EdFiOdsApiIntegrationTests_";

        private static DatabaseEngine DatabaseEngine { get; set; }
        private static string TestDbConnectionString { get; set; }

        private IDatabaseHelper _databaseHelper;
        private bool _isTestDbCreated;

        [OneTimeSetUp]
        public void Setup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables(ConfigEnvironmentVariablesPrefix); 

            var engine = configurationBuilder
                .Build()
                .GetValue<string>("Engine");
            DatabaseEngine = DatabaseEngine.TryParseEngine(engine);

            var configuration = configurationBuilder
                .AddJsonFile($"appsettings.{(DatabaseEngine == DatabaseEngine.SqlServer ? "mssql" : "pgsql")}.json", true)
                .AddEnvironmentVariables(ConfigEnvironmentVariablesPrefix)
                .Build();

            var isStrictMode = configuration.GetValue<bool?>("StrictMode");
            if (isStrictMode is null)
            {
                throw new ApplicationException(
                    "Missing configuration entry: StrictMode");
            }

            var maintenanceConnectionString = configuration.GetConnectionString("EdFi_Master");
            if (string.IsNullOrWhiteSpace(maintenanceConnectionString))
            {
                throw new ApplicationException(
                    $"Missing configuration entry: ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Master");
            }

            var odsConnectionString = configuration.GetConnectionString("EdFi_Ods");
            if (string.IsNullOrWhiteSpace(odsConnectionString))
            {
                throw new ApplicationException(
                    $"Missing configuration entry: ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Ods");
            }

            IDbConnectionStringBuilderAdapter connectionStringBuilder;

            if (DatabaseEngine == DatabaseEngine.SqlServer)
            {
                connectionStringBuilder = new SqlConnectionStringBuilderAdapter();
                _databaseHelper = new MsSqlDatabaseHelper(configuration);
            }
            else
            {
                connectionStringBuilder = new NpgsqlConnectionStringBuilderAdapter();
                _databaseHelper = new PgSqlDatabaseHelper(configuration);
            }

            try
            {
                BuildConnection(maintenanceConnectionString);
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
                BuildConnection(odsConnectionString);
            }
            catch
            {
                // TODO implement [ODS-5109 Download Test Database] here

                var reason = $"Couldn't open template database, verify ConnectionStrings{ConfigurationPath.KeyDelimiter}EdFi_Ods";
                if (isStrictMode.Value)
                {
                    Assert.Fail(reason);
                }
                else
                {
                    Assert.Ignore(reason);
                }
            }

            var testDbName = $"{TestDbPrefix}{Guid.NewGuid():N}";
            connectionStringBuilder.ConnectionString = odsConnectionString;

            _databaseHelper.CopyDatabase(connectionStringBuilder.DatabaseName, testDbName);
            _isTestDbCreated = true;

            connectionStringBuilder.DatabaseName = testDbName;
            TestDbConnectionString = connectionStringBuilder.ConnectionString;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (_isTestDbCreated)
            {
                _databaseHelper.DropMatchingDatabases(TestDbPrefix + "%");
            }
        }

        public static IDbConnection BuildConnection(string connectionString = null)
        {
            connectionString ??= TestDbConnectionString;

            var connection = DatabaseEngine == DatabaseEngine.SqlServer ?
                (IDbConnection)new SqlConnection(connectionString)
                : new NpgsqlConnection(connectionString);

            connection.Open();
            return connection;
        }
    }
}