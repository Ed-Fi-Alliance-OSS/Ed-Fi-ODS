// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Validation
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ValidateAggregateExtensionsAttributeTests
    {
        public class When_validating_an_object_that_is_not_an_IDictionary
            : TestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            protected override void Act()
            {
                _actualResults = (new DataAnnotationsEntityValidator().ValidateObject(new InvalidAttributeUseTestObject()));
            }

            [Assert]
            public void Should_indicate_that_validation_was_successful()
            {
                Assert.That(_actualResults, Has.Count.EqualTo(0));
            }

            public class InvalidAttributeUseTestObject
            {
                [ValidateAggregateExtensions]
                public List<object> Objects { get; set; }
            }
        }

        public class TestObject
        {
            [ValidateAggregateExtensions]
            public IDictionary ValidatedDictionary { get; set; }
        }

        public class TestCollectionItem
        {
            [Required]
            public int? Value { get; set; }
        }

        public class When_validating_an_object_that_is_an_IDictionary_containing_objects_that_do_not_implement_IList
            : TestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            protected override void Act()
            {
                _actualResults = new DataAnnotationsEntityValidator()
                    .ValidateObject(
                        new TestObject
                        {
                            ValidatedDictionary = new Hashtable
                            {
                                { "Schema_Collection", new object() }
                            }
                        });
            }

            [Assert]
            public void Should_throw_an_exception_indicating_the_underlying_extension_object_could_not_be_unwrapped()
            {
                Assert.That(ActualException, Is.Not.Null);

                ActualException.MessageShouldContain("Unable to unwrap the extension object.");
            }
        }

        public class When_validating_an_object_with_a_valid_aggregate_extensions_collection 
            : TestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            protected override void Act()
            {
                _actualResults = new DataAnnotationsEntityValidator()
                    .ValidateObject(
                        new TestObject
                        {
                            ValidatedDictionary = new Hashtable
                            {
                                {"Schema_Collection", new List<TestCollectionItem> {new TestCollectionItem {Value = 1}}}
                            }
                        });
            }

            [Assert]
            public void Should_indicate_that_validation_was_successful()
            {
                Assert.That(_actualResults, Has.Count.EqualTo(0));
            }
        }

        public class When_validating_an_object_with_an_invalid_aggregate_extensions_collection 
            : TestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            protected override void Act()
            {
                _actualResults = new DataAnnotationsEntityValidator()
                    .ValidateObject(
                        new TestObject
                        {
                            ValidatedDictionary = new Hashtable
                            {
                                {"TestSchema_Items", new List<TestCollectionItem> {new TestCollectionItem() }}
                            }
                        });
            }

            [Assert]
            public void Should_indicate_that_validation_was_unsuccessful()
            {
                Assert.That(_actualResults, Has.Count.GreaterThan(0));
            }

            [Assert]
            public void Should_indicate_that_the_ValidatedDictionary_property_was_invalid()
            {
                Assert.That(_actualResults.Single().ErrorMessage, Is.EqualTo("Validation of 'ValidatedDictionary' failed."));
            }

            [Assert]
            public void Should_indicate_that_the_Items_from_TestSchema_was_invalid()
            {
                var compositeResults = (_actualResults.Single() as CompositeValidationResult).Results;

                Assert.That(compositeResults.Single().ErrorMessage, Is.EqualTo("Validation of 'Items (TestSchema)' failed."));
            }
        }
    }
}
