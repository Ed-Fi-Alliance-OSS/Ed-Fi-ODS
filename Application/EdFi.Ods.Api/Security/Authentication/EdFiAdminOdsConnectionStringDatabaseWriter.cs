// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Security.Authentication;

/// <summary>
/// Defines an interface for writing the connection string for an ODS instance to the EdFi_Admin database.
/// </summary>
public class EdFiAdminOdsConnectionStringDatabaseWriter : IEdFiOdsConnectionStringWriter
{
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    
    private const string UpdateOdsConnectionStringByIdSql = "UPDATE dbo.OdsInstances SET ConnectionString = @ConnectionString WHERE OdsInstanceId = @OdsInstanceId";
    private const string UpdateOdsDerivativeConnectionStringByIdSql = "UPDATE dbo.OdsInstanceDerivatives SET ConnectionString = @ConnectionString WHERE OdsInstance_OdsInstanceId = @OdsInstanceId AND DerivativeType = @DerivativeType";

    /// <inheritdoc cref="IEdFiOdsConnectionStringWriter.WriteConnectionStringAsync"/>
    public EdFiAdminOdsConnectionStringDatabaseWriter(IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
    }
    
    public async Task WriteConnectionStringAsync(int odsInstanceId, string connectionString, DerivativeType derivativeType = null)
    {
        var connection = CreateConnection();
        
        if (derivativeType == null)
        {
            // Write the encrypted connection string for the main ODS
            await connection.QueryAsync(
                UpdateOdsConnectionStringByIdSql,
                new
                {
                    ConnectionString = connectionString,
                    OdsInstanceId = odsInstanceId,
                });
        }
        else
        {
            // Write the encrypted connection string for the derivative ODS
            await connection.QueryAsync(
                UpdateOdsDerivativeConnectionStringByIdSql,
                new
                {
                    OdsInstanceId = odsInstanceId,
                    ConnectionString = connectionString,
                    DerivativeType = derivativeType.ToString(),
                });
        }
        
        DbConnection CreateConnection()
        {
            var newConnection = _dbProviderFactory.CreateConnection();
            newConnection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();

            return newConnection;
        }
    }
}
