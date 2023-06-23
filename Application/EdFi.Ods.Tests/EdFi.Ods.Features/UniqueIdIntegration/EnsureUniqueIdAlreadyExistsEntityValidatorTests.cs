// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.UniqueIdIntegration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EnsureUniqueIdAlreadyExistsEntityValidatorTests
    {
        private class Student : IHasIdentifier, IIdentifiablePerson
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Object"/> class.
            /// </summary>
            public Student(Guid id, string uniqueId)
            {
                Id = id;
                UniqueId = uniqueId;
            }

            public Guid Id { get; set; }

            public string UniqueId { get; }
        }

        private class NotAPerson : Student
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Object"/> class.
            /// </summary>
            public NotAPerson(Guid id, string uniqueId)
                : base(id, uniqueId) { }
        }

        [TestFixture]
        public class When_validating_a_person_entity_that_has_both_the_UniqueId_and_Id_assigned
        {
            [Test]
            public void Should_not_generate_any_validation_errors()
            {
                // Arrange
                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var person = new Student(Guid.NewGuid(), "ABCD");
                var validator = new EnsureUniqueIdAlreadyExistsEntityValidator(personEntitySpecification);
                var actualResults = validator.ValidateObject(person);

                // Assert                
                actualResults.ShouldBeEmpty();
            }
        }

        [TestFixture]
        public class When_validating_a_person_entity_that_has_just_the_UniqueId_assigned
        {
            [Test]
            public void ValidateObject_generate_a_validation_error_about_the_UniqueId_value_not_being_resolved()
            {
                // Arrange
                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var person = new Student(default(Guid), "ABCD");
                var validator = new EnsureUniqueIdAlreadyExistsEntityValidator(personEntitySpecification);
                var actualResults = validator.ValidateObject(person);

                // Assert
                actualResults.ShouldNotBeEmpty();
                actualResults.Single().ErrorMessage.ShouldContain("was not resolved");
            }
        }

        [TestFixture]
        public class When_validating_a_entity_that_is_not_a_Person_entity
        {
            [Test]
            public void Should_not_generate_any_validation_errors()
            {
                // Arrange
                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(false);

                // Act
                var person = new NotAPerson(default(Guid), "ABCD");
                var validator = new EnsureUniqueIdAlreadyExistsEntityValidator(personEntitySpecification);
                var actualResults = validator.ValidateObject(person);

                // Assert
                actualResults.ShouldBeEmpty();
            }
        }

        [TestFixture]
        public class When_validating_a_entity_that_looks_like_a_Person_entity_but_does_not_implement_the_Id_interface
        {
            private class Student : IIdentifiablePerson
            {
                public string UniqueId { get; private set; }
            }

            [Test]
            public void ValidateObject_throws_NotImplementedException_indicating_the_interface_was_not_implemented()
            {
                // Arrange
                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var person = new Student();
                var validator = new EnsureUniqueIdAlreadyExistsEntityValidator(personEntitySpecification);
                
                // Assert
                Should.Throw<NotImplementedException>(() => validator.ValidateObject(person))
                    .Message.ShouldContain("did not implement");
            }
        }

        [TestFixture]
        public class When_validating_a_entity_that_looks_like_a_Person_entity_but_does_not_implement_the_UniqueId_interface
        {
            private class Student : IHasIdentifier
            {
                public Guid Id { get; set; }
            }

            [Test]
            public void Should_throw_a_NotImplementedException_indicating_the_interface_was_not_implemented()
            {
                // Arrange
                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var person = new Student();
                var validator = new EnsureUniqueIdAlreadyExistsEntityValidator(personEntitySpecification);

                // Assert
                Should.Throw<NotImplementedException>(() => validator.ValidateObject(person))
                    .Message.ShouldContain("did not implement");
            }
        }
    }
}