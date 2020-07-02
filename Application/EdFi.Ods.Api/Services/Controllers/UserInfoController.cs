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
    public class UserInfoController : ApiController
    {
        private readonly IUserInfoProvider _userInfoProvider;

        public UserInfoController(IUserInfoProvider userInfoProvider)
        {
            _userInfoProvider = userInfoProvider;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            UserInfo userInfo = await _userInfoProvider.GetUserInfoAsync();

            HttpContext.Current.Response.Headers.Add("Cache-Control", "no-cache");
            return Ok(userInfo);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync()
        {
            // post is required for OpenIdConnect, but we do not have any requirements at this point for OpenIdConnect
            // in the future this could be a surrogate id of the api client id which is not available in the function.
            // for now we return a get based off the bearer token.
            return await GetAsync();
        }
    }
}
