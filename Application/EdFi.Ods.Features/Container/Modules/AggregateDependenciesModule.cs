// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.Conventions;
using EdFi.Ods.Api.Security.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Container.Modules
{
    public class AggregateDependenciesModule : ConditionalModule
    {
        public AggregateDependenciesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(AggregateDependenciesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.AggregateDependencies);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<ResourceLoadGraphFactory>()
                .As<IResourceLoadGraphFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PersonResourceLoadGraphTransformer>()
                .As<IResourceLoadGraphTransformer>()
                .SingleInstance();
        }
    }
}