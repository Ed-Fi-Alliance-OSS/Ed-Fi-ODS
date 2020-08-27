// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Diagnostics.CodeAnalysis;
using System.Text;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Helpers;
using EdFi.TestFixture;
using NUnit.Framework;

namespace EdFi.Ods.Common.UnitTests.Security
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Pbkdf2HmacSha1SecureHasherTests
    {
        protected const string Secret = "MyTestSecret";
        protected const string Salt = "MyTestSalt";

        public class When_computing_a_valid_hash : TestFixtureBase
        {
            private PackedHash _actualResult;
            private string _expectedBytes;
            private SecureHashRequest _request;
            private Pbkdf2HmacSha1SecureHasher _secureHasher;

            protected override void Arrange()
            {
                _secureHasher = new Pbkdf2HmacSha1SecureHasher(null);

                _request = new SecureHashRequest
                {
                    Secret = Secret,
                    HashAlgorithm = HashHelper.GetSha256Hash(Pbkdf2HmacSha1SecureHasher.ConfigurationAlgorithmName).ToInt32(),
                    Iterations = 10000,
                    Salt = Encoding.UTF8.GetBytes(Salt)
                };

                _expectedBytes = "9B0FEB3C38F75E8C65BD6516C162F20095F8C3FB6F2006241C17C4D194CF96BD";
            }

            protected override void Act()
            {
                _actualResult = _secureHasher.ProcessRequest(_request);
            }

            [Test]
            public virtual void Should_be_able_to_compute_hash()
            {
                Assert.That(_actualResult.HashBytes.ToHexString(), Is.EqualTo(_expectedBytes));
            }

            [Test]
            public virtual void Should_return_non_null_result()
            {
                Assert.That(_actualResult, Is.Not.Null);
            }
        }

        public class When_computing_an_invalid_hash : TestFixtureBase
        {
            private PackedHash _actualResult;
            private SecureHashRequest _request;
            private Pbkdf2HmacSha1SecureHasher _secureHasher;

            protected override void Arrange()
            {
                _secureHasher = new Pbkdf2HmacSha1SecureHasher(null);

                _request = new SecureHashRequest { HashAlgorithm = 1234 };
            }

            protected override void Act()
            {
                _actualResult = _secureHasher.ProcessRequest(_request);
            }

            [Test]
            public virtual void Should_not_compute_hash_with_invalid_hash_algorithm()
            {
                Assert.That(_actualResult, Is.Null);
            }
        }
    }
}