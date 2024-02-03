// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
public class ExpireSecurityMetadataHandlerTests
{
    private MemoryAppender _memoryAppender;
    private IClearableInterceptor _fakeClerableInterceptor;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _fakeClerableInterceptor = A.Fake<IClearableInterceptor>();

        // Set up log4net with MemoryAppender before each test
        _memoryAppender = Log4NetTestHelper.SetupMemoryAppender();
    }

    [TearDown]
    public void Teardown()
    {
        _memoryAppender.GetEvents().Select(e => e.RenderedMessage).ForEach(s => Console.WriteLine(s));

        // Clean up and clear the MemoryAppender after each test
        Log4NetTestHelper.ClearMemoryAppender();
    }

    [Test]
    public void Handle_ClearableInterceptor_ClearsSecurityMetadata()
    {
        // Arrange
        A.CallTo(() => _fakeClerableInterceptor.Clear()).DoesNothing();
        var handler = new ExpireSecurityMetadataHandler(_fakeClerableInterceptor);

        // Act
        handler.Handle(new ExpireSecurityMetadata(), CancellationToken.None).Wait();

        // Assert
        A.CallTo(() => _fakeClerableInterceptor.Clear()).MustHaveHappened();
    }

    [Test]
    public void Handle_ClearableInterceptor_Exception_LogsError()
    {
        // Arrange
        A.CallTo(() => _fakeClerableInterceptor.Clear()).Throws<Exception>();
        var handler = new ExpireSecurityMetadataHandler(_fakeClerableInterceptor);

        // Act
        handler.Handle(new ExpireSecurityMetadata(), CancellationToken.None).Wait();

        // Assert
        _memoryAppender.GetEvents()
            .ShouldContain(e => e.Level == Level.Error && e.RenderedMessage == $"Unable to clear security metadata.");
    }

    [Test]
    public void Handle_NonClearableInterceptor_Warns_Cache_Not_Expired()
    {
        // Arrange
        var nonClearableInterceptor = A.Fake<IInterceptor>(); // Mock a non-clearable interceptor
        var handler = new ExpireSecurityMetadataHandler(nonClearableInterceptor);

        // Act
        handler.Handle(new ExpireSecurityMetadata(), CancellationToken.None).Wait();

        // Assert
        _memoryAppender.GetEvents()
            .ShouldContain(e => 
                e.Level == Level.Warn 
                && e.RenderedMessage == $"Notification to clear security metadata was received, but the {nameof(IInterceptor)} (named \"cache-security\") registered with the container was not clearable.");
    }
}
