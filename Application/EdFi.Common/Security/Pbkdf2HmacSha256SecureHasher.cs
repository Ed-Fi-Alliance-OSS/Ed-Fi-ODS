// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Cryptography;
using EdFi.Common.Extensions;

namespace EdFi.Common.Security
{
    public class Pbkdf2HmacSha256SecureHasher : ISecureHasher
    {
        private readonly Lazy<int> _algorithmHashCode;

        public const string ConfigurationAlgorithmName = "PBKDF2-HMACSHA256";

        public Pbkdf2HmacSha256SecureHasher()
        {
            _algorithmHashCode = new Lazy<int>(() => HashHelper.GetSha256Hash(Algorithm).ToInt32());
        }

        public string Algorithm
        {
            get => ConfigurationAlgorithmName;
        }

        public int AlgorithmHashCode
        {
            get => _algorithmHashCode.Value;
        }

        public PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, byte[] salt)
        {
            byte[] bytes = Rfc2898DeriveBytes.Pbkdf2(secret, salt, iterations, HashAlgorithmName.SHA256, 32);

            return new PackedHash
            {
                Format = 0,
                HashAlgorithm = hashAlgorithm,
                HashBytes = bytes,
                Iterations = iterations,
                Salt = salt
            };
        }

        public PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(saltSizeInBytes);
            byte[] bytes = Rfc2898DeriveBytes.Pbkdf2(secret, salt, iterations, HashAlgorithmName.SHA256, 32);

            return new PackedHash
            {
                Format = 0,
                HashAlgorithm = hashAlgorithm,
                HashBytes = bytes,
                Iterations = iterations,
                Salt = salt
            };
        }
    }
}
