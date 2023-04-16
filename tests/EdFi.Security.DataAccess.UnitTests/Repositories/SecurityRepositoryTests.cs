// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;

namespace EdFi.Security.DataAccess.UnitTests.Repositories;

using System.Collections.Generic;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

[TestFixture]
public class SecurityRepositoryTests
{
    private ISecurityTableGateway _securityTableGateway;
    private SecurityRepository _securityRepository;

    [SetUp]
    public void SetUp()
    {
        _securityTableGateway = A.Fake<ISecurityTableGateway>();
        _securityRepository = new SecurityRepository(_securityTableGateway);
    }

    [Test]
    public void GetActionByName_ReturnsCorrectAction_WhenActionExists()
    {
        // Arrange
        var actionName = "TestAction";
        var action = new Action { ActionName = actionName };
        A.CallTo(() => _securityTableGateway.GetActions()).Returns(new List<Action> { action });

        // Act
        var result = _securityRepository.GetActionByName(actionName);

        // Assert
        result.ShouldBe(action);
    }

    [Test]
    public void GetActionByName_ThrowsException_WhenActionDoesNotExist()
    {
        // Arrange
        var actionName = "TestAction";
        var action = new Action { ActionName = actionName };
        A.CallTo(() => _securityTableGateway.GetActions()).Returns(new List<Action> { action });

        // Act & Assert
        Should.Throw<System.InvalidOperationException>(() => _securityRepository.GetActionByName("Not an action"));
    }

    [Test]
    public void GetAuthorizationStrategyByName_ReturnsCorrectAuthorizationStrategy_WhenAuthorizationStrategyExists()
    {
        // Arrange
        var authorizationStrategyName = "TestAuthorizationStrategy";
        var authorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName = authorizationStrategyName };

        A.CallTo(() => _securityTableGateway.GetAuthorizationStrategies(A<int>.Ignored))
            .Returns(new List<AuthorizationStrategy> { authorizationStrategy });

        // Act
        var result = _securityRepository.GetAuthorizationStrategyByName(authorizationStrategyName);

        // Assert
        result.ShouldBe(authorizationStrategy);
    }

    [Test]
    public void GetAuthorizationStrategyByName_ThrowsException_WhenAuthorizationStrategyDoesNotExist()
    {
        // Arrange
        var authorizationStrategyName = "TestAuthorizationStrategy";
        var authorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName = authorizationStrategyName };

        A.CallTo(() => _securityTableGateway.GetAuthorizationStrategies(A<int>.Ignored))
            .Returns(new List<AuthorizationStrategy> { authorizationStrategy });

        // Act & Assert
        Should.Throw<System.InvalidOperationException>(
            () => _securityRepository.GetAuthorizationStrategyByName("Non-existing authorization"));
    }

    [Test]
    public void GetClaimsForClaimSet_ReturnsCorrectClaimSetResourceClaimActions_WhenClaimSetExists()
    {
        // Arrange
        var claimSetName = "TestClaimSet";

        var claimSetResourceClaimAction =
            new ClaimSetResourceClaimAction { ClaimSet = new ClaimSet { ClaimSetName = claimSetName } };

        A.CallTo(() => _securityTableGateway.GetClaimSetResourceClaimActions(A<int>.Ignored))
            .Returns(new List<ClaimSetResourceClaimAction> { claimSetResourceClaimAction });

        // Act
        var result = _securityRepository.GetClaimsForClaimSet(claimSetName);

        // Assert
        result.ShouldContain(claimSetResourceClaimAction);
    }

    [Test]
    public void GetClaimsForClaimSet_ReturnsEmptyList_WhenClaimSetDoesNotExist()
    {
        // Arrange
        var claimSetName = "TestClaimSet";

        var claimSetResourceClaimAction =
            new ClaimSetResourceClaimAction { ClaimSet = new ClaimSet { ClaimSetName = claimSetName } };

        A.CallTo(() => _securityTableGateway.GetClaimSetResourceClaimActions(A<int>.Ignored))
            .Returns(new List<ClaimSetResourceClaimAction> { claimSetResourceClaimAction });

        // Act
        var result = _securityRepository.GetClaimsForClaimSet("Non-existing claim set");

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GetResourceClaimLineage_ShouldReturnLineageForValidResourceClaim()
    {
        // Arrange
        const string resourceClaimUri = "uri";

        var resourceClaim = new ResourceClaim { ClaimName = resourceClaimUri };
        var parentResourceClaim = new ResourceClaim { ClaimName = "parentUri" };
        resourceClaim.ParentResourceClaim = parentResourceClaim;

        A.CallTo(() => _securityTableGateway.GetResourceClaims(A<int>._))
            .Returns(new List<ResourceClaim> { parentResourceClaim, resourceClaim });

        // Act
        var lineage = _securityRepository.GetResourceClaimLineage(resourceClaimUri).ToList();

        // Assert
        lineage.ShouldSatisfyAllConditions(
            // Should contain lineage going UP the hierarchy
            () => lineage.Count().ShouldBe(2),
            () => lineage[0].ShouldBe(resourceClaim.ClaimName),
            () => lineage[1].ShouldBe(parentResourceClaim.ClaimName));
    }

    [Test]
    public void GetResourceClaimLineage_ShouldReturnEmptyListForInvalidResourceClaim()
    {
        // Arrange
        const string resourceClaimUri = "uri";

        var resourceClaim = new ResourceClaim { ClaimName = resourceClaimUri };

        A.CallTo(() => _securityTableGateway.GetResourceClaims(A<int>._))
            .Returns(new List<ResourceClaim> { resourceClaim });

        // Act
        var lineage = _securityRepository.GetResourceClaimLineage("Not-an-existing-resource-claim");

        // Assert
        lineage.ShouldBeEmpty();
    }

    [Test]
    public void GetResourceClaimLineageMetadata_ShouldReturnMetadataForValidResourceClaimAndAction()
    {
        // Arrange
        const string resourceClaimUri = "uri";
        const string action = "action";

        var resourceClaim = new ResourceClaim { ClaimName = resourceClaimUri };
        var actionStrategy = new ResourceClaimAction { Action = new Action { ActionUri = action }, ResourceClaim = resourceClaim };

        A.CallTo(() => _securityTableGateway.GetResourceClaims(A<int>._))
            .Returns(new List<ResourceClaim> { resourceClaim });

        A.CallTo(() => _securityTableGateway.GetResourceClaimActionAuthorizations(A<int>._))
            .Returns(new List<ResourceClaimAction> { actionStrategy });

        // Act
        var metadata = _securityRepository.GetResourceClaimLineageMetadata(resourceClaimUri, action);

        // Assert
        metadata.Count().ShouldBe(1);
        metadata.First().ShouldBe(actionStrategy);
    }

    [Test]
    public void GetResourceClaimLineageMetadata_ShouldReturnEmptyListForInvalidResourceClaim()
    {
        // Arrange
        const string resourceClaimUri = "uri";
        const string action = "action";

        A.CallTo(() => _securityTableGateway.GetResourceClaims(A<int>._))
            .Returns(new List<ResourceClaim>());

        // Act
        var metadata = _securityRepository.GetResourceClaimLineageMetadata(resourceClaimUri, action);

        // Assert
        metadata.ShouldBeEmpty();
    }

    [Test]
    public void GetResourceClaimLineageMetadata_WithExactMatch_ReturnsMatch()
    {
        // Arrange
        var securityTableGateway = A.Fake<ISecurityTableGateway>();
        var repository = new SecurityRepository(securityTableGateway);

        var suppliedResourceClaimUri = "urn:some:resource";
        var suppliedActionUri = "read";

        var otherResourceClaimAction = new ResourceClaimAction
        {
            ResourceClaim = new ResourceClaim { ClaimName = suppliedResourceClaimUri + ":other" },
            Action = new Action { ActionUri = suppliedActionUri }
        };

        var suppliedResourceClaimAction = new ResourceClaimAction
        {
            ResourceClaim = new ResourceClaim { ClaimName = suppliedResourceClaimUri },
            Action = new Action { ActionUri = suppliedActionUri }
        };

        A.CallTo(() => securityTableGateway.GetApplication())
            .Returns(new Application { ApplicationId = 1 });
        
        A.CallTo(() => securityTableGateway.GetResourceClaimActionAuthorizations(1))
            .Returns(new List<ResourceClaimAction> { otherResourceClaimAction, suppliedResourceClaimAction });

        // Act
        var result = repository.GetResourceClaimLineageMetadata(suppliedResourceClaimUri, suppliedActionUri)
            .ToArray();

        // Assert
        result.Length.ShouldBe(1);
        result.ShouldContain(suppliedResourceClaimAction);
    }

    [Test]
    public void GetResourceClaimLineageMetadata_WithParentResource_ReturnsMatchWithLineage()
    {
        // Arrange
        var securityTableGateway = A.Fake<ISecurityTableGateway>();
        var repository = new SecurityRepository(securityTableGateway);

        var suppliedParentResourceClaimUri = "urn:some:resource:parent";
        var suppliedChildResourceClaimUri = "urn:some:resource:child";
        var suppliedOtherResourceClaimUri = "urn:some:resource:other";
        var suppliedActionUri = "read";

        var otherResourceClaim = new ResourceClaim
        {
            ClaimName = suppliedOtherResourceClaimUri,
        };

        var suppliedOtherResourceClaimAction = new ResourceClaimAction
        {
            ResourceClaim = otherResourceClaim,
            Action = new Action { ActionUri = suppliedActionUri }
        };
        
        var parentResourceClaim = new ResourceClaim
        {
            ClaimName = suppliedParentResourceClaimUri,
        };

        var childResourceClaim = new ResourceClaim
        {
            ClaimName = suppliedChildResourceClaimUri,
            ParentResourceClaim = parentResourceClaim,
        };

        var suppliedParentResourceClaimAction = new ResourceClaimAction
        {
            ResourceClaim = parentResourceClaim,
            Action = new Action { ActionUri = suppliedActionUri }
        };
        
        var suppliedChildResourceClaimAction = new ResourceClaimAction
        {
            ResourceClaim = childResourceClaim,
            Action = new Action { ActionUri = suppliedActionUri }
        };

        A.CallTo(() => securityTableGateway.GetApplication()).Returns(new Application() { ApplicationId = 1});
        
        A.CallTo(() => securityTableGateway.GetResourceClaimActionAuthorizations(1))
            .Returns(new List<ResourceClaimAction> { suppliedParentResourceClaimAction, suppliedChildResourceClaimAction, suppliedOtherResourceClaimAction });
        
        A.CallTo(() => securityTableGateway.GetResourceClaims(1))
            .Returns(new List<ResourceClaim> { otherResourceClaim, parentResourceClaim, childResourceClaim });

        // Act
        var result = repository.GetResourceClaimLineageMetadata(suppliedChildResourceClaimUri, suppliedActionUri)
            .ToArray();

        // Assert
        result.Length.ShouldBe(2);
        result[0].ShouldBe(suppliedChildResourceClaimAction);
        result[1].ShouldBe(suppliedParentResourceClaimAction);
    }

    [Test]
    public void GetResourceByResourceName_WithMatchingResourceName_ReturnsResourceClaim()
    {
        // Arrange
        var securityTableGateway = A.Fake<ISecurityTableGateway>();
        var repository = new SecurityRepository(securityTableGateway);

        var resourceName = "Some Resource";
        var resourceClaim = new ResourceClaim { ResourceName = resourceName };
        
        var otherResourceName = "Other Resource";
        var otherResourceClaim = new ResourceClaim { ResourceName = otherResourceName };

        A.CallTo(() => securityTableGateway.GetApplication()).Returns(new Application() { ApplicationId = 1});
        A.CallTo(() => securityTableGateway.GetResourceClaims(1))
            .Returns(new List<ResourceClaim> { otherResourceClaim, resourceClaim });

        // Act
        var result = repository.GetResourceByResourceName(resourceName);

        // Assert
        result.ShouldBe(resourceClaim);
    }
    
    // GetResourceClaimLineage
    // GetResourceClaimLineageMetadata
    
    // GetApplication
    // GetClaimSets
    // GetResourceClaims
    // GetResourceClaimActionsAuthorizations
}