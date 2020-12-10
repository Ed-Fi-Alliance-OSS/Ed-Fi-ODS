// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using CommandLine;
using EdFi.LoadTools;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest;
using EdFi.SmokeTest.Console.Application;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;

namespace EdFi.SmokeTest.Console
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        private static async Task Main(string[] args)
        {
            ConfigureLogging();
            ConfigureTls();

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

                await SetOdsEndpoints(configRoot);

                var container = RegisterContainer(configRoot);
                await using var scope = container.BeginLifetimeScope();

                var validator = container.Resolve<ISmokeTestConfigurationValidator>();

                if (!validator.IsValid())
                {
                    throw new InvalidOperationException(validator.ErrorText);
                }

                var application = container.Resolve<ISmokeTestApplication>();

                Environment.ExitCode = await application.Run();
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

            static ILifetimeScope RegisterContainer(IConfigurationRoot configuration)
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(configuration)
                    .As<IConfiguration>()
                    .As<IConfigurationRoot>()
                    .SingleInstance();

                var smokeTestsConfiguration = SmokeTestsConfiguration.Create(configuration);

                builder.RegisterInstance(smokeTestsConfiguration)
                    .As<IApiConfiguration>()
                    .As<IApiMetadataConfiguration>()
                    .As<IOAuthTokenConfiguration>()
                    .As<IOAuthSessionToken>()
                    .As<ISdkLibraryConfiguration>()
                    .As<IDestructiveTestConfiguration>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterModule(new SmokeTestsModule());

                if (smokeTestsConfiguration.TestSet == TestSet.NonDestructiveApi)
                {
                    builder.RegisterModule(new SmokeTestsApiModule());
                }
                else
                {
                    builder.RegisterModule(new SmokeTestsSdkModule());

                    if (smokeTestsConfiguration.TestSet == TestSet.NonDestructiveSdk)
                    {
                        builder.RegisterModule(new SmokeTestsNonDestructiveSdkModule());
                    }
                    else
                    {
                        builder.RegisterModule(new SmokeTestsDestructiveSdkModule());
                    }
                }

                return builder.Build();
            }

            static void ConfigureLogging()
            {
                var assembly = typeof(Program).GetType().Assembly;

                string configPath = Path.Combine(AppContext.BaseDirectory, "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }

            async Task SetOdsEndpoints(IConfigurationRoot configuration)
            {
                if (string.IsNullOrEmpty(configuration["OdsApi:Url"]))
                {
                    throw new ArgumentException("OdsApi:Url is null or empty");
                }

                // get api version information.
                var apiVersionInformation = await new OdsVersionRetriever(configuration).GetApiVersionInformationAsync()
                    .ConfigureAwait(false);

                if (string.IsNullOrEmpty(configuration.GetValue<string>("OdsApi:ApiUrl")))
                {
                    configuration["OdsApi:ApiUrl"] = apiVersionInformation.Urls["dataManagementApi"];
                }

                if (string.IsNullOrEmpty(configuration.GetValue<string>("OdsApi:MetadataUrl")))
                {
                    configuration["OdsApi:MetadataUrl"] = apiVersionInformation.Urls["openApiMetadata"];
                }

                if (string.IsNullOrEmpty(configuration.GetValue<string>("OdsApi:DependenciesUrl")))
                {
                    configuration["OdsApi:DependenciesUrl"] = apiVersionInformation.Urls["dependencies"];
                }

                if (string.IsNullOrEmpty(configuration.GetValue<string>("OdsApi:OAuthUrl")))
                {
                    configuration["OdsApi:OAuthUrl"] = apiVersionInformation.Urls["oauth"];
                }

                configuration["OdsApi:ApiMode"] = apiVersionInformation.ApiMode;
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
