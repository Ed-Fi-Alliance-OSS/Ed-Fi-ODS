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
using log4net;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.ExternalCache;

public abstract class ExternalCacheModule : ConditionalModule, IExternalCacheModule
{
    private const string ApiClientDetailsCacheProviderName = "ApiClientDetailsTieredCacheProvider";

    private static readonly ILog _logger = LogManager.GetLogger(typeof(ExternalCacheModule));

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
        LogConfiguredCacheModes();

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
            .WithParameter(
                new ResolvedParameter(
                    (p, _) => p.ParameterType == typeof(RedisCacheResilience),
                    (_, c) => c.ResolveOptional<RedisCacheResilience>()))
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

        if (_cacheSettings.ApiClientDetails.CachingMode == CachingMode.Hybrid)
        {
            // Hybrid: short-lived in-process L1 cache in front of the external (L2) cache.
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
        }
        else
        {
            // External (L2 only): the caching decorator uses the external cache provider directly.
            builder.Register(ctx => ctx.Resolve<IExternalCacheProvider<string>>())
                .Named<ICacheProvider<string>>(ApiClientDetailsCacheProviderName)
                .SingleInstance();
        }

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
        if (_cacheSettings.Descriptors.CachingMode == CachingMode.Hybrid)
        {
            // Hybrid: short-lived in-process L1 cache in front of the external (L2) cache.
            builder.Register(
                    ctx =>
                    {
                        int absoluteExpirationSeconds = _cacheSettings.Descriptors.AbsoluteExpirationSeconds;
                        int l1CacheDurationSeconds = _cacheSettings.Descriptors.L1CacheDurationSeconds;
                        var distributedCache = ctx.Resolve<IDistributedCache>();
                        var absoluteExpiration = TimeSpan.FromSeconds(absoluteExpirationSeconds);
                        var resilience = ctx.ResolveOptional<RedisCacheResilience>();

                        return new TieredCacheProvider<ulong>(
                            ctx.Resolve<IMemoryCache>(),
                            new ExternalCacheProvider<ulong>(distributedCache, TimeSpan.Zero, absoluteExpiration, resilience),
                            TimeSpan.FromSeconds(l1CacheDurationSeconds),
                            new AsyncExternalCacheProvider<ulong>(distributedCache, TimeSpan.Zero, absoluteExpiration, resilience));
                    })
                .As<ICacheProvider<ulong>>()
                .As<IAsyncCacheProvider<ulong>>()
                .SingleInstance();
        }
        else
        {
            // External (L2 only): register a single async provider as BOTH the synchronous and asynchronous
            // provider so the AsyncCachingInterceptor's reference-equality check skips the blocking
            // synchronous path and always uses async access — no in-process L1 tier.
            builder.Register(
                    ctx =>
                    {
                        int absoluteExpirationSeconds = _cacheSettings.Descriptors.AbsoluteExpirationSeconds;
                        var distributedCache = ctx.Resolve<IDistributedCache>();
                        var absoluteExpiration = TimeSpan.FromSeconds(absoluteExpirationSeconds);
                        var resilience = ctx.ResolveOptional<RedisCacheResilience>();

                        return new AsyncExternalCacheProvider<ulong>(distributedCache, TimeSpan.Zero, absoluteExpiration, resilience);
                    })
                .As<ICacheProvider<ulong>>()
                .As<IAsyncCacheProvider<ulong>>()
                .SingleInstance();
        }

        builder.RegisterType<AsyncContextualCachingInterceptor<OdsInstanceConfiguration>>()
            .Named<IInterceptor>(InterceptorCacheKeys.Descriptors)
            .SingleInstance();
    }

    private void OverridePersonUniqueIdToUsiCache(ContainerBuilder builder)
    {
        if (!IsProviderSelected())
        {
            return;
        }

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

        bool hybrid = _cacheSettings.PersonUniqueIdToUsi.CachingMode == CachingMode.Hybrid;

        builder.Register(ctx => BuildUsiByUniqueIdMapCache(ctx, hybrid))
            .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>>()
            .SingleInstance();

        builder.Register(ctx => BuildUniqueIdByUsiMapCache(ctx, hybrid))
            .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
            .SingleInstance();
    }

    private IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> BuildUsiByUniqueIdMapCache(
        IComponentContext ctx, bool hybrid)
    {
        var person = _cacheSettings.PersonUniqueIdToUsi;

        var l2 = new RedisUsiByUniqueIdMapCache(
            ctx.Resolve<IRedisConnectionProvider>(),
            ctx.Resolve<RedisCacheResilience>(),
            ToExpirationPeriod(person.AbsoluteExpirationSeconds),
            ToExpirationPeriod(person.SlidingExpirationSeconds),
            person.BatchSize);

        if (!hybrid)
        {
            return l2;
        }

        var l1 = new InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>(
            ctx.Resolve<IMemoryCache>(),
            TimeSpan.FromSeconds(person.L1CacheDurationSeconds),
            TimeSpan.Zero);

        return new TieredMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>(l1, l2);
    }

    private IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> BuildUniqueIdByUsiMapCache(
        IComponentContext ctx, bool hybrid)
    {
        var person = _cacheSettings.PersonUniqueIdToUsi;

        var l2 = new RedisUniqueIdByUsiMapCache(
            ctx.Resolve<IRedisConnectionProvider>(),
            ctx.Resolve<RedisCacheResilience>(),
            ToExpirationPeriod(person.AbsoluteExpirationSeconds),
            ToExpirationPeriod(person.SlidingExpirationSeconds),
            person.BatchSize);

        if (!hybrid)
        {
            return l2;
        }

        var l1 = new InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>(
            ctx.Resolve<IMemoryCache>(),
            TimeSpan.FromSeconds(person.L1CacheDurationSeconds),
            TimeSpan.Zero);

        return new TieredMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>(l1, l2);
    }

    private static TimeSpan? ToExpirationPeriod(int seconds)
    {
        return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
    }

    // Emits a one-time, startup summary of the effective caching mode for each cache type so operators can
    // confirm whether the API is using in-memory, external (L2 only), or hybrid (L1 + L2) caching.
    private void LogConfiguredCacheModes()
    {
        if (!_logger.IsInfoEnabled)
        {
            return;
        }

        _logger.Info(
            $"Cache mode configuration: provider='{_cacheSettings.ExternalCacheProvider}', "
            + $"Descriptors={DescribeMode(_cacheSettings.Descriptors.UseExternalCache, _cacheSettings.Descriptors.CachingMode)}, "
            + $"PersonUniqueIdToUsi={DescribeMode(_cacheSettings.PersonUniqueIdToUsi.UseExternalCache, _cacheSettings.PersonUniqueIdToUsi.CachingMode)}, "
            + $"ApiClientDetails={DescribeMode(_cacheSettings.ApiClientDetails.UseExternalCache, _cacheSettings.ApiClientDetails.CachingMode)}.");
    }

    private static string DescribeMode(bool useExternalCache, CachingMode cachingMode)
    {
        return !useExternalCache
            ? "InMemory"
            : cachingMode.ToString();
    }
}
