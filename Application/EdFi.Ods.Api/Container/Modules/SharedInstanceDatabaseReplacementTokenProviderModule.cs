﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api.Container.Modules
{
    public class SharedInstanceDatabaseReplacementTokenProviderModule : ConditionalModule
    {
        public SharedInstanceDatabaseReplacementTokenProviderModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(SharedInstanceDatabaseReplacementTokenProviderModule)) { }

        public override bool IsSelected() => ApiSettings.GetApiMode() == ApiMode.SharedInstance;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            builder.RegisterType<SharedInstanceDatabaseReplacementTokenProvider>()
                .As<IDatabaseReplacementTokenProvider>()
                .SingleInstance();
        }
    }
}