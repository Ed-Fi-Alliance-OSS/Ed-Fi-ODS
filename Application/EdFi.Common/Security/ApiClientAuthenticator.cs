// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;

namespace EdFi.Common.Security
{
    public class ApiClientAuthenticator : IApiClientAuthenticator
    {
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;
        private readonly ISecretVerifier _secretVerifier;

        public ApiClientAuthenticator(
            IApiClientDetailsProvider apiClientDetailsProvider,
            ISecretVerifier secretVerifier)
        {
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _secretVerifier = secretVerifier;
        }

        public async Task<AuthenticationResult> TryAuthenticateAsync(string key, string secret)
        {
            ApiClientSecret apiClientSecret;
            ApiClientDetails apiClientDetails;

            try
            {
                apiClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForKeyAsync(key);

                if(apiClientDetails == null)
                {
                    new AuthenticationResult { IsAuthenticated = false };
                }

                apiClientSecret = new ApiClientSecret
                {
                    Secret = apiClientDetails.Secret,
                    IsHashed = apiClientDetails.SecretIsHashed
                };

            }
            catch (ArgumentException)
            {
                return new AuthenticationResult {IsAuthenticated = false};
            }

            if (!_secretVerifier.VerifySecret(key, secret, apiClientSecret))
            {
                return new AuthenticationResult {IsAuthenticated = false};
            }

            return new AuthenticationResult
            {
                IsAuthenticated = true,
                ApiClientDetails = apiClientDetails
            };
        }

        public class AuthenticationResult
        {
            public bool IsAuthenticated { get; set; }

            public ApiClientDetails ApiClientDetails { get; set; }
        }
    }
}
