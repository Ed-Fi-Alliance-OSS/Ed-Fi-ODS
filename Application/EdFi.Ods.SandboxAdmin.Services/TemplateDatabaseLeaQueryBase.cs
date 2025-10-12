// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;

namespace EdFi.Ods.SandboxAdmin.Services
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

        public long[] GetLocalEducationAgencyIds(string sandboxKey)
            => GetEdOrgIdsAsync(sandboxKey, "LocalEducationAgency").GetResultSafely();

        public long[] GetCommunityProviderIds(string sandboxKey)
            => GetEdOrgIdsAsync(sandboxKey, "CommunityProvider").GetResultSafely();

        private async Task<long[]> GetEdOrgIdsAsync(string sandboxKey, string table)
        {
            using (var conn = CreateConnection(_databaseNameBuilder.TemplateSandboxNameForKey(sandboxKey)))
            {
                var results = await conn.QueryAsync<long>($"select {table}Id from edfi.{table}")
                    .ConfigureAwait(false);

                return results.ToArray();
            }
        }

        protected abstract DbConnection CreateConnection(string templateDatabaseName);
    }
}