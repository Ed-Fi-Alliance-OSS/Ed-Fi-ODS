// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Linq;
using Autofac;
using Autofac.Core;
using EdFi.LoadTools;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using EdFi.XmlLookup.Console.Application;

namespace EdFi.XmlLookup.Console
{
    public class XmlLookupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OdsRestClient>()
                .As<IOdsRestClient>()
                .SingleInstance();

            builder.RegisterType<OAuthTokenHandler>()
                .As<IOAuthTokenHandler>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<SchemaSetFactory>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<XmlLookupConfigurationValidator>()
                .As<IXmlLookupConfigurationValidator>()
                .SingleInstance();

            builder.RegisterType<XmlLookupPipelineProcessor>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<XmlLookupToResourceProcessor>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<XmlToWorkItemsProcessor>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<XmlLookupApplication>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<SwaggerMetadataRetriever>()
                .As<ISwaggerMetadataRetriever>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ISwaggerRetriever>()
                .As<ISwaggerRetriever>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<XsdStreamsRetriever>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<NameMatchingMetadataMapper>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<XmlIoFactory>()
                .As<IXmlPairsFactory>()
                .SingleInstance();

            builder.RegisterType<JsonMetadataFactory>()
                .As<IMetadataFactory<JsonModelMetadata>>()
                .SingleInstance();

            builder.RegisterType<XsdMetadataFactory>()
                .As<IMetadataFactory<XmlModelMetadata>>()
                .SingleInstance();

            builder.RegisterType<HashProvider>()
                .As<IHashProvider>()
                .SingleInstance();

            builder.RegisterType<TokenRetriever>()
                .As<ITokenRetriever>()
                .SingleInstance();

            builder.Register(c => c.Resolve<SchemaSetFactory>().GetSchemaSet())
                .SingleInstance();

            builder.RegisterInstance(new ConcurrentDictionary<string, XElement>())
                .As<IDictionary<string, XElement>>()
                .SingleInstance();

            builder.RegisterInstance(new List<string>())
                .SingleInstance();

            builder.Register(c => c.Resolve<IMetadataFactory<JsonModelMetadata>>().GetMetadata())
                .SingleInstance();

            builder.Register(c => c.Resolve<IMetadataFactory<XmlModelMetadata>>().GetMetadata());

            var pipelineSteps =
                new[]
                {
                    typeof(IdentifyResourceTypeStep),
                    typeof(ComputeHashStep),
                    typeof(DirectLookupToIdentityMappingStep),
                    typeof(AvoidDuplicateLookupsStep),
                    typeof(EducationOrganizationCacheLookupStep),
                    typeof(MapXmlLookupToGetByExampleJsonStep),
                    typeof(PerformGetByExampleStep),
                    typeof(MapResourceToIdentityStep),
                    typeof(StoreIdentityForWritingStep)
                };

            builder.RegisterType<LookupToGetByExampleMetadataMappingFactory>()
                .Named<IMetadataMappingFactory>(nameof(LookupToIdentityMetadataMappingFactory))
                .As<IMetadataMappingFactory>()
                .SingleInstance();

            builder.RegisterType<ResourceToIdentityMetadataMappingFactory>()
                .Named<IMetadataMappingFactory>(nameof(ResourceToIdentityMetadataMappingFactory))
                .As<IMetadataMappingFactory>()
                .SingleInstance();

            builder.RegisterType<LookupToIdentityMetadataMappingFactory>()
                .Named<IMetadataMappingFactory>(nameof(LookupToIdentityMetadataMappingFactory))
                .As<IMetadataMappingFactory>()
                .SingleInstance();

            foreach (var pipelineStep in pipelineSteps)
            {
                if (pipelineStep == typeof(MapXmlLookupToGetByExampleJsonStep))
                {
                    builder.RegisterType(pipelineStep)
                        .As<ILookupPipelineStep>()
                        .WithParameter(
                            new ResolvedParameter(
                                (p, c) => p.GetType() == typeof(IMetadataMappingFactory),
                                (p, c) => c.ResolveNamed<IMetadataMappingFactory>(
                                    nameof(LookupToGetByExampleMetadataMappingFactory))));
                }
                else if (pipelineStep == typeof(MapResourceToIdentityStep))
                {
                    builder.RegisterType(pipelineStep)
                        .As<ILookupPipelineStep>()
                        .WithParameter(
                            new ResolvedParameter(
                                (p, c) => p.GetType() == typeof(IMetadataMappingFactory),
                                (p, c) => c.ResolveNamed<IMetadataMappingFactory>(
                                    nameof(ResourceToIdentityMetadataMappingFactory))));
                }
                else if (pipelineStep == typeof(DirectLookupToIdentityMappingStep))
                {
                    builder.RegisterType(pipelineStep)
                        .As<ILookupPipelineStep>()
                        .WithParameter(
                            new ResolvedParameter(
                                (p, c) => p.GetType() == typeof(IMetadataMappingFactory),
                                (p, c) => c.ResolveNamed<IMetadataMappingFactory>(
                                    nameof(LookupToIdentityMetadataMappingFactory))));
                }
                else
                {
                    builder.RegisterType(pipelineStep).As<ILookupPipelineStep>();
                }
            }

            builder.RegisterType<EducationOrganizationIdentityCache>().As<IEducationOrganizationIdentityCache>();

            var metadataMappers =
                new[]
                {
                    typeof(PremappedLookupMetadataMapper),
                    typeof(LookupDoNotMapPropertyMapper),
                    typeof(DescriptorReferenceMetadataMapper),
                    typeof(NameMatchingMetadataMapper)
                };

            foreach (var metadataMapper in metadataMappers)
            {
                builder.RegisterType(metadataMapper).As<IMetadataMapper>();
            }
        }
    }
}
