// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.RouteInformations;

namespace EdFi.Ods.Features.Container.Modules
{
    public class CompositesOpenApiMetadataModule : ConditionalModule
    {
        public CompositesOpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(CompositesOpenApiMetadataModule)) { }

        public override bool IsSelected()
            => IsFeatureEnabled(ApiFeature.Composites)
               && IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<CompositesOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();
        }
    }
}
