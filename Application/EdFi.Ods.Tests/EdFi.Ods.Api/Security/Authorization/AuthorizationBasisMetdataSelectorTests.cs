// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization;

[TestFixture]
public class AuthorizationBasisMetadataSelectorTests
{
    private IResourceAuthorizationMetadataProvider _resourceAuthorizationMetadataProvider;
    private ISecurityRepository _securityRepository;
    private IAuthorizationStrategy[] _suppliedAuthorizationStrategies;
    private IClaimSetClaimsProvider _claimSetClaimsProvider;
    private AuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
    
    private readonly Fake1AuthorizationStrategy _fake1AuthorizationStrategy = new();
    private readonly Fake2AuthorizationStrategy _fake2AuthorizationStrategy = new();
    private ApiClientContext _suppliedApiClientContext;

    private const string SuppliedClaimSetName = "ApiClientClaimSet";

    public enum TestActions
    {
        _,
        Create,
        Read,
        Update,
        Delete,
        ReadChanges
    }

    public enum AuthorizationResult
    {
        Granted,
        Denied,
    }

    [SetUp]
    public void SetUp()
    {
        _resourceAuthorizationMetadataProvider = A.Fake<IResourceAuthorizationMetadataProvider>();
        _securityRepository = A.Fake<ISecurityRepository>();

        A.CallTo(() => _securityRepository.GetActionByName("Create"))
            .Returns(new Action()
            {
                ActionName = "Create",
                ActionUri = "createUri"
            });
        A.CallTo(() => _securityRepository.GetActionByName("Read"))
            .Returns(new Action()
            {
                ActionName = "Read",
                ActionUri = "readUri"
            });
        A.CallTo(() => _securityRepository.GetActionByName("Update"))
            .Returns(new Action()
            {
                ActionName = "Update",
                ActionUri = "updateUri"
            });
        A.CallTo(() => _securityRepository.GetActionByName("Delete"))
            .Returns(new Action()
            {
                ActionName = "Delete",
                ActionUri = "deleteUri"
            });
        A.CallTo(() => _securityRepository.GetActionByName("ReadChanges"))
            .Returns(new Action()
            {
                ActionName = "ReadChanges",
                ActionUri = "readChangesUri"
            });

        _claimSetClaimsProvider = A.Fake<IClaimSetClaimsProvider>();

        _suppliedAuthorizationStrategies = new IAuthorizationStrategy[]
        {
            _fake1AuthorizationStrategy, 
            _fake2AuthorizationStrategy
        };

        _suppliedApiClientContext = new ApiClientContext("API_KEY",
            SuppliedClaimSetName,
            Array.Empty<long>(),
            Array.Empty<string>(),
            Array.Empty<string>(),
            null,
            null,
            Array.Empty<short>(),
            Array.Empty<int>(),
            99);

        _authorizationBasisMetadataSelector = new AuthorizationBasisMetadataSelector(
            _resourceAuthorizationMetadataProvider,
            _securityRepository,
            _suppliedAuthorizationStrategies,
            _claimSetClaimsProvider);
    }

    private static IEnumerable<object[]> GetActionScenarios()
    {
        // Request actions to enumerate
        (string actionUri, TestActions action, int bitValue)[] actionDetails = {
            ("createUri", TestActions.Create, (int) Math.Pow(2, 0)),
            ("readUri", TestActions.Read, (int) Math.Pow(2, 1)),
            ("updateUri", TestActions.Update, (int) Math.Pow(2, 2)),
            ("deleteUri", TestActions.Delete, (int) Math.Pow(2, 3)),
            ("readChangesUri", TestActions.ReadChanges, (int) Math.Pow(2, 4)),
        };
        
        for (int requestActionIndex = 0; requestActionIndex < actionDetails.Length; requestActionIndex++)
        {
            for (int i = 0; i < Math.Pow(2, actionDetails.Length); i++)
            {
                yield return new object[]
                {
                    actionDetails[requestActionIndex].actionUri, 
                    (i & actionDetails[0].bitValue) != 0 ? actionDetails[0].action : TestActions._,
                    (i & actionDetails[1].bitValue) != 0 ? actionDetails[1].action : TestActions._,
                    (i & actionDetails[2].bitValue) != 0 ? actionDetails[2].action : TestActions._, 
                    (i & actionDetails[3].bitValue) != 0 ? actionDetails[3].action : TestActions._,
                    (i & actionDetails[4].bitValue) != 0 ? actionDetails[4].action : TestActions._, 
                    (i & (int) Math.Pow(2, requestActionIndex)) != 0 ? AuthorizationResult.Granted : AuthorizationResult.Denied
                };
            }
        }
    }
    
    [TestCaseSource(nameof(GetActionScenarios))]
    public void SelectAuthorizationBasisMetadata_ClaimAction_MatchingSucceeds_OtherwiseException(
        string requestActionUri,
        TestActions hasCreate,
        TestActions hasRead,
        TestActions hasUpdate,
        TestActions hasDelete,
        TestActions hasReadChanges,
        AuthorizationResult expectedAuthorizationResult)
    {
        A.CallTo(() => _claimSetClaimsProvider.GetClaims("AssignedClaimSet"))
            .Returns(
                new[]
                {
                    new EdFiResourceClaim(
                        "resourceClaimUri2",
                        Actions(
                            create: hasCreate == TestActions.Create,
                            read: hasRead == TestActions.Read,
                            update: hasUpdate == TestActions.Update,
                            delete: hasDelete == TestActions.Delete,
                            readChanges: hasReadChanges == TestActions.ReadChanges))
                });

        // Arrange
        var suppliedAuthorizationMetadata = new List<ResourceClaimAuthorizationMetadata>
        {
            new()
            {
                ClaimName = "resourceClaimUri2",
                AuthorizationStrategies = new List<string> { "fake2" }
            }
        };

        A.CallTo(() =>  
                _resourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(
                        "resourceClaimUri2", requestActionUri))
            .Returns(suppliedAuthorizationMetadata);

        var requestResourceClaimUris = new[]
        {
            "resourceClaimUri1",
            "resourceClaimUri2",
        };

        // Choose Act/Assert path based on expected authorization result (Granted or Denied)
        if (expectedAuthorizationResult == AuthorizationResult.Granted)
        {
            // Act
            var result = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                "AssignedClaimSet",
                requestResourceClaimUris,
                requestActionUri);

            // Assert
            result.ShouldSatisfyAllConditions(
                _ => _.ShouldNotBeNull(),
                _ => _.AuthorizationStrategies.ShouldNotBeNull(),
                _ => _.AuthorizationStrategies.ShouldContain(_fake2AuthorizationStrategy),
                _ => _.RelevantClaim.ClaimName.ShouldBe("resourceClaimUri2"),
                _ => _.RelevantClaim.ClaimValue.Actions.ShouldContain(a => a.Name == requestActionUri));
        }
        else
        {
            // Act & Assert
            var exception = Should.Throw<SecurityAuthorizationException>(() => _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                    "AssignedClaimSet",
                    requestResourceClaimUris,
                    requestActionUri));

            exception.Detail.ShouldContain($"Access to the data could not be authorized. You do not have permissions to perform the requested operation on the data.");
            exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:access-denied:action"));
            exception.Message.ShouldContain($"The API client's assigned claim set (currently 'AssignedClaimSet') must grant permission of the '{requestActionUri}' action on one of the following data claims: 'resourceClaimUri2'.");
        }
    }

    private static EdFiResourceClaimValue Actions(bool create = false, bool read = false, bool update = false, bool delete = false, bool readChanges = false)
    {
        var resourceActions = new List<ResourceAction>();
    
        if (create)
        {
            resourceActions.Add(new ResourceAction("createUri"));
        }
        
        if (read)
        {
            resourceActions.Add(new ResourceAction("readUri"));
        }
        
        if (update)
        {
            resourceActions.Add(new ResourceAction("updateUri"));
        }
        
        if (delete)
        {
            resourceActions.Add(new ResourceAction("deleteUri"));
        }
        
        if (readChanges)
        {
            resourceActions.Add(new ResourceAction("readChangesUri"));
        }

        return new EdFiResourceClaimValue() { Actions = resourceActions.ToArray() };
    }

    private class Fake1AuthorizationStrategy : IAuthorizationStrategy
    {
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext)
            => new();
    }

    private class Fake2AuthorizationStrategy : IAuthorizationStrategy
    {
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext)
            => new();
    }
}
