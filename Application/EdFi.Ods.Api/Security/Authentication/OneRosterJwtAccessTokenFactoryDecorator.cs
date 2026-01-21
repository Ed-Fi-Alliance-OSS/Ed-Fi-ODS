// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static EdFi.Ods.Common.Constants.RequestActions;

namespace EdFi.Ods.Api.Security.Authentication;

public class OneRosterJwtAccessTokenFactoryDecorator(
    IAccessTokenFactory _next,
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

    public async Task<AccessToken> CreateAccessTokenAsync(ApiClientDetails apiClientDetails, string scope = null)
    {
        var token = await _next.CreateAccessTokenAsync(apiClientDetails, scope);

        if (token == null)
        {
            return null;
        }

        // https://datatracker.ietf.org/doc/html/rfc7519#section-4.1.7
        List<Claim> claims = [new(JwtRegisteredClaimNames.Jti, token.Id)];

        // Add audiences (from configuration)
        claims.AddRange(_securitySettings.Value.Jwt.Audiences.Select(a => new Claim(JwtRegisteredClaimNames.Aud, a)));

        // EducationOrganizationIds
        claims.AddRange(
            apiClientDetails.EducationOrganizationIds.Select(id => new Claim("educationOrganizationId", id.ToString())));

        // Obtain the necessary data from the Admin database (scope claims and EdOrgIds)
        var oneRosterScopes = GetOneRosterScopes(apiClientDetails.ClaimSetName);

        // Add the scope claims only for OneRoster scopes
        if (oneRosterScopes.Any())
        {
            // https://datatracker.ietf.org/doc/html/rfc7662#section-2.2
            claims.AddRange(oneRosterScopes.Select(s => new Claim("scope", s)));
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
            string baseScope = string.IsNullOrWhiteSpace(token.Scope)
                ? string.Empty
                : (token.Scope.Trim() + ' '); 

            token.Scope = baseScope + string.Join(' ', oneRosterScopes);
        }

        return token;

        string[] GetOneRosterScopes(string claimSetName)
        {
            // If no scope(s) were requested, return an empty list with the EdOrgIds
            if (scope == null)
            {
                return Array.Empty<string>();
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
            const int readOnly = 2;
            const int createPut = 5;
            const int delete = 8;

            var scopeList = 
                // Convert claims metadata to OneRoster scopes
                claimsMetadata.Where(c => (c.Actions & readOnly) != 0).Select(s => $"{s.ClaimName}.readonly")
                    .Concat(claimsMetadata.Where(c => (c.Actions & createPut) != 0).Select(s => $"{s.ClaimName}.createput"))
                    .Concat(claimsMetadata.Where(c => (c.Actions & delete) != 0).Select(s => $"{s.ClaimName}.delete"))
                    // Intersect with the requested scopes
                    .Intersect(scope.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    .ToArray();

            return scopeList;
        }
    }
}
