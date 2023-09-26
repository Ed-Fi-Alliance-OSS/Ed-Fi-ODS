// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Castle.DynamicProxy;
using EdFi.Common.Security;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.ExternalCache.Redis;
using Microsoft.Extensions.Caching.Distributed;

namespace EdFi.Ods.Features.ExternalCache
{
    public abstract class ExternalCacheModule : ConditionalModule, IExternalCacheModule
    {
        public ExternalCacheModule(ApiSettings apiSettings, string moduleName)
           : base(apiSettings, moduleName) { }

        public override bool IsSelected() => ApiSettings.Caching.ApiClientDetails.UseExternalCache ||
            ApiSettings.Caching.Descriptors.UseExternalCache ||
            ApiSettings.Caching.PersonUniqueIdToUsi.UseExternalCache;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            RegisterDistributedCache(builder);

            RegisterProvider(builder);

            if (ApiSettings.Caching.ApiClientDetails.UseExternalCache)
            {
                OverrideApiClientDetailsCache(builder);
            }

            if (ApiSettings.Caching.Descriptors.UseExternalCache)
            {
                OverrideDescriptorsCache(builder);
            }

            if (ApiSettings.Caching.PersonUniqueIdToUsi.UseExternalCache)
            {
                OverridePersonUniqueIdToUsiCache(builder);
            }
        }

        public abstract string ExternalCacheProvider { get; }

        public bool IsProviderSelected(string externalCacheProvider)
        {
            return ExternalCacheProvider == externalCacheProvider;
        }

        public void RegisterProvider(ContainerBuilder builder)
        {
            builder.RegisterType<ExternalCacheProvider<string>>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(TimeSpan),
                        (p, c) => GetDefaultExpiration(c)))
                .As<IExternalCacheProvider<string>>()
                .SingleInstance();
        }

        private TimeSpan GetDefaultExpiration(IComponentContext componentContext)
        {
            return TimeSpan.FromSeconds(1800);
        }

        public abstract void RegisterDistributedCache(ContainerBuilder builder);

        public void OverrideApiClientDetailsCache(ContainerBuilder builder)
        {
            builder.RegisterType<ApiClientDetailsCacheKeyProvider>()
                .As<IApiClientDetailsCacheKeyProvider>()
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
                componentContext.Resolve<IExternalCacheProvider<string>>(),
                componentContext.Resolve<IApiClientDetailsCacheKeyProvider>());
        }

        public void OverrideDescriptorsCache(ContainerBuilder builder)
        {
            // Override the named interceptor registration to use the external (distributed) cache
            builder.RegisterType<ContextualCachingInterceptor<OdsInstanceConfiguration>>()
                .Named<IInterceptor>("cache-descriptors")
                .WithParameter(
                    ctx =>
                    {
                        int absoluteExpirationSeconds = ApiSettings.Caching.Descriptors.AbsoluteExpirationSeconds;

                        return (ICacheProvider<ulong>)new ExternalCacheProvider<ulong>(
                            ctx.Resolve<IDistributedCache>(),
                            TimeSpan.Zero,
                            TimeSpan.FromSeconds(absoluteExpirationSeconds));
                    })
                .SingleInstance();
        }

        public void OverridePersonUniqueIdToUsiCache(ContainerBuilder builder)
        {
            if (IsProviderSelected("Redis"))
            {
                builder.RegisterType<RedisUsiByUniqueIdMapCache>()
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name == "configuration",
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();

                                return apiSettings.Caching.Redis.Configuration;
                            }))
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name.Equals("slidingExpirationPeriod", StringComparison.OrdinalIgnoreCase),
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();
                                int seconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
                            }))
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.OrdinalIgnoreCase),
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();
                                int seconds = apiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;
                                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
                            }))
                    .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>>()
                    .SingleInstance();

                builder.RegisterType<RedisUniqueIdByUsiMapCache>()
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name == "configuration",
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();

                                return apiSettings.Caching.Redis.Configuration;
                            }))
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name.Equals("slidingExpirationPeriod", StringComparison.OrdinalIgnoreCase),
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();
                                int seconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
                            }))
                    .WithParameter(
                        new ResolvedParameter(
                            (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.OrdinalIgnoreCase),
                            (p, c) =>
                            {
                                var apiSettings = c.Resolve<ApiSettings>();
                                int seconds = apiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;
                                return seconds > 0 ? TimeSpan.FromSeconds(seconds) : null;
                            }))
                    .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                    .SingleInstance();
            }
        }
    }
}
