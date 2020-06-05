// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EdFi.Ods.Api.NetCore.Providers;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.NetCore.Middleware
{
    public class EdFiOAuthAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IAuthenticationProvider _authenticationProvider;

        public EdFiOAuthAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthenticationProvider authenticationProvider,
            IApiKeyContextProvider apiKeyContextProvider)
            : base(options, logger, encoder, clock)
        {
            _authenticationProvider = authenticationProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticationResult authenticationResult;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

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

            // Set the api key context
            _apiKeyContextProvider.SetApiKeyContext(authenticationResult.ApiKeyContext);

            var principal = new ClaimsPrincipal(authenticationResult.ClaimsIdentity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
