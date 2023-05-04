// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.Jobs;

/// <summary>
/// Provides a base class implementation of jobs that are tenant-specific, applying the necessary tenant configuration
/// into context when the job is executed in an API process running with the MultiTenancy feature enabled. 
/// </summary>
public abstract class TenantSpecificJobBase : IJob
{
    private readonly IApiJobScheduler _apiJobScheduler;
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;
    private readonly ILog _logger;

    protected TenantSpecificJobBase(
        IApiJobScheduler apiJobScheduler,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _apiJobScheduler = apiJobScheduler;
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
        _logger = LogManager.GetLogger(GetType());
    }

    /// <summary>
    /// Gets or sets the optional dependency on <see cref="ITenantConfigurationProvider" /> which will be null if the
    /// API is running in single-tenant mode.
    /// </summary>
    public ITenantConfigurationProvider TenantConfigurationProvider { get; set; }
    
    async Task IJob.Execute(IJobExecutionContext context)
    {
        // If there is not tenant configuration provider available, proceed with execution as we are running in single-tenant mode
        if (TenantConfigurationProvider == null)
        {
            // Proceed with execution
            await Execute(context);

            return;
        }
        
        // If the tenant configuration has been provided in the job data map, set it into context before executing
        if (context.JobDetail.JobDataMap.TryGetValue(nameof(TenantConfiguration), out object tenantConfigurationAsObject))
        {
            var tenantConfigurationForExecution = tenantConfigurationAsObject as TenantConfiguration;

            _logger.Debug($"Setting tenant configuration for '{tenantConfigurationForExecution.TenantIdentifier}' into context for job '{context.JobDetail.Key.Name}'...");
            _tenantConfigurationContextProvider.Set(tenantConfigurationForExecution);

            // Proceed with execution
            await Execute(context);

            return;
        }

        // Intercept the job execution, and instead of executing it now, add tenant-specific single-execution jobs
        _logger.Debug($"Intercepting execution of scheduled job '{context.JobDetail.Key.Name}' to reschedule it as tenant-specific single-executions...");
        
        // Iterate all tenant configurations
        foreach (var tenantConfiguration in TenantConfigurationProvider.GetAllConfigurations())
        {
            // Add the tenant configuration to the job data
            var jobDataMap = new JobDataMap((IDictionary<string, object>)context.JobDetail.JobDataMap);
            jobDataMap[nameof(TenantConfiguration)] = tenantConfiguration;

            var tenantSpecificJobName = $"{context.JobDetail.Key.Name}-{tenantConfiguration.TenantIdentifier}";
            var tenantSpecificTriggerName = $"{context.Trigger.Key.Name}-{tenantConfiguration.TenantIdentifier}";

            _logger.Debug($"Scheduling job '{context.JobDetail.Key.Name}' as '{tenantSpecificJobName}' for single execution for tenant '{tenantConfiguration.TenantIdentifier}'...");

            await _apiJobScheduler.AddSingleExecutionJob(
                GetType(),
                tenantSpecificJobName,
                tenantSpecificTriggerName,
                jobDataMap);
        }
    }

    protected abstract Task Execute(IJobExecutionContext context);
}
