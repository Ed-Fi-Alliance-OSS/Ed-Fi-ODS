// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using CommandLine;
using CommandLine.Text;
using log4net;
using log4net.Config;

namespace EdFi.SdkGen.Console
{
    internal static class Program
    {
        private const int Success = 0;
        private const int Error = 2;
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        private static void Main(string[] args)
        {
            ConfigureLogging();

            var result = Parser.Default.ParseArguments<Options>(args);

            result.WithParsed(options =>
            {
                try
                {
                    var cliUpdater = new OpenApiCodgenCliUpdater(options);
                    var cliRunner = new OpenApiCodeGenCliRunner(options);

                    cliUpdater.Run();
                    cliRunner.Run();
                }
                catch (Exception e)
                {
                    _log.Error(e);
                    Environment.Exit(Error);
                }
                Environment.Exit(Success);
            });

            result.WithNotParsed(errs =>
            {
                var helpText = HelpText.AutoBuild(result, h =>
                {
                    return HelpText.DefaultParsingErrorsHandler(result, h);
                }, e =>
                {
                    return e;
                });
                _log.Info(helpText);
            });
        }

        private static void ConfigureLogging()
        {
            var assembly = typeof(Program).GetTypeInfo().Assembly;

            string configPath = Path.Combine(Path.GetDirectoryName(assembly.Location), "log4net.config");

            XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
        }
    }
}
