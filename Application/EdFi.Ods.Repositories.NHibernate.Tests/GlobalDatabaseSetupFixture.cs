// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using EdFi.Common.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [SetUpFixture]
    public class GlobalDatabaseSetupFixture
    {
        private const string DatabasePrefix = "EdFi_Integration_Test_";

        public static string PopulatedDatabaseName { get; set; }

        public static string TestPopulatedDatabaseName { get; set; }

        public IConfigurationRoot Configuration { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var databaseEngine = DbHelper.GetDatabaseEngine();

            Configuration = DbHelper.GetDatabaseEngineSpecificConfiguration(databaseEngine);

            PopulatedDatabaseName = Configuration.GetSection("TestDatabaseTemplateName").Value ??
                                    "EdFi_Ods_Populated_Template_Test";

            TestPopulatedDatabaseName = DatabasePrefix + Guid.NewGuid().ToString("N");

            if (string.IsNullOrWhiteSpace(PopulatedDatabaseName))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid source database name is provided in the App Setting \"TestDatabaseTemplateName\"");
            }

            IDatabaseHelper databaseHelper = databaseEngine == DatabaseEngine.SqlServer? new MsSqlDatabaseHelper(Configuration): new PgSqlDatabaseHelper(Configuration);
            databaseHelper.CopyDatabase(PopulatedDatabaseName, TestPopulatedDatabaseName);

            Assembly.Load("EdFi.Ods.Common");
            Assembly.Load("EdFi.Ods.Standard");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseEngine = DbHelper.GetDatabaseEngine();
            IDatabaseHelper databaseHelper = databaseEngine == DatabaseEngine.SqlServer ? new MsSqlDatabaseHelper(Configuration) : new PgSqlDatabaseHelper(Configuration);
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
