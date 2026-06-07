// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Castle.DynamicProxy;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.ExternalCache.Redis;
using EdFi.Ods.Features.Services.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.ExternalCache;

public abstract class ExternalCacheModule : ConditionalModule, IExternalCacheModule
{
    private const string ApiClientDetailsCacheProviderName = "ApiClientDetailsTieredCacheProvider";

    private readonly CacheSettings _cacheSettings;

    protected ExternalCacheModule(IFeatureManager featureManager, ApiSettings apiSettings)
        : base(featureManager)
    {
        _cacheSettings = apiSettings.Caching;
    }

    protected override bool IsSelected() => _cacheSettings.ApiClientDetails.UseExternalCache
        || _cacheSettings.Descriptors.UseExternalCache
        || _cacheSettings.PersonUniqueIdToUsi.UseExternalCache;

    protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        RegisterDistributedCache(builder);

        RegisterProvider(builder);

        if (_cacheSettings.ApiClientDetails.UseExternalCache)
        {
            OverrideApiClientDetailsCache(builder);
        }

        if (_cacheSettings.Descriptors.UseExternalCache)
        {
            OverrideDescriptorsCache(builder);
        }

        if (_cacheSettings.PersonUniqueIdToUsi.UseExternalCache)
        {
            OverridePersonUniqueIdToUsiCache(builder);
        }
    }

    public abstract string ExternalCacheProvider { get; }

    public bool IsProviderSelected()
    {
        return ExternalCacheProvider.EqualsIgnoreCase(_cacheSettings.ExternalCacheProvider);
    }

    public void RegisterProvider(ContainerBuilder builder)
    {
        builder.RegisterType<ExternalCacheProvider<string>>()
            .WithParameter(
                new ResolvedParameter(
                    (p, _) => p.ParameterType == typeof(TimeSpan),
                    (_, _) => GetDefaultExpiration()))
            .As<IExternalCacheProvider<string>>()
            .SingleInstance();
    }

    private static TimeSpan GetDefaultExpiration()
    {
        return TimeSpan.FromSeconds(1800);
    }

    public abstract void RegisterDistributedCache(ContainerBuilder builder);

    private void OverrideApiClientDetailsCache(ContainerBuilder builder)
    {
        builder.RegisterType<ApiClientDetailsCacheKeyProvider>()
            .As<IApiClientDetailsCacheKeyProvider>()
            .SingleInstance();

        builder.Register(
                ctx =>
                {
                    int l1CacheDurationSeconds = _cacheSettings.ApiClientDetails.L1CacheDurationSeconds;

                    return new TieredCacheProvider<string>(
                        ctx.Resolve<IMemoryCache>(),
                        ctx.Resolve<IExternalCacheProvider<string>>(),
                        TimeSpan.FromSeconds(l1CacheDurationSeconds));
                })
            .Named<ICacheProvider<string>>(ApiClientDetailsCacheProviderName)
            .SingleInstance();

        builder.RegisterDecorator<IApiClientDetailsProvider>(
            (context, parameters, instance) => GetCachingApiClientDetailsProviderDecorator(context, instance));
    }

    private static CachingApiClientDetailsProviderDecorator GetCachingApiClientDetailsProviderDecorator(
        IComponentContext componentContext,
        IApiClientDetailsProvider apiClientDetailsProvider)
    {
        return new CachingApiClientDetailsProviderDecorator(
            apiClientDetailsProvider,
            componentContext.ResolveNamed<ICacheProvider<string>>(ApiClientDetailsCacheProviderName),
            componentContext.Resolve<IApiClientDetailsCacheKeyProvider>());
    }

    private void OverrideDescriptorsCache(ContainerBuilder builder)
    {
        builder.Register(
                ctx =>
                {
                    int absoluteExpirationSeconds = _cacheSettings.Descriptors.AbsoluteExpirationSeconds;
                    int l1CacheDurationSeconds = _cacheSettings.Descriptors.L1CacheDurationSeconds;
                    var distributedCache = ctx.Resolve<IDistributedCache>();
                    var absoluteExpiration = TimeSpan.FromSeconds(absoluteExpirationSeconds);

                    return new TieredCacheProvider<ulong>(
                        ctx.Resolve<IMemoryCache>(),
                        new ExternalCacheProvider<ulong>(distributedCache, TimeSpan.Zero, absoluteExpiration),
                        TimeSpan.FromSeconds(l1CacheDurationSeconds),
                        new AsyncExternalCacheProvider<ulong>(distributedCache, TimeSpan.Zero, absoluteExpiration));
                })
            .As<ICacheProvider<ulong>>()
            .As<IAsyncCacheProvider<ulong>>()
            .SingleInstance();

        builder.RegisterType<AsyncContextualCachingInterceptor<OdsInstanceConfiguration>>()
            .Named<IInterceptor>(InterceptorCacheKeys.Descriptors)
            .SingleInstance();
    }

    // TODO: does the person unique ID cache need to have the TieredCacheProvider for L1/L2 fallback?

    private void OverridePersonUniqueIdToUsiCache(ContainerBuilder builder)
    {
        if (IsProviderSelected())
        {
            builder.Register(
                    c => new RedisConnectionProvider(c.Resolve<ApiSettings>().Services.Redis))
                .As<IRedisConnectionProvider>()
                .IfNotRegistered(typeof(IRedisConnectionProvider))
                .SingleInstance();

            builder.RegisterType<RedisDistributedLockProvider>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(RedisCacheResilience),
                        (_, c) => c.Resolve<RedisCacheResilience>()))
                .As<IDistributedLockProvider>()
                .SingleInstance();

            builder.RegisterType<RedisUsiByUniqueIdMapCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(RedisCacheResilience),
                        (_, c) => c.Resolve<RedisCacheResilience>()))
                .WithParameter(CreateExpirationParameter("slidingExpirationPeriod", c => c.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds))
                .WithParameter(CreateExpirationParameter("absoluteExpirationPeriod", c => c.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>>()
                .SingleInstance();

            builder.RegisterType<RedisUniqueIdByUsiMapCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(RedisCacheResilience),
                        (_, c) => c.Resolve<RedisCacheResilience>()))
                .WithParameter(CreateExpirationParameter("slidingExpirationPeriod", c => c.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds))
                .WithParameter(CreateExpirationParameter("absoluteExpirationPeriod", c => c.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                .SingleInstance();
        }
    }

    private static ResolvedParameter CreateExpirationParameter(
        string parameterName,
        Func<ApiSettings, int> getSeconds)
    {
        return new ResolvedParameter(
            (p, _) => p.Name.EqualsIgnoreCase(parameterName),
            (_, c) =>
            {
                int seconds = getSeconds(c.Resolve<ApiSettings>());
                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
            });
    }
}
