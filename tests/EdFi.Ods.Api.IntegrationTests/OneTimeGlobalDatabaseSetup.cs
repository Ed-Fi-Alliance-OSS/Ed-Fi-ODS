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

        public static string SqlServerConnectionString { get; private set; }
        public static string PostgreSqlConnectionString { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var sqlServerConnectionString = _configuration.GetConnectionString("EdFi_Ods");

            if (string.IsNullOrWhiteSpace(sqlServerConnectionString))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid sql server connection string for 'EdFi_Ods'");
            }

            var connectionStringBuilder = new DbConnectionStringBuilder {ConnectionString = sqlServerConnectionString };
            var sourceDatabaseName = connectionStringBuilder["Database"] as string;
            var testDatabaseName = $"{DatabasePrefix}{Guid.NewGuid():N}";

            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.CopyDatabase(sourceDatabaseName, testDatabaseName);

            connectionStringBuilder["Database"] = testDatabaseName;
            SqlServerConnectionString = connectionStringBuilder.ConnectionString;

            PostgreSqlConnectionString = _configuration.GetConnectionString("EdFi_Ods_Manual_PostgreSQL");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
