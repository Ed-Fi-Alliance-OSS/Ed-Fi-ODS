// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using NUnit.Framework;

namespace EdFi.Ods.Common.UnitTests.Security
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PackedHashConverterTests
    {
        public class When_converting_packed_hash : TestFixtureBase
        {
            private const string _expectedBase64String = "ARgAAAD///9/BAAAAAUIBAIBAg==";
            private string _actualBase64String;
            private PackedHash _packedHash;

            protected override void Arrange()
            {
                _packedHash = new PackedHash
                {
                    Format = 1,
                    HashAlgorithm = 24,
                    HashBytes = new byte[]
                    {
                        1,
                        2
                    },
                    Iterations = int.MaxValue,
                    Salt = new byte[]
                    {
                        5,
                        8,
                        4,
                        2
                    }
                };
            }

            protected override void Act()
            {
                var packedHashConverter = new PackedHashConverter();
                _actualBase64String = packedHashConverter.GetBase64String(_packedHash);
            }

            [Test]
            public virtual void Should_be_able_to_convert_packed_hash()
            {
                Assert.That(_actualBase64String, Is.EqualTo(_expectedBase64String));
            }
        }

        public class When_converting_string : TestFixtureBase
        {
            private const string _base64String = "ARgAAAD///9/BAAAAAUIBAIBAg==";
            private PackedHash _actualPackedHash;
            private PackedHash _expectedPackedHash;

            protected override void Arrange()
            {
                _expectedPackedHash = new PackedHash
                {
                    Format = 1,
                    HashAlgorithm = 24,
                    HashBytes = new byte[]
                    {
                        1,
                        2
                    },
                    Iterations = int.MaxValue,
                    Salt = new byte[]
                    {
                        5,
                        8,
                        4,
                        2
                    }
                };
            }

            protected override void Act()

            {
                var packedHashConverter = new PackedHashConverter();
                _actualPackedHash = packedHashConverter.GetPackedHash(_base64String);
            }

            [Test]
            public virtual void Should_be_able_to_convert_base_64_encoded_string()
            {
                Assert.That(_actualPackedHash.Format, Is.EqualTo(_expectedPackedHash.Format));
                Assert.That(_actualPackedHash.HashAlgorithm, Is.EqualTo(_expectedPackedHash.HashAlgorithm));
                Assert.That(_actualPackedHash.Iterations, Is.EqualTo(_expectedPackedHash.Iterations));
                Assert.That(_actualPackedHash.HashBytes.SequenceEqual(_expectedPackedHash.HashBytes), Is.True);
                Assert.That(_actualPackedHash.Salt.SequenceEqual(_expectedPackedHash.Salt), Is.True);
            }
        }

        public class When_converting_very_short_string : TestFixtureBase
        {
            private const string _base64String = "ARgAAAD///9/BA==";

            protected override void Act() => new PackedHashConverter().GetPackedHash(_base64String);

            [Test]
            public virtual void Should_throw_a_format_exception()
            {
                Assert.That(ActualException, Is.TypeOf<FormatException>());
            }
        }

        public class When_converting_short_string : TestFixtureBase
        {
            private const string _base64String = "ARgAAAD///9/BAAAAAUIBAI==";

            protected override void Act() => new PackedHashConverter().GetPackedHash(_base64String);

            [Test]
            public virtual void Should_throw_a_format_exception()
            {
                Assert.That(ActualException, Is.TypeOf<FormatException>());
            }
        }
    }
}
