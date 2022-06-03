// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Extensions;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("oauth/token")]
    [Produces("application/json")]
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class TokenController : ControllerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TokenController));
        private readonly ITokenRequestProvider _requestProvider;

        public TokenController(ITokenRequestProvider provider)
        {
            _requestProvider = provider;
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/json")]
        public async Task<IActionResult> PostFromJsonAsync([FromBody] TokenRequest tokenRequest)
        {
            // Look for the authorization header, since we MUST support this method of authorization
            // https://tools.ietf.org/html/rfc6749#section-2.3.1
            // Decode and parse the client id/secret from the header
            // Authorization is in a form of Bearer <encoded client and secret>
            // We accept two cases for the json post, if the json post contains the client secret and client credentials
            // then we process with that information, other we look for a header with a bearer token
            // and parse the response then. We fail when there is a client_secret or client_id in the header and json at the
            // same time.
            string[] clientIdAndSecret = new string[0];

            if (Request.Headers.ContainsKey("Authorization"))
            {
                string[] encodedClientAndSecret = Request.Headers["Authorization"]
                    .ToString()
                    .Split(' ');

                if (encodedClientAndSecret.Length != 2)
                {
                    _logger.Debug("Header is not in the form of Basic <encoded credentials>");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                if (!encodedClientAndSecret[0].EqualsIgnoreCase("Basic"))
                {
                    _logger.Debug("Authorization scheme is not Basic");
                    return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
                }

                if (string.IsNullOrWhiteSpace(encodedClientAndSecret[1]))
                {
                    _logger.Debug("Header does not have <encoded credentials> value");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                try
                {
                    clientIdAndSecret = GetClientIdAndSecret(encodedClientAndSecret[1]);

                    if (clientIdAndSecret.Length != 2)
                    {
                        return BadRequest(new TokenError(TokenErrorType.InvalidClient));
                    }
                }
                catch (Exception)
                {
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }
            }

            if (clientIdAndSecret.Length == 2)
            {
                if (!string.IsNullOrWhiteSpace(tokenRequest.Client_id) || !string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
                {
                    return BadRequest(new TokenError(TokenErrorType.InvalidClient));
                }

                // Correct format will include 2 entries
                // format of the string is <client_id>:<client_secret>
                tokenRequest.Client_id = clientIdAndSecret[0];
                tokenRequest.Client_secret = clientIdAndSecret[1];
            }

            if (string.IsNullOrWhiteSpace(tokenRequest.Client_id) || string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
            {
                return Unauthorized(new TokenError(TokenErrorType.InvalidRequest));
            }

            // Handle token request
            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);


            if (authenticationResult.TokenError != null && authenticationResult.TokenError.Error.EqualsIgnoreCase(TokenErrorType.InvalidClient))
            {
                return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
            }

            if (authenticationResult.TokenError != null)
            {
                return BadRequest(authenticationResult.TokenError);
            }

            return Ok(authenticationResult.TokenResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostAsync([FromForm] TokenRequest tokenRequest)
        {
            // Look for the authorization header, since we MUST support this method of authorization
            // https://tools.ietf.org/html/rfc6749#section-2.3.1
            // Decode and parse the client id/secret from the header
            // Authorization is in a form of Bearer <encoded client and secret>
            string[] clientIdAndSecret = new string[0];

            if (Request.Headers.ContainsKey("Authorization"))
            {
                string[] encodedClientAndSecret = Request.Headers["Authorization"]
                    .ToString()
                    .Split(' ');

                if (encodedClientAndSecret.Length != 2)
                {
                    _logger.Debug("Header is not in the form of Basic <encoded credentials>");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                if (!encodedClientAndSecret[0]
                    .EqualsIgnoreCase("Basic"))
                {
                    _logger.Debug("Authorization scheme is not Basic");
                    return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
                }

                if (string.IsNullOrWhiteSpace(encodedClientAndSecret[1]))
                {
                    _logger.Debug("Header does not have <encoded credentials> value");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                try
                {
                    clientIdAndSecret = GetClientIdAndSecret(encodedClientAndSecret[1]);

                    if (clientIdAndSecret.Length != 2)
                    {
                        return BadRequest(new TokenError(TokenErrorType.InvalidClient));
                    }
                }
                catch (Exception)
                {
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }
            }

            if (clientIdAndSecret.Length == 2)
            {
                if (!string.IsNullOrWhiteSpace(tokenRequest.Client_id) || !string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
                {
                    return BadRequest(new TokenError(TokenErrorType.InvalidClient));
                }

                // Correct format will include 2 entries
                // format of the string is <client_id>:<client_secret>
                tokenRequest.Client_id = clientIdAndSecret[0];
                tokenRequest.Client_secret = clientIdAndSecret[1];
            }

            if (string.IsNullOrWhiteSpace(tokenRequest.Client_id) || string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
            {
               return Unauthorized(new TokenError(TokenErrorType.InvalidRequest));
            }

            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

            if (authenticationResult.TokenError != null && authenticationResult.TokenError.Error.EqualsIgnoreCase(TokenErrorType.InvalidClient))
            {
                return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
            }

            if (authenticationResult.TokenError != null)
            {
                return BadRequest(authenticationResult.TokenError);
            }

            return Ok(authenticationResult.TokenResponse);
        }

        private static string[] GetClientIdAndSecret(string encodedClientAndSecret)
        {
            string[] clientIdAndSecret = Encoding.UTF8.GetString(Convert.FromBase64String(encodedClientAndSecret))
                .Split(':');

            return clientIdAndSecret;
        }
    }
}
