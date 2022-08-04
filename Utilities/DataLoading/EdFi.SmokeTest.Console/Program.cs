// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.IO;
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
                        if (errs.IsHelp() || errs.IsVersion())
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
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
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

            async Task<OdsVersionInformation> SetOdsEndpoints(IConfiguration configuration)
            {
                if (string.IsNullOrWhiteSpace(configuration["OdsApi:Url"]))
                {
                    Log.Info("OdsApi:Url is null or empty. Using legacy url parameters.");

                    return new OdsVersionInformation();
                }

                var odsVersionInformation = await new OdsVersionRetriever(configuration)
                    .GetApiVersionInformationAsync()
                    .ConfigureAwait(false);

                configuration["OdsApi:ApiMode"] = odsVersionInformation.ApiMode;

                if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("OdsApi:DependenciesUrl"))
                    && odsVersionInformation.Urls.TryGetValue("dependencies", out string dependencies))
                {
                    configuration["OdsApi:DependenciesUrl"] = dependencies;
                }

                if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("OdsApi:MetadataUrl"))
                    && odsVersionInformation.Urls.TryGetValue("openApiMetadata", out string openApiMetadata))
                {
                    configuration["OdsApi:MetadataUrl"] = openApiMetadata;
                }

                if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("OdsApi:OAuthUrl"))
                    && odsVersionInformation.Urls.TryGetValue("oauth", out string oauth))
                {
                    configuration["OdsApi:OAuthUrl"] = oauth;
                }

                if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("OdsApi:ApiUrl"))
                    && odsVersionInformation.Urls.TryGetValue("dataManagementApi", out string dataManagementApi))
                {
                    configuration["OdsApi:ApiUrl"] = dataManagementApi;
                }

                if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("OdsApi:XsdMetadataUrl")) &&
                    odsVersionInformation.Urls.TryGetValue("xsdMetadata", out string xsdMetadata))
                {
                    configuration["OdsApi:XsdMetadataUrl"] = xsdMetadata;
                }

                return odsVersionInformation;
            }
        }
    }
}
