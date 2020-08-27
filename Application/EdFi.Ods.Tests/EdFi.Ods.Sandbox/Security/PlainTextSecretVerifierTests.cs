// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PlainTextSecretVerifierTests
    {
        public class When_handling_valid_secret
            : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                _secretVerifier = new PlainTextSecretVerifier();
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "MySecret"
                    });
            }

            [Assert]
            public void Should_return_true()
            {
                Assert.That(_actualResponse, Is.True);
            }
        }

        public class When_handling_invalid_secret
            : TestFixtureBase
        {
            private bool _actualResponse;
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                _secretVerifier = new PlainTextSecretVerifier();
            }

            protected override void Act()
            {
                _actualResponse = _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "NotMySecret"
                    });
            }

            [Assert]
            public void Should_return_false()
            {
                Assert.That(_actualResponse, Is.False);
            }
        }

        public class When_handling_hashed_secret
            : TestFixtureBase
        {
            private ISecretVerifier _secretVerifier;

            protected override void Arrange()
            {
                _secretVerifier = new PlainTextSecretVerifier();
            }

            protected override void Act()
            {
                _secretVerifier.VerifySecret(
                    "MyKey",
                    "MySecret",
                    new ApiClientSecret
                    {
                        Secret = "NotMySecret", IsHashed = true
                    });
            }

            [Assert]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }
    }
}
