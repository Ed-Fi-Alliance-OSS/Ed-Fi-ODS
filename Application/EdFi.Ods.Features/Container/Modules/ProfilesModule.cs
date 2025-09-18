// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.SingleFlight;
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
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ProfilesModule : ConditionalModule
    {
        private readonly ApiSettings _apiSettings;

        public ProfilesModule(IFeatureManager featureManager, ApiSettings apiSettings)
            : base(featureManager)
        {
            _apiSettings = apiSettings;
        }

        protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.Profiles);

        protected override void ApplyFeatureDisabledRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<FeatureDisabledProfileResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .SingleInstance();
        }

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
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

            //When MultiTenancy is enabled, the CachingInterceptor is registered as a ContextualCachingInterceptor<TenantConfiguration> in the MultiTenancyModule 
            if (!IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                builder.RegisterType<CachingInterceptor>()
                    .Named<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)
                    .WithParameter(
                        ctx =>
                        {
                            var mediator = ctx.Resolve<IMediator>();
                            
                            return (ISingleFlightCache<ulong, object>) new ExpiringSingleFlightCache<ulong, object>(
                                "Profile Metadata",
                                TimeSpan.FromSeconds(_apiSettings.Caching.Profiles.AbsoluteExpirationSeconds),
                                () => mediator.Publish(new ProfileMetadataCacheExpired()),
                                TimeSpan.FromSeconds(_apiSettings.Caching.Profiles.CreationTimeoutSeconds));
                        })
                    .SingleInstance();
                
                // Wrap into AsyncDeterminationInterceptor to support async interception
                builder.Register(ctx =>
                        new AsyncDeterminationInterceptor(ctx.ResolveNamed<IAsyncInterceptor>(InterceptorCacheKeys.ProfileMetadata)))
                    .Named<IInterceptor>(InterceptorCacheKeys.ProfileMetadata);
            }
            
            builder.RegisterType<AdminProfileNamesPublisher>()
                .As<IAdminProfileNamesPublisher>()
                .SingleInstance();

            builder.RegisterType<PublishAdminProfileNamesStartupCommand>()
                .As<IStartupCommand>()
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