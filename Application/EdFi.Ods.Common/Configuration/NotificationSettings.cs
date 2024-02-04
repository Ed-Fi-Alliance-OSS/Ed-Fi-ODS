// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Configuration;

public class NotificationSettings
{
    public RedisNotificationSettings Redis { get; set; }
    
    public Dictionary<string, int> MinimumIntervalSeconds { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public class RedisNotificationSettings
{
    public string Channel { get; set; }
}
