// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.NetCore.Models.ClientCredentials;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Sandbox.Repositories;
using Microsoft.Extensions.Hosting.Internal;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public class ClientCredentialsTokenRequestProvider
        : ITokenRequestProvider
    {
        private readonly IApiClientAuthenticator _apiClientAuthenticator;
        private readonly IClientAppRepo _clientAppRepo;

        public ClientCredentialsTokenRequestProvider(IClientAppRepo clientAppRepo, IApiClientAuthenticator apiClientAuthenticator)
        {
            _clientAppRepo = clientAppRepo;
            _apiClientAuthenticator = apiClientAuthenticator;
        }

        public async Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest)
        {
            // Only handle the "client_credentials" grant type
            if (!RequestIsRequiredGrantType())
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.UnsupportedGrantType)};
            }

            // Verify client_id and client_secret are present
            if (!HasIdAndSecret())
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidClient)};
            }

            // authenticate the client
            var authenticationResult = await _apiClientAuthenticator.TryAuthenticateAsync(
                tokenRequest.Client_id,
                tokenRequest.Client_secret);

            if (!authenticationResult.IsAuthenticated)
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidClient)};
            }

            // get client information
            var client = await _clientAppRepo.GetClientAsync(authenticationResult.ApiClientIdentity.Key);

            // Convert empty scope to null
            string tokenRequestScope = string.IsNullOrEmpty(tokenRequest.Scope)
                ? null
                : tokenRequest.Scope.Trim();

            // validate client is in scope
            if (tokenRequestScope != null)
            {
                if (!int.TryParse(tokenRequestScope, out int educationOrganizationScope))
                {
                    return new AuthenticationResponse
                    {
                        TokenError = new TokenError(
                            TokenErrorType.InvalidScope,
                            "The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client).")
                    };
                }

                if (!client.ApplicationEducationOrganizations
                    .Select(x => x.EducationOrganizationId)
                    .Contains(educationOrganizationScope))
                {
                    return new AuthenticationResponse
                    {
                        TokenError = new TokenError(
                            TokenErrorType.InvalidScope,
                            "The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'.")
                    };
                }
            }

            // create a new token
            var token = await _clientAppRepo.AddClientAccessTokenAsync(client.ApiClientId, tokenRequestScope);

            var tokenResponse = new TokenResponse();
            tokenResponse.SetToken(token.Id, (int) token.Duration.TotalSeconds, token.Scope);

            return new AuthenticationResponse {TokenResponse = tokenResponse};

            bool RequestIsRequiredGrantType() => tokenRequest.Grant_type.EqualsIgnoreCase("client_credentials");

            bool HasIdAndSecret()
                => !string.IsNullOrEmpty(tokenRequest.Client_secret) && !string.IsNullOrEmpty(tokenRequest.Client_id);
        }
    }
}
