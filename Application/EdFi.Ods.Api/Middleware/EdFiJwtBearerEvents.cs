// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Makes JWT authentication fail with the same messages as GUID token authentication
/// (see <see cref="EdFiOAuthAuthenticationHandler" />), instead of the default JWT bearer handler results,
/// and rejects a JWT issued by one tenant when it is used with another tenant.
/// </summary>
public class EdFiJwtBearerEvents : JwtBearerEvents
{
    private const string BearerHeaderScheme = "Bearer";

    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiJwtBearerEvents));

    public override Task MessageReceived(MessageReceivedContext context)
    {
        // Without a parseable Authorization header there is no result, as with GUID tokens
        if (!AuthenticationHeaderValue.TryParse(context.Request.Headers.Authorization, out var authHeader))
        {
            return base.MessageReceived(context);
        }

        if (!authHeader.Scheme.EqualsIgnoreCase(BearerHeaderScheme))
        {
            _logger.Debug(AuthenticationFailureMessages.UnknownAuthorizationHeaderScheme);
            context.Fail(AuthenticationFailureMessages.UnknownAuthorizationHeaderScheme);
        }
        else if (string.IsNullOrEmpty(authHeader.Parameter))
        {
            _logger.Debug(AuthenticationFailureMessages.MissingAuthorizationHeaderBearerTokenValue);
            context.Fail(AuthenticationFailureMessages.MissingAuthorizationHeaderBearerTokenValue);
        }

        return base.MessageReceived(context);
    }

    public override Task AuthenticationFailed(AuthenticationFailedContext context)
    {
        if (IsConfigurationFailure(context.Exception))
        {
            // Every token fails this way when the Security:Jwt settings don't match the issued tokens, so log it at
            // the default thresholds (only the exception type; the details are logged at Debug below)
            _logger.Warn(
                $"JWT validation failed with {context.Exception.GetType().Name}. Check the Security:Jwt Issuer, Audiences and SigningKey settings.");
        }

        // Don't expose token validation details (e.g. IdentityModel IDX messages) to the caller
        _logger.Debug("JWT validation failed.", context.Exception);
        context.Fail(AuthenticationFailureMessages.InvalidToken);

        return base.AuthenticationFailed(context);
    }

    public override Task TokenValidated(TokenValidatedContext context)
    {
        var tokenTenantIdentifier = context.Principal?.FindFirst(OneRosterTokenClaimsProvider.TenantIdClaimType)?.Value;

        // Tokens without a tenant claim (e.g. single-tenant deployments) are left to the token lookup
        if (string.IsNullOrEmpty(tokenTenantIdentifier))
        {
            return base.TokenValidated(context);
        }

        var requestTenantIdentifier = context.HttpContext.RequestServices
            ?.GetService<IContextProvider<TenantConfiguration>>()
            ?.Get()
            ?.TenantIdentifier;

        // Without a tenant in context (single-tenant), the token lookup by jti still decides whether the token is valid
        if (requestTenantIdentifier != null && !tokenTenantIdentifier.EqualsIgnoreCase(requestTenantIdentifier))
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(
                    $"JWT validation failed because the token was issued for tenant '{tokenTenantIdentifier}' and the request is for tenant '{requestTenantIdentifier}'.");
            }

            context.Fail(AuthenticationFailureMessages.InvalidToken);
        }

        return base.TokenValidated(context);
    }

    private static bool IsConfigurationFailure(Exception exception)
        => exception is SecurityTokenInvalidIssuerException
            or SecurityTokenInvalidAudienceException
            or SecurityTokenSignatureKeyNotFoundException;
}
