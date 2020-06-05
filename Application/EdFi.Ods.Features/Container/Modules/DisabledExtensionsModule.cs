// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;

namespace EdFi.Ods.Features.Container.Modules
{
    public class DisabledExtensionsModule : ConditionalModule

    {
        public DisabledExtensionsModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(DisabledExtensionsModule)) { }

        public override bool IsSelected() => !IsFeatureEnabled(ApiFeature.Extensions);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<NoEntityExtensionsFactory>().As<IEntityExtensionsFactory>().SingleInstance();
        }
    }
}
#endif