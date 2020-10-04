// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    public class FakedCompositesOdsConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        public string GetConnectionString()
            => $"Server=(local); Database={CompositesSpecFlowTestFixture.SpecFlowDatabaseName}; Trusted_Connection=True; Application Name=EdFi.Ods.WebApi;";
    }
}
