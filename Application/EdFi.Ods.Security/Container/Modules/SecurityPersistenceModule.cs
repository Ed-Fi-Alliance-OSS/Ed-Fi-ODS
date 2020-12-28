// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Ods.Security.Container.Modules
{
    public class SecurityPersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientAppRepo>()
                .As<IClientAppRepo>()
                .SingleInstance();

            builder.RegisterType<AccessTokenClientRepo>()
                .As<IAccessTokenClientRepo>()
                .SingleInstance();

            builder.RegisterType<UsersContextFactory>()
                .As<IUsersContextFactory>()
                .SingleInstance();

            builder.RegisterType<SecurityContextFactory>()
                .As<ISecurityContextFactory>()
                .SingleInstance();
        }
    }
}
