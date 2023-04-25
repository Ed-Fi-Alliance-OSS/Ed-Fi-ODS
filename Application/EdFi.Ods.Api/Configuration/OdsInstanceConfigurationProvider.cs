// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

public class OdsInstanceConfigurationProvider : IOdsInstanceConfigurationProvider
{
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IOdsInstanceHashIdGenerator _odsInstanceHashIdGenerator;

    private const string GetOdsConfigurationByIdSql = "SELECT OdsInstanceId, ConnectionString FROM dbo.GetOdsInstanceConfigurationById(@OdsInstanceId);";
    
    public OdsInstanceConfigurationProvider(
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory,
        IOdsInstanceHashIdGenerator odsInstanceHashIdGenerator)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
        _odsInstanceHashIdGenerator = odsInstanceHashIdGenerator;
    }
    
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
        if (!rawDataRows.Any())
        {
            rawDataRows = null;
        }

        ArgumentNullException.ThrowIfNull(rawDataRows);

        var firstRow = rawDataRows.FirstOrDefault();

        if (firstRow == null)
        {
            return null;
        }

        var configuration = new OdsInstanceConfiguration(
            odsInstanceId: firstRow.OdsInstanceId,
            odsInstanceHashId: _odsInstanceHashIdGenerator.GenerateHashId(firstRow.OdsInstanceId),
            connectionString: firstRow.ConnectionString,
            contextValueByKey: new Dictionary<string, string>(),
            connectionStringByDerivativeType: new Dictionary<DerivativeType, string>()
        );

        return configuration;
    }
    
    private DbConnection CreateConnectionAsync()
    {
        var connection = _dbProviderFactory.CreateConnection();
        connection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            
        return connection;
    }
}
