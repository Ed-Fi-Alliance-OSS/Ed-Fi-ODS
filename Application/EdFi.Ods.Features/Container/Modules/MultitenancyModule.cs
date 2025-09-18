// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Castle.DynamicProxy;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.SingleFlight;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Caching.CacheKeyProviders;
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
        builder.RegisterType<CachingInterceptor>()
            .Named<IAsyncInterceptor>(InterceptorCacheKeys.Security)
            // Method signature built using tenant configuration as context
            .WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IMethodSignatureCacheKeyProvider),
                (pi, ctx) => ctx.Resolve<ContextualMethodSignatureCacheKeyProvider<TenantConfiguration>>())
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ISingleFlightCache<ulong, object>)new ExpiringSingleFlightCache<ulong, object>(
                        "Security",
                        TimeSpan.FromMinutes(apiSettings.Caching.Security.AbsoluteExpirationMinutes),
                        TimeSpan.FromSeconds(apiSettings.Caching.Security.CreationTimeoutSeconds));
                })
            .SingleInstance();
        
        // Wrap into AsyncDeterminationInterceptor to support async interception
        builder.Register(ctx =>
                new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.Security)))
            .Named<IInterceptor>(InterceptorCacheKeys.Security);

        builder.RegisterType<CachingInterceptor>()
            .Named<IAsyncInterceptor>(InterceptorCacheKeys.ApiClientDetails)
            // Method signature built using tenant configuration as context
            .WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IMethodSignatureCacheKeyProvider),
                (pi, ctx) => ctx.Resolve<ContextualMethodSignatureCacheKeyProvider<TenantConfiguration>>())
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                        "API Client Details",
                        TimeSpan.FromSeconds(apiSettings.Caching.ApiClientDetails.AbsoluteExpirationSeconds),
                        TimeSpan.FromSeconds(apiSettings.Caching.ApiClientDetails.CreationTimeoutSeconds));
                })
            .SingleInstance();
        
        // Wrap into AsyncDeterminationInterceptor to support async interception
        builder.Register(ctx =>
                new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.ApiClientDetails)))
            .Named<IInterceptor>(InterceptorCacheKeys.ApiClientDetails);

        builder.RegisterType<CachingInterceptor>()
            .Named<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)
            // Method signature built using tenant configuration as context
            .WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IMethodSignatureCacheKeyProvider),
                (pi, ctx) => ctx.Resolve<ContextualMethodSignatureCacheKeyProvider<TenantConfiguration>>())
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();
                    var mediator = ctx.Resolve<IMediator>();

                    return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                        "Profile Metadata",
                        TimeSpan.FromSeconds(apiSettings.Caching.Profiles.AbsoluteExpirationSeconds),
                        () => mediator.Publish(new ProfileMetadataCacheExpired()),
                        TimeSpan.FromSeconds(apiSettings.Caching.Profiles.CreationTimeoutSeconds));
                })
            .SingleInstance();
        
        // Wrap into AsyncDeterminationInterceptor to support async interception
        builder.Register(ctx =>
                new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)))
            .Named<IInterceptor>(InterceptorCacheKeys.ProfileMetadata);

        builder.RegisterType<CachingInterceptor>()
            .Named<IAsyncInterceptor>(InterceptorCacheKeys.OdsInstances)
            // Method signature built using tenant configuration as context
            .WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IMethodSignatureCacheKeyProvider),
                (pi, ctx) => ctx.Resolve<ContextualMethodSignatureCacheKeyProvider<TenantConfiguration>>())
            .WithParameter(
                ctx =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();
                    
                    var cache = new ExpiringSingleFlightCache<ulong, object>(
                        "ODS Instance Configurations",
                        TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.AbsoluteExpirationSeconds),
                        TimeSpan.FromSeconds(apiSettings.Caching.OdsInstances.CreationTimeoutSeconds));

                    // Subscribe to any changes related to the Tenants section of the configuration, and clear it explicitly
                    var options = ctx.Resolve<IOptionsMonitor<TenantsSection>>();
                    options.OnChange(config =>
                    {
                        if (_logger.IsDebugEnabled)
                        {
                            _logger.Debug($"Tenants configuration change detected. Clearing interceptor cache provider...");
                        }
                        
                        cache.Clear();
                    });

                    return (ISingleFlightCache<ulong, object>) cache;
                })
            .SingleInstance();

        // Wrap into AsyncDeterminationInterceptor to support async interception
        builder.Register(ctx =>
                new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.OdsInstances)))
            .Named<IInterceptor>(InterceptorCacheKeys.OdsInstances);

        builder.RegisterDecorator<MultiTenantApiJobSchedulerDecorator, IApiJobScheduler>();
    }
}
