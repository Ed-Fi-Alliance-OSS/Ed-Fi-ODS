// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Data.SqlClient;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using Npgsql;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class EngineBasedDatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly IEngineTypeProvider _engineTypeProvider;

        public EngineBasedDatabaseConnectionProvider(IEngineTypeProvider engineTypeProvider)
        {
            _engineTypeProvider = Preconditions.ThrowIfNull(engineTypeProvider, nameof(engineTypeProvider));
        }

        public DbConnection CreateConnection(string connectionString)
            => _engineTypeProvider.EngineType == EngineType.SQLServer
                ? new SqlConnection(connectionString)
                : new NpgsqlConnection(connectionString) as DbConnection;
    }
}
