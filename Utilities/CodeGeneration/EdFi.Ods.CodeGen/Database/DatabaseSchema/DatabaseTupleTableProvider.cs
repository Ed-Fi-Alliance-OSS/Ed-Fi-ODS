// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using EdFi.Common;
using EdFi.Common.Database;
using EdFi.Ods.CodeGen.Providers;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class DatabaseTupleTableProvider : ITupleTableProvider
    {
        private readonly string _connectionString;
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private DatabaseTable _tupleTable;

        public DatabaseTupleTableProvider(
            IDatabaseConnectionProvider databaseConnectionProvider,
            IDatabaseConnectionStringProvider connectionStringProvider)
        {
            _databaseConnectionProvider = Preconditions.ThrowIfNull(
                databaseConnectionProvider, nameof(databaseConnectionProvider));

            Preconditions.ThrowIfNull(connectionStringProvider, nameof(connectionStringProvider));
            _connectionString = connectionStringProvider.GetConnectionString();
        }

        public DatabaseTable LoadTupleTable()
        {
            if (_tupleTable != null)
            {
                return _tupleTable;
            }

            using (var connection = _databaseConnectionProvider.CreateConnection(_connectionString))
            {
                connection.Open();

                using (var dr = new DatabaseReader(connection))
                {
                    dr.CommandTimeout = 60;
                    _tupleTable = dr.Table("EducationOrganizationIdToEducationOrganizationId");
                }
            }

            return _tupleTable;
        }
    }
}
