// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Security;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
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
    [RouteRootContext(RouteContextType.Tenant)]
    [Route("oauth/token_info")]
    public class TokenInfoController : ControllerBase
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly ITokenInfoProvider _tokenInfoProvider;
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;
        private readonly bool _isEnabled;

        public TokenInfoController(
            ITokenInfoProvider tokenInfoProvider,
            IApiClientDetailsProvider apiClientDetailsProvider,
            IApiKeyContextProvider apiKeyContextProvider,
            ApiSettings apiSettings)
        {
            _tokenInfoProvider = tokenInfoProvider;
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
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
                return BadRequest(ErrorTranslator.GetErrorMessage("Invalid token"));
            }

            var oAuthTokenClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(accessToken.ToString("N"));

            if (oAuthTokenClientDetails == null)
            {
                return NotFound();
            }

            ApiKeyContext apiContext = _apiKeyContextProvider.GetApiKeyContext();

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