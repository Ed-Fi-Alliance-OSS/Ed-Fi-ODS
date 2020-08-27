// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq.Expressions;
using EdFi.Ods.Common.Utils.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils.Extensions
{
    public class ExpressionExtensionsTests
    {
        public class ExampleClass
        {
            public string SomeProperty { get; set; }

            public Guid SomeUnary { get; set; }

            public string SomeMethod()
            {
                return string.Empty;
            }
        }

        [TestFixture]
        public class When_getting_the_member_name_of_a_property
        {
            [Test]
            public void Should_get_the_member_name()
            {
                Expression<Func<ExampleClass, object>> expression = x => x.SomeProperty;

                expression.MemberName()
                          .ShouldBe("SomeProperty");
            }
        }

        [TestFixture]
        public class When_getting_the_member_name_of_a_method
        {
            [Test]
            public void Should_get_the_member_name()
            {
                Expression<Func<ExampleClass, object>> expression = x => x.SomeMethod();

                expression.MemberName()
                          .ShouldBe("SomeMethod");
            }
        }

        [TestFixture]
        public class When_getting_the_member_name_of_a_unary_expression
        {
            [Test]
            public void Should_get_the_member_name()
            {
                Expression<Func<ExampleClass, object>> expression = x => x.SomeUnary;

                expression.MemberName()
                          .ShouldBe("SomeUnary");
            }
        }
    }
}
