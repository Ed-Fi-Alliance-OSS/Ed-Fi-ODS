// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Database;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Container;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Api.Container.Modules
{
    public class InstanceYearSpecificPersistenceModule : ConditionalModule
    {
        public InstanceYearSpecificPersistenceModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(InstanceYearSpecificPersistenceModule)) { }

        //Need to run every time
        public override bool IsSelected() => true;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            if (ApiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
            {
                builder.RegisterType<InstanceAdminDatabaseNameTokenReplacementConnectionStringProvider>()
                    .As<IAdminDatabaseConnectionStringProvider>()
                    .SingleInstance();

                builder.RegisterType<InstanceSecurityDatabaseNameTokenReplacementConnectionStringProvider>()
                    .As<ISecurityDatabaseConnectionStringProvider>()
                    .SingleInstance();
            }
            else
            {
                builder.RegisterType<AdminDatabaseConnectionStringProvider>()
                    .As<IAdminDatabaseConnectionStringProvider>()
                    .SingleInstance();

                builder.RegisterType<SecurityDatabaseConnectionStringProvider>()
                    .As<ISecurityDatabaseConnectionStringProvider>()
                    .SingleInstance();
            }
        }
    }
}