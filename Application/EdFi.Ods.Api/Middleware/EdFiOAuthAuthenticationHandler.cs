// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Middleware
{
    public class EdFiOAuthAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthenticationProvider _authenticationProvider;

        public EdFiOAuthAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthenticationProvider authenticationProvider)
            : base(options, logger, encoder, clock)
        {
            _authenticationProvider = authenticationProvider;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticationResult authenticationResult;

            try
            {
                if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue authHeader))
                {
                    return AuthenticateResult.NoResult();
                }

                authenticationResult = await _authenticationProvider.GetAuthenticationResultAsync(authHeader);

                if (authenticationResult == null)
                {
                    return AuthenticateResult.NoResult();
                }

                if (authenticationResult.ClaimsIdentity == null && authenticationResult.AuthenticateResult == null)
                {
                    return AuthenticateResult.NoResult();
                }

                if (authenticationResult.AuthenticateResult != null)
                {
                    return authenticationResult.AuthenticateResult;
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var principal = new ClaimsPrincipal(authenticationResult.ClaimsIdentity);

            var ticket = new AuthenticationTicket(principal, CreateAuthenticationProperties(), Scheme.Name);

            return AuthenticateResult.Success(ticket);

            AuthenticationProperties CreateAuthenticationProperties()
            {
                var properties = new Dictionary<string, string>();
                var parameters = new Dictionary<string, object>()
                {
                    {"ApiKeyContext", authenticationResult.ApiKeyContext}
                };

                return new AuthenticationProperties(properties, parameters);
            }
        }
    }
}