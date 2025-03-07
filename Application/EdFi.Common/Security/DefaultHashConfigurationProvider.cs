﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Common.Security
{
    public class DefaultHashConfigurationProvider : IHashConfigurationProvider
    {
        private const string DefaultAlgorithm = Pbkdf2HmacSha256SecureHasher.ConfigurationAlgorithmName;
        private const int DefaultIterations = 600000;
        private const int DefaultSaltSize = 128;

        private readonly HashConfiguration _hashConfiguration;

        public DefaultHashConfigurationProvider()
        {
            _hashConfiguration = new HashConfiguration
            {
                Algorithm = DefaultAlgorithm,
                Iterations = DefaultIterations,
                SaltSize = DefaultSaltSize
            };
        }

        public HashConfiguration GetHashConfiguration()
        {
            return _hashConfiguration;
        }
    }
}
