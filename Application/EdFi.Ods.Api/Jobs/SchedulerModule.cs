using System.Linq;
using Autofac;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using log4net;
using Quartz;
using Module = Autofac.Module;

namespace EdFi.Ods.Api.Jobs
{
    public class SchedulerModule : Module
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SchedulerModule));

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiJobScheduler>()
                .As<IApiJobScheduler>()
                .SingleInstance();

            // Scan for jobs
            var assembly = typeof(Marker_EdFi_Ods_Api).Assembly;
            
            var jobTypes = assembly.GetTypes()
                .Where(t => t.IsImplementationOf<IJob>() && !t.IsDecoratorOf<IJob>())
                .ToList();

            // Register jobs, keyed by name
            foreach (var jobType in jobTypes)
            {
                _logger.Debug($"Registering job '{jobType.Name}' with the container...");

                builder.RegisterType(jobType)
                    .Named<IJob>(jobType.Name.TrimSuffix("Job"))
                    .AsSelf()
                    .PropertiesAutowired();
            }
        }
    }
}
