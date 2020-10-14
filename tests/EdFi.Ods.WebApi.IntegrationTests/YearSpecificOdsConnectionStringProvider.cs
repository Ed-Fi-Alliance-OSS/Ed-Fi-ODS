// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.WebApi.IntegrationTests.YearSpecificSharedInstanceTests;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class YearSpecificOdsConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        private static ISchoolYearContextProvider _schoolYearContextProvider;

        public YearSpecificOdsConnectionStringProvider(IConfiguration configuration, ISchoolYearContextProvider schoolYearContextProvider)
        {
            _configuration = configuration;
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder(_configuration.GetConnectionString("EdFi_Ods")) { InitialCatalog = ResolveDatabase() };

            return builder.ConnectionString;
        }

        private static string ResolveDatabase()
        {
            int schoolYear = _schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 2014)
            {
                return WebApiYearSpecificTestFixture.DatabaseName_2014;
            }

            if (schoolYear == 2015)
            {
                return WebApiYearSpecificTestFixture.DatabaseName_2015;
            }

            return string.Empty;
        }
    }
}
