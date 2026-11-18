// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [ApplyOdsRouteRootTemplate]
    [Route("oauth/token")]
    public class TokenController : ControllerBase
    {
        private const string BasicAuthenticationChallenge = "Basic realm=\"Ed-Fi ODS API\", charset=\"UTF-8\"";

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
            // The header is in the form of Basic <base64 of client_id:client_secret>.
            // We accept the client credentials either in the header or in the body, but not in both
            // (https://tools.ietf.org/html/rfc6749#section-2.3).
            string rawClientId = null;
            string rawClientSecret = null;

            var authorizationHeader = Request.Headers.Authorization.FirstOrDefault();

            if (authorizationHeader != null)
            {
                string[] encodedClientAndSecret = authorizationHeader.Split(' ');

                if (encodedClientAndSecret.Length != 2)
                {
                    _logger.Debug("Header is not in the form of Basic <encoded credentials>");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                if (!encodedClientAndSecret[0].EqualsIgnoreCase("Basic"))
                {
                    _logger.Debug("Authorization scheme is not Basic");
                    return InvalidClient();
                }

                if (string.IsNullOrWhiteSpace(encodedClientAndSecret[1]))
                {
                    _logger.Debug("Header does not have <encoded credentials> value");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                string decodedClientAndSecret;

                try
                {
                    decodedClientAndSecret = Encoding.UTF8.GetString(Convert.FromBase64String(encodedClientAndSecret[1]));
                }
                catch (FormatException)
                {
                    _logger.Debug("Header <encoded credentials> value is not valid Base64");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                // The client secret may contain a colon, so only the first colon separates the two values
                // (https://tools.ietf.org/html/rfc7617#section-2).
                int separatorIndex = decodedClientAndSecret.IndexOf(':');

                if (separatorIndex < 0)
                {
                    _logger.Debug("Header <encoded credentials> value does not contain a colon separator");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                if (!string.IsNullOrWhiteSpace(tokenRequest.Client_id) || !string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
                {
                    _logger.Debug("Client credentials were supplied in both the header and the body");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest));
                }

                rawClientId = decodedClientAndSecret[..separatorIndex];
                rawClientSecret = decodedClientAndSecret[(separatorIndex + 1)..];

                // RFC 6749 section 2.3.1 requires both values to be form-urlencoded before the Base64 encoding
                tokenRequest.Client_id = WebUtility.UrlDecode(rawClientId);
                tokenRequest.Client_secret = WebUtility.UrlDecode(rawClientSecret);
            }

            if (string.IsNullOrWhiteSpace(tokenRequest.Client_id) || string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
            {
                return InvalidClient();
            }

            // Handle token request
            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

            if (IsInvalidClient(authenticationResult) && HeaderCredentialsChangedByDecoding())
            {
                // Credentials created before the decoding was introduced may contain '+' or '%' characters
                // that their clients send without form-urlencoding them, so try the values as received.
                _logger.Debug("Retrying client authentication with the header credentials as received");

                tokenRequest.Client_id = rawClientId;
                tokenRequest.Client_secret = rawClientSecret;

                authenticationResult = await _requestProvider.HandleAsync(tokenRequest);
            }

            if (IsInvalidClient(authenticationResult))
            {
                return InvalidClient();
            }

            if (authenticationResult.TokenError != null)
            {
                return BadRequest(authenticationResult.TokenError);
            }

            return Ok(authenticationResult.TokenResponse);

            bool HeaderCredentialsChangedByDecoding()
                => rawClientId != null
                    && (rawClientId != tokenRequest.Client_id || rawClientSecret != tokenRequest.Client_secret);

            static bool IsInvalidClient(AuthenticationResponse response)
                => response.TokenError != null && response.TokenError.Error.EqualsIgnoreCase(TokenErrorType.InvalidClient);
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostAsync([FromForm] TokenRequest tokenRequest)
        {
            // Look for the authorization header, since we MUST support this method of authorization
            // https://tools.ietf.org/html/rfc6749#section-2.3.1
            // Decode and parse the client id/secret from the header
            // Authorization is in a form of Basic <encoded client and secret>
            return await PostFromJsonAsync(tokenRequest);
        }

        private UnauthorizedObjectResult InvalidClient()
        {
            // RFC 6749 section 5.2 requires the challenge when the client attempted the Authorization header,
            // and allows it otherwise.
            Response.Headers.WWWAuthenticate = BasicAuthenticationChallenge;

            return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
        }
    }
}
