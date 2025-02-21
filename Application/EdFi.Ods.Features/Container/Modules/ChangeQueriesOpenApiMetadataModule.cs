// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.ChangeQueries.Providers;
using EdFi.Ods.Features.RouteInformations;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Container.Modules
{
    public class EnabledChangeQueriesOpenApiMetadataModule : ConditionalModule
    {
        public EnabledChangeQueriesOpenApiMetadataModule(IFeatureManager featureManager)
            : base(featureManager) { }

        protected override bool IsSelected()
            => IsFeatureEnabled(ApiFeature.ChangeQueries)
               && IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ChangeQueriesOpenApiContentProvider>()
                .As<IOpenApiContentProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChangeQueriesOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>()
                .InstancePerLifetimeScope();
        }
    }
}