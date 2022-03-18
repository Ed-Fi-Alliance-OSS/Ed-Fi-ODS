// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using log4net;
using Quartz;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.ScheduledJobs.Configurators
{
    public class SchedulerConfigurator<T> : ISchedulerConfigurator
        where T : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SchedulerConfigurator<T>));

        public const string DefaultCronExpression = "0 0/30 * 1/1 * ? *"; // Run every 30 minutes repeatedly

        public SchedulerConfigurator(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public JobBuilder GetJobBuilder()
        {
            return JobBuilder.Create<T>();
        }

        public async Task AddScheduledJob(IScheduler scheduler, ScheduledJobSetting scheduledJobSetting,
            CancellationToken cancellationToken = default)
        {
            IJobDetail jobDetail = GetJobDetail(scheduledJobSetting);
            ITrigger trigger = GetTrigger(scheduledJobSetting);

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public IJobDetail GetJobDetail(ScheduledJobSetting scheduledJobSetting)
        {
            return GetJobBuilder()
                .WithIdentity($"{scheduledJobSetting.Name} Job")
                .WithDescription($"{scheduledJobSetting.Name} Job")
                .Build();
        }

        public ITrigger GetTrigger(ScheduledJobSetting scheduledJobSetting)
        {
            string cronSchedule = GetCronExpression(scheduledJobSetting);

            return TriggerBuilder.Create()
                .WithIdentity($"{scheduledJobSetting.Name} Trigger")
                .WithCronSchedule(cronSchedule)
                .WithDescription($"{scheduledJobSetting.Name} Trigger")
                .Build();
        }

        public string GetCronExpression(ScheduledJobSetting scheduledJobSetting)
        {
            bool isCronExpressionValid = scheduledJobSetting?.CronExpression != null && CronExpression.IsValidExpression(scheduledJobSetting.CronExpression);

            if (isCronExpressionValid)
            {
                return scheduledJobSetting.CronExpression;
            }
            
            _logger.Warn($"Invalid cron expression provided for scheduled job: {scheduledJobSetting.Name}");
            return DefaultCronExpression;
        }
    }
}