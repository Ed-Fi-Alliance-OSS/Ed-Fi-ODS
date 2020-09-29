// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Security
{
    public class SecurePackedHashProvider : ISecurePackedHashProvider
    {
        private readonly IPackedHashConverter _packedHashConverter;
        private readonly IList<ISecureHasher> _secureHashers;

        public SecurePackedHashProvider(IPackedHashConverter packedHashConverter, IList<ISecureHasher> secureHashers)
        {
            _packedHashConverter = packedHashConverter;
            _secureHashers = secureHashers;
        }

        public string ComputePackedHashString(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes)
        {
            var hasher = _secureHashers.SingleOrDefault(x => x.GetAlgorithmHashCode == hashAlgorithm);

            if (hasher == null)
            {
                throw new NotImplementedException(
                    $"Secure hasher is not found for algorithm specified => {hashAlgorithm}");
            }

            var packedHash = hasher.ComputeHash(secret, hashAlgorithm, iterations, saltSizeInBytes);
            var base64String = _packedHashConverter.GetBase64String(packedHash);
            return base64String;
        }
    }
}
