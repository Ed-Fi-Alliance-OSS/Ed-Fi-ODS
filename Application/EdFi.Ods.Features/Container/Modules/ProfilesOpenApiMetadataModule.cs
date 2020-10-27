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
using EdFi.Ods.Features.Profiles;
using EdFi.Ods.Features.RouteInformations;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ProfilesOpenApiMetadataModule : ConditionalModule
    {
        public ProfilesOpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ProfilesOpenApiMetadataModule)) { }

        public override bool IsSelected()
            => IsFeatureEnabled(ApiFeature.OpenApiMetadata) &&
               IsFeatureEnabled(ApiFeature.Profiles);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ProfilesOpenApiContentProvider>()
                .As<IOpenApiContentProvider>()
                .SingleInstance();

            builder.RegisterType<ProfilesOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();
        }
    }
}
