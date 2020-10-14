// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Models.Identity;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.TestObjects;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class OverrideIdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIdentitiesService>()
                .As<IIdentityService>()
                .As<IIdentityServiceAsync>();

            builder.RegisterType<YearSpecificOdsConnectionStringProvider>()
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterType<FakedAuthenticationProvider>()
                .As<IAuthenticationProvider>();
        }
    }
}
