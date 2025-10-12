// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EdFi.Ods.SwaggerUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string startupClassName;

            using (var hostBuilderInitial = Host.CreateDefaultBuilder(args).Build())
            {
                var config = hostBuilderInitial.Services.GetService<IConfiguration>();
                startupClassName = config.GetValue<string>("SwaggerUIOptions:StartupClassName");

                AssemblyLoaderHelper.LoadAssembliesFromFolder(
                    AssemblyLoaderHelper.GetPluginFolder(
                        config.GetValue<string>("Plugin:Folder") ?? string.Empty));
            }

            var hostBuilder = Host.CreateDefaultBuilder(args)
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
                            webBuilder.UseStartup(context => startupFactory.CreateStartup(context));
                        }
                    });

            await hostBuilder.Build().RunAsync();
        }
    }
}
