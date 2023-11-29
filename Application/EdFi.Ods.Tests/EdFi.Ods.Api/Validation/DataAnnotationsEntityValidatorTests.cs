// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.Common.EdFi;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Array = System.Array;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    [TestFixture]
    public class DataAnnotationsEntityValidatorTests
    {
        private readonly DataAnnotationsResourceValidator validator = new();
        private ICollection<ValidationResult> validationResults;

        private class DataAnnotatedProperty : IValidatableObject
        {
            [Required]
            public string RequiredProperty { get; set; }

            public bool ValidateInvoked { get; set; }
            
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                ValidateInvoked = true;

                return Array.Empty<ValidationResult>();
            }
        }

        [Test]
        public void When_validating_object_with_data_annotation_should_validate_and_raise_error()
        {
            var objectToValidate = new DataAnnotatedProperty();

            validationResults = validator.ValidateObject(objectToValidate);

            validationResults.Count.ShouldBe(1);
            objectToValidate.ValidateInvoked.ShouldBeTrue();
        }

        [Test]
        public void When_validating_person_entity_and_uniqueId_property_contains_trailing_or_leading_whitespace_should_raise_validation_error()
        {
            GeneratedArtifactStaticDependencies.Resolvers.Set(() => new ContextProvider<UsiLookupsByUniqueIdContext>(new CallContextStorage()));
            GeneratedArtifactStaticDependencies.UsiLookupsByUniqueIdContextProvider.Set(new UsiLookupsByUniqueIdContext());

            var mappingContractProvider = A.Fake<IMappingContractProvider>();
            A.CallTo(() => mappingContractProvider.GetMappingContract(A<FullName>.Ignored)).Returns(null);
            
            GeneratedArtifactStaticDependencies.Resolvers.Set(() => mappingContractProvider);

            validationResults = validator.ValidateObject(
                new Student
                {
                    StudentUniqueId = "12345 "
                });

            validationResults.Select(r => r.ErrorMessage)
                .ShouldContain(
                    "StudentUniqueId cannot contain leading or trailing spaces.");
        }
    }
}