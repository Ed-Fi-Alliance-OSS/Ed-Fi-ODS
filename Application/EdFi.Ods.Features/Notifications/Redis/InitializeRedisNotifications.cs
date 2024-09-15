// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Services.Redis;
using log4net;
using StackExchange.Redis;
using static StackExchange.Redis.RedisChannel;

namespace EdFi.Ods.Features.Notifications.Redis;

/// <summary>
/// Performs the initialization activity necessary to create a Redis subscription for notifications from the configured channel. 
/// </summary>
public class InitializeRedisNotifications : IStartupCommand
{
    private readonly IRedisConnectionProvider _redisConnectionProvider;
    private readonly RedisNotificationSettings _redisNotificationSettings;
    private readonly INotificationsMessageSink _notificationsMessageSink;

    private readonly ILog _logger = LogManager.GetLogger(typeof(InitializeRedisNotifications));
    
    public InitializeRedisNotifications(
        IRedisConnectionProvider redisConnectionProvider, 
        RedisNotificationSettings redisNotificationSettings,
        INotificationsMessageSink notificationsMessageSink)
    {
        _redisConnectionProvider = redisConnectionProvider;
        _redisNotificationSettings = redisNotificationSettings;
        _notificationsMessageSink = notificationsMessageSink;
    }

    public void Execute()
    {
        try
        {
            var subscriber = _redisConnectionProvider.Get().Multiplexer.GetSubscriber();

            subscriber.Subscribe(
                new RedisChannel(_redisNotificationSettings.Channel, PatternMode.Auto),
                (channel, message) => { _notificationsMessageSink.Receive(message); });
        }
        catch (Exception ex)
        {
            _logger.Error($"An error occurred while attempting to subscribe to notifications from Redis channel '{_redisNotificationSettings.Channel}'...", ex);
        }
    }
}
