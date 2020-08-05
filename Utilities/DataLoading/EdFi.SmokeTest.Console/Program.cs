// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Net;
using EdFi.LoadTools;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.SmokeTest.Console.Application;
using log4net;
using log4net.Config;
using SimpleInjector;

namespace EdFi.SmokeTest.Console
{
    public partial class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private static Container _container;

        private static void Main(string[] args)
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
                    using (_container = new Container())
                    {
                        ConfigureCommandLineContainer(_container, parser.Object);
                        StartCommandLine(_container);
                    }
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
                    _container.Dispose();
                    if (Debugger.IsAttached)
                    {
                        System.Console.WriteLine("Press enter to continue.");
                        System.Console.ReadLine();
                    }
                }
            }
        }

        private static void StartCommandLine(Container container)
        {
            var application = container.GetInstance<ISmokeTestApplication>();
            Environment.ExitCode = application.Run().Result;
            Log.Info($"Exit Code is {Environment.ExitCode}");
        }

        private static void ConfigureCommandLineContainer(Container container, Configuration configuration)
        {
            container.RegisterInstance<IApiConfiguration>(configuration);
            container.RegisterInstance<IApiMetadataConfiguration>(configuration);
            container.RegisterInstance<IOAuthTokenConfiguration>(configuration);
            container.RegisterInstance<IOAuthSessionToken>(configuration);
            container.RegisterInstance<ISdkLibraryConfiguration>(configuration);
            container.RegisterInstance<IDestructiveTestConfiguration>(configuration);
            container.Register<ISmokeTestApplication, SmokeTestApplicationNoBlocks>();

            switch (configuration.TestSet)
            {
                case TestSet.NonDestructiveApi:
                    ConfigureNonDestructiveApi(container);
                    break;
                case TestSet.NonDestructiveSdk:
                    ConfigureNonDestructiveSdk(container);
                    break;
                case TestSet.DestructiveSdk:
                    ConfigureDestructiveSdk(container);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            container.Verify();
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
