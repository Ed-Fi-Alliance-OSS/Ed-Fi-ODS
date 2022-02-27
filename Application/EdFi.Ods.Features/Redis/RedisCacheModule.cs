// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
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

        public override bool IsSelected() => ApiSettings.IsFeatureEnabled("UseRedisCache");

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
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
                                c.Resolve<IConnectionMultiplexer>(),
                                TimeSpan.FromSeconds(expirationPeriod));
                        }))
                .As<IDescriptorsCache>()
                .SingleInstance();

            builder.RegisterType<RedisCacheProvider>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(TimeSpan),
                        (p, c) => GetRedisDefaultExpiration(c)))
                .As<ICacheProvider>()
                .As<IRedisCacheProvider>()
                .SingleInstance();

            OverrideEducationOrganizationCache(builder);

            OverrideSecurityRepository(builder);
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

        private static void OverrideEducationOrganizationCache(ContainerBuilder builder)
        {
            builder.RegisterType<EducationOrganizationCache>()
                .As<IEducationOrganizationCache>()
                .SingleInstance();

            builder.RegisterType<EducationOrganizationCacheInitializer>()
                .As<IEducationOrganizationCacheInitializer>()
                .SingleInstance();
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
    }
}
