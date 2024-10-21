// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class AuthorizationBasisMetadataSelectorTests
{
    [SetUp]
    public void SetUp()
    {
        _authorizationStrategyResolver = A.Fake<IAuthorizationStrategyResolver>();
        _claimSetRequestEvaluator = A.Fake<IClaimSetRequestEvaluator>();
        _requestEvaluationStrategiesSelector = A.Fake<IRequestEvaluationStrategiesSelector>();
        _requestEvaluationValidationRuleSetSelector = A.Fake<IRequestEvaluationValidationRuleSetSelector>();

        _selector = new AuthorizationBasisMetadataSelector(
            _authorizationStrategyResolver,
            _claimSetRequestEvaluator,
            _requestEvaluationStrategiesSelector,
            _requestEvaluationValidationRuleSetSelector);
    }

    private AuthorizationBasisMetadataSelector _selector;
    private IAuthorizationStrategyResolver _authorizationStrategyResolver;
    private IClaimSetRequestEvaluator _claimSetRequestEvaluator;
    private IRequestEvaluationStrategiesSelector _requestEvaluationStrategiesSelector;
    private IRequestEvaluationValidationRuleSetSelector _requestEvaluationValidationRuleSetSelector;

    [Test]
    public void SelectAuthorizationBasisMetadata_ShouldReturnMetadata_WhenEvaluationSucceeds()
    {
        // Arrange
        var claimSetName = "TestClaimSet";
        var resourceClaimUris = new List<string> { "Resource1" };
        var action = "Read";

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            Success = true,
            RequestedAction = action,
            RequestedResourceUris = resourceClaimUris,
            ClaimSetResourceClaimLineage =
                new List<ClaimSetResourceClaimMetadata> { new("ResourceClaim1", new ResourceAction[] { new(action) }) }
        };

        var authorizationStrategies = new List<IAuthorizationStrategy> { A.Fake<IAuthorizationStrategy>() };
        IReadOnlyList<string> authorizationStrategyNames = new List<string> { "Strategy1" };
        var validationRuleSetName = "RuleSet1";

        A.CallTo(() => _claimSetRequestEvaluator.EvaluateRequest(claimSetName, resourceClaimUris, action))
            .Returns(requestEvaluation);

        A.CallTo(
                () => _requestEvaluationStrategiesSelector.TryGetAuthorizationStrategyNames(
                    requestEvaluation,
                    out authorizationStrategyNames))
            .Returns(true);

        A.CallTo(() => _authorizationStrategyResolver.GetAuthorizationStrategies(authorizationStrategyNames))
            .Returns(authorizationStrategies);

        A.CallTo(() => _requestEvaluationValidationRuleSetSelector.GetValidationRuleSetName(requestEvaluation))
            .Returns(validationRuleSetName);

        // Act
        var result = _selector.SelectAuthorizationBasisMetadata(claimSetName, resourceClaimUris, action);

        // Assert
        result.ShouldNotBeNull();
        result.AuthorizationStrategies.ShouldBe(authorizationStrategies);
        result.RelevantClaim.ClaimName.ShouldBe("ResourceClaim1");
        result.ValidationRuleSetName.ShouldBe(validationRuleSetName);
    }

    [Test]
    public void SelectAuthorizationBasisMetadata_ShouldThrowException_WhenEvaluationFails()
    {
        // Arrange
        var claimSetName = "TestClaimSet";
        var resourceClaimUris = new List<string> { "Resource1" };
        var action = "Create";

        var exception = new SecurityAuthorizationException("Authorization failed.", "An error.");

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            Success = false,
            SecurityException = exception
        };

        A.CallTo(() => _claimSetRequestEvaluator.EvaluateRequest(claimSetName, resourceClaimUris, action))
            .Returns(requestEvaluation);

        // Act & Assert
        var ex = Should.Throw<SecurityAuthorizationException>(
            () => _selector.SelectAuthorizationBasisMetadata(claimSetName, resourceClaimUris, action));

        ex.ShouldBe(exception);
    }

    [Test]
    public void SelectAuthorizationBasisMetadata_ShouldThrowException_WhenNoAuthorizationStrategiesDefined()
    {
        // Arrange
        var claimSetName = "TestClaimSet";
        var resourceClaimUris = new List<string> { "Resource1" };
        var action = "Update";

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            Success = true,
            RequestedAction = action,
            RequestedResourceUris = resourceClaimUris,
            ClaimSetResourceClaimLineage =
                new List<ClaimSetResourceClaimMetadata> { new("ResourceClaim1", new ResourceAction[] { new(action) }) }
        };

        IReadOnlyList<string> authorizationStrategyNames = new List<string>();

        A.CallTo(() => _claimSetRequestEvaluator.EvaluateRequest(claimSetName, resourceClaimUris, action))
            .Returns(requestEvaluation);

        A.CallTo(
                () => _requestEvaluationStrategiesSelector.TryGetAuthorizationStrategyNames(
                    requestEvaluation,
                    out authorizationStrategyNames))
            .Returns(false);

        // Act & Assert
        var ex = Should.Throw<SecurityConfigurationException>(
            () => _selector.SelectAuthorizationBasisMetadata(claimSetName, resourceClaimUris, action));

        ex.Message.ShouldContain(
            "No authorization strategies were defined for the requested action 'Update' against resource URIs ['Resource1']");
    }
    
    [Test]
    public void SelectAuthorizationBasisMetadata_ShouldReturnMetadataWithNullValidationRuleSetName_WhenNoValidationRuleSetNameReturned()
    {
        // Arrange
        var claimSetName = "TestClaimSet";
        var resourceClaimUris = new List<string> { "Resource1" };
        var action = "Read";

        var requestEvaluation = new ClaimSetRequestEvaluation
        {
            Success = true,
            RequestedAction = action,
            RequestedResourceUris = resourceClaimUris,
            ClaimSetResourceClaimLineage = new List<ClaimSetResourceClaimMetadata> 
            { 
                new("ResourceClaim1", new ResourceAction[] { new(action) }) 
            }
        };

        var authorizationStrategies = new List<IAuthorizationStrategy> { A.Fake<IAuthorizationStrategy>() };
        IReadOnlyList<string> authorizationStrategyNames = new List<string> { "Strategy1" };

        A.CallTo(() => _claimSetRequestEvaluator.EvaluateRequest(claimSetName, resourceClaimUris, action)).Returns(requestEvaluation);
        A.CallTo(() => _requestEvaluationStrategiesSelector.TryGetAuthorizationStrategyNames(requestEvaluation, out authorizationStrategyNames)).Returns(true);
        A.CallTo(() => _authorizationStrategyResolver.GetAuthorizationStrategies(authorizationStrategyNames)).Returns(authorizationStrategies);
        A.CallTo(() => _requestEvaluationValidationRuleSetSelector.GetValidationRuleSetName(requestEvaluation)).Returns(null);

        // Act
        var result = _selector.SelectAuthorizationBasisMetadata(claimSetName, resourceClaimUris, action);

        // Assert
        result.ShouldNotBeNull();
        result.AuthorizationStrategies.ShouldBe(authorizationStrategies);
        result.RelevantClaim.ClaimName.ShouldBe("ResourceClaim1");
        result.ValidationRuleSetName.ShouldBeNull(); // Assert that the validation rule set name is null
    }
}
