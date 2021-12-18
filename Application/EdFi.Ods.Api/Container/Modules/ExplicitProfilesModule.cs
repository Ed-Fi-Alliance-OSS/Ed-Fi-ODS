// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ExplicitProfilesModule : ConditionalModule
    {
        public ExplicitProfilesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ExplicitProfilesModule)) { }

        public override bool IsSelected()
            => ApiSettings.IsFeatureEnabled(ApiFeature.Profiles.GetConfigKeyName()) &&
               ApiSettings.IsFeatureEnabled(ApiFeature.UseExplicitProfiles.GetConfigKeyName());

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ExplicitProfilesMiddleware>()
                .As<IMiddleware>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
