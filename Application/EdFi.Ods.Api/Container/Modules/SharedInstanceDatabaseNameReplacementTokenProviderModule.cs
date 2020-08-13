﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.Container.Modules
{
    public class SharedInstanceDatabaseNameReplacementTokenProviderModule : ConditionalModule
    {
        public SharedInstanceDatabaseNameReplacementTokenProviderModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SharedInstanceDatabaseNameReplacementTokenProviderModule)) { }

        public override bool IsSelected() => ApiSettings.GetApiMode() == ApiMode.SharedInstance;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SharedInstanceDatabaseNameReplacementTokenProvider>()
                .As<IDatabaseNameReplacementTokenProvider>()
                .SingleInstance();
        }
    }
}
#endif