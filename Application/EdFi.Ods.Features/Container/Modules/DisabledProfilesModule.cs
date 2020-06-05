// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Features.Container.Modules
{
    public class DisabledProfilesModule : ConditionalModule
    {
        public DisabledProfilesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(DisabledProfilesModule)) { }

        public override bool IsSelected() => !IsFeatureEnabled(ApiFeature.Profiles);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ProfilePassthroughResourceModelProvider>()
                .As<IProfileResourceModelProvider>();
        }
    }
}
#endif