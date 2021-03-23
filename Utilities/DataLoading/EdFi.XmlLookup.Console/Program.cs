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
                        if (errs.IsHelp())
                        {
                            Environment.ExitCode = 0;
                            Environment.Exit(Environment.ExitCode);
                        }

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
    }
}
