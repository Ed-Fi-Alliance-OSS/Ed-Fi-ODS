// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using log4net;
using NHibernate;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories.EntityAuthorization;

public class FakeDbConnection : DbConnection
{
    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel) => throw new System.NotImplementedException();

    public override void ChangeDatabase(string databaseName)
    {
        throw new System.NotImplementedException();
    }

    public override void Close()
    {
        throw new System.NotImplementedException();
    }

    public override void Open()
    {
        throw new System.NotImplementedException();
    }

    public override string ConnectionString { get; set; }

    public override string Database { get; }

    public override ConnectionState State { get; }

    public override string DataSource { get; }

    public override string ServerVersion { get; }

    protected override DbCommand CreateDbCommand() => throw new System.NotImplementedException();
}


[TestFixture]
public class EntityAuthorizationQueryExecutorTests
{
    private ISessionFactory _sessionFactory;
    private IViewBasedSingleItemAuthorizationQuerySupport _viewBasedQuerySupport;
    private IRedundantAuthorizationContextManager _redundantContextManager;
    private EntityAuthorizationQueryExecutor _queryExecutor;

    [SetUp]
    public void SetUp()
    {
        _sessionFactory = A.Fake<ISessionFactory>();
        _viewBasedQuerySupport = A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>();
        _redundantContextManager = A.Fake<IRedundantAuthorizationContextManager>();

        _queryExecutor = new EntityAuthorizationQueryExecutor(
            _sessionFactory,
            _viewBasedQuerySupport,
            _redundantContextManager);
    }

    [Test]
    public async Task ExecuteAsync_ShouldAssignCommandTextAndParameters()
    {
        // Arrange
        var sql = "SELECT COUNT(*) FROM Authorization";
        var parameterDetails = new[]
        {
            new KeyValuePair<string, object>("@param1", 123),
            new KeyValuePair<string, object>("@param2", "Test")
        };
        
        var session = A.Fake<ISession>();
        var connection = A.Fake<FakeDbConnection>();
        var command = A.Fake<DbCommand>();

        A.CallTo(() => _sessionFactory.GetCurrentSession()).Returns(session);
        A.CallTo(() => session.Connection).Returns(connection);
        A.CallTo(() => connection.CreateCommand()).Returns(command);

        DbParameter[] dbParameters =
        [
            A.Fake<DbParameter>(),
            A.Fake<DbParameter>()
        ];

        A.CallTo(() => command.CreateParameter()).ReturnsNextFromSequence(dbParameters[0], dbParameters[2]);

        // Act
        await _queryExecutor.ExecuteAsync(sql, parameterDetails, new AuthorizationStrategyFilterResults[0], new List<long>());

        // Assert
        command.CommandText.ShouldBe(sql);
        A.CallTo(() => command.CreateParameter()).MustHaveHappened(parameterDetails.Length, Times.Exactly);

        dbParameters[0].ParameterName.ShouldBe(parameterDetails[0].Key);
        dbParameters[0].Value.ShouldBe(parameterDetails[0].Value);
        
        dbParameters[1].ParameterName.ShouldBe(parameterDetails[1].Key);
        dbParameters[1].Value.ShouldBe(parameterDetails[1].Value);
    }
/*
    [Test]
    public async Task ExecuteAsync_ShouldReturnNull_WhenAuthorizationQueryIsRedundant()
    {
        // Arrange
        var sql = "SELECT COUNT(*) FROM Authorization";
        var parameterDetails = new[]
        {
            new KeyValuePair<string, object>("@param1", 123)
        };

        var session = A.Fake<ISession>();
        var connection = A.Fake<IDbConnection>();
        var command = A.Fake<IDbCommand>();

        A.CallTo(() => _sessionFactory.GetCurrentSession()).Returns(session);
        A.CallTo(() => session.Connection).Returns(connection);
        A.CallTo(() => connection.CreateCommand()).Returns(command);
        A.CallTo(() => _redundantContextManager.IsAuthorizationQueryRedundant(command.CommandText, A<IDataParameterCollection>.Ignored)).Returns(true);

        // Act
        var result = await _queryExecutor.ExecuteAsync(sql, parameterDetails, new AuthorizationStrategyFilterResults[0], new List<long>());

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public async Task ExecuteAsync_ShouldApplyEducationOrganizationClaims_WhenPendingExistenceChecksHaveClaimParameterNames()
    {
        // Arrange
        var sql = "SELECT COUNT(*) FROM Authorization";
        var parameterDetails = new[]
        {
            new KeyValuePair<string, object>("@param1", 123)
        };

        var session = A.Fake<ISession>();
        var connection = A.Fake<IDbConnection>();
        var command = A.Fake<IDbCommand>();

        var resultsWithPendingChecks = new[]
        {
            new AuthorizationStrategyFilterResults
            {
                FilterResults = new[]
                {
                    new FilterAuthorizationResult
                    {
                        FilterContext = new AuthorizationFilterContext
                        {
                            ClaimParameterName = "ClaimParam"
                        }
                    }
                }
            }
        };

        A.CallTo(() => _sessionFactory.GetCurrentSession()).Returns(session);
        A.CallTo(() => session.Connection).Returns(connection);
        A.CallTo(() => connection.CreateCommand()).Returns(command);

        // Act
        await _queryExecutor.ExecuteAsync(sql, parameterDetails, resultsWithPendingChecks, new List<long> { 456 });

        // Assert
        A.CallTo(() => _viewBasedQuerySupport.ApplyEducationOrganizationIdClaimsToCommand(command, A<IList<long>>.That.Contains(456))).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task ExecuteAsync_ShouldStoreQueryContext_WhenExecutedSuccessfully()
    {
        // Arrange
        var sql = "SELECT COUNT(*) FROM Authorization";
        var parameterDetails = new[]
        {
            new KeyValuePair<string, object>("@param1", 123)
        };

        var session = A.Fake<ISession>();
        var connection = A.Fake<IDbConnection>();
        var command = A.Fake<DbCommand>();

        A.CallTo(() => _sessionFactory.GetCurrentSession()).Returns(session);
        A.CallTo(() => session.Connection).Returns(connection);
        A.CallTo(() => connection.CreateCommand()).Returns(command);
        A.CallTo(() => command.ExecuteScalarAsync()).Returns(Task.FromResult<object>(1));

        // Act
        var result = await _queryExecutor.ExecuteAsync(sql, parameterDetails, new AuthorizationStrategyFilterResults[0], new List<long>());

        // Assert
        result.ShouldBe(1);
        A.CallTo(() => _redundantContextManager.StoreAuthorizationQueryContext(command.CommandText, A<IDataParameterCollection>.Ignored)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task ExecuteAsync_ShouldLogDebugMessage_WhenDebugLoggingIsEnabled()
    {
        // Arrange
        var sql = "SELECT COUNT(*) FROM Authorization";
        var parameterDetails = new[]
        {
            new KeyValuePair<string, object>("@param1", 123)
        };

        var session = A.Fake<ISession>();
        var connection = A.Fake<IDbConnection>();
        var command = A.Fake<IDbCommand>();

        A.CallTo(() => _sessionFactory.GetCurrentSession()).Returns(session);
        A.CallTo(() => session.Connection).Returns(connection);
        A.CallTo(() => connection.CreateCommand()).Returns(command);
        A.CallTo(() => command.ExecuteScalarAsync()).Returns(Task.FromResult<object>(1));

        var logger = A.Fake<ILog>();
        A.CallTo(() => logger.IsDebugEnabled).Returns(true);
        
        // Act
        await _queryExecutor.ExecuteAsync(sql, parameterDetails, new AuthorizationStrategyFilterResults[0], new List<long>());

        // Assert
        A.CallTo(() => logger.Debug($"Single Item SQL: {sql}")).MustHaveHappenedOnceExactly();
    }
    */
}