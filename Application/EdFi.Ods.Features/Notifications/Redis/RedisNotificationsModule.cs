// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;

namespace EdFi.Ods.Features.Notifications.Redis;

public class RedisNotificationsModule : ConditionalModule
{
    public RedisNotificationsModule(ApiSettings apiSettings, string moduleName)
        : base(apiSettings, moduleName) { }

    public override bool IsSelected()
        => IsFeatureEnabled(ApiFeature.Notifications) && !string.IsNullOrEmpty(ApiSettings.Notifications.Redis.Channel);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        // Register the Redis-specific pub/sub initialization activity
        builder.RegisterType<InitializeRedisNotifications>()
            .As<IExternalTask>()
            .WithParameter(
                new ResolvedParameter(
                    (p, c) => p.ParameterType == typeof(RedisNotificationSettings),
                    (p, c) => c.Resolve<ApiSettings>().Notifications.Redis))
            .SingleInstance();
    }
}
