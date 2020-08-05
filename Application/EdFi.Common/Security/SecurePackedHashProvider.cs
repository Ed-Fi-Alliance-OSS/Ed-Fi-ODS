// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security
{
    public class SecurePackedHashProvider : ISecurePackedHashProvider
    {
        private readonly IPackedHashConverter _packedHashConverter;
        private readonly ISecureHasher _secureHasher;

        public SecurePackedHashProvider(IPackedHashConverter packedHashConverter, ISecureHasher secureHasher)
        {
            _packedHashConverter = packedHashConverter;
            _secureHasher = secureHasher;
        }

        public string ComputePackedHashString(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes)
        {
            var packedHash = _secureHasher.ComputeHash(secret, hashAlgorithm, iterations, saltSizeInBytes);
            var base64String = _packedHashConverter.GetBase64String(packedHash);
            return base64String;
        }
    }
}
