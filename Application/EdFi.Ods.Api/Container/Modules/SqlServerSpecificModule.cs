// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using Microsoft.Data.SqlClient;
using Autofac;
using Autofac.Core;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Api.Database.NamingConventions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.SqlServer;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying.Dialects;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Api.Container.Modules
{
    public class SqlServerSpecificModule : ConditionalModule
    {
        private readonly DatabaseEngine _databaseEngine;

        public SqlServerSpecificModule(IFeatureManager featureManager, DatabaseEngine databaseEngine)
            : base(featureManager)
        {
            _databaseEngine = databaseEngine;
        }

        protected override bool IsSelected() => _databaseEngine == DatabaseEngine.SqlServer;

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterInstance(DatabaseEngine.SqlServer);

            builder.RegisterType<SqlServerTableValuedParameterListSetter>()
                .As<IParameterListSetter>()
                .SingleInstance();

            builder.RegisterType<SqlServerMultiValueRestrictions>()
                .As<IMultiValueRestrictions>()
                .SingleInstance();

            builder.RegisterType<SqlServerDatabaseEngineNHibernateConfigurationActivity>()
                .As<INHibernateConfigurationActivity>()
                .SingleInstance();

            builder.RegisterType<SqlServerViewBasedSingleItemAuthorizationQuerySupport>()
                .As<IViewBasedSingleItemAuthorizationQuerySupport>()
                .SingleInstance();

            builder.RegisterInstance(SqlClientFactory.Instance)
                .As<DbProviderFactory>()
                .SingleInstance();
            
            builder.RegisterType<SqlServerDialect>()
                .As<Dialect>()
                .SingleInstance();
            
            // Register SQL Server SQL naming convention
            builder.RegisterType<SqlServerDatabaseNamingConvention>()
                .As<IDatabaseNamingConvention>()
                .SingleInstance();

            builder.RegisterType<SqlServerPartitionsQueryBuilderPartitionsApplicator>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(int) && p.Name == "_defaultPartitionCount",
                        (p, c) => c.Resolve<ApiSettings>().DefaultPartitionCount))
                .As<IPartitionsQueryBuilderPartitionsApplicator>()
                .SingleInstance();
        }
    }
}