// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.NetCore.Providers;
using EdFi.Ods.Common.Extensions;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.NetCore.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("oauth/token")]
    [Produces("application/json")]
    [AllowAnonymous]
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
        public async Task<IActionResult> Post([FromBody] TokenRequest tokenRequest)
        {
            // Handle token request
            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

            if (authenticationResult.TokenError != null)
            {
                return BadRequest(authenticationResult.TokenError);
            }

            return Ok(authenticationResult.TokenResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostFromForm([FromForm] TokenRequest tokenRequest)
        {
            // Look for the authorization header, since we MUST support this method of authorization
            // https://tools.ietf.org/html/rfc6749#section-2.3.1
            // Decode and parse the client id/secret from the header
            // Authorization is in a form of Bearer <encoded client and secret>

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                _logger.Debug($"Header is missing authorization credentials");
                return Unauthorized();
            }

            string[] encodedClientAndSecret = Request.Headers["Authorization"]
                .ToString()
                .Split(' ');

            if (encodedClientAndSecret.Length != 2)
            {
                _logger.Debug("Header is not in the form of Basic <encoded credentials>");
                return Unauthorized();
            }

            if (!encodedClientAndSecret[0]
                .EqualsIgnoreCase("Basic"))
            {
                _logger.Debug("Authorization scheme is not Basic");
                return Unauthorized();
            }

            string[] clientIdAndSecret = Base64Decode(encodedClientAndSecret[1])
                .Split(':');

            // Correct format will include 2 entries
            // format of the string is <client_id>:<client_secret>
            if (clientIdAndSecret.Length == 2)
            {
                tokenRequest.Client_id = clientIdAndSecret[0];
                tokenRequest.Client_secret = clientIdAndSecret[1];
            }

            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

            if (authenticationResult.TokenError != null)
            {
                return BadRequest(authenticationResult.TokenError);
            }

            return Ok(authenticationResult.TokenResponse);

            string Base64Decode(string encoded) => Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }
    }
}
