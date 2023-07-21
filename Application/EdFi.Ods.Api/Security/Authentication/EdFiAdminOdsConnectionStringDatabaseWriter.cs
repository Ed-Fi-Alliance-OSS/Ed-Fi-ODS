// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using Dapper;
using EdFi.Admin.DataAccess.Providers;

namespace EdFi.Ods.Api.Security.Authentication;

/// <summary>
/// Defines an interface for writing the connection string for an ODS instance to the admin database.
/// </summary>
public class EdFiAdminOdsConnectionStringDatabaseWriter : IEdFiOdsConnectionStringWriter
{
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    
    private const string UpdateOdsConnectionStringByIdSql = "UPDATE dbo.OdsInstances SET ConnectionString = @ConnectionString WHERE OdsInstanceId = @OdsInstanceId";
    private const string UpdateOdsDerivativeConnectionStringByIdSql = "UPDATE dbo.OdsInstanceDerivative SET ConnectionString = @ConnectionString WHERE OdsInstanceId = @OdsInstanceId AND DerivativeType = @DerivativeType";

    /// <inheritdoc cref="IEdFiOdsConnectionStringWriter.WriteConnectionString"/>
    public EdFiAdminOdsConnectionStringDatabaseWriter(IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        DbProviderFactory dbProviderFactory)
    {
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
    }
    
    public void WriteConnectionString(int odsInstanceId, string connectionString, string derivativeType = null)
    {
        var connection = CreateConnection();
        
        if(!string.IsNullOrEmpty(derivativeType))
        {
            connection.Query(
                UpdateOdsDerivativeConnectionStringByIdSql,
                new
                {
                    ConnectionString = connectionString,
                    OdsInstanceId = odsInstanceId
                });
        }
        else
        {
            connection.Query(
                UpdateOdsConnectionStringByIdSql,
                new
                {
                    ConnectionString = connectionString,
                    OdsInstanceId = odsInstanceId,
                    DerivativeType = derivativeType
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
