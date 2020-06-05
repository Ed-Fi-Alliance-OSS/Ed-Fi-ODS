// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.ExternalTasks;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NetCore.Providers;
using EdFi.Ods.Api.NetCore.Routing;
using EdFi.Ods.Features.Middleware;
using EdFi.Ods.Features.OpenApiMetadata;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.RouteInformations;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Features.Container.Modules
{
    public class EnabledOpenApiMetadataModule : ConditionalModule
    {
        public EnabledOpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(EnabledOpenApiMetadataModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<OpenApiMetadataCacheProvider>()
                .As<IOpenApiMetadataCacheProvider>()
                .SingleInstance();

            builder.RegisterType<InitializeOpenApiMetadataCache>()
                .As<IExternalTask>()
                .SingleInstance();

            builder.RegisterType<AllOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();

            builder.RegisterType<ResourceTypeOpenMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();

            // this is required to for ed-fi default
            builder.RegisterType<SchemaOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();

            builder.RegisterType<EdFiOpenApiContentProvider>()
                .As<IOpenApiContentProvider>();

            builder.RegisterType<EnabledOpenApiMetadataDocumentProvider>()
                .As<IOpenApiMetadataDocumentProvider>();

            builder.RegisterType<OpenApiMetadataMiddleware>()
                .As<IMiddleware>()
                .AsSelf();
        }
    }
}
#endif
