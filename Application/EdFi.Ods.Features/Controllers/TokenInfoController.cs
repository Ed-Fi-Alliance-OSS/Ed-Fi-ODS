// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.TokenInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Features.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json")]
    [ApiController]
    [ApplyOdsRouteRootTemplate]
    [Route("oauth/token_info")]
    public class TokenInfoController : ControllerBase
    {
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly ILogContextAccessor _logContextAccessor;
        private readonly IOptions<SecuritySettings> _securitySettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenInfoProvider _tokenInfoProvider;
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;
        private readonly bool _isEnabled;

        public TokenInfoController(
            ITokenInfoProvider tokenInfoProvider,
            IApiClientDetailsProvider apiClientDetailsProvider,
            IApiClientContextProvider apiClientContextProvider,
            ILogContextAccessor logContextAccessor,
            IFeatureManager featureManager,
            IOptions<SecuritySettings> securitySettings,
            IHttpContextAccessor httpContextAccessor)
        {
            _tokenInfoProvider = tokenInfoProvider;
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _logContextAccessor = logContextAccessor;
            _securitySettings = securitySettings;
            _httpContextAccessor = httpContextAccessor;
            _isEnabled = featureManager.IsFeatureEnabled(ApiFeature.TokenInfo);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] TokenInfoRequest tokenInfoRequest) => await GetTokenInformation(tokenInfoRequest);

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostFromFormAsync([FromForm] TokenInfoRequest tokenInfoRequest) => await GetTokenInformation(tokenInfoRequest);

        private async Task<IActionResult> GetTokenInformation(TokenInfoRequest tokenInfoRequest)
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            Guid guidAccessToken = Guid.Empty;

            // see https://tools.ietf.org/html/rfc7662#section-2.2 for oauth token_info spec
            if (tokenInfoRequest?.Token == null
                || (_securitySettings.Value.AccessTokenType == SecuritySettings.AccessTokenTypeGuid
                    && !Guid.TryParse(tokenInfoRequest.Token, out guidAccessToken)))
            {
                return BadRequest(
                    new BadRequestException(
                        "An invalid token was provided",
                        new[] { "The token was not present, or was not processable." })
                    {
                        CorrelationId = _logContextAccessor.GetCorrelationId()
                    }.AsSerializableModel());
            }

            if (_securitySettings.Value.AccessTokenType == SecuritySettings.AccessTokenTypeJwt)
            {
                // Validate that the submitted token matches the Bearer token used to authenticate
                // this request (RFC 7662 §2 — the caller must submit the token to be introspected).
                var authHeader = _httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
                var bearerToken = authHeader?.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) == true
                    ? authHeader["Bearer ".Length..].Trim()
                    : null;

                if (bearerToken == null || !string.Equals(tokenInfoRequest.Token, bearerToken, StringComparison.Ordinal))
                {
                    return BadRequest(
                        new BadRequestException(
                            "An invalid token was provided",
                            new[] { "The token was not present, or was not processable." })
                        {
                            CorrelationId = _logContextAccessor.GetCorrelationId()
                        }.AsSerializableModel());
                }

                if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value, out guidAccessToken))
                {
                    return BadRequest(
                        new BadRequestException(
                            "An invalid token was provided",
                            new[] { "The token was not present, or was not processable." })
                        {
                            CorrelationId = _logContextAccessor.GetCorrelationId()
                        }.AsSerializableModel());
                }
            }

            var oAuthTokenClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(guidAccessToken.ToString("N"));

            ApiClientContext apiContext = _apiClientContextProvider.GetApiClientContext();

            // Return 404 for both missing tokens and tokens owned by another client to
            // prevent enumeration: callers must not learn whether a foreign token exists.
            if (oAuthTokenClientDetails == null || oAuthTokenClientDetails.ApiKey != apiContext.ApiKey)
            {
                return NotFound();
            }

            var tokenInfo = await _tokenInfoProvider.GetTokenInfoAsync(apiContext);

            var typedHeaders = _httpContextAccessor.HttpContext?.Response?.GetTypedHeaders();
            if (typedHeaders != null)
            {
                typedHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            }
            return Ok(tokenInfo);
        }
    }
}