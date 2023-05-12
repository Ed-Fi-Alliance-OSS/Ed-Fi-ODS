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
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Implements an <see cref="IOdsInstanceConfigurationProvider"/> that obtains ODS instance configurations from the EdFi_Admin database.
/// </summary>
public class OdsInstanceConfigurationProvider : IOdsInstanceConfigurationProvider
{
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IOdsInstanceHashIdGenerator _odsInstanceHashIdGenerator;

    private const string GetOdsConfigurationByIdSql = "SELECT OdsInstanceId, ConnectionString, ContextKey, ContextValue, DerivativeType, ConnectionStringByDerivativeType FROM dbo.GetOdsInstanceConfigurationById(@OdsInstanceId);";
    
    public OdsInstanceConfigurationProvider(
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory,
        IOdsInstanceHashIdGenerator odsInstanceHashIdGenerator)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
        _odsInstanceHashIdGenerator = odsInstanceHashIdGenerator;
    }

    /// <inheritdoc cref="IOdsInstanceConfigurationProvider.GetByIdAsync" />
    public async Task<OdsInstanceConfiguration> GetByIdAsync(int odsInstanceId)
    {
        // Consider refactoring out to follow the pattern used by EdFiAdminRawApiClientDetailsProvider
        await using var connection = CreateConnectionAsync();

        var rawDataRows = (await connection.QueryAsync<RawOdsInstanceConfigurationDataRow>(
                GetOdsConfigurationByIdSql, 
                new { OdsInstanceId = odsInstanceId }))
            .ToArray();

        return CreateOdsInstanceConfiguration(rawDataRows);
    }

    private OdsInstanceConfiguration CreateOdsInstanceConfiguration(
        RawOdsInstanceConfigurationDataRow[] rawDataRows)
    {
        var firstRow = rawDataRows?.FirstOrDefault();

        if (firstRow == null)
        {
            return null;
        }

        var configuration = new OdsInstanceConfiguration(
            odsInstanceId: firstRow.OdsInstanceId,
            odsInstanceHashId: _odsInstanceHashIdGenerator.GenerateHashId(firstRow.OdsInstanceId),
            connectionString: firstRow.ConnectionString,
            contextValueByKey: GetContextValues(),
            connectionStringByDerivativeType: GetConnectionStringsByDerivativeType()
        );

        return configuration;

        IDictionary<string, string> GetContextValues()
        {
            return rawDataRows
                .Where(x => !string.IsNullOrEmpty(x.ContextKey))
                .Select(x => new KeyValuePair<string, string>(x.ContextKey, x.ContextValue))
                .DistinctBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        IDictionary<DerivativeType, string> GetConnectionStringsByDerivativeType()
        {
            return rawDataRows
                .Where(x => !string.IsNullOrEmpty(x.DerivativeType))
                .Select(x => new KeyValuePair<DerivativeType, string>(DerivativeType.Parse(x.DerivativeType), x.ConnectionStringByDerivativeType))
                .DistinctBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
    
    private DbConnection CreateConnectionAsync()
    {
        var connection = _dbProviderFactory.CreateConnection();
        connection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            
        return connection;
    }
}
