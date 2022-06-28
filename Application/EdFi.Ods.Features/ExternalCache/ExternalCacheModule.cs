// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.ChangeQueries.Providers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;

namespace EdFi.Ods.Features.ExternalCache
{
    public abstract class ExternalCacheModule : ConditionalModule, IExternalCacheModule
    {
        public ExternalCacheModule(ApiSettings apiSettings, string moduleName)
           : base(apiSettings, moduleName) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.ExternalCache);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            RegisterDistributedCache(builder);
            
            RegisterProvider(builder);

            if (ApiSettings.ExternalCache.EnableForApiClientDetailsCache)
            {
                OverrideApiClientDetailsCache(builder);
            }

            if (ApiSettings.ExternalCache.EnableForAvailableChangeVersionCache)
            {
                OverrideAvailableChangeVersionCache(builder);
            }

            if (ApiSettings.ExternalCache.EnableForDescriptorsCache)
            {
                OverrideDescriptorsCache(builder);
            }

            if (ApiSettings.ExternalCache.EnablePersonUniqueIdToUsiCache)
            {
                OverridePersonUniqueIdtoUsiCache(builder);
            }
        }

        public abstract ExternalCacheProviders ExternalCacheProvider { get; }
        
        public bool IsProviderSelected(ExternalCacheProviders externalCacheProvider)
        {
            return ExternalCacheProvider == externalCacheProvider;
        }

        public void RegisterProvider(ContainerBuilder builder)
        {
            builder.RegisterType<ExternalCacheProvider>()
            .WithParameter(
                new ResolvedParameter(
                (p, c) => p.ParameterType == typeof(TimeSpan),
                (p, c) => GetDefaultExpiration(c)))
            .As<IExternalCacheProvider>()
            .SingleInstance();
        }

        private TimeSpan GetDefaultExpiration(IComponentContext componentContext)
        {
            int defaultExpirationSeconds = ApiSettings.ExternalCache.DefaultExpirationSeconds;

            return defaultExpirationSeconds > 0
                ? TimeSpan.FromSeconds(defaultExpirationSeconds)
                : TimeSpan.FromHours(8);
        }

        public abstract void RegisterDistributedCache(ContainerBuilder builder);
        public void OverrideApiClientDetailsCache(ContainerBuilder builder)
        {
            builder.RegisterDecorator<IApiClientDetailsProvider>((context, parameters, instance) => GetCachingApiClientDetailsProviderDecorator(context, instance));
        }

        private static CachingApiClientDetailsProviderDecorator GetCachingApiClientDetailsProviderDecorator(IComponentContext componentContext, IApiClientDetailsProvider apiClientDetailsProvider)
        {
            return new CachingApiClientDetailsProviderDecorator(apiClientDetailsProvider,
                componentContext.Resolve<IExternalCacheProvider>(),
                componentContext.Resolve<IApiClientDetailsCacheKeyProvider>());
        }

        public void OverrideAvailableChangeVersionCache(ContainerBuilder builder)
        {
            builder.RegisterDecorator<IAvailableChangeVersionProvider>((context, parameters, instance) => GetCachingAvailableChangeVersionProviderDecorator(context, instance));
        }

        private static CachingAvailableChangeVersionProviderDecorator GetCachingAvailableChangeVersionProviderDecorator(IComponentContext componentContext, IAvailableChangeVersionProvider availableChangeVersionProvider)
        {
            return new CachingAvailableChangeVersionProviderDecorator(availableChangeVersionProvider,
                componentContext.Resolve<IExternalCacheProvider>());
        }

        public void OverrideDescriptorsCache(ContainerBuilder builder)
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
                                    "Caching:Descriptors:AbsoluteExpirationSeconds") ?? 1800;

                            return c.Resolve<IExternalCacheProvider>();
                        }))
                .As<IDescriptorsCache>()
                .SingleInstance();
        }

        public void OverridePersonUniqueIdtoUsiCache(ContainerBuilder builder)
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

                      return new ExternalCacheProvider(
                              c.Resolve<IDistributedCache>(),
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