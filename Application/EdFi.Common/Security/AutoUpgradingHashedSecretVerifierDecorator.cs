// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using log4net;

namespace EdFi.Ods.Common.Security
{
    public class AutoUpgradingHashedSecretVerifierDecorator : ISecretVerifier
    {
        private readonly IApiClientSecretProvider _apiClientSecretProvider;
        private readonly HashConfiguration _hashConfiguration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AutoUpgradingHashedSecretVerifierDecorator));
        private readonly ISecretVerifier _next;
        private readonly IPackedHashConverter _packedHashConverter;
        private readonly ISecurePackedHashProvider _securePackedHashProvider;

        public AutoUpgradingHashedSecretVerifierDecorator(
            IApiClientSecretProvider apiClientSecretProvider,
            ISecretVerifier next,
            IPackedHashConverter packedHashConverter,
            ISecurePackedHashProvider securePackedHashProvider,
            IHashConfigurationProvider hashConfigurationProvider)
        {
            _apiClientSecretProvider = apiClientSecretProvider;
            _next = next;
            _packedHashConverter = packedHashConverter;
            _securePackedHashProvider = securePackedHashProvider;
            _hashConfiguration = hashConfigurationProvider.GetHashConfiguration();
        }

        public bool VerifySecret(string key, string presentedSecret, ApiClientSecret actualSecret)
        {
            if (!_next.VerifySecret(key, presentedSecret, actualSecret))
            {
                _logger.Warn(
                    $"Unable to decode the secret for vendor \"{key}\" using the secret verifier \"{_next.GetType().Name}\". You may need to reset the secret for this vendor.");

                return false;
            }

            var hashAlgorithm = _hashConfiguration.GetAlgorithmHashCode();

            if (actualSecret.IsHashed)
            {
                var packedHash = _packedHashConverter.GetPackedHash(actualSecret.Secret);

                if (packedHash.HashAlgorithm == hashAlgorithm
                    && packedHash.Iterations == _hashConfiguration.Iterations
                    && packedHash.Salt.Length == _hashConfiguration.GetSaltSizeInBytes())
                {
                    return true;
                }
            }

            actualSecret.Secret = _securePackedHashProvider.ComputePackedHashString(
                presentedSecret,
                hashAlgorithm,
                _hashConfiguration.Iterations,
                _hashConfiguration.GetSaltSizeInBytes());

            actualSecret.IsHashed = true;

            _apiClientSecretProvider.SetSecret(key, actualSecret);

            return true;
        }
    }
}
