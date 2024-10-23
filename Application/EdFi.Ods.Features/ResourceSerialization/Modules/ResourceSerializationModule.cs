// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;

namespace EdFi.Ods.Features.ResourceSerialization.Modules;

public class ResourceSerializationModule : ConditionalModule
{
    public ResourceSerializationModule(ApiSettings apiSettings)
        : base(apiSettings, nameof(ResourceSerializationModule)) { }

    public override bool IsSelected() => IsFeatureEnabled(ApiFeature.ResourceSerialization);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        // Change Queries support in NHibernate mappings 
        builder.RegisterType<JsonNHibernateConfigurationActivity>()
            .As<INHibernateBeforeBindMappingActivity>()
            .SingleInstance();
    }
}
