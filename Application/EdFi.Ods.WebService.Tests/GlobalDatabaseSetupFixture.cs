// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebService.Tests
{
    [SetUpFixture]
    public class GlobalDatabaseSetupFixture
    {
        private const string DatabasePrefix = "EdFi_Integration_Test_";
        private static readonly string Suffix = "_" + Guid.NewGuid()
                                                          .ToString("N");

        static GlobalDatabaseSetupFixture()
        {
            PopulatedTemplateDatabaseName = ConfigurationManager.AppSettings["GlobalDatabaseSetupFixture.TestDatabaseTemplateName"];

            PopulatedDatabaseName = DatabasePrefix + PopulatedTemplateDatabaseName + Suffix;

            var testConnectionStringPrototype =
                new SqlConnectionStringBuilder(
                    ConfigurationManager.ConnectionStrings["EdFi_Ods"]
                                        .ConnectionString)
                {
                    InitialCatalog = PopulatedDatabaseName
                };

            PopulatedDatabaseConnectionString = testConnectionStringPrototype.ConnectionString;
            SpecFlowDatabaseName = DatabasePrefix + "SpecFlow" + PopulatedTemplateDatabaseName + Suffix;
            testConnectionStringPrototype.InitialCatalog = SpecFlowDatabaseName;
            SpecFlowDatabaseConnectionString = testConnectionStringPrototype.ConnectionString;
        }

        // templates
        public static string PopulatedTemplateDatabaseName { get; }

        // database copies for test
        public static string PopulatedDatabaseName { get; }

        public static string PopulatedDatabaseConnectionString { get; }

        // Setting up special separate database for SpecFlow tests due to transactions not working properly with the way its set up
        public static string SpecFlowDatabaseName { get; }

        public static string SpecFlowDatabaseConnectionString { get; }

        [OneTimeSetUp]
        public void Setup()
        {
            if (string.IsNullOrWhiteSpace(PopulatedTemplateDatabaseName))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid source database name is provided in the App Setting \"GlobalDatabaseSetupFixture.TestDatabaseTemplateName\"");
            }

            var databaseHelper = new DatabaseHelper();
            databaseHelper.CopyDatabase(PopulatedTemplateDatabaseName, PopulatedDatabaseName);
            databaseHelper.CopyDatabase(PopulatedTemplateDatabaseName, SpecFlowDatabaseName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseHelper = new DatabaseHelper();
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
