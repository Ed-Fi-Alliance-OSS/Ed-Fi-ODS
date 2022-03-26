using Autofac;
using EdFi.Ods.Api.ScheduledJobs.Configurators;
using EdFi.Ods.Api.ScheduledJobs.Providers;
using System;
using System.Linq;

namespace EdFi.Ods.Api.ScheduledJobs.Container.Modules
{
    public class SchedulerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchedulerConfiguratorProvider>()
                .As<ISchedulerConfiguratorProvider>()
                .SingleInstance();

            var assembly = typeof(Marker_EdFi_Ods_Api).Assembly;
            var schedulerConfiguratorTypes = assembly.GetTypes()
                .Where(t => typeof(ISchedulerConfigurator).IsAssignableFrom(t) && !t.IsAbstract).ToList();

            foreach (Type schedulerConfiguratorType in schedulerConfiguratorTypes)
            {
                builder.RegisterType(schedulerConfiguratorType)
                    .As<ISchedulerConfigurator>()
                    .SingleInstance();
            }
        }
    }
}