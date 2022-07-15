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
                OverridePersonUniqueIdtoUsiCache(builder);
            }
        }

        public abstract string ExternalCacheProvider { get; }
        
        public bool IsProviderSelected(string externalCacheProvider)
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
            return TimeSpan.FromSeconds(1800);
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

        public void OverrideDescriptorsCache(ContainerBuilder builder)
        {
            builder.RegisterType<DescriptorsCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ICacheProvider),
                        (p, c) =>
                        {
                            int expirationPeriod = ApiSettings.Caching.Descriptors.AbsoluteExpirationSeconds;

                            return new ExternalCacheProvider(
                              c.Resolve<IDistributedCache>(),
                              TimeSpan.Zero,
                              TimeSpan.FromSeconds(expirationPeriod));
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
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                      int expirationPeriod = ApiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                      return new ExternalCacheProvider(
                              c.Resolve<IDistributedCache>(),
                              TimeSpan.FromSeconds(period),
                              TimeSpan.FromSeconds(expirationPeriod));
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("slidingExpiration", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStudentCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressStudentCache;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStaffCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressStaffCache;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressParentCache", StringComparison.InvariantCultureIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressParentCache;
                  }))
          .As<IPersonUniqueIdToUsiCache>()
          .SingleInstance();
        }
    }
}