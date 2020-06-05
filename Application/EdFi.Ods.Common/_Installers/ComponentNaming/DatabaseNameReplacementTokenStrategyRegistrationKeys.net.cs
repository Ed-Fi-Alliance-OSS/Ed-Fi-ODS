#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common._Installers.ComponentNaming
{
    public static class DatabaseNameReplacementTokenStrategyRegistrationKeys
    {
        private static readonly string BaseName = typeof(IDatabaseNameReplacementTokenProvider).Name + ".";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database replacement token
        /// strategy for Ed-Fi ODS Sandbox databases.
        /// </summary>
        public static string Sandbox = BaseName + "Sandbox";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database replacement token
        /// strategy for year-specific Ed-Fi ODS databases.
        /// </summary>
        public static string YearSpecific = BaseName + "YearSpecific";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database replacement token
        /// strategy for shared instance Ed-Fi ODS databases.
        /// </summary>
        public static string SharedInstance = BaseName + "SharedInstance";

        /// <summary>
        /// Get the registration key to use when registering or referring to the database replacement token
        /// strategy for district-specific Ed-Fi ODS databases.
        /// </summary>
        public static string DistrictSpecific = BaseName + "DistrictSpecific";
    }
}
#endif