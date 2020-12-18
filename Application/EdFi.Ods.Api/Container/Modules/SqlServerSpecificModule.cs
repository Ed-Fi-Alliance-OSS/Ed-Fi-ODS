// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming;
using EdFi.Ods.Api.Controllers.DataManagement.QueryTemplating;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.SqlServer;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Api.Container.Modules
{
    public class SqlServerSpecificModule : ConditionalModule
    {
        public SqlServerSpecificModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SqlServerSpecificModule)) { }

        public override bool IsSelected() => ApiSettings.GetDatabaseEngine() == DatabaseEngine.SqlServer;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SqlServerTableValuedParameterListSetter>()
                .As<IParameterListSetter>()
                .SingleInstance();

            builder.RegisterType<SqlServerAuthorizationSegmentSqlProvider>()
                .As<IAuthorizationSegmentsSqlProvider>()
                .SingleInstance();

            builder.RegisterType<SqlServerDatabaseEngineNHibernateConfigurationActivity>()
                .As<INHibernateConfigurationActivity>()
                .SingleInstance();

            builder.RegisterType<SqlServerDatabaseArtifactPhysicalNameProvider>()
                .As<IDatabaseArtifactPhysicalNameProvider>()
                .SingleInstance();

            builder.RegisterType<SqlServerTvpPagedAggregateIdsQueryTemplateProvider>()
                .As<IPagedAggregateIdsQueryTemplateProvider>()
                .SingleInstance();
        }
    }
}