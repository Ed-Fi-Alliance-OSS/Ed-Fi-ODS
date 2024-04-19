// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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
        private readonly ITokenInfoProvider _tokenInfoProvider;
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;
        private readonly bool _isEnabled;

        public TokenInfoController(
            ITokenInfoProvider tokenInfoProvider,
            IApiClientDetailsProvider apiClientDetailsProvider,
            IApiClientContextProvider apiClientContextProvider,
            ILogContextAccessor logContextAccessor,
            ApiSettings apiSettings)
        {
            _tokenInfoProvider = tokenInfoProvider;
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _logContextAccessor = logContextAccessor;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.TokenInfo.GetConfigKeyName());
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

            // see https://tools.ietf.org/html/rfc7662#section-2.2 for oauth token_info spec
            if (tokenInfoRequest == null || tokenInfoRequest.Token == null ||
                !Guid.TryParse(tokenInfoRequest.Token, out Guid accessToken))
            {
                return BadRequest(
                    new BadRequestException(
                        "scenario13.",
                        new[] { "The token was not present, or was not processable as a GUID value." })
                    {
                        CorrelationId = _logContextAccessor.GetCorrelationId()
                    }.AsSerializableModel());
            }

            var oAuthTokenClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(accessToken.ToString("N"));

            if (oAuthTokenClientDetails == null)
            {
                return NotFound();
            }

            ApiClientContext apiContext = _apiClientContextProvider.GetApiClientContext();

            // must be able to see my specific items ie vendor a cannot look at vendor b
            if (oAuthTokenClientDetails.ApiKey != apiContext.ApiKey)
            {
                return Unauthorized();
            }

            var tokenInfo = await _tokenInfoProvider.GetTokenInfoAsync(apiContext);

            Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue { NoCache = true };
            return Ok(tokenInfo);
        }
    }

}