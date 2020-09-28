// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Features.OpenApiMetadata;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.RouteInformations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Container.Modules
{
    public class OpenApiMetadataModule : ConditionalModule
    {
        public OpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(OpenApiMetadataModule)) { }

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
                .As<IOpenApiMetadataRouteInformation>();

            builder.RegisterType<ResourceTypeOpenMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>();

            // this is required to for ed-fi default
            builder.RegisterType<SchemaOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>();

            builder.RegisterType<EdFiOpenApiContentProvider>()
                .As<IOpenApiContentProvider>();

            builder.RegisterType<EnabledOpenApiMetadataDocumentProvider>()
                .As<IOpenApiMetadataDocumentProvider>();

            builder.RegisterType<OpenApiMetadataMiddleware>()
                .As<IMiddleware>()
                .AsSelf();

            builder.RegisterType<OpenApiMetadataDocumentFactory>()
                .As<IOpenApiMetadataDocumentFactory>();
           
            builder.RegisterType<OpenApiMetadataRouteConvention>()
                .As<IApplicationModelConvention>();
        }
    }
}
#endif
