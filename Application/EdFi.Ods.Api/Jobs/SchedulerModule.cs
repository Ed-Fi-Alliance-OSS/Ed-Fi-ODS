using System.Linq;
using Autofac;
using EdFi.Common.Extensions;
using Quartz;

namespace EdFi.Ods.Api.Jobs
{
    public class SchedulerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiJobScheduler>()
                .As<IApiJobScheduler>()
                .SingleInstance();

            // Scan for jobs
            var assembly = typeof(Marker_EdFi_Ods_Api).Assembly;
            
            var jobTypes = assembly.GetTypes()
                .Where(t => typeof(IJob).IsAssignableFrom(t) && !t.IsAbstract && !t.Name.EndsWith("Decorator"))
                .ToList();

            // Register jobs, keyed by name
            foreach (var jobType in jobTypes)
            {
                builder.RegisterType(jobType)
                    .Named<IJob>(jobType.Name.TrimSuffix("Job"));
            }
        }
    }
}