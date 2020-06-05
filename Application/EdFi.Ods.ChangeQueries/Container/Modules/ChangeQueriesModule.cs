// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.ChangeQueries.Conventions;
using EdFi.Ods.ChangeQueries.NHibernate;
using EdFi.Ods.ChangeQueries.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.ChangeQueries.Container.Modules
{
    public class ChangeQueriesModule : ConditionalModule
    {
        public ChangeQueriesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ChangeQueriesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.ChangeQueries);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<AvailableChangeVersionProvider>()
                .As<IAvailableChangeVersionProvider>();

            builder.RegisterType<GetDeletedResourceIds>()
                .As<IGetDeletedResourceIds>();

            builder.RegisterType<AvailableChangeVersionsRouteConvention>()
                .As<IApplicationModelConvention>();

            builder.RegisterType<DeletesRouteConvention>()
                .As<IApplicationModelConvention>();
        }
    }
}
#endif
