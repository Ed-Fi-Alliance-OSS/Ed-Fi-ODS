// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static EdFi.Ods.Common.Constants.RequestActions;

namespace EdFi.Ods.Api.Security.Authentication;

public class OneRosterJwtAccessTokenFactoryDecorator(
    IAccessTokenFactory _next,
    DbProviderFactory _dbProviderFactory,
    IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider,
    IClaimSetClaimsProvider _claimSetClaimsProvider,
    IOptions<SecuritySettings> _securitySettings) : IAccessTokenFactory
{
    public async Task<AccessToken> CreateAccessTokenAsync(int apiClientId, string scope = null)
    {
        var token = await _next.CreateAccessTokenAsync(apiClientId, scope);

        if (token == null)
        {
            return null;
        }

        var oneRosterScopes = await GetOneRosterScopes();

        List<Claim> claims =
        [
            // https://datatracker.ietf.org/doc/html/rfc7519#section-4.1.7
            new(JwtRegisteredClaimNames.Jti, token.Id)
        ];

        if (oneRosterScopes.Any())
        {
            // https://datatracker.ietf.org/doc/html/rfc7662#section-2.2
            claims.Add(new("scope", string.Join(" ", oneRosterScopes)));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.Value.SigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(token.Duration),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        // Rewrite the token as a serialized JWT with original "id" as a "jti" claim, and include the scopes in the response as well
        token.Id = tokenHandler.WriteToken(jwtToken);

        if (oneRosterScopes.Any())
        {
            string baseScope = !string.IsNullOrWhiteSpace(token.Scope) ? (token.Scope.Trim() + " ") : string.Empty;

            token.Scope = baseScope + string.Join(" ", oneRosterScopes);
        }

        return token;

        async Task<List<string>> GetOneRosterScopes()
        {
            // If no scope was requested, return an empty list
            if (scope == null)
            {
                return [];
            }

            // Get the API client's claim set name (from the associated Application)
            await using var connection = _dbProviderFactory.CreateConnection();
            
            connection!.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            await connection.OpenAsync();

            var claimSetName = await connection.ExecuteScalarAsync<string>(
                "select claimsetname from dbo.applications app inner join dbo.apiclients c on app.applicationid = c.application_applicationid where apiclientid = @apiClientId",
                new { apiClientId = apiClientId });

            // Inspect the security metadata for the claim set to determine the One Roster scopes
            var claimsMetadata = _claimSetClaimsProvider.GetClaims(claimSetName)
                .Where(c => c.ClaimName.StartsWith("https://purl.imsglobal.org/spec/or/v1p1/"))
                .Select(c => new
                {
                    c.ClaimName,
                    Actions = c.Actions
                        .Select(a => a.Name switch
                        {
                            CreateActionUri => 1,
                            ReadActionUri => 2, 
                            UpdateActionUri => 4, 
                            DeleteActionUri => 8,
                            _ => 0
                        })
                        .Aggregate((a, b) => a | b)
                })
                .ToList();

            const int ReadOnly = 2;
            const int CreatePut = 5;
            const int Delete = 8;

            var scopeList = 
                // Convert claims metadata to OneRoster scopes
                claimsMetadata.Where(c => (c.Actions & ReadOnly) != 0).Select(s => $"{s.ClaimName}.readonly")
                    .Concat(claimsMetadata.Where(c => (c.Actions & CreatePut) != 0).Select(s => $"{s.ClaimName}.createput"))
                    .Concat(claimsMetadata.Where(c => (c.Actions & Delete) != 0).Select(s => $"{s.ClaimName}.delete"))
                    // Intersect the requested scopes
                    .Intersect(scope.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    .ToList();

            return scopeList;
        }
    }
}
