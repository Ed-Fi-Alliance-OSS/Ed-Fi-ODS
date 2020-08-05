// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Utils;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils
{
    public class RandomUtilTests
    {
        [TestFixture]
        public class When_generating_a_random_string
        {
            [Test]
            public void Should_generate_a_string_of_the_correct_length()
            {
                for (int i = 1; i < 32; i++)
                {
                    RandomUtil.GenerateRandomBase64String(i)
                              .Length.ShouldBe(i);
                }
            }

            [Test]
            public void Should_not_ever_include_the_equal_sign_since_it_isnt_random()
            {
                for (int i = 1; i < 32; i++)
                {
                    RandomUtil.GenerateRandomBase64String(i)
                              .ShouldNotContain("=");
                }
            }
        }
    }
}
