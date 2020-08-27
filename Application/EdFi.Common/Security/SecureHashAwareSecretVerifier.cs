// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Runtime.CompilerServices;

namespace EdFi.Ods.Common.Security
{
    public class SecureHashAwareSecretVerifier : ISecretVerifier
    {
        private readonly IPackedHashConverter _packedHashConverter;
        private readonly ISecureHasher _secureHasher;

        public SecureHashAwareSecretVerifier(IPackedHashConverter packedHashConverter, ISecureHasher secureHasher)
        {
            _packedHashConverter = packedHashConverter;
            _secureHasher = secureHasher;
        }

        public bool VerifySecret(string key, string presentedSecret, ApiClientSecret actualSecret)
        {
            if (!actualSecret.IsHashed)
            {
                return presentedSecret == actualSecret.Secret;
            }

            var actualHash = _packedHashConverter.GetPackedHash(actualSecret.Secret);
            var presentedHash = _secureHasher.ComputeHash(presentedSecret, actualHash.HashAlgorithm, actualHash.Iterations, actualHash.Salt);

            return ByteArraysEqual(actualHash.HashBytes, presentedHash.HashBytes);
        }

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized
        // c.f. https://github.com/aspnet/Identity/blob/rel/2.0.0/src/Microsoft.Extensions.Identity.Core/PasswordHasher.cs#L70
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;

            for (var i = 0; i < a.Length; i++)
            {
                areSame &= a[i] == b[i];
            }

            return areSame;
        }
    }
}
