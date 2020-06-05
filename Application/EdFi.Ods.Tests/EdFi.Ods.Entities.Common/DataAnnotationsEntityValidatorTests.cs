// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    [TestFixture]
    public class DataAnnotationsEntityValidatorTests
    {
        private readonly DataAnnotationsEntityValidator validator = new DataAnnotationsEntityValidator();
        private ICollection<ValidationResult> validationResults;

        private class DataAnnotatedProperty
        {
            [Required]
            public string RequiredProperty { get; set; }
        }

        private class DataAnnotatedClass
        {
            [ValidateObject]
            public DataAnnotatedProperty Property { get; set; }
        }

        private class DataAnnotatedCollectionClass
        {
            [ValidateEnumerable]
            public IEnumerable<DataAnnotatedClass> PropertyList { get; set; }
        }

        [Test]
        public void When_validating_object_with_data_annotation_should_validate_and_raise_error()
        {
            var objectToValidate = new DataAnnotatedProperty();

            validationResults = validator.ValidateObject(objectToValidate);

            validationResults.Count.ShouldBe(1);
        }

        [Test]
        public void When_validating_object_with_validateEnumerableAttribute_should_validate_items_in_enumeration_and_raise_error()
        {
            var list = new List<DataAnnotatedClass>
                       {
                           new DataAnnotatedClass
                           {
                               Property = new DataAnnotatedProperty()
                           }
                       };

            var objectToValidate = new DataAnnotatedCollectionClass
                                   {
                                       PropertyList = list
                                   };

            validationResults = validator.ValidateObject(objectToValidate);

            validationResults.Count.ShouldBe(1);
        }

        [Test]
        public void When_validating_object_with_validationObjectAttribute_should_validate_recursively_and_raise_error()
        {
            var objectToValidate = new DataAnnotatedClass
                                   {
                                       Property = new DataAnnotatedProperty()
                                   };

            validationResults = validator.ValidateObject(objectToValidate);

            validationResults.Count.ShouldBe(1);
        }

        [Test]
        public void When_validating_person_entity_and_uniqueId_property_contains_trailing_or_leading_whitespace_should_raise_validation_error()
        {
            PersonUniqueIdToUsiCache.GetCache =
                () => MockRepository.GenerateStub<IPersonUniqueIdToUsiCache>();

            DescriptorsCache.GetCache =
                () => MockRepository.GenerateStub<IDescriptorsCache>();

            validationResults = validator.ValidateObject(
                new Student
                {
                    StudentUniqueId = "12345 "
                });

            validationResults.Select(r => r.ErrorMessage)
                             .ShouldContain(
                                  "StudentUniqueId property is part of the primary key and therefore its value cannot contain leading or trailing whitespace.");
        }
    }
}
