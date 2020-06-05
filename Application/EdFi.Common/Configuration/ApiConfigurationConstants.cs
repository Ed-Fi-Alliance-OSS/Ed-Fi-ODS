// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration
{
    public static class ApiConfigurationConstants
    {
#if NETFRAMEWORK
        public const string ApiStartupType = "apiStartup:type";
#endif
        public const string Sandbox = "sandbox";
        public const string YearSpecific = "yearspecific";
        public const string SharedInstance = "sharedinstance";
        public const string DistrictSpecific = "districtspecific";

        public const string SqlServerProviderName = "System.Data.SqlClient";
        public const string PostgresProviderName = "Npgsql";

        // ApiModel constants
        public const string PostgreSQL = "postgreSql";
        public const string SqlServer = "sqlServer";
    }
}
