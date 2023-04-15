// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Container.Modules
{
    public class SecurityRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityRepository>()
                .As<ISecurityRepository>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IInterceptor>("cache-security")
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Security",
                            TimeSpan.FromMinutes(apiSettings.Caching.Security.AbsoluteExpirationMinutes));
                    });
            
            builder.RegisterType<SecurityTableGateway>()
                .As<ISecurityTableGateway>()
                .SingleInstance();
        }
    }
}
