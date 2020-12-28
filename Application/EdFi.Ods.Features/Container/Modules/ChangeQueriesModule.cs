// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.ChangeQueries;
using EdFi.Ods.Features.ChangeQueries.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ChangeQueriesModule : ConditionalModule
    {
        public ChangeQueriesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ChangeQueriesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.ChangeQueries);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<AvailableChangeVersionProvider>()
                .As<IAvailableChangeVersionProvider>()
                .SingleInstance();

            builder.RegisterType<GetDeletedResourceIds>()
                .As<IGetDeletedResourceIds>()
                .SingleInstance();

            builder.RegisterType<AvailableChangeVersionsRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<DeletesRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();
        }
    }
}
