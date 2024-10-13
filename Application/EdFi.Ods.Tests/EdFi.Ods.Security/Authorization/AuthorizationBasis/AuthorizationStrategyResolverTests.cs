// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Api.Security.AuthorizationStrategies;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class AuthorizationStrategyResolverTests
{
    [SetUp]
    public void SetUp()
    {
        _strategyProvider1 = A.Fake<IAuthorizationStrategyProvider>();
        _strategyProvider2 = A.Fake<IAuthorizationStrategyProvider>();

        _resolver = new AuthorizationStrategyResolver(
            new[]
            {
                _strategyProvider1,
                _strategyProvider2
            });
    }

    private AuthorizationStrategyResolver _resolver;
    private IAuthorizationStrategyProvider _strategyProvider1;
    private IAuthorizationStrategyProvider _strategyProvider2;

    [Test]
    public void GetAuthorizationStrategies_ShouldReturnStrategies_WhenAllStrategiesAreFound()
    {
        // Arrange
        var strategyNames = new List<string>
        {
            "Strategy1",
            "Strategy2"
        };

        var strategy1 = A.Fake<IAuthorizationStrategy>();
        var strategy2 = A.Fake<IAuthorizationStrategy>();

        A.CallTo(() => _strategyProvider1.GetByName("Strategy1")).Returns(strategy1);
        A.CallTo(() => _strategyProvider1.GetByName("Strategy2")).Returns(null);
        A.CallTo(() => _strategyProvider2.GetByName("Strategy2")).Returns(strategy2);

        // Act
        var result = _resolver.GetAuthorizationStrategies(strategyNames);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.ShouldContain(strategy1);
        result.ShouldContain(strategy2);
    }

    [Test]
    public void GetAuthorizationStrategies_ShouldThrowException_WhenStrategyIsNotFound()
    {
        // Arrange
        var strategyNames = new List<string> { "NonExistentStrategy" };

        A.CallTo(() => _strategyProvider1.GetByName("NonExistentStrategy")).Returns(null);
        A.CallTo(() => _strategyProvider2.GetByName("NonExistentStrategy")).Returns(null);

        // Act & Assert
        var ex = Should.Throw<SecurityConfigurationException>(() => _resolver.GetAuthorizationStrategies(strategyNames));

        ex.Message.ShouldContain(
            "Could not find an authorization strategy implementation for strategy name 'NonExistentStrategy'.");
    }

    [Test]
    public void GetAuthorizationStrategies_ShouldUseMultipleProviders_WhenNecessary()
    {
        // Arrange
        var strategyNames = new List<string>
        {
            "Strategy1",
            "Strategy2"
        };

        var strategy1 = A.Fake<IAuthorizationStrategy>();
        var strategy2 = A.Fake<IAuthorizationStrategy>();

        A.CallTo(() => _strategyProvider1.GetByName("Strategy1")).Returns(strategy1);
        A.CallTo(() => _strategyProvider1.GetByName("Strategy2")).Returns(null);
        A.CallTo(() => _strategyProvider2.GetByName("Strategy2")).Returns(strategy2);

        // Act
        var result = _resolver.GetAuthorizationStrategies(strategyNames);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.ShouldContain(strategy1);
        result.ShouldContain(strategy2);

        // Verify that Strategy1 was resolved by the first provider
        A.CallTo(() => _strategyProvider1.GetByName("Strategy1")).MustHaveHappened();
        A.CallTo(() => _strategyProvider2.GetByName("Strategy1")).MustNotHaveHappened();

        // Verify that Strategy2 was resolved by the second provider
        A.CallTo(() => _strategyProvider1.GetByName("Strategy2")).MustHaveHappened();
        A.CallTo(() => _strategyProvider2.GetByName("Strategy2")).MustHaveHappened();
    }

    [Test]
    public void GetAuthorizationStrategies_ShouldThrowException_WhenOneOfMultipleStrategiesIsNotFound()
    {
        // Arrange
        var strategyNames = new List<string>
        {
            "Strategy1",
            "MissingStrategy"
        };

        var strategy1 = A.Fake<IAuthorizationStrategy>();

        A.CallTo(() => _strategyProvider1.GetByName("Strategy1")).Returns(strategy1);
        A.CallTo(() => _strategyProvider1.GetByName("MissingStrategy")).Returns(null);
        A.CallTo(() => _strategyProvider2.GetByName("MissingStrategy")).Returns(null);

        // Act & Assert
        var ex = Should.Throw<SecurityConfigurationException>(() => _resolver.GetAuthorizationStrategies(strategyNames));
        ex.Message.ShouldContain("Could not find an authorization strategy implementation for strategy name 'MissingStrategy'.");
    }

    [Test]
    public void GetAuthorizationStrategies_ShouldReturnEmptyList_WhenNoStrategyNamesAreProvided()
    {
        // Arrange
        var strategyNames = new List<string>();

        // Act
        var result = _resolver.GetAuthorizationStrategies(strategyNames);

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GetAuthorizationStrategies_ShouldReturnFirstMatchingStrategy_WhenStrategyIsFoundInMultipleProviders()
    {
        // Arrange
        var strategyNames = new List<string> { "SharedStrategy" };
        var strategy1 = A.Fake<IAuthorizationStrategy>();
        var strategy2 = A.Fake<IAuthorizationStrategy>();

        A.CallTo(() => _strategyProvider1.GetByName("SharedStrategy")).Returns(strategy1);
        A.CallTo(() => _strategyProvider2.GetByName("SharedStrategy")).Returns(strategy2);

        // Act
        var result = _resolver.GetAuthorizationStrategies(strategyNames);

        // Assert
        result.Count.ShouldBe(1);
        result.ShouldContain(strategy1);
        A.CallTo(() => _strategyProvider2.GetByName(A<string>._)).MustNotHaveHappened();
    }
}
