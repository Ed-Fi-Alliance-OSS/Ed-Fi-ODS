// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Features.UniqueIdIntegration.Caching;
using EdFi.Ods.Features.UniqueIdIntegration.Pipeline;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;

namespace EdFi.Ods.Features.Container.Modules
{
    public class UniqueIdIntegrationModule : ConditionalModule
    {
        public UniqueIdIntegrationModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(UniqueIdIntegrationModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.UniqueIdValidation);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            // only install the cache is one is not provided.
            builder.RegisterType<PersonUniqueIdToIdCache>()
                .As<IPersonUniqueIdToIdCache>()
                .IfNotRegistered(typeof(IPersonUniqueIdToIdCache));

            builder.RegisterGeneric(typeof(PopulateIdFromUniqueIdOnPeople<,,,>))
                .AsSelf();

            builder.RegisterDecorator(
                typeof(UniqueIdIntegrationPutPipelineStepsProviderDecorator),
                typeof(IPutPipelineStepsProvider));

            builder.RegisterType<UniqueIdNotChangedEntityValidator>()
                .As<IEntityValidator>();

            builder.RegisterType<EnsureUniqueIdAlreadyExistsEntityValidator>()
                .As<IEntityValidator>();
        }
    }
}
#endif
