// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Common.Security
{
    public class SecureHasherProvider : ISecureHasherProvider
    {
        private readonly IList<ISecureHasher> _secureHashers;

        public SecureHasherProvider(IList<ISecureHasher> secureHashers)
        {
            _secureHashers = secureHashers;
        }

        public ISecureHasher GetHasher(int hashAlgorithm)
            => _secureHashers.SingleOrDefault(x => x.AlgorithmHashCode == hashAlgorithm) ??
               throw new NotImplementedException($"Secure hasher is not found for algorithm specified => {hashAlgorithm}");
    }
}
