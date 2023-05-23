// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Castle.DynamicProxy;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.MultiTenancy;
using EdFi.Security.DataAccess.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Container.Modules;

public class MultiTenancyModule : ConditionalModule
{
    public MultiTenancyModule(ApiSettings apiSettings)
        : base(apiSettings, nameof(MultiTenancyModule)) { }

    public override bool IsSelected() => IsFeatureEnabled(ApiFeature.MultiTenancy);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        builder.RegisterType<TenantIdentificationMiddleware>()
            .As<IMiddleware>()
            .AsSelf()
            .SingleInstance();
        
        builder.RegisterType<TenantConfigurationMapProvider>()
            .As<ITenantConfigurationMapProvider>()
            .SingleInstance();
        
        builder.RegisterType<MultiTenantOdsInstanceHashIdGenerator>()
            .As<IOdsInstanceHashIdGenerator>()
            .SingleInstance();

        builder.RegisterType<MultiTenantSecurityDatabaseConnectionStringProvider>()
            .As<ISecurityDatabaseConnectionStringProvider>()
            .SingleInstance();

        builder.RegisterType<MultiTenantAdminDatabaseConnectionStringProvider>()
            .As<IAdminDatabaseConnectionStringProvider>()
            .SingleInstance();

        // Override interceptors to include tenant context
        builder.RegisterType<CachingInterceptor>()
            .Named<IInterceptor>("cache-tenants")
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "Tenant Configurations",
                        TimeSpan.FromSeconds(apiSettings.Caching.Tenants.AbsoluteExpirationSeconds));
                })
            .SingleInstance();

        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
            .Named<IInterceptor>("cache-security")
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "Security",
                        TimeSpan.FromMinutes(apiSettings.Caching.Security.AbsoluteExpirationMinutes));
                })
            .SingleInstance();
        
        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
            .Named<IInterceptor>("cache-api-client-details")
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "API Client Details",
                        TimeSpan.FromSeconds(apiSettings.Caching.ApiClientDetails.AbsoluteExpirationSeconds));
                })
            .SingleInstance();
        
        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
            .Named<IInterceptor>("cache-profile-metadata")
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "Profile Metadata",
                        TimeSpan.FromSeconds(apiSettings.Caching.Profiles.AbsoluteExpirationSeconds));
                })
            .SingleInstance();
        
        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
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

        builder.RegisterDecorator<MultiTenantApiJobSchedulerDecorator, IApiJobScheduler>();
    }
}
