// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Common.Security
{
    public class SecurePackedHashProvider : ISecurePackedHashProvider
    {
        private readonly IPackedHashConverter _packedHashConverter;
        private readonly ISecureHasherProvider _secureHasherProvider;

        public SecurePackedHashProvider(IPackedHashConverter packedHashConverter, ISecureHasherProvider secureHasherProvider)
        {
            _packedHashConverter = packedHashConverter;
            _secureHasherProvider = secureHasherProvider;
        }

        public string ComputePackedHashString(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes)
        {
            var hasher = _secureHasherProvider.GetHasher(hashAlgorithm);
            var packedHash = hasher.ComputeHash(secret, hashAlgorithm, iterations, saltSizeInBytes);
            var base64String = _packedHashConverter.GetBase64String(packedHash);

            return base64String;
        }
    }
}
