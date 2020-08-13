// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Infrastructure.Pipelines.Get;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetDeletedResource;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Api.Infrastructure.Pipelines.Put;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetDeletedResource;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;

namespace EdFi.Ods.Api.Container.Modules
{
    public class PipelineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PipelineFactory>()
                .As<IPipelineFactory>();

            RegisterPipeLineStepProviders();
            RegisterModels();
            RegisterContexts();
            RegisterResults();

            void RegisterResults()
            {
                builder.RegisterGeneric(typeof(GetResult<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetManyResult<>))
                    .AsSelf();

                builder.RegisterType<GetDeletedResourceResult>()
                    .AsSelf();

                builder.RegisterType<PutResult>()
                    .AsSelf();

                builder.RegisterType<DeleteResult>()
                    .AsSelf();
            }

            void RegisterContexts()
            {
                builder.RegisterGeneric(typeof(GetContext<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetManyContext<,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetDeletedResourceContext<>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(PutContext<,>))
                    .AsSelf();

                builder.RegisterType<DeleteContext>()
                    .AsSelf();
            }

            void RegisterModels()
            {
                builder.RegisterGeneric(typeof(GetEntityModelById<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(DetectUnmodifiedEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapEntityModelToResourceModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetEntityModelsBySpecification<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(GetDeletedResourceModelByIds<,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(ValidateResourceModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(DeleteEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapResourceModelToEntityModel<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(MapEntityModelsToResourceModels<,,,>))
                    .AsSelf();

                builder.RegisterGeneric(typeof(PersistEntityModel<,,,>))
                    .AsSelf();
            }

            void RegisterPipeLineStepProviders()
            {
                builder.RegisterType<GetPipelineStepsProvider>()
                    .As<IGetPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<GetBySpecificationPipelineStepsProvider>()
                    .As<IGetBySpecificationPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<GetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IGetDeletedResourceIdsPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<PutPipelineStepsProvider>()
                    .As<IPutPipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();

                builder.RegisterType<DeletePipelineStepsProvider>()
                    .As<IDeletePipelineStepsProvider>()
                    .As<IPipelineStepsProvider>();
            }
        }
    }
}
#endif
