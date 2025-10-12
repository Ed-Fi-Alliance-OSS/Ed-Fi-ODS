// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using log4net.Config;
using log4net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace EdFi.Ods.Api.IntegrationTestHarness
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var _logger = LogManager.GetLogger(typeof(Program));
            _logger.Debug("Loading configuration files");

            ConfigureLogging();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName);
                    })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            await host.RunAsync();

            static void ConfigureLogging()
            {
                var assembly = typeof(Program).GetTypeInfo().Assembly;

                string configPath = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).FullName, "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }
        }
    }
}
