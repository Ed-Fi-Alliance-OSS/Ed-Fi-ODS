// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Represents a notification message sent to the Ed-Fi ODS API process to explicitly expire the cached security metadata.
/// </summary>
[NotificationType("expire-security-metadata")]
public class ExpireSecurityMetadata : INotification { }
