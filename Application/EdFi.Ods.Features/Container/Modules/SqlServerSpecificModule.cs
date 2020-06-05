// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.SqlServer;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Features.Container.Modules
{
    public class SqlServerSpecificModule : ConditionalModule
    {
        public SqlServerSpecificModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SqlServerSpecificModule)) { }

        public override bool IsSelected() => ApiSettings.GetDatabaseEngine() == DatabaseEngine.SqlServer;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SqlServerTableValuedParameterListSetter>()
                .As<IParameterListSetter>();

            builder.RegisterType<SqlServerAuthorizationSegmentSqlProvider>()
                .As<IAuthorizationSegmentsSqlProvider>();
        }
    }
}
#endif