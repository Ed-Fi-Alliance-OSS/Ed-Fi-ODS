// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using log4net;
using Microsoft.Extensions.Time.Testing;
using NUnit.Framework;
using Polly;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Configuration
{
    [TestFixture]
    public class NHibernateOdsConnectionProviderTests
    {
        public abstract class When_a_malformatted_connection_string_is_set_up : TestFixtureBase
        {
            NHibernateOdsConnectionProvider _nhibernateOdsConnectionProvider;

            protected override void Arrange()
            {
                var odsDatabaseConnectionStringProvider = A.Fake<IOdsDatabaseConnectionStringProvider>();
                A.CallTo(() => odsDatabaseConnectionStringProvider.GetConnectionString())
                    .Returns($"invalid");

                _nhibernateOdsConnectionProvider = new NHibernateOdsConnectionProvider(odsDatabaseConnectionStringProvider);
                _nhibernateOdsConnectionProvider.Configure(new Dictionary<string, string>() {
                    { NHibernate.Cfg.Environment.ConnectionString, A.Dummy<string>() },
                    { NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MicrosoftDataSqlClientDriver" },
                    { NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect" }
                });
            }

            public class A_call_to_GetConnection : When_a_malformatted_connection_string_is_set_up
            {
                protected override void Act()
                {
                    _nhibernateOdsConnectionProvider.GetConnection();
                }
            }

            public class A_call_to_GetConnectionAsync : When_a_malformatted_connection_string_is_set_up
            {
                protected override void Act()
                {
                    _nhibernateOdsConnectionProvider.GetConnectionAsync(CancellationToken.None)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
                }
            }

            [Test]
            public void Should_throw_an_exception()
            {
                var problemDetails = ActualException.ShouldBeOfType<DatabaseConnectionException>();

                AssertHelper.All(
                    () => problemDetails.Status.ShouldBe(500),
                    () => problemDetails.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "system:database-connection")),
                    () => problemDetails.Detail.ShouldBe("There was a problem communicating with the database.")
                );
            }
        }

        [TestFixture]
        public class ConnectionRetryPipeline
        {
            private FakeTimeProvider _timeProvider;
            private List<string> _warnings;
            private ResiliencePipeline _pipeline;

            [SetUp]
            public void SetUp()
            {
                _timeProvider = new FakeTimeProvider();
                _warnings = new List<string>();

                var logger = A.Fake<ILog>();
                A.CallTo(() => logger.Warn(A<object>._)).Invokes((object message) => _warnings.Add(message.ToString()));

                _pipeline = NHibernateOdsConnectionProvider.CreateConnectionRetryPipeline(logger, _timeProvider);
            }

            [Test]
            public async Task Should_retry_a_transient_connection_failure_until_the_connection_opens()
            {
                int attempts = 0;

                await ExecuteAndAdvanceUntilCompleted(
                    () =>
                    {
                        if (++attempts <= 2)
                        {
                            throw new InvalidOperationException("Connection refused");
                        }
                    });

                attempts.ShouldBe(3);

                _warnings.ShouldBe(
                    new[]
                    {
                        "Retry attempt 1 of 5: Retrying connection in 1 seconds due to exception: Connection refused",
                        "Retry attempt 2 of 5: Retrying connection in 2 seconds due to exception: Connection refused"
                    });
            }

            [Test]
            public async Task Should_retry_5_times_with_exponential_backoff_and_then_rethrow()
            {
                int attempts = 0;

                var execution = ExecuteAndAdvanceUntilCompleted(
                    () =>
                    {
                        attempts++;
                        throw new InvalidOperationException("Connection refused");
                    });

                await Should.ThrowAsync<InvalidOperationException>(execution);
                attempts.ShouldBe(6);

                // Log output must match the Polly v7 implementation
                _warnings.ShouldBe(
                    new[] { 1, 2, 4, 8, 16 }.Select(
                        (delaySeconds, i) =>
                            $"Retry attempt {i + 1} of 5: Retrying connection in {delaySeconds} seconds due to exception: Connection refused"));
            }

            [Test]
            public async Task Should_not_retry_a_problem_details_exception()
            {
                int attempts = 0;

                var execution = ExecuteAndAdvanceUntilCompleted(
                    () =>
                    {
                        attempts++;
                        throw new DatabaseConnectionException("Unable to open connection to the ODS database.");
                    });

                await Should.ThrowAsync<DatabaseConnectionException>(execution);
                attempts.ShouldBe(1);
                _warnings.ShouldBeEmpty();
            }

            private async Task ExecuteAndAdvanceUntilCompleted(Action openConnection)
            {
                // Synchronous execution blocks on the (fake) retry delays, so run it on another thread
                var execution = Task.Run(() => _pipeline.Execute(openConnection));

                // Advance the fake clock past each pending retry delay until the execution finishes (bounded to avoid hanging)
                for (int i = 0; i < 1000 && !execution.IsCompleted; i++)
                {
                    _timeProvider.Advance(TimeSpan.FromSeconds(20));
                    await Task.Delay(1);
                }

                execution.IsCompleted.ShouldBeTrue("The retry pipeline execution did not complete.");

                await execution;
            }
        }
    }
}