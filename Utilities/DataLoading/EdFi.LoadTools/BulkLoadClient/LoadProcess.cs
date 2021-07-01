// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Autofac;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.ApiClient.XsdMetadata;
using EdFi.LoadTools.BulkLoadClient.Application;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Modules;
using log4net;
using Microsoft.Extensions.Configuration;

namespace EdFi.LoadTools.BulkLoadClient
{
    public static class LoadProcess
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(LoadProcess));

        public static async Task<int> Run(IConfiguration configuration)
        {
            int exitCode;

            try
            {
                var odsVersionInformation = await SetOdsEndpoints(configuration);

                var bulkLoadClientConfiguration = BulkLoadClientConfiguration.Create(configuration);

                var container = RegisterContainer(configuration, odsVersionInformation, bulkLoadClientConfiguration);

                await using var scope = container.BeginLifetimeScope();

                var validator = container.Resolve<IBulkLoadClientConfigurationValidator>();

                if (!validator.IsValid())
                {
                    throw new InvalidOperationException(validator.ErrorText);
                }

                await LoadXsdFiles(bulkLoadClientConfiguration, odsVersionInformation);

                // run application
                exitCode = await container.Resolve<IApiLoaderApplication>().Run();
            }
            catch (Exception ex)
            {
                exitCode = 1;
                _log.Error(ex);
            }

            return exitCode;
        }

        private static async Task LoadXsdFiles(BulkLoadClientConfiguration bulkLoadClientConfiguration,
            OdsVersionInformation odsVersionInformation)
        {
            using var xsdFilesRetriever = new XsdFilesRetriever(
                bulkLoadClientConfiguration,
                new XsdMetadataInformationProvider(),
                new XsdMetadataFilesProvider(),
                new RemoteFileDownloader(),
                odsVersionInformation);

            await xsdFilesRetriever.DownloadXsdFilesAsync();
        }

        private static async Task<OdsVersionInformation> SetOdsEndpoints(IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration["OdsApi:Url"]))
            {
                _log.Info("OdsApi:Url is null or empty. Using legacy url parameters.");

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

        private static ILifetimeScope RegisterContainer(IConfiguration configuration,
            OdsVersionInformation odsVersionInformation,
            BulkLoadClientConfiguration bulkLoadClientConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(configuration)
                .As<IConfiguration>()
                .As<IConfigurationRoot>()
                .SingleInstance();

            builder.RegisterInstance(odsVersionInformation)
                .SingleInstance();

            builder.RegisterInstance(bulkLoadClientConfiguration)
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

            if (configuration.GetValue<bool>("IncludeStats"))
            {
                builder.RegisterModule(new IncludeStatsModule());
            }

            return builder.Build();
        }

        private static IEnumerable<string> GetFilesToImport(BulkLoadClientConfiguration configuration)
        {
            return Directory.EnumerateFiles(configuration.DataFolder);
        }

        public static async Task<BulkLoadValidationResult> ValidateXmlFile(IConfiguration configuration,
            string[] unsupportedInterchanges)
        {
            var odsVersionInformation = await SetOdsEndpoints(configuration);
            var xsdConfiguration = BulkLoadClientConfiguration.Create(configuration);

            await LoadXsdFiles(xsdConfiguration, odsVersionInformation);

            var validationErrors = new BulkLoadValidationResult();
            var streamsRetriever = new XsdStreamsRetriever(xsdConfiguration);
            var factory = new SchemaSetFactory(streamsRetriever);
            var schemaSet = factory.GetSchemaSet();

            foreach (var fileToImport in GetFilesToImport(xsdConfiguration))
            {
                var xmlReaderSettings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema,
                    Schemas = schemaSet,
                    ValidationFlags = XmlSchemaValidationFlags.AllowXmlAttributes |
                                      XmlSchemaValidationFlags.ReportValidationWarnings |
                                      XmlSchemaValidationFlags.ProcessIdentityConstraints
                };

                xmlReaderSettings.ValidationEventHandler += (s, e) => { validationErrors.Add(e.Message); };

                await using var fileStream = new FileStream(fileToImport, FileMode.Open, FileAccess.Read);

                using (var reader = XmlReader.Create(fileStream, xmlReaderSettings))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && unsupportedInterchanges.Any(
                            i => i.Equals(reader.Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            validationErrors.Add($"Import of data for {reader.Name} is not supported");
                        }
                    }

                    reader.Close();
                }

                fileStream.Close();
            }

            return validationErrors;
        }
    }
}
