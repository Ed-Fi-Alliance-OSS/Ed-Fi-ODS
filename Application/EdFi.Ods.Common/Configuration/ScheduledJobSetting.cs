// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public class ScheduledJobSetting
    {
        public const string DefaultCronExpression = "0 0/30 * 1/1 * ? *"; // Used if the user does not supply CronExpression or the value provided is not a valid cron expression

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public string CronExpression { get; set; } = DefaultCronExpression;
    }
}