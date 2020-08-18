// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Validation;
using FluentValidation;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common.Validation
{
    public class Feature_Fluent_Validation_can_be_used_to_explicitly_validate_objects
    {
        public class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }
        }

        public class Pet
        {
            public string Name { get; set; }

            public string AnimalType { get; set; }
        }

        public class CatsAndDogsOnlyValidator : AbstractValidator<Pet>
        {
            public CatsAndDogsOnlyValidator()
            {
                RuleFor(x => x.AnimalType)
                   .Must(
                        y => new[]
                             {
                                 "Cat", "Dog"
                             }.Contains(y))
                   .WithMessage("It can only rain cats and dogs.");
            }
        }

        public class EvenAgeValidator : AbstractValidator<Person>
        {
            public EvenAgeValidator()
            {
                RuleSet(
                    "EvenAge",
                    () =>
                    {
                        RuleFor(x => x.Age)
                           .Must(y => y % 2 == 0)
                           .WithMessage("The age is quite odd.");
                    });
            }
        }

        public class ShortFirstNameValidator : AbstractValidator<Person>
        {
            public ShortFirstNameValidator()
            {
                RuleSet(
                    "ShortNames",
                    () =>
                    {
                        RuleFor(x => x.FirstName)
                           .Length(1, 3);
                    });
            }
        }

        public class ShortLastNameValidator : AbstractValidator<Person>
        {
            public ShortLastNameValidator()
            {
                RuleSet(
                    "ShortNames",
                    () =>
                    {
                        RuleFor(x => x.LastName)
                           .Length(1, 5);
                    });
            }
        }

        public class When_explicitly_validating_an_object
            : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualValidationResults;

            protected override void Act()
            {
                // Execute code under test
                var explicitValidator = new FluentValidationObjectValidator(
                    new IValidator[]
                    {
                        new EvenAgeValidator(), new ShortFirstNameValidator(), new ShortLastNameValidator(), new CatsAndDogsOnlyValidator()
                    });

                var person = new Person
                             {
                                 FirstName = "Wolfgang", LastName = "Mozart", Age = 261
                             };

                _actualValidationResults = explicitValidator.ValidateObject(person, "ShortNames");
            }

            [Assert]
            public void Should_only_generate_validation_errors_for_the_specific_ruleset()
            {
                Assert.That(
                    _actualValidationResults.GetAllMessages(),
                    Does.Contain("between 1 and 3 characters")
                      .And.ContainsSubstring("between 1 and 5 characters")
                      .And.Not.ContainsSubstring("age is quite odd"));
            }
        }

        public class When_explicitly_validating_an_object_that_does_not_have_any_ruleset_validations_defined_for_the_object_type
            : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualValidationResults;

            protected override void Act()
            {
                // Execute code under test
                var explicitValidator = new FluentValidationObjectValidator(
                    new IValidator[]
                    {
                        new EvenAgeValidator(), // Does not apply to Pets or define validations for the "ShortNames" ruleset
                        new ShortFirstNameValidator(), // Has a "ShortNames" ruleset, but does not apply to Pets
                        new ShortLastNameValidator(), // Has a "ShortNames" ruleset, but does not apply to Pets
                        new CatsAndDogsOnlyValidator() // Applies to Pets, but does not have a "ShortNames" ruleset
                    });

                var pet = new Pet
                          {
                              Name = "Fido", AnimalType = "Hamster"
                          };

                _actualValidationResults = explicitValidator.ValidateObject(pet, "ShortNames");
            }

            [Assert]
            public void Should_not_generate_any_validation_errors()
            {
                Assert.That(_actualValidationResults.Count, Is.EqualTo(0));
            }
        }

        public class When_validating_an_object
            : LegacyTestFixtureBase
        {
            private ICollection<ValidationResult> _actualValidationResults;

            protected override void Act()
            {
                // Execute code under test
                var explicitValidator = new FluentValidationObjectValidator(
                    new IValidator[]
                    {
                        new EvenAgeValidator(), new ShortFirstNameValidator(), new ShortLastNameValidator(), new CatsAndDogsOnlyValidator()
                    });

                var pet = new Pet
                          {
                              Name = "Fido", AnimalType = "Hamster"
                          };

                _actualValidationResults = explicitValidator.ValidateObject(pet);
            }

            [Assert]
            public void Should_only_generate_validation_errors_for_validators_of_the_object_type_being_validated()
            {
                Assert.That(
                    _actualValidationResults.GetAllMessages()
                                            .Trim(),
                    Is.EqualTo("It can only rain cats and dogs."));
            }
        }
    }
}
