// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Extensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_trimming_a_suffix : TestFixtureBase
    {
        [Test]
        public void Should_trim_a_suffix_only_if_the_case_matches()
        {
            "aBcDeFgH".TrimSuffix("fGh")
                      .ShouldBe("aBcDeFgH");

            "aBcDeFgH".TrimSuffix("FgH")
                      .ShouldBe("aBcDe");
        }

        [Test]
        public void Should_only_trim_a_suffix_it_appears_at_the_end_of_the_string()
        {
            "aBcDeFgH".TrimSuffix("eFg")
                      .ShouldBe("aBcDeFgH");
        }

        [Test]
        public void Should_trim_a_suffix_off_the_end_even_if_it_also_appears_in_the_middle_of_the_string()
        {
            "aBcD_gH_eFgH".TrimSuffix("gH")
                          .ShouldBe("aBcD_gH_eF");
        }
    }

    public class When_converting_string_to_boolean : TestFixtureBase
    {
        [Test]
        public void Should_convert_a_null_to_false()
        {
            (null as string).ToBoolean()
                .ShouldBeFalse();
        }

        [Test]
        public void Should_convert_an_empty_string_to_false()
        {
            (string.Empty).ToBoolean()
                .ShouldBeFalse();
        }

        [Test]
        public void Should_convert_a_non_boolean_value_string_to_false()
        {
            ("NotABoolean").ToBoolean()
                .ShouldBeFalse();
        }
        
        [Test]
        public void Should_convert_a_boolean_true_value_string_using_mixed_casing_to_true()
        {
            ("tRuE").ToBoolean()
                .ShouldBeTrue();
        }

        [Test]
        public void Should_convert_a_boolean_false_value_string_using_mixed_casing_to_false()
        {
            ("fAlSe").ToBoolean()
                .ShouldBeFalse();
        }
    }
}
