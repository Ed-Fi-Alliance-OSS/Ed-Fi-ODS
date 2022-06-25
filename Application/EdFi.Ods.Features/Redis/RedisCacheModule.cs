// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Security.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace EdFi.Ods.Features.Redis
{
    public class RedisCacheModule : ConditionalModule
    {
        public RedisCacheModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(RedisCacheModule)) { }

        public override bool IsSelected() => ApiSettings.ApiCacheFeature.CacheProvider == CacheProviders.Redis;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.Register(cx => ConnectionMultiplexer.Connect(new ConfigurationOptions {
                EndPoints = { { ApiSettings.ApiCacheFeature.Configuration, 6379 } },
                AbortOnConnectFail = true
                }, Console.Out))
                .As<IConnectionMultiplexer>()
                .SingleInstance();

            builder.RegisterType<RedisCacheProvider>()
            .WithParameter(
                new ResolvedParameter(
                (p, c) => p.ParameterType == typeof(TimeSpan),
                (p, c) => GetRedisDefaultExpiration(c)))
            .As<IRedisCacheProvider>()
            .SingleInstance();

            if (ApiSettings.ApiCacheFeature.EnableForApiClientDetailsCache)
            {
                OverrideApiClientDetailsCache(builder);
            }

            if (ApiSettings.ApiCacheFeature.EnableForDescriptorsCache)
            {
                OverrideDescriptorsCache(builder);
            }

            if (ApiSettings.ApiCacheFeature.EnablePersonUniqueIdToUsiCache)
            {
                OverridePersonUniqueIdtoUsiCache(builder);
            }

            if (ApiSettings.ApiCacheFeature.EnableForSecurityCache)
            {
                OverrideSecurityRepository(builder);
            }
        }

        private static TimeSpan GetRedisDefaultExpiration(IComponentContext componentContext)
        {
            int defaultExpirationSeconds =
                componentContext.Resolve<IConfiguration>()
                    .GetValue<int>("Redis:DefaultExpirationSeconds");

            return defaultExpirationSeconds > 0
                ? TimeSpan.FromSeconds(defaultExpirationSeconds)
                : TimeSpan.FromHours(8);
        }

        private static void OverrideSecurityRepository(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityRepository>()
                .As<ISecurityRepository>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name == "cacheTimeoutInMinutes",
                        (p, c) =>
                        {
                            var configuration = c.Resolve<IConfiguration>();

                            int period = configuration.GetValue<int?>(
                                "Caching:Security:AbsoluteExpirationMinutes") ?? 10;

                            return period;
                        }))
                .SingleInstance();

            builder.RegisterType<SecurityRepositoryInitializer>()
                .As<ISecurityRepositoryInitializer>()
                .SingleInstance();
        }

        private static void OverrideDescriptorsCache(ContainerBuilder builder)
        {
            builder.RegisterType<DescriptorsCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ICacheProvider),
                        (p, c) =>
                        {
                            var configuration = c.Resolve<IConfiguration>();

                            int expirationPeriod =
                                configuration.GetValue<int?>(
                                    "Caching:Descriptors:AbsoluteExpirationSeconds") ?? 60;

                            return new RedisCacheProvider(
                                c.Resolve<Lazy<IConnectionMultiplexer>>().Value,
                                TimeSpan.FromSeconds(expirationPeriod));
                        }))
                .As<IDescriptorsCache>()
                .SingleInstance();
        }

        private static void OverrideApiClientDetailsCache(ContainerBuilder builder)
        {
            builder.RegisterDecorator<IApiClientDetailsProvider>((context, parameters, instance) => GetCachingApiClientDetailsProviderDecorator(context, instance));
        }

        private static CachingApiClientDetailsProviderDecorator GetCachingApiClientDetailsProviderDecorator(IComponentContext componentContext, IApiClientDetailsProvider apiClientDetailsProvider)
        {
            return new CachingApiClientDetailsProviderDecorator(apiClientDetailsProvider,
                componentContext.Resolve<IRedisCacheProvider>(),
                componentContext.Resolve<IApiClientDetailsCacheKeyProvider>());
        }

        private static void OverridePersonUniqueIdtoUsiCache(ContainerBuilder builder)
        {
            builder.RegisterType<PersonUniqueIdToUsiCache>()
            .WithParameter(new NamedParameter("synchronousInitialization", false))
            .WithParameter(
                new ResolvedParameter(
                  (p, c) => p.Name.Equals("cacheProvider", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                    {
                        var configuration = c.Resolve<IConfiguration>();

                        int expirationPeriod =
                            configuration.GetValue<int?>(
                                "Caching:PersonUniqueIdToUsi:AbsoluteExpirationSeconds") ?? 60;

                        return new RedisCacheProvider(
                            c.Resolve<Lazy<IConnectionMultiplexer>>().Value,
                            TimeSpan.FromSeconds(expirationPeriod));
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("slidingExpiration", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      var configuration = c.Resolve<IConfiguration>();

                      int period = configuration.GetValue<int?>("Caching:PersonUniqueIdToUsi:SlidingExpirationSeconds") ??
                                   14400;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      var configuration = c.Resolve<IConfiguration>();

                      int period = configuration.GetValue<int?>("Caching:PersonUniqueIdToUsi:AbsoluteExpirationSeconds") ??
                                   86400;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStudentCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      var configuration = c.Resolve<IConfiguration>();

                      return configuration.GetValue<bool?>("Caching:PersonUniqueIdToUsi:SuppressStudentCache") ?? false;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStaffCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      var configuration = c.Resolve<IConfiguration>();

                      return configuration.GetValue<bool?>("Caching:PersonUniqueIdToUsi:SuppressStaffCache") ?? false;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressParentCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      var configuration = c.Resolve<IConfiguration>();

                      return configuration.GetValue<bool?>("Caching:PersonUniqueIdToUsi:SuppressParentCache") ?? false;
                  }))
          .As<IPersonUniqueIdToUsiCache>()
          .SingleInstance();
        }
    }
}
