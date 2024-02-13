// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;

namespace EdFi.Ods.Features.Notifications;

public class NotificationsModule : ConditionalModule
{
    public NotificationsModule(ApiSettings apiSettings)
        : base(apiSettings, nameof(NotificationsModule)) { }

    public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Notifications);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        builder.RegisterType<NotificationsMessageSink>()
            .As<INotificationsMessageSink>()
            .WithParameter(new ResolvedParameter(
                (p, ctx) => p.ParameterType == typeof(IDictionary<string, TimeSpan>),
                (p, ctx) =>
                {
                    var apiSettings = ctx.Resolve<ApiSettings>();

                    // Convert the values in the configuration settings dictionary from integer (seconds) to TimeSpans
                    return apiSettings.Notifications.MinimumIntervalSeconds.ToDictionary(
                        kvp => kvp.Key,
                        kvp => TimeSpan.FromSeconds(kvp.Value),
                        StringComparer.OrdinalIgnoreCase);
                }))
            .SingleInstance();
    }
}
