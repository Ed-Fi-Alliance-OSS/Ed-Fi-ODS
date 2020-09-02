// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Features.TokenInfo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebService.Tests.OAuth
{
    [TestFixture]
    public class OAuthTests : HttpClientTestsBase
    {
        [Test]
        public async Task OAuthEndpointPostShouldReturnValidToken()
        {
            var tokenRequest = new TokenRequest()
            {
                Client_id = "clientId",
                Client_secret = "clientSecret",
                Grant_type = "client_credentials"
            };

            var _serializerSettings
                = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string jsonText = JsonConvert.SerializeObject(tokenRequest, _serializerSettings);

            var json = JObject.Parse(jsonText);
            string rawJson = json.ToString();
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(TestConstants.BaseUrl + "oauth/token", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var result = await response.Content.ReadAsStringAsync();

            result.ShouldBeNullOrWhiteSpace();
        }

        [Test]
        public async Task OAuthEndpointPostShouldReturnValidTokenInfo()
        {
            var tokenInfoRequest = new TokenInfoRequest()
            {
                Token = ""
            };

            var _serializerSettings
                = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string jsonText = JsonConvert.SerializeObject(tokenInfoRequest, _serializerSettings);

            var json = JObject.Parse(jsonText);
            string rawJson = json.ToString();
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(TestConstants.BaseUrl + "oauth/token_info", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var result = await response.Content.ReadAsStringAsync();

            result.ShouldBeNullOrWhiteSpace();
        }
    }
}
#endif