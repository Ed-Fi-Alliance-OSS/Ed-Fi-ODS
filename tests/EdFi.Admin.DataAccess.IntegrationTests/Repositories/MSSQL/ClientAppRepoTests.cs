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
using System.Linq;

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
        protected SqlServerUsersContext _openContext;
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
            _openContext = new SqlServerUsersContext(optionsBuilder.Options);

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

        [TestFixture]
        public class When_getting_client_by_key_and_secret : ClientAppRepoTests
        {
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

        [TestFixture]
        public class When_getting_client_by_key : ClientAppRepoTests
        {
            [Test]
            public void Given_key_and_secret_should_get_client()
            {
                var tmpClient = _clientAppRepo.GetClientByKey(_testClient.Key);
                tmpClient.ShouldNotBeNull();
                tmpClient.Name.ShouldBe(_testClient.Name);
            }

            [Test]
            public void Given_Invalid_key_should_return_null()
            {
                var tmpClient = _clientAppRepo.GetClient("does not exist");
                tmpClient.ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_updating_a_client :ClientAppRepoTests
        {
            [Test]
            public void Given_valid_client_should_save_update()
            {
                const string tempName = "new name";
                _testClient.Name = tempName;

                _clientAppRepo.UpdateClient(_testClient);

                _openContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
            }

            [Test]
            public void Given_new_client_should_upsert()
            {
                const string tempName = "new name";
                var client = new ApiClient
                {
                    Key = "a",
                    Secret = "b",
                    Name = tempName
                };

                 _clientAppRepo.UpdateClient(client);

                _openContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
            }
        }

        [TestFixture]
        public class When_deleting_a_client : ClientAppRepoTests
        {
            [Test]
            public void Given_valid_client_it_should_delete()
            {
                _clientAppRepo.DeleteClient(_testClient.Key);

                _openContext.Clients.Count(x => x.Name == _testClient.Name).ShouldBe(0);
            }
        }

        [TestFixture]
        public class When_getting_vendor_applications : ClientAppRepoTests
        {
            [Test]
            public void Given_a_vendor_has_an_application_it_should_return_that_application()
            {
                // Arrange
                var vendor = new Vendor
                {
                    VendorName = "vendor name"
                };
                var application = new Application
                {
                    Vendor = vendor,
                    ApplicationName = "a",
                    OperationalContextUri = "uri://ed-fi.org"
                };
                vendor.Applications.Add(application);
                _openContext.Vendors.Add(vendor);
                _openContext.Applications.Add(application);
                _openContext.SaveChangesForTest();

                // Act
                var result = _clientAppRepo.GetVendorApplications(vendor.VendorId);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBe(1);
                result.Count(x => x.ApplicationName == application.ApplicationName).ShouldBe(1);
            }

            [Test]
            public void Given_a_vendor_has_no_applications_it_should_return_an_empty_array()
            {
                // Arrange
                var vendor = new Vendor
                {
                    VendorName = "vendor name"
                };
  
                _openContext.Vendors.Add(vendor);
                _openContext.SaveChangesForTest();

                // Act
                var result = _clientAppRepo.GetVendorApplications(vendor.VendorId);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBe(0);
            }
        }


        [TestFixture]
        public class When_adding_api_client_to_user : ClientAppRepoTests
        {
            [Test]
            public void Given_user_does_not_exist_it_should_do_nothing()
            {
                _clientAppRepo.AddApiClientToUserWithVendorApplication(7777777, _testClient);
            }

            [Test]
            public void Given_user_exists_but_vendor_does_not_it_should_save_the_new_client()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                _openContext.Users.Add(user);
                _openContext.SaveChangesForTest();

                const string tempName = "Given_user_exists_but_vendor_does_not";
                var client = new ApiClient
                {
                    Key = "a",
                    Secret = "b",
                    Name = tempName
                };

                // Act
                _clientAppRepo.AddApiClientToUserWithVendorApplication(user.UserId, client);

                // Assert
                _openContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
            }

            [Test]
            public void Given_user_and_vendor_exist_it_should_attach_first_application_to_the_client()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                _openContext.Users.Add(user);

                var vendor = new Vendor
                {
                    VendorName = "vendor name"
                };
                var application = new Application
                {
                    Vendor = vendor,
                    ApplicationName = "a",
                    OperationalContextUri = "uri://ed-fi.org"
                };
                vendor.Applications.Add(application);
                _openContext.Vendors.Add(vendor);
                _openContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                _openContext.SaveChangesForTest();

                const string tempName = "Given_user_and_vendor_exi...";
                var client = new ApiClient
                {
                    Key = "a",
                    Secret = "b",
                    Name = tempName
                };

                // Act
                _clientAppRepo.AddApiClientToUserWithVendorApplication(user.UserId, client);

                // Assert
                var saved = _openContext.Clients.FirstOrDefault(x => x.Name == tempName);
                saved.ShouldNotBeNull();

                saved.Application
                    .ApplicationName
                    .ShouldBe(application.ApplicationName);
            }
        }

        [TestFixture]
        public class When_creating_an_api_client : ClientAppRepoTests
        {
            [Test]
            public void Given_user_exists_it_should_save_the_new_client_for_sandbox()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                _openContext.Users.Add(user);
                _openContext.SaveChangesForTest();

                // Act
                const string clientName = "Given_user_exists_it_should_save...";
                const string key = "key";
                const string secret = "secret";

                _clientAppRepo.CreateApiClient(user.UserId, clientName, key, secret);

                // Assert
                var saved = _openContext.Clients.FirstOrDefault(x => x.Name == clientName);
                saved.ShouldNotBeNull();
                saved.UseSandbox.ShouldBeTrue();
                saved.IsApproved.ShouldBeTrue();
                saved.SandboxType.ShouldBe(SandboxType.Sample);
            }

            // No negative testing here, because the code does not have proper safe guards
            // when the user does not exist. Will throw an exception.
        }

    }
}
