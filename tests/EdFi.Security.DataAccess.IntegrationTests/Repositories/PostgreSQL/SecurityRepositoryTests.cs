// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Transactions;
using EdFi.Common.Configuration;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using Microsoft.EntityFrameworkCore;


namespace EdFi.Security.DataAccess.IntegrationTests.Repositories.PostgreSQL
{
    /// <summary>
    /// This is a light-weight set of integration tests that only tries to prove
    /// that there is database connectivity without trying to carefully validate
    /// business logic.
    /// </summary>
    [TestFixture]
    public class SecurityRepositoryTests
    {
        protected PostgresSecurityContext Context;
        private SecurityRepository _repository;
        protected TransactionScope Transaction;

        [SetUp]
        public void Setup()
        {
            // Read settings
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.Development.json", true, true);

            var config = builder.Build();
            var engine = config.GetSection("ApiSettings")["Engine"] ?? "";

            if (!engine.Equals(DatabaseEngine.Postgres.Value, StringComparison.OrdinalIgnoreCase))
            {
                Assert.Inconclusive("PostgresSQL SecurityRepo integration tests are not being run because the engine is not set to Postgres.");
            }

            // Setup PostgreSQL
            var connectionString = config.GetConnectionString("EdFi_Security");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLowerCaseNamingConvention();
            Context = new PostgresSecurityContext(optionsBuilder.Options);

            // Startup a transaction so we can dispose of any changes after running the tests
            Transaction = new TransactionScope();

            // Configure settings mocks
            var securityContextFactory = A.Fake<ISecurityContextFactory>();

            A.CallTo(() => securityContextFactory.CreateContext())
                .ReturnsLazily(() => Context = new PostgresSecurityContext(optionsBuilder.Options));

            // Create the system under test
            _repository = new SecurityRepository(securityContextFactory);

            Context.SaveChangesForTest();
        }

        [TearDown]
        public void Teardown()
        {
            Transaction?.Dispose();
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