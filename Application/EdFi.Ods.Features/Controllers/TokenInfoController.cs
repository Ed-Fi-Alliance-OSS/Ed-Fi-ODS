// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.TokenInfo;
using EdFi.Ods.Sandbox.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("oauth/tokenInfo")]
    [Produces("application/json")]
    [ApiController]
    public class TokenInfoController : ControllerBase
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IAccessTokenClientRepo _tokenClientRepo;
        private readonly ITokenInfoProvider _tokenInfoProvider;
        private readonly bool _isEnabled;

        public TokenInfoController(ITokenInfoProvider tokenInfoProvider, IApiKeyContextProvider apiKeyContextProvider,
            IAccessTokenClientRepo tokenClientRepo, ApiSettings apiSettings)
        {
            _tokenInfoProvider = tokenInfoProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
            _tokenClientRepo = tokenClientRepo;
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
                return BadRequest("Invalid token");
            }

            var oAuthTokenClient = (await _tokenClientRepo.GetClientForTokenAsync(accessToken)).FirstOrDefault();

            if (oAuthTokenClient == null)
            {
                return NotFound();
            }

            ApiKeyContext apiContext = _apiKeyContextProvider.GetApiKeyContext();

            // must be able to see my specific items ie vendor a cannot look at vendor b
            if (oAuthTokenClient.Key != apiContext.ApiKey)
            {
                return Unauthorized();
            }

            var tokenInfo = await _tokenInfoProvider.GetTokenInfoAsync(apiContext);

            Response.Headers.Add("Cache-Control", "no-cache");
            return Ok(tokenInfo);
        }
    }

}
#endif