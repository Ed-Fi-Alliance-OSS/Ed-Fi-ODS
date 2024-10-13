// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Api.Security.Authorization.EntityAuthorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

[TestFixture]
public class EntityAuthorizerTests
{
    private IDataManagementAuthorizationPlanFactory _authorizationPlanFactory;
    private IEntityInstanceDelegateFilterAuthorizer _delegateFilterAuthorizer;
    private IEntityInstanceAuthorizationValidator _authorizationValidator;
    private IEntityInstanceViewBasedFilterAuthorizer _viewBasedFilterAuthorizer;
    private EntityAuthorizer _entityAuthorizer;

    [SetUp]
    public void Setup()
    {
        _authorizationPlanFactory = A.Fake<IDataManagementAuthorizationPlanFactory>();
        _delegateFilterAuthorizer = A.Fake<IEntityInstanceDelegateFilterAuthorizer>();
        _authorizationValidator = A.Fake<IEntityInstanceAuthorizationValidator>();
        _viewBasedFilterAuthorizer = A.Fake<IEntityInstanceViewBasedFilterAuthorizer>();

        _entityAuthorizer = new EntityAuthorizer(
            _authorizationPlanFactory,
            _delegateFilterAuthorizer,
            _authorizationValidator,
            _viewBasedFilterAuthorizer);
    }

    [Test]
    public void AuthorizeEntityAsync_ShouldThrow_WhenActionUriIsNull()
    {
        // Arrange
        var entity = new object();
        
        // Act & Assert
        Assert.ThrowsAsync<AuthorizationContextException>(() => 
            _entityAuthorizer.AuthorizeEntityAsync(entity, null, AuthorizationPhase.ExistingData, CancellationToken.None));
    }

    [Test]
    public async Task AuthorizeEntityAsync_ShouldCallCreateAuthorizationPlan()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
        var authorizationPlan = new DataManagementAuthorizationPlan();

        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");
        
        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        // Act
        await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None);

        // Assert
        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .MustHaveHappenedOnceExactly();
    }

    private static DataManagementRequestContext CreateAuthorizationPlanRequestContext(string actionUri, object entity) => new(
        new ApiClientContext(),
        new Resource("name"),
        Array.Empty<string>(),
        actionUri,
        entity,
        AuthorizationPhase.ExistingData);

    [Test]
    public async Task AuthorizeEntityAsync_ShouldCallValidateOnAuthorizationValidator()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
        var authorizationPlan = new DataManagementAuthorizationPlan();
        var authorizationPhase = AuthorizationPhase.ExistingData;

        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        // Act
        await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, authorizationPhase, CancellationToken.None);

        // Assert
        A.CallTo(() => _authorizationValidator.Validate(
                authorizationPlan.RequestContext.Data,
                authorizationPlan.RequestContext.Action,
                authorizationPlan.AuthorizationBasisMetadata.ValidationRuleSetName))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task AuthorizeEntityAsync_ShouldThrowException_WhenDelegateFilterAuthorizerFailsAndResults()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
        var authorizationPlan = new DataManagementAuthorizationPlan();

        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");

        var failedResult = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Failed(new Exception("Authorization failed"))
                }
            }
        };

        authorizationPlan.Filtering = new[] { A.Fake<AuthorizationStrategyFiltering>() };

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.And, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { failedResult });

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(() => 
            _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None));
        
        ex.Message.ShouldBe("Authorization failed");
    }

    [Test]
    public async Task AuthorizeEntityAsync_ShouldPerformViewBasedAuthorizationAsync_ForPendingStrategies()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
        
        var authorizationPlan = new DataManagementAuthorizationPlan();
        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");

        var successResult = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.NotPerformed()
                }
            }
        };

        authorizationPlan.Filtering = new[] { new AuthorizationStrategyFiltering() };

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.And, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { successResult });

        // Act
        await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None);

        // Assert
        A.CallTo(() => _viewBasedFilterAuthorizer.PerformViewBasedAuthorizationAsync(
                A<AuthorizationStrategyFilterResults[]>.That.Matches(x => x.Length == 1),
                authorizationPlan.RequestContext.ApiClientContext.EducationOrganizationIds,
                AuthorizationPhase.ExistingData))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task AuthorizeEntityAsync_ShouldAuthorize_WhenOrConditionSatisfied()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
        var authorizationPlan = new DataManagementAuthorizationPlan();
        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");

        var orConditionResult = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Success()
                }
            }
        };

        authorizationPlan.Filtering = new[] { A.Fake<AuthorizationStrategyFiltering>() };
        authorizationPlan.RequestContext = A.Fake<DataManagementRequestContext>();

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.Or, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { orConditionResult });

        // Act
        await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None);

        // Assert
        A.CallTo(() => _viewBasedFilterAuthorizer.PerformViewBasedAuthorizationAsync(A<AuthorizationStrategyFilterResults[]>.Ignored,
                A<IList<long>>.Ignored,
                A<AuthorizationPhase>.Ignored))
            .MustNotHaveHappened();
    }
    
    [Test]
    public async Task AuthorizeEntityAsync_ShouldPerformViewBasedAuthorization_WhenPendingOrStrategyExists()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();
     
        var authorizationPlan = new DataManagementAuthorizationPlan();
        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");
        authorizationPlan.Filtering = new[] { new AuthorizationStrategyFiltering() };
        
        var andStrategy = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Success()
                }
            }
        };

        var orStrategy = new AuthorizationStrategyFilterResults
        {
            AuthorizationStrategyName = "TestStrategy",
            Operator = FilterOperator.Or,
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.NotPerformed()
                }
            }
        };


        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.And, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { andStrategy });

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.Or, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { orStrategy });

        // Act
        await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None);

        // Assert
        A.CallTo(() => _viewBasedFilterAuthorizer.PerformViewBasedAuthorizationAsync(
                A<AuthorizationStrategyFilterResults[]>.That.Matches(x => x.Length == 1),
                authorizationPlan.RequestContext.ApiClientContext.EducationOrganizationIds,
                AuthorizationPhase.ExistingData))
            .MustHaveHappenedOnceExactly();
    }
    
    [Test]
    public async Task AuthorizeEntityAsync_ShouldThrow_WhenAllPendingExistenceChecksIsEmpty()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();

        var authorizationPlan = new DataManagementAuthorizationPlan();
        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");
        authorizationPlan.Filtering = new[] { new AuthorizationStrategyFiltering() };

        var failedOrStrategy = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Failed(new Exception("Authorization failed"))
                }
            }
        };

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.And, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new AuthorizationStrategyFilterResults[0]);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.Or, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { failedOrStrategy });

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(() =>
            _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None));
        
        ex.Message.ShouldBe("Authorization failed");
    }
    
    [Test]
    public async Task AuthorizeEntityAsync_ShouldThrow_WhenPendingOrStrategyResultsInFailedState()
    {
        // Arrange
        var actionUri = "some-action-uri";
        var entity = new object();

        var authorizationPlan = new DataManagementAuthorizationPlan();
        authorizationPlan.RequestContext = CreateAuthorizationPlanRequestContext(actionUri, entity);
        authorizationPlan.AuthorizationBasisMetadata = new AuthorizationBasisMetadata(null, null, "validation-rule-set");
        authorizationPlan.Filtering = new[] { new AuthorizationStrategyFiltering() };

        var pendingAndStrategy = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Success()
                }
            }
        };

        var failedOrStrategy = new AuthorizationStrategyFilterResults
        {
            FilterResults = new[]
            {
                new FilterAuthorizationResult
                {
                    Result = InstanceAuthorizationResult.Failed(new Exception("Authorization failed"))
                }
            }
        };

        A.CallTo(() => _authorizationPlanFactory.CreateAuthorizationPlan(actionUri))
            .Returns(authorizationPlan);

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.And, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { pendingAndStrategy });

        A.CallTo(() => _delegateFilterAuthorizer.PerformInstanceBasedAuthorization(FilterOperator.Or, authorizationPlan.Filtering, authorizationPlan.RequestContext))
            .Returns(new[] { failedOrStrategy });

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(() =>
            _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ExistingData, CancellationToken.None));
        
        ex.Message.ShouldBe("Authorization failed");
    }
}
