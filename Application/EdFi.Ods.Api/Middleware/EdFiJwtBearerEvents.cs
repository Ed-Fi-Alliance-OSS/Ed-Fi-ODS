// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Makes JWT authentication fail with the same messages as GUID token authentication
/// (see <see cref="EdFiOAuthAuthenticationHandler" />), instead of the default JWT bearer handler results.
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

    private static bool IsConfigurationFailure(Exception exception)
        => exception is SecurityTokenInvalidIssuerException
            or SecurityTokenInvalidAudienceException
            or SecurityTokenSignatureKeyNotFoundException;
}
