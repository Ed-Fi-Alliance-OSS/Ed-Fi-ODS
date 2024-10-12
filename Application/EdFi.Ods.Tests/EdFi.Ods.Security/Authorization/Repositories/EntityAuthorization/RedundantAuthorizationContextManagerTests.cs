// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

[TestFixture]
public class RedundantAuthorizationContextManagerTests
{
    [SetUp]
    public void SetUp()
    {
        _contextProvider = A.Fake<IContextProvider<ViewBasedAuthorizationQueryContext>>();
        _redundantAuthorizationContextManager = new RedundantAuthorizationContextManager(_contextProvider);
    }

    private IContextProvider<ViewBasedAuthorizationQueryContext> _contextProvider;
    private RedundantAuthorizationContextManager _redundantAuthorizationContextManager;

    [Test]
    public void IsAuthorizationQueryRedundant_ShouldReturnFalse_WhenContextIsNull()
    {
        // Arrange
        var sql = "SELECT * FROM Table";
        var parameters = new DbParameter[0];

        A.CallTo(() => _contextProvider.Get()).Returns(null);

        // Act
        var result = _redundantAuthorizationContextManager.IsAuthorizationQueryRedundant(sql, parameters);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void IsAuthorizationQueryRedundant_ShouldReturnFalse_WhenSqlDoesNotMatch()
    {
        // Arrange
        var sql = "SELECT * FROM Table";
        var parameters = new DbParameter[0];

        var context = new ViewBasedAuthorizationQueryContext
        {
            Sql = "SELECT * FROM AnotherTable",
            Parameters = parameters
        };

        A.CallTo(() => _contextProvider.Get()).Returns(context);

        // Act
        var result = _redundantAuthorizationContextManager.IsAuthorizationQueryRedundant(sql, parameters);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void IsAuthorizationQueryRedundant_ShouldReturnFalse_WhenParametersDoNotMatch()
    {
        // Arrange
        var sql = "SELECT * FROM Table";
        var parameter1 = A.Fake<DbParameter>();
        var parameter2 = A.Fake<DbParameter>();

        A.CallTo(() => parameter1.Value).Returns(123);
        A.CallTo(() => parameter2.Value).Returns(456);

        var parameters = new[] { parameter1 };

        var context = new ViewBasedAuthorizationQueryContext
        {
            Sql = sql,
            Parameters = new[] { parameter2 }
        };

        A.CallTo(() => _contextProvider.Get()).Returns(context);

        // Act
        var result = _redundantAuthorizationContextManager.IsAuthorizationQueryRedundant(sql, parameters);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void IsAuthorizationQueryRedundant_ShouldReturnTrue_WhenSqlAndParametersMatch()
    {
        // Arrange
        var sql = "SELECT * FROM Table";
        var parameter1 = A.Fake<DbParameter>();
        A.CallTo(() => parameter1.Value).Returns(123);

        var parameters = new[] { parameter1 };

        var context = new ViewBasedAuthorizationQueryContext
        {
            Sql = sql,
            Parameters = new[] { parameter1 }
        };

        A.CallTo(() => _contextProvider.Get()).Returns(context);

        // Same values, different instances
        var sql2 = "SELECT * FROM Table";
        var parameter2 = A.Fake<DbParameter>();
        A.CallTo(() => parameter2.Value).Returns(123);

        var parameters2 = new[] { parameter2 };

        // Act
        var result = _redundantAuthorizationContextManager.IsAuthorizationQueryRedundant(sql2, parameters2);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void StoreAuthorizationQueryContext_ShouldStoreSqlAndParameters_WhenContextIsNotInitialized()
    {
        // Arrange
        var sql = "SELECT * FROM Table";
        var parameter1 = A.Fake<DbParameter>();
        var parameters = new[] { parameter1 };
        var context = new ViewBasedAuthorizationQueryContext();

        A.CallTo(() => _contextProvider.Get()).Returns(context);

        // Act
        _redundantAuthorizationContextManager.StoreAuthorizationQueryContext(sql, parameters);

        // Assert
        context.Sql.ShouldBe(sql);
        context.Parameters.ShouldBe(parameters);
    }

    [Test]
    public void StoreAuthorizationQueryContext_ShouldNotModifyContext_WhenAlreadyInitialized()
    {
        // Arrange
        var existingSql = "SELECT * FROM Table";
        var newSql = "SELECT * FROM NewTable";
        var existingParameter = A.Fake<DbParameter>();
        var newParameter = A.Fake<DbParameter>();

        var existingParameters = new[] { existingParameter };
        var newParameters = new[] { newParameter };

        var context = new ViewBasedAuthorizationQueryContext
        {
            Sql = existingSql,
            Parameters = existingParameters
        };

        A.CallTo(() => _contextProvider.Get()).Returns(context);

        // Act
        _redundantAuthorizationContextManager.StoreAuthorizationQueryContext(newSql, newParameters);

        // Assert
        context.Sql.ShouldBe(existingSql);
        context.Parameters.ShouldBe(existingParameters);
    }
}
