// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public interface IDatabaseSchemaProvider
    {
        List<DatabaseIndex> LoadIndices();

        List<DatabaseView> LoadViews();
    }

    public class DatabaseSchemaProvider : IDatabaseSchemaProvider
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private readonly string _connectionString;

        private List<DatabaseIndex> _indices;
        private List<DatabaseView> _views;

        public DatabaseSchemaProvider(IDatabaseConnectionProvider databaseConnectionProvider, IDatabaseConnectionStringProvider connectionStringProvider)
        {
            _databaseConnectionProvider = Preconditions.ThrowIfNull(databaseConnectionProvider, nameof(databaseConnectionProvider));

            Preconditions.ThrowIfNull(connectionStringProvider, nameof(connectionStringProvider));
            _connectionString = connectionStringProvider.GetConnectionString();
        }

        public List<DatabaseView> LoadViews()
        {
            if (_views != null)
            {
                return _views;
            }

            using (var connection = _databaseConnectionProvider.CreateConnection(_connectionString))
            {
                connection.Open();

                using (var dr = new DatabaseReader(connection))
                {
                    dr.CommandTimeout = 60;
                    _views = dr.AllViews().ToList();
                }
            }

            return _views;
        }

        public List<DatabaseIndex> LoadIndices()
        {
            if (_indices != null)
            {
                return _indices;
            }

            using (var connection = _databaseConnectionProvider.CreateConnection(_connectionString))
            {
                connection.Open();

                using (var dr = new DatabaseReader(connection))
                {
                    dr.CommandTimeout = 60;
                    // requires setting the search_path for postgres or no indexes will be returned
                    // example: ALTER DATABASE "EdFi_Ods_Empty_Template" SET search_path TO edfi,auth,util;
                    _indices = dr.AllTables().SelectMany(t => t.Indexes).ToList();
                }
            }

            return _indices;
        }
    }
}
