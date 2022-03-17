// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using log4net;
using Quartz;
using Quartz.Impl.Matchers;

namespace EdFi.Ods.Api.ScheduledJobs.Jobs
{
    public class SchedulerStatusScheduledJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SchedulerStatusScheduledJob));

        public async Task Execute(IJobExecutionContext context)
        {
            var scheduler = context.Scheduler;
            var jobGroupNames = await scheduler.GetJobGroupNames();

            foreach (var jobGroupName in jobGroupNames)
            {
                var groupMatcher = GroupMatcher<JobKey>.GroupContains(jobGroupName);
                var jobKeys = await scheduler.GetJobKeys(groupMatcher);

                foreach (var jobKey in jobKeys)
                {
                    var triggers = await scheduler.GetTriggersOfJob(jobKey);

                    foreach (ITrigger trigger in triggers)
                    {
                        _logger.Info(
                            $"Previous trigger for scheduled Job {jobKey.Name} was last executed at {trigger.GetPreviousFireTimeUtc()}");

                        _logger.Info(
                            $"Next trigger for scheduled Job {jobKey.Name} is scheduled for {trigger.GetNextFireTimeUtc()}");
                    }
                }
            }
        }
    }
}