// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Admin.Services
{
    public abstract class TemplateDatabaseLeaQueryBase : ITemplateDatabaseLeaQuery
    {
        private readonly IDatabaseNameBuilder _databaseNameBuilder;
        protected readonly string _connectionStringTemplate;

        protected TemplateDatabaseLeaQueryBase(IConfigConnectionStringsProvider configConnectionStringsProvider, IDatabaseNameBuilder databaseNameBuilder)
        {
            _databaseNameBuilder = databaseNameBuilder;
            _connectionStringTemplate = configConnectionStringsProvider.GetConnectionString("EdFi_Ods");
        }

        public int[] GetLocalEducationAgencyIds(string sandboxKey)
            => GetLocalEducationAgencyIdsAsync(sandboxKey).GetResultSafely();

        public async Task<int[]> GetLocalEducationAgencyIdsAsync(string sandboxKey)
        {
            using (var conn = CreateConnection(_databaseNameBuilder.TemplateSandboxNameForKey(sandboxKey)))
            {
                var results = await conn.QueryAsync<int>(@"select LocalEducationAgencyId from edfi.LocalEducationAgency")
                    .ConfigureAwait(false);

                return results.ToArray();
            }
        }

        protected abstract DbConnection CreateConnection(string templateDatabaseName);
    }
}
#endif