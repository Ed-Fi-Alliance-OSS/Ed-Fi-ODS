// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using Microsoft.EntityFrameworkCore;

namespace EdFi.SecurityCompatibility53.DataAccess.IntegrationTests.Repositories.MSSQL
{
    /// <summary>
    /// This is a light-weight set of integration tests that only tries to prove
    /// that there is database connectivity without trying to carefully validate
    /// business logic.
    /// </summary>
    [TestFixture]
    public class SecurityRepositoryTests
    {
        private SecurityRepository _repository;
        protected SqlServerSecurityContext Context;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("MSSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            Context = new SqlServerSecurityContext(optionsBuilder.Options);

            var contextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => contextFactory.CreateContext()).Returns(Context);

            _repository = new SecurityRepository(contextFactory);
        }

        [TestCase("GET", "Read")]
        [TestCase("POST", "Create")]
        [TestCase("PUT", "Update")]
        [TestCase("DELETE", "Delete")]
        public void GetActionByHttpVerb(string verb, string expected)
        {
            _repository.GetActionByHttpVerb(verb).ActionName.ShouldBe(expected);
        }

        [Test]
        public void GetAuthorizationStrategyByName()
        {
            _repository.GetAuthorizationStrategyByName("NoFurtherAuthorizationRequired").AuthorizationStrategyName.ShouldBe("NoFurtherAuthorizationRequired");
        }
    }
}