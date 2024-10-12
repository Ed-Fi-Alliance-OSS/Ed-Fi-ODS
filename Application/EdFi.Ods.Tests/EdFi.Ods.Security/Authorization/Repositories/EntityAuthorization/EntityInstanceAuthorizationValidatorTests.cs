// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;
using EdFi.Ods.Common;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

[TestFixture]
public class EntityInstanceAuthorizationValidatorTests
{
    [SetUp]
    public void Setup()
    {
        _explicitObjectValidators = new[] { A.Fake<IExplicitObjectValidator>() };
        _securityRepository = A.Fake<ISecurityRepository>();

        // Mock security repository actions
        A.CallTo(() => _securityRepository.GetActionByName("Create")).Returns(new Action { ActionUri = "createUri" });
        A.CallTo(() => _securityRepository.GetActionByName("Read")).Returns(new Action { ActionUri = "readUri" });
        A.CallTo(() => _securityRepository.GetActionByName("Update")).Returns(new Action { ActionUri = "updateUri" });
        A.CallTo(() => _securityRepository.GetActionByName("Delete")).Returns(new Action { ActionUri = "deleteUri" });

        _validator = new EntityInstanceAuthorizationValidator(_explicitObjectValidators, _securityRepository);
    }

    private IExplicitObjectValidator[] _explicitObjectValidators;
    private ISecurityRepository _securityRepository;
    private EntityInstanceAuthorizationValidator _validator;

    [TestCase("createUri", true)]
    [TestCase("readUri", false)]
    [TestCase("updateUri", true)]
    [TestCase("deleteUri", true)]
    public void Validate_ShouldCallExplicitValidators_OnlyForCreateUpdateAndDeleteActions(string actionUri, bool shouldValidate)
    {
        // Arrange
        var entity = new object();
        var validationRuleSetName = "RuleSet";

        var validationResults = new List<ValidationResult> { ValidationResult.Success };
        A.CallTo(() => _explicitObjectValidators[0].ValidateObject(entity, validationRuleSetName)).Returns(validationResults);

        // Act
        Should.NotThrow(() => _validator.Validate(entity, actionUri, validationRuleSetName));

        // Assert
        if (shouldValidate)
        {
            A.CallTo(() => _explicitObjectValidators[0].ValidateObject(entity, validationRuleSetName))
                .MustHaveHappenedOnceExactly();
        }
        else
        {
            A.CallTo(() => _explicitObjectValidators[0].ValidateObject(entity, validationRuleSetName)).MustNotHaveHappened();
        }
    }

    [Test]
    public void Validate_ShouldThrowValidationException_WhenExplicitValidationFails()
    {
        // Arrange
        var entity = new object();
        var actionUri = "createUri";
        var validationRuleSetName = "RuleSet";

        var validationResults = new List<ValidationResult>
        {
            new ValidationResult("Field1 is required"),
            new ValidationResult("Field2 is invalid")
        };

        A.CallTo(() => _explicitObjectValidators[0].ValidateObject(entity, validationRuleSetName)).Returns(validationResults);

        // Act & Assert
        var exception = Should.Throw<ValidationException>(() => _validator.Validate(entity, actionUri, validationRuleSetName));

        exception.Message.ShouldContain("Validation of 'Object' failed");
        exception.Message.ShouldContain("Field1 is required");
        exception.Message.ShouldContain("Field2 is invalid");
    }

    [Test]
    public void Validate_ShouldNotCallValidators_WhenNoExplicitValidatorsAvailable()
    {
        // Arrange
        _explicitObjectValidators = Array.Empty<IExplicitObjectValidator>();

        var entity = new object();
        var actionUri = "updateUri";
        var validationRuleSetName = "RuleSet";

        // Act & Assert
        Should.NotThrow(() => _validator.Validate(entity, actionUri, validationRuleSetName));
    }

    [Test]
    public void Validate_ShouldThrowException_WhenActionUriIsUnknown()
    {
        // Arrange
        var entity = new object();
        var actionUri = "unknownUri";
        var validationRuleSetName = "RuleSet";

        // Act & Assert
        Should.Throw<KeyNotFoundException>(() => _validator.Validate(entity, actionUri, validationRuleSetName));
    }
}
