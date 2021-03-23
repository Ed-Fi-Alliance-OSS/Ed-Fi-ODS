// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using CommandLine;
using EdFi.BulkLoadClient.Console.Application;
using EdFi.LoadTools.BulkLoadClient;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;

namespace EdFi.BulkLoadClient.Console
{
    public static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(Program));

        private static async Task Main(string[] args)
        {
            ConfigureLogging();

            CommandLineOverrides commandLineOverrides = null;

            var parser = new Parser(
                    config =>
                    {
                        config.CaseInsensitiveEnumValues = true;
                        config.CaseSensitive = false;
                        config.HelpWriter = System.Console.Out;
                        config.IgnoreUnknownArguments = true;
                    })
                .ParseArguments<CommandLineOverrides>(args)
                .WithParsed(overrides => commandLineOverrides = overrides)
                .WithNotParsed(
                    errs =>
                    {
                        if (errs.IsHelp())
                        {
                            Environment.ExitCode = 0;
                            Environment.Exit(Environment.ExitCode);
                        }

                        System.Console.WriteLine("Invalid options were entered.");
                        System.Console.WriteLine(errs.ToString());
                        Environment.ExitCode = 1;
                        Environment.Exit(Environment.ExitCode);
                    });

            try
            {
                var configRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddCommandLine(args, CommandLineOverrides.SwitchingMapping())
                    .Build();

                // apply the command line args overrides for boolean values
                if (args.Contains("--include-stats"))
                {
                    configRoot["IncludeStats"] = "true";
                }

                if (args.Contains("--novalidation") || args.Contains("-n"))
                {
                    configRoot["ValidateSchema"] = "false";
                }

                if (args.Contains("--force") || args.Contains("-f"))
                {
                    configRoot["ForceMetadata"] = "true";
                }

                Environment.ExitCode = await LoadProcess.Run(configRoot);
            }
            catch (Exception ex)
            {
                Environment.ExitCode = 1;
                _log.Error(ex);
            }
            finally
            {
                _log.Info($"Exit Code is {Environment.ExitCode}");

                if (Debugger.IsAttached)
                {
                    System.Console.WriteLine("Press enter to continue.");
                    System.Console.ReadLine();
                }

                Environment.Exit(Environment.ExitCode);
            }
        }

        static void ConfigureLogging()
        {
            var assembly = typeof(Program).GetType().Assembly;

            string configPath = Path.Combine(Path.GetDirectoryName(AppContext.BaseDirectory), "log4net.config");

            XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
        }
    }
}
