// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;

namespace EdFi.Ods.Api.Providers
{
    public class ClientCredentialsTokenRequestProvider
        : ITokenRequestProvider
    {
        private readonly IApiClientAuthenticator _apiClientAuthenticator;
        private readonly IAccessTokenClientRepo _accessTokenClientRepo;

        public ClientCredentialsTokenRequestProvider(
            IApiClientAuthenticator apiClientAuthenticator,
            IAccessTokenClientRepo accessTokenClientRepo)
        {
            _apiClientAuthenticator = apiClientAuthenticator;
            _accessTokenClientRepo = accessTokenClientRepo;
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
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidRequest)};
            }

            // authenticate the client and get client information
            var authenticationResult = await _apiClientAuthenticator.TryAuthenticateAsync(
                tokenRequest.Client_id,
                tokenRequest.Client_secret);

            if (!authenticationResult.IsAuthenticated)
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidClient)};
            }

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

                if (!authenticationResult.ApiClientIdentity.EducationOrganizationIds
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
            var token = await _accessTokenClientRepo.AddClientAccessTokenAsync(authenticationResult.ApiClientIdentity.ApiClientId, tokenRequestScope);

            var tokenResponse = new TokenResponse();
            tokenResponse.SetToken(token.Id, (int) token.Duration.TotalSeconds, token.Scope);

            return new AuthenticationResponse {TokenResponse = tokenResponse};

            bool RequestIsRequiredGrantType() => tokenRequest.Grant_type.EqualsIgnoreCase("client_credentials");

            bool HasIdAndSecret()
                => !string.IsNullOrEmpty(tokenRequest.Client_secret) && !string.IsNullOrEmpty(tokenRequest.Client_id);
        }
    }
}