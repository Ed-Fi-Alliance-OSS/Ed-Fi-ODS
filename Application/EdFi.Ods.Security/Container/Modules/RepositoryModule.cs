// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using Autofac.Core;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Container.Modules {
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityRepository>().As<ISecurityRepository>();
            builder.RegisterType<ClientAppRepo>().As<IClientAppRepo>();
            builder.RegisterType<AccessTokenClientRepo>().As<IAccessTokenClientRepo>();

            builder.RegisterType<UsersContextFactory>()
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.GetType() == typeof(DatabaseEngine),
                        (pi, ctx) => ctx.Resolve<ApiSettings>()
                            .GetDatabaseEngine()))
                .As<IUsersContextFactory>().SingleInstance();

            builder.RegisterType<SecurityContextFactory>()
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.GetType() == typeof(DatabaseEngine),
                        (pi, ctx) => ctx.Resolve<ApiSettings>()
                            .GetDatabaseEngine()))
                .As<ISecurityContextFactory>()
                .SingleInstance();
            builder.RegisterType<SqlSandboxProvisioner>().As<ISandboxProvisioner>().SingleInstance();
        }
    }
}
#endif