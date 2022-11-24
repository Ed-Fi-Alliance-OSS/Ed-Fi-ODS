// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;

namespace EdFi.Admin.DataAccess.Authentication;

public class EdFiAdminAccessTokenFactory : IAccessTokenFactory
{
    private const int DefaultBearerTokenDurationMinutes = 60;
    
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly int _tokenDurationMinutes;

    private const string InsertClientAccessTokenSql = "INSERT INTO dbo.ClientAccessTokens(Id, Expiration, Scope, ApiClient_ApiClientId) VALUES (@Id, @Expiration, @Scope, @ApiClientId);";

    public EdFiAdminAccessTokenFactory(
        DbProviderFactory dbProviderFactory,
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        int tokenDurationMinutes)
    {
        if (tokenDurationMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException("The token expiration duration (seconds) must be greater than 0.");
        }

        _dbProviderFactory = dbProviderFactory;
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;

        _tokenDurationMinutes = tokenDurationMinutes;
    }
    
    public async Task<AccessToken> CreateAccessToken(int apiClientId, string scope = null)
    {
        await using var connection = _dbProviderFactory.CreateConnection();
        connection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
        await connection.OpenAsync();

        var @params = new
        {
            Id = Guid.NewGuid(),
            Expiration = DateTime.UtcNow.Add(TimeSpan.FromMinutes(_tokenDurationMinutes)),
            Scope = scope,
            ApiClientId = apiClientId
        };
            
        await connection.ExecuteAsync(InsertClientAccessTokenSql, @params);

        return new AccessToken(@params.Id, TimeSpan.FromMinutes(_tokenDurationMinutes), scope);
    }
}
