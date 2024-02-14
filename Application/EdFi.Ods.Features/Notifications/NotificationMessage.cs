// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Represents the JSON message body for notification messages published to the pub/sub messaging infrastructure.
/// </summary>
public class NotificationMessage
{
    public string Type { get; set; }
    public JObject Data { get; set; }
}
