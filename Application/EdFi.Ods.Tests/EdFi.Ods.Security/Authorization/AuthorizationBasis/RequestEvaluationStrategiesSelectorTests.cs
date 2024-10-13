// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Common.Security.Claims;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class RequestEvaluationStrategiesSelectorTests
{
    [SetUp]
    public void SetUp()
    {
        _selector = new RequestEvaluationStrategiesSelector();
    }

    private RequestEvaluationStrategiesSelector _selector;

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldReturnOverrideStrategyNames_WhenOverrideIsPresent()
    {
        // Arrange
        var action = "Create";

        var overrideStrategies = new List<string>
        {
            "OverrideStrategy1",
            "OverrideStrategy2"
        };

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            new ResourceAction[] { new ResourceAction(action, overrideStrategies, null) });

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata>()
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeTrue();
        strategyNames.ShouldBe(overrideStrategies);
    }

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldReturnDefaultStrategyNames_WhenNoOverrideIsPresent()
    {
        // Arrange
        var action = "Read";

        var defaultStrategies = new List<string>
        {
            "DefaultStrategy1",
            "DefaultStrategy2"
        };

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            AuthorizationStrategies = defaultStrategies
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata>(),
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeTrue();
        strategyNames.ShouldBe(defaultStrategies);
    }

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldReturnTrue_WhenNoOverridesOrDefaultsArePresent()
    {
        // Arrange
        var action = "Update";

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata>(),
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata>()
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeFalse();
        strategyNames.ShouldBeNull();
    }

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldPreferOverrideToDefault_WhenBothArePresent()
    {
        // Arrange
        var action = "Delete";
        var overrideStrategies = new List<string> { "OverrideStrategy" };

        var defaultStrategies = new List<string>
        {
            "DefaultStrategy1",
            "DefaultStrategy2"
        };

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            [new ResourceAction(action, overrideStrategies, null)]);

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            AuthorizationStrategies = defaultStrategies
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeTrue();
        strategyNames.ShouldBe(overrideStrategies);
    }

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldReturnFirstNonEmptyDefault_WhenMultipleDefaultsPresent()
    {
        // Arrange
        var action = "Read";
        var defaultStrategies1 = new List<string> { "FirstDefaultStrategy" };
        var defaultStrategies2 = new List<string> { "SecondDefaultStrategy" };

        var defaultClaimMetadata1 = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim1",
            AuthorizationStrategies = defaultStrategies1
        };

        var defaultClaimMetadata2 = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim2",
            AuthorizationStrategies = defaultStrategies2
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata>(),
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata>
            {
                defaultClaimMetadata1,
                defaultClaimMetadata2
            }
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeTrue();
        strategyNames.ShouldBe(defaultStrategies1);
    }

    [Test]
    public void TryGetAuthorizationStrategyNames_ShouldReturnEmpty_WhenAllStrategiesAreEmpty()
    {
        // Arrange
        var action = "Read";

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            [new ResourceAction(action, new List<string>(), null)]);

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            AuthorizationStrategies = new List<string>()
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.TryGetAuthorizationStrategyNames(requestEvaluation, out var strategyNames);

        // Assert
        result.ShouldBeFalse();
        strategyNames.ShouldBeNull();
    }
}
