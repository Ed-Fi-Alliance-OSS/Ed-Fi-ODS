// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Utils;
using EdFi.Ods.Features.Notifications;
using EdFi.Ods.Features.Notifications.Redis;
using EdFi.Ods.Features.Services.Redis;
using FakeItEasy;
using MediatR;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using StackExchange.Redis;

namespace EdFi.Ods.Features.UnitTests.Notifications.Redis;

[TestFixture]
public class RedisNotificationTests
{
    private const string RedisConfiguration = "localhost:6379";

    private static readonly IRedisConnectionProvider _redisConnectionProvider = new RedisConnectionProvider(RedisConfiguration);
    private static readonly RedisNotificationSettings _redisNotificationSettings = new() { Channel = "test-notifications" };

    private readonly Dictionary<string, TimeSpan> _intervalsByNotificationType = new();

    [Test]
    public void Should_subscribe_to_and_receive_Redis_pub_sub_notification_and_invoke_appropriate_Mediatr_handler()
    {
        try
        {
            bool connected = _redisConnectionProvider.Get().Multiplexer.IsConnected;
        }
        catch (RedisConnectionException ex)
        {
            throw new InconclusiveException("The test is inconclusive since Redis is not available.", ex);
        }

        //--------------------------------
        // Arrange
        //--------------------------------
        var signal = new AutoResetEvent(false);

        var interceptor = new SignalingClearableInterceptor(signal);
        IServiceProvider serviceProvider = A.Fake<IServiceProvider>();

        var fakeInterceptorIndex = A.Fake<IIndex<string, IInterceptor>>();
        IInterceptor interceptorOutPlaceholder;
        
        A.CallTo(() => fakeInterceptorIndex.TryGetValue("cache-security", out interceptorOutPlaceholder))
            .Returns(true)
            .AssignsOutAndRefParameters(interceptor);

        A.CallTo(() => serviceProvider.GetService(typeof(IEnumerable<INotificationHandler<ExpireCache>>)))
            .Returns(new[] { new ExpireCacheHandler(fakeInterceptorIndex) });

        var mediator = new Mediator(serviceProvider);

        var activity = new InitializeRedisNotifications(
            _redisConnectionProvider,
            _redisNotificationSettings,
            new NotificationsMessageSink(mediator, _intervalsByNotificationType, TimeProvider.System));

        activity.Execute();

        //--------------------------------
        // Act
        //--------------------------------
        // Publish a message to redis
        _redisConnectionProvider.Get()
            .Publish(_redisNotificationSettings.Channel, JsonConvert.SerializeObject(new { Type = "expire-cache", Data = new { CacheType = "security" } }));

        //--------------------------------
        // Assert
        //--------------------------------
        signal.WaitOne(200);
        interceptor.ClearCalled.ShouldBeTrue();
    }
}

public class SignalingClearableInterceptor : IClearableInterceptor
{
    private readonly AutoResetEvent _signal;

    public SignalingClearableInterceptor(AutoResetEvent signal)
    {
        _signal = signal;
    }

    public void Intercept(IInvocation invocation)
    {
        InterceptCalled = true;
    }

    public bool InterceptCalled { get; set; }

    public void Clear()
    {
        ClearCalled = true;
        _signal.Set();
    }

    public bool ClearCalled { get; set; }
}
