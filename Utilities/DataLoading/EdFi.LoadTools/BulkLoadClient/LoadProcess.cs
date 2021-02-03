// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Autofac;
using EdFi.LoadTools.ApiClient;
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
                await SetOdsEndpoints(configuration);

                var container = RegisterContainer(configuration);

                await using var scope = container.BeginLifetimeScope();

                var validator = container.Resolve<IBulkLoadClientConfigurationValidator>();

                if (!validator.IsValid())
                {
                    throw new InvalidOperationException(validator.ErrorText);
                }

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

        private static async Task SetOdsEndpoints(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration["OdsApi:Url"]))
            {
                _log.Warn("OdsApi:Url is null or empty");
                return;
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

        private static ILifetimeScope RegisterContainer(IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(configuration)
                .As<IConfiguration>()
                .As<IConfigurationRoot>()
                .SingleInstance();

            builder.RegisterInstance(BulkLoadClientConfiguration.Create(configuration))
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

        public static BulkLoadValidationResult ValidateXmlFile(BulkLoadClientConfiguration configuration,
            string[] unsupportedInterchanges)
        {
            var validationErrors = new BulkLoadValidationResult();
            var streamsRetriever = new XsdStreamsRetriever(configuration);
            var factory = new SchemaSetFactory(streamsRetriever);
            var schemaSet = factory.GetSchemaSet();

            foreach (var fileToImport in GetFilesToImport(configuration))
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

                using (var fileStream = new FileStream(fileToImport, FileMode.Open, FileAccess.Read))
                {
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
            }

            return validationErrors;
        }
    }
}
