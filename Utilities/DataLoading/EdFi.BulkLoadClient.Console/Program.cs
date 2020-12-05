// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using EdFi.BulkLoadClient.Console.Application;
using EdFi.BulkLoadClient.Console.Modules;
using EdFi.LoadTools.BulkLoadClient;
using EdFi.LoadTools.Engine;
using log4net;
using log4net.Config;

namespace EdFi.BulkLoadClient.Console
{
    public static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(Program));

        private static async Task Main(string[] args)
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
                var container = RegisterContainer();
                await using var scope = container.BeginLifetimeScope();

                var loadProcess = container.Resolve<ILoadProcess>();

                Environment.ExitCode = await loadProcess.Run();
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

            ILifetimeScope RegisterContainer()
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(p.Object)
                    .As<IApiConfiguration>()
                    .As<IHashCacheConfiguration>()
                    .As<IDataConfiguration>()
                    .As<IOAuthTokenConfiguration>()
                    .As<IApiMetadataConfiguration>()
                    .As<IXsdConfiguration>()
                    .As<IInterchangeOrderConfiguration>()
                    .As<IThrottleConfiguration>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterModule(new LoadToolsModule());

                if (p.Object.IncludeStats)
                {
                    builder.RegisterModule(new IncludeStatsModule());
                }

                return builder.Build();
            }
        }
    }
}
