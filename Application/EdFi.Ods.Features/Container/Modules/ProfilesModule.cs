// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.Profiles;
using EdFi.Ods.Security.Profiles;

namespace EdFi.Ods.Features.Container.Modules
{
    public class ProfilesModule : ConditionalModule
    {
        public ProfilesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ProfilesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Profiles);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<AdminProfileNamesPublisher>()
                .As<IAdminProfileNamesPublisher>()
                .SingleInstance();

            builder.RegisterType<ProfileResourceNamesProvider>()
                .As<IProfileResourceNamesProvider>()
                .As<IProfileMetadataProvider>()
                .SingleInstance();

            builder.RegisterType<ProfileResourceModelProvider>()
                .As<IProfileResourceModelProvider>()
                .SingleInstance();

            builder.RegisterType<ProfileNamePublisher>()
                .As<IExternalTask>()
                .SingleInstance();
        }
    }
}