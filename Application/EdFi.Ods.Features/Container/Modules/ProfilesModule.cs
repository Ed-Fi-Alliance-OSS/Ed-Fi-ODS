// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.ExternalTasks;
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
using EdFi.Ods.Features.Profiles;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ProfilesModule : ConditionalModule
    {
        public ProfilesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ProfilesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Profiles);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseProfileDefinitionsProvider>()
                                    "Admin Database Profile Definitions",
                    .As<IProfileDefinitionsProvider>()
                    .SingleInstance();

            builder.RegisterType<EmbeddedResourceProfileDefinitionsProvider>()
                    .As<IProfileDefinitionsProvider>()
                    .SingleInstance();

            builder.RegisterType<ProfileMetadataProvider>()
                    .As<IProfileMetadataProvider>()
                    .EnableInterfaceInterceptors()
                    .SingleInstance();

            builder.RegisterType<CachingInterceptor>()
                .WithParameter(
                    new ResolvedParameter(
                        (parmInfo, ctx) => parmInfo.ParameterType == typeof(ICacheProvider<ulong>),
                        (parmInfo, ctx) => new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Profile Metadata",
                            TimeSpan.FromSeconds(ApiSettings.Caching.Profiles.AbsoluteExpirationSeconds))))
                .Named<IInterceptor>("cache-profile-metadata");

            builder.RegisterType<ProfileResourceNamesProvider>()
                .As<IProfileResourceNamesProvider>()
                .SingleInstance();

            builder.RegisterType<AdminProfileNamesPublisher>()
                    .As<IAdminProfileNamesPublisher>()
                    .SingleInstance();

            builder.RegisterType<ProfileNamePublisher>()
                .As<IExternalTask>()
                .SingleInstance();

            builder.RegisterType<AppDomainEmbeddedResourcesProfilesMetadataStreamsProvider>()
                .As<IProfilesMetadataStreamsProvider>()
                .SingleInstance();

            builder.RegisterType<ProfileMetadataValidator>()
                .As<IProfileMetadataValidator>()
                .SingleInstance();

            builder.RegisterType<ProfileResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .SingleInstance();

            builder.RegisterType<ProfileValidationReporter>()
                .As<IProfileValidationReporter>()
                .SingleInstance();

            builder.RegisterType<ProfileConfigurationActivity>()
                .As<IApplicationConfigurationActivity>()
                .SingleInstance();
        }
    }
}