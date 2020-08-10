// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Data.SqlClient;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Admin.Services
{
    public class SqlServerTemplateDatabaseLeaQuery : TemplateDatabaseLeaQueryBase
    {
        public SqlServerTemplateDatabaseLeaQuery(IConfigConnectionStringsProvider configConnectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
            : base(configConnectionStringsProvider, databaseNameBuilder) { }

        protected override DbConnection CreateConnection(string templateDatabaseName)
            => new SqlConnection(string.Format((string) _connectionStringTemplate, templateDatabaseName));
    }
}
