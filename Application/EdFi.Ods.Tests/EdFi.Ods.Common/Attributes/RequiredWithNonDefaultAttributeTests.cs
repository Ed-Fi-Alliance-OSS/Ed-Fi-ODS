// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using FakeItEasy;
using Shouldly;
using System;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Dependencies;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Attributes;

[TestFixture]
public class RequiredWithNonDefaultAttributeTests
{
    private RequiredWithNonDefaultAttribute _attribute;
    private Behaviors _behaviors;

    [SetUp]
    public void SetUp()
    {
        _attribute = new RequiredWithNonDefaultAttribute();
        _behaviors = new Behaviors() { AllowWhitespaceOnlyValues = false };
        GeneratedArtifactStaticDependencies.Resolvers.Set(() => _behaviors);
    }

    [Test]
    public void Should_FailValidation_When_StringIsEmpty()
    {
        // Arrange
        var context = CreateValidationContext("MyProperty");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, string.Empty, context);

        // Assert
        result.ShouldNotBe(null);
        result.ErrorMessage.ShouldBe("MyProperty is required and should not be left empty.");
    }

    [Test]
    public void Should_FailValidation_When_StringIsWhitespaceOnly_And_AllowWhitespaceOnlyValuesIsDisabled()
    {
        // Arrange
        var context = CreateValidationContext("MyProperty");
        _behaviors.AllowWhitespaceOnlyValues = false;

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, "    ", context);

        // Assert
        result.ShouldNotBe(null);
        result.ErrorMessage.ShouldBe("MyProperty is required and should not be left empty.");
    }

    [Test]
    public void Should_PassValidation_When_StringIsWhitespaceOnly_And_AllowWhitespaceOnlyValuesIsEnabled()
    {
        // Arrange
        var context = CreateValidationContext("MyProperty");
        _behaviors.AllowWhitespaceOnlyValues = true;

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, "    ", context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_PassValidation_When_StringIsNotEmpty()
    {
        // Arrange
        var context = CreateValidationContext("MyProperty");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, "Some Value", context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_PassValidation_When_BooleanIsFalseOrTrue()
    {
        // Arrange
        var context = CreateValidationContext("MyBoolean");

        // Act & Assert
        ValidationAttributeHelper.InvokeIsValid(_attribute, false, context).ShouldBe(ValidationResult.Success);
        ValidationAttributeHelper.InvokeIsValid(_attribute, true, context).ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_PassValidation_When_DecimalIsDefaultValue()
    {
        // Arrange
        var context = CreateValidationContext("MyDecimal");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, 0m, context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_FailValidation_When_DateTimeIsDefaultValue()
    {
        // Arrange
        var context = CreateValidationContext("MyDateTime");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, default(DateTime), context);

        // Assert
        result.ShouldNotBe(null);
        result.ErrorMessage.ShouldBe("MyDateTime is required.");
    }

    [Test]
    public void Should_PassValidation_When_DateTimeIsNonDefault()
    {
        // Arrange
        var context = CreateValidationContext("MyDateTime");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, new DateTime(2023, 1, 1), context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_FailValidation_When_ValueIsTypeDefaultValue()
    {
        // Arrange
        var context = CreateValidationContext("MyInt");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, 0, context);

        // Assert
        result.ShouldNotBe(null);
        result.ErrorMessage.ShouldBe("MyInt value must be different than 0.");
    }

    [Test]
    public void Should_PassValidation_When_ValueHasNonDefaultValue()
    {
        // Arrange
        var context = CreateValidationContext("MyInt");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, 50, context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    [Test]
    public void Should_FailValidation_When_NullReferenceTypeIsProvided()
    {
        // Arrange
        var context = CreateValidationContext("MyObject");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, null, context);

        // Assert
        result.ShouldNotBe(null);
        result.ErrorMessage.ShouldBe("MyObject is required.");
    }

    [Test]
    public void Should_PassValidation_When_ReferenceTypeIsNonNull()
    {
        // Arrange
        var context = CreateValidationContext("MyObject");

        // Act
        var result = ValidationAttributeHelper.InvokeIsValid(_attribute, new object(), context);

        // Assert
        result.ShouldBe(ValidationResult.Success);
    }

    private ValidationContext CreateValidationContext(string memberName)
    {
        var fakeServiceProvider = A.Fake<IServiceProvider>();

        return new ValidationContext(new object(), fakeServiceProvider, null) { MemberName = memberName };
    }
}
