// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.Publishing.DatabaseNaming;
using EdFi.Ods.Features.Publishing.ExceptionHandling;
using EdFi.Ods.Features.Publishing.OpenApiMetadata;
using EdFi.Ods.Features.Publishing.Repositories;
using EdFi.Ods.Features.Publishing.Routing;
using EdFi.Ods.Features.Publishing.SnapshotContext;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Features.Publishing.Container
{
    public class PublishingModule : ConditionalModule
    {
        public PublishingModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(PublishingModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Publishing);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            // Routing
            builder.RegisterType<SnapshotsControllerRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            // Open API Metadata
            builder.RegisterType<PublishingOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .SingleInstance();

            builder.RegisterType<PublishingOpenApiContentProvider>()
                .As<IOpenApiContentProvider>()
                .SingleInstance();

            // Publishing components / services
            builder.RegisterType<SnapshotContextProvider>()
                .As<ISnapshotContextProvider>()
                .SingleInstance();

            builder.RegisterType<SnapshotContextActionFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();

            builder.RegisterDecorator<
                    SnapshotSuffixDatabaseNameReplacementTokenProvider, 
                    IDatabaseNameReplacementTokenProvider>();

            builder.RegisterType<SnapshotGoneExceptionTranslator>()
                .As<IExceptionTranslator>()
                .SingleInstance();

            builder.RegisterType<GetSnapshots>()
                .As<IGetSnapshots>()
                .SingleInstance();
        }
    }
}
