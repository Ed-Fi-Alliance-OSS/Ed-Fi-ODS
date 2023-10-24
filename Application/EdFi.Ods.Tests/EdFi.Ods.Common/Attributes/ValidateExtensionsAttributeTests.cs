﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Validation
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ValidateExtensionsAttributeTests
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
                [ValidateExtensions]
                public List<object> Objects { get; set; }
            }
        }

        public class TestObject
        {
            [ValidateExtensions]
            public IDictionary ValidatedDictionary { get; set; }
        }

        public class TestObjectExtension
        {
            [Required]
            public int? Value { get; set; }
        }

        public class When_validating_an_object_that_is_an_IDictionary_containing_an_entry_with_null_value
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
                                { "Schema_Collection", null }
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

        public class When_validating_an_object_with_a_valid_entity_extension_object
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
                                {"Schema_Collection", new List<TestObjectExtension> {new TestObjectExtension {Value = 1}}}
                            }
                        });
            }

            [Assert]
            public void Should_indicate_that_validation_was_successful()
            {
                Assert.That(_actualResults, Has.Count.EqualTo(0));
            }
        }
    }
}