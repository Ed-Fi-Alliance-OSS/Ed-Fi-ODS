// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Middleware
{
    public class EdFiOAuthAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;

        public EdFiOAuthAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthenticationProvider authenticationProvider,
            IApiKeyContextProvider apiKeyContextProvider,
            IInstanceIdContextProvider instanceIdContextProvider = null)
            : base(options, logger, encoder, clock)
        {
            _authenticationProvider = authenticationProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
            _instanceIdContextProvider = instanceIdContextProvider;
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

                //NOTE: Patch for setting instanceId as IFilterMetadata (InstanceIdContextFilter) is run's too late for EdFi_Admin and EdFi_Security databases.
                /* ------- */
                if (Request.RouteValues.TryGetValue("instanceIdFromRoute", out object instance))
                {
                    // Convert the object value to a string and see if it is empty
                    var instanceId = instance as string;
                    if (!string.IsNullOrEmpty(instanceId))
                    {
                        const string Pattern = @"^[A-Za-z0-9-]+$";
                        //check that the character's are allowed
                        Match match = Regex.Match(instanceId, Pattern);
                        if (match.Success && _instanceIdContextProvider != null)
                        {
                            // If we're still here, set the context value
                            _instanceIdContextProvider.SetInstanceId(instanceId);
                        }
                    }
                }
                /* ------- */

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