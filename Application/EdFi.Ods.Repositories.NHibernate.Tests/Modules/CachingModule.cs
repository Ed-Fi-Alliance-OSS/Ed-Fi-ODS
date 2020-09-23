// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace EdFi.Ods.Repositories.NHibernate.Tests.Modules
{
    public class CachingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>();

            builder.RegisterType<MemoryCacheProvider>().As<ICacheProvider>();
            builder.RegisterType<ConcurrentDictionaryCacheProvider>().AsSelf().SingleInstance();

            builder.RegisterType<DescriptorsCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(IDescriptorsCache),
                        (p, c) => c.Resolve<ConcurrentDictionaryCacheProvider>()))
                .As<IDescriptorsCache>()
                .SingleInstance();
        }
    }
}
#endif