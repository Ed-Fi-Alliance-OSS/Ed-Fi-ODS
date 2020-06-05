// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Security.Authorization;

namespace EdFi.Ods.Security.Container.Modules
{
    public class EducationOrganizationCachingModule : ConditionalModule
    {
        public EducationOrganizationCachingModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(EducationOrganizationCachingModule)) { }

        public override bool IsSelected() => !ApiSettings.DisableSecurity;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<EducationOrganizationCache>()
                .WithParameter(new NamedParameter("synchronousInitialization", false))
                .As<IEducationOrganizationCache>()
                .AsSelf();

            builder.RegisterType<EducationOrganizationCacheDataProvider>()
                .As<IEducationOrganizationCacheDataProvider>()
                .As<IEducationOrganizationIdentifiersValueMapper>()
                .AsSelf();
        }
    }
}
#endif
