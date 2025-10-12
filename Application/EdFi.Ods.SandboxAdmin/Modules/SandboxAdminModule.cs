// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Sandbox.Admin.Contexts;
using EdFi.Ods.Sandbox.Admin.Services.Initialization;
using EdFi.Ods.Sandbox.Admin.Services;
using EdFi.Ods.SandboxAdmin.Services.Security;
using EdFi.Ods.SandboxAdmin.Services;

namespace EdFi.Ods.SandboxAdmin.Modules
{
    public class SandboxAdminModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientAppRepo>().As<IClientAppRepo>();
            builder.RegisterType<UsersContextFactory>().As<IUsersContextFactory>();
            builder.RegisterType<AdminDatabaseConnectionStringProvider>().As<IAdminDatabaseConnectionStringProvider>();
            builder.RegisterType<DatabaseNameBuilder>().As<IDatabaseNameBuilder>();
            builder.RegisterType<DbConnectionStringBuilderAdapterFactory>().As<IDbConnectionStringBuilderAdapterFactory>();
            builder.RegisterType<ConfigConnectionStringsProvider>().As<IConfigConnectionStringsProvider>();
            builder.RegisterType<ClientCreator>().As<IClientCreator>();
            builder.RegisterType<DefaultApplicationCreator>().As<IDefaultApplicationCreator>();
            builder.RegisterType<ClientCreator>().As<IClientCreator>();
            builder.RegisterType<InitializationEngine>().As<IInitializationEngine>();
            builder.Register(c => c.Resolve<ApiSettings>().GetDatabaseEngine());
            builder.RegisterType<BackgroundJobService>().As<IBackgroundJobService>();
            builder.RegisterType<RouteService>().As<IRouteService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<PasswordService>().As<IPasswordService>();
            builder.RegisterType<UserAccountManager>().As<IUserAccountManager>();
            builder.RegisterType<SecurityService>().As<ISecurityService>();
            builder.RegisterType<IdentityProvider>().As<IIdentityProvider>();
            builder.RegisterType<SqlServerIdentityContext>();
            builder.RegisterType<PostgresIdentityContext>();
        }
    }
}
