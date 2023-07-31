// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Common.Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Extensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Feature_Inserting_items_into_enumerable_collections_based_on_existing_items
    {
        public class When_inserting_an_item_before_the_second_item_of_a_two_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object object2 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1, object2
                           };

                _actualResult = list.InsertBefore(object2, insertObject);
            }

            [Test]
            public void Should_insert_the_item_between_the_existing_items()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        object1, insertObject, object2
                    });
            }
        }

        public class When_inserting_an_item_after_the_first_item_of_a_two_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object object2 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1, object2
                           };

                _actualResult = list.InsertAfter(object1, insertObject);
            }

            [Test]
            public void Should_insert_the_item_between_the_existing_items()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        object1, insertObject, object2
                    });
            }
        }

        public class When_inserting_an_item_after_the_second_item_of_a_two_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object object2 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1, object2
                           };

                _actualResult = list.InsertAfter(object2, insertObject);
            }

            [Test]
            public void Should_insert_the_item_as_the_last_item_in_the_list()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        object1, object2, insertObject
                    });
            }
        }

        public class When_inserting_an_item_before_the_first_item_of_a_two_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object object2 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1, object2
                           };

                _actualResult = list.InsertBefore(object1, insertObject);
            }

            [Test]
            public void Should_insert_the_item_as_the_first_item_in_the_list()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        insertObject, object1, object2
                    });
            }
        }

        public class When_inserting_an_item_before_the_only_item_in_a_single_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1
                           };

                _actualResult = list.InsertBefore(object1, insertObject);
            }

            [Test]
            public void Should_insert_the_item_as_the_first_item_in_the_list()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        insertObject, object1
                    });
            }
        }

        public class When_inserting_an_item_after_the_only_item_in_a_single_item_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object insertObject = new object();

            // Actual values
            private IEnumerable<object> _actualResult;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1
                           };

                _actualResult = list.InsertAfter(object1, insertObject);
            }

            [Test]
            public void Should_insert_the_item_as_the_last_item_in_the_list()
            {
                _actualResult.ShouldBe(
                    new[]
                    {
                        object1, insertObject
                    });
            }
        }

        public class When_inserting_an_item_before_an_item_that_does_not_exist_in_list
        {
            // Supplied values
            private readonly object object1 = new object();
            private readonly object object2 = new object();
            private readonly object nonMemberObject = new object();
            private readonly object insertObject = new object();

            // Actual values
            private Exception ActualException;

            [SetUp]
            protected void Act()
            {
                // Execute code under test
                var list = new List<object>
                           {
                               object1, object2
                           };

                try
                {
                    list.InsertBefore(nonMemberObject, insertObject);
                }
                catch (Exception e)
                {
                    ActualException = e;
                }
            }

            [Test]
            public void Should_throw_an_exception()
            {
                ActualException.ShouldBeOfType<ArgumentException>();
                ActualException.Message.ShouldContainWithoutWhitespace("Item could not be inserted because the insertion point item was not found in the collection.");
            }
        }
    }

    [TestFixture]
    public class Feature_Enumerable_can_be_checked_for_all_values_being_equal
    {
        public class When_checking_an_empty_enumerable : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int[] values = Array.Empty<int>();

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_all_equal()
            {
                _actualResult.ShouldBeTrue();
            }
        }

        public class When_checking_an_enumerable_of_value_types_containing_a_single_value : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int[] values = { 1 };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_all_equal()
            {
                _actualResult.ShouldBeTrue();
            }
        }

        public class When_checking_an_enumerable_of_value_types_containing_the_same_values : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int[] values = { 1, 1 };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_all_equal()
            {
                _actualResult.ShouldBeTrue();
            }
        }

        public class When_checking_an_enumerable_of_value_types_containing_different_values : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int[] values = { 1, 2 };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_not_all_equal()
            {
                _actualResult.ShouldBeFalse();
            }
        }

        public class When_checking_an_enumerable_of_nullable_values_containing_some_null_values : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int?[] values = { null, 2, 2, null };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_not_all_equal()
            {
                _actualResult.ShouldBeFalse();
            }
        }

        public class When_checking_a_null_enumerable : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                int[] values = null;

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_throw_a_ArgumentNullException()
            {
                ActualException.ShouldBeOfType<ArgumentNullException>();
            }
        }
        
        public class When_checking_an_enumerable_of_strings_containing_same_casing : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                string[] values = { "One", "One", "One" };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_all_equal()
            {
                _actualResult.ShouldBeTrue();
            }
        }
        
        public class When_checking_an_enumerable_of_strings_with_default_comparer_containing_different_casing : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                string[] values = { "One", "ONE", "ONE" };

                _actualResult = values.AllEqual();
            }

            [Test]
            public void Should_indicate_values_are_not_all_equal()
            {
                _actualResult.ShouldBeFalse();
            }
        }
        
        public class When_checking_an_enumerable_of_strings_with_explicit_case_insensitive_comparer_containing_different_casing : TestFixtureBase
        {
            private bool _actualResult;

            protected override void Act()
            {
                string[] values = { "One", "oNe", "OnE" };

                _actualResult = values.AllEqual(StringComparer.OrdinalIgnoreCase);
            }

            [Test]
            public void Should_indicate_values_are_all_equal()
            {
                _actualResult.ShouldBeTrue();
            }
        }
    }
}