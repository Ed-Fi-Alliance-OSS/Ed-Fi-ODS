// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.SmokeTest.Console.Application;
using log4net;
using log4net.Config;

namespace EdFi.SmokeTest.Console
{
    public partial class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        private static async Task Main(string[] args)
        {
            XmlConfigurator.Configure();
            ConfigureTls();

            var parser = new CommandLineParser();
            var parseResult = parser.Parse(args);

            if (parseResult.HasErrors || !parser.Object.IsValid)
            {
                System.Console.Write(parseResult.ErrorText);
                System.Console.Write(parser.Object.ErrorText);
            }
            else if (!parseResult.HelpCalled)
            {
                try
                {
                    var container = RegisterContainer();
                    await using var scope = container.BeginLifetimeScope();

                    var application = container.Resolve<ISmokeTestApplication>();

                    Environment.ExitCode = await application.Run();
                }
                catch (AggregateException ex)
                {
                    foreach (var e in ex.InnerExceptions)
                    {
                        Log.Error(e);
                    }

                    Environment.ExitCode = 1;
                }
                catch (Exception e)
                {
                    Log.Error(e);
                    Environment.ExitCode = 1;
                }
                finally
                {
                    Log.Info($"Exit Code is {Environment.ExitCode}");

                    if (Debugger.IsAttached)
                    {
                        System.Console.WriteLine("Press enter to continue.");
                        System.Console.ReadLine();
                    }
                }
            }

            ILifetimeScope RegisterContainer()
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(parser.Object)
                    .As<IApiConfiguration>()
                    .As<IApiMetadataConfiguration>()
                    .As<IOAuthTokenConfiguration>()
                    .As<IOAuthSessionToken>()
                    .As<ISdkLibraryConfiguration>()
                    .As<IDestructiveTestConfiguration>()
                    .SingleInstance();

                builder.RegisterModule(new SmokeTestsModule());

                switch (parser.Object.TestSet)
                {
                    case TestSet.NonDestructiveApi:
                        builder.RegisterModule(new SmokeTestsApiModule());
                        break;
                    case TestSet.NonDestructiveSdk:
                        builder.RegisterModule(new SmokeTestsSdkModule());
                        builder.RegisterModule(new SmokeTestsNonDestructiveSdkModule());
                        break;
                    case TestSet.DestructiveSdk:
                        builder.RegisterModule(new SmokeTestsSdkModule());
                        builder.RegisterModule(new SmokeTestsDestructiveSdkModule());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return builder.Build();
            }
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
