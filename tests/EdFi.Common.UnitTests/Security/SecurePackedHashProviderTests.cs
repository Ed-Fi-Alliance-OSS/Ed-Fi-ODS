// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.Common.UnitTests.Security
{
    [TestFixture]
    public class SecurePackedHashProviderTests
    {
        public class When_handling_valid_secret : TestFixtureBase
        {
            private string _actualResponse;
            private ISecurePackedHashProvider _securePackedHashProvider;

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

                var secureHasher = A.Fake<ISecureHasher>();

                A.CallTo(() => secureHasher.ComputeHash("MySecret", 123, 321, 3))
                    .Returns(packedHash);

                var packedHashProvider = A.Fake<ISecureHasherProvider>();

                A.CallTo(() => packedHashProvider.GetHasher(123)).Returns(secureHasher);

                var packedHashConverter = A.Fake<IPackedHashConverter>();

                A.CallTo(() => packedHashConverter.GetBase64String(packedHash))
                    .Returns("MyHashedSecret");

                _securePackedHashProvider = new SecurePackedHashProvider(packedHashConverter, packedHashProvider);
            }

            protected override void Act()
            {
                _actualResponse = _securePackedHashProvider.ComputePackedHashString("MySecret", 123, 321, 3);
            }

            [Test]
            public void Should_return_not_null()
            {
                Assert.That(_actualResponse, Is.Not.Null);
            }

            [Test]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.EqualTo("MyHashedSecret"));
            }
        }
    }
}