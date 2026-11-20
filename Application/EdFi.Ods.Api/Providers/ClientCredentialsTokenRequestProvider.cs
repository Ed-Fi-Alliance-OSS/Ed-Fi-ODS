// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Globalization;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Providers
{
    public class ClientCredentialsTokenRequestProvider
        : ITokenRequestProvider
    {
        private readonly IApiClientAuthenticator _apiClientAuthenticator;
        private readonly IAccessTokenFactory _accessTokenFactory;
        private readonly IOptions<SecuritySettings> _securitySettings;

        public ClientCredentialsTokenRequestProvider(
            IApiClientAuthenticator apiClientAuthenticator,
            IAccessTokenFactory accessTokenFactory,
            IOptions<SecuritySettings> securitySettings)
        {
            _apiClientAuthenticator = apiClientAuthenticator;
            _accessTokenFactory = accessTokenFactory;
            _securitySettings = securitySettings;
        }

        public async Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest)
        {
            // A missing required parameter is an invalid request (https://tools.ietf.org/html/rfc6749#section-5.2)
            if (string.IsNullOrWhiteSpace(tokenRequest.Grant_type))
            {
                return new AuthenticationResponse
                {
                    TokenError = new TokenError(TokenErrorType.InvalidRequest, "The 'grant_type' parameter is required.")
                };
            }

            // Only handle the "client_credentials" grant type
            if (!RequestIsRequiredGrantType())
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.UnsupportedGrantType)};
            }

            // Verify client_id and client_secret are present (the token controller already rejects missing
            // credentials with invalid_client; this guard protects other callers of the provider)
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
                return new AuthenticationResponse
                {
                    TokenError = new TokenError(TokenErrorType.InvalidClient),
                    ClientAuthenticationFailed = true
                };
            }

            // Convert empty scope to null
            string tokenRequestScope = string.IsNullOrEmpty(tokenRequest.Scope)
                ? null
                : tokenRequest.Scope.Trim();

            // validate client is in scope
            if (tokenRequestScope != null)
            {
                // Digits only, so the scope stored with the token is exactly the education organization id validated here.
                // The range stays int because dbo.GetClientForToken converts the stored scope to int on both database engines.
                if (int.TryParse(tokenRequestScope, NumberStyles.None, CultureInfo.InvariantCulture, out int educationOrganizationScope))
                {
                    if (!authenticationResult.ApiClientDetails.EducationOrganizationIds
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
                else
                {
                    // Scope should be an EducationOrganizationId unless support for OneRoster JWTs is enabled
                    if (_securitySettings.Value.AccessTokenType != SecuritySettings.AccessTokenTypeJwt)
                    {
                        return new AuthenticationResponse
                        {
                            TokenError = new TokenError(
                                TokenErrorType.InvalidScope,
                                "The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client).")
                        };
                    }

                    if (!tokenRequestScope.StartsWith(SecuritySettings.OneRosterScopePrefix))
                    {
                        return new AuthenticationResponse
                        {
                            TokenError = new TokenError(
                                TokenErrorType.InvalidScope,
                                "The supplied 'scope' is not a valid OneRoster scope.")
                        };
                    }
                }
            }

            // create a new token
            var token = await _accessTokenFactory.CreateAccessTokenAsync(authenticationResult.ApiClientDetails, tokenRequestScope);

            if (token == null)
            {
                return new AuthenticationResponse {TokenError = new TokenError(TokenErrorType.InvalidClient)};
            }

            var tokenResponse = new TokenResponse();
            tokenResponse.SetToken(token.Id, (int) token.Duration.TotalSeconds, token.Scope);

            return new AuthenticationResponse {TokenResponse = tokenResponse, ApiClientDetails = authenticationResult.ApiClientDetails };

            bool RequestIsRequiredGrantType() => tokenRequest.Grant_type.EqualsIgnoreCase("client_credentials");

            bool HasIdAndSecret()
                => !string.IsNullOrEmpty(tokenRequest.Client_secret) && !string.IsNullOrEmpty(tokenRequest.Client_id);
        }
    }
}