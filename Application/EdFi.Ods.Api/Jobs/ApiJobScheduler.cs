// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using Quartz;

namespace EdFi.Ods.Api.Jobs;

/// <summary>
/// Schedules jobs for background execution by Quartz.
/// </summary>
public class ApiJobScheduler : IApiJobScheduler
{
    private readonly ISchedulerFactory _schedulerFactory;

    public ApiJobScheduler(ISchedulerFactory schedulerFactory)
    {
        _schedulerFactory = schedulerFactory;
    }

    /// <inheritdoc cref="IApiJobScheduler.AddSingleExecutionJob{TJob}" />
    public Task AddSingleExecutionJob<TJob>(string jobName = null, string triggerName = null, JobDataMap jobDataMap = null)
        where TJob : IJob
    {   
        return AddSingleExecutionJob(typeof(TJob), jobName, triggerName, jobDataMap);
    }

    /// <inheritdoc cref="IApiJobScheduler.AddSingleExecutionJob" />
    public async Task AddSingleExecutionJob(
        Type jobType,
        string jobName = null,
        string triggerName = null,
        JobDataMap jobDataMap = null)
    {
        var jobBuilder = JobBuilder.Create(jobType).UsingJobData(jobDataMap ?? new JobDataMap());

        if (jobName != null)
        {
            jobBuilder.WithIdentity(jobName);
        }

        var job = jobBuilder.Build();

        var triggerBuilder = TriggerBuilder.Create().StartNow();

        if (triggerName != null)
        {
            triggerBuilder.WithIdentity(triggerName);
        }

        var trigger = triggerBuilder.Build();

        var scheduler = await _schedulerFactory.GetScheduler().ConfigureAwait(false);

        await scheduler.ScheduleJob(job, trigger).ConfigureAwait(false);
    }

    /// <inheritdoc cref="IApiJobScheduler.AddScheduledJob" />
    public async Task AddScheduledJob(
        Type jobType,
        ScheduledJobSettings scheduledJobSettings,
        CancellationToken cancellationToken = default)
    {
        var jobDetail = BuildJobDetail(jobType, scheduledJobSettings);
        var trigger = BuildTrigger(scheduledJobSettings);

        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken).ConfigureAwait(false);
        await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
    }

    private IJobDetail BuildJobDetail(Type jobType, ScheduledJobSettings scheduledJobSettings)
    {
        return JobBuilder.Create(jobType)
            .WithIdentity($"{scheduledJobSettings.Name} Job")
            .WithDescription($"{scheduledJobSettings.Name} Job")
            .Build();
    }

    private ITrigger BuildTrigger(ScheduledJobSettings scheduledJobSettings)
    {
        string cronSchedule = CronHelper.GetValidCronExpressionOrDefault(scheduledJobSettings);

        return TriggerBuilder.Create()
            .WithIdentity($"{scheduledJobSettings.Name} Trigger")
            .WithCronSchedule(cronSchedule)
            .WithDescription($"{scheduledJobSettings.Name} Trigger")
            .Build();
    }
}
