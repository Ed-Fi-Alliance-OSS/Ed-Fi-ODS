// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Features.OwnershipBasedAuthorization.NHibernate;
using EdFi.Ods.Features.OwnershipBasedAuthorization.Security;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.OwnershipBasedAuthorization.Container.Modules
{
    public class OwnershipBasedAuthorizationModule : ConditionalModule
    {
        public OwnershipBasedAuthorizationModule(IFeatureManager featureManager)
            : base(featureManager) { }

        protected override bool IsSelected() => IsFeatureEnabled(ApiFeature.OwnershipBasedAuthorization);

        protected override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<OwnershipBasedAuthorizationNHibernateConfigurationActivity>()
                .As<INHibernateBeforeBindMappingActivity>();

            builder.RegisterGenericDecorator(typeof(OwnershipInitializationCreateEntityDecorator<>), typeof(ICreateEntity<>));
        }
    }
}