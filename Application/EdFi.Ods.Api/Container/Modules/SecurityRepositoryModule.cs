// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Caching.SingleFlight;
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
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<SecurityTableGateway>()
                .As<ISecurityTableGateway>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IAsyncInterceptor>(InterceptorCacheKeys.Security)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                            "Security",
                            TimeSpan.FromMinutes(apiSettings.Caching.Security.AbsoluteExpirationMinutes));
                    })
                .SingleInstance();
            
            builder.Register(ctx =>
                    new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.Security)))
                .Named<IInterceptor>(InterceptorCacheKeys.Security); // Wrap into AsyncDeterminationInterceptor to support async interception
        }
    }
}
