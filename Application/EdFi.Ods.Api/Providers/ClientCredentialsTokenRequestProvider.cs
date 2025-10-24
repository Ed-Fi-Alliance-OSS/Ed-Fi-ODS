// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Security.Authentication;

namespace EdFi.Ods.Api.Providers
{
    public class ClientCredentialsTokenRequestProvider : TokenRequestProviderBase
    {
        private readonly IAccessTokenFactory _accessTokenFactory;

        public ClientCredentialsTokenRequestProvider(
            IApiClientAuthenticator apiClientAuthenticator,
            IAccessTokenFactory accessTokenFactory)
            : base(apiClientAuthenticator)
        {
            _accessTokenFactory = accessTokenFactory;
        }

        public override async Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest)
        {
            var authentication = await ValidateAndAuthenticateRequest(tokenRequest);

            if (!authentication.IsSuccessful)
            {
                return new AuthenticationResponse(){ TokenError = authentication.Error };
            }

            var clientId = authentication.Result.ApiClientDetails.ApiClientId;

            // create a new token
            var token = await _accessTokenFactory.CreateAccessTokenAsync(clientId, tokenRequest.GetCleanedScope());

            if (token == null)
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidClient)};
            }

            var tokenResponse = new TokenResponse();
            tokenResponse.SetToken(token.Id, (int) token.Duration.TotalSeconds, token.Scope);

            return new AuthenticationResponse {TokenResponse = tokenResponse};
        }

        protected override bool HasValidScope(TokenRequest request, ApiClientAuthenticator.AuthenticationResult result, out TokenError error)
        {
            var tokenRequestScope = request.GetCleanedScope();
            if (result != null)
            {
                if (!int.TryParse(tokenRequestScope, out int educationOrganizationScope))
                {
                    error = new TokenError(
                        TokenErrorType.InvalidScope,
                        "The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client).");

                    return false;
                }

                if (!result.ApiClientDetails.EducationOrganizationIds.Contains(educationOrganizationScope))
                {
                    error = new TokenError(
                        TokenErrorType.InvalidScope,
                        "The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'.");

                        return false;
                }
            }

            error = null;
            return true;
        }
    }
}
