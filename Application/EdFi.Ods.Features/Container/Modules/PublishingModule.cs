using Autofac;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Extensions.Publishing.Feature.DatabaseNaming;
using EdFi.Ods.Extensions.Publishing.Feature.ExceptionHandling;
using EdFi.Ods.Extensions.Publishing.Feature.SnapshotContext;
using EdFi.Ods.Features.Publishing.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Features.Container.Modules
{
    public class PublishingModule : ConditionalModule
    {
        public PublishingModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(PublishingModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Publishing);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SnapshotContextProvider>()
                .As<ISnapshotContextProvider>();

            builder.RegisterType<SnapshotContextActionFilter>()
                .As<IFilterMetadata>()
                .SingleInstance();

            builder
                .RegisterDecorator<
                    SnapshotSuffixDatabaseNameReplacementTokenProvider, 
                    IDatabaseNameReplacementTokenProvider>();

            builder.RegisterType<SnapshotGoneExceptionTranslator>()
                .As<IExceptionTranslator>();

            builder.RegisterType<GetSnapshots>()
                .As<IGetSnapshots>()
                .SingleInstance();
        }
    }
}
