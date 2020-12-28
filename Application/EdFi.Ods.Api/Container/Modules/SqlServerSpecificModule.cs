// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQueryTemplating;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
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
            builder.RegisterType<SqlServerAuthorizationSegmentSqlProvider>()
                .As<IAuthorizationSegmentsSqlProvider>()
                .SingleInstance();

            // API Simplification components 
            builder.RegisterType<SqlServerPhysicalNamesProvider>()
                .As<IPhysicalNamesProvider>()
                .SingleInstance();

            builder.RegisterType<SqlServerResourcePageQuerySqlProvider>()
                .As<IResourcePageQuerySqlProvider>()
                .SingleInstance();
        }
    }
}