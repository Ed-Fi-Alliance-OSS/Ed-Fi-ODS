// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using FakeItEasy;
using EdFi.Security.DataAccess.Contexts;
using NUnit.Framework;
using Shouldly;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Security.DataAccess.UnitTests.Contexts
{
    [TestFixture]
    public class SecurityContextFactoryTests
    {
        [Test]
        public void Given_configured_for_SqlServer_then_create_SqlServerSecurityContext()
        {
            var connectionstringProvider = A.Fake<ISecurityDatabaseConnectionStringProvider>();

            A.CallTo(() => connectionstringProvider.GetConnectionString()).Returns(
                          "Server=(local); Database=EdFi_Security; trusted_connection=True; Application Name=EdFi.Ods.WebApi;");

            new SecurityContextFactory(connectionstringProvider, DatabaseEngine.SqlServer)
                 .CreateContext()
                .ShouldBeOfType<SqlServerSecurityContext>()
                .ShouldNotBeNull();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresSecurityContext()
        {
            var connectionstringProvider = A.Fake<ISecurityDatabaseConnectionStringProvider>();

            A.CallTo(() => connectionstringProvider.GetConnectionString()).Returns(
                "Host=localhost; Port=5432; Username=postgres; Database=EdFi_Security; Application Name=EdFi.Ods.WebApi;");

            new SecurityContextFactory(connectionstringProvider, DatabaseEngine.Postgres)
                .CreateContext()
                .ShouldBeOfType<PostgresSecurityContext>()
                .ShouldNotBeNull();
        }

        private class UnsupportedDatabaseEngine : DatabaseEngine
        {
            public UnsupportedDatabaseEngine()
                : base("unsupported", "Unsupported Database Engine", null) { }
        }

        [Test]
        public void Given_configured_for_Unsupported_then_throws_invalid_operation_exception()
        {
            var connectionstringProvider = A.Fake<ISecurityDatabaseConnectionStringProvider>();

            A.CallTo(() => connectionstringProvider.GetConnectionString()).Returns(
                "Host=localhost; Port=5432; Username=postgres; Database=EdFi_Security; Application Name=EdFi.Ods.WebApi;");

            Should.Throw<InvalidOperationException>(() => new SecurityContextFactory(connectionstringProvider, new UnsupportedDatabaseEngine())
            .CreateContext());
        }
    }
}
