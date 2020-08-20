// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Net;
using CommandLine;
using CommandLine.Text;
using log4net;
using log4net.Config;

namespace EdFi.SdkGen.Console
{
    internal static class Program
    {
        private const int Success = 0;
        private const int ParseError = 1;
        private const int Error = 2;
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        private static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            ConfigureTls();
                  
            var result = Parser.Default.ParseArguments<Options>(args);           

            result.WithParsed(options =>
            {
                try
                {
                    var cliUpdater = new SwaggerCodgenCliUpdater(options);
                    var cliRunner = new SwaggerCodeGenCliRunner(options);

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

        /// <summary>
        /// Explicitly configures all outgoing network calls to use the latest version of TLS where possible.
        /// c.f https://docs.microsoft.com/en-us/dotnet/framework/network-programming/tls
        /// </summary>
        private static void ConfigureTls()
        {
            // TLS 1.2 is not available by default for version of the frameworks less that .NET 4.6.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
