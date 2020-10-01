// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using EdFi.Common.Security;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Security
{
    [TestFixture]
    public class SecureHasAwareSecretVerifierTests
    {
        public class Using_a_valid_secret : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHash = new PackedHash
                {
                    Format = 1,
                    HashAlgorithm = 123,
                    HashBytes = new byte[]
                    {
                        111,
                        222,
                        200
                    },
                    Iterations = 321,
                    Salt = new byte[]
                    {
                        100,
                        200,
                        201
                    }
                };

                var packedHashConverter = Stub<IPackedHashConverter>();

                A.CallTo(() => packedHashConverter.GetPackedHash("MyHashedSecret"))
                    .Returns(packedHash);

                var secureHasher = Stub<ISecureHasher>();
                A.CallTo(() => secureHasher.AlgorithmHashCode).Returns(123);
                A.CallTo(() => secureHasher.ComputeHash(A<string>._, A<int>._, A<int>._, A<byte[]>._)).Returns(packedHash);

                _secretVerifier = new SecureHashAwareSecretVerifier(
                    packedHashConverter, new SecureHasherProvider(new List<ISecureHasher> {secureHasher}));
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MyHashedSecret",
                        IsHashed = true
                    });
            }

            [Test]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.True);
            }
        }

        public class Using_an_invalid_secret : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = Stub<IPackedHashConverter>();

                A.CallTo(() => packedHashConverter.GetPackedHash("MyHashedSecret"))
                    .Returns(
                        new PackedHash
                        {
                            Format = 1,
                            HashAlgorithm = 123,
                            HashBytes = new byte[]
                            {
                                100,
                                100,
                                100
                            },
                            Iterations = 321,
                            Salt = new byte[]
                            {
                                100,
                                200,
                                201
                            }
                        });

                var secureHasher = Stub<ISecureHasher>();

                A.CallTo(
                        () => secureHasher.ComputeHash(
                            "MyDifferentSecret",
                            123,
                            321,
                            new byte[]
                            {
                                100,
                                200,
                                201
                            }))
                    .Returns(
                        new PackedHash
                        {
                            Format = 1,
                            HashAlgorithm = 123,
                            HashBytes = new byte[]
                            {
                                200,
                                200,
                                200
                            },
                            Iterations = 321,
                            Salt = new byte[]
                            {
                                100,
                                200,
                                201
                            }
                        });

                _secretVerifier = new SecureHashAwareSecretVerifier(
                    packedHashConverter, new SecureHasherProvider( new List<ISecureHasher> {secureHasher}));
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MyDifferentSecret",
                    new ApiClientSecret
                    {
                        Secret = "MyHashedSecret",
                        IsHashed = true
                    });
            }

            [Test]
            public void Should_return_false()
            {
                _actualResponse.ShouldBeFalse();
            }

            [Test]
            public void Should_throw_not_implemented_exception()
            {
                ActualException.ShouldBeOfType<NotImplementedException>();
            }
        }

        public class When_handling_valid_non_hashed_secrets : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = Stub<IPackedHashConverter>();
                var secureHasher = Stub<ISecureHasher>();

                _secretVerifier = new SecureHashAwareSecretVerifier(
                    packedHashConverter, new SecureHasherProvider(new List<ISecureHasher> {secureHasher}));
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MySecret",
                        IsHashed = false
                    });
            }

            [Test]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.True);
            }
        }

        public class When_handling_invalid_non_hashed_secrets : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                var packedHashConverter = Stub<IPackedHashConverter>();
                var secureHasher = Stub<ISecureHasher>();

                _secretVerifier = new SecureHashAwareSecretVerifier(
                    packedHashConverter, new SecureHasherProvider(new List<ISecureHasher> {secureHasher}));
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MyDifferentSecret",
                        IsHashed = false
                    });
            }

            [Test]
            public void Should_return_false()
            {
                Assert.That(_actualResponse, Is.False);
            }
        }
    }
}
#endif
