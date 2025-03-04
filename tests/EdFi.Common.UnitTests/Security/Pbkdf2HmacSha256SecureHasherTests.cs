// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Security
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Pbkdf2HmacSha256SecureHasherTests
    {
        private const string Secret = "MyTestSecret";
        private const string Salt = "MyTestSalt";

        public class When_computing_a_valid_hash : TestFixtureBase
        {
            private PackedHash _actualResult;
            private string _expectedBytes;
            private Pbkdf2HmacSha256SecureHasher _secureHasher;
            private int _hashAlgorithm;
            private byte[] _salt;

            protected override void Arrange()
            {
                _secureHasher = new Pbkdf2HmacSha256SecureHasher();

                _hashAlgorithm = _secureHasher.AlgorithmHashCode;

                _salt = Encoding.UTF8.GetBytes(Salt);

                _expectedBytes = "B98C827EE187EC98775E2A995B87DA1C988445E81825C4196F3D9CDC10D9EDCF";
            }

            protected override void Act()
            {
                _actualResult = _secureHasher.ComputeHash(Secret, _hashAlgorithm, 600000, _salt);
            }

            [Test]
            public void Should_be_able_to_compute_hash()
            {
                _actualResult.HashBytes.ToHexString().ShouldBe(_expectedBytes);
            }

            [Test]
            public void Should_return_non_null_result()
            {
                _actualResult.ShouldNotBeNull();
            }
        }

        public class When_computing_an_invalid_hash : TestFixtureBase
        {
            private PackedHash _actualResult;
            private Pbkdf2HmacSha256SecureHasher _secureHasher;

            protected override void Arrange()
            {
                _secureHasher = new Pbkdf2HmacSha256SecureHasher();
            }

            protected override void Act()
            {
                _actualResult = _secureHasher.ComputeHash(null, 1234, 0, null);
            }

            [Test]
            public void Should_not_compute_hash_with_invalid_hash_algorithm()
            {
                _actualResult.ShouldBeNull();
            }

            [Test]
            public void Should_throw_argument_null_exception()
            {
                ActualException.ShouldBeOfType<ArgumentNullException>();
            }
        }
    }
}
