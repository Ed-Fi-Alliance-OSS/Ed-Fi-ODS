// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Claims;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Common.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;

namespace EdFi.Ods.Api.Security.Jwt;

using static OpenIddict.Abstractions.OpenIddictConstants;

public static class OpenIddictIdentityExtensions
{
    public static ClaimsIdentity ToClaimsIdentity(this TokenResponse token, ApiSettings config, string clientId)
    {
        var identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        identity.SetClaim(Claims.Subject, clientId);
        identity.SetClaim(Claims.Audience, config.Services.OpenIddict.Audience);
        identity.SetClaim(Claims.Issuer, config.Services.OpenIddict.Issuer);
        identity.SetClaim(Claims.IssuedAt, DateTime.UtcNow);
        identity.SetClaim(Claims.ExpiresAt, DateTime.UtcNow.Add(TimeSpan.FromMinutes(config.BearerTokenTimeoutMinutes)));
        identity.SetClaim("ctx", token.Access_token);

        identity.SetScopes(token.Scope.Split(" "));

        return identity;
    }
}
