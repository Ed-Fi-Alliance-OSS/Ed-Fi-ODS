// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.BulkLoadClient.Application;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.FileImportPipeline;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using EdFi.LoadTools.Engine.ResourcePipeline;
using log4net;
using SimpleInjector;

namespace EdFi.LoadTools.BulkLoadClient
{
    public static class LoadProcess
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(LoadProcess));

        public static int Run(Configuration configuration)
        {
            ConfigureTls();

            int exitCode;

            if (!configuration.IsValid)
            {
                exitCode = 1;
                _log.Error(configuration.ErrorText);
            }
            else
            {
                try
                {
                    using (var container = new Container())
                    {
                        LogConfiguration(configuration);

                        // configure DI container
                        ConfigureCompositionRoot(container, configuration);

                        // retrieve application
                        var application = container.GetInstance<IApiLoaderApplication>();

                        // run application
                        exitCode = application.Run().Result;
                    }
                }
                catch (AggregateException ex)
                {
                    exitCode = 1;

                    foreach (var e in ex.InnerExceptions)
                    {
                        _log.Error(e);
                    }
                }
            }
            return exitCode;
        }

        private static IEnumerable<string> GetFilesToImport(Configuration configuration)
        {
            return Directory.EnumerateFiles(configuration.DataFolder);
        }

        public static BulkLoadValidationResult ValidateXmlFile(Configuration configuration, string[] unsupportedInterchanges)
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

                xmlReaderSettings.ValidationEventHandler += (s, e) =>
                {
                    validationErrors.Add(e.Message);
                };

                using (var fileStream = new FileStream(fileToImport, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = XmlReader.Create(fileStream, xmlReaderSettings))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && unsupportedInterchanges.Any(i => i.Equals(reader.Name, StringComparison.InvariantCultureIgnoreCase)))
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

        private static void LogConfiguration(Configuration configuration)
        {
            _log.Info($"Api Url:                  {configuration.ApiUrl}");
            _log.Info($"School Year:              {configuration.SchoolYear}");
            _log.Info($"Retries:                  {configuration.Retries}");
            _log.Info($"Oauth Key:                {configuration.OauthKey}");
            _log.Info($"Metadata Url:             {configuration.MetadataUrl}");
            _log.Info($"Data Folder:              {configuration.DataFolder}");
            _log.Info($"Working Folder:           {configuration.WorkingFolder}");
            _log.Info($"Xsd Folder:               {configuration.XsdFolder}");
            _log.Info($"Dependencies Url:         {configuration.DependenciesUrl}");
        }

        private static void ConfigureCompositionRoot(Container container, Configuration configuration)
        {
            container.RegisterSingleton<IApiConfiguration>(() => configuration);
            container.RegisterSingleton<IApiMetadataConfiguration>(() => configuration);
            container.RegisterSingleton<IHashCacheConfiguration>(() => configuration);
            container.RegisterSingleton<IDataConfiguration>(() => configuration);
            container.RegisterSingleton<IOAuthTokenConfiguration>(() => configuration);
            container.RegisterSingleton<IXsdConfiguration>(() => configuration);
            container.RegisterSingleton<IInterchangeOrderConfiguration>(() => configuration);
            container.RegisterSingleton<IThrottleConfiguration>(() => configuration);
            container.RegisterSingleton<DependenciesRetriever>();
            container.RegisterSingleton<SwaggerMetadataRetriever>();
            container.RegisterSingleton<SwaggerRetriever>();
            container.RegisterSingleton<XsdStreamsRetriever>();
            container.RegisterSingleton<IFileContextProvider, FileContextProvider>();

            container.RegisterSingleton<IEnumerable<JsonModelMetadata>>(
                () => container.GetInstance<IMetadataFactory<JsonModelMetadata>>().GetMetadata().ToArray());

            container.RegisterSingleton<IEnumerable<XmlModelMetadata>>(
                () => container.GetInstance<IMetadataFactory<XmlModelMetadata>>().GetMetadata().ToArray());

            var xmlReferenceCacheFactoryRegistration =
                Lifestyle.Singleton.CreateRegistration<XmlReferenceCacheFactory>(container);

            container.AddRegistration(typeof(IXmlReferenceCacheFactory), xmlReferenceCacheFactoryRegistration);
            container.AddRegistration(typeof(IXmlReferenceCacheProvider), xmlReferenceCacheFactoryRegistration);

            container.RegisterSingleton(() => container.GetInstance<SchemaSetFactory>().GetSchemaSet());

            container.RegisterSingleton<IHashProvider, HashProvider>();
            container.RegisterSingleton<IResourceHashCache, ResourceHashCache>();
            container.RegisterSingleton<IMetadataFactory<JsonModelMetadata>, JsonMetadataFactory>();
            container.RegisterSingleton<IMetadataFactory<XmlModelMetadata>, XsdApiTypesMetadataFactory>();
            container.RegisterSingleton<IMetadataMappingFactory, ResourceToResourceMetadataMappingFactory>();
            container.RegisterSingleton<ITokenRetriever, TokenRetriever>();
            container.Register<IOdsRestClient, OdsRestClient>();
            container.Register<ISubmitResource, SubmitResource>();
            container.Register<IApiLoaderApplication, ApiLoaderApplication>();

            if (configuration.IncludeStats)
            {
                container.RegisterSingleton<ResourceStatistic>(() => new ResourceStatistic());
                container.RegisterDecorator<ISubmitResource, SubmitResourceTimingDecorator>();
                container.RegisterDecorator<IApiLoaderApplication, ApiLoadApplicationTimerDecorator>();
            }

            container.RegisterCollection<IFileImportPipelineStep>(
                new[]
                {
                    typeof(FindReferencesStep), typeof(PreloadReferencesStep)
                });

            container.RegisterCollection<IResourcePipelineStep>(
                new[]
                {
                    typeof(ComputeHashStep), typeof(FilterResourceStep), typeof(ResolveReferenceStep), typeof(MapElementStep)
                });

            container.RegisterCollection<IMetadataMapper>(
                new[]
                {
                    typeof(ArrayMetadataMapper), typeof(DescriptorReferenceMetadataMapper), typeof(NameMatchingMetadataMapper)
                });

            // Holds unique schema names
            container.RegisterSingleton(() => new List<string>());

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
