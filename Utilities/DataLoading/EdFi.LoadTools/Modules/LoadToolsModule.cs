// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.BulkLoadClient;
using EdFi.LoadTools.BulkLoadClient.Application;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.FileImportPipeline;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using EdFi.LoadTools.Engine.ResourcePipeline;

namespace EdFi.LoadTools.Modules
{
    public class LoadToolsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BulkLoadClientResult>()
                .As<IBulkLoadClientResult>();

            builder.RegisterType<DependenciesRetriever>()
                .As<IDependenciesRetriever>()
                .SingleInstance();

            builder.RegisterType<SwaggerMetadataRetriever>()
                .As<ISwaggerMetadataRetriever>()
                .SingleInstance();

            builder.RegisterType<SwaggerRetriever>()
                .As<ISwaggerRetriever>()
                .SingleInstance();

            builder.RegisterType<XsdStreamsRetriever>()
                .SingleInstance();

            builder.RegisterType<FileContextProvider>()
                .As<IFileContextProvider>()
                .SingleInstance();

            builder.RegisterType<SchemaSetFactory>()
                .SingleInstance();

            builder.RegisterType<OAuthTokenHandler>()
                .SingleInstance();

            builder.RegisterType<FileImportPipeline>();

            builder.RegisterType<ResourcePipeline>();

            builder.RegisterType<XmlReferenceCacheFactory>()
                .As<IXmlReferenceCacheFactory>()
                .As<IXmlReferenceCacheProvider>()
                .SingleInstance();

            builder.Register(c => c.Resolve<SchemaSetFactory>().GetSchemaSet())
                .SingleInstance();

            builder.RegisterType<HashProvider>()
                .As<IHashProvider>()
                .SingleInstance();

            builder.RegisterType<ResourceHashCache>()
                .As<IResourceHashCache>()
                .SingleInstance();

            builder.RegisterType<JsonMetadataFactory>()
                .As<IMetadataFactory<JsonModelMetadata>>()
                .SingleInstance();

            builder.RegisterType<XsdApiTypesMetadataFactory>()
                .As<IMetadataFactory<XmlModelMetadata>>()
                .SingleInstance();

            builder.Register(c => c.Resolve<IMetadataFactory<JsonModelMetadata>>().GetMetadata())
                .SingleInstance();

            builder.Register(c => c.Resolve<IMetadataFactory<XmlModelMetadata>>().GetMetadata())
                .SingleInstance();

            builder.RegisterType<ResourceToResourceMetadataMappingFactory>()
                .As<IMetadataMappingFactory>()
                .SingleInstance();

            builder.RegisterType<TokenRetriever>()
                .As<ITokenRetriever>()
                .SingleInstance();

            builder.RegisterType<OdsRestClient>()
                .As<IOdsRestClient>()
                .SingleInstance();

            builder.RegisterType<OdsVersionRetriever>()
                .As<IOdsVersionRetriever>()
                .SingleInstance();

            builder.RegisterType<SubmitResource>()
                .As<ISubmitResource>();

            builder.RegisterType<ApiLoaderApplication>()
                .As<IApiLoaderApplication>();

            builder.RegisterType<BulkLoadClientConfigurationValidator>()
                .As<IBulkLoadClientConfigurationValidator>()
                .SingleInstance();

            RegisterFileImportPipelineSteps();

            RegisterResourcePipelineSteps();

            RegisterMappers();

            // Holds unique schema names
            builder.RegisterInstance(new List<string>())
                .SingleInstance();

            void RegisterMappers()
            {
                builder.RegisterType<ArrayMetadataMapper>()
                    .As<IMetadataMapper>();

                builder.RegisterType<DescriptorReferenceMetadataMapper>()
                    .As<IMetadataMapper>();

                builder.RegisterType<NameMatchingMetadataMapper>()
                    .As<IMetadataMapper>();
            }

            void RegisterResourcePipelineSteps()
            {
                builder.RegisterType<ComputeHashStep>()
                    .As<IResourcePipelineStep>();

                builder.RegisterType<FilterResourceStep>()
                    .As<IResourcePipelineStep>();

                builder.RegisterType<ResolveReferenceStep>()
                    .As<IResourcePipelineStep>();

                builder.RegisterType<MapElementStep>()
                    .As<IResourcePipelineStep>();
            }

            void RegisterFileImportPipelineSteps()
            {
                builder.RegisterType<FindReferencesStep>()
                    .As<IFileImportPipelineStep>();

                builder.RegisterType<PreloadReferencesStep>()
                    .As<IFileImportPipelineStep>();
            }
        }
    }
}
