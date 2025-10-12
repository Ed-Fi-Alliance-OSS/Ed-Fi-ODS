// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EdFi.Ods.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string startupClassName;

            using (var hostBuilderInitial = Host.CreateDefaultBuilder(args).Build())
            {
                var config = hostBuilderInitial.Services.GetService<IConfiguration>();
                startupClassName = config.GetValue<string>("StartupClassName");

                AssemblyLoaderHelper.LoadAssembliesFromFolder(
                    AssemblyLoaderHelper.GetPluginFolder(
                        config?.GetValue<string>("Plugin:Folder") ?? string.Empty));
            }

            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(ConfigureLogging)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.ConfigureKestrel(
                            serverOptions => { serverOptions.AddServerHeader = false; });

                        if (string.IsNullOrEmpty(startupClassName) || startupClassName.EqualsIgnoreCase("Startup"))
                        {
                            webBuilder.UseStartup<Startup>();
                        }
                        else
                        {
                            var startupFactory = new StartupFactory(startupClassName);
                            webBuilder.UseStartup(context => startupFactory.Create(context));
                        }
                    });

            await ConfigureHostUsingPlugins();

            var host = hostBuilder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            await host.RunAsync();

            static void ConfigureLogging(HostBuilderContext hostBuilderContext, ILoggingBuilder loggingBuilder)
            {
                var loggingOptions = hostBuilderContext.Configuration.GetSection("Log4NetCore")
                    .Get<Log4NetProviderOptions>()
                    ?? new Log4NetProviderOptions
                    {
                        Log4NetConfigFileName = hostBuilderContext.HostingEnvironment.IsDevelopment()
                            ? "log4net.development.config"
                            : "log4net.config"
                    };

                loggingBuilder.AddLog4Net(loggingOptions);
            }

            async Task ConfigureHostUsingPlugins()
            {
                var hostConfigurationActivities = TypeHelper.GetAssemblyTypes<IHostConfigurationActivity>();

                foreach (Type hostConfigurationActivity in hostConfigurationActivities)
                {
                    try
                    {
                        var plugin = (IHostConfigurationActivity) Activator.CreateInstance(hostConfigurationActivity);
                        plugin!.ConfigureHost(hostBuilder);
                    }
                    catch (Exception ex)
                    {
                        await Console.Error.WriteLineAsync($"Error occured during host configuration activity '{hostConfigurationActivity.Name}': {ex}");
                    }
                }
            }
        }
    }
}
