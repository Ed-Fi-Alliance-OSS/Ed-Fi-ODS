// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using DatabaseSchemaReader;
using DatabaseSchemaReader.DataSchema;
using EdFi.Common;
using EdFi.Common.Database;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class AuthorizationDatabaseTableViewsProvider : IAuthorizationDatabaseTableViewsProvider
    {
        private readonly string _connectionString;
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private List<AuthorizationDatabaseTable> _views;

        public AuthorizationDatabaseTableViewsProvider(
            IDatabaseConnectionProvider databaseConnectionProvider,
            IDatabaseConnectionStringProvider connectionStringProvider)
        {
            _databaseConnectionProvider = Preconditions.ThrowIfNull(
                databaseConnectionProvider, nameof(databaseConnectionProvider));

            Preconditions.ThrowIfNull(connectionStringProvider, nameof(connectionStringProvider));
            _connectionString = connectionStringProvider.GetConnectionString();
        }

        public List<AuthorizationDatabaseTable> LoadViews()
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

                    _views = dr.AllViews().Select(
                    v => new AuthorizationDatabaseTable()
                    {
                        SchemaOwner = v.SchemaOwner,
                        Name = v.Name,
                        Columns = v.Columns.Select(x=> new AuthorizationDatabaseColumn()
                        { 
                            DbDataType = x.DbDataType,
                            IsPrimaryKey = x.IsPrimaryKey,
                            Length = x.Length,
                            Name = x.Name,
                            Nullable = x.Nullable,
                            Precision = x.Precision,
                            Scale = x.Scale
                        })
                    }).ToList();

                    var dataTupleTable = dr.Table("EducationOrganizationIdToEducationOrganizationId");

                    _views.Add(new AuthorizationDatabaseTable()
                    {
                        SchemaOwner = dataTupleTable.SchemaOwner,
                        Name = dataTupleTable.Name,
                        Columns = dataTupleTable.Columns.Select(x => new AuthorizationDatabaseColumn()
                        {
                            DbDataType = x.DbDataType,
                            IsPrimaryKey = x.IsPrimaryKey,
                            Length = x.Length,
                            Name = x.Name,
                            Nullable = x.Nullable,
                            Precision = x.Precision,
                            Scale = x.Scale
                        })
                    });
                }

                return _views;
            }
        }
    }
}
