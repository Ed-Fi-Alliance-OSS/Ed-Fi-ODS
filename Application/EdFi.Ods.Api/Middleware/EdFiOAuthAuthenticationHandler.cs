// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Providers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Middleware
{
    public class EdFiOAuthAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string BearerHeaderScheme = "Bearer";
        
        private const string UnknownAuthorizationHeaderScheme = "Unknown Authorization header scheme";
        private const string MissingAuthorizationHeaderBearerTokenValue = "Missing Authorization header bearer token value";
        private const string InvalidAuthorizationHeader = "Invalid Authorization header";

        private readonly IOAuthTokenAuthenticator _oauthTokenAuthenticator;

        private readonly ILogger _logger;

        public EdFiOAuthAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            ISystemClock clock,
            IOAuthTokenAuthenticator oauthTokenAuthenticator)
            : base(options, loggerFactory, encoder, clock)
        {
            _logger = loggerFactory.CreateLogger(typeof(EdFiOAuthAuthenticationHandler).FullName!);
            _oauthTokenAuthenticator = oauthTokenAuthenticator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticationHeaderValue authHeader;
            
            try
            {
                if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out authHeader))
                {
                    return AuthenticateResult.NoResult();
                }

                // If there is an authorization header, but we do not recognize the authentication scheme, do nothing.
                if (!authHeader.Scheme.EqualsIgnoreCase(BearerHeaderScheme))
                {
                    _logger.LogDebug(UnknownAuthorizationHeaderScheme);
                    return AuthenticateResult.NoResult();
                }

                // If the token value is missing, fail authentication
                if (string.IsNullOrEmpty(authHeader.Parameter))
                {
                    _logger.LogDebug(MissingAuthorizationHeaderBearerTokenValue);
                    return AuthenticateResult.Fail(MissingAuthorizationHeaderBearerTokenValue);
                }
            }
            catch (ConfigurationException)
            {
                // The Security repository couldn't open a connection to the Security database
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Token authentication failed...");
                return AuthenticateResult.Fail(InvalidAuthorizationHeader);
            }

            try
            {
                var result = await _oauthTokenAuthenticator.AuthenticateAsync(authHeader.Parameter, authHeader.Scheme);

                return result;
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);
            }
        }
    }
}