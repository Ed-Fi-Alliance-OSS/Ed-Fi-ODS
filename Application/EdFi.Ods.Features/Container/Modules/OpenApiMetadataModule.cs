// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.OpenApiMetadata;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.RouteInformations;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Container.Modules
{
    public class OpenApiMetadataModule : ConditionalModule
    {
        public OpenApiMetadataModule(IFeatureManager featureManager)
            : base(featureManager) { }

        protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<OpenApiMetadataCacheProvider>()
                .As<IOpenApiMetadataCacheProvider>()
                .SingleInstance();

            builder.RegisterType<InitializeOpenApiMetadataCache>()
                .As<IStartupCommand>()
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
                .As<IOpenApiContentProvider>()
                .SingleInstance();

            builder.RegisterType<EnabledOpenApiMetadataDocumentProvider>()
                .As<IOpenApiMetadataDocumentProvider>()
                .SingleInstance();

            builder.RegisterType<OpenApiMetadataMiddleware>()
                .As<IMiddleware>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<OpenApiMetadataDocumentFactory>()
                .As<IOpenApiMetadataDocumentFactory>()
                .SingleInstance();

            builder.RegisterType<OpenApiV3UpconversionProvider>()
                .As<IOpenApiUpconversionProvider>()
                .SingleInstance();

            builder.RegisterType<OpenApiIdentityProvider>()
                .As<IOpenApiIdentityProvider>()
                .SingleInstance();
        }
    }
}
