// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

// using EdFi.Ods.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Claims;

[TestFixture]
public class ClaimsIdentityProviderTests
{
    private IApiClientContextProvider _apiClientContextProvider;
    private ISecurityRepository _securityRepository;
    private ClaimsIdentityProvider _identityProvider;

    [SetUp]
    public void SetUp()
    {
        _apiClientContextProvider = A.Fake<IApiClientContextProvider>();
        _securityRepository = A.Fake<ISecurityRepository>();

        _identityProvider = new ClaimsIdentityProvider(_apiClientContextProvider, _securityRepository);
    }

    [Test]
    public void GetClaimsIdentity_ApiClientContextIsNull_ShouldThrowEdFiSecurityException()
    {
        // Arrange
        A.CallTo(() => _apiClientContextProvider.GetApiClientContext()).Returns(null);

        // Act & Assert
        Should.Throw<EdFiSecurityException>(() => _identityProvider.GetClaimsIdentity())
            .Message.ShouldBe("No API key information was available for authorization.");
    }

    [Test]
    public void GetClaimsIdentity_ApiClientContextIsEmpty_ShouldThrowEdFiSecurityException()
    {
        // Arrange
        A.CallTo(() => _apiClientContextProvider.GetApiClientContext()).Returns(ApiClientContext.Empty);

        // Act & Assert
        Should.Throw<EdFiSecurityException>(() => _identityProvider.GetClaimsIdentity())
            .Message.ShouldBe("No API key information was available for authorization.");
    }

    [Test]
    public void GetClaimsIdentity_ApiClientContextIsInitialized_CallsThroughToGetClaimsIdentityWithClaimSetName_ReturnsClaimsIdentityWithServiceClaims()
    {
        // Arrange
        const string claimSetName = "claimSet1";
        var apiClientContext = CreateApiClientContext(claimSetName);
        A.CallTo(() => _apiClientContextProvider.GetApiClientContext()).Returns(apiClientContext);
    
        A.CallTo(() => _securityRepository.GetClaimsForClaimSet(claimSetName))
            .Returns(CreateDummyClaimSetResourceClaimsActions());
    
        // Act
        var result = _identityProvider.GetClaimsIdentity();
    
        // Assert
        result.ShouldNotBeNull();
        result.Claims.ShouldNotBeEmpty();
        result.Claims.ShouldAllBe(c => c.Type.StartsWith(EdFiOdsApiClaimTypes.ServicesPrefix));
        result.Claims.Count().ShouldBe(1);
        result.AuthenticationType.ShouldBe(EdFiAuthenticationTypes.OAuth);
    }

    [Test]
    public void GetClaimsIdentityWithClaimSetName_ReturnsClaimsIdentityWithServiceClaims()
    {
        // Arrange
        const string claimSetName = "claimSet1";
        var apiClientContext = CreateApiClientContext(claimSetName);
        A.CallTo(() => _apiClientContextProvider.GetApiClientContext()).Returns(apiClientContext);

        var resourceClaimsActions = CreateDummyClaimSetResourceClaimsActions();
        A.CallTo(() => _securityRepository.GetClaimsForClaimSet(claimSetName))
            .Returns(resourceClaimsActions);

        // Act
        var result = _identityProvider.GetClaimsIdentity(claimSetName);

        // Assert
        result.ShouldNotBeNull();
        result.Claims.ShouldNotBeEmpty();
        result.Claims.ShouldAllBe(c => c.Type.StartsWith(EdFiOdsApiClaimTypes.ServicesPrefix));
        result.Claims.Count().ShouldBe(1);
        result.AuthenticationType.ShouldBe(EdFiAuthenticationTypes.OAuth);
    }
    
    [Test]
    public void GetClaimsIdentityWithClaimSetName_Twice_ReturnsClaimsIdentityWithSameServiceClaimsInstance()
    {
        // Arrange
        const string claimSetName = "claimSet1";
        var apiClientContext = CreateApiClientContext(claimSetName);
        A.CallTo(() => _apiClientContextProvider.GetApiClientContext()).Returns(apiClientContext);

        var resourceClaimsActions = CreateDummyClaimSetResourceClaimsActions();
        A.CallTo(() => _securityRepository.GetClaimsForClaimSet(claimSetName))
            .Returns(resourceClaimsActions);

        // Act
        var result1 = _identityProvider.GetClaimsIdentity(claimSetName);
        var result2 = _identityProvider.GetClaimsIdentity(claimSetName);

        // Assert
        result1.ShouldNotBeNull();
        result1.Claims.ShouldNotBeEmpty();
        result1.Claims.ShouldAllBe(c => c.Type.StartsWith(EdFiOdsApiClaimTypes.ServicesPrefix));
        result1.Claims.Count().ShouldBe(1);
        result1.AuthenticationType.ShouldBe(EdFiAuthenticationTypes.OAuth);
        result2.Claims.ShouldBeEquivalentTo(result1.Claims);
    }

    private ApiClientContext CreateApiClientContext(string claimSetName)
    {
        return new ApiClientContext(
            null,
            claimSetName,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            1);
    }
    
    private static IList<ClaimSetResourceClaimAction> CreateDummyClaimSetResourceClaimsActions()
    {
        return new List<ClaimSetResourceClaimAction>
        {
            new()
            {
                ResourceClaim = new ResourceClaim() { ClaimName = "http://ed-fi.org/ods/identity/claims/domains/claim1" },
                Action = new Action() { ActionId = 1, ActionName = "Create", ActionUri = "http://ed-fi.org/odsapi/actions/create" },
            },
            new()
            {
                ResourceClaim = new ResourceClaim() { ClaimName = "http://ed-fi.org/ods/identity/claims/services/claim1" },
                Action = new Action() { ActionId = 1, ActionName = "Create", ActionUri = "http://ed-fi.org/odsapi/actions/create" },
            },
            new()
            {
                ResourceClaim = new ResourceClaim() { ClaimName = "http://ed-fi.org/ods/identity/claims/services/claim1" },
                Action = new Action() { ActionId = 2, ActionName = "Read", ActionUri = "http://ed-fi.org/odsapi/actions/read" },
            },
            new()
            {
                ResourceClaim = new ResourceClaim() { ClaimName = "http://ed-fi.org/ods/identity/claims/domains/ed-fi/claim1" },
                Action = new Action() { ActionId = 1, ActionName = "Create", ActionUri = "http://ed-fi.org/odsapi/actions/create" },
            }
        };
    }
    //
    // private static IReadOnlyList<ResourceClaimAction> CreateDummyResourceClaimsActions()
    // {
    //     return new List<ResourceClaimAction>
    //     {
    //         new ResourceClaimAction(
    //             new ResourceClaim("http://ed-fi.org/ods/identity/claims/services/claim1"),
    //             new ResourceAction("action1", null, null)),
    //         new ResourceClaimAction(
    //             new ResourceClaim("http://ed-fi.org/ods/identity/claims/services/claim1"),
    //             new ResourceAction("action2", null, null)),
    //         new ResourceClaimAction(
    //             new ResourceClaim("http://ed-fi.org/ods/identity/claims/services/claim2"),
    //             new ResourceAction("action1", null, null)),
    //     };
    // }
}
