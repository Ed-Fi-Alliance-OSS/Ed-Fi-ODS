// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;

namespace EdFi.Ods.Api.Configuration;

public class EdFiAdminRawOdsInstanceConfigurationDataProvider : IEdFiAdminRawOdsInstanceConfigurationDataProvider
{
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;

    private const string GetOdsConfigurationByIdSql = "SELECT OdsInstanceId, ConnectionString, ContextKey, ContextValue, DerivativeType, ConnectionStringByDerivativeType FROM dbo.GetOdsInstanceConfigurationById(@OdsInstanceId);";

    public EdFiAdminRawOdsInstanceConfigurationDataProvider(
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
    }

    public async Task<RawOdsInstanceConfigurationDataRow[]> GetByIdAsync(int odsInstanceId)
    {
        await using var connection = CreateConnectionAsync();

        var rawDataRows = (await connection.QueryAsync<RawOdsInstanceConfigurationDataRow>(
                GetOdsConfigurationByIdSql, 
                new { OdsInstanceId = odsInstanceId }))
            .ToArray();

        return rawDataRows;
        
        DbConnection CreateConnectionAsync()
        {
            var newConnection = _dbProviderFactory.CreateConnection();
            newConnection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            
            return newConnection;
        }
    }
}
