// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.Sandbox
{
    [SetUpFixture]
    public class SandboxHostGlobalFixture
    {
        private DatabaseHelper _databaseHelper;

        public static IHost Host { get; set; }

        public static IConfiguration Configuration { get; private set; }

        public static HttpClient HttpClient { get; private set; }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.SandboxBaseUrl);
                    })
                .Build();

            Configuration = (IConfiguration) Host.Services.GetService(typeof(IConfiguration));

            CreateDatabase();

            await Host.StartAsync(GlobalWebApiIntegrationTestFixture.CancellationToken);

            HttpClient = new HttpClient {BaseAddress = new Uri(TestConstants.SandboxBaseUrl)};

            void CreateDatabase()
            {
                var populatedTemplateDatabaseName = Configuration.GetValue<string>("TestDatabaseTemplateName");

                if (string.IsNullOrWhiteSpace(populatedTemplateDatabaseName))
                {
                    throw new ApplicationException(
                        "Invalid configuration for integration tests. Verify a valid source database name is provided in the App Setting \"TestDatabaseTemplateName\"");
                }

                _databaseHelper = new DatabaseHelper((IConfigurationRoot) Configuration);

                // sandbox databases
                _databaseHelper.CopyDatabase(populatedTemplateDatabaseName, GlobalWebApiIntegrationTestFixture.DatabaseName);
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            HttpClient?.Dispose();

            await Host?.StopAsync();
            Host?.Dispose();

            _databaseHelper.DropDatabase(GlobalWebApiIntegrationTestFixture.DatabaseName);
        }
    }
}
