// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommandLine;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Modules;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.CodeGen
{
    internal static class Program
    {
        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private static ILog _logger;
        private static IContainer _container;

        private static async Task<int> Main(string[] args)
        {
            ConfigureLogging();

            int result = ReturnCodesConventions.Success;

            Options options = null;

            new Parser(
                    config =>
                    {
                        config.CaseInsensitiveEnumValues = true;
                        config.CaseSensitive = false;
                    }).ParseArguments<Options>(args)
                .WithParsed(opts => options = opts)
                .WithNotParsed(
                    errs =>
                    {
                        Console.WriteLine("Invalid options were entered.");
                        Console.WriteLine(errs.ToString());
                        result = ReturnCodesConventions.Error;
                    });

            if (result != ReturnCodesConventions.Success)
            {
                return result;
            }

            CreateServiceProvider(new ServiceCollection(), options);

            _logger = LogManager.GetLogger(typeof(Program));

            Console.CancelKeyPress += (o, e) =>
            {
                _logger.Warn("Ctrl-C Pressed. Stopping all threads.");
                _cancellationTokenSource.Cancel();
                e.Cancel = true;
            };

            var cancellationToken = _cancellationTokenSource.Token;

            var stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();

                _logger.Info("Starting code generation.");

                await _container.Resolve<IApplicationRunner>()
                    .RunAsync(cancellationToken)
                    .ConfigureAwait(false);

                stopwatch.Stop();

                _logger.Info($"Finished code generation in {stopwatch.Elapsed.ToString()}.");

                return ReturnCodesConventions.Success;
            }
            catch (Exception e)
            {
                _logger.Info(e.ToString());

                return ReturnCodesConventions.Error;
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }

                _container?.Dispose();
            }

            static void ConfigureLogging()
            {
                var assembly = typeof(Program).GetTypeInfo()
                    .Assembly;

                string configPath = Path.Combine(Path.GetDirectoryName(assembly.Location), "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }

            static void CreateServiceProvider(IServiceCollection serviceCollection, Options options)
            {
                serviceCollection.AddConfiguration();

                var containerBuilder = new ContainerBuilder();

                containerBuilder.RegisterModule(new CodeGenModule());
                containerBuilder.RegisterModule(new CommandLineOverrideModule {Options = options});

                containerBuilder.Populate(serviceCollection);

                _container = containerBuilder.Build();
            }
        }
    }
}
