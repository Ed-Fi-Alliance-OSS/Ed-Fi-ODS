// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
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

            builder.RegisterType<ContextualCachingInterceptor<OdsInstanceConfiguration>>()
                .Named<IInterceptor>("cache-descriptors")
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();
            
                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Descriptors",
                            TimeSpan.FromSeconds(apiSettings.Caching.Descriptors.AbsoluteExpirationSeconds));
                    })
                .SingleInstance();

            builder.RegisterType<DescriptorDetailsProvider>()
                .As<IDescriptorDetailsProvider>()
                .SingleInstance();
        }
    }
}
