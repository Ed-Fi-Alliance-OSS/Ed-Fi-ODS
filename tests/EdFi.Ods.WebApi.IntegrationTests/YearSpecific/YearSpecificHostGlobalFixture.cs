// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using EdFi.Common.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.YearSpecific
{
    [SetUpFixture]
    public class YearSpecificHostGlobalFixture
    {
        private IDatabaseHelper _databaseHelper;

        public static IHost Host { get; set; }

        public static IConfiguration Configuration { get; private set; }

        public static HttpClient HttpClient { get; private set; }

        [OneTimeSetUp]
        public async Task OneTimeStartup()
        {
            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebApiIntegrationTestFixture).Assembly.Location);
            var databaseEngine = DbHelper.GetDatabaseEngine();

            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                    (hostBuilderContext, configBuilder) =>
                    {
                        configBuilder.SetBasePath(executableAbsoluteDirectory)
                            .AddJsonFile(Path.Combine(executableAbsoluteDirectory, $"appsettings.{(databaseEngine == DatabaseEngine.SqlServer ? "mssql" : "pgsql")}.json"), true)
                            .AddJsonFile(Path.Combine(executableAbsoluteDirectory, "appsettings.yearspecific.json"));
                    })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.YearSpecificBaseUrl);
                    })
                .Build();

            Configuration = (IConfiguration) Host.Services.GetService(typeof(IConfiguration));

            HttpClient = new HttpClient {BaseAddress = new Uri(TestConstants.YearSpecificBaseUrl)};

            CreateDatabases();

            await Host.StartAsync(GlobalWebApiIntegrationTestFixture.CancellationToken);

            void CreateDatabases()
            {
                string populatedTemplateDatabaseName = Configuration.GetValue<string>("TestDatabaseTemplateName");

                if (string.IsNullOrWhiteSpace(populatedTemplateDatabaseName))
                {
                    throw new ApplicationException(
                        "Invalid configuration for integration tests. Verify a valid source database name is provided in the App Setting \"TestDatabaseTemplateName\"");
                }

                if (databaseEngine == DatabaseEngine.SqlServer)
                {
                    _databaseHelper = new MsSqlDatabaseHelper((IConfigurationRoot)Configuration);
                }
                else
                {
                    _databaseHelper = new PgSqlDatabaseHelper((IConfigurationRoot)Configuration);
                }

                // year specific databases
                _databaseHelper.CopyDatabase(
                    populatedTemplateDatabaseName, $"{GlobalWebApiIntegrationTestFixture.DatabaseName}_2014");

                _databaseHelper.CopyDatabase(
                    populatedTemplateDatabaseName, $"{GlobalWebApiIntegrationTestFixture.DatabaseName}_2015");
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            HttpClient.Dispose();

            await Host?.StopAsync();
            Host?.Dispose();

            _databaseHelper.DropMatchingDatabases($"{GlobalWebApiIntegrationTestFixture.DatabaseName}_2014");
            _databaseHelper.DropMatchingDatabases($"{GlobalWebApiIntegrationTestFixture.DatabaseName}_2015");
        }
    }
}
