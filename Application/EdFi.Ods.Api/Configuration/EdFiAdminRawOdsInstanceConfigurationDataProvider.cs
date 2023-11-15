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

/// <summary>
/// Implements a configuration data provider that reads ODS instance configuration data from the EdFi_Admin database.
/// </summary>
public class EdFiAdminRawOdsInstanceConfigurationDataProvider : IEdFiAdminRawOdsInstanceConfigurationDataProvider
{
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;

    private const string GetOdsConfigurationByIdSql = "SELECT OdsInstanceId, ConnectionString, ContextKey, ContextValue, DerivativeType, ConnectionStringByDerivativeType FROM dbo.GetOdsInstanceConfigurationById(@OdsInstanceId);";

    private const string GetDistinctOdsContextValuesSql = "SELECT ContextValue FROM dbo.GetOdsInstanceContextValues(@OdsContextKey);";

    public EdFiAdminRawOdsInstanceConfigurationDataProvider(
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
    }

    /// <inheritdoc cref="IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetByIdAsync" />
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

    public async Task<string[]> GetDistinctOdsInstanceContextValuesAsync(string odsContextKey, string connectionStringOverride = null)
    {
        await using var connection = CreateConnectionAsync();

        var contextValues = (await connection.QueryAsync<string>(
                GetDistinctOdsContextValuesSql,
                new { OdsContextKey = odsContextKey }))
            .ToArray();


        return contextValues;

        DbConnection CreateConnectionAsync()
        {
            var newConnection = _dbProviderFactory.CreateConnection();
            newConnection.ConnectionString = connectionStringOverride ?? _adminDatabaseConnectionStringProvider.GetConnectionString();

            return newConnection;
        }
    }
}
