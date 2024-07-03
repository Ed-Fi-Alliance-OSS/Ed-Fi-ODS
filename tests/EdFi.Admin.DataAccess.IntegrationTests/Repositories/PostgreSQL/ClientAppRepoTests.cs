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
using Microsoft.IdentityModel.Tokens;
using EdFi.Common.Configuration;

// ReSharper disable once InconsistentNaming
namespace EdFi.Admin.DataAccess.IntegrationTests.Repositories.PostgreSQL
{
    [TestFixture]
    public class ClientAppRepoTests
    {
        private const int BearerTokenTimeoutMinutes = 10;
        private const string DefaultOperationalContextUri = "uri://ed-fi.org";
        private const string DefaultApplicationName = "Integration Test";
        private const string DefaultClaimSetName = "SIS Vendor";

        protected PostgresUsersContext Context;
        protected PostgresUsersContext OpenContext;
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
            var engine = config.GetSection("ApiSettings")["Engine"] ?? "";

            if (!engine.Equals(DatabaseEngine.Postgres.Value, StringComparison.OrdinalIgnoreCase))
            {
                Assert.Inconclusive("PostgresSQL SecurityRepo integration tests are not being run because the engine is not set to Postgres.");
            }

            // Setup PostgreSQL
            var connectionString = config.GetConnectionString("PostgreSQL");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);
            Context = new PostgresUsersContext(optionsBuilder.Options);
            OpenContext = new PostgresUsersContext(optionsBuilder.Options);

            // Startup a transaction so we can dispose of any changes after running the tests
            Transaction = new TransactionScope();

            // Configure settings mocks
            var usersContextFactory = A.Fake<IUsersContextFactory>();
            A.CallTo(() => usersContextFactory.CreateContext())
                .Returns(Context);

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
            Context.Clients.Add(_testClient);
            Context.SaveChangesForTest();
        }

        [TearDown]
        public void Teardown()
        {
            Transaction?.Dispose();
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
        public class When_getting_a_client_and_all_related_properties : ClientAppRepoTests
        {
            private const string ClientName = "zsdfasdf";
            private ApiClient _result;

            [SetUp]
            public void SetUp()
            {
                // Arrange
                // Adding vendor, namespace prefix, profiles, education organizations,
                // and ownership token in order to test the Entity Framework
                // hydration of those properties on the client
                var client = new ApiClient
                {
                    Name = ClientName,
                    Key = "987sal;ifasd",
                    Secret = "987asdkif"
                };
                OpenContext.Clients.Add(client);

                var vendor = new Vendor
                {
                    VendorName = "vendor name"
                };
                OpenContext.Vendors.Add(vendor);

                var namespacePrefix = new VendorNamespacePrefix
                {
                    NamespacePrefix = "abc",
                    Vendor = vendor
                };
                vendor.VendorNamespacePrefixes.Add(namespacePrefix);
                OpenContext.VendorNamespacePrefixes.Add(namespacePrefix);

                var application = new Application
                {
                    Vendor = vendor,
                    ApplicationName = "a",
                    OperationalContextUri = "uri://ed-fi.org"
                };
                client.Application = application;
                application.ApiClients.Add(client);

                vendor.Applications.Add(application);
                OpenContext.Applications.Add(application);

                var profile = new Profile
                {
                    ProfileName = "profile"
                };
                application.Profiles.Add(profile);
                profile.Applications.Add(application);
                OpenContext.Profiles.Add(profile);

                var token = new OwnershipToken
                {
                    Description = "sddsdsf"
                };
                token.Clients.Add(client);
                client.CreatorOwnershipToken = token;
                OpenContext.OwnershipTokens.Add(token);

                OpenContext.SaveChangesForTest();

                // Uncomment next two lines only for debugging.
                // PostgreSQL does not have a "read uncommitted" isolation level, therefore
                // this is the only way to manually query the database for inspection while
                // debugging the test.
                //Transaction.Complete();
                //Transaction = new TransactionScope();

                // Act
                _result = _clientAppRepo.GetClient(client.Key);
            }

            [Test]
            public void Then_result_not_be_null()
            {
                _result.ShouldNotBeNull();
            }

            [Test]
            public void Then_result_should_be_the_correct_client()
            {
                _result.Name.ShouldBe(ClientName);
            }

            [Test]
            public void Then_result_should_have_a_hydrated_application()
            {
                _result.Application.ShouldNotBeNull();
            }

            [Test]
            public void Then_result_should_have_a_hydrated_vendor()
            {
                _result.Application.Vendor.ShouldNotBeNull();
            }

            [Test]
            public void Then_result_should_have_a_hydrated_vendor_namespace()
            {
                _result.Application.Vendor.VendorNamespacePrefixes.ShouldHaveSingleItem();
            }

            [Test]
            public void Then_result_should_have_a_hydrated_profile()
            {
                _result.Application.Profiles.ShouldHaveSingleItem();
            }

            [Test]
            public void Then_result_should_have_a_hydrated_ownership_token()
            {
                _result.CreatorOwnershipToken.ShouldNotBeNull();
            }
        }

        [TestFixture]
        public class When_getting_client_by_key : ClientAppRepoTests
        {
            [Test]
            public void Given_Invalid_key_should_return_null()
            {
                var tmpClient = _clientAppRepo.GetClient("does not exist");
                tmpClient.ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_updating_a_client : ClientAppRepoTests
        {
            [Test]
            public void Given_valid_client_should_save_update()
            {
                const string tempName = "new name";
                _testClient.Name = tempName;
                _clientAppRepo.UpdateClient(_testClient);

                OpenContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
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

                OpenContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
            }
        }

        [TestFixture]
        public class When_deleting_a_client : ClientAppRepoTests
        {
            [Test]
            public void Given_valid_client_it_should_delete()
            {
                _clientAppRepo.DeleteClient(_testClient.Key);

                OpenContext.Clients.Count(x => x.Name == _testClient.Name).ShouldBe(0);
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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);
                OpenContext.SaveChangesForTest();

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

                OpenContext.Vendors.Add(vendor);
                OpenContext.SaveChangesForTest();

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
                OpenContext.Users.Add(user);
                OpenContext.SaveChangesForTest();

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
                OpenContext.Clients.Count(x => x.Name == tempName).ShouldBe(1);
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
                OpenContext.Users.Add(user);

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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                OpenContext.SaveChangesForTest();

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
                var saved = OpenContext.Clients.FirstOrDefault(x => x.Name == tempName);
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
                OpenContext.Users.Add(user);
                OpenContext.SaveChangesForTest();

                // Act
                const string clientName = "Given_user_exists_it_should_save...";
                const string key = "key";
                const string secret = "secret";

                _clientAppRepo.CreateApiClient(user.UserId, clientName, key, secret);

                // Assert
                var saved = OpenContext.Clients.FirstOrDefault(x => x.Name == clientName);
                saved.ShouldNotBeNull();
                saved.UseSandbox.ShouldBeTrue();
                saved.IsApproved.ShouldBeTrue();
                saved.SandboxType.ShouldBe(SandboxType.Sample);
            }

            // No negative testing here, because the code does not have proper safe guards
            // when the user does not exist. Will throw an exception.
        }

        [TestFixture]
        public class When_getting_users : ClientAppRepoTests
        {
            [Test]
            public void Given_there_are_no_users_it_should_return_an_empty_list()
            {
                _clientAppRepo.GetUsers().ShouldBeEmpty();
            }

            [Test]
            public void Given_there_is_a_user_with_an_application()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                OpenContext.Users.Add(user);

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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                var client = new ApiClient
                {
                    Name = "a",
                    Application = application,
                    Key = "key",
                    Secret = "secret"
                };
                application.ApiClients.Add(client);
                user.ApiClients.Add(client);

                OpenContext.SaveChangesForTest();

                // Act
                var result = _clientAppRepo.GetUsers();

                result.ShouldNotBeEmpty();
                result.First()
                    .ApiClients
                    .First()
                    .Application
                    .ApplicationName
                    .ShouldBe(application.ApplicationName);
            }
        }


        [TestFixture]
        public class When_getting_user_by_id : ClientAppRepoTests
        {
            [Test]
            public void Given_there_are_no_users_it_should_return_null()
            {
                _clientAppRepo.GetUser(-45678).ShouldBeNull();
            }

            [Test]
            public void Given_there_is_a_user_with_an_application()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                OpenContext.Users.Add(user);

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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                var client = new ApiClient
                {
                    Name = "a",
                    Application = application,
                    Key = "key",
                    Secret = "secret"
                };
                application.ApiClients.Add(client);
                user.ApiClients.Add(client);

                OpenContext.SaveChangesForTest();

                // Act
                var result = _clientAppRepo.GetUser(user.UserId);

                result.ShouldNotBeNull();
                result.ApiClients
                    .First()
                    .Application
                    .ApplicationName
                    .ShouldBe(application.ApplicationName);
            }
        }

        [TestFixture]
        public class When_getting_user_by_name : ClientAppRepoTests
        {
            [Test]
            public void Given_there_are_no_users_it_should_return_null()
            {
                _clientAppRepo.GetUser("-45678").ShouldBeNull();
            }

            [Test]
            public void Given_there_is_a_user_with_an_application()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                OpenContext.Users.Add(user);

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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                var client = new ApiClient
                {
                    Name = "a",
                    Application = application,
                    Key = "key",
                    Secret = "secret"
                };
                application.ApiClients.Add(client);
                user.ApiClients.Add(client);

                OpenContext.SaveChangesForTest();

                // Act
                var result = _clientAppRepo.GetUser(user.Email);

                result.ShouldNotBeNull();
                result.ApiClients
                    .First()
                    .Application
                    .ApplicationName
                    .ShouldBe(application.ApplicationName);
            }
        }

        [TestFixture]
        public class When_deleting_a_user : ClientAppRepoTests
        {
            [Test]
            public void Given_there_are_no_users_it_should_not_do_anything()
            {
                _clientAppRepo.DeleteUser(new User { Email = "-45678" } );
                // Sufficient to show that no exceptions occur
            }

            [Test]
            public void Given_there_is_a_user_with_an_application_it_should_delet_user_and_clients()
            {
                // Arrange
                var user = new User
                {
                    FullName = "a",
                    Email = "b@example.com"
                };
                OpenContext.Users.Add(user);

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
                OpenContext.Vendors.Add(vendor);
                OpenContext.Applications.Add(application);

                user.Vendor = vendor;
                vendor.Users.Add(user);

                var client = new ApiClient
                {
                    Name = "a",
                    Application = application,
                    Key = "key",
                    Secret = "secret"
                };
                application.ApiClients.Add(client);
                user.ApiClients.Add(client);

                OpenContext.SaveChangesForTest();

                // Act
                _clientAppRepo.DeleteUser(user);

                // Assert

                OpenContext.Users.Count(x => x.Email == user.Email).ShouldBe(0);
                OpenContext.Clients.Count(x => x.Name == client.Name).ShouldBe(0);
            }
        }
    }
}
