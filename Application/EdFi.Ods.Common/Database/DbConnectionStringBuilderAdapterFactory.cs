// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Common.Database
{
    public class DbConnectionStringBuilderAdapterFactory : IDbConnectionStringBuilderAdapterFactory
    {
        private readonly DatabaseEngine _databaseEngine;

        public DbConnectionStringBuilderAdapterFactory(DatabaseEngine databaseEngine)
        {
            _databaseEngine = databaseEngine;
        }

        public IDbConnectionStringBuilderAdapter Get()
        {
            if (_databaseEngine == DatabaseEngine.Postgres)
            {
                return new NpgsqlConnectionStringBuilderAdapter();
            }

            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                return new SqlConnectionStringBuilderAdapter();
            }

            throw new ArgumentException("Unknown database engine specified");
        }
    }
}
