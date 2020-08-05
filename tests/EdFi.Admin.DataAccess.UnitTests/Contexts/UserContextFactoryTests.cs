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
using EdFi.Ods.Common.Database;

namespace EdFi.Admin.DataAccess.UnitTests.Contexts
{
    [TestFixture]
    public class UserContextFactoryTests
    {
        // Not using TestFixtureBase because the tests are too simple to merit it.

        [Test]
        public void Given_configured_for_SqlServer_then_create_SqlServerUsersContext()
        {
            var connectionStringsProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
            A.CallTo(() => connectionStringsProvider.GetConnectionString()).Returns("Server=.;Database=EdFi_Admin_Test;Integrated Security=SSPI;");

            new UsersContextFactory(connectionStringsProvider, DatabaseEngine.SqlServer)
                .CreateContext()
                .ShouldBeOfType<SqlServerUsersContext>()
                .ShouldNotBeNull();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresUsersContext()
        {
            var connectionStringsProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
            A.CallTo(() => connectionStringsProvider.GetConnectionString()).Returns("Host=localhost; Port=5432; Username=postgres; Database=EdFi_Admin_Test; Application Name=EdFi.Ods.WebApi;");

            new UsersContextFactory(connectionStringsProvider, DatabaseEngine.Postgres)
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
            var connectionStringsProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
            A.CallTo(() => connectionStringsProvider.GetConnectionString()).Returns("unsupported");

            Should.Throw<InvalidOperationException>(() => new UsersContextFactory(connectionStringsProvider, new UnsupportedDatabaseEngine()).CreateContext());
        }
    }
}
