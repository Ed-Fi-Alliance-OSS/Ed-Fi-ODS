// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.Authorization.EntityAuthorization;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

[TestFixture]
public class EntityAuthorizationSqlBuilderTests
{
    [SetUp]
    public void Setup()
    {
        _sqlBuilder = new EntityAuthorizationSqlBuilder();
    }

    private EntityAuthorizationSqlBuilder _sqlBuilder;

    [Test]
    public void BuildExistenceCheckSql_ShouldReturnCorrectSql_ForSingleAndCondition()
    {
        // Arrange
        var viewSqlSupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();

        var filterDefinition = new ViewBasedAuthorizationFilterDefinition(
            "filter-name",
            "view-name",
            "view-source-endpoint-name",
            "view-target-endpoint-name",
            null, null, viewSqlSupport);

        var filterResult = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition,
            FilterContext = new AuthorizationFilterContext()
        };

        var authorizationResults = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.And,
            FilterResults = new[] { filterResult }
        };

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition, filterResult.FilterContext))
            .Returns("SELECT 1 FROM Table WHERE Condition = Value");

        // Act
        var sql = _sqlBuilder.BuildExistenceCheckSql(new[] { authorizationResults });

        // Assert
        sql.ShouldBe("SELECT CASE WHEN (EXISTS (SELECT 1 FROM Table WHERE Condition = Value)) THEN 1 ELSE 0 END AS IsAuthorized");
    }

    [Test]
    public void BuildExistenceCheckSql_ShouldReturnCorrectSql_ForMultipleAndConditions()
    {
        // Arrange
        var viewSqlSupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();

        var filterDefinition1 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name",
            "view-name",
            "view-source-endpoint-name",
            "view-target-endpoint-name",
            null, null, viewSqlSupport);

        var filterDefinition2 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-2",
            "view-name-2",
            "view-source-endpoint-name-2",
            "view-target-endpoint-name-2",
            null, null, viewSqlSupport);

        var filterResult1 = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition1,
            FilterContext = new AuthorizationFilterContext()
        };

        var filterResult2 = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition2,
            FilterContext = new AuthorizationFilterContext()
        };

        var authorizationResults = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.And,
            FilterResults = new[]
            {
                filterResult1,
                filterResult2
            }
        };

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition1, filterResult1.FilterContext))
            .Returns("SELECT 1 FROM Table1 WHERE Condition1 = Value1");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition2, filterResult2.FilterContext))
            .Returns("SELECT 1 FROM Table2 WHERE Condition2 = Value2");

        // Act
        var sql = _sqlBuilder.BuildExistenceCheckSql(new[] { authorizationResults });

        // Assert
        sql.ShouldBe(
            "SELECT CASE WHEN (EXISTS (SELECT 1 FROM Table1 WHERE Condition1 = Value1) AND EXISTS (SELECT 1 FROM Table2 WHERE Condition2 = Value2)) THEN 1 ELSE 0 END AS IsAuthorized");
    }

    [Test]
    public void BuildExistenceCheckSql_ShouldReturnCorrectSql_ForSingleOrCondition()
    {
        // Arrange
        var viewSqlSupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();

        var filterDefinition = new ViewBasedAuthorizationFilterDefinition(
            "filter-name",
            "view-name",
            "view-source-endpoint-name",
            "view-target-endpoint-name",
            null, null, viewSqlSupport);

        var filterResult = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition,
            FilterContext = new AuthorizationFilterContext()
        };

        var authorizationResults = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.Or,
            FilterResults = new[] { filterResult }
        };

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition, filterResult.FilterContext))
            .Returns("SELECT 1 FROM Table WHERE Condition = Value");

        // Act
        var sql = _sqlBuilder.BuildExistenceCheckSql(new[] { authorizationResults });

        // Assert
        sql.ShouldBe("SELECT CASE WHEN (EXISTS (SELECT 1 FROM Table WHERE Condition = Value)) THEN 1 ELSE 0 END AS IsAuthorized");
    }

    [Test]
    public void BuildExistenceCheckSql_ShouldReturnSqlWithFiltersWithinOrStrategyCombinedUsingAnd_ForMultipleOrConditions()
    {
        // Arrange
        var viewSqlSupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();

        var filterDefinition1 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name",
            "view-name",
            "view-source-endpoint-name",
            "view-target-endpoint-name",
            null, null, viewSqlSupport);

        var filterDefinition2 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-2",
            "view-name-2",
            "view-source-endpoint-name-2",
            "view-target-endpoint-name-2",
            null, null, viewSqlSupport);

        var filterResult1 = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition1,
            FilterContext = new AuthorizationFilterContext()
        };

        var filterResult2 = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition2,
            FilterContext = new AuthorizationFilterContext()
        };

        var authorizationResults = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.Or,
            FilterResults = new[]
            {
                filterResult1,
                filterResult2
            }
        };

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition1, filterResult1.FilterContext))
            .Returns("SELECT 1 FROM Table1 WHERE Condition1 = Value1");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(filterDefinition2, filterResult2.FilterContext))
            .Returns("SELECT 1 FROM Table2 WHERE Condition2 = Value2");

        // Act
        var sql = _sqlBuilder.BuildExistenceCheckSql(new[] { authorizationResults });

        // Assert
        sql.ShouldBe(
            "SELECT CASE WHEN (EXISTS (SELECT 1 FROM Table1 WHERE Condition1 = Value1) AND EXISTS (SELECT 1 FROM Table2 WHERE Condition2 = Value2)) THEN 1 ELSE 0 END AS IsAuthorized");
    }

    [Test]
    public void BuildExistenceCheckSql_ShouldReturnCorrectSql_ForCombinedAndOrConditions()
    {
        // Arrange
        var viewSqlSupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();

        var andFilterDefinition1a = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-and-1a",
            "view-name-and-1a",
            "view-source-endpoint-name-and-1a",
            "view-target-endpoint-name-and=1a",
            null, null, viewSqlSupport);

        var andFilterDefinition1b = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-and-1b",
            "view-name-and-1b",
            "view-source-endpoint-name-and-1b",
            "view-target-endpoint-name-and=1b",
            null, null, viewSqlSupport);

        var andFilterDefinition2 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-and-2",
            "view-name-and-2",
            "view-source-endpoint-name-and-2",
            "view-target-endpoint-name-and=2",
            null, null, viewSqlSupport);

        var orFilterDefinition1 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-1",
            "view-name-1",
            "view-source-endpoint-name-1",
            "view-target-endpoint-name-1",
            null, null, viewSqlSupport);

        var orFilterDefinition2 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-2",
            "view-name-2",
            "view-source-endpoint-name-2",
            "view-target-endpoint-name-2",
            null, null, viewSqlSupport);

        var orFilterDefinition3 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-3",
            "view-name-3",
            "view-source-endpoint-name-3",
            "view-target-endpoint-name-3",
            null, null, viewSqlSupport);

        var orFilterDefinition4 = new ViewBasedAuthorizationFilterDefinition(
            "filter-name-4",
            "view-name-4",
            "view-source-endpoint-name-4",
            "view-target-endpoint-name-4",
            null, null, viewSqlSupport);

        var andFilterResult1a = new FilterAuthorizationResult
        {
            FilterDefinition = andFilterDefinition1a,
            FilterContext = new AuthorizationFilterContext(),
        };

        var andFilterResult1b = new FilterAuthorizationResult
        {
            FilterDefinition = andFilterDefinition1b,
            FilterContext = new AuthorizationFilterContext(),
        };

        var andFilterResult2 = new FilterAuthorizationResult
        {
            FilterDefinition = andFilterDefinition2,
            FilterContext = new AuthorizationFilterContext(),
        };

        var orFilterResult1 = new FilterAuthorizationResult
        {
            FilterDefinition = orFilterDefinition1,
            FilterContext = new AuthorizationFilterContext()
        };

        var orFilterResult2 = new FilterAuthorizationResult
        {
            FilterDefinition = orFilterDefinition2,
            FilterContext = new AuthorizationFilterContext()
        };

        var orFilterResult3 = new FilterAuthorizationResult
        {
            FilterDefinition = orFilterDefinition3,
            FilterContext = new AuthorizationFilterContext()
        };

        var orFilterResult4 = new FilterAuthorizationResult
        {
            FilterDefinition = orFilterDefinition4,
            FilterContext = new AuthorizationFilterContext()
        };

        var andResults1 = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.And,
            FilterResults = new[]
            {
                andFilterResult1a, 
                andFilterResult1b
            }
        };

        var andResults2 = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.And,
            FilterResults = new[] { andFilterResult2 }
        };

        var orResults1 = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.Or,
            FilterResults = new[]
            {
                orFilterResult1,
                orFilterResult2
            }
        };

        var orResults2 = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.Or,
            FilterResults = new[]
            {
                orFilterResult3,
                orFilterResult4
            }
        };

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(andFilterDefinition1a, andFilterResult1a.FilterContext))
            .Returns("SELECT 1 FROM AndTable1a WHERE Condition = AndValue1a");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(andFilterDefinition1b, andFilterResult1b.FilterContext))
            .Returns("SELECT 1 FROM AndTable1b WHERE Condition = AndValue1b");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(andFilterDefinition2, andFilterResult2.FilterContext))
            .Returns("SELECT 1 FROM AndTable2 WHERE Condition = AndValue2");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(orFilterDefinition1, orFilterResult1.FilterContext))
            .Returns("SELECT 1 FROM OrTable1 WHERE Condition = OrValue1");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(orFilterDefinition2, orFilterResult2.FilterContext))
            .Returns("SELECT 1 FROM OrTable2 WHERE Condition = OrValue2");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(orFilterDefinition3, orFilterResult3.FilterContext))
            .Returns("SELECT 1 FROM OrTable3 WHERE Condition = OrValue3");

        A.CallTo(() => viewSqlSupport.GetItemExistenceCheckSql(orFilterDefinition4, orFilterResult4.FilterContext))
            .Returns("SELECT 1 FROM OrTable4 WHERE Condition = OrValue4");

        // Act
        var sql = _sqlBuilder.BuildExistenceCheckSql(
            new[]
            {
                andResults1,
                andResults2,
                orResults1,
                orResults2
            });

        // Assert
        sql.ShouldBe(
            "SELECT CASE WHEN (EXISTS (SELECT 1 FROM AndTable1a WHERE Condition = AndValue1a) AND EXISTS (SELECT 1 FROM AndTable1b WHERE Condition = AndValue1b)) AND (EXISTS (SELECT 1 FROM AndTable2 WHERE Condition = AndValue2)) AND ((EXISTS (SELECT 1 FROM OrTable1 WHERE Condition = OrValue1) AND EXISTS (SELECT 1 FROM OrTable2 WHERE Condition = OrValue2)) OR (EXISTS (SELECT 1 FROM OrTable3 WHERE Condition = OrValue3) AND EXISTS (SELECT 1 FROM OrTable4 WHERE Condition = OrValue4))) THEN 1 ELSE 0 END AS IsAuthorized");
    }

    [Test]
    public void BuildExistenceCheckSql_ShouldThrowException_WhenFilterDefinitionIsNotViewBased()
    {
        // Arrange
        var filterDefinition = new AuthorizationFilterDefinition(
            "filter-name",
            "view-name",
            null,
            null, null);

        var filterResult = new FilterAuthorizationResult
        {
            FilterDefinition = filterDefinition,
            FilterContext = new AuthorizationFilterContext()
        };

        var authorizationResults = new AuthorizationStrategyFilterResults
        {
            Operator = FilterOperator.And,
            FilterResults = new[] { filterResult }
        };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _sqlBuilder.BuildExistenceCheckSql(new[] { authorizationResults }));
    }
}
