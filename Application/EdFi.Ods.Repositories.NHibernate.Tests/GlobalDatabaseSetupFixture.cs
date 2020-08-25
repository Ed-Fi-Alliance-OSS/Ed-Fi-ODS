// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [SetUpFixture]
    public class GlobalDatabaseSetupFixture
    {
        private const string DatabasePrefix = "EdFi_Integration_Test_";
        private static IConfigurationRoot _configuration;

        static GlobalDatabaseSetupFixture()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            PopulatedDatabaseName = _configuration.GetSection("GlobalDatabaseSetupFixture").GetSection("TestDatabaseTemplateName").Value ?? "EdFi_Ods_Populated_Template_Test";

            TestPopulatedDatabaseName = DatabasePrefix + Guid.NewGuid().ToString("N");
        }

        public static string PopulatedDatabaseName { get; set; }

        public static string TestPopulatedDatabaseName { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            if (string.IsNullOrWhiteSpace(PopulatedDatabaseName))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid source database name is provided in the App Setting \"GlobalDatabaseSetupFixture.TestDatabaseTemplateName\"");
            }

            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.CopyDatabase(PopulatedDatabaseName, TestPopulatedDatabaseName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
#endif