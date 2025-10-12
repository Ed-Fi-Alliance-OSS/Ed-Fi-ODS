// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using CommandLine;
using CommandLine.Text;
using EdFi.Common.Extensions;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EdFi.Ods.SandboxAdmin
{
    public class Program
    {
        private const int Error = 2;

        public static async Task Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            await result.MapResult(
                async (Options opts) =>
                {
                    ConfigureLogging(opts.CommandLineEnvironment.Equals("development", StringComparison.OrdinalIgnoreCase));

                    var host = Host.CreateDefaultBuilder(args)
                        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                        .ConfigureWebHostDefaults(
                            webBuilder =>
                            {
                                webBuilder.ConfigureKestrel(serverOptions => serverOptions.AddServerHeader = false);
                                webBuilder.UseSetting("ExitAfterSandboxCreation", opts.ExitAfterSandboxCreation.ToString());
                                webBuilder.UseStartup<Startup>();
                            }).Build();
                    
                    await host.RunAsync();
                },
                errors =>
                {
                    var helpText = HelpText.AutoBuild(
                        result, h => { return HelpText.DefaultParsingErrorsHandler(result, h); }, e => { return e; });
                    Environment.Exit(Error);
                    return Task.CompletedTask;
                });


            static void ConfigureLogging(bool isDevelopment)
            {
                var assembly = typeof(Program).GetTypeInfo().Assembly;

                string configPath = Path.Combine(
                    Path.GetDirectoryName(assembly.Location), isDevelopment
                        ? "log4net.development.config"
                        : "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }
        }
    }
}
