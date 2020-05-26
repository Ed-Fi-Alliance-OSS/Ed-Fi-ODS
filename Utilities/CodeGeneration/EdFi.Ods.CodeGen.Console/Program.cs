// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using CommandLine;
using EdFi.Ods.CodeGen.Console._Installers;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.Common.InversionOfControl;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.CodeGen.Console
{
    internal class Program
    {
        private static readonly IWindsorContainer _container = new WindsorContainer();
        private static IServiceProvider _serviceProvider;
        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private static ILogger _logger = NullLogger.Instance;

        private static async Task<int> Main(string[] args)
        {
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
                        System.Console.WriteLine("Invalid options were entered.");
                        System.Console.WriteLine(errs.ToString());
                        result = ReturnCodesConventions.Error;
                    });

            if (result != ReturnCodesConventions.Success)
            {
                return result;
            }

            _serviceProvider = CreateServiceProvider(new ServiceCollection(), options);

            _logger = _serviceProvider.GetService<ILogger>();

            System.Console.CancelKeyPress += (o, e) =>
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
                await _serviceProvider.GetService<IApplicationRunner>().RunAsync(cancellationToken).ConfigureAwait(false);

                stopwatch.Stop();

                _logger.Info($"Finished code generation in {stopwatch.Elapsed.ToString()}.");

                return ReturnCodesConventions.Success;
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());

                return ReturnCodesConventions.Error;
            }
            finally
            {
                _container.Dispose();
                if (Debugger.IsAttached)
                {
                    System.Console.WriteLine("Press enter to continue.");
                    System.Console.ReadLine();
                }
            }
        }

        private static IServiceProvider CreateServiceProvider(IServiceCollection serviceCollection, Options options)
        {
            InstallSubResolvers();
            InstallFacilities();

            _container.Install(new CodeGenInstaller(), new CommandLineOverrideInstaller(options));

            return WindsorRegistrationHelper.CreateServiceProvider(_container, serviceCollection);
        }

        private static void InstallSubResolvers()
        {
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
        }

        private static void InstallFacilities()
        {
            // Add logging to the container
            _container.AddFacility<LoggingFacility>(f => f.LogUsing<ExtendedLog4netFactory>().WithConfig("log4net.config"));

            _container.AddFacility<DatabaseConnectionStringProviderFacility>();
        }
    }
}
