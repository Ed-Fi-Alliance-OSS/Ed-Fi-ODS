// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using BindingFlags = System.Reflection.BindingFlags;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

[TestFixture]
public class CustomAuthorizationViewHintProviderTests
{
    private ICustomViewBasisEntityProvider _fakeCustomViewBasisEntityProvider;
    private CustomAuthorizationViewHintProvider _provider;
    private ConstructorInfo _entityConstructor;

    [SetUp]
    public void SetUp()
    {
        _fakeCustomViewBasisEntityProvider = A.Fake<ICustomViewBasisEntityProvider>();
        _provider = new CustomAuthorizationViewHintProvider(_fakeCustomViewBasisEntityProvider);

        _entityConstructor = typeof(Entity).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            new[]
            {
                typeof(DomainModel),
                typeof(EntityDefinition)
            });
    }

    private Entity CreateEntity()
    {
        var entity = _entityConstructor.Invoke(new object[]
        {
            null,
            new EntityDefinition()
            {
                LocallyDefinedProperties = [],
                Identifiers = []
            }
        });

        return (Entity)entity;
    }

    [TestCase("StudentWithCTEEnrollment", "You may need a Student with CTE Enrollment.")]
    [TestCase("AssessmentWithACTIdentifier", "You may need an Assessment with ACT Identifier.")]
    [TestCase("TransportationTypeDescriptorWithABus", "You may need a Transportation Type Descriptor with a Bus.")]
    [TestCase("EducationOrganizationWithACategoryContainingAnSWord", "You may need an Education Organization with a Category Containing an S Word.")]
    public void GetFailureHint_ReturnsCorrectHint(string viewName, string expectedHint)
    {
        // Arrange
        A.CallTo(() => _fakeCustomViewBasisEntityProvider.GetBasisEntity(viewName))
            .Returns((attemptedEntityName: "SomeEntity", entity: CreateEntity())); // Simulating that an entity was found

        // Act
        var hint = _provider.GetFailureHint(viewName);

        // Assert
        hint.ShouldBe(expectedHint);
    }

    [Test]
    public void GetFailureHint_ReturnsNull_WhenEntityNotFound()
    {
        // Arrange
        string viewName = "ViewNameNotMatchingConvention";
        A.CallTo(() => _fakeCustomViewBasisEntityProvider.GetBasisEntity(viewName))
            .Returns((null, null)); // Simulating that the view didn't match conventions

        // Act
        var hint = _provider.GetFailureHint(viewName);

        // Assert
        hint.ShouldBeNull();
    }
}
