// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.ChangeQueries.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;

namespace EdFi.Ods.ChangeQueries.Container.Modules
{
    public class EnabledChangeQueriesOpenApiMetadataModule : ConditionalModule
    {
        public EnabledChangeQueriesOpenApiMetadataModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(EnabledChangeQueriesOpenApiMetadataModule)) { }

        public override bool IsSelected()
            => IsFeatureEnabled(ApiFeature.ChangeQueries)
               && IsFeatureEnabled(ApiFeature.OpenApiMetadata);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ChangeQueriesOpenApiContentProvider>()
                .As<IOpenApiContentProvider>();

            builder.RegisterType<ChangeQueriesOpenApiMetadataRouteInformation>()
                .As<IOpenApiMetadataRouteInformation>();
        }
    }
}
#endif