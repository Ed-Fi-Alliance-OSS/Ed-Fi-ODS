// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Features.IdentityManagement;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace EdFi.Ods.Features.Container.Modules
{
    public class IdentityModule : ConditionalModule
    {
        public IdentityModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(IdentityModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.IdentityManagement);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<IdentitiesControllerRouteConvention>()
              .As<IApplicationModelConvention>()
              .SingleInstance();

            builder.RegisterType<UnimplementedIdentityService>()
               .As<IIdentityService>()
               .As<IIdentityServiceAsync>()
               .SingleInstance();
        }
    }
}
