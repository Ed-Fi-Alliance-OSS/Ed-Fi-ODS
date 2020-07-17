// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Admin.Services
{
    public abstract class TemplateDatabaseLeaQueryBase : ITemplateDatabaseLeaQuery
    {
        protected readonly IConfigConnectionStringsProvider _configConnectionStringsProvider;
        protected readonly string _connectionStringTemplate;

        protected TemplateDatabaseLeaQueryBase(IConfigConnectionStringsProvider configConnectionStringsProvider)
        {
            _configConnectionStringsProvider = configConnectionStringsProvider;
            _connectionStringTemplate = configConnectionStringsProvider.GetConnectionString("EdFi_Ods");
        }

        public int[] GetLocalEducationAgencyIds(SandboxType sandboxType)
            => GetLocalEducationAgencyIdsAsync(sandboxType).GetResultSafely();

        public async Task<int[]> GetLocalEducationAgencyIdsAsync(SandboxType sandboxType)
        {
            switch (sandboxType)
            {
                case SandboxType.Sample:
                    return await GetLeasForTemplateDatabaseAsync(DatabaseNameBuilder.TemplateSampleDatabase)
                        .ConfigureAwait(false);
                case SandboxType.Minimal:
                    return await GetLeasForTemplateDatabaseAsync(DatabaseNameBuilder.TemplateMinimalDatabase)
                        .ConfigureAwait(false);
                case SandboxType.Empty:
                    return new int[0];
                default:
                    throw new Exception($"Cannot lookup LEA's for sandbox type {sandboxType}");
            }
        }

        protected abstract DbConnection CreateConnection(string templateDatabaseName);

        private async Task<int[]> GetLeasForTemplateDatabaseAsync(string templateDatabaseName)
        {
            using (var conn = CreateConnection(templateDatabaseName))
            {
                var results = await conn.QueryAsync<int>("select LocalEducationAgencyId from edfi.LocalEducationAgency")
                    .ConfigureAwait(false);

                return results.ToArray();
            }
        }
    }
}
