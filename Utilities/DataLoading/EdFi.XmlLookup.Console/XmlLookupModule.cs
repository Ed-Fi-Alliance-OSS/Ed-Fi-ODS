// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Xml.Linq;
using Autofac;
using Autofac.Core;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using EdFi.LoadTools.Engine.XmlLookupPipeline;

namespace EdFi.XmlLookup.Console
{
    public class XmlLookupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SwaggerMetadataRetriever>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<SwaggerRetriever>()
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

            builder.RegisterInstance(new ConcurrentDictionary<string, XElement>()).SingleInstance()
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
                .SingleInstance();

            builder.RegisterType<ResourceToIdentityMetadataMappingFactory>()
                .Named<IMetadataMappingFactory>(nameof(ResourceToIdentityMetadataMappingFactory))
                .SingleInstance();

            builder.RegisterType<LookupToIdentityMetadataMappingFactory>()
                .Named<IMetadataMappingFactory>(nameof(LookupToIdentityMetadataMappingFactory))
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
