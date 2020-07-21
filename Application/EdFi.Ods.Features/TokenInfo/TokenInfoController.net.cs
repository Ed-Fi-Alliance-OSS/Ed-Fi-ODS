// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.TokenInfo;
using EdFi.Ods.Sandbox.Repositories;

namespace EdFi.Ods.Api.Services.Controllers
{
    [Authenticate]
    public class TokenInfoController : ApiController
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IAccessTokenClientRepo _tokenClientRepo;
        private readonly ITokenInfoProvider _tokenInfoProvider;

        public TokenInfoController(ITokenInfoProvider tokenInfoProvider, IApiKeyContextProvider apiKeyContextProvider,
            IAccessTokenClientRepo tokenClientRepo)
        {
            _tokenInfoProvider = tokenInfoProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
            _tokenClientRepo = tokenClientRepo;
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] TokenInfoRequest tokenInfoRequest)
        {
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

            TokenInfo tokenInfo = await _tokenInfoProvider.GetTokenInfoAsync(apiContext);

            HttpContext.Current.Response.Headers.Add("Cache-Control", "no-cache");
            return Ok(tokenInfo);
        }
    }
}
#endif