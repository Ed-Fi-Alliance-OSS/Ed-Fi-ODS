// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Admin.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Extensions
{
    public class StringExtensionsTests
    {
        [TestFixture]
        public class When_email_address_is_valid
        {
            [Test]
            public void Should_indicate_address_is_valid()
            {
                var address = "foo.bar@example.com";

                address.IsValidEmailAddress()
                       .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_email_address_is_invalid
        {
            [Test]
            public void Should_indicate_address_is_invalid()
            {
                "missingdomain".IsValidEmailAddress()
                               .ShouldBeFalse();

                "missingdomain@".IsValidEmailAddress()
                                .ShouldBeFalse();

                "@example.com".IsValidEmailAddress()
                              .ShouldBeFalse();
            }
        }
    }
}
