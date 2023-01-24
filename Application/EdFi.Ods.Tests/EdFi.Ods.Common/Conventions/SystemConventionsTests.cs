// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Conventions
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SystemConventionsTests
    {
        public class When_getting_extension_bag_name_parts_from_an_extension_bag_name_without_underscore_separator
            : TestFixtureBase
        {
            protected override void Act()
            {
                var actualBagNameParts = SystemConventions.GetExtensionBagNameParts("NoUnderscoreSeparator");
            }

            [Assert]
            public void Should_throw_an_exception_indicating_the_bag_name_format_is_invalid()
            {
                Assert.That(ActualException, Is.Not.Null);
                ActualException.MessageShouldContain("Supplied extension bag name 'NoUnderscoreSeparator' did not match the expected format.");
            }
        }

        public class When_getting_extension_bag_name_parts_from_an_extension_bag_name_with_too_many_underscore_separator
            : TestFixtureBase
        {
            protected override void Act()
            {
                var actualBagNameParts = SystemConventions.GetExtensionBagNameParts("Too_Many_Underscores");
            }

            [Assert]
            public void Should_throw_an_exception_indicating_the_bag_name_format_is_invalid()
            {
                Assert.That(ActualException, Is.Not.Null);
                ActualException.MessageShouldContain("Supplied extension bag name 'Too_Many_Underscores' did not match the expected format.");
            }
        }

        public class When_getting_extension_bag_name_parts_from_a_valid_extension_bag_name
            : TestFixtureBase
        {
            private SystemConventions.ExtensionBagNameParts _actualBagNameParts;
            private readonly string _suppliedExtensionBagName = "SchemaName_CollectionName";

            protected override void Act()
            {
                _actualBagNameParts = SystemConventions.GetExtensionBagNameParts(_suppliedExtensionBagName);
            }

            [Assert]
            public void Should_parse_the_schema_name_from_the_first_segment()
            {
                Assert.That(
                    _actualBagNameParts.SchemaProperCaseName,
                    Is.EqualTo(_suppliedExtensionBagName.Split('_')[0]));
            }

            [Assert]
            public void Should_parse_the_schema_name_from_the_last_segment()
            {
                Assert.That(
                    _actualBagNameParts.MemberName,
                    Is.EqualTo(_suppliedExtensionBagName.Split('_')[1]));
            }
        }
    }
}