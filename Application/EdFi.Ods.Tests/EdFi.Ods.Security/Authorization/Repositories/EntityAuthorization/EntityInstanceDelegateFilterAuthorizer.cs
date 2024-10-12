// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

[TestFixture]
public class EntityInstanceDelegateFilterAuthorizerTests
{
    [SetUp]
    public void Setup()
    {
        _filterDefinitionProvider = A.Fake<IAuthorizationFilterDefinitionProvider>();
        _authorizer = new EntityInstanceDelegateFilterAuthorizer(_filterDefinitionProvider);
    }

    private IAuthorizationFilterDefinitionProvider _filterDefinitionProvider;
    private EntityInstanceDelegateFilterAuthorizer _authorizer;

    [Test]
    public void PerformInstanceBasedAuthorization_ShouldReturnEmptyResults_WhenNoMatchingFilterOperator()
    {
        // Arrange
        var authorizationStrategyFilterings = new List<AuthorizationStrategyFiltering>
        {
            new() { Operator = FilterOperator.Or }
        };

        var dataManagementRequestContext = A.Fake<DataManagementRequestContext>();

        // Act
        var results = _authorizer.PerformInstanceBasedAuthorization(
            FilterOperator.And,
            authorizationStrategyFilterings,
            dataManagementRequestContext);

        // Assert
        results.ShouldBeEmpty();
    }

    [Test]
    public void PerformInstanceBasedAuthorization_ShouldReturnResults_WithCorrectFilterOperator()
    {
        // Arrange
        var authorizationStrategyFiltering = new AuthorizationStrategyFiltering
        {
            Operator = FilterOperator.And,
            AuthorizationStrategyName = "TestStrategy",
            Filters = new List<AuthorizationFilterContext> { new AuthorizationFilterContext { FilterName = "TestFilter" } }
        };

        var fakeAuthorizeInstance =
            A.Fake<Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult>>();

        var filterDefinition = new AuthorizationFilterDefinition(
            "filter-name",
            "friendly-hql",
            null,
            null,
            fakeAuthorizeInstance);

        var dataManagementRequestContext = A.Fake<DataManagementRequestContext>();

        A.CallTo(() => _filterDefinitionProvider.GetAuthorizationFilterDefinition("TestFilter")).Returns(filterDefinition);

        A.CallTo(
                () => fakeAuthorizeInstance(
                    dataManagementRequestContext,
                    A<AuthorizationFilterContext>.Ignored,
                    "TestStrategy"))
            .Returns(InstanceAuthorizationResult.Success());

        // Act
        var results = _authorizer.PerformInstanceBasedAuthorization(
            FilterOperator.And,
            new List<AuthorizationStrategyFiltering> { authorizationStrategyFiltering },
            dataManagementRequestContext);

        // Assert
        results.ShouldHaveSingleItem();
        results[0].AuthorizationStrategyName.ShouldBe("TestStrategy");
        results[0].Operator.ShouldBe(FilterOperator.And);
        results[0].FilterResults.ShouldHaveSingleItem();
        results[0].FilterResults[0].Result.State.ShouldBe(AuthorizationState.Success);
    }

    [Test]
    public void PerformInstanceBasedAuthorization_ShouldAuthorizeEachFilter_WithCorrectContextAndStrategy()
    {
        // Arrange
        var authorizationStrategyFiltering = new AuthorizationStrategyFiltering
        {
            Operator = FilterOperator.And,
            AuthorizationStrategyName = "TestStrategy",
            Filters = new List<AuthorizationFilterContext>
            {
                new() { FilterName = "Filter1" },
                new() { FilterName = "Filter2" }
            }
        };

        var fakeAuthorizeInstance1 =
            A.Fake<Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult>>();

        var filterDefinition1 = new AuthorizationFilterDefinition(
            "filter-name-1",
            "friendly-hql",
            null,
            null,
            fakeAuthorizeInstance1);

        var fakeAuthorizeInstance2 =
            A.Fake<Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult>>();

        var filterDefinition2 = new AuthorizationFilterDefinition(
            "filter-name-2",
            "friendly-hql",
            null,
            null,
            fakeAuthorizeInstance2);
        
        var dataManagementRequestContext = A.Fake<DataManagementRequestContext>();

        A.CallTo(() => _filterDefinitionProvider.GetAuthorizationFilterDefinition("Filter1")).Returns(filterDefinition1);

        A.CallTo(() => _filterDefinitionProvider.GetAuthorizationFilterDefinition("Filter2")).Returns(filterDefinition2);

        A.CallTo(
                () => fakeAuthorizeInstance1(
                    dataManagementRequestContext,
                    A<AuthorizationFilterContext>.Ignored,
                    "TestStrategy"))
            .Returns(InstanceAuthorizationResult.Success());

        A.CallTo(
                () => fakeAuthorizeInstance2(
                    dataManagementRequestContext,
                    A<AuthorizationFilterContext>.Ignored,
                    "TestStrategy"))
            .Returns(InstanceAuthorizationResult.NotPerformed());

        // Act
        var results = _authorizer.PerformInstanceBasedAuthorization(
            FilterOperator.And,
            new List<AuthorizationStrategyFiltering> { authorizationStrategyFiltering },
            dataManagementRequestContext);

        // Assert
        results.ShouldHaveSingleItem();

        results[0]
            .FilterResults.ShouldSatisfyAllConditions(
                x => x[0].Result.State.ShouldBe(AuthorizationState.Success),
                x => x[1].Result.State.ShouldBe(AuthorizationState.NotPerformed));
    }

    [Test]
    public void PerformInstanceBasedAuthorization_ShouldReturnFailedState_WhenAuthorizationFails()
    {
        // Arrange
        var authorizationStrategyFiltering = new AuthorizationStrategyFiltering
        {
            Operator = FilterOperator.Or,
            AuthorizationStrategyName = "TestStrategy",
            Filters = new List<AuthorizationFilterContext> { new AuthorizationFilterContext { FilterName = "TestFilter" } }
        };

        var fakeAuthorizeInstance =
            A.Fake<Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult>>();

        var filterDefinition = new AuthorizationFilterDefinition(
            "filter-name",
            "friendly-hql",
            null,
            null,
            fakeAuthorizeInstance);

        var dataManagementRequestContext = A.Fake<DataManagementRequestContext>();

        A.CallTo(() => _filterDefinitionProvider.GetAuthorizationFilterDefinition("TestFilter")).Returns(filterDefinition);

        A.CallTo(
                () => fakeAuthorizeInstance(
                    dataManagementRequestContext,
                    A<AuthorizationFilterContext>.Ignored,
                    "TestStrategy"))
            .Returns(InstanceAuthorizationResult.Failed(new Exception("Authorization failed")));

        // Act
        var results = _authorizer.PerformInstanceBasedAuthorization(
            FilterOperator.Or,
            new List<AuthorizationStrategyFiltering> { authorizationStrategyFiltering },
            dataManagementRequestContext);

        // Assert
        results.ShouldHaveSingleItem();
        results[0].FilterResults.ShouldHaveSingleItem();
        results[0].FilterResults[0].Result.State.ShouldBe(AuthorizationState.Failed);
        results[0].FilterResults[0].Result.Exception.Message.ShouldBe("Authorization failed");
    }

    [Test]
    public void PerformInstanceBasedAuthorization_ShouldThrowException_WhenFilterDefinitionNotFound()
    {
        // Arrange
        var authorizationStrategyFiltering = new AuthorizationStrategyFiltering
        {
            Operator = FilterOperator.And,
            AuthorizationStrategyName = "TestStrategy",
            Filters = new List<AuthorizationFilterContext> { new AuthorizationFilterContext { FilterName = "UnknownFilter" } }
        };

        var dataManagementRequestContext = A.Fake<DataManagementRequestContext>();

        A.CallTo(() => _filterDefinitionProvider.GetAuthorizationFilterDefinition("UnknownFilter"))
            .Throws(new Exception("Filter definition not found"));

        // Act & Assert
        Should.Throw<Exception>(
            () => _authorizer.PerformInstanceBasedAuthorization(
                FilterOperator.And,
                new List<AuthorizationStrategyFiltering> { authorizationStrategyFiltering },
                dataManagementRequestContext));
    }
}
