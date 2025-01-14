// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.Services.Redis;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Notifications.Redis;

public class RedisNotificationsModule : ConditionalModule
{
    private readonly ApiSettings _apiSettings;

    public RedisNotificationsModule(IFeatureManager featureManager, ApiSettings apiSettings)
        : base(featureManager)
    {
        _apiSettings = apiSettings;
    }

    protected override bool IsSelected()
        => IsFeatureEnabled(ApiFeature.Notifications) && !string.IsNullOrEmpty(_apiSettings.Notifications.Redis.Channel);

    protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        // Ensure the Redis connection provider is registered (it may be registered by other conditional modules as well)
        builder.RegisterType<RedisConnectionProvider>()
            .As<IRedisConnectionProvider>()
            .WithParameter(new NamedParameter("configuration", _apiSettings.Services.Redis.Configuration))
            .IfNotRegistered(typeof(IRedisConnectionProvider))
            .SingleInstance();

        // Register the Redis-specific pub/sub initialization activity
        builder.RegisterType<InitializeRedisNotifications>()
            .As<IStartupCommand>()
            .WithParameter(
                new ResolvedParameter(
                    (p, c) => p.ParameterType == typeof(RedisNotificationSettings),
                    (p, c) => c.Resolve<ApiSettings>().Notifications.Redis))
            .SingleInstance();
    }
}
