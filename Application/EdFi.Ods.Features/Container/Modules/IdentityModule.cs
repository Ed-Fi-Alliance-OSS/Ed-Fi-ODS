// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Features.ChangeQueries;
using EdFi.Ods.Features.ChangeQueries.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Models.Identity;

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
               .As<IIdentityServiceAsync>();
        }
    }
}
#endif
