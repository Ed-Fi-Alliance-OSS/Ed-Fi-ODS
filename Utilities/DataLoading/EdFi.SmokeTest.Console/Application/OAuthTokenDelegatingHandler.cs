// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;

namespace EdFi.SmokeTest.Console.Application
{
    /// <summary>
    /// DelegatingHandler that adds OAuth Bearer token to each HTTP request
    /// </summary>
    public class OAuthTokenDelegatingHandler : DelegatingHandler
    {
        private readonly IOAuthTokenHandler _tokenHandler;

        public OAuthTokenDelegatingHandler(IOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Get fresh token for each request
            var token = _tokenHandler.GetBearerToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}
