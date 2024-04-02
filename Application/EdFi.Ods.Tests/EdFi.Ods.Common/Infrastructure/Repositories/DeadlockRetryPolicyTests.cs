// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using FakeItEasy;
using Microsoft.Data.SqlClient;
using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;
using NHibernate.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Repositories;

[TestFixture]
public class DeadlockRetryPolicyTests
{
    private int _originalStartingDelayMilliseconds;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _originalStartingDelayMilliseconds = DeadlockPolicyHelper.RetryStartingDelayMilliseconds;
        DeadlockPolicyHelper.RetryStartingDelayMilliseconds = 10;
    }

    [OneTimeTearDown]
    public void OneTimeTeardown()
    {
        DeadlockPolicyHelper.RetryStartingDelayMilliseconds = _originalStartingDelayMilliseconds;
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
            .Throws(() => CreateWrappedSqlException("Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"));

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
            .Throws(() => CreateWrappedSqlException("Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"))
            .NumberOfTimes(3)
            .Then
            .Returns(Task.CompletedTask);

        var dataManagementResourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new CreateEntity<TestEntity>(sessionFactory, dataManagementResourceContextProvider);

        // Act
        Func<Task> action = async () => await repository.CreateAsync(entity, false, CancellationToken.None);

        // Assert
        await action.ShouldNotThrowAsync(); // Ensure the deadlock exception is thrown
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
            .Throws(() => CreateWrappedSqlException("Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"));

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
        A.CallTo(() => session.SaveAsync(A<TestEntity>._, A<CancellationToken>._))
            .Throws(() => CreateWrappedSqlException("Transaction (Process ID 54) was deadlocked on lock resources with another process and has been chosen as the deadlock victim"))
            .NumberOfTimes(3)
            .Then
            .Returns(Task.CompletedTask);

        var dataManagementResourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        var entity = new TestEntity() { Name = "Bob", Age = 42};
        var repository = new CreateEntity<TestEntity>(sessionFactory, dataManagementResourceContextProvider);

        // Act
        Func<Task> action = async () => await repository.CreateAsync(entity, false, CancellationToken.None);

        // Assert
        await action.ShouldNotThrowAsync(); // Ensure the deadlock exception is thrown
        A.CallTo(() => session.SaveAsync(entity, CancellationToken.None)).MustHaveHappened(4, Times.Exactly);
    }

    private static GenericADOException CreateWrappedSqlException(string message)
    {
        try
        {
            // Get the internal SqlException type from System.Data assembly
            var sqlExceptionType = typeof(SqlException);
            // Get the constructor that accepts message parameter
            var constructor = sqlExceptionType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new []
            {
                typeof(string),
                typeof(SqlErrorCollection),
                typeof(Exception),
                typeof(Guid)
            }, null);

            var errorCollectionConstructor = typeof(SqlErrorCollection).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                Type.EmptyTypes);

            var errorCollection = errorCollectionConstructor.Invoke(Array.Empty<object>());

            // Create an instance of SqlException using the constructor
            var sqlException = (SqlException)constructor.Invoke(new object[] { message, errorCollection, new Exception("123"), Guid.NewGuid() });
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

public class TestEntity : AggregateRootWithCompositeKey
{
    // You can add properties specific to TestEntity here
    public string Name { get; set; }
    public int Age { get; set; }

    public override int GetHashCode() => $"{Name}: {Age}".GetHashCode();
}
