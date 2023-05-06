// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.Jobs;

public static class CronHelper
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(CronHelper));

    /// <summary>
    /// Returns the cron expression in the supplied <see cref="ScheduledJobSettings" /> if valid, otherwise a default expression
    /// with a repeating schedule of every 30 minutes.
    /// </summary>
    /// <param name="scheduledJobSettings">The configuration section for scheduled jobs.</param>
    /// <returns>The configured cron expression if valid; otherwise a default expression with a repeating schedule of every 30 minutes.</returns>
    public static string GetValidCronExpressionOrDefault(ScheduledJobSettings scheduledJobSettings)
    {
        bool isCronExpressionValid = scheduledJobSettings?.CronExpression != null
            && CronExpression.IsValidExpression(scheduledJobSettings.CronExpression);

        if (isCronExpressionValid)
        {
            return scheduledJobSettings.CronExpression;
        }

        _logger.Warn(
            $"Invalid cron expression provided for scheduled job: {scheduledJobSettings.Name}. Using default value: {ScheduledJobSettings.DefaultCronExpression}");

        return ScheduledJobSettings.DefaultCronExpression;
    }
}
