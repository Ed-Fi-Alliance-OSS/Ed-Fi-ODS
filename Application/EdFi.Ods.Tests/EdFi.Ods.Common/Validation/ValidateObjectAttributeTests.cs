// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Validation
{
    public class ParentClass
    {
        [ValidateObject]
        public ChildClass Child { get; set; }
    }

    public class ChildClass
    {
        public int Property { get; set; }
    }

    [TestFixture]
    public class When_validating_an_object_with_a_validated_child_reference_that_is_null : LegacyTestFixtureBase
    {
        private ValidationResult validationResult;

        protected override void ExecuteBehavior()
        {
            var parentObject = new ParentClass();

            var validator = new ValidateObjectAttribute();

            validationResult = validator.GetValidationResult(
                parentObject,
                new ValidationContext(parentObject, null, null));
        }

        [Test]
        public virtual void Should_indicate_success()
        {
            validationResult.ShouldBe(ValidationResult.Success);
        }
    }
}
