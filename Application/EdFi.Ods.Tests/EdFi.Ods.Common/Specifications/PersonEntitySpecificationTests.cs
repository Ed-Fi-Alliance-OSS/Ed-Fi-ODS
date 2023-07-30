// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Specifications;

[TestFixture]
public class PersonEntitySpecificationTests
{
    public class PersonType1 { }

    public class NotAPersonType { }

    [SetUp]
    public void SetUp()
    {
        _personTypesProvider = GetPersonTypesProvider();
        _personEntitySpecification = new PersonEntitySpecification(_personTypesProvider);
        
        static IPersonTypesProvider GetPersonTypesProvider()
        {
            var personTypesProvider = A.Fake<IPersonTypesProvider>();

            A.CallTo(() => personTypesProvider.PersonTypes)
                .Returns(
                    new[]
                    {
                        "PersonType1",
                        "PersonType2"
                    });

            return personTypesProvider;
        }
    }

    private IPersonTypesProvider _personTypesProvider;
    private PersonEntitySpecification _personEntitySpecification;

    [Test]
    public void IsPersonEntity_ShouldReturnTrue_WhenPersonTypeNameExists()
    {
        // Arrange

        // Act
        var isPersonEntity = _personEntitySpecification.IsPersonEntity("PersonType1");

        // Assert
        isPersonEntity.ShouldBe(true);
    }

    [Test]
    public void IsPersonEntity_ShouldReturnTrue_WhenPersonTypeExists()
    {
        // Arrange

        // Act
        var isPersonEntity = _personEntitySpecification.IsPersonEntity(typeof(PersonType1));

        // Assert
        isPersonEntity.ShouldBe(true);
    }

    [Test]
    public void IsPersonEntity_ShouldReturnFalse_WhenPersonTypeNameDoesNotExist()
    {
        // Arrange

        // Act
        var isPersonEntity = _personEntitySpecification.IsPersonEntity("NotAPersonType");

        // Assert
        isPersonEntity.ShouldBe(false);
    }

    [Test]
    public void IsPersonEntity_ShouldReturnFalse_WhenPersonTypeDoesNotExist()
    {
        // Arrange

        // Act
        var isPersonEntity = _personEntitySpecification.IsPersonEntity(typeof(NotAPersonType));

        // Assert
        isPersonEntity.ShouldBe(false);
    }

    [Test]
    public void IsPersonIdentifier_ShouldReturnTrue_WhenPropertyNameMatchesConvention()
    {
        // Arrange
        
        // Act
        var isPersonIdentifier = _personEntitySpecification.IsPersonIdentifier("PersonType2UniqueId", "PersonType2");

        // Assert
        isPersonIdentifier.ShouldBe(true);
    }

    [Test]
    public void IsPersonIdentifier_ShouldReturnFalse_WhenPersonTypeDoesNotExist()
    {
        // Arrange

        // Act
        // Assert
        Should.Throw<ArgumentException>(() => _personEntitySpecification.IsPersonIdentifier("NotAUniqueId", "NotAPersonType"))
            .Message.ShouldBe($"'NotAPersonType' is not a supported person type.");
    }

    [TestCase("NotAUniqueId")]
    [TestCase("SomethingElseCompletely")]
    public void IsPersonIdentifier_ShouldReturnFalse_WhenPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        // Assert
        var result = _personEntitySpecification.IsPersonIdentifier(propertyName);

        result.ShouldBeFalse();
    }

    [Test]
    public void IsPersonIdentifier_ShouldReturnFalse_WhenPropertyNameDoesNotMatchConventionForAValidPersonType()
    {
        // Arrange

        // Act
        // Assert
        var result = _personEntitySpecification.IsPersonIdentifier("NotAUniqueId", "PersonType1");

        result.ShouldBeFalse();
    }

    [TestCase("PersonType1UniqueId")]
    [TestCase("RoleNamedPersonType1UniqueId")]
    public void GetUniqueIdPersonType_ShouldReturnPersonType_WhenUniqueIdPropertyNameMatchesConvention(string propertyName)
    {
        // Arrange

        // Act
        var result = _personEntitySpecification.GetUniqueIdPersonType(propertyName);

        // Assert
        result.ShouldBe("PersonType1");
    }

    [TestCase("NotAPersonTypeUniqueId")]
    [TestCase("RoleNamedNotAPersonTypeUniqueId")]
    public void GetUniqueIdPersonType_ShouldReturnNull_WhenUniqueIdPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        var result = _personEntitySpecification.GetUniqueIdPersonType(propertyName);

        // Assert
        result.ShouldBeNull();
    }

    [TestCase("PersonType1UniqueId")]
    [TestCase("RoleNamedPersonType1UniqueId")]
    public void TryGetUniqueIdPersonType_ShouldReturnTrueAndPersonType_WhenUniqueIdPropertyNameMatchesConvention(string propertyName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUniqueIdPersonType(propertyName, out var result);

        // Assert
        success.ShouldBe(true);
        result.ShouldBe("PersonType1");
    }

    [TestCase("NotAPersonTypeUniqueId")]
    [TestCase("RoleNamedNotAPersonTypeUniqueId")]
    public void TryGetUniqueIdPersonType_ShouldReturnFalseAndNull_WhenUniqueIdPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUniqueIdPersonType(propertyName, out var result);

        // Assert
        success.ShouldBe(false);
        result.ShouldBeNull();
    }

    [TestCase("PersonType1USI")]
    [TestCase("RoleNamedPersonType1USI")]
    public void GetUSIPersonType_ShouldReturnPersonType_WhenUSIPropertyNameMatchesConvention(string propertyName)
    {
        // Arrange

        // Act
        var result = _personEntitySpecification.GetUSIPersonType(propertyName);

        // Assert
        result.ShouldBe("PersonType1");
    }

    [TestCase("NotAPersonTypeUniqueId")]
    [TestCase("RoleNamedNotAPersonTypeUniqueId")]
    public void GetUSIPersonType_ShouldReturnNull_WhenUSIPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        var result = _personEntitySpecification.GetUSIPersonType(propertyName);

        // Assert
        result.ShouldBeNull();
    }

    [TestCase("PersonType1USI")]
    [TestCase("RoleNamedPersonType1USI")]
    public void TryGetUSIPersonType_ShouldReturnTrueAndPersonType_WhenUSIPropertyNameMatchesConvention(string propertyName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUSIPersonType(propertyName, out var result);

        // Assert
        success.ShouldBe(true);
        result.ShouldBe("PersonType1");
    }

    [TestCase("NotAPersonTypeUniqueId")]
    [TestCase("RoleNamedNotAPersonTypeUniqueId")]
    public void TryGetUSIPersonType_ShouldReturnFalseAndNull_WhenUSIPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUSIPersonType(propertyName, out var result);

        // Assert
        success.ShouldBe(false);
        result.ShouldBeNull();
    }

    [TestCase("PersonType1USI", null)]
    [TestCase("RoleNamedPersonType1USI", "RoleNamed")]
    public void TryGetUSIPersonTypeAndRoleName_ShouldReturnTrueAndPersonTypeAndRoleName_WhenUSIPropertyNameMatchesConvention(string propertyName, string expectedRoleName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUSIPersonTypeAndRoleName(
            propertyName,
            out var actualPersonType,
            out var actualRoleName);

        // Assert
        success.ShouldBe(true);
        actualPersonType.ShouldBe("PersonType1");
        actualRoleName.ShouldBe(expectedRoleName);
    }

    [TestCase("NotAPersonTypeUniqueId")]
    [TestCase("RoleNamedNotAPersonTypeUniqueId")]
    public void TryGetUSIPersonTypeAndRoleName_ShouldReturnFalseAndNulls_WhenUSIPropertyNameDoesNotMatchConvention(string propertyName)
    {
        // Arrange

        // Act
        var success = _personEntitySpecification.TryGetUSIPersonTypeAndRoleName(
            propertyName,
            out var personTypeResult,
            out var roleNameResult);

        // Assert
        success.ShouldBe(false);
        personTypeResult.ShouldBeNull();
        roleNameResult.ShouldBeNull();
    }
    
    [Test]
    public void IsDefiningUniqueId_ShouldReturnTrue_WhenResourceClassIsPersonEntityAndPropertyIsUniqueId()
    {
        // Arrange
        var resourceClass = new Resource("PersonType1");

        var resourceProperty = new ResourceProperty(
            resourceClass,
            "PersonType1UniqueId",
            new PropertyType(DbType.String),
            new PropertyCharacteristics(
                false,
                false,
                false,
                false,
                false,
                null),
            null);
        
        // Act
        var result = _personEntitySpecification.IsDefiningUniqueId(resourceClass, resourceProperty);

        // Assert
        result.ShouldBe(true);
    }

    [Test]
    public void IsDefiningUniqueId_ShouldReturnFalse_WhenResourceClassIsNotPersonEntity()
    {
        // Arrange
        var resourceClass = new Resource("NotAPersonType");
        var resourceProperty = new ResourceProperty(
            resourceClass,
            "PersonType1UniqueId",
            new PropertyType(DbType.String),
            new PropertyCharacteristics(
                false,
                false,
                false,
                false,
                false,
                null),
            null);
    
        // Act
        var result = _personEntitySpecification.IsDefiningUniqueId(resourceClass, resourceProperty);
    
        // Assert
        result.ShouldBe(false);
    }
    
    [Test]
    public void IsDefiningUniqueId_ShouldReturnFalse_WhenResourceClassIsPersonEntityButPropertyIsNotUniqueId()
    {
        // Arrange
        var resourceClass = new Resource("PersonType1");
        var resourceProperty = new ResourceProperty(
            resourceClass,
            "NotAUniqueId",
            new PropertyType(DbType.String),
            new PropertyCharacteristics(
                false,
                false,
                false,
                false,
                false,
                null),
            null);
    
        // Act
        var result = _personEntitySpecification.IsDefiningUniqueId(resourceClass, resourceProperty);
    
        // Assert
        result.ShouldBe(false);
    }
}
