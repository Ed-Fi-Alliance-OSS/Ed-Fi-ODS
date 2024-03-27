// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Features.Notifications;
using FakeItEasy;
using log4net.Appender;
using log4net.Core;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.Notifications;

[TestFixture]
public class ExpireCacheHandlerTests
{
    private MemoryAppender? _memoryAppender;
    private IClearableInterceptor? _fakeClearableInterceptor;

    private IInterceptor? _interceptorOutPlaceholder;
    private IIndex<string, IInterceptor>? _fakeInterceptorIndex;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _fakeClearableInterceptor = A.Fake<IClearableInterceptor>();

        // Autofac Index
        _fakeInterceptorIndex = A.Fake<IIndex<string, IInterceptor>>();

        // Set up log4net with MemoryAppender before each test
        _memoryAppender = Log4NetTestHelper.SetupMemoryAppender();
    }

    [TearDown]
    public void Teardown()
    {
        _memoryAppender!.GetEvents().Select(e => e.RenderedMessage).ForEach(s => Console.WriteLine(s));

        // Clean up and clear the MemoryAppender after each test
        Log4NetTestHelper.ClearMemoryAppender();
    }

    [Test]
    public void Handle_ClearableInterceptor_ClearsSecurityMetadata()
    {
        // Arrange
        A.CallTo(() => _fakeClearableInterceptor!.Clear()).DoesNothing();

        A.CallTo(() => _fakeInterceptorIndex!.TryGetValue("cache-the-one", out _interceptorOutPlaceholder))
            .Returns(true)
            .AssignsOutAndRefParameters(_fakeClearableInterceptor);

        var handler = new ExpireCacheHandler(_fakeInterceptorIndex);

        // Act
        handler.Handle(new ExpireCache() { CacheType = "the-one" }, CancellationToken.None).Wait();

        // Assert
        A.CallTo(() => _fakeClearableInterceptor!.Clear()).MustHaveHappened();
    }

    [Test]
    public void Handle_ClearableInterceptor_Exception_LogsError()
    {
        // Arrange
        A.CallTo(() => _fakeClearableInterceptor!.Clear()).Throws<Exception>();

        A.CallTo(() => _fakeInterceptorIndex!.TryGetValue("cache-the-one", out _interceptorOutPlaceholder))
            .Returns(true)
            .AssignsOutAndRefParameters(_fakeClearableInterceptor);

        var handler = new ExpireCacheHandler(_fakeInterceptorIndex);

        // Act
        handler.Handle(new ExpireCache() { CacheType = "the-one" }, CancellationToken.None).Wait();

        // Assert
        _memoryAppender!.GetEvents()
            .ShouldContain(e => e.Level == Level.Error && e.RenderedMessage == $"Unable to clear cache.");
    }

    [Test]
    public void Handle_NonClearableInterceptor_Warns_Cache_Not_Expired()
    {
        // Arrange
        var nonClearableInterceptor = A.Fake<IInterceptor>(); // Mock a non-clearable interceptor

        A.CallTo(() => _fakeInterceptorIndex!.TryGetValue("cache-the-one", out _interceptorOutPlaceholder))
            .Returns(true)
            .AssignsOutAndRefParameters(nonClearableInterceptor);

        var handler = new ExpireCacheHandler(_fakeInterceptorIndex);

        // Act
        handler.Handle(new ExpireCache() { CacheType = "the-one" }, CancellationToken.None).Wait();

        // Assert
        _memoryAppender!.GetEvents()
            .ShouldContain(e => 
                e.Level == Level.Warn
                && e.RenderedMessage == $"Notification to clear the 'the-one' cache was received, but the registered {nameof(IInterceptor)} (named 'cache-the-one') is not clearable...");
    }
    
    [Test]
    public void Handle_NonRegisteredInterceptor_Warns_Interceptor_Not_Registered()
    {
        // Arrange
        var nonClearableInterceptor = A.Fake<IInterceptor>(); // Mock a non-clearable interceptor

        A.CallTo(() => _fakeInterceptorIndex!.TryGetValue("cache-the-one", out _interceptorOutPlaceholder))
            .Returns(true)
            .AssignsOutAndRefParameters(nonClearableInterceptor);

        var handler = new ExpireCacheHandler(_fakeInterceptorIndex);

        // Act
        handler.Handle(new ExpireCache() { CacheType = "something-else" }, CancellationToken.None).Wait();

        // Assert
        _memoryAppender!.GetEvents()
            .ShouldContain(e => 
                e.Level == Level.Warn
                && e.RenderedMessage == $"Notification to clear the 'something-else' cache was received, but no {nameof(IInterceptor)} has been registered with a name of 'cache-something-else'...");
    }
}
