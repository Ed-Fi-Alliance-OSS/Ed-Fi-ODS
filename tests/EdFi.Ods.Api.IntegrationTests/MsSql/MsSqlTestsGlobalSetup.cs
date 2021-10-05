// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Test.Common;

namespace EdFi.Ods.Api.IntegrationTests.MsSql
{
    [SetUpFixture]
    public class MsSqlTestsGlobalSetup
    {
        private const string TestDbPrefix = "EdFi_Integration_Test_";

        private static string TestDbConnectionString { get; set; }
        public static string TestFailedReason { get; private set; }
        public static string TestDisabledReason { get; private set; }

        private IConfigurationRoot _configuration;
        private DatabaseHelper _databaseHelper;
        private bool _isTestDbCreated;

        [OneTimeSetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.mssql.json", optional: true)
                .Build();

            _databaseHelper = new DatabaseHelper(_configuration);

            var maintenanceConnectionString = _configuration.GetConnectionString("EdFi_Master");
            if (string.IsNullOrWhiteSpace(maintenanceConnectionString))
            {
                throw new ApplicationException(
                    "Missing configuration entry: appsettings.mssql.json/ConnectionStrings/EdFi_Master");
            }

            var odsConnectionString = _configuration.GetConnectionString("EdFi_Ods");
            if (string.IsNullOrWhiteSpace(odsConnectionString))
            {
                throw new ApplicationException(
                    "Missing configuration entry: appsettings.mssql.json/ConnectionStrings/EdFi_Ods");
            }

            var testMode = _configuration.GetValue<string>("TestMode");
            if (testMode is null)
            {
                throw new ApplicationException(
                    "Missing or invalid configuration entry: appsettings.json/TestMode");
            }

            var engines = _configuration
                .GetSection("Engines")
                .GetChildren()
                .Select(engine => engine.Value);

            if (engines.All(engine => engine != "SQLServer"))
            {
                TestDisabledReason = "SQLServer isn't present in appsettings.json/Engines";
                return;
            }

            try
            {
                using var conn = new SqlConnection(maintenanceConnectionString);
                conn.Open();
            }
            catch
            {
                // TODO implement [ODS-5110 Create Test Container] here

                var reason =
                    "Couldn't connect to SQLServer server, verify appsettings.mssql.json/ConnectionStrings/EdFi_Master";
                if (testMode == "Strict")
                {
                    TestFailedReason = reason;
                }
                else
                {
                    TestDisabledReason = reason;
                }
                return;
            }

            try
            {
                using var conn = new SqlConnection(odsConnectionString);
                conn.Open();
            }
            catch
            {
                // TODO implement [ODS-5109 Download Test Database] here

                var reason = "Couldn't open template database, verify appsettings.mssql.json/ConnectionStrings/EdFi_Ods";
                if (testMode == "Strict")
                {
                    TestFailedReason = reason;
                }
                else
                {
                    TestDisabledReason = reason;
                }
                return;
            }

            var testDbName = $"{TestDbPrefix}{Guid.NewGuid():N}";
            var connectionStringBuilder = new SqlConnectionStringBuilder { ConnectionString = odsConnectionString };

            _databaseHelper.CopyDatabase(connectionStringBuilder.InitialCatalog, testDbName);
            _isTestDbCreated = true;

            connectionStringBuilder.InitialCatalog = testDbName;
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

        public static IDbConnection BuildConnection()
        {
            var connection = new SqlConnection(TestDbConnectionString);
            connection.Open();
            return connection;
        }
    }
}