// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using EdFi.LoadTools;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using EdFi.XmlLookup.Console.Application;
using log4net;
using log4net.Config;
using SimpleInjector;

namespace EdFi.XmlLookup.Console
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).Name);

        private static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            ConfigureTls();

            //BasicConfigurator.Configure();
            int exitCode;
            var p = new CommandLineParser();

            p.SetupHelp("?", "Help").Callback(
                text =>
                {
                    System.Console.WriteLine(text);
                    Environment.Exit(0);
                });

            var result = p.Parse(args);

            if (result.HasErrors || !p.Object.IsValid)
            {
                exitCode = 1;
                System.Console.Write(result.ErrorText);
                System.Console.Write(p.Object.ErrorText);
            }
            else
            {
                try
                {
                    using (var container = new Container())
                    {
                        LogConfiguration(p.Object);

                        // configure DI container
                        ConfigureCompositionRoot(container, p.Object);

                        // retrieve application
                        var application = container.GetInstance<XmlLookupApplication>();

                        // run application 
                        exitCode = application.Run().Result;
                    }
                }
                catch (AggregateException ex)
                {
                    exitCode = 1;

                    foreach (var e in ex.InnerExceptions)
                    {
                        Log.Error(e);
                    }
                }
            }

            Environment.Exit(exitCode);
        }

        private static void LogConfiguration(Configuration configuration)
        {
            Log.Info($"Api Url:        {configuration.ApiUrl}");
            Log.Info($"School Year:    {configuration.SchoolYear}");
            Log.Info($"Oauth Key:      {configuration.OauthKey}");
            Log.Info($"Metadata Url:   {configuration.MetadataUrl}");
            Log.Info($"Data Folder:    {configuration.DataFolder}");
            Log.Info($"Working Folder: {configuration.WorkingFolder}");
            Log.Info($"Xsd Folder:     {configuration.XsdFolder}");
        }

        private static void ConfigureCompositionRoot(Container container, Configuration configuration)
        {
            container.RegisterSingleton<IApiConfiguration>(() => configuration);
            container.RegisterSingleton<IApiMetadataConfiguration>(() => configuration);
            container.RegisterSingleton<IDataConfiguration>(() => configuration);
            container.RegisterSingleton<IOAuthTokenConfiguration>(() => configuration);
            container.RegisterSingleton<IXsdConfiguration>(() => configuration);

            container.RegisterSingleton<SwaggerMetadataRetriever>();
            container.RegisterSingleton<SwaggerRetriever>();
            container.RegisterSingleton<XsdStreamsRetriever>();

            container.RegisterSingleton<NameMatchingMetadataMapper>();

            container.RegisterSingleton<IXmlPairsFactory, XmlIoFactory>();
            container.RegisterSingleton<IMetadataFactory<JsonModelMetadata>, JsonMetadataFactory>();
            container.RegisterSingleton<IMetadataFactory<XmlModelMetadata>, XsdMetadataFactory>();
            container.RegisterSingleton<IHashProvider, HashProvider>();
            container.RegisterSingleton<ITokenRetriever, TokenRetriever>();

            container.RegisterSingleton(() => container.GetInstance<SchemaSetFactory>().GetSchemaSet());

            container.RegisterSingleton<IDictionary<string, XElement>>(
                () =>
                    new ConcurrentDictionary<string, XElement>());

            container.RegisterSingleton<IEnumerable<JsonModelMetadata>>(
                () => container.GetInstance<IMetadataFactory<JsonModelMetadata>>().GetMetadata().ToArray());

            container.RegisterSingleton<IEnumerable<XmlModelMetadata>>(
                () => container.GetInstance<IMetadataFactory<XmlModelMetadata>>().GetMetadata().ToArray());

            container.RegisterCollection<ILookupPipelineStep>(
                new[]
                {
                    typeof(IdentifyResourceTypeStep), typeof(ComputeHashStep), typeof(DirectLookupToIdentityMappingStep),
                    typeof(AvoidDuplicateLookupsStep), typeof(EducationOrganizationCacheLookupStep), typeof(MapXmlLookupToGetByExampleJsonStep),
                    typeof(PerformGetByExampleStep), typeof(MapResourceToIdentityStep), typeof(StoreIdentityForWritingStep)
                });

            container.Register<IEducationOrganizationIdentityCache, EducationOrganizationIdentityCache>();

            container.RegisterConditional<IMetadataMappingFactory, LookupToGetByExampleMetadataMappingFactory>(
                Lifestyle.Singleton,
                c => c.Consumer.ImplementationType == typeof(MapXmlLookupToGetByExampleJsonStep));

            container.RegisterConditional<IMetadataMappingFactory, ResourceToIdentityMetadataMappingFactory>(
                Lifestyle.Singleton,
                c => c.Consumer.ImplementationType == typeof(MapResourceToIdentityStep));

            container.RegisterConditional<IMetadataMappingFactory, LookupToIdentityMetadataMappingFactory>(
                Lifestyle.Singleton,
                c => c.Consumer.ImplementationType == typeof(DirectLookupToIdentityMappingStep));

            container.RegisterCollection<IMetadataMapper>(
                new[]
                {
                    typeof(PremappedLookupMetadataMapper), typeof(LookupDoNotMapPropertyMapper), typeof(DescriptorReferenceMetadataMapper),
                    typeof(NameMatchingMetadataMapper)
                });

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
