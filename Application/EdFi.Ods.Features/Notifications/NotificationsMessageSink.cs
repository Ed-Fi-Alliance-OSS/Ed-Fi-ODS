// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Helpers;
using log4net;
using MediatR;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Implements a message sink that identifies the notification message type and invokes the appropriate handlers using MediatR. 
/// </summary>
public class NotificationsMessageSink : INotificationsMessageSink
{
    private readonly IMediator _mediator;
    private readonly TimeProvider _timeProvider;
    private readonly ConcurrentDictionary<string, TimeSpan> _intervalByNotificationType;
    private readonly ConcurrentDictionary<string, DateTime> _lastReceivedTimeByNotificationType = new(StringComparer.OrdinalIgnoreCase);

    private readonly ILog _logger = LogManager.GetLogger(typeof(NotificationsMessageSink));
    private readonly Lazy<IDictionary<string, Type>> _notificationTypeByName;

    public NotificationsMessageSink(
        IMediator mediator, IDictionary<string, TimeSpan> intervalByNotificationType, TimeProvider timeProvider)
    {
        _mediator = mediator;
        _timeProvider = timeProvider;

        _intervalByNotificationType = new ConcurrentDictionary<string, TimeSpan>(
            intervalByNotificationType,
            StringComparer.OrdinalIgnoreCase);

        _notificationTypeByName = new Lazy<IDictionary<string, Type>>(
            () => TypeHelper.GetImplementationsOf<INotification>()
                .Select(t => (Name: t.type.GetCustomAttribute<NotificationTypeAttribute>()?.Name, Type: t.type))
                .Where(t => !string.IsNullOrEmpty(t.Name))
                .ToDictionary(x => x.Name, x => x.Type, StringComparer.OrdinalIgnoreCase));

        var x = _notificationTypeByName.Value;
    }

    /// <summary>
    /// Receives the JSON message content and processes it to determine the type of notification received, and invokes the
    /// handler(s) for the message.
    /// </summary>
    /// <param name="messageContent">The JSON content of the notification message.</param>
    public void Receive(string messageContent)
    {
        try
        {
            var rawMessage = JsonConvert.DeserializeObject<NotificationMessage>(messageContent);

            if (!_notificationTypeByName.Value.TryGetValue(rawMessage.Type, out Type notificationType))
            {
                // Unrecognized message type
                _logger.Error($"Message received with unrecognized notification type '{rawMessage.Type}'...");
            }
            else
            {
                _logger.Info($"Received notification message '{rawMessage.Type}' associated with type '{notificationType.Name}'...");

                // Check for configured minimum interval
                if (_intervalByNotificationType.TryGetValue(rawMessage.Type, out var minimumInterval))
                {
                    var intervalEvaluation = new IntervalEvaluation(minimumInterval, _timeProvider);
                    
                    // Check for last processed time
                    var returnedTime = _lastReceivedTimeByNotificationType.AddOrUpdate(
                        rawMessage.Type,
                        static (t, evaluation) =>
                        {
                            // Always proceed the first time
                            evaluation.Proceed = true;
                            return evaluation.TimeProvider.GetUtcNow().UtcDateTime;
                        },
                        static (t, lastNotification, evaluation) =>
                        {
                            // If notification is too soon after the previous one, decline to handle (and return the previous date/time)
                            if (lastNotification.Add(evaluation.MinimumInterval) > evaluation.TimeProvider.GetUtcNow())
                            {
                                evaluation.Proceed = false;
                                return lastNotification;
                            }

                            evaluation.Proceed = true;
                            return evaluation.TimeProvider.GetUtcNow().UtcDateTime;
                        },
                        intervalEvaluation);

                    if (intervalEvaluation.Proceed)
                    {
                        PublishNotification(notificationType, rawMessage);
                    }
                    else
                    {
                        _logger.Info($"Notification message '{rawMessage.Type}' discarded due to configured minimum interval value. Handling of '{rawMessage.Type}' notification messages will resume at {returnedTime.Add(minimumInterval)}.");
                    }
                }
                else
                {
                    PublishNotification(notificationType, rawMessage);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error($"An error occurred while processing the incoming message content: '{messageContent.TrimAt(50, true)}'...", ex);
        }

        void PublishNotification(Type notificationType, NotificationMessage rawMessage)
        {
            _logger.Debug($"Publishing internal notification of type '{notificationType.Name}' for handling...");

            // Deserialize the data portion of the incoming message and publish for internal handling
            var notification = (INotification) JsonConvert.DeserializeObject((rawMessage.Data?.ToString() ?? "{}"), notificationType);
            _mediator.Publish(notification, CancellationToken.None);
        }
    }

    private class IntervalEvaluation
    {
        public IntervalEvaluation(TimeSpan minimumInterval, TimeProvider timeProvider)
        {
            MinimumInterval = minimumInterval;
            TimeProvider = timeProvider;
        }
        
        public TimeSpan MinimumInterval { get; }

        public TimeProvider TimeProvider { get; }

        public bool Proceed { get; set; }
    }
}
