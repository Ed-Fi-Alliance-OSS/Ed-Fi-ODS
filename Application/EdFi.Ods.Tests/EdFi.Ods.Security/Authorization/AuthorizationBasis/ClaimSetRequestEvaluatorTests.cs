// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[TestFixture]
public class ClaimSetRequestEvaluatorTests
{
    [SetUp]
    public void SetUp()
    {
        _claimSetClaimsProvider = A.Fake<IClaimSetClaimsProvider>();
        _authorizationContextValidator = A.Fake<IAuthorizationContextValidator>();
        _lineageProvider = A.Fake<IResourceClaimAuthorizationMetadataLineageProvider>();
        _actionBitValueProvider = A.Fake<IActionBitValueProvider>();

        A.CallTo(() => _actionBitValueProvider.GetBitValue("Create")).Returns(CreateBitValue);
        A.CallTo(() => _actionBitValueProvider.GetBitValue("Read")).Returns(ReadBitValue);
        A.CallTo(() => _actionBitValueProvider.GetBitValue("Update")).Returns(UpdateBitValue);
        A.CallTo(() => _actionBitValueProvider.GetBitValue("Delete")).Returns(DeleteBitValue);

        _evaluator = new ClaimSetRequestEvaluator(
            _claimSetClaimsProvider,
            _authorizationContextValidator,
            _lineageProvider,
            _actionBitValueProvider);
    }

    private ClaimSetRequestEvaluator _evaluator;
    private IClaimSetClaimsProvider _claimSetClaimsProvider;
    private IAuthorizationContextValidator _authorizationContextValidator;
    private IResourceClaimAuthorizationMetadataLineageProvider _lineageProvider;
    private IActionBitValueProvider _actionBitValueProvider;

    private const int CreateBitValue = 1;
    private const int ReadBitValue = 2;
    private const int UpdateBitValue = 4;
    private const int DeleteBitValue = 8;

    [Test]
    public void EvaluateRequest_ShouldReturnSuccessfulEvaluation_WhenClaimSetAndActionMatch()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Read";
        var resourceClaimUri = "ResourceClaimUri";

        var claimSetLineage = new List<ClaimSetResourceClaimMetadata>
        {
            new(resourceClaimUri, [new(action)])
        };

        var defaultLineage = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ChildResourceClaimUri" },
            new() { ClaimName = resourceClaimUri },
            new() { ClaimName = "ParentResourceClaimUri" },
        };

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(claimSetLineage);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action)).Returns(defaultLineage);

        // Act
        var result = _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action);

        // Assert
        result.Success.ShouldBeTrue();
        result.ClaimSetResourceClaimLineage.ShouldBeEquivalentTo(CreateList(claimSetLineage[0]));
        result.DefaultResourceClaimLineage.ShouldBe(defaultLineage);
        result.SecurityException.ShouldBeNull();
    }

    [Test]
    public void EvaluateRequest_ShouldReturnFailedEvaluation_WhenClaimSetHasNoMatchingResourceClaims()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Read";
        var resourceClaimUri = "ResourceClaimUri";

        var claimSetSecurityMetadata = new List<ClaimSetResourceClaimMetadata>
        {
            new("NonMatchingClaimUri1", [new(action)]),
            new("NonMatchingClaimUri2", [new(action)])
        };

        var defaultLineage = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ResourceClaimUri" },
            new() { ClaimName = "ParentClaimUri" },
            new() { ClaimName = "GrandparentClaimUri" },
        };

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(claimSetSecurityMetadata);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action)).Returns(defaultLineage);

        // Act
        var result = _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action);

        // Assert
        result.Success.ShouldBeFalse();
        result.ClaimSetResourceClaimLineage.ShouldBeNull();
        result.DefaultResourceClaimLineage.ShouldBeNull();
        
        var problemDetails = result.SecurityException as IEdFiProblemDetails; 
        problemDetails.Errors[0].ShouldBe($"The API client's assigned claim set (currently '{claimSetName}') must include one of the following resource claims to provide access to this resource: 'ResourceClaimUri', 'ParentClaimUri', 'GrandparentClaimUri'.");
        problemDetails.Type.ShouldBe("urn:ed-fi:api:security:authorization:access-denied:resource");
    }

    [Test]
    public void EvaluateRequest_ShouldReturnFailedEvaluation_WhenClaimSetHasNoMatchingActionsForResourceClaimLineage()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Delete";
        var resourceClaimUri = "ResourceClaimUri";

        var claimSetSecurityMetadata = new List<ClaimSetResourceClaimMetadata>
        {
            new("ResourceClaimUri", [new("Create"), new("Read")]),
            new("NotInLineageClaimUri", [new("Update"), new("Delete")])
        };

        var defaultLineage = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ResourceClaimUri" },
            new() { ClaimName = "ParentClaimUri" },
            new() { ClaimName = "GrandparentClaimUri" },
        };

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(claimSetSecurityMetadata);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action)).Returns(defaultLineage);

        // Act
        var result = _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action);

        // Assert
        result.Success.ShouldBeFalse();
        result.ClaimSetResourceClaimLineage.ShouldBeNull();
        result.DefaultResourceClaimLineage.ShouldBeNull();

        var problemDetails = result.SecurityException as IEdFiProblemDetails; 
        problemDetails.Errors[0].ShouldBe($"The API client's assigned claim set (currently '{claimSetName}') must grant permission of the '{action}' action on one of the following resource claims: 'ResourceClaimUri', 'ParentClaimUri', 'GrandparentClaimUri'.");
        problemDetails.Type.ShouldBe("urn:ed-fi:api:security:authorization:access-denied:action");
    }

    [Test]
    public void EvaluateRequest_ShouldReturnSuccessfulEvaluation_WhenClaimSetHasMatchingActionForAncestorResourceClaim()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Delete";
        var resourceClaimUri = "ResourceClaimUri";

        var claimSetSecurityMetadata = new List<ClaimSetResourceClaimMetadata>
        {
            new("ResourceClaimUri", [new("Create"), new("Read")]),
            new("ParentClaimUri", [new("Update"), new("Delete")]), // This grants access
            new("GrandparentClaimUri", [new("Delete")]), // Also grants access
            new("NotInLineageClaimUri", [new("Update"), new("Delete")])
        };

        var defaultLineage = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ResourceClaimUri" },
            new() { ClaimName = "ParentClaimUri" },
            new() { ClaimName = "GrandparentClaimUri" },
        };

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(claimSetSecurityMetadata);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action)).Returns(defaultLineage);

        // Act
        var result = _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action);

        // Assert
        result.Success.ShouldBeTrue();
        
        result.ClaimSetResourceClaimLineage.ShouldBeEquivalentTo(
            CreateList(claimSetSecurityMetadata[1], claimSetSecurityMetadata[2])); // 0 and 3 are excluded
        
        result.DefaultResourceClaimLineage.ShouldBe(defaultLineage);
        result.SecurityException.ShouldBeNull();
    }

    [Test]
    public void EvaluateRequest_ShouldThrowException_WhenActionIsNotAllowed()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Delete";
        var resourceClaimUri = "ResourceClaimUri";

        var claimSetClaimLineage = new List<ClaimSetResourceClaimMetadata>
        {
            new(resourceClaimUri, [new("Read")])
        };

        var defaultClaimLineage = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = resourceClaimUri }
        };

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(claimSetClaimLineage);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action)).Returns(defaultClaimLineage);

        // Act
        var result = _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action);

        // Assert
        result.Success.ShouldBeFalse();
        result.SecurityException.ShouldNotBeNull();
        result.SecurityException.Message.ShouldBe("The API client's assigned claim set (currently 'ExampleClaimSet') must grant permission of the 'Delete' action on one of the following resource claims: 'ResourceClaimUri'.");
    }

    [Test]
    public void EvaluateRequest_ShouldThrowSecurityConfigurationException_WhenResourceClaimUriHasNoSecurityMetadataDefined()
    {
        // Arrange
        var claimSetName = "InvalidClaimSet";
        var action = "Create";
        var resourceClaimUri = "NonexistentResourceClaimUri";

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(claimSetName)).Returns(new List<ClaimSetResourceClaimMetadata>());

        A.CallTo(() => _lineageProvider.GetAuthorizationLineage(resourceClaimUri, action))
            .Returns(new List<DefaultResourceClaimMetadata>());

        // Act / Assert
        var exception = Should.Throw<SecurityConfigurationException>(
            () => _evaluator.EvaluateRequest(claimSetName, new List<string> { resourceClaimUri }, action));

        (exception as IEdFiProblemDetails).Errors.ShouldContain("No security metadata has been configured for this resource.");
    }

    [Test]
    public void EvaluateRequest_ShouldThrowSecurityConfigurationException_WhenSecurityMetadataIsFoundForMultipleResourceClaimUris()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Read";

        var resourceClaimUris = new List<string>
        {
            "ResourceClaimUriWithoutSchema",
            "ResourceClaimUriWithSchema"
        };

        var lineage1 = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ResourceClaimUriWithoutSchema" }
        };

        var lineage2 = new List<DefaultResourceClaimMetadata>
        {
            new() { ClaimName = "ResourceClaimUriWithSchema" }
        };

        A.CallTo(() => _lineageProvider.GetAuthorizationLineage("ResourceClaimUriWithoutSchema", action)).Returns(lineage1);
        A.CallTo(() => _lineageProvider.GetAuthorizationLineage("ResourceClaimUriWithSchema", action)).Returns(lineage2);

        // Act & Assert
        var exception = Should.Throw<SecurityConfigurationException>(() => _evaluator.EvaluateRequest(claimSetName, resourceClaimUris, action));

        (exception as IEdFiProblemDetails).Errors.ShouldContain("Authorization metadata was found for more than one of the supplied resource claims ('ResourceClaimUriWithoutSchema, ResourceClaimUriWithSchema') resulting in an ambiguous basis for authorization.");
    }

    [Test]
    public void EvaluateRequest_ShouldValidateAuthorizationContextFirst()
    {
        // Arrange
        var claimSetName = "ExampleClaimSet";
        var action = "Update";
        var resourceClaimUri = "ResourceClaimUri";

        var resourceClaimUris = new List<string> { resourceClaimUri };

        A.CallTo(() => _authorizationContextValidator.Validate(resourceClaimUris, action)).Throws<Exception>();

        // Act
        Should.Throw<Exception>(() => _evaluator.EvaluateRequest(claimSetName, resourceClaimUris, action));

        // Assert
        A.CallTo(() => _authorizationContextValidator.Validate(A<IList<string>>._, A<string>._)).MustHaveHappenedOnceExactly();
    }

    private List<ClaimSetResourceClaimMetadata> CreateList(params ClaimSetResourceClaimMetadata[] entries)
    {
        return new List<ClaimSetResourceClaimMetadata>(entries);
    }
}
