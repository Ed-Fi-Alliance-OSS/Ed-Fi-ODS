// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Features.ChangeQueries.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;
using Microsoft.AspNetCore.Mvc.Filters;
using EdFi.Ods.Features.ChangeQueries.DatabaseNaming;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.ChangeQueries.ExceptionHandling;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using EdFi.Ods.Features.ChangeQueries.Conventions;

namespace EdFi.Ods.Features.ChangeQueries.Modules
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

            builder.RegisterType<DeletedItemsResourceDataProvider>()
                .As<IDeletedItemsResourceDataProvider>()
                .SingleInstance();

            builder.RegisterType<GetKeyChanges>()
                .As<IGetKeyChanges>()
                .SingleInstance();

            builder.RegisterType<AvailableChangeVersionsRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<DeletesRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<KeyChangesRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<ChangeQueryMappingNHibernateConfigurationActivity>()
                .As<INHibernateBeforeBindMappingActivity>()
                .SingleInstance();

            // Routing
            builder.RegisterType<SnapshotsControllerRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            // Publishing components / services
            builder.RegisterType<SnapshotContextProvider>()
                .As<ISnapshotContextProvider>()
                .SingleInstance();

            builder.RegisterType<SnapshotContextActionFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();

            builder.RegisterDecorator<
                    SnapshotSuffixDatabaseReplacementTokenProvider,
                    IDatabaseReplacementTokenProvider>();

            builder.RegisterType<SnapshotGoneExceptionTranslator>()
                .As<IExceptionTranslator>()
                .SingleInstance();

            builder.RegisterType<GetSnapshots>()
                .As<IGetSnapshots>()
                .SingleInstance();
        }
    }
}
