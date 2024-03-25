// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Security.Profiles;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Features.Profiles;
using MediatR;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ProfilesModule : ConditionalModule
    {
        public ProfilesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ProfilesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Profiles);

        protected override void ApplyFeatureDisabledRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<FeatureDisabledProfileResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .SingleInstance();
        }

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseProfileDefinitionsProvider>()
                    .As<IProfileDefinitionsProvider>()
                    .SingleInstance();

            builder.RegisterType<EmbeddedResourceProfileDefinitionsProvider>()
                    .As<IProfileDefinitionsProvider>()
                    .SingleInstance();

            builder.RegisterType<ProfileMetadataProvider>()
                    .As<IProfileMetadataProvider>()
                    .EnableInterfaceInterceptors()
                    .SingleInstance();

            builder.RegisterType<ProfileResourceNamesProvider>()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .Named<IInterceptor>(InterceptorCacheKeys.ProfileMetadata)
                .WithParameter(
                    ctx =>
                    {
                        var mediator = ctx.Resolve<IMediator>();

                        return (ICacheProvider<ulong>)new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Profile Metadata",
                            TimeSpan.FromSeconds(ApiSettings.Caching.Profiles.AbsoluteExpirationSeconds),
                            () => mediator.Publish(new ProfileMetadataCacheExpired()));
                    })
                .SingleInstance();

            builder.RegisterType<AdminProfileNamesPublisher>()
                .As<IAdminProfileNamesPublisher>()
                .SingleInstance();

            builder.RegisterType<ProfileMetadataCacheExpiredNotificationHandler>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<AdminProfileNamesPublisherTask>()
                .As<IExternalTask>()
                .SingleInstance();

            builder.RegisterType<ApiJobScheduler>()
                .As<IApiJobScheduler>()
                .SingleInstance();

            builder.RegisterType<AdminProfileNamesPublisherJob>()
                .AsSelf()
                .PropertiesAutowired();

            builder.RegisterType<AppDomainEmbeddedResourcesProfilesMetadataStreamsProvider>()
                .As<IProfilesMetadataStreamsProvider>()
                .SingleInstance();

            builder.RegisterType<ProfileMetadataValidator>()
                .As<IProfileMetadataValidator>()
                .SingleInstance();

            builder.RegisterType<ProfileResourceModelProvider>()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<ProfileValidationReporter>()
                .As<IProfileValidationReporter>()
                .SingleInstance();

            builder.RegisterType<ProfileConfigurationActivity>()
                .As<IApplicationConfigurationActivity>()
                .SingleInstance();

            // Register a decorator over ICreateEntity to perform suitability check of active Profile for resource creation.
            builder.RegisterGenericDecorator(typeof(ProfileBasedCreateEntityDecorator<>), typeof(ICreateEntity<>));
        }
    }
}