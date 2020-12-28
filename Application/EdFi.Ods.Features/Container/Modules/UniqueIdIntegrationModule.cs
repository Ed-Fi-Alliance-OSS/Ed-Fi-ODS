// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.UniqueIdIntegration.Caching;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;

namespace EdFi.Ods.Features.Container.Modules
{
    public class UniqueIdIntegrationModule : ConditionalModule
    {
        public UniqueIdIntegrationModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(UniqueIdIntegrationModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.UniqueIdValidation);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            // only install the cache is one is not provided.
            builder.RegisterType<PersonUniqueIdToIdCache>()
                .As<IPersonUniqueIdToIdCache>()
                .IfNotRegistered(typeof(IPersonUniqueIdToIdCache))
                .SingleInstance();

            builder.RegisterType<UniqueIdNotChangedEntityValidator>()
                .As<IEntityValidator>()
                .SingleInstance();

            builder.RegisterType<EnsureUniqueIdAlreadyExistsEntityValidator>()
                .As<IEntityValidator>()
                .SingleInstance();
        }
    }
}
