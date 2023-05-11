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
/// Defines methods for scheduling jobs for execution by Quartz.
/// </summary>
public interface IApiJobScheduler
{
    /// <summary>
    /// Schedules a job for one-time background execution.
    /// </summary>
    /// <param name="jobName">The unique name for the job, or null to allow Quartz to assign one automatically.</param>
    /// <param name="triggerName">The unique name for the trigger, or null to allow Quartz to assign one automatically.</param>
    /// <param name="jobDataMap">The data map for the job, if needed.</param>
    /// <typeparam name="TJob">The <see cref="Type" /> of the job class to be executed.</typeparam>
    Task AddSingleExecutionJob<TJob>(string jobName = null, string triggerName = null, JobDataMap jobDataMap = null)
        where TJob : IJob;

    /// <summary>
    /// Schedules a job for one-time background execution.
    /// </summary>
    /// <param name="jobType">The <see cref="Type" /> of the job class to be executed.</param>
    /// <param name="jobName">The unique name for the job, or null to allow Quartz to assign one automatically.</param>
    /// <param name="triggerName">The unique name for the trigger, or null to allow Quartz to assign one automatically.</param>
    /// <param name="jobDataMap">The data map for the job, if needed.</param>
    Task AddSingleExecutionJob(Type jobType, string jobName = null, string triggerName = null, JobDataMap jobDataMap = null);

    /// <summary>
    /// Adds a job for repeated execution on a set schedule.
    /// </summary>
    /// <param name="jobType">The <see cref="Type" /> of the job class to be executed.</param>
    /// <param name="scheduledJobSettings">Settings that indicate how to schedule the job for execution.</param>
    /// <param name="cancellationToken"></param>
    Task AddScheduledJob(Type jobType, ScheduledJobSettings scheduledJobSettings, CancellationToken cancellationToken = default);
}
