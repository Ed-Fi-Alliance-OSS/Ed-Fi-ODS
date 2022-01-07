// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Cryptography;
using System.Text;

namespace EdFi.Common.Security
{
    public static class HashHelper
    {
        /// <summary>
        /// Generates a deterministic hash of a string using SHA256.
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static byte[] GetSha256Hash(string stringToHash) =>  SHA256.Create()
           .ComputeHash(Encoding.UTF8.GetBytes(stringToHash), 0, Encoding.UTF8.GetByteCount(stringToHash));
    }
}
