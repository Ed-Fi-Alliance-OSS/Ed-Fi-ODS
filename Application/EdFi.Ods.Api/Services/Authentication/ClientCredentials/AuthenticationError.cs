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
    public class AuthenticationError : IHttpActionResult
    {
        private readonly TokenError _errorResponse;
        private readonly HttpRequestMessage _httpRequest;

        public AuthenticationError(HttpRequestMessage httpRequest, TokenError errorResponse)
        {
            _httpRequest = httpRequest;
            _errorResponse = errorResponse;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpResponse = _httpRequest.CreateResponse(HttpStatusCode.BadRequest, _errorResponse);
            return Task.FromResult(httpResponse);
        }
    }

    public class AuthenticationUnauthorized : IHttpActionResult
    {
        private readonly HttpRequestMessage _httpRequest;

        public AuthenticationUnauthorized(HttpRequestMessage httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpResponse = _httpRequest.CreateResponse(HttpStatusCode.Unauthorized, new TokenError(TokenErrorType.InvalidClient));
            httpResponse.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_httpRequest.Headers.Authorization.Scheme));
            return Task.FromResult(httpResponse);
        }
    }
}
