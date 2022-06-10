// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using EdFi.Common.Configuration;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [SetUpFixture]
    public class CompositesSpecFlowTestFixture
    {
        public const string DatabasePrefix = "EdFi_Specflow_Test_";

        public static IHost Host { get; private set; }

        public static IDatabaseHelper DatabaseHelper { get; private set; }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static string SpecFlowDatabaseName { get; private set; }

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            SpecFlowDatabaseName = DatabasePrefix + Guid.NewGuid().ToString("N");

            var executableAbsoluteDirectory = AppContext.BaseDirectory;
            ConfigureLogging(executableAbsoluteDirectory);

            var databaseEngine = DbHelper.GetDatabaseEngine();
            
            // Create and start up the host
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(configurationBuilder => {
                    configurationBuilder.SetBasePath(TestContext.CurrentContext.TestDirectory);
                    configurationBuilder.AddJsonFile($"appsettings.{(databaseEngine == DatabaseEngine.SqlServer ? "mssql" : "pgsql")}.json", true);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(CompositesTestConstants.BaseUrl);
                    })
                .Build();

            ServiceProvider = Host.Services;
            
            var configuration = (IConfigurationRoot) ServiceProvider.GetService(typeof(IConfiguration));

            var populatedTemplateDatabaseName = configuration.GetSection("TestDatabaseTemplateName").Value;

            if (string.IsNullOrWhiteSpace(populatedTemplateDatabaseName))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests. Verify a valid source database name is provided in the App Setting \"TestDatabaseTemplateName\"");
            }

            
            
            if (databaseEngine == DatabaseEngine.SqlServer)
            {
                DatabaseHelper = new MsSqlDatabaseHelper(configuration);
            }
            else
            {
                DatabaseHelper = new PgSqlDatabaseHelper(configuration);
            }
            
            DatabaseHelper.CopyDatabase(populatedTemplateDatabaseName, SpecFlowDatabaseName);

            await Host.StartAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDownAsync()
        {
            await Host?.StopAsync();
            Host?.Dispose();

            DatabaseHelper?.DropMatchingDatabases(DatabasePrefix + "%");
        }

        private static void ConfigureLogging(string executableAbsoluteDirectory)
        {
            var assembly = typeof(CompositesSpecFlowTestFixture).GetTypeInfo().Assembly;

            string configPath = Path.Combine(executableAbsoluteDirectory, "log4net.config");

            XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
        }
    }
}
