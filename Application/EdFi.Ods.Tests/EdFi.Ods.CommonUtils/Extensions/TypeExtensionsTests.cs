// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Utils.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils.Extensions
{
    public class TypeExtensionsTests
    {
        [TestFixture]
        public class When_type_can_be_cast_to_another_type
        {
            [Test]
            public void Should_not_report_that_the_type_cannot_be_cast_to_the_other_type()
            {
                typeof(List<string>).CannotBeCastTo<IEnumerable<string>>()
                                    .ShouldBeFalse();
            }

            [Test]
            public void Should_report_that_it_can_be_cast()
            {
                typeof(List<string>).CanBeCastTo<IEnumerable<string>>()
                                    .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_type_cannot_be_cast_to_another_type
        {
            [Test]
            public void Should_not_report_that_the_type_can_be_cast_to_the_other_type()
            {
                typeof(List<string>).CanBeCastTo<IEnumerable<int>>()
                                    .ShouldBeFalse();
            }

            [Test]
            public void Should_report_that_it_cannot_be_cast()
            {
                typeof(List<string>).CannotBeCastTo<IEnumerable<int>>()
                                    .ShouldBeTrue();
            }
        }
    }
}
