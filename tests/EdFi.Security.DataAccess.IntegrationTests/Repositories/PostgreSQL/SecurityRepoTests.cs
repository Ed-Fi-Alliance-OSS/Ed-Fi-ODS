// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Shouldly;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

// ReSharper disable once InconsistentNaming
namespace EdFi.Security.DataAccess.IntegrationTests.Repositories.PostgreSQL
{
    [TestFixture]
    public class SecurityRepoTests
    {
        protected PostgresSecurityContext Context;
        protected PostgresSecurityContext OpenContext;
        protected TransactionScope Transaction;

        [SetUp]
        public void Setup()
        {
            // Read settings
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true)
               .AddJsonFile($"appSettings.development.json", true, true);

            var config = builder.Build();

            // Setup PostgreSQL
            var connectionString = config.GetConnectionString("PostgreSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLowerCaseNamingConvention();
            Context = new PostgresSecurityContext(optionsBuilder.Options);
            OpenContext = new PostgresSecurityContext(optionsBuilder.Options);

            // Startup a transaction so we can dispose of any changes after running the tests
            Transaction = new TransactionScope();

            // Configure settings mocks
            var usersContextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => usersContextFactory.CreateContext())
                .Returns(Context);

            // Create the system under test
            _securityRepo = new SecurityRepository(usersContextFactory);

            // Load a fake Application
            _testApplication = new Application()
            {
                ApplicationName = "SecurityRepositoryTest" + Guid.NewGuid().ToString("N")
            };
            Context.Applications.Add(_testApplication);
            Context.SaveChangesForTest();
        }

        [TearDown]
        public void Teardown()
        {
            Transaction.Dispose();
        }

        private SecurityRepository _securityRepo;
        private Application _testApplication;


    }
}
