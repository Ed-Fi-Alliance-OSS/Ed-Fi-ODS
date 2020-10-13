// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [SetUpFixture]
    public class GlobalWebApiIntegrationTestFixture
    {
        public static IHost Host { get; private set; }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebApiIntegrationTestFixture).Assembly.Location);
            ConfigureLogging(executableAbsoluteDirectory);

            // Create and start up the host
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.BaseUrl);
                    })
                .Build();

            await Host.StartAsync();

            static void ConfigureLogging(string executableAbsoluteDirectory)
            {
                var assembly = typeof(GlobalWebApiIntegrationTestFixture).GetTypeInfo().Assembly;

                string configPath = Path.Combine(executableAbsoluteDirectory, "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }
        }

        [OneTimeTearDown]
        public async Task TearDownAsync()
        {
            await Host.StopAsync();
            Host.Dispose();
        }
    }
}