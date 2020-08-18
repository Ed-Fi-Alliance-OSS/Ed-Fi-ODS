// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EnumerationTests
    {
        protected static TestObject ObjectOne = new TestObject
        {
            Name = "one",
            Value = 1
        };
        protected static TestObject ObjectTwo = new TestObject
        {
            Name = "two",
            Value = 2
        };

        protected class TestEnumeration : Enumeration<TestEnumeration>
        {
            public static TestEnumeration One = new TestEnumeration(1, "One");
            public static TestEnumeration Two = new TestEnumeration(2, "Two");

            public TestEnumeration(int value, string displayName)
                : base(value, displayName) { }
        }

        protected class TestObjectEnumeration : Enumeration<TestObjectEnumeration, TestObject>
        {
            public static TestObjectEnumeration One = new TestObjectEnumeration(ObjectOne, "One");
            public static TestObjectEnumeration Two = new TestObjectEnumeration(ObjectTwo, "Two");

            public TestObjectEnumeration(TestObject value, string displayName)
                : base(value, displayName) { }
        }

        protected class TestObject : IComparable
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public int CompareTo(object obj) => obj.GetHashCode();
        }

        public class When_using_the_enumeration_class : TestFixtureBase
        {

            [Test]
            public void Should_get_an_object_by_value()
            {
                var result = TestEnumeration.TryParse(1, out TestEnumeration enumeration);

               AssertHelper.All(() => result.ShouldBeTrue(),
                   () => enumeration.ShouldNotBeNull(),
                   () => enumeration.ShouldBe(TestEnumeration.One));
            }

            [Test]
            public void Should_get_an_object_by_predicate()
            {
                var result = TestEnumeration.TryParse(x=> x.DisplayName.Equals("Two"), out TestEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestEnumeration.Two));
            }

            [Test]
            public void Should_get_an_object_by_int32()
            {
                var result = TestEnumeration.TryFromInt32(2, out TestEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestEnumeration.Two));
            }

            [Test]
            public void Should_get_an_object_by_display_name()
            {
                var result = TestEnumeration.TryParse("One", out TestEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestEnumeration.One));
            }

            [Test]
            public void Should_return_null_for_missing_enumeration()
            {
                var result = TestEnumeration.TryParse("Three", out TestEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeFalse(),
                    () => enumeration.ShouldBeNull());
            }
        }

        public class When_using_the_enumeration_class_with_an_object_as_the_value : TestFixtureBase
        {
            [Test]
            public void Should_get_an_object_by_value()
            {
                var result = TestObjectEnumeration.TryParse( ObjectOne, out TestObjectEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestObjectEnumeration.One));
            }

            [Test]
            public void Should_get_an_object_by_predicate()
            {
                var result = TestObjectEnumeration.TryParse(x=> x.Value == ObjectTwo,  out TestObjectEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestObjectEnumeration.Two));
            }

            [Test]
            public void Should_get_an_object_by_display_name()
            {
                var result = TestObjectEnumeration.TryParse("One", out TestObjectEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeTrue(),
                    () => enumeration.ShouldNotBeNull(),
                    () => enumeration.ShouldBe(TestObjectEnumeration.One));
            }

            [Test]
            public void Should_return_null_for_missing_enumeration()
            {
                var result = TestObjectEnumeration.TryParse("Three", out TestObjectEnumeration enumeration);

                AssertHelper.All(() => result.ShouldBeFalse(),
                    ()=> enumeration.ShouldBeNull());
            }
        }
    }
}
