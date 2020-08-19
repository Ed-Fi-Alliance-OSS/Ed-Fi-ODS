// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using Castle.Windsor;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.InversionOfControl;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    public class DatabaseConnectionStringProvidersInstaller : RegistrationMethodsInstallerBase
    {
        protected virtual void RegisterAdminDatabaseConnectionStringProvider(IWindsorContainer container)
        {
            // Admin database
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.Admin);
        }

        protected virtual void RegisterMasterDatabaseConnectionStringProvider(IWindsorContainer container)
        {
            // Master database connection (for creating sandboxes)
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.Master);
        }

        protected virtual void RegisterEduIdDatabaseConnectionStringProvider(IWindsorContainer container)
        {
            // EduId database (TODO: Code Split: This will need to be move to TN-specific portion of the codebase)
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.EduId);
        }

        protected virtual void RegisterOdsDatabaseConnectionStringProvider(IWindsorContainer container)
        {
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.Ods);
        }
    }
}
