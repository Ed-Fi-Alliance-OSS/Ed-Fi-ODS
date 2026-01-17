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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static EdFi.Ods.Common.Constants.RequestActions;

namespace EdFi.Ods.Api.Security.Authentication;

public class OneRosterJwtAccessTokenFactoryDecorator(
    IAccessTokenFactory _next,
    DbProviderFactory _dbProviderFactory,
    IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider,
    IClaimSetClaimsProvider _claimSetClaimsProvider,
    IOptions<SecuritySettings> _securitySettings) : IAccessTokenFactory
{
    private readonly Lazy<SigningCredentials> _signingCredentials = new(() =>
    {
        // Get the Private Key for signing and register as a singleton
        var rsa = RSA.Create();
        rsa.ImportFromPem(_securitySettings.Value.Jwt.SigningKey.PrivateKey);
        return new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
    });

    private record JwtClaimData(string ClaimSetName, long EducationOrganizationId);

    public async Task<AccessToken> CreateAccessTokenAsync(int apiClientId, string scope = null)
    {
        var token = await _next.CreateAccessTokenAsync(apiClientId, scope);

        if (token == null)
        {
            return null;
        }

        // Obtain the necessary data from the Admin database (scope claims and EdOrgIds)
        var oneRosterClaimData = await GetOneRosterClaimData();

        // https://datatracker.ietf.org/doc/html/rfc7519#section-4.1.7
        List<Claim> claims = [new(JwtRegisteredClaimNames.Jti, token.Id)];

        // Add audiences (from configuration)
        claims.AddRange(_securitySettings.Value.Jwt.Audiences.Select(a => new Claim(JwtRegisteredClaimNames.Aud, a)));

        // EducationOrganizationIds
        claims.AddRange(
            oneRosterClaimData.EducationOrganizationIds.Select(id => new Claim("educationOrganizationId", id.ToString())));

        // Add the scope claims only for OneRoster scopes
        if (oneRosterClaimData.Scopes.Any())
        {
            // https://datatracker.ietf.org/doc/html/rfc7662#section-2.2
            claims.AddRange(oneRosterClaimData.Scopes.Select(s => new Claim("scope", s)));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _securitySettings.Value.Jwt.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(token.Duration),
            SigningCredentials = _signingCredentials.Value,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        // Rewrite the token as a serialized JWT with the original "id" in a "jti" claim on the JWT
        token.Id = tokenHandler.WriteToken(jwtToken);

        // Set the OAuth 2.0 token response's scope (space delimited)
        if (!string.IsNullOrEmpty(scope))
        {
            // Preserve the original scope behavior (EdOrgIds)
            string baseScope = !string.IsNullOrWhiteSpace(token.Scope) ? (token.Scope.Trim() + " ") : string.Empty;

            token.Scope = baseScope + string.Join(' ', oneRosterClaimData.Scopes);
        }

        return token;

        async Task<(string[] Scopes, long[] EducationOrganizationIds)> GetOneRosterClaimData()
        {
            // Get the API client's claim set name (from the associated Application)
            await using var connection = _dbProviderFactory.CreateConnection();
            
            connection!.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            await connection.OpenAsync();

            var claimData = (await connection.QueryAsync<JwtClaimData>(
                @"
                select ClaimsetName, EducationOrganizationId
                from dbo.applications app 
                    inner join dbo.apiclients c 
                        on app.applicationid = c.application_applicationid
                    inner join dbo.ApiClientApplicationEducationOrganizations apiEdOrgs
                        on c.ApiClientId = apiEdOrgs.ApiClient_ApiClientId
                    inner join dbo.ApplicationEducationOrganizations appEdOrgs
                        on apiEdOrgs.ApplicationEducationOrganization_ApplicationEducationOrganizationId = appEdOrgs.ApplicationEducationOrganizationId
                where apiclientid = @apiClientId",
                new { apiClientId = apiClientId }))
                .ToList();

            string claimSetName = claimData.Select(d => d.ClaimSetName).FirstOrDefault();
            long[] edOrgIds = claimData.Select(d => d.EducationOrganizationId).ToArray();

            // If no scope(s) were requested, return an empty list with the EdOrgIds
            if (scope == null)
            {
                return (Array.Empty<string>(), edOrgIds);
            }

            // Inspect the security metadata for the claim set to determine the One Roster scopes
            var claimsMetadata = _claimSetClaimsProvider.GetClaims(claimSetName)
                .Where(c => c.ClaimName.StartsWith(SecuritySettings.OneRosterScopePrefix))
                .Select(c => new
                {
                    c.ClaimName,
                    // Distill the actions into a CRUD bitmask
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

            // Valid OneRoster bitmask values
            const int ReadOnly = 2;
            const int CreatePut = 5;
            const int Delete = 8;

            var scopeList = 
                // Convert claims metadata to OneRoster scopes
                claimsMetadata.Where(c => (c.Actions & ReadOnly) != 0).Select(s => $"{s.ClaimName}.readonly")
                    .Concat(claimsMetadata.Where(c => (c.Actions & CreatePut) != 0).Select(s => $"{s.ClaimName}.createput"))
                    .Concat(claimsMetadata.Where(c => (c.Actions & Delete) != 0).Select(s => $"{s.ClaimName}.delete"))
                    // Intersect with the requested scopes
                    .Intersect(scope.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    .ToArray();

            return (scopeList, edOrgIds);
        }
    }
}
