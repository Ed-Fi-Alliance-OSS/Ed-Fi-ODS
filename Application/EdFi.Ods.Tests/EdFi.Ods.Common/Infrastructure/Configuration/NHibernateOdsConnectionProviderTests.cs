// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
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
    }
}