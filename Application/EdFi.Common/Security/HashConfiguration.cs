// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;

namespace EdFi.Ods.Common.Security
{
    public class HashConfiguration
    {
        /// <summary>
        /// The hashing algorithm being used.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// The number of iterations used to calculate the hash.
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// The size of the salt in bits.
        /// </summary>
        public int SaltSize { get; set; }

        /// <summary>
        /// Converts the salt size from bits to bytes.
        /// </summary>
        /// <returns>The number of bytes</returns>
        public int GetSaltSizeInBytes() => SaltSize / 8;

        /// <summary>
        /// The hashcode that identifies the algorithm being used. The truncation of the hash to 128 bits is intentional.
        /// </summary>
        /// <returns></returns>
        public int GetAlgorithmHashCode() => HashHelper.GetSha256Hash(Algorithm).ToInt32();
    }
}
