using System.Linq;
using Autofac.Features.Indexed;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Common.Configuration;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.Jobs.Extensions
{
    public class InitializeScheduledJobs : IExternalTask
    {
        private readonly ApiSettings _apiSettings;
        private readonly IApiJobScheduler _apiJobScheduler;
        private readonly IIndex<string, IJob> _jobsByName;
        private readonly ILog _logger = LogManager.GetLogger(typeof(InitializeScheduledJobs));

        public InitializeScheduledJobs(
            ApiSettings apiSettings,
            IApiJobScheduler apiJobScheduler,
            IIndex<string, IJob> jobsByName)
        {
            _apiSettings = apiSettings;
            _apiJobScheduler = apiJobScheduler;
            _jobsByName = jobsByName;
        }
        
        public void Execute()
        {
            var duplicateScheduledJobs =
                _apiSettings.ScheduledJobs
                    .GroupBy(a => a.Name)
                    .Where(a=>a.Count() > 1)
                    .Select(a => a.First().Name).ToList();

            if (duplicateScheduledJobs.Any())
            {
                _logger.Warn($"The following scheduled jobs have duplicate names: {string.Join(", ", duplicateScheduledJobs)}");
            }

            var enabledDistinctScheduledJobs =
                _apiSettings.ScheduledJobs
                    .Where(a=>a.IsEnabled)
                    .GroupBy(a => a.Name)
                    .Select(a => a.First()).ToList();

            if (!enabledDistinctScheduledJobs.Any())
            {
                _logger.Debug($"There are currently no enabled scheduled jobs...");
                return;
            }

            foreach (var scheduledJobSetting in enabledDistinctScheduledJobs)
            {
                if (_jobsByName.TryGetValue(scheduledJobSetting.Name, out var job))
                {
                    _logger.Debug($"Scheduled job '{scheduledJobSetting.Name}' added to background task scheduling service...");
                    
                    _apiJobScheduler.AddScheduledJob(job.GetType(), scheduledJobSetting)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();;
                }
                else
                {
                    _logger.Warn($"Scheduled job '{scheduledJobSetting.Name}' is not available in the background task scheduling service...");
                }
            }
        }
    }
}