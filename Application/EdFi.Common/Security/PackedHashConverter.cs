// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Linq;

namespace EdFi.Ods.Common.Security
{
    /// <summary>
    /// Format (1 byte)
    /// HashAlgorithm(4 bytes)
    /// Iterations(4 bytes)
    /// SaltSize(4 bytes)
    /// Salt("Salt Size" bytes)
    /// HashBytes(variable, determined by algorithm and/or settings)
    /// { 0x00, Format, HashAlgorithm, Iterations, SaltSize, Salt, HashBytes }
    /// </summary>
    public class PackedHashConverter : IPackedHashConverter
    {
        public string GetBase64String(PackedHash packedHash)
        {
            var bytes = new byte[1 + 4 + 4 + 4 + packedHash.Salt.Length + packedHash.HashBytes.Length];
            bytes[0] = packedHash.Format;

            BitConverter.GetBytes(packedHash.HashAlgorithm)
                        .CopyTo(bytes, 1);

            BitConverter.GetBytes(packedHash.Iterations)
                        .CopyTo(bytes, 5);

            BitConverter.GetBytes(packedHash.Salt.Length)
                        .CopyTo(bytes, 9);

            packedHash.Salt.CopyTo(bytes, 13);
            packedHash.HashBytes.CopyTo(bytes, 13 + packedHash.Salt.Length);
            return Convert.ToBase64String(bytes);
        }

        public PackedHash GetPackedHash(string base64EncodedPackedHashValue)
        {
            var bytes = Convert.FromBase64String(base64EncodedPackedHashValue);

            if (bytes.Length < 13)
            {
                throw new FormatException($"Invalid value of {nameof(base64EncodedPackedHashValue)}:{base64EncodedPackedHashValue}");
            }

            var saltLength = BitConverter.ToInt32(bytes, 9);

            if (bytes.Length < 13 + saltLength + 1)
            {
                throw new FormatException($"Invalid value of {nameof(base64EncodedPackedHashValue)}:{base64EncodedPackedHashValue}");
            }

            return new PackedHash
                   {
                       Format = bytes[0], HashAlgorithm = BitConverter.ToInt32(bytes, 1), Iterations = BitConverter.ToInt32(bytes, 5), Salt = bytes
                                                                                                                                             .Skip(13)
                                                                                                                                             .Take(
                                                                                                                                                  saltLength)
                                                                                                                                             .ToArray(),
                       HashBytes = bytes.Skip(13 + saltLength)
                                        .Take(bytes.Length)
                                        .ToArray()
                   };
        }
    }
}
