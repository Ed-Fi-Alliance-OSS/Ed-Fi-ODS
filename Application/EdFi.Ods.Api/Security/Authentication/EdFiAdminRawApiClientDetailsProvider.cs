// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;

namespace EdFi.Ods.Api.Security.Authentication
{
    public class EdFiAdminRawApiClientDetailsProvider : IEdFiAdminRawApiClientDetailsProvider
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IAdminDatabaseConnectionStringProvider _adminConnectionStringProvider;

        // NOTE: Lower case "key" in quotes required -- In SQL Server, key is a reserved word and requires quotes, but once quoted is must be lower-case to match when executed in PostgreSQL
        private const string GetClientDetailsCommonSelect = "SELECT ApiClientId, \"key\", UseSandbox, StudentIdentificationSystemDescriptor, EducationOrganizationId, ClaimSetName, NamespacePrefix, ProfileName, CreatorOwnershipTokenId, OwnershipTokenId";
        private const string GetClientDetailsForKeySql = GetClientDetailsCommonSelect + ", Secret, SecretIsHashed FROM dbo.GetClientForKey(@ApiKey);";
        private const string GetClientDetailsForTokenSql = GetClientDetailsCommonSelect + ", OdsInstanceId, Expiration FROM dbo.GetClientForToken(@Token);";

        public EdFiAdminRawApiClientDetailsProvider(
            DbProviderFactory dbProviderFactory,
            IAdminDatabaseConnectionStringProvider adminConnectionStringProvider)
        {
            _dbProviderFactory = dbProviderFactory;
            _adminConnectionStringProvider = adminConnectionStringProvider;
        }
        
        public async Task<IReadOnlyList<RawApiClientDetailsDataRow>> GetRawClientDetailsDataAsync(Guid accessToken)
        {
            await using var connection = CreateConnectionAsync();

            var apiClientRawDataRows = (await connection.QueryAsync<RawApiClientDetailsDataRow>(
                GetClientDetailsForTokenSql, 
                new { Token = accessToken }))
                .ToArray();

            return apiClientRawDataRows;
        }

        public async Task<IReadOnlyList<RawApiClientDetailsDataRow>> GetRawClientDetailsDataAsync(string key)
        {
            await using var connection = CreateConnectionAsync();

            var apiClientRawDataRows = (await connection.QueryAsync<RawApiClientDetailsDataRow>(
                GetClientDetailsForKeySql, 
                new { ApiKey = key }))
                .ToArray();

            return apiClientRawDataRows;
        }

        private DbConnection CreateConnectionAsync()
        {
            var connection = _dbProviderFactory.CreateConnection();
            connection.ConnectionString = _adminConnectionStringProvider.GetConnectionString();
            
            return connection;
        }
    }
}
