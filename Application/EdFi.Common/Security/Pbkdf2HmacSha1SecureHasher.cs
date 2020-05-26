// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Security.Cryptography;
using EdFi.Ods.Common.ChainOfResponsibility;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;

namespace EdFi.Ods.Common.Security
{
    public class Pbkdf2HmacSha1SecureHasher : ChainOfResponsibilityBase<ISecureHasher, SecureHashRequest, PackedHash>,
                                              ISecureHasher
    {
        public const string ConfigurationAlgorithmName = "PBKDF2-HMACSHA1";

        public Pbkdf2HmacSha1SecureHasher(ISecureHasher next)
            : base(next) { }

        public string Algorithm => ConfigurationAlgorithmName;

        public PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, byte[] salt)
        {
            byte[] bytes;

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(secret, salt, iterations))
            {
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }

            return new PackedHash
                   {
                       Format = 0, HashAlgorithm = hashAlgorithm, HashBytes = bytes, Iterations = iterations, Salt = salt
                   };
        }

        public PackedHash ComputeHash(string secret, int hashAlgorithm, int iterations, int saltSizeInBytes)
        {
            byte[] bytes;
            byte[] salt;

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(secret, saltSizeInBytes, iterations))
            {
                salt = rfc2898DeriveBytes.Salt;
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }

            return new PackedHash
                   {
                       Format = 0, HashAlgorithm = hashAlgorithm, HashBytes = bytes, Iterations = iterations, Salt = salt
                   };
        }

        protected override bool CanHandleRequest(SecureHashRequest request)
        {
            // to allow for auto upgrading of an existing hash routine that used the string version of GetHashCode() 
            // we need to keep it in this check. Note, the string version of GetHashCode() is not deterministic when outside of the app domain.
            return request.HashAlgorithm == HashHelper.GetSha256Hash(Algorithm).ToInt32()
                   || request.HashAlgorithm == Algorithm.GetHashCode();
        }

        protected override PackedHash HandleRequest(SecureHashRequest request)
        {
            return request.Salt != null
                ? ComputeHash(request.Secret, request.HashAlgorithm, request.Iterations, request.Salt)
                : ComputeHash(request.Secret, request.HashAlgorithm, request.Iterations, request.SaltSizeInBytes);
        }
    }
}
