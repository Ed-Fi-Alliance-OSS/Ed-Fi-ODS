// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Domain;
using Npgsql;
using TaskExtensions = System.Data.Entity.Utilities.TaskExtensions;

namespace EdFi.Ods.Admin.Services
{
    public class PostgresTemplateDatabaseLeaQuery : TemplateDatabaseLeaQueryBase
    {
        public PostgresTemplateDatabaseLeaQuery(IConfigConnectionStringsProvider configConnectionStringsProvider)
            : base(configConnectionStringsProvider) { }

        private DbConnection CreateMasterDbConnection()
            => new NpgsqlConnection(_configConnectionStringsProvider.GetConnectionString("EdFi_master"));

        protected override DbConnection CreateConnection(string templateDatabaseName)
            => new NpgsqlConnection(string.Format(_connectionStringTemplate, templateDatabaseName));
    }
}
