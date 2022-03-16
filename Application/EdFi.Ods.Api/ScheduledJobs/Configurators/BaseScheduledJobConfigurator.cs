// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Globalization;
using EdFi.Ods.Common.Configuration;
using Quartz;

namespace EdFi.Ods.Api.ScheduledJobs.Configurators;

public abstract class BaseScheduledJobConfigurator : IScheduledJobConfigurator
{
    public const string DefaultCronExpression = "0 0/30 * 1/1 * ? *"; // Run every 30 minutes repeatedly
    public const double DefaultStartAt = 30;
    public const double MaxStartAt = 24 * 60; // MaxStartAt = 1 day in minutes

    public abstract string Name { get; }
    public abstract void AddScheduledJob(IServiceCollectionQuartzConfigurator serviceCollectionQuartzConfigurator, ScheduledJobSetting scheduledJobSetting);

    public string GetCronExpression(ScheduledJobSetting scheduledJobSetting)
    {
        return scheduledJobSetting?.CronExpression != null && CronExpression.IsValidExpression(scheduledJobSetting.CronExpression) ? scheduledJobSetting.CronExpression : DefaultCronExpression;
    }

    public double GetStartAt(ScheduledJobSetting scheduledJobSetting)
    {
        double startAt = scheduledJobSetting.StartAtMinutes is > 0 and <= MaxStartAt ? scheduledJobSetting.StartAtMinutes : DefaultStartAt;
        return startAt;
    }
}
