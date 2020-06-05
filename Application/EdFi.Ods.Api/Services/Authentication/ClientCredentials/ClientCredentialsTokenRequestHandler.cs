// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Api.Common.Models.Tokens;

namespace EdFi.Ods.Api.Services.Authentication.ClientCredentials
{
    public class ClientCredentialsTokenRequestHandler
        : ITokenRequestHandler
    {
        private readonly IApiClientAuthenticator _apiClientAuthenticator;
        private readonly IClientAppRepo _clientAppRepo;

        public ClientCredentialsTokenRequestHandler(IClientAppRepo clientAppRepo, IApiClientAuthenticator apiClientAuthenticator)
        {
            _clientAppRepo = clientAppRepo;
            _apiClientAuthenticator = apiClientAuthenticator;
        }

        public bool Handle(
            HttpRequestMessage httpRequest,
            TokenRequest tokenRequest,
            out IHttpActionResult actionResult)
        {
            var resp = new TokenResponse();

            ApiClientIdentity apiClientIdentity;

            if (!_apiClientAuthenticator.TryAuthenticate(tokenRequest.Client_id, tokenRequest.Client_secret, out apiClientIdentity))
            {
                actionResult = new AuthenticationError(httpRequest, new TokenError(TokenErrorType.InvalidClient));
                return true;
            }

            var client = _clientAppRepo.GetClient(apiClientIdentity.Key);

            // Convert empty scope to null
            string tokenRequestScope = string.IsNullOrEmpty(tokenRequest.Scope)
                ? null
                : tokenRequest.Scope.Trim();

            // Validate the requested scope
            if (tokenRequestScope != null)
            {
                actionResult = ValidateAndAuthorizeTokenRequestScope();

                if (actionResult != null)
                {
                    return true;
                }
            }

            var token = _clientAppRepo.AddClientAccessToken(
                client.ApiClientId,
                tokenRequestScope);

            resp.SetToken(token.Id, (int) token.Duration.TotalSeconds, token.Scope);

            actionResult = new AuthenticationSuccess(httpRequest, resp);
            return true;

            // -----------------------------------------------
            //              Local functions
            // -----------------------------------------------
            IHttpActionResult ValidateAndAuthorizeTokenRequestScope()
            {
                // Verify that the scope is a single number (EdOrg)
                if (!int.TryParse(tokenRequestScope, out int educationOrganizationScope))
                {
                    return new AuthenticationError(httpRequest,
                        new TokenError(
                            TokenErrorType.InvalidScope,
                            "The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client)."));
                }

                // Verify that the scope (EdOrgId) is valid for the client
                if (!client.ApplicationEducationOrganizations
                    .Select(x => x.EducationOrganizationId)
                    .Contains(educationOrganizationScope))
                {
                    return new AuthenticationError(httpRequest,
                        new TokenError(
                            TokenErrorType.InvalidScope,
                            "The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'."));
                }

                return null;
            }
        }
    }
}
