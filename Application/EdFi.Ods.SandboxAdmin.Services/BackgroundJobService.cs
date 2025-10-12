// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using EdFi.Ods.Sandbox.Admin.Services.Initialization;
namespace EdFi.Ods.Sandbox.Admin.Services
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IInitializationEngine _engine;
        private readonly Dictionary<string, UserOptions> _users;

        public BackgroundJobService(IInitializationEngine engine, IOptions<Dictionary<string, UserOptions>> users)
        {
            _engine = engine;
            _users = users.Value;
        }

        /// <summary>
        /// Create background jobs to populate users and sandboxes
        /// This class separates the initialization engine from Quartz
        /// </summary>
        public async void Configure(bool exitAfterSandboxCreation = false)
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            
            await scheduler.Start();
            
            await CreateAndScheduleNewJob<CreateIdentityRolesJob>("createIdentityRoles", "setupAdminDatabase");
            await CreateAndScheduleNewJob<CreateIdentityUsersJob>("createIdentityUsers", "setupAdminDatabase");
            
            await CreateAndScheduleNewJob<CreateSandboxesJob>("createSandboxes", "setupAdminDatabase");
            
            foreach (var user in _users)
            {
                // refresh existing sandboxes periodically
                if (user.Value.Sandboxes.Any(s => s.Value.Refresh))
                {
                    // Change the recurrence to suit your needs using Cron functions or a unix CRON expressions (i.e. "0 */6 * * * ?" = every 6 hours)
                    await CreateAndScheduleNewJob<RebuildSandboxesJob>($"refreshSandboxes-{user.Value.Email}", "setupAdminDatabase", "0 */24 * * * ?");
                }
            }
            
            async Task<IJobDetail> CreateAndScheduleNewJob<T>(string idName, string idGroup, string cronExpression = null)
                where T : IJob
            {
                var newJob = JobBuilder.Create<T>().WithIdentity(idName, idGroup).Build();
                newJob.JobDataMap.Put("engine", _engine);
                newJob.JobDataMap.Put("exitAfterSandboxCreation", exitAfterSandboxCreation);
                ITrigger newTrigger;
            
                // If no cron expression is provided, then use a simple schedule that runs once
                if (string.IsNullOrEmpty(cronExpression))
                {
                    newTrigger = TriggerBuilder.Create()
                        .WithIdentity(idName, idGroup)
                        .WithSimpleSchedule()
                        .StartNow()
                        .Build();
                }
                else
                {
                    newTrigger = TriggerBuilder.Create()
                        .WithIdentity(idName, idGroup)
                        .WithCronSchedule(cronExpression)
                        .StartNow()
                        .Build();
                }

                await scheduler.ScheduleJob(newJob, newTrigger);
                return newJob;
            }
        }
    }

    [DisallowConcurrentExecution]
    public class CreateIdentityRolesJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ((IInitializationEngine)context.MergedJobDataMap["engine"]).CreateIdentityRoles();
            return Task.CompletedTask;
        }
    }

    [DisallowConcurrentExecution]
    public class CreateIdentityUsersJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ((IInitializationEngine)context.MergedJobDataMap["engine"]).CreateIdentityUsers();
            return Task.CompletedTask;
        }
    }

    [DisallowConcurrentExecution]
    public class RebuildSandboxesJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ((IInitializationEngine)context.MergedJobDataMap["engine"]).RebuildSandboxes();
            return Task.CompletedTask;
        }
    }

    [DisallowConcurrentExecution]
    public class CreateSandboxesJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ((IInitializationEngine)context.MergedJobDataMap["engine"]).CreateSandboxes();

            if (context.MergedJobDataMap.GetBoolean("exitAfterSandboxCreation"))
            {
                Environment.Exit(0);
            }

            return Task.CompletedTask;
        }
    }
}
