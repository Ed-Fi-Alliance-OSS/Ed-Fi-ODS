// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Utils;
using EdFi.Ods.Features.Notifications;
using FakeItEasy;
using log4net.Appender;
using log4net.Core;
using MediatR;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.Notifications
{
    [NotificationType("test-notification")]
    public class TestNotification : INotification { }

    [TestFixture]
    public class NotificationsMessageSinkTests
    {
        private MemoryAppender _memoryAppender;

        [SetUp]
        public void Setup()
        {
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
        public void Receive_UnrecognizedMessageType_LogsDebug()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var sink = new NotificationsMessageSink(mediator, new Dictionary<string, TimeSpan>(), TimeProvider.System);

            // Act
            sink.Receive(@"{""Type"":""non-attributed-test-notification"",""Data"":{}}");

            // Assert
            A.CallTo(() => mediator.Publish(A<INotification>._, CancellationToken.None)).MustNotHaveHappened();
            
            _memoryAppender.GetEvents()
                .ShouldContain(e => 
                    e.Level == Level.Error 
                    && e.RenderedMessage == $"Message received with unrecognized notification type 'non-attributed-test-notification'...");
        }

        [Test]
        public void Receive_RecognizedMessageType_PublishesNotification()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var sink = new NotificationsMessageSink(mediator, new Dictionary<string, TimeSpan>(), TimeProvider.System);

            var messageContent = @"{""Type"":""test-notification"",""Data"":{""Property"":""Value""}}";

            // Act
            sink.Receive(messageContent);

            // Assert
            A.CallTo(() => mediator.Publish(A<INotification>._, CancellationToken.None)).MustHaveHappened();
        }

        [Test]
        public void Receive_InvalidMessageFormat_LogsError()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var sink = new NotificationsMessageSink(mediator, new Dictionary<string, TimeSpan>(), TimeProvider.System);

            var invalidMessageContent = "InvalidMessageContent";

            // Act
            sink.Receive(invalidMessageContent);

            // Assert
            _memoryAppender.GetEvents()
                .ShouldContain(e => 
                        e.Level == Level.Error 
                        && e.RenderedMessage == "An error occurred while processing the incoming message content: 'InvalidMessageContent'...");
        }

        [Test]
        public void Receive_ValidMessageFormat_LogsDebug()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var sink = new NotificationsMessageSink(mediator, new Dictionary<string, TimeSpan>(), TimeProvider.System);

            var validMessageContent = @"{""Type"":""test-notification"",""Data"":{""Property"":""Value""}}";

            // Act
            sink.Receive(validMessageContent);

            // Assert
            _memoryAppender.GetEvents()
                .ShouldContain(e => 
                    e.Level == Level.Info 
                    && e.RenderedMessage == $"Received notification message 'test-notification' associated with type '{nameof(TestNotification)}'...");
        }
        
        [Test]
        public void Receive_WithConfiguredMinimumInterval_PublishesNotificationOncePerInterval()
        {
            // Arrange
            var mediator = A.Fake<IMediator>();
            var fakeTimeProvider = new FakeTimeProvider(DateTimeOffset.UtcNow);
            var intervalByNotificationType = new Dictionary<string, TimeSpan>
            {
                { "test-notification", TimeSpan.FromSeconds(5) }
            };

            var sink = new NotificationsMessageSink(mediator, intervalByNotificationType, fakeTimeProvider);

            // Act
            // First notification should be processed
            sink.Receive("{\"Type\":\"test-notification\",\"Data\":{}}");

            // Move time forward by 2 seconds
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(2));

            // Second notification should be discarded due to the minimum interval
            sink.Receive("{\"Type\":\"test-notification\",\"Data\":{}}");

            // Move time forward by 5 seconds
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(5));

            // Third notification should be processed as the interval has passed
            sink.Receive("{\"Type\":\"test-notification\",\"Data\":{}}");

            // Move time forward by 2 seconds
            fakeTimeProvider.Advance(TimeSpan.FromSeconds(2));

            // Fourth notification should be discarded due to the minimum interval
            sink.Receive("{\"Type\":\"test-notification\",\"Data\":{}}");

            // Assert
            A.CallTo(() => mediator.Publish(A<INotification>._, A<CancellationToken>._)).MustHaveHappenedTwiceExactly();
        }
    }
}
