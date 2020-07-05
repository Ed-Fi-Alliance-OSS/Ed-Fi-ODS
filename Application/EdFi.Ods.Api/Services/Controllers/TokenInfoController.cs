// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Providers;

namespace EdFi.Ods.Api.Services.Controllers
{
    [Authenticate]
    public class TokenInfoController : ApiController
    {
        private readonly ITokenInfoProvider _tokenInfoProvider;

        public TokenInfoController(ITokenInfoProvider tokenInfoProvider)
        {
            _tokenInfoProvider = tokenInfoProvider;
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync()
        {
            TokenInfo tokenInfo = await _tokenInfoProvider.GetTokenInfoAsync();

            HttpContext.Current.Response.Headers.Add("Cache-Control", "no-cache");
            return Ok(tokenInfo);
        }
    }
}
