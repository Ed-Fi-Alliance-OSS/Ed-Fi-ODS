// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Exceptions;
using Microsoft.AspNetCore.Authentication;

namespace EdFi.Ods.Api.Security.Authentication;

public class EdFiAdminAccessTokenFactory : IAccessTokenFactory
{
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly int _tokenDurationMinutes;
    private readonly int _tokenPerClientLimit;

    private const string AddTokenProcedureName = "dbo.CreateClientAccessToken";
    private const string TokenLimitReachedDbMessage = "Token limit reached";
    private const string ClientNotApprovedDbMessage = "Client is not approved";

    public EdFiAdminAccessTokenFactory(
        DbProviderFactory dbProviderFactory,
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        int tokenDurationMinutes,
        int tokenPerClientLimit)
    {
        if (tokenDurationMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException("The token expiration duration (seconds) must be greater than 0.");
        }

        _dbProviderFactory = dbProviderFactory;
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;

        _tokenDurationMinutes = tokenDurationMinutes;
        _tokenPerClientLimit = tokenPerClientLimit;
    }

    public async Task<AccessToken> CreateAccessTokenAsync(int apiClientId, string scope = null)
    {
        await using var connection = _dbProviderFactory.CreateConnection();
        connection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
        await connection.OpenAsync();

        var @params = new
        {
            id = Guid.NewGuid(),
            expiration = DateTime.UtcNow.Add(TimeSpan.FromMinutes(_tokenDurationMinutes)),
            scope = scope,
            apiclientid = apiClientId,
            maxtokencount = _tokenPerClientLimit
        };

        try
        {
            await connection.ExecuteAsync(AddTokenProcedureName, @params, commandType: CommandType.StoredProcedure);
        }
        catch (DbException ex) when (ex.Message.Contains(ClientNotApprovedDbMessage))
        {
            throw new SecurityAuthenticationException(AuthenticationFailureMessages.ClientNotApproved);
        }
        catch (DbException ex) when (ex.Message.Contains(TokenLimitReachedDbMessage))
        {
            throw new TooManyTokensException(_tokenPerClientLimit);
        }

        return new AccessToken(@params.id, TimeSpan.FromMinutes(_tokenDurationMinutes), scope);
    }
}
