// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.OpenApiMetadataContentProviders;
using EdFi.Ods.Features.RouteInformations;

namespace EdFi.Ods.Features.Container.Modules
{
    public class EnabledIdentityOpenApiMetadataModule : ConditionalModule
    {
        public EnabledIdentityOpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(EnabledIdentityOpenApiMetadataModule)) { }

        public override bool IsSelected()
            => IsFeatureEnabled(ApiFeature.IdentityManagement)
               && IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityOpenApiContentProvider>()
                .As<IOpenApiContentProvider>()
                .SingleInstance();

            builder.RegisterType<IdentityOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();
        }
    }
}
