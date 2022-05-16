// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class OverrideIntegrationTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIdentitiesService>()
                .As<IIdentityService>()
                .As<IIdentityServiceAsync>()
                .SingleInstance();

            builder.RegisterType<IntegrationTestOdsConnectionStringProvider>()
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterType<FakedOAuthTokenAuthenticator>()
                .As<IOAuthTokenAuthenticator>()
                .InstancePerLifetimeScope();
        }
    }
}
