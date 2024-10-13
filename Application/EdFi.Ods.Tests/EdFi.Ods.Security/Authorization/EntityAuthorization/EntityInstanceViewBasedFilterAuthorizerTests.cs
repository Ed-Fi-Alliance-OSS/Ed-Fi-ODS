// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.EntityAuthorization;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

[TestFixture]
public class EntityInstanceViewBasedFilterAuthorizerTests
{
    [SetUp]
    public void SetUp()
    {
        _sqlBuilder = A.Fake<IEntityAuthorizationSqlBuilder>();
        _queryExecutor = A.Fake<IEntityAuthorizationQueryExecutor>();
        _hintProviders = new[] { A.Fake<IAuthorizationViewHintProvider>() };
        _authorizer = new EntityInstanceViewBasedFilterAuthorizer(_sqlBuilder, _queryExecutor, _hintProviders);
    }

    private IEntityAuthorizationSqlBuilder _sqlBuilder;
    private IEntityAuthorizationQueryExecutor _queryExecutor;
    private IAuthorizationViewHintProvider[] _hintProviders;
    private EntityInstanceViewBasedFilterAuthorizer _authorizer;

    [Test]
    public async Task PerformViewBasedAuthorizationAsync_ShouldNotExecuteQuery_WhenParameterValuesAreNull()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { null },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [ 123 ]
                        }
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        // Act
        var exception = Should.Throw<SecurityAuthorizationException>(
                async () => await _authorizer.PerformViewBasedAuthorizationAsync(
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds,
                    AuthorizationPhase.ExistingData));
        exception.Detail.ShouldBe("Access to the requested data could not be authorized.");
        (exception as IEdFiProblemDetails).Errors.ShouldContain("No relationships have been established between the caller's education organization id claim (123) and the resource item's 'TestParam' value.");

        // Assert
        A.CallTo(
            () => _sqlBuilder.BuildExistenceCheckSql(A<AuthorizationStrategyFilterResults[]>.Ignored))
            .MustNotHaveHappened();
        
        A.CallTo(
            () => _queryExecutor.ExecuteAsync(
                A<string>.Ignored,
                A<KeyValuePair<string, object>[]>.Ignored,
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds))
            .MustNotHaveHappened();
    }

    [Test]
    public async Task PerformViewBasedAuthorizationAsync_ShouldExecuteQuery_WhenAllParameterValuesAreNotNull()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [ 123 ]
                        }
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(1));

        // Act
        await _authorizer.PerformViewBasedAuthorizationAsync(
            resultsWithPendingExistenceChecks,
            claimEducationOrganizationIds,
            AuthorizationPhase.ExistingData);

        // Assert
        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task PerformViewBasedAuthorizationAsync_ShouldNotThrow_WhenQueryReturnsNull()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [ 123 ]
                        }
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        // This will return null only if the authorization request is redundant in the call context
        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(null));

        // Act & Assert
        await Should.NotThrowAsync(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));
    }

    [Test]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithHints_WhenQueryReturnsZero()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [123]
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "TestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns("Test hint");

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));

        exception.Result.Detail.ShouldStartWith("Access to the requested data could not be authorized.");
        exception.Result.Detail.ShouldContain("Hint: Test hint");
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain("No relationships have been established between the caller's education organization id claim (123) and the resource item's 'TestParam' value.");
    }

    [TestCase("claim (123)", new [] { 123L })]
    [TestCase("claims (1, 2, 3, 4, 5, ...)", new long[] {1,2,3,4,5,6,7,8,9,10})]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithoutHints_WhenNoHintsAvailable(string claimsErrorText, long[] edOrgIds)
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = edOrgIds.Cast<object>().ToArray()
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "TestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long>(edOrgIds);

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns(string.Empty);

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));

        // No hint
        exception.Result.Detail.ShouldBe("Access to the requested data could not be authorized.");
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain($"No relationships have been established between the caller's education organization id {claimsErrorText} and the resource item's 'TestParam' value.");
    }
    
    [Test]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithMultipleFilterAuthorizationResults()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [ 123, 234 ] // Error message uses the first filter's claim values
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "TestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    },
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam2" },
                            SubjectEndpointValues = new object[] { 789 },
                            ClaimParameterName = "ClaimParam",
                            ClaimEndpointValues = [ 345 ] // Error message ignores these
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name-2",
                            "TestView2",
                            "view-source-endpoint-2",
                            "view-target-endpoint-2",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 4567 }; // Error message ignores these values 

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns(null);
        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView2")).Returns(null);

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));

        // No hint
        exception.Result.Detail.ShouldBe("Access to the requested data could not be authorized.");
        
        // Multiple subject endpoints message
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain($"No relationships have been established between the caller's education organization id claims (123, 234) and one or more of the following properties of the resource item: 'TestParam', 'TestParam2'.");
    }

    [Test]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithHints_WhenQueryReturnsZero_ForCustomViewBasedAuthorization()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            // Custom view-based authorization will have no claim values
                            // ClaimParameterName = "ClaimParam",
                            // ClaimEndpointValues = [123]
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "CustomTestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("CustomTestView")).Returns("Custom test hint");
        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns("Test hint");

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));

        exception.Result.Detail.ShouldStartWith("Access to the requested data could not be authorized.");
        exception.Result.Detail.ShouldContain("Hint: Custom test hint");
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain("The caller is not authorized to perform the requested operation on the item based on the existing value of the 'TestParam' property of the item.");
    }

    [Test]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithoutHints_WhenNoHintsAvailable_ForCustomViewBasedAuthorization()
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            // Custom view-based authorization will have no claim values
                            // ClaimParameterName = "ClaimParam",
                            // ClaimEndpointValues = [123]
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "CustomTestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("CustomTestView")).Returns(string.Empty);
        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns("Test hint");

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                AuthorizationPhase.ExistingData));

        // No hint
        exception.Result.Detail.ShouldBe("Access to the requested data could not be authorized.");
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain("The caller is not authorized to perform the requested operation on the item based on the existing value of the 'TestParam' property of the item.");
    }

    [TestCase(AuthorizationPhase.ExistingData)]
    [TestCase(AuthorizationPhase.ProposedData)]
    public void PerformViewBasedAuthorizationAsync_ShouldThrowSecurityAuthorizationException_WithoutMultipleFilters_ForCustomViewBasedAuthorization(AuthorizationPhase authorizationPhase)
    {
        // Arrange
        var resultsWithPendingExistenceChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam" },
                            SubjectEndpointValues = new object[] { 456 },
                            // Custom view-based authorization will have no claim values
                            // ClaimParameterName = "ClaimParam",
                            // ClaimEndpointValues = [123]
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name",
                            "CustomTestView",
                            "view-source-endpoint",
                            "view-target-endpoint",
                            null, null, null)
                    },
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            SubjectEndpointNames = new[] { "TestParam2" },
                            SubjectEndpointValues = new object[] { 567 },
                            // Custom view-based authorization will have no claim values
                            // ClaimParameterName = "ClaimParam",
                            // ClaimEndpointValues = [123]
                        },
                        FilterDefinition = new ViewBasedAuthorizationFilterDefinition(
                            "filter-name-2",
                            "CustomTestView2",
                            "view-source-endpoint-2",
                            "view-target-endpoint-2",
                            null, null, null)
                    }
                }
            }
        };

        var claimEducationOrganizationIds = new List<long> { 123 };

        A.CallTo(() => _sqlBuilder.BuildExistenceCheckSql(resultsWithPendingExistenceChecks)).Returns("Generated SQL");

        A.CallTo(
                () => _queryExecutor.ExecuteAsync(
                    "Generated SQL",
                    A<KeyValuePair<string, object>[]>.Ignored,
                    resultsWithPendingExistenceChecks,
                    claimEducationOrganizationIds))
            .Returns(Task.FromResult<int?>(0));

        A.CallTo(() => _hintProviders[0].GetFailureHint("CustomTestView")).Returns(string.Empty);
        A.CallTo(() => _hintProviders[0].GetFailureHint("TestView")).Returns("Test hint");

        // Act & Assert
        var exception = Should.ThrowAsync<SecurityAuthorizationException>(
            () => _authorizer.PerformViewBasedAuthorizationAsync(
                resultsWithPendingExistenceChecks,
                claimEducationOrganizationIds,
                authorizationPhase));

        string existingOrProposedText = authorizationPhase switch
        {
            AuthorizationPhase.ExistingData => "existing",
            AuthorizationPhase.ProposedData => "proposed",
            _ => null
        };

        // No hint
        exception.Result.Detail.ShouldBe("Access to the requested data could not be authorized.");
        (exception.Result as IEdFiProblemDetails).Errors.ShouldContain($"The caller is not authorized to perform the requested operation on the item based on the {existingOrProposedText} values of one or more of the following properties of the item: 'TestParam', 'TestParam2'.");
    }
}
