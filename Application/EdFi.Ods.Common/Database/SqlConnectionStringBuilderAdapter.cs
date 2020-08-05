// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace EdFi.Ods.Common.Database
{
    /// <summary>
    /// Implements a SQL Server-specific adapter for the <see cref="DbConnectionStringBuilder" />
    /// that provides the database name through the <see cref="SqlConnectionStringBuilder.InitialCatalog" />
    /// property.
    /// </summary>
    public class SqlConnectionStringBuilderAdapter : IDbConnectionStringBuilderAdapter
    {
        private SqlConnectionStringBuilder _builder;

        public string ConnectionString
        {
            get => _builder?.ConnectionString;
            set => _builder = new SqlConnectionStringBuilder(value);
        }

        public string DatabaseName
        {
            get => _builder.InitialCatalog;
            set
            {
                if (_builder == null)
                {
                    throw new InvalidOperationException("Connection string has not been set.");
                }

                _builder.InitialCatalog = value;
            }
        }
    }
}
