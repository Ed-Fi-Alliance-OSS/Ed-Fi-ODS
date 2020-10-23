﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.Filters;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Security.DataAccess.Caching;
using EdFi.Security.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Container.Modules
{
    public class InstanceYearSpecificModule : ConditionalModule
    {
        public InstanceYearSpecificModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(InstanceYearSpecificModule)) { }

        public override bool IsSelected() => ApiSettings.GetApiMode() == ApiMode.InstanceYearSpecific;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<TokenControllerRouteConvention>()
                .As<IApplicationModelConvention>()
                .SingleInstance();

            builder.RegisterType<InstanceIdContextFilter>()
                .As<IFilterMetadata>();

            builder.RegisterType<InstanceIdContextProvider>()
                .As<IInstanceIdContextProvider>()
                .As<IHttpContextStorageTransferKeys>();

            builder.RegisterType<InstanceYearSpecificAdminDatabaseNameReplacementTokenProvider>()
                .As<IAdminDatabaseNameReplacementTokenProvider>();

            builder.RegisterType<InstanceYearSpecificSecurityDatabaseNameReplacementTokenProvider>()
                .As<ISecurityDatabaseNameReplacementTokenProvider>();

            builder.RegisterType<InstanceYearSpecificDatabaseNameReplacementTokenProvider>()
                .As<IDatabaseNameReplacementTokenProvider>();

            builder.RegisterType<InstanceSecurityRepository>()
                .As<ISecurityRepository>()
                .SingleInstance();

            builder.RegisterType<InstanceSecurityRepositoryCache>()
                .As<IInstanceSecurityRepositoryCache>()
                .SingleInstance();
        }
    }
}