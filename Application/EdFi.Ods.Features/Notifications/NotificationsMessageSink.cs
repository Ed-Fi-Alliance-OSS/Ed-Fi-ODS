// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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

    private readonly ILog _logger = LogManager.GetLogger(typeof(NotificationsMessageSink));
    private readonly Lazy<IDictionary<string, Type>> _notificationTypeByName;

    public NotificationsMessageSink(IMediator mediator)
    {
        _mediator = mediator;

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
                _logger.Debug($"Unrecognized notification message received of type '{rawMessage.Type}'...");
            }
            else
            {
                _logger.Debug($"Received message '{rawMessage.Type}' associated with type '{notificationType.Name}'...");
            
                // Deserialize the data portion of the incoming message and publish for internal handling
                var notification = (INotification) JsonConvert.DeserializeObject((rawMessage.Data?.ToString() ?? "{}"), notificationType);
                _mediator.Publish(notification, CancellationToken.None);
            }
        }
        catch (Exception ex)
        {
            _logger.Error($"An error occurred while processing the incoming message: '{messageContent.TrimAt(50, true)}'...", ex);
        }
    }
}
