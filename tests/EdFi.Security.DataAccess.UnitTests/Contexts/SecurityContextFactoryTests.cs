// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using FakeItEasy;
using EdFi.Security.DataAccess.Contexts;
using NUnit.Framework;
using Shouldly;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Security.DataAccess.UnitTests.Contexts
{
    [TestFixture]
    public class SecurityContextFactoryTests
    {
        [Test]
        public void Given_null_argument_then_constructor_throws_exception()
        {
            Should.Throw<ArgumentNullException>(() => new SecurityContextFactory(null));
        }

        [Test]
        public void Given_configured_for_SqlServer_then_create_SqlServerSecurityContext()
        {
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(DatabaseEngine.SqlServer);

            new SecurityContextFactory(configurationProvider)
                .CreateContext()
                .ShouldBeOfType<SqlServerSecurityContext>()
                .ShouldNotBeNull();
        }

        [Test]
        public void Given_configured_for_Postgres_then_create_PostgresSecurityContext()
        {
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(DatabaseEngine.Postgres);

            new SecurityContextFactory(configurationProvider)
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
            var configurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => configurationProvider.DatabaseEngine).Returns(new UnsupportedDatabaseEngine());

            Should.Throw<InvalidOperationException>(() => new SecurityContextFactory(configurationProvider).CreateContext());
        }
    }
}
