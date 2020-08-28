// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Database;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class EngineBasedDatabaseConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IEngineTypeProvider _engineTypeProvider;

        public EngineBasedDatabaseConnectionStringProvider(IConfigurationRoot configuration, IEngineTypeProvider engineTypeProvider)
        {
            _configuration = Preconditions.ThrowIfNull(configuration, nameof(configuration));
            _engineTypeProvider = Preconditions.ThrowIfNull(engineTypeProvider, nameof(engineTypeProvider));
        }

        public string GetConnectionString() => _configuration.GetConnectionString(
            _engineTypeProvider.EngineType == EngineType.SQLServer
                ? DatabaseConventions.EdFiOdsEmpty
                : DatabaseConventions.EdFiOdsEmptyPostgreSQL);
    }
}
