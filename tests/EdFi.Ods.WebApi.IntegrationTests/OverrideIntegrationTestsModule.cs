// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.SingleFlight;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class OverrideIntegrationTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IntegrationTestOdsConnectionStringProvider>()
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterType<FakedOAuthTokenAuthenticator>()
                .As<IOAuthTokenAuthenticator>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<FakeOdsInstanceConfigurationProvider>()
                .As<IOdsInstanceConfigurationProvider>()
                .SingleInstance();
            
            builder.RegisterType<CachingInterceptor>()
                .Named<IAsyncInterceptor>(InterceptorCacheKeys.OdsInstances)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                            "ODS Instance Configurations",
                            TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.AbsoluteExpirationSeconds),
                            TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.CreationTimeoutSeconds));
                    })
                .SingleInstance();

            // Wrap into AsyncDeterminationInterceptor to support async interception
            builder.Register(ctx =>
                    new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.OdsInstances)))
                .Named<IInterceptor>(InterceptorCacheKeys.OdsInstances);

            builder.RegisterType<CachingInterceptor>()
                .Named<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                            "Profile Metadata",
                            TimeSpan.FromSeconds(apiSettings.Caching.Profiles.AbsoluteExpirationSeconds),
                            TimeSpan.FromSeconds(apiSettings.Caching.Profiles.CreationTimeoutSeconds));
                    })
                .SingleInstance();

            // Wrap into AsyncDeterminationInterceptor to support async interception
            builder.Register(ctx =>
                    new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)))
                .Named<IInterceptor>(InterceptorCacheKeys.ProfileMetadata);
        }
    }
}
