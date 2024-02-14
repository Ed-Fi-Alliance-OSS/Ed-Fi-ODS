// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Defines a method for receiving the string-based content of a notification message from a pub/sub infrastructure component.
/// </summary>
public interface INotificationsMessageSink
{
    /// <summary>
    /// Receives the JSON message content and initiates appropriate notification handling.
    /// </summary>
    /// <param name="messageContent">The JSON content of the notification message.</param>
    void Receive(string messageContent);
}
