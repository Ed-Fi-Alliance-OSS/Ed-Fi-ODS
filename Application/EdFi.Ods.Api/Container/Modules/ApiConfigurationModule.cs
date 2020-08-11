﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ApiConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NetCoreApiConfigurationProvider>().As<IApiConfigurationProvider>().SingleInstance();

            builder.Register(c => c.Resolve<IApiConfigurationProvider>().DatabaseEngine)
                .SingleInstance();
        }
    }
}
#endif