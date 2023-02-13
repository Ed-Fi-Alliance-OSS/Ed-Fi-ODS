// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.WebApi.IntegrationTests.Sandbox;
using EdFi.Ods.WebApi.IntegrationTests.YearSpecific;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class IntegrationTestOdsConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly ApiSettings _apiSettings;
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;
        private readonly IConfiguration _configuration;

        public IntegrationTestOdsConnectionStringProvider(IConfiguration configuration, ApiSettings apiSettings, ISchoolYearContextProvider schoolYearContextProvider)
        {
            _configuration = configuration;
            _apiSettings = apiSettings;
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public string GetConnectionString()
        {
            return _apiSettings.GetApiMode() == ApiMode.YearSpecific
                ? YearSpecificHostGlobalFixture.Instance.GetConnectionString(_schoolYearContextProvider.GetSchoolYear().ToString())
                : SandboxHostGlobalFixture.Instance.GetConnectionString();
        }

        public string GetReadOnlyConnectionString() => GetConnectionString(); // No read-only connection support here
    }
}
