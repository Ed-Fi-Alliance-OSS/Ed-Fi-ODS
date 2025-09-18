// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Caching.CacheKeyProviders;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Descriptors;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class DescriptorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DescriptorResolver>()
                .As<IDescriptorResolver>()
                .SingleInstance();

            builder.RegisterType<DescriptorMapsProvider>()
                .As<IDescriptorMapsProvider>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IAsyncInterceptor>(InterceptorCacheKeys.Descriptors)
                // Method signature built using ODS Instance configuration as context
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IMethodSignatureCacheKeyProvider),
                    (pi, ctx) => ctx.Resolve<ContextualMethodSignatureCacheKeyProvider<OdsInstanceConfiguration>>())
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();
            
                        return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                            "Descriptors",
                            TimeSpan.FromSeconds(apiSettings.Caching.Descriptors.AbsoluteExpirationSeconds),
                            TimeSpan.FromSeconds(apiSettings.Caching.Descriptors.CreationTimeoutSeconds));
                    })
                .SingleInstance();

            // Wrap into AsyncDeterminationInterceptor to support async interception
            builder.Register(ctx =>
                    new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.Descriptors)))
                .Named<IInterceptor>(InterceptorCacheKeys.Descriptors);

            builder.RegisterType<DescriptorDetailsProvider>()
                .As<IDescriptorDetailsProvider>()
                .SingleInstance();
        }
    }
}
