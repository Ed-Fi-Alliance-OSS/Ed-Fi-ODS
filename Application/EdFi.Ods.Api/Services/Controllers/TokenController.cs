// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Authentication.ClientCredentials;
using EdFi.Ods.Api.Services.Extensions;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Api.Services.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TokenController : ApiController
    {
        private readonly ITokenRequestHandler _requestHandler;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TokenController));

        public TokenController(ITokenRequestHandler handler)
        {
            _requestHandler = handler;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] TokenRequest tokenRequest)
        {
            IHttpActionResult actionResult;
            var httpRequest = ActionContext.Request;

            // Only handle the "client_credentials" grant type
            if (!RequestIsRequiredGrantType(tokenRequest))
            {
                return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.UnsupportedGrantType));
            }

            // If there is Authorization in the header
            if (httpRequest.Headers.Authorization != null)
            {
                // Only Basic authorization is supported
                if (!httpRequest.Headers.Authorization.Scheme.EqualsIgnoreCase("Basic"))
                {
                    return new AuthenticationUnauthorized(httpRequest);
                }

                // If there is an Authorization header, the authorization parameter is required.
                if (!HasCredentialsInHeader(httpRequest))
                {
                    return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidRequest));
                }

                // Go and try to retrieve the ID and Secret from the header
                var headerTokenRequest = GetIdSecretFromHeader(httpRequest, tokenRequest);

                // If we failed to get the credentials from the header, the request was invalid.
                if (headerTokenRequest == null)
                {
                    return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidRequest));
                }

                // If body contains a value for Client_id, verify it matches Client_id retrieved from authorization header
                if (!string.IsNullOrEmpty(tokenRequest.Client_id) && tokenRequest.Client_id != headerTokenRequest.Client_id)
                {
                    return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidRequest));
                }

                // If body contains a value for Client_secret, verify it matches Client_secret retrieved from authorization header
                if (!string.IsNullOrEmpty(tokenRequest.Client_secret) && tokenRequest.Client_secret != headerTokenRequest.Client_secret)
                {
                    return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidRequest));
                }

                // If a valid token request retrieved from header, override body token request values.
                tokenRequest.Client_id = headerTokenRequest.Client_id;
                tokenRequest.Client_secret = headerTokenRequest.Client_secret;
            }

            // Verify client_id and client_secret are present
            if (!IsIdAndSecretPresent(tokenRequest))
            {
                return new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidClient));
            }

            // Handle token request
            _requestHandler.Handle(ActionContext.Request, tokenRequest, out actionResult);
            return actionResult;
        }

        private TokenRequest GetIdSecretFromHeader(HttpRequestMessage httpRequest, TokenRequest tokenRequest)
        {
            TokenRequest request = null;

            try
            {
                // Look for the authorization header, since we MUST support this method of authorization
                // https://tools.ietf.org/html/rfc6749#section-2.3.1
                // Decode and parse the client id/secret from the header
                string[] clientIdAndSecret = httpRequest.Headers.Authorization.Parameter.Base64Decode()
                                                        .Split(':');

                // Correct format will include 2 entries
                if (clientIdAndSecret.Length == 2)
                {
                    request = new TokenRequest
                              {
                                  Client_id = clientIdAndSecret[0], Client_secret = clientIdAndSecret[1], Grant_type = tokenRequest.Grant_type
                              };
                }
            }
            catch (FormatException e)
            {
                _logger.Warn("Error in parsing the token request from header", e);
            }

            return request;
        }

        private bool HasCredentialsInHeader(HttpRequestMessage httpRequest)
        {
            return !string.IsNullOrEmpty(httpRequest.Headers.Authorization.Parameter);
        }

        private bool IsIdAndSecretPresent(TokenRequest tokenRequest)
        {
            return !string.IsNullOrEmpty(tokenRequest.Client_secret) && !string.IsNullOrEmpty(tokenRequest.Client_id);
        }

        private bool RequestIsRequiredGrantType(TokenRequest tokenRequest)
        {
            return tokenRequest.Grant_type.EqualsIgnoreCase("client_credentials");
        }
    }
}
