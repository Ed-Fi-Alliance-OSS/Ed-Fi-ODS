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
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Features.MultiTenancy;
using EdFi.Security.DataAccess.Providers;
using log4net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Container.Modules;

public class MultiTenancyModule : ConditionalModule
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(MultiTenancyModule));
    
    public MultiTenancyModule(IFeatureManager featureManager)
        : base(featureManager) { } 

    protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.MultiTenancy);

    protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
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

        builder.RegisterType<MultiTenantConnectionStringOverridesApplicator>()
            .As<IConnectionStringOverridesApplicator>()
            .SingleInstance();
        
        // Override interceptors to include tenant context
        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
            .Named<IInterceptor>(InterceptorCacheKeys.Security)
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
            .Named<IInterceptor>(InterceptorCacheKeys.ApiClientDetails)
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
            .Named<IInterceptor>(InterceptorCacheKeys.ProfileMetadata)
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();
                    var mediator = ctx.Resolve<IMediator>();

                    return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "Profile Metadata",
                        TimeSpan.FromSeconds(apiSettings.Caching.Profiles.AbsoluteExpirationSeconds),
                        () => mediator.Publish(new ProfileMetadataCacheExpired()));
                })
            .SingleInstance();
        
        builder.RegisterType<ContextualCachingInterceptor<TenantConfiguration>>()
            .Named<IInterceptor>(InterceptorCacheKeys.OdsInstances)
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();
                    
                    var cacheProvider = new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                        "ODS Instance Configurations",
                        TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.AbsoluteExpirationSeconds));

                    // Subscribe to any changes related to the Tenants section of the configuration, and clear it explicitly
                    var options = ctx.Resolve<IOptionsMonitor<TenantsSection>>();
                    options.OnChange(config =>
                    {
                        if (_logger.IsDebugEnabled)
                        {
                            _logger.Debug($"Tenants configuration change detected. Clearing interceptor cache provider...");
                        }
                        
                        cacheProvider.Clear();
                    });

                    return (ICacheProvider<ulong>) cacheProvider;
                })
            .SingleInstance();

        builder.RegisterDecorator<MultiTenantApiJobSchedulerDecorator, IApiJobScheduler>();
    }
}
