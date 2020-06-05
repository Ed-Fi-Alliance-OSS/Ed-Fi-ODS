// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using EdFi.Ods.Api.Common.Models.Tokens;

namespace EdFi.Ods.Api.Services.Authentication.ClientCredentials
{
    public class AuthenticationSuccess : IHttpActionResult
    {
        private readonly HttpRequestMessage _httpRequest;
        private readonly TokenResponse _response;

        public AuthenticationSuccess(HttpRequestMessage httpRequest, TokenResponse response)
        {
            _httpRequest = httpRequest;
            _response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpResponse = _httpRequest.CreateResponse(HttpStatusCode.OK, _response);

            // From https://tools.ietf.org/html/rfc6749#section-5.1
            /*
                   The authorization server MUST include the HTTP "Cache-Control"
                   response header field [RFC2616] with a value of "no-store" in any
                   response containing tokens, credentials, or other sensitive
                   information, as well as the "Pragma" response header field [RFC2616]
                   with a value of "no-cache".
                 */
            httpResponse.Headers.CacheControl = new CacheControlHeaderValue
                                                {
                                                    NoStore = true
                                                };

            httpResponse.Headers.Add("Pragma", "no-cache");

            return Task.FromResult(httpResponse);
        }
    }
}
