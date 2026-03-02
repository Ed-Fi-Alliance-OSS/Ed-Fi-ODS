// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EdFi.Ods.Api.Security.Authentication;

public class OneRosterJwtAccessTokenFactoryDecorator(
    IAccessTokenFactory _next,
    IOneRosterTokenClaimsProvider _claimsProvider,
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

        var claimsResult = _claimsProvider.CreateClaims(apiClientDetails, token, scope);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _securitySettings.Value.Jwt.Issuer,
            Subject = new ClaimsIdentity(claimsResult.Claims),
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

            token.Scope = baseScope + string.Join(' ', claimsResult.OneRosterScopes);
        }

        return token;
    }
}
