// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.ExternalCache;
using EdFi.Ods.Features.Services.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Redis
{
    public class OverrideRedisExternalCacheModule : ExternalCacheModule
    {
        private readonly ServiceSettings _servicesSettings;

        public override string ExternalCacheProvider => ExternalCacheProviderOption.Redis.ToString();

        public OverrideRedisExternalCacheModule(IFeatureManager featureManager, ApiSettings apiSettings)
            : base(featureManager, apiSettings)
        {
            _servicesSettings = apiSettings.Services;
        }

        public override void RegisterDistributedCache(ContainerBuilder builder)
        {
            if (!IsProviderSelected())
            {
                return;
            }

            // Ensure the Redis connection provider is registered (it may be registered by other conditional modules as well)
            builder.RegisterType<RedisConnectionProvider>()
                .As<IRedisConnectionProvider>()
                .WithParameter(new NamedParameter("configuration", _servicesSettings.Redis.Configuration))
                .IfNotRegistered(typeof(IRedisConnectionProvider))
                .SingleInstance();

            var configurationOptions = StackExchange.Redis.ConfigurationOptions.Parse(
                _servicesSettings.Redis.Configuration);
            
            builder.Register<IDistributedCache>(
                    (c, d) =>
                    {
                        var redisCacheOptions = new RedisCacheOptions() { ConfigurationOptions = configurationOptions };
            
                        return new RedisCache(redisCacheOptions);
                    })
                .SingleInstance();
        }
    }
}
