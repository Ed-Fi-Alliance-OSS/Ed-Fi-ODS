// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace EdFi.Ods.WebService.Tests
{
    [SetUpFixture]
    public class GlobalWebServiceFixture
    {
        public static IHost Host { get; private set; }

        [OneTimeSetUp]
        public async Task SetupAsync()
        {
            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebServiceFixture).Assembly.Location);
            ConfigureLogging(executableAbsoluteDirectory);

            // Create and start up the host
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                    (hostBuilderContext, configBuilder) =>
                    {
                        string appSettingsPath = Path.Combine(executableAbsoluteDirectory, "appsettings.json");

                        configBuilder.SetBasePath(executableAbsoluteDirectory)
                            .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables();
                    })
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
                var assembly = typeof(GlobalWebServiceFixture).GetTypeInfo().Assembly;

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

    public static class TestConstants
    {
        public const string BaseUrl = "http://localhost:49745/";
    }
}
#endif