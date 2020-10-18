// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [SetUpFixture]
    public class GlobalWebApiIntegrationTestFixture
    {
        public static string DatabasePrefix = "EdFi_IntegrationTests_";
        public static IHost SandboxHost { get; set; }

        public static IHost YearSpecificHost { get; set; }

        public static string DatabaseName { get; set; }

        public static DatabaseHelper DatabaseHelper { get; private set; }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            DatabaseName = DatabasePrefix + Guid.NewGuid().ToString("N");

            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebApiIntegrationTestFixture).Assembly.Location);
            ConfigureLogging(executableAbsoluteDirectory);

            // Create and start up the host
            CreateSandboxHost();

            CreateYearSpecificHost();

            CreateDatabases();

            await SandboxHost.StartAsync();
            await YearSpecificHost.StartAsync();

            static void ConfigureLogging(string executableAbsoluteDirectory)
            {
                var assembly = typeof(GlobalWebApiIntegrationTestFixture).GetTypeInfo().Assembly;

                string configPath = Path.Combine(executableAbsoluteDirectory, "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }

            static void CreateSandboxHost()
            {
                SandboxHost = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureWebHostDefaults(
                        webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                            webBuilder.UseUrls(TestConstants.BaseUrl);
                        })
                    .Build();
            }

            void CreateYearSpecificHost()
            {
                YearSpecificHost = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration(
                        (hostBuilderContext, configBuilder) =>
                        {
                            configBuilder.SetBasePath(executableAbsoluteDirectory)
                                .AddJsonFile(Path.Combine(executableAbsoluteDirectory, "appsettings.json"))
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
            }

            void CreateDatabases()
            {
                var configuration = (IConfigurationRoot) SandboxHost.Services.GetService(typeof(IConfiguration));

                var populatedTemplateDatabaseName = configuration.GetSection("TestDatabaseTemplateName").Value;

                if (string.IsNullOrWhiteSpace(populatedTemplateDatabaseName))
                {
                    throw new ApplicationException(
                        "Invalid configuration for integration tests. Verify a valid source database name is provided in the App Setting \"TestDatabaseTemplateName\"");
                }

                DatabaseHelper = new DatabaseHelper(configuration);

                // sandbox databases
                DatabaseHelper.CopyDatabase(populatedTemplateDatabaseName, DatabaseName);

                // year specific databases
                DatabaseHelper.CopyDatabase(populatedTemplateDatabaseName, $"{DatabaseName}_2014");
                DatabaseHelper.CopyDatabase(populatedTemplateDatabaseName, $"{DatabaseName}_2015");
            }
        }

        [OneTimeTearDown]
        public async Task TearDownAsync()
        {
            await SandboxHost.StopAsync();
            SandboxHost.Dispose();

            await YearSpecificHost.StopAsync();
            YearSpecificHost.Dispose();

            DatabaseHelper?.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}
