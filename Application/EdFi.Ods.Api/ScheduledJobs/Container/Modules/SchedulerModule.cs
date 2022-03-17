using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using EdFi.Ods.Api.ScheduledJobs.Providers;

namespace EdFi.Ods.Api.ScheduledJobs.Container.Modules
{
    public class SchedulerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchedulerConfiguratorProvider>()
                .As<ISchedulerConfiguratorProvider>()
                .SingleInstance();
        }
    }
}
