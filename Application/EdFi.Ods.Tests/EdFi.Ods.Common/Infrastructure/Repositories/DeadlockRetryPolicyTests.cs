// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using FakeItEasy;
using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Time.Testing;
using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;
using NHibernate.Exceptions;
using Npgsql;
using NUnit.Framework;
using Polly;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Repositories;

[TestFixture]
public class DeadlockRetryPolicyTests
{
    private const string SqlServerDeadlockMessage =
        "Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim";

    [Test]
    public async Task RetryPolicy_DeadlockOccursRepeatedly_RetriesWithExponentialBackoffAndLogsEachRetry()
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        var pipeline = DeadlockPolicyHelper.CreatePipeline(DeadlockPolicyHelper.RetryStartingDelay, timeProvider);

        var warnings = new List<string>();
        var logger = A.Fake<ILog>();
        A.CallTo(() => logger.IsWarnEnabled).Returns(true);
        A.CallTo(() => logger.Warn(A<object>._)).Invokes((object message) => warnings.Add(message.ToString()));

        var context = ResilienceContextPool.Shared.Get();
        context.Properties.Set(DeadlockPolicyHelper.LoggerKey, logger);
        context.Properties.Set(DeadlockPolicyHelper.EntityTypeNameKey, nameof(TestEntity));

        int attempts = 0;
        var retriesSeenByCallback = new List<int>();

        // Act
        var execution = pipeline.ExecuteAsync(
                ctx =>
                {
                    attempts++;

                    if (ctx.Properties.TryGetValue(DeadlockPolicyHelper.RetriesKey, out int retries))
                    {
                        retriesSeenByCallback.Add(retries);
                    }

                    return ValueTask.FromException(CreateWrappedSqlException(1205, SqlServerDeadlockMessage));
                },
                context)
            .AsTask();

        try
        {
            await AdvanceUntilCompleted(timeProvider, execution);
        }
        finally
        {
            ResilienceContextPool.Shared.Return(context);
        }

        // Assert
        await Should.ThrowAsync<GenericADOException>(execution);
        attempts.ShouldBe(6);
        retriesSeenByCallback.ShouldBe(new[] { 1, 2, 3, 4, 5 });

        // Log output (up to the cumulative count, which is shared across tests) must match the Polly v7 implementation
        warnings.Select(w => w.Substring(0, w.IndexOf(" (Cumulative total retries", StringComparison.Ordinal)))
            .ShouldBe(
                new[] { 100, 200, 400, 800, 1600 }.Select(
                    (delay, i) =>
                        $"Deadlock exception encountered during 'TestEntity' entity persistence. Retrying transaction (with attempt #{i + 2} overall of 6 total in {delay:N0}ms)."));
    }

    [Test]
    public async Task RetryPolicy_PostgreSqlDeadlockOccurs_Retries()
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        var pipeline = DeadlockPolicyHelper.CreatePipeline(DeadlockPolicyHelper.RetryStartingDelay, timeProvider);

        int attempts = 0;

        // Act
        var execution = pipeline.ExecuteAsync(
                _ => ++attempts <= 2
                    ? ValueTask.FromException(CreateWrappedPostgresException(PostgresErrorCodes.DeadlockDetected))
                    : ValueTask.CompletedTask)
            .AsTask();

        await AdvanceUntilCompleted(timeProvider, execution);

        // Assert
        await Should.NotThrowAsync(execution);
        attempts.ShouldBe(3);
    }

    private static IEnumerable<TestCaseData> NonDeadlockErrors()
    {
        yield return new TestCaseData(
                (Func<Exception>)(() => CreateWrappedSqlException(547, "The INSERT statement conflicted with the FOREIGN KEY constraint")))
            .SetArgDisplayNames("SqlServerForeignKeyViolation");

        yield return new TestCaseData((Func<Exception>)(() => CreateWrappedPostgresException(PostgresErrorCodes.UniqueViolation)))
            .SetArgDisplayNames("PostgreSqlUniqueViolation");
    }

    [TestCaseSource(nameof(NonDeadlockErrors))]
    public async Task RetryPolicy_NonDeadlockErrorOccurs_DoesNotRetry(Func<Exception> createException)
    {
        // Arrange
        var pipeline = DeadlockPolicyHelper.CreatePipeline(DeadlockPolicyHelper.RetryStartingDelay, new FakeTimeProvider());

        int attempts = 0;

        // Act
        Func<Task> action = async () => await pipeline.ExecuteAsync(
            _ =>
            {
                attempts++;

                return ValueTask.FromException(createException());
            });

        // Assert
        await action.ShouldThrowAsync<GenericADOException>();
        attempts.ShouldBe(1);
    }

    [Test]
    public async Task CreateEntity_DeadlockOccursRepeatedly_RetriesAccordingToPolicy()
    {
        // Arrange
        var session = A.Fake<ISession>();
        A.CallTo(() => session.IsOpen).Returns(true);

        var sessionContext = A.Fake<CurrentSessionContext>();
        A.CallTo(() => sessionContext.CurrentSession()).Returns(session);

        var sessionFactory = A.Fake<ISessionFactoryImplementor>();
        A.CallTo(() => sessionFactory.CurrentSessionContext).Returns(sessionContext);
        A.CallTo(() => sessionFactory.OpenSession()).Returns(session);
        A.CallTo(() => sessionFactory.GetCurrentSession()).Returns(session);

        // Simulate a deadlock exception on the first attempt
        A.CallTo(() => session.SaveAsync(A<TestEntity>._, A<CancellationToken>._))
            .Throws(() => CreateWrappedSqlException(1205, "Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"));

        var dataManagementResourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new CreateEntity<TestEntity>(sessionFactory, dataManagementResourceContextProvider);

        // Act
        Func<Task> action = async () => await repository.CreateAsync(entity, false, CancellationToken.None);

        // Assert
        var exception = await action.ShouldThrowAsync<GenericADOException>(); // Ensure the deadlock exception is thrown
        exception.InnerException.ShouldBeExceptionType<SqlException>().Message.ShouldContain("deadlocked");
        A.CallTo(() => session.SaveAsync(entity, CancellationToken.None)).MustHaveHappened(6, Times.Exactly); // Ensure that the retry policy (5 retries + initial attempt) is applied correctly
    }

    [Test]
    public async Task CreateEntity_TransientDeadlockOccurs_RetriesAccordingToPolicy()
    {
        // Arrange
        var session = A.Fake<ISession>();
        A.CallTo(() => session.IsOpen).Returns(true);

        var sessionContext = A.Fake<CurrentSessionContext>();
        A.CallTo(() => sessionContext.CurrentSession()).Returns(session);

        var sessionFactory = A.Fake<ISessionFactoryImplementor>();
        A.CallTo(() => sessionFactory.CurrentSessionContext).Returns(sessionContext);
        A.CallTo(() => sessionFactory.OpenSession()).Returns(session);
        A.CallTo(() => sessionFactory.GetCurrentSession()).Returns(session);

        // Simulate a deadlock exception on the first attempt
        A.CallTo(() => session.SaveAsync(A<TestEntity>._, A<CancellationToken>._))
            .Throws(() => CreateWrappedSqlException(1205, "Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"))
            .NumberOfTimes(3)
            .Then
            .Returns(Task.CompletedTask);

        var dataManagementResourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new CreateEntity<TestEntity>(sessionFactory, dataManagementResourceContextProvider);

        // Act
        Func<Task> action = async () => await repository.CreateAsync(entity, false, CancellationToken.None);

        // Assert
        await action.ShouldNotThrowAsync(); // Ensure the deadlock exception is NOT thrown
        A.CallTo(() => session.SaveAsync(entity, CancellationToken.None)).MustHaveHappened(4, Times.Exactly);
    }
    
    [Test]
    public async Task UpdateEntity_DeadlockOccursRepeatedly_RetriesAccordingToPolicy()
    {
        // Arrange
        var session = A.Fake<ISession>();
        A.CallTo(() => session.IsOpen).Returns(true);

        var sessionContext = A.Fake<CurrentSessionContext>();
        A.CallTo(() => sessionContext.CurrentSession()).Returns(session);

        var sessionFactory = A.Fake<ISessionFactoryImplementor>();
        A.CallTo(() => sessionFactory.CurrentSessionContext).Returns(sessionContext);
        A.CallTo(() => sessionFactory.OpenSession()).Returns(session);
        A.CallTo(() => sessionFactory.GetCurrentSession()).Returns(session);

        // Simulate a deadlock exception on the first attempt
        A.CallTo(() => session.UpdateAsync(A<TestEntity>._, A<CancellationToken>._))
            .Throws(() => CreateWrappedSqlException(1205, "Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"));

        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new UpdateEntity<TestEntity>(sessionFactory);

        // Act
        Func<Task> action = async () => await repository.UpdateAsync(entity, CancellationToken.None);

        // Assert
        var exception = await action.ShouldThrowAsync<GenericADOException>(); // Ensure the deadlock exception is thrown
        exception.InnerException.ShouldBeExceptionType<SqlException>().Message.ShouldContain("deadlocked");
        A.CallTo(() => session.UpdateAsync(entity, CancellationToken.None)).MustHaveHappened(6, Times.Exactly); // Ensure that the retry policy (5 retries + initial attempt) is applied correctly
    }

    [Test]
    public async Task UpdateEntity_TransientDeadlockOccurs_RetriesAccordingToPolicy()
    {
        // Arrange
        var session = A.Fake<ISession>();
        A.CallTo(() => session.IsOpen).Returns(true);

        var sessionContext = A.Fake<CurrentSessionContext>();
        A.CallTo(() => sessionContext.CurrentSession()).Returns(session);

        var sessionFactory = A.Fake<ISessionFactoryImplementor>();
        A.CallTo(() => sessionFactory.CurrentSessionContext).Returns(sessionContext);
        A.CallTo(() => sessionFactory.OpenSession()).Returns(session);
        A.CallTo(() => sessionFactory.GetCurrentSession()).Returns(session);

        // Simulate a deadlock exception on the first attempt
        A.CallTo(() => session.UpdateAsync(A<TestEntity>._, A<CancellationToken>._))
            .Throws(() => CreateWrappedSqlException(1205, "Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"))
            .NumberOfTimes(3)
            .Then
            .Returns(Task.CompletedTask);

        var dataManagementResourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new UpdateEntity<TestEntity>(sessionFactory);

        // Act
        Func<Task> action = async () => await repository.UpdateAsync(entity, CancellationToken.None);

        // Assert
        await action.ShouldNotThrowAsync(); // Ensure the deadlock exception is NOT thrown
        A.CallTo(() => session.UpdateAsync(entity, CancellationToken.None)).MustHaveHappened(4, Times.Exactly);
    }

    private static async Task AdvanceUntilCompleted(FakeTimeProvider timeProvider, Task execution)
    {
        // Advance the fake clock past each pending retry delay until the execution finishes (bounded to avoid hanging)
        for (int i = 0; i < 1000 && !execution.IsCompleted; i++)
        {
            timeProvider.Advance(TimeSpan.FromSeconds(2));
            await Task.Delay(1);
        }

        execution.IsCompleted.ShouldBeTrue("The retry pipeline execution did not complete.");
    }

    private static GenericADOException CreateWrappedPostgresException(string sqlState)
    {
        var postgresException = new PostgresException("Database error", "ERROR", "ERROR", sqlState);

        return new GenericADOException("Could not do it.", postgresException);
    }

    private static GenericADOException CreateWrappedSqlException(int number, string message)
    {
        try
        {
            var sqlException = SqlExceptionCreator.Create(number, message);
            
            return new GenericADOException("Could not do it.", sqlException);
        }
        catch (Exception ex)
        {
            // Log or handle the exception accordingly
            Console.WriteLine($"Exception occurred while creating SqlException: {ex.Message}");
            return null;
        }
    }
}

public static class SqlExceptionCreator
{
    public static SqlException Create(int number, string errorMessage)
    {
        Exception innerException = null;
        
        var sqlErrorCollectionConstructors = typeof(SqlErrorCollection).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
        SqlErrorCollection errors = (sqlErrorCollectionConstructors[0].Invoke(null) as SqlErrorCollection)!;

        var errorList =
            (errors.GetType().GetField("_errors", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.GetValue(errors) as List<object>)!;

        var sqlErrorConstructors = typeof(SqlError).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
        var sqlErrorConstructor = sqlErrorConstructors.FirstOrDefault(f => f.GetParameters().Length == 9)!;

        SqlError sqlError = (sqlErrorConstructor.Invoke(
        [
            number, 
            /* errorState */ (byte)0, 
            /* errorClass */ (byte)0,
            /* server */ "", 
            "test error", 
            /* procedure */ "",
            /* lineNumber */ (int)0,
            /* win32 error code */ (int)0,
            innerException
        ]) as SqlError)!;

        errorList.Add(sqlError);

        SqlException ex = (Activator.CreateInstance(
            typeof(SqlException),
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            [
                errorMessage,
                errors,
                innerException,
                Guid.NewGuid()
            ],
            null) as SqlException)!;

        return ex;
    }
}

public class TestEntity : AggregateRootWithCompositeKey
{
    // You can add properties specific to TestEntity here
    public string Name { get; set; }
    public int Age { get; set; }

    public override int GetHashCode() => $"{Name}: {Age}".GetHashCode();
}
