// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Configuration;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Container.Modules
{
    public class SecurityRepositoryModule : ConditionalModule
    {
        public SecurityRepositoryModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SecurityRepositoryModule)) { }

        //Only if the ApiMode is not InstanceYearSpecific
        public override bool IsSelected() => !(ApiSettings.GetApiMode() == ApiMode.InstanceYearSpecific);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityRepository>()
                .As<ISecurityRepository>()
                .SingleInstance();
        }
    }
}