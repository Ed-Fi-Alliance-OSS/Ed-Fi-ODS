#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;

namespace EdFi.Ods.Common._Installers.ComponentNaming
{
    /// <summary>
    /// Provides short names (and connection string names via field-level attributes) for databases
    /// used by the application.
    /// </summary>
    public enum Databases
    {
        [ConnectionStringName("EdFi_Ods")]
        Ods,

        [ConnectionStringName("EdFi_Admin")]
        Admin,

        [ConnectionStringName("Sso_Integration")]
        SsoIntegration,

        [ConnectionStringName("EduIdContext")]
        EduId,

        [ConnectionStringName("EdFi_master")]
        Master,

        [Obsolete("Use the UniqueIdIntegration enumerated database from the UniqueIdDatabases enumeration.")]
        [ConnectionStringName("UniqueIdIntegrationContext")]
        UniqueIdIntegration
    }
}
#endif
