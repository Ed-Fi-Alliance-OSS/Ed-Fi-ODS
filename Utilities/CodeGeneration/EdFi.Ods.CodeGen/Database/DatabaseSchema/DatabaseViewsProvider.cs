// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class DatabaseViewsProvider : IViewsProvider
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private readonly string _connectionString;
        private List<DatabaseView> _views;

        public DatabaseViewsProvider(
            IDatabaseConnectionProvider databaseConnectionProvider,
            IDatabaseConnectionStringProvider connectionStringProvider)
        {
            _databaseConnectionProvider = Preconditions.ThrowIfNull(
                databaseConnectionProvider, nameof(databaseConnectionProvider));

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
    }
}
