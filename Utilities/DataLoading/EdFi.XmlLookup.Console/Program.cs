// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using CommandLine;
using EdFi.LoadTools;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.XmlLookup.Console.Application;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;

namespace EdFi.XmlLookup.Console
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(Program));

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

            int exitCode = 0;

            try
            {
                var configRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddCommandLine(args, CommandLineOverrides.SwitchingMapping())
                    .Build();

                await SetOdsEndpoints(configRoot);

                // configure DI container
                var container = RegisterContainer(configRoot);
                await using var scope = container.BeginLifetimeScope();

                var validator = container.Resolve<IXmlLookupConfigurationValidator>();

                if (!validator.IsValid())
                {
                    throw new InvalidOperationException(validator.ErrorText);
                }

                LogConfiguration(container.Resolve<XmlLookupConfiguration>());

                // retrieve application
                var application = container.Resolve<XmlLookupApplication>();

                // run application
                exitCode = await application.Run();
            }
            catch (Exception ex)
            {
                exitCode = 1;
                Log.Error(ex);
            }
            finally
            {
                Environment.Exit(exitCode);
            }

            ILifetimeScope RegisterContainer(IConfiguration configuration)
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(configuration)
                    .As<IConfiguration>()
                    .As<IConfigurationRoot>()
                    .SingleInstance();

                builder.RegisterInstance(XmlLookupConfiguration.Create(configuration))
                    .As<IApiConfiguration>()
                    .As<IDataConfiguration>()
                    .As<IOAuthTokenConfiguration>()
                    .As<IApiMetadataConfiguration>()
                    .As<IXsdConfiguration>()
                    .AsSelf()
                    .SingleInstance();

                builder.RegisterModule(new XmlLookupModule());

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

        private static void LogConfiguration(XmlLookupConfiguration xmlLookupConfiguration)
        {
            Log.Info($"Api Url:        {xmlLookupConfiguration.ApiUrl}");
            Log.Info($"School Year:    {xmlLookupConfiguration.SchoolYear}");
            Log.Info($"Oauth Key:      {xmlLookupConfiguration.OAuthKey}");
            Log.Info($"Metadata Url:   {xmlLookupConfiguration.MetadataUrl}");
            Log.Info($"Data Folder:    {xmlLookupConfiguration.DataFolder}");
            Log.Info($"Working Folder: {xmlLookupConfiguration.WorkingFolder}");
            Log.Info($"Xsd Folder:     {xmlLookupConfiguration.XsdFolder}");
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
