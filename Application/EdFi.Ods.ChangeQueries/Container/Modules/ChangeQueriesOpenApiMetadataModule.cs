// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NetCore.Routing;
using EdFi.Ods.ChangeQueries.Providers;

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