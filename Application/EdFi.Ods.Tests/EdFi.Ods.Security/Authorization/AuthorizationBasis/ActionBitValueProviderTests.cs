// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class ActionBitValueProviderTests
{
    [SetUp]
    public void SetUp()
    {
        _securityRepository = A.Fake<ISecurityRepository>();

        A.CallTo(() => _securityRepository.GetActionByName("Create")).Returns(new Action { ActionUri = "Create" });
        A.CallTo(() => _securityRepository.GetActionByName("Read")).Returns(new Action { ActionUri = "Read" });
        A.CallTo(() => _securityRepository.GetActionByName("Update")).Returns(new Action { ActionUri = "Update" });
        A.CallTo(() => _securityRepository.GetActionByName("Delete")).Returns(new Action { ActionUri = "Delete" });
        A.CallTo(() => _securityRepository.GetActionByName("ReadChanges")).Returns(new Action { ActionUri = "ReadChanges" });

        _provider = new ActionBitValueProvider(_securityRepository);
    }

    private ActionBitValueProvider _provider;
    private ISecurityRepository _securityRepository;

    [TestCase("Create", 1)]
    [TestCase("Read", 2)]
    [TestCase("Update", 4)]
    [TestCase("Delete", 8)]
    [TestCase("ReadChanges", 16)]
    public void GetBitValue_ShouldReturnCorrectBitValue_ForSupportedActions(string action, int expectedBitValue)
    {
        // Act
        var result = _provider.GetBitValue(action);

        // Assert
        result.ShouldBe(expectedBitValue);
    }

    [Test]
    public void GetBitValue_ShouldThrowNotSupportedException_ForUnsupportedAction()
    {
        // Arrange
        var unsupportedAction = "UnsupportedAction";

        // Act & Assert
        var ex = Should.Throw<NotSupportedException>(() => _provider.GetBitValue(unsupportedAction));
        ex.Message.ShouldBe("The requested action is not supported for authorization.");
    }

    [Test]
    public void Constructor_ShouldLazyLoadBitValuesByAction_FromSecurityRepository()
    {
        // Act
        var result = _provider.GetBitValue("Create");

        // Assert
        A.CallTo(() => _securityRepository.GetActionByName("Create")).MustHaveHappenedOnceExactly();
        A.CallTo(() => _securityRepository.GetActionByName("Read")).MustHaveHappenedOnceExactly();
        A.CallTo(() => _securityRepository.GetActionByName("Update")).MustHaveHappenedOnceExactly();
        A.CallTo(() => _securityRepository.GetActionByName("Delete")).MustHaveHappenedOnceExactly();
        A.CallTo(() => _securityRepository.GetActionByName("ReadChanges")).MustHaveHappenedOnceExactly();

        result.ShouldBe(1); // Check that the correct value is returned for "Create"
    }
}
