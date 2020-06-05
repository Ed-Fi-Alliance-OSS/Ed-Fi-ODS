// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Validation
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NoWhitespaceAttributeTests
    {
        private class TestEntityWithPrimaryKeyValues : IHasPrimaryKeyValues
        {
            [NoWhitespace]
            public string PrimaryKeyProperty1 { get; set; }

            [NoWhitespace]
            public string PrimaryKeyProperty2 { get; set; }

            public OrderedDictionary GetPrimaryKeyValues()
            {
                return new OrderedDictionary
                       {
                           {
                               "PrimaryKeyProperty1", PrimaryKeyProperty1
                           },
                           {
                               "PrimaryKeyProperty2", PrimaryKeyProperty2
                           }
                       };
            }
        }

        private class TestEntityWithOutPrimaryKeyValues
        {
            [NoWhitespace]
            public string Property1 { get; set; }
        }

        public class When_validating_an_entity_decorated_with_the_NoWhitespaceAttribute_and_a_primary_key_value_contains_trailing_whitespace
            : TestFixtureBase
        {
            private readonly List<ValidationResult> _validationResults = new List<ValidationResult>();
            private TestEntityWithPrimaryKeyValues _entity;

            protected override void Arrange()
            {
                _entity =
                    new TestEntityWithPrimaryKeyValues
                    {
                        PrimaryKeyProperty1 =
                            "StringWithTrailingWhitespace ",
                        PrimaryKeyProperty2 = "ValidString"
                    };
            }

            protected override void Act()
            {
                Validator.TryValidateObject(_entity, new ValidationContext(_entity, null, null), _validationResults, true);
            }

            [Assert]
            public void Should_return_validation_exception_indicating_primary_key_values_cannot_leading_or_trailing_whitespace()
            {
                AssertHelper.All(
                    () => Assert.That(_validationResults.Count, Is.EqualTo(1)),
                    () => Assert.That(
                        _validationResults.First()
                                          .ErrorMessage,
                        Is.EqualTo(
                            "PrimaryKeyProperty1 property is part of the primary key and therefore its value cannot contain leading or trailing whitespace.")));
            }
        }

        public class When_validating_an_entity_decorated_with_the_NoWhitespaceAttribute_and_a_primary_key_value_contains_leading_whitespace
            : TestFixtureBase
        {
            private readonly List<ValidationResult> _validationResults = new List<ValidationResult>();
            private TestEntityWithPrimaryKeyValues _entity;

            protected override void Arrange()
            {
                _entity =
                    new TestEntityWithPrimaryKeyValues
                    {
                        PrimaryKeyProperty1 =
                            " StringWithTrailingWhitespace",
                        PrimaryKeyProperty2 = "ValidString"
                    };
            }

            protected override void Act()
            {
                Validator.TryValidateObject(_entity, new ValidationContext(_entity, null, null), _validationResults, true);
            }

            [Assert]
            public void Should_return_validation_exception_indicating_primary_key_values_cannot_leading_or_trailing_whitespace()
            {
                AssertHelper.All(
                    () => Assert.That(_validationResults.Count, Is.EqualTo(1)),
                    () => Assert.That(
                        _validationResults.First()
                                          .ErrorMessage,
                        Is.EqualTo(
                            "PrimaryKeyProperty1 property is part of the primary key and therefore its value cannot contain leading or trailing whitespace.")));
            }
        }

        public class When_validating_a_type_decorated_with_the_NoWhitespaceAttribute_and_it_is_not_a_derived_class_of_IHasPrimaryKeys
            : TestFixtureBase
        {
            private readonly List<ValidationResult> _validationResults = new List<ValidationResult>();
            private TestEntityWithOutPrimaryKeyValues _entity;

            protected override void Arrange()
            {
                _entity =
                    new TestEntityWithOutPrimaryKeyValues
                    {
                        Property1 = "StringValue"
                    };
            }

            protected override void Act()
            {
                Validator.TryValidateObject(_entity, new ValidationContext(_entity, null, null), _validationResults, true);
            }

            [Assert]
            public void Should_return_0_validation_exceptions()
            {
                Assert.That(_validationResults.Count, Is.EqualTo(0));
            }
        }
    }
}
