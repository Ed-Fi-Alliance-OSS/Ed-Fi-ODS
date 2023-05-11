// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
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
                .Named<IInterceptor>("cache-ods-instances")
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "ODS Instance Configurations",
                            TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.AbsoluteExpirationSeconds));
                    })
                .SingleInstance();
            
            builder.RegisterType<CachingInterceptor>()
                .Named<IInterceptor>("cache-profile-metadata")
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();

                        return (ICacheProvider<ulong>)new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Profile Metadata",
                            TimeSpan.FromSeconds(apiSettings.Caching.Profiles.AbsoluteExpirationSeconds));
                    })
                .SingleInstance();
        }
    }
}
