// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using log4net;
using Quartz;
using TenantConfiguration = NHibernate.MultiTenancy.TenantConfiguration;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements a decorator over the <see cref="IApiJobScheduler" /> that ensures that tenant-specific jobs (classes that
/// derived from <see cref="TenantSpecificJobBase" />) have tenant configuration added to the job data map, or it obtains
/// all the tenant configurations and schedules the job for each tenant individually. 
/// </summary>
public class MultiTenantApiJobSchedulerDecorator : IApiJobScheduler
{
    private readonly IApiJobScheduler _next;
    private readonly ITenantConfigurationProvider _tenantConfigurationProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(MultiTenantApiJobSchedulerDecorator));
    
    public MultiTenantApiJobSchedulerDecorator(IApiJobScheduler next, ITenantConfigurationProvider tenantConfigurationProvider)
    {
        _next = next;
        _tenantConfigurationProvider = tenantConfigurationProvider;
    }

    /// <summary>
    /// Schedules a job for execution once.
    /// </summary>
    /// <param name="jobName">The unique name for the job, or null to allow Quartz to assign one automatically.</param>
    /// <param name="triggerName">The unique name for the trigger, or null to allow Quartz to assign one automatically.</param>
    /// <param name="jobDataMap">The data map for the job, if needed.</param>
    /// <typeparam name="TJob">The <see cref="Type" /> of the job class to be executed.</typeparam>
    public async Task AddSingleExecutionJob<TJob>(string jobName = null, string triggerName = null, JobDataMap jobDataMap = null)
        where TJob : IJob
    {
        await AddSingleExecutionJob(typeof(TJob), jobName, triggerName, jobDataMap);
    }
    
    /// <summary>
    /// Ensures that tenant-specific jobs (classes that derived from <see cref="TenantSpecificJobBase" />) have tenant
    /// configuration added to the job data map, or it obtains all the tenant configurations and schedules the job for each
    /// tenant individually.
    /// </summary>
    /// <param name="jobType">The <see cref="Type" /> of the job class to be executed.</param>
    /// <param name="jobName">The unique name for the job, or null to allow Quartz to assign one automatically.</param>
    /// <param name="triggerName">The unique name for the trigger, or null to allow Quartz to assign one automatically.</param>
    /// <param name="jobDataMap">The data map for the job, if needed.</param>
    public async Task AddSingleExecutionJob(Type jobType, string jobName = null, string triggerName = null, JobDataMap jobDataMap = null)
    {
        if (typeof(TenantSpecificJobBase).IsAssignableFrom(jobType))
        {
            // Ensure job data map is initialized
            jobDataMap ??= new JobDataMap();

            // If tenant configuration already assigned, proceed normally...
            if (jobDataMap.ContainsKey(nameof(TenantConfiguration)))
            {
                _logger.Debug($"Multi-tenant job already has tenant configuration assigned. Scheduling execution normally...");
                await _next.AddSingleExecutionJob(jobType, jobName, triggerName, jobDataMap);

                return;
            }

            jobName ??= jobType.Name;

            _logger.Debug($"Intercepting scheduling of single-execution job '{jobName}' for multi-tenant execution...");
            
            // Schedule the job once for each tenant configuration
            foreach (var tenantConfiguration in _tenantConfigurationProvider.GetAllConfigurations())
            {
                var tenantSpecificJobDataMap = new JobDataMap((IDictionary<string, object>) jobDataMap);
                tenantSpecificJobDataMap[nameof(TenantConfiguration)] = tenantConfiguration;

                var newJobName = $"{jobName}-{tenantConfiguration.TenantIdentifier}";
                var newTriggerName = $"{triggerName ?? Guid.NewGuid().ToString("n")}-{tenantConfiguration.TenantIdentifier}";

                _logger.Debug($"Scheduling single-execution job '{newJobName}' for tenant '{tenantConfiguration.TenantIdentifier}'...");

                await _next.AddSingleExecutionJob(
                    jobType,
                    newJobName,
                    newTriggerName,
                    tenantSpecificJobDataMap);
            }
        }
        else
        {
            _logger.Debug($"Job type '{jobType.Name}' is not a tenant-specific job. Scheduling execution normally...");
            await _next.AddSingleExecutionJob(jobType, jobName, triggerName, jobDataMap);
        }
    }

    public Task AddScheduledJob(Type jobType, ScheduledJobSettings scheduledJobSettings, CancellationToken cancellationToken = default) 
        => _next.AddScheduledJob(jobType, scheduledJobSettings, cancellationToken);
}
