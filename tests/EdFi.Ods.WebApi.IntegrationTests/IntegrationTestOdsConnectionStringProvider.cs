// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;
using EdFi.Ods.WebApi.IntegrationTests.Sandbox;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class IntegrationTestOdsConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return HostGlobalFixture.Instance.GetConnectionString();
        }

        public string GetReadReplicaConnectionString() => GetConnectionString(); // No read-only connection support here
    }
}
