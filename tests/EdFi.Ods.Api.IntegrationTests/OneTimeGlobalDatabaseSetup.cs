using System;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Api.IntegrationTests
{
    [SetUpFixture]
    public class OneTimeGlobalDatabaseSetup
    {
        private const string DatabasePrefix = "EdFi_Integration_Test_";

        private IConfigurationRoot _configuration;

        public static string ConnectionString { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = _configuration.GetConnectionString("EdFi_Ods");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid connection string for 'EdFi_Ods'");
            }

            var connectionStringBuilder = new DbConnectionStringBuilder {ConnectionString = connectionString};
            var sourceDatabaseName = connectionStringBuilder["Database"] as string;
            var testDatabaseName = $"{DatabasePrefix}{Guid.NewGuid():N}";

            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.CopyDatabase(sourceDatabaseName, testDatabaseName);

            connectionStringBuilder["Database"] = testDatabaseName;
            ConnectionString = connectionStringBuilder.ConnectionString;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
