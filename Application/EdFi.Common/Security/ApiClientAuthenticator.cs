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
        private readonly IApiClientIdentityProvider _apiClientIdentityProvider;
        private readonly IApiClientSecretProvider _apiClientSecretProvider;
        private readonly ISecretVerifier _secretVerifier;

        public ApiClientAuthenticator(
            IApiClientIdentityProvider apiClientIdentityProvider,
            IApiClientSecretProvider apiClientSecretProvider,
            ISecretVerifier secretVerifier)
        {
            _apiClientIdentityProvider = apiClientIdentityProvider;
            _apiClientSecretProvider = apiClientSecretProvider;
            _secretVerifier = secretVerifier;
        }

        public bool TryAuthenticate(string key, string secret, out ApiClientIdentity authenticatedApiClientIdentity)
        {
            authenticatedApiClientIdentity = null;
            ApiClientSecret apiClientSecret;

            try
            {
                apiClientSecret = _apiClientSecretProvider.GetSecret(key);
            }
            catch (ArgumentException)
            {
                return false;
            }

            if (!_secretVerifier.VerifySecret(key, secret, apiClientSecret))
            {
                return false;
            }

            authenticatedApiClientIdentity = _apiClientIdentityProvider.GetApiClientIdentity(key);
            return true;
        }

        public async Task<AuthenticationResult> TryAuthenticateAsync(string key, string secret)
        {
            ApiClientSecret apiClientSecret;
            ApiClientIdentity apiClientIdentity;

            try
            {
                apiClientIdentity = await _apiClientIdentityProvider.GetApiClientIdentityAsync(key);

                apiClientSecret = new ApiClientSecret
                {
                    Secret = apiClientIdentity.Secret,
                    IsHashed = apiClientIdentity.IsHashed
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
                ApiClientIdentity = apiClientIdentity
            };
        }

        public class AuthenticationResult
        {
            public bool IsAuthenticated { get; set; }

            public ApiClientIdentity ApiClientIdentity { get; set; }
        }
    }
}
