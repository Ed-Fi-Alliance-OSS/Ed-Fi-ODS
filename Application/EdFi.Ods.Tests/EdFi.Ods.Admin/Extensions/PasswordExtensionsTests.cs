// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Admin.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Extensions
{
    public class PasswordExtensionsTests
    {
        [TestFixture]
        public class When_checking_password_strength
        {
            [Test]
            public void Should_approve_a_strong_password()
            {
                "StrongPassword1!".IsStrongPassword()
                                  .ShouldBeTrue();
            }

            [Test]
            public void Should_reject_password_without_a_digit()
            {
                "SomePassword!".IsStrongPassword()
                               .ShouldBeFalse();
            }

            [Test]
            public void Should_reject_password_without_an_upper_case_letter()
            {
                "nouppercaseletters@1".IsStrongPassword()
                                      .ShouldBeFalse();
            }

            [Test]
            public void Should_reject_passwords_shorter_than_8_characters()
            {
                "Aa!4567".IsStrongPassword()
                         .ShouldBeFalse();
            }

            [Test]
            public void Should_reject_passwords_with_disallowed_characters()
            {
                "1!WeDontAllow_".IsStrongPassword()
                                .ShouldBeFalse();

                "1!WeDontAllow-".IsStrongPassword()
                                .ShouldBeFalse();

                "1!WeDontAllow[".IsStrongPassword()
                                .ShouldBeFalse();

                "1!WeDontAllow]".IsStrongPassword()
                                .ShouldBeFalse();
            }

            [Test]
            public void Should_reject_passwords_without_a_lower_case_letter()
            {
                "SCREAMINGBLAHBLAH@1".IsStrongPassword()
                                     .ShouldBeFalse();
            }

            [Test]
            public void Should_reject_passwords_without_a_symbol()
            {
                "FiveCharacters1".IsStrongPassword()
                                 .ShouldBeFalse();
            }
        }
    }
}
