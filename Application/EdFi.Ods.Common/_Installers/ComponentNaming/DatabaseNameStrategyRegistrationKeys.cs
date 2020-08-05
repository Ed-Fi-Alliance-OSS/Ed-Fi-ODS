// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common._Installers.ComponentNaming
{
    /// <summary>
    /// Provides keys for IoC container registrations for identifying specific implementations
    /// of database name strategies for configuration purposes.
    /// </summary>
    [Obsolete("This class will soon be deprecated. Use DatabaseNameReplacementTokenStrategyRegistrationKeys instead.", false)]
    public static class DatabaseNameStrategyRegistrationKeys
    {
        private static readonly string BaseName = typeof(IDatabaseNameProvider).Name + ".";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database naming
        /// strategy for Ed-Fi ODS Sandbox databases.
        /// </summary>
        public static string Sandbox = BaseName + "Sandbox";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database naming
        /// strategy for year-specific Ed-Fi ODS databases.
        /// </summary>
        public static string YearSpecificOds = BaseName + "YearSpecificOds";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database naming
        /// strategy for shared instance Ed-Fi ODS databases.
        /// </summary>
        public static string SharedInstance = BaseName + "SharedInstance";
    }
}
