// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils.Enumerations
{
    public class EnumerationTests
    {
        [TestFixture]
        public class When_enumeration_has_values : TestBase
        {
            private TestEnumeration[] _results;

            private class TestEnumeration : LegacyEnumeration<TestEnumeration, string>
            {
                public static readonly TestEnumeration One = new TestEnumeration("1", "One");
                public static readonly TestEnumeration Two = new TestEnumeration("2", "Two");

                private static TestEnumeration Problematic = new TestEnumeration("3", "I Cause Problems");

                public static string Detractor = "foo";

                public TestEnumeration(string id, string name)
                {
                    MyId = id;
                    Name = name;
                }

                public string MyId { get; }

                public override string Id
                {
                    get { return MyId; }
                }

                public string Name { get; }
            }

            [OneTimeSetUp]
            public void Setup()
            {
                _results = TestEnumeration.GetValues();
            }

            [Test]
            public void Should_retrieve_all_values()
            {
                _results.Length.ShouldBe(2);
                _results.ShouldContain(TestEnumeration.One);
                _results.ShouldContain(TestEnumeration.Two);
            }

            [Test]
            public void Should_retrieve_value_by_id()
            {
                TestEnumeration.GetById("1")
                               .ShouldBe(TestEnumeration.One);
            }

            [Test]
            public void Should_return_null_when_searching_by_nonexistent_id()
            {
                TestEnumeration.GetById("foo")
                               .ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_enumeration_has_value_with_null_id : TestBase
        {
            private TestEnumeration[] _results;

            private class TestEnumeration : LegacyEnumeration<TestEnumeration, string>
            {
                public static readonly TestEnumeration Null = new TestEnumeration(null, "Null");
                public static readonly TestEnumeration One = new TestEnumeration("1", "One");
                public static readonly TestEnumeration Two = new TestEnumeration("2", "Two");

                private static TestEnumeration Problematic = new TestEnumeration("3", "I Cause Problems");

                public static string Detractor = "foo";

                public TestEnumeration(string id, string name)
                {
                    MyId = id;
                    Name = name;
                }

                public string MyId { get; }

                public override string Id
                {
                    get { return MyId; }
                }

                public string Name { get; }
            }

            [OneTimeSetUp]
            public void Setup()
            {
                _results = TestEnumeration.GetValues();
            }

            [Test]
            public void Should_retrieve_all_values()
            {
                _results.Length.ShouldBe(3);
                _results.ShouldContain(TestEnumeration.Null);
                _results.ShouldContain(TestEnumeration.One);
                _results.ShouldContain(TestEnumeration.Two);
            }

            [Test]
            public void Should_retrieve_value_by_id()
            {
                TestEnumeration.GetById("1")
                               .ShouldBe(TestEnumeration.One);
            }

            [Test]
            public void Should_retrive_value_with_null_id()
            {
                TestEnumeration.GetById(null)
                               .ShouldBe(TestEnumeration.Null);
            }

            [Test]
            public void Should_return_null_when_searching_by_nonexistent_id()
            {
                TestEnumeration.GetById("foo")
                               .ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_ids_are_equal : TestBase
        {
            private class EqualsEnumeration : LegacyEnumeration<EqualsEnumeration, int>
            {
                public static readonly EqualsEnumeration One = new EqualsEnumeration(1, "One");
                public static readonly EqualsEnumeration Two = new EqualsEnumeration(1, "Two");

                public EqualsEnumeration(int id, string name)
                {
                    MyId = id;
                    Name = name;
                }

                public override int Id
                {
                    get { return MyId; }
                }

                public int MyId { get; }

                public string Name { get; }
            }

            [Test]
            public void Should_be_equal()
            {
                EqualsEnumeration.One.ShouldBe(EqualsEnumeration.Two);
            }

            [Test]
            public void Should_throw_exception_when_searching_by_duplicated_id()
            {
                try
                {
                    EqualsEnumeration.GetById(1);
                }
                catch
                {
                    Assert.Pass("Nothing to see here.... These are not the tests you're looking for.");
                }

                Assert.Fail("Should have thrown an exception");
            }
        }

        [TestFixture]
        public class When_ids_are_not_equal : TestBase
        {
            private class EqualsEnumeration : LegacyEnumeration<EqualsEnumeration, int>
            {
                public static readonly EqualsEnumeration One = new EqualsEnumeration(1, "One");
                public static readonly EqualsEnumeration Two = new EqualsEnumeration(2, "Two");

                public EqualsEnumeration(int id, string name)
                {
                    MyId = id;
                    Name = name;
                }

                public override int Id
                {
                    get { return MyId; }
                }

                public int MyId { get; }

                public string Name { get; }
            }

            [Test]
            public void Should_not_be_equal()
            {
                EqualsEnumeration.One.ShouldNotBe(EqualsEnumeration.Two);
            }
        }
    }
}
