using Autofac;
using EdFi.Ods.Api.ScheduledJobs.Providers;
using EdFi.Ods.Common.Configuration;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Linq;

namespace EdFi.Ods.Api.ScheduledJobs.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        // The purpose of the ConfigureScheduleJobs method is to wire-up background tasks to be handled by quartz-scheduler.net
        public static async void ConfigureScheduledJobs(this IApplicationBuilder app, ApiSettings apiSettings, ILifetimeScope container, ILog logger)
        {
            var duplicateScheduledJobs =
                apiSettings.ScheduledJobs
                    .GroupBy(a => a.Name)
                    .Where(a=>a.Count() > 1)
                    .Select(a => a.First().Name).ToList();

            if (duplicateScheduledJobs.Any())
            {
                logger.Warn($"The following scheduled jobs have duplicate names: {string.Join(", ", duplicateScheduledJobs)}");
            }

            var enabledDistinctScheduledJobs =
                apiSettings.ScheduledJobs
                    .Where(a=>a.IsEnabled)
                    .GroupBy(a => a.Name)
                    .Select(a => a.First()).ToList();

            if (!enabledDistinctScheduledJobs.Any())
            {
                logger.Debug($"There are currently no enabled scheduled jobs");
                return;
            }

            var schedulerFactory = app.ApplicationServices.GetService<ISchedulerFactory>();

            if (schedulerFactory == null)
            {
                logger.Debug($"Scheduler factory service not running");
                return;
            }

            var scheduler = await schedulerFactory.GetScheduler();

            ISchedulerConfiguratorProvider schedulerConfiguratorProvider = container.Resolve<ISchedulerConfiguratorProvider>();
            enabledDistinctScheduledJobs.ForEach(async scheduledJobSetting =>
            {
                var configurator = schedulerConfiguratorProvider.GetSchedulerConfigurator(scheduledJobSetting.Name);

                if (configurator != null)
                {
                    logger.Debug($"Scheduled job: {scheduledJobSetting.Name} added to background task scheduling service");
                    await configurator.AddScheduledJob(scheduler, scheduledJobSetting);
                }
                else
                {
                    logger.Warn($"Scheduled job: {scheduledJobSetting.Name} is not available in the background task scheduling service");
                }
            });
        }
    }
}