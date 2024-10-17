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
public class RequestEvaluationValidationRuleSetSelectorTests
{
    [SetUp]
    public void SetUp()
    {
        _selector = new RequestEvaluationValidationRuleSetSelector();
    }

    private RequestEvaluationValidationRuleSetSelector _selector;

    [Test]
    public void GetValidationRuleSetName_ShouldReturnOverrideRuleSetName_WhenOverrideIsPresent()
    {
        // Arrange
        var action = "Create";
        var overrideRuleSet = "OverrideRuleSet";

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            [new ResourceAction(action, null, overrideRuleSet)]);

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata>()
        };

        // Act
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBe(overrideRuleSet);
    }

    [Test]
    public void GetValidationRuleSetName_ShouldReturnDefaultRuleSetName_WhenNoOverrideIsPresent()
    {
        // Arrange
        var action = "Read";
        var defaultRuleSet = "DefaultRuleSet";

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            ValidationRuleSetName = defaultRuleSet
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata>(),
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBe(defaultRuleSet);
    }

    [Test]
    public void GetValidationRuleSetName_ShouldReturnNull_WhenNoOverridesOrDefaultsArePresent()
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
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public void GetValidationRuleSetName_ShouldPreferOverrideToDefault_WhenBothArePresent()
    {
        // Arrange
        var action = "Delete";
        var overrideRuleSet = "OverrideRuleSet";
        var defaultRuleSet = "DefaultRuleSet";

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            [new ResourceAction(action, null, overrideRuleSet)]);

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            ValidationRuleSetName = defaultRuleSet
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBe(overrideRuleSet);
    }

    [Test]
    public void GetValidationRuleSetName_ShouldReturnFirstNonEmptyRuleSetName_WhenMultipleDefaultRuleSetsPresent()
    {
        // Arrange
        var action = "Read";
        var firstRuleSet = "FirstRuleSet";
        var secondRuleSet = "SecondRuleSet";

        var defaultClaimMetadata1 = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim1",
            ValidationRuleSetName = firstRuleSet
        };

        var defaultClaimMetadata2 = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim2",
            ValidationRuleSetName = secondRuleSet
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
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBe(firstRuleSet);
    }

    [Test]
    public void GetValidationRuleSetName_ShouldReturnDefaultRuleSetName_WhenOverrideIsEmpty_AndDefaultIsPresent()
    {
        // Arrange
        var action = "Update";
        var defaultRuleSet = "DefaultRuleSet";

        var claimSetMetadata = new ClaimSetResourceClaimMetadata(
            "ResourceClaim",
            [new ResourceAction(action, null, "")]);

        var defaultClaimMetadata = new DefaultResourceClaimMetadata
        {
            ClaimName = "ResourceClaim",
            ValidationRuleSetName = defaultRuleSet
        };

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            RequestedAction = action,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> { claimSetMetadata },
            DefaultResourceClaimLineage = new List<DefaultResourceClaimMetadata> { defaultClaimMetadata }
        };

        // Act
        var result = _selector.GetValidationRuleSetName(requestEvaluation);

        // Assert
        result.ShouldBe(defaultRuleSet);
    }
}
