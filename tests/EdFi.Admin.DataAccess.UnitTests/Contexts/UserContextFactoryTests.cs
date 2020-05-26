// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using FakeItEasy;
using EdFi.Admin.DataAccess.Contexts;
using NUnit.Framework;
using Shouldly;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Admin.DataAccess.UnitTests.Contexts
{
    [TestFixture]
    public class UserContextFactoryTests
    {
        // Not using TestFixtureBase because the tests are too simple to merit it.

        [Test]
        public void Given_null_argument_then_constructor_throws_exception()
        {
            Should.Throw<ArgumentNullException>(() => new UsersContextFactory(null));
        }
       

        [Test]
        public void Given_configured_for_SqlServer_then_create_SqlServerUsersContext()
        {
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(DatabaseEngine.SqlServer);

            new UsersContextFactory(configurationProvider)
                .CreateContext()
                .ShouldBeOfType<SqlServerUsersContext>()
                .ShouldNotBeNull();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresUsersContext()
        {
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(DatabaseEngine.Postgres);

            new UsersContextFactory(configurationProvider)
                .CreateContext()
                .ShouldBeOfType<PostgresUsersContext>()
                .ShouldNotBeNull();
        }

        private class UnsupportedDatabaseEngine : DatabaseEngine
        {
            public UnsupportedDatabaseEngine()
                : base("unsupported", "Unsupported Database Engine") { }
        }

        [Test]
        public void Given_configured_for_Unsupported_then_throws_invalid_operation_exception()
        {
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(new UnsupportedDatabaseEngine());

            Should.Throw<InvalidOperationException>(() => new UsersContextFactory(configurationProvider).CreateContext());
        }
    }
}
