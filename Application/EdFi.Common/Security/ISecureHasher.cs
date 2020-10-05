// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Common.Security
{
    public interface ISecureHasher
    {
        string Algorithm { get; }

        int AlgorithmHashCode { get; }

        PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, byte[] salt);

        PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes);
    }
}
