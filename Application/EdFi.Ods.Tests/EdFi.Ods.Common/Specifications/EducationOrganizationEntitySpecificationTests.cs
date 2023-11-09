// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EducationOrganizationEntitySpecificationTests
    {
        public class EdOrgType1 { }

        public class NotEdOrgType { }

        private IEducationOrganizationTypesProvider _educationOrganizationTypesProvider;
        private EducationOrganizationEntitySpecification _educationOrganizationEntitySpecification;

        [SetUp]
        public void SetUp()
        {
            _educationOrganizationTypesProvider = GetEducationOrganizationTypesProvider();
            _educationOrganizationEntitySpecification = new EducationOrganizationEntitySpecification(_educationOrganizationTypesProvider);

            static IEducationOrganizationTypesProvider GetEducationOrganizationTypesProvider()
            {
                var educationOrganizationTypesProvider = A.Fake<IEducationOrganizationTypesProvider>();

                A.CallTo(() => educationOrganizationTypesProvider.EducationOrganizationTypes)
                    .Returns(
                        new[]
                        {
                            "EdOrgType1",
                            "EdOrgType2"
                        });

                return educationOrganizationTypesProvider;
            }
        }

        [Test]
        public void IsEducationOrganizationEntity_ShouldReturnTrue_WhenEdOrgTypeNameExists()
        {
            // Arrange

            // Act
            var isEducationOrganizationEntity = 
                _educationOrganizationEntitySpecification.IsEducationOrganizationEntity(nameof(EdOrgType1));

            // Assert
            isEducationOrganizationEntity.ShouldBeTrue();
        }

        [Test]
        public void IsEducationOrganizationEntity_ShouldReturnTrue_WhenEdOrgTypeExists()
        {
            // Arrange

            // Act
            var isEducationOrganizationEntity =
                _educationOrganizationEntitySpecification.IsEducationOrganizationEntity(typeof(EdOrgType1));

            // Assert
            isEducationOrganizationEntity.ShouldBeTrue();
        }

        [Test]
        public void IsEducationOrganizationEntity_ShouldReturnFalse_WhenEdOrgTypeNameDoesNotExists()
        {
            // Arrange

            // Act
            var isEducationOrganizationEntity =
                _educationOrganizationEntitySpecification.IsEducationOrganizationEntity(nameof(NotEdOrgType));

            // Assert
            isEducationOrganizationEntity.ShouldBeFalse();
        }

        [Test]
        public void IsEducationOrganizationEntity_ShouldReturnFalse_WhenEdOrgTypeDoesNotExists()
        {
            // Arrange

            // Act
            var isEducationOrganizationEntity =
                _educationOrganizationEntitySpecification.IsEducationOrganizationEntity(typeof(NotEdOrgType));

            // Assert
            isEducationOrganizationEntity.ShouldBeFalse();
        }

        [Test]
        public void IsEducationOrganizationIdentifier_ShouldReturnTrue_WhenPropertyNameMatchesConvention()
        {
            // Arrange

            // Act
            var isEducationOrganizationIdentifier = _educationOrganizationEntitySpecification.IsEducationOrganizationIdentifier("EdOrgType2Id");

            // Assert
            isEducationOrganizationIdentifier.ShouldBeTrue();
        }

        [TestCase("NotAnEdOrgId")]
        [TestCase("SomethingElseCompletely")]
        public void IsEducationOrganizationIdentifier_ShouldReturnFalse_WhenPropertyNameDoesNotMatchConvention(string propertyName)
        {
            // Arrange

            // Act
            var isEducationOrganizationIdentifier = 
                _educationOrganizationEntitySpecification.IsEducationOrganizationIdentifier(propertyName);

            // Assert
            isEducationOrganizationIdentifier.ShouldBeFalse();
        }

        [Test]
        public void IsEducationOrganizationBaseEntity_Should_return_true_for_educationOrganization_base_entity()
        {
            // Arrange

            // Act
            var isIsEducationOrganizationBaseEntity = 
                _educationOrganizationEntitySpecification.IsEducationOrganizationBaseEntity(nameof(EducationOrganization));

            // Assert
            isIsEducationOrganizationBaseEntity.ShouldBeTrue();
        }
    }
}
