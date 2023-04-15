// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    // TODO: Remove?
    public class SpecFlowOdsConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public SpecFlowOdsConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
            => _configuration.GetConnectionString("EdFi_Ods");

        public string GetReadReplicaConnectionString() => GetConnectionString(); // No read-only connection support here
    }
}
