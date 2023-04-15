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
using EdFi.Ods.Common.Container;
using Microsoft.Extensions.Caching.Distributed;
using System;
using Castle.DynamicProxy;
using EdFi.Common.Security;
using EdFi.Ods.Common.Descriptors;

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

                        return (ICacheProvider<ulong>) new ExternalCacheProvider<ulong>(
                            ctx.Resolve<IDistributedCache>(),
                            TimeSpan.Zero,
                            TimeSpan.FromSeconds(absoluteExpirationSeconds));
                    });
        }

        public void OverridePersonUniqueIdToUsiCache(ContainerBuilder builder)
        {
            builder.RegisterType<PersonUniqueIdToUsiCache>()
            .WithParameter(new NamedParameter("synchronousInitialization", false))
            .WithParameter(
                new ResolvedParameter(
                  (p, c) => p.ParameterType == typeof(ICacheProvider<string>),
                  (p, c) =>
                  {
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                      int expirationPeriod = ApiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                      return new ExternalCacheProvider<string>(
                              c.Resolve<IDistributedCache>(),
                              TimeSpan.FromSeconds(period),
                              TimeSpan.FromSeconds(expirationPeriod));
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("slidingExpiration", StringComparison.OrdinalIgnoreCase),
                  (p, c) =>
                  {
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.OrdinalIgnoreCase),
                  (p, c) =>
                  {
                      int period = ApiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                      return TimeSpan.FromSeconds(period);
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStudentCache", StringComparison.OrdinalIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressStudentCache;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressStaffCache", StringComparison.OrdinalIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressStaffCache;
                  }))
          .WithParameter(
              new ResolvedParameter(
                  (p, c) => p.Name.Equals("suppressParentCache", StringComparison.OrdinalIgnoreCase),
                  (p, c) =>
                  {
                      return ApiSettings.Caching.PersonUniqueIdToUsi.SuppressParentCache;
                  }))
          .As<IPersonUniqueIdToUsiCache>()
          .SingleInstance();
        }
    }
}