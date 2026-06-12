// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Notifications;
using EdFi.Ods.Features.Notifications.Redis;
using EdFi.Ods.Features.Services.Redis;
using FakeItEasy;
using MediatR;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using StackExchange.Redis;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Notifications.Redis;

[TestFixture]
public class RedisNotificationTests
{
    private const string RedisConfigurationString = "localhost:6379";

    private static readonly RedisNotificationSettings _redisNotificationSettings = new()
    {
        Channel = "test-notifications",
    };

    private readonly Dictionary<string, TimeSpan> _intervalsByNotificationType = new();

    // This is explicitly an integration test, requiring a running Redis instance. The second test in this class is a unit test that mocks the Redis infrastructure and should be used for regular automated testing.
    [Test]
    [Explicit("Requires active Redis server")]
    public async Task Integration_Should_subscribe_to_and_receive_Redis_pub_sub_notification_and_invoke_appropriate_Mediatr_handler()
    {
        var connectionProvider = new RedisConnectionProvider(
            new RedisConfiguration { Configuration = RedisConfigurationString }
        );

        try
        {
            bool connected = connectionProvider.Get().Multiplexer.IsConnected;
        }
        catch (RedisConnectionException ex)
        {
            throw new InconclusiveException(
                "The test is inconclusive since Redis is not available.",
                ex
            );
        }

        //--------------------------------
        // Arrange
        //--------------------------------
        var signal = new AutoResetEvent(false);

        var interceptor = new SignalingClearableInterceptor(signal);
        IServiceProvider serviceProvider = A.Fake<IServiceProvider>();

        var fakeInterceptorIndex = A.Fake<IIndex<string, IInterceptor>>();
        IInterceptor interceptorOutPlaceholder;

        A.CallTo(() =>
                fakeInterceptorIndex.TryGetValue("cache-security", out interceptorOutPlaceholder)
            )
            .Returns(true)
            .AssignsOutAndRefParameters(interceptor);

        A.CallTo(() =>
                serviceProvider.GetService(typeof(IEnumerable<INotificationHandler<ExpireCache>>))
            )
            .Returns(new[] { new ExpireCacheHandler(fakeInterceptorIndex) });

        var mediator = new Mediator(serviceProvider);

        var activity = new InitializeRedisNotifications(
            connectionProvider,
            _redisNotificationSettings,
            new NotificationsMessageSink(
                mediator,
                _intervalsByNotificationType,
                TimeProvider.System
            )
        );

        await activity.ExecuteAsync();

        //--------------------------------
        // Act
        //--------------------------------
        // Publish a message to redis
        connectionProvider
            .Get()
            .Publish(
                new RedisChannel(_redisNotificationSettings.Channel, RedisChannel.PatternMode.Auto),
                JsonConvert.SerializeObject(
                    new { Type = "expire-cache", Data = new { CacheType = "security" } }
                )
            );

        //--------------------------------
        // Assert
        //--------------------------------
        signal.WaitOne(200);
        interceptor.ClearCalled.ShouldBeTrue();
    }

    [Test]
    public async Task Should_subscribe_to_and_receive_Redis_pub_sub_notification_and_invoke_appropriate_Mediatr_handler()
    {
        //--------------------------------
        // Arrange
        //--------------------------------
        var signal = new AutoResetEvent(false);

        // Set up the mocked Redis infrastructure
        Action<RedisChannel, RedisValue> capturedHandler = null;

        var fakeSubscriber = A.Fake<ISubscriber>();

        A.CallTo(() =>
                fakeSubscriber.SubscribeAsync(
                    A<RedisChannel>.Ignored,
                    A<Action<RedisChannel, RedisValue>>.Ignored,
                    A<CommandFlags>.Ignored
                )
            )
            .Invokes(
                (
                    RedisChannel channel,
                    Action<RedisChannel, RedisValue> handler,
                    CommandFlags flags
                ) =>
                {
                    capturedHandler = handler;
                }
            )
            .Returns(Task.CompletedTask);

        var fakeMultiplexer = A.Fake<IConnectionMultiplexer>();
        A.CallTo(() => fakeMultiplexer.GetSubscriber(A<object>.Ignored)).Returns(fakeSubscriber);

        var fakeDatabase = A.Fake<IDatabase>();
        A.CallTo(() => fakeDatabase.Multiplexer).Returns(fakeMultiplexer);

        var fakeRedisConnectionProvider = A.Fake<IRedisConnectionProvider>();
        A.CallTo(() => fakeRedisConnectionProvider.Get()).Returns(fakeDatabase);

        // Set up the MediatR handler
        var interceptor = new SignalingClearableInterceptor(signal);
        IServiceProvider serviceProvider = A.Fake<IServiceProvider>();

        var fakeInterceptorIndex = A.Fake<IIndex<string, IInterceptor>>();
        IInterceptor interceptorOutPlaceholder;

        A.CallTo(() =>
                fakeInterceptorIndex.TryGetValue("cache-security", out interceptorOutPlaceholder)
            )
            .Returns(true)
            .AssignsOutAndRefParameters(interceptor);

        A.CallTo(() =>
                serviceProvider.GetService(typeof(IEnumerable<INotificationHandler<ExpireCache>>))
            )
            .Returns(new[] { new ExpireCacheHandler(fakeInterceptorIndex) });

        var mediator = new Mediator(serviceProvider);

        var activity = new InitializeRedisNotifications(
            fakeRedisConnectionProvider,
            _redisNotificationSettings,
            new NotificationsMessageSink(
                mediator,
                _intervalsByNotificationType,
                TimeProvider.System
            )
        );

        await activity.ExecuteAsync();

        //--------------------------------
        // Act
        //--------------------------------
        // Simulate receiving a message via the captured subscription handler
        var message = JsonConvert.SerializeObject(
            new { Type = "expire-cache", Data = new { CacheType = "security" } }
        );
        capturedHandler.ShouldNotBeNull(
            "The subscription handler was not captured during ExecuteAsync."
        );
        capturedHandler.Invoke(
            new RedisChannel(_redisNotificationSettings.Channel, RedisChannel.PatternMode.Auto),
            message
        );

        //--------------------------------
        // Assert
        //--------------------------------
        signal.WaitOne(200);
        interceptor.ClearCalled.ShouldBeTrue();
    }
}

public interface IClearableInterceptor : IInterceptor, IClearable { }

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
