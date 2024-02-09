// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Shouldly;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once InconsistentNaming
namespace EdFi.Admin.DataAccess.IntegrationTests.Repositories.MSSQL
{
    [TestFixture]
    public class ClientAppRepoTests
    {
        private const int BearerTokenTimeoutMinutes = 10;
        private const string DefaultOperationalContextUri = "uri://ed-fi.org";
        private const string DefaultApplicationName = "Integration Test";
        private const string DefaultClaimSetName = "SIS Vendor";

        protected SqlServerUsersContext _context;
        protected TransactionScope _transaction;

        [SetUp]
        public void Setup()
        {
            // Read settings
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true)
               .AddJsonFile($"appSettings.development.json", true, true);

            var config = builder.Build();
            
            // Setup SQL Server
            var connectionString = config.GetConnectionString("MSSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            _context = new SqlServerUsersContext(optionsBuilder.Options);

            // Startup a transaction so we can dispose of any changes after running the tests
            _transaction = new TransactionScope();

            // Configure settings mocks
            var usersContextFactory = A.Fake<IUsersContextFactory>();
            A.CallTo(() => usersContextFactory.CreateContext())
                .Returns(_context);

            var configValueProviderStub = A.Fake<IConfigurationRoot>();

            var tokenTimeoutSection = A.Fake<IConfigurationSection>();
            A.CallTo(() => tokenTimeoutSection.Value).Returns(BearerTokenTimeoutMinutes.ToString());
            A.CallTo(() => configValueProviderStub.GetSection("BearerTokenTimeoutMinutes")).Returns(tokenTimeoutSection);

            var contextSection = A.Fake<IConfigurationSection>();
            A.CallTo(() => contextSection.Value).Returns(DefaultOperationalContextUri);
            A.CallTo(() => configValueProviderStub.GetSection("DefaultOperationalContextUri")).Returns(contextSection);

            var appNameSection = A.Fake<IConfigurationSection>();
            A.CallTo(() => appNameSection.Value).Returns(DefaultApplicationName);
            A.CallTo(() => configValueProviderStub.GetSection("DefaultApplicationName")).Returns(appNameSection);

            var claimSetSection = A.Fake<IConfigurationSection>();
            A.CallTo(() => claimSetSection.Value).Returns(DefaultClaimSetName);
            A.CallTo(() => configValueProviderStub.GetSection("DefaultClaimSetName")).Returns(claimSetSection);

            // Create the system under test
            _clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

            // Load a fake API client
            _testClient = new ApiClient(true)
            {
                Name = "ClientAppRepoTest" + Guid.NewGuid().ToString("N")
            };
            _context.Clients.Add(_testClient);
            _context.SaveChangesForTest();
        }

        [TearDown]
        public void Teardown()
        {
            _transaction.Dispose();
        }

        private ClientAppRepo _clientAppRepo;
        private ApiClient _testClient;

        [Test]
        public void Should_get_client_with_key_and_secret()
        {
            var tmpClient = _clientAppRepo.GetClient(_testClient.Key, _testClient.Secret);
            tmpClient.ShouldNotBeNull();
            tmpClient.Name.ShouldBe(_testClient.Name);
        }

        [Test]
        public void Should_get_client_with_key_only()
        {
            var tmpClient = _clientAppRepo.GetClient(_testClient.Key);
            tmpClient.ShouldNotBeNull();
            tmpClient.Name.ShouldBe(_testClient.Name);
        }

        [Test]
        public void Should_not_get_client_with_key_and_empty_secret()
        {
            var tmpClient = _clientAppRepo.GetClient(_testClient.Key, string.Empty);
            tmpClient.ShouldBeNull();
        }

        [Test]
        public void Should_not_get_client_with_key_and_null_secret()
        {
            var tmpClient = _clientAppRepo.GetClient(_testClient.Key, null);
            tmpClient.ShouldBeNull();
        }
    }
}
