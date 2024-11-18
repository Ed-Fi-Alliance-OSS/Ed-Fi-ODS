// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Features.SerializedData.Pipeline;
using EdFi.Ods.Features.SerializedData.Repositories;

namespace EdFi.Ods.Features.SerializedData.Modules;

public class SerializedDataModule : ConditionalModule
{
    private readonly bool _resourceLinksEnabled;

    public SerializedDataModule(ApiSettings apiSettings)
        : base(apiSettings, nameof(SerializedDataModule))
    {
        _resourceLinksEnabled = IsFeatureEnabled(ApiFeature.ResourceLinks);
    }

    public override bool IsSelected() => IsFeatureEnabled(ApiFeature.SerializedData);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        // Change Queries support in NHibernate mappings 
        builder.RegisterType<SerializedDataNHibernateConfigurationActivity>()
            .As<INHibernateBeforeBindMappingActivity>()
            .SingleInstance();
        
        builder.RegisterDecorator(
            typeof(ReferenceDataUpsertPipelineStepsProviderDecorator),
            typeof(IUpsertPipelineStepsProvider));

        builder.RegisterDecorator(
            typeof(ReferenceDataGetBySpecificationPipelineStepsProviderDecorator),
            typeof(IGetBySpecificationPipelineStepsProvider));

        builder.RegisterDecorator(
            typeof(ReferenceDataGetPipelineStepsProviderDecorator),
            typeof(IGetPipelineStepsProvider));

        // These components are only needed if we are resolving reference data with serialized data feature enabled
        if (_resourceLinksEnabled)
        {
            builder.RegisterType<ReferenceDataResolver>()
                .As<IReferenceDataResolver>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(ResolveReferenceData<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(InitializeReferenceDataLookupContext<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGenericDecorator(typeof(GetEntityByIdReferenceDataLookupDecorator<>), typeof(IGetEntityById<>));
            builder.RegisterGenericDecorator(typeof(GetEntityByKeyReferenceDataLookupDecorator<>), typeof(IGetEntityByKey<>));

            builder.RegisterGenericDecorator(typeof(UpdateEntityReferenceDataLookupDecorator<>), typeof(IUpdateEntity<>));
            builder.RegisterGenericDecorator(typeof(CreateEntityReferenceDataLookupDecorator<>), typeof(ICreateEntity<>));
        }
    }
}
