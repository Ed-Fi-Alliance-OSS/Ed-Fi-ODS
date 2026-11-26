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
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private const string BasicScheme = "Basic";
        private const string BasicAuthenticationChallenge = "Basic realm=\"Ed-Fi ODS API\", charset=\"UTF-8\"";

        private const string MalformedBasicHeaderDescription =
            "The Authorization header must be 'Basic' followed by the Base64 encoding of client_id:client_secret.";

        private const string MissingSeparatorDescription =
            "The decoded Basic credentials must contain a ':' between the client_id and the client_secret.";

        private const string CredentialsInHeaderAndBodyDescription =
            "Client credentials must be supplied in either the Authorization header or the request body, not both.";

        private const string TooManyRequestsDescription =
            "Too many token requests. Wait for the time in the Retry-After header before trying again.";

        private readonly ILog _logger = LogManager.GetLogger(typeof(TokenController));
        private readonly ITokenRequestProvider _requestProvider;
        private readonly ITokenRequestRateLimiter _rateLimiter;

        public TokenController(ITokenRequestProvider provider, ITokenRequestRateLimiter rateLimiter)
        {
            _requestProvider = provider;
            _rateLimiter = rateLimiter;
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/json")]
        public async Task<IActionResult> PostFromJsonAsync([FromBody] TokenRequest tokenRequest)
        {
            var remoteIpAddress = HttpContext?.Connection?.RemoteIpAddress;

            if (!_rateLimiter.TryAcquireForIpAddress(remoteIpAddress, out var ipAddressRetryAfter))
            {
                _logger.Warn($"Token request rate limit exceeded for IP address '{remoteIpAddress}'.");
                return TooManyRequests(ipAddressRetryAfter);
            }

            // We MUST support client credentials in the Authorization header (https://tools.ietf.org/html/rfc6749#section-2.3.1)
            // and also accept them in the body, but not in both (https://tools.ietf.org/html/rfc6749#section-2.3).
            BasicCredentials headerCredentials = null;

            var authorizationHeader = Request.Headers.Authorization.FirstOrDefault();

            if (authorizationHeader != null)
            {
                if (!TryParseBasicCredentials(authorizationHeader, out headerCredentials, out var errorResult))
                {
                    return errorResult;
                }

                if (!string.IsNullOrWhiteSpace(tokenRequest.Client_id) || !string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
                {
                    _logger.Debug("Client credentials were supplied in both the header and the body");
                    return BadRequest(new TokenError(TokenErrorType.InvalidRequest, CredentialsInHeaderAndBodyDescription));
                }

                tokenRequest.Client_id = headerCredentials.ClientId;
                tokenRequest.Client_secret = headerCredentials.ClientSecret;
            }

            if (string.IsNullOrWhiteSpace(tokenRequest.Client_id) || string.IsNullOrWhiteSpace(tokenRequest.Client_secret))
            {
                _logger.Debug("Client credentials were not supplied");
                return InvalidClientWithChallenge();
            }

            // Checked before authenticating, so that guessing a client's secret can't keep using the server's CPU
            var clientId = tokenRequest.Client_id;

            if (!_rateLimiter.IsClientIdAllowed(clientId, out var clientIdRetryAfter))
            {
                _logger.Warn($"Token request rate limit for failed authentications exceeded for client '{ForLog(clientId)}'.");
                return TooManyRequests(clientIdRetryAfter);
            }

            var authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

            if (authenticationResult.ClientAuthenticationFailed && headerCredentials is { DecodingChangedValues: true })
            {
                // Credentials created before the decoding was introduced may contain '+' or '%' characters
                // that their clients send without form-urlencoding them, so try the values as received.
                tokenRequest.Client_id = headerCredentials.RawClientId;
                tokenRequest.Client_secret = headerCredentials.RawClientSecret;

                authenticationResult = await _requestProvider.HandleAsync(tokenRequest);

                if (authenticationResult.ClientAuthenticationFailed)
                {
                    _logger.Debug("Client authentication failed with the header credentials both decoded and as received");
                }
                else
                {
                    _logger.Info(
                        $"Client '{tokenRequest.Client_id}' authenticated with Basic credentials that were not form-urlencoded.");
                }
            }

            if (authenticationResult.ClientAuthenticationFailed)
            {
                _rateLimiter.RecordFailedAuthentication(clientId);
            }

            if (authenticationResult.TokenError != null
                && authenticationResult.TokenError.Error.EqualsIgnoreCase(TokenErrorType.InvalidClient))
            {
                return InvalidClientWithChallenge();
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
            return await PostFromJsonAsync(tokenRequest);
        }

        private bool TryParseBasicCredentials(
            string authorizationHeader,
            out BasicCredentials credentials,
            out IActionResult errorResult)
        {
            credentials = null;
            errorResult = null;

            var schemeAndParameter = authorizationHeader.Split(' ');

            if (schemeAndParameter.Length != 2)
            {
                _logger.Debug("Header is not in the form of Basic <encoded credentials>");
                errorResult = BadRequest(new TokenError(TokenErrorType.InvalidRequest, MalformedBasicHeaderDescription));
                return false;
            }

            if (!schemeAndParameter[0].EqualsIgnoreCase(BasicScheme))
            {
                _logger.Debug("Authorization scheme is not Basic");
                errorResult = InvalidClientWithChallenge();
                return false;
            }

            if (string.IsNullOrWhiteSpace(schemeAndParameter[1]))
            {
                _logger.Debug("Header does not have <encoded credentials> value");
                errorResult = BadRequest(new TokenError(TokenErrorType.InvalidRequest, MalformedBasicHeaderDescription));
                return false;
            }

            string decodedClientAndSecret;

            try
            {
                decodedClientAndSecret = Encoding.UTF8.GetString(Convert.FromBase64String(schemeAndParameter[1]));
            }
            catch (FormatException)
            {
                _logger.Debug("Header <encoded credentials> value is not valid Base64");
                errorResult = BadRequest(new TokenError(TokenErrorType.InvalidRequest, MalformedBasicHeaderDescription));
                return false;
            }

            // The client secret may contain a colon, so only the first colon separates the two values
            // (https://tools.ietf.org/html/rfc7617#section-2).
            var separatorIndex = decodedClientAndSecret.IndexOf(':');

            if (separatorIndex < 0)
            {
                _logger.Debug("Header <encoded credentials> value does not contain a colon separator");
                errorResult = BadRequest(new TokenError(TokenErrorType.InvalidRequest, MissingSeparatorDescription));
                return false;
            }

            // RFC 6749 section 2.3.1 requires both values to be form-urlencoded before the Base64 encoding
            var rawClientId = decodedClientAndSecret[..separatorIndex];
            var rawClientSecret = decodedClientAndSecret[(separatorIndex + 1)..];

            credentials = new BasicCredentials(
                rawClientId,
                rawClientSecret,
                WebUtility.UrlDecode(rawClientId),
                WebUtility.UrlDecode(rawClientSecret));

            return true;
        }

        private UnauthorizedObjectResult InvalidClientWithChallenge()
        {
            // RFC 6749 section 5.2 requires the challenge when the client attempted the Authorization header,
            // and allows it otherwise.
            Response.Headers.WWWAuthenticate = BasicAuthenticationChallenge;

            return Unauthorized(new TokenError(TokenErrorType.InvalidClient));
        }

        private ObjectResult TooManyRequests(TimeSpan retryAfter)
        {
            Response.Headers.RetryAfter = Math.Max(1, (int)Math.Ceiling(retryAfter.TotalSeconds)).ToString();

            return StatusCode(
                StatusCodes.Status429TooManyRequests,
                new TokenError(TokenErrorType.InvalidRequest, TooManyRequestsDescription));
        }

        // The client_id comes from the request and may not belong to any client, so keep it short and on one line
        private static string ForLog(string value)
            => new string(value.Where(c => !char.IsControl(c)).Take(100).ToArray());

        private sealed record BasicCredentials(string RawClientId, string RawClientSecret, string ClientId, string ClientSecret)
        {
            public bool DecodingChangedValues => RawClientId != ClientId || RawClientSecret != ClientSecret;
        }
    }
}
