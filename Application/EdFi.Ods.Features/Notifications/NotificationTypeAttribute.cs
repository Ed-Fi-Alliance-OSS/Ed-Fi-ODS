// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Applied to <see cref="INotification" /> implementations, indicates a notification message type that is
/// explicitly supported by the Ed-Fi ODS API. 
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class NotificationTypeAttribute : Attribute
{
    public NotificationTypeAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
