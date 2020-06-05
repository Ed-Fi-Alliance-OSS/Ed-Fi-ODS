// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    public class RequiredCollectionAttributeTests
    {
        private class RequiredCollectionTestObject
        {
            [RequiredCollection]
            public List<CollectionTestObject> TestCollection { get; set; }
        }

        private class CollectionTestObject { }

        public class When_validating_collection_with_one_item_for_RequiredCollection : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var testObject = new RequiredCollectionTestObject
                                 {
                                     TestCollection = new List<CollectionTestObject>()
                                 };

                testObject.TestCollection.Add(new CollectionTestObject());

                var validator = new DataAnnotationsEntityValidator();
                _actualResults = validator.ValidateObject(testObject);
            }

            [Assert]
            public void Should_not_have_any_validation_errors()
            {
                Assert.That(_actualResults, Is.Empty);
            }
        }

        public class When_validating_collection_with_more_than_one_item_for_RequiredCollection : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var testObject = new RequiredCollectionTestObject
                                 {
                                     TestCollection = new List<CollectionTestObject>()
                                 };

                testObject.TestCollection.Add(new CollectionTestObject());
                testObject.TestCollection.Add(new CollectionTestObject());
                testObject.TestCollection.Add(new CollectionTestObject());

                var validator = new DataAnnotationsEntityValidator();
                _actualResults = validator.ValidateObject(testObject);
            }

            [Assert]
            public void Should_not_have_any_validation_errors()
            {
                Assert.That(_actualResults, Is.Empty);
            }
        }

        public class When_validating_null_collection_for_RequiredCollection : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var testObject = new RequiredCollectionTestObject
                                 {
                                     TestCollection = null
                                 };

                var validator = new DataAnnotationsEntityValidator();
                _actualResults = validator.ValidateObject(testObject);
            }

            [Assert]
            public void Should_have_a_validation_error_regarding_a_required_collection()
            {
                Assert.That(_actualResults, Has.Count.EqualTo(1));

                var errorMessage = _actualResults.Single()
                                                 .ErrorMessage;

                Assert.That(errorMessage, Does.Contain("requires at least one object in the collection"));
            }
        }

        public class When_validating_empty_collection_for_RequiredCollection : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualResults;

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var testObject = new RequiredCollectionTestObject
                                 {
                                     TestCollection = new List<CollectionTestObject>()
                                 };

                var validator = new DataAnnotationsEntityValidator();
                _actualResults = validator.ValidateObject(testObject);
            }

            [Assert]
            public void Should_have_a_validation_error_regarding_a_required_collection()
            {
                Assert.That(_actualResults, Has.Count.EqualTo(1));

                var errorMessage = _actualResults.Single()
                                                 .ErrorMessage;

                Assert.That(errorMessage, Does.Contain("requires at least one object in the collection"));
            }
        }
    }
}
