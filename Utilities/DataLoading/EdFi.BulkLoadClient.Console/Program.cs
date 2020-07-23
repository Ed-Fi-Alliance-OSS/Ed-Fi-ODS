// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using EdFi.BulkLoadClient.Console.Application;
using log4net;
using log4net.Config;

namespace EdFi.BulkLoadClient.Console
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(Program));

        private static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            //BasicConfigurator.Configure();
            var p = new CommandLineParser();

            p.SetupHelp("?", "Help").Callback(
                text =>
                {
                    System.Console.WriteLine(text);
                    Environment.Exit(0);
                });

            var result = p.Parse(args);

            if (result.HasErrors || !p.Object.IsValid)
            {
                _log.Error(result.ErrorText);
                _log.Error(p.Object.ErrorText);

                Environment.ExitCode = 1;
                Environment.Exit(Environment.ExitCode);
            }

            try
            {
                Environment.ExitCode = LoadTools.BulkLoadClient.LoadProcess.Run(p.Object);
            }
            catch (AggregateException ex)
            {
                Environment.ExitCode = 1;

                foreach (var e in ex.InnerExceptions)
                {
                    _log.Error(e);
                }
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
    }
}
