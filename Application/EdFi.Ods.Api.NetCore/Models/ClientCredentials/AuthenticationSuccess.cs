// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.NetCore.Models.ClientCredentials
{
    public class AuthenticationSuccess : IActionResult
    {
        private readonly HttpRequestMessage _httpRequest;
        private readonly TokenResponse _response;

        public AuthenticationSuccess(HttpRequestMessage httpRequest, TokenResponse response)
        {
            _httpRequest = httpRequest;
            _response = response;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = _httpRequest,
                Content = new StringContent(JsonSerializer.Serialize(_response))
            };

            httpResponseMessage.Headers.CacheControl = new CacheControlHeaderValue {NoStore = true};

            httpResponseMessage.Headers.Add("Pragma", "no-cache");

            return Task.FromResult(httpResponseMessage);
        }
    }
}
