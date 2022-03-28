// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using log4net;
using Quartz;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.ScheduledJobs.Configurators
{
    public abstract class SchedulerConfiguratorBase<T> : ISchedulerConfigurator
        where T : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SchedulerConfiguratorBase<T>));

        public const string DefaultCronExpression = "0 0/30 * 1/1 * ? *"; // Run every 30 minutes repeatedly

        public abstract string Name { get; }

        public virtual JobBuilder GetJobBuilder() => JobBuilder.Create<T>();

        public async Task AddScheduledJob(IScheduler scheduler, ScheduledJobSetting scheduledJobSetting,
            CancellationToken cancellationToken = default)
        {
            IJobDetail jobDetail = BuildJobDetail(scheduledJobSetting);
            ITrigger trigger = BuildTrigger(scheduledJobSetting);

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public IJobDetail BuildJobDetail(ScheduledJobSetting scheduledJobSetting)
        {
            return GetJobBuilder()
                .WithIdentity($"{scheduledJobSetting.Name} Job")
                .WithDescription($"{scheduledJobSetting.Name} Job")
                .Build();
        }

        public ITrigger BuildTrigger(ScheduledJobSetting scheduledJobSetting)
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