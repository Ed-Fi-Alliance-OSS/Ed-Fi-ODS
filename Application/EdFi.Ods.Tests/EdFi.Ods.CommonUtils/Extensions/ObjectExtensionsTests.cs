// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Utils.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils.Extensions
{
    public class ObjectExtensionsTests
    {
        [TestFixture]
        public class When_type_is_object
        {
            [Test]
            public void Should_be_default_for_null()
            {
                ObjectExtensions.IsDefault(null, typeof(object))
                                .ShouldBeTrue();
            }

            [Test]
            public void Should_not_be_default_for_integers()
            {
                1.IsDefault(typeof(object))
                 .ShouldBeFalse();

                0.IsDefault(typeof(object))
                 .ShouldBeFalse();
            }

            [Test]
            public void Should_not_be_default_for_nonnull()
            {
                new object().IsDefault(typeof(object))
                            .ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_type_is_int
        {
            [Test]
            public void Should_be_default_for_zero()
            {
                0.IsDefault(typeof(int))
                 .ShouldBeTrue();
            }

            [Test]
            public void Should_not_be_default_for_object_value()
            {
                new object().IsDefault(typeof(int))
                            .ShouldBeFalse();
            }

            [Test]
            public void Should_not_be_default_for_one()
            {
                1.IsDefault(typeof(int))
                 .ShouldBeFalse();
            }
        }
    }
}
