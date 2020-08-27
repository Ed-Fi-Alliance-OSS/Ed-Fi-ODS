// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Security;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    public class When_calling_SecureHashAwareSecretVerifier_VerifySecret
    {
        public class Using_a_valid_secret
            : LegacyTestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHash = new PackedHash
                                 {
                                     Format = 1, HashAlgorithm = 123, HashBytes = new byte[]
                                                                                  {
                                                                                      111, 222, 200
                                                                                  },
                                     Iterations = 321, Salt = new byte[]
                                                              {
                                                                  100, 200, 201
                                                              }
                                 };

                var packedHashConverter = mocks.Stub<IPackedHashConverter>();

                packedHashConverter.Stub(phc => phc.GetPackedHash("MyHashedSecret"))
                                   .Return(packedHash);

                var secureHasher = mocks.Stub<ISecureHasher>();

                secureHasher.Stub(
                                 sh => sh.ComputeHash(
                                     "MySecret",
                                     123,
                                     321,
                                     new byte[]
                                     {
                                         100, 200, 201
                                     }))
                            .Return(packedHash);

                _secretVerifier = new SecureHashAwareSecretVerifier(packedHashConverter, secureHasher);
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MyHashedSecret", IsHashed = true
                    });
            }

            [Assert]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.True);
            }
        }

        public class Usning_a_invalid_secret
            : LegacyTestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = mocks.Stub<IPackedHashConverter>();

                packedHashConverter.Stub(phc => phc.GetPackedHash("MyHashedSecret"))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 1, HashAlgorithm = 123, HashBytes = new byte[]
                                                                                         {
                                                                                             100, 100, 100
                                                                                         },
                                            Iterations = 321, Salt = new byte[]
                                                                     {
                                                                         100, 200, 201
                                                                     }
                                        });

                var secureHasher = mocks.Stub<ISecureHasher>();

                secureHasher.Stub(
                                 sh => sh.ComputeHash(
                                     "MyDifferentSecret",
                                     123,
                                     321,
                                     new byte[]
                                     {
                                         100, 200, 201
                                     }))
                            .Return(
                                 new PackedHash
                                 {
                                     Format = 1, HashAlgorithm = 123, HashBytes = new byte[]
                                                                                  {
                                                                                      200, 200, 200
                                                                                  },
                                     Iterations = 321, Salt = new byte[]
                                                              {
                                                                  100, 200, 201
                                                              }
                                 });

                _secretVerifier = new SecureHashAwareSecretVerifier(packedHashConverter, secureHasher);
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MyDifferentSecret",
                    new ApiClientSecret
                    {
                        Secret = "MyHashedSecret", IsHashed = true
                    });
            }

            [Assert]
            public void Should_return_false()
            {
                Assert.That(_actualResponse, Is.False);
            }
        }

        public class When_handling_valid_non_hashed_secrets
            : LegacyTestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = mocks.Stub<IPackedHashConverter>();
                var secureHasher = mocks.Stub<ISecureHasher>();

                _secretVerifier = new SecureHashAwareSecretVerifier(packedHashConverter, secureHasher);
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MySecret", IsHashed = false
                    });
            }

            [Assert]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.True);
            }
        }

        public class When_handling_invalid_non_hashed_secrets
            : LegacyTestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = mocks.Stub<IPackedHashConverter>();
                var secureHasher = mocks.Stub<ISecureHasher>();

                _secretVerifier = new SecureHashAwareSecretVerifier(packedHashConverter, secureHasher);
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MyDifferentSecret", IsHashed = false
                    });
            }

            [Assert]
            public void Should_return_false()
            {
                Assert.That(_actualResponse, Is.False);
            }
        }
    }
}
