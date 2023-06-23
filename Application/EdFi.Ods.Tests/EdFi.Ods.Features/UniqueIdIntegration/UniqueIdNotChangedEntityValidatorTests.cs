// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.UniqueIdIntegration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class UniqueIdNotChangeEntityValidatorTests
    {
        [TestFixture]
        public class When_validating_identifiable_person_object_with_changed_unique_id
        {
            [Test]
            public void Should_return_validation_error()
            {
                // Arrange
                const string uniqueId = "ABC123";

                var suppliedPerson = new TestPersonType()
                {
                    Id = Guid.NewGuid(),
                    TheUniqueId = uniqueId + "XYZ"
                };

                var personUniqueIdToIdCache = A.Fake<IPersonUniqueIdToIdCache>();
                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._)).Returns(uniqueId);

                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache, personEntitySpecification);
                var result = validator.ValidateObject(suppliedPerson);

                // Assert
                result.IsValid().ShouldBeFalse();
                result.Count.ShouldBe(1);
                result.First().ErrorMessage.ShouldBe("A person's UniqueId cannot be modified.");
            }
        }

        [TestFixture]
        public class When_validating_identifiable_person_object_with_unchanged_unique_id
        {
            [Test]
            public void Should_pass_validation()
            {
                // Arrange
                const string uniqueId = "ABC123";

                var suppliedPerson = new TestPersonType()
                {
                    Id = Guid.NewGuid(),
                    TheUniqueId = uniqueId
                };

                var personUniqueIdToIdCache = A.Fake<IPersonUniqueIdToIdCache>();
                A.CallTo(() => personUniqueIdToIdCache.GetUniqueId(A<string>._, A<Guid>._)).Returns(uniqueId);

                var personEntitySpecification = A.Fake<IPersonEntitySpecification>();
                A.CallTo(() => personEntitySpecification.IsPersonEntity(A<Type>.Ignored)).Returns(true);

                // Act
                var validator = new UniqueIdNotChangedEntityValidator(personUniqueIdToIdCache, personEntitySpecification);
                var result = validator.ValidateObject(suppliedPerson);

                result.IsValid().ShouldBeTrue();
            }
        }

        private class TestPersonType : IHasIdentifier, IIdentifiablePerson
        {
            public string TheUniqueId { get; set; }

            public Guid Id { get; set; }

            string IIdentifiablePerson.UniqueId
            {
                get => TheUniqueId;
            }
        }
    }
}
