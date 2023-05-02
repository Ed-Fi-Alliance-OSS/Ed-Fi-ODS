// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Configuration;
using EdFi.TestFixture;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Microsoft.Data.SqlClient;
using EdFi.Admin.DataAccess.DbConfigurations;
using EdFi.Ods.Api.Security.Authentication;
using Npgsql;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Admin.DataAccess.IntegrationTests.Repositories
{
    [TestFixture]
    public class AccessTokenClientRepoTests : TestFixtureBase
    {
        // Note: need to create two different UsersContext: one that is returned
        // by the factory - and which will be disposed by the methods under test -
        // and a second one available to the tests methods for direct database
        // interaction. Create transaction scope before opening either connection,
        // so that both are enrolled in the same transaction.

        private TransactionScope _transaction;
        private DatabaseEngine _databaseEngine;
        protected IUsersContext TestFixtureContext;

        private AdminDatabaseConnectionStringProvider _connectionStringProvider;

        // This original class under test was refactored into 2 classes, tests have not been rewritten
        protected ExpiredAccessTokenDeleter ExpiredAccessTokenDeleter;
        protected EdFiAdminRawApiClientDetailsProvider RawApiClientDetailsProvider;
        private DbProviderFactory _dbFactory;

        protected override void Arrange()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _transaction = new TransactionScope();
            
            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables()
                .Build();

            var engine = config.GetSection("ApiSettings").GetValue<string>("Engine");
            _databaseEngine = DatabaseEngine.TryParseEngine(engine);

            _connectionStringProvider = new AdminDatabaseConnectionStringProvider(new ConfigConnectionStringsProvider(config));
            DbConfiguration.SetConfiguration(new DatabaseEngineDbConfiguration(_databaseEngine));
            var userContextFactory = new UsersContextFactory(_connectionStringProvider, _databaseEngine);
            TestFixtureContext = userContextFactory.CreateContext();

            if (_databaseEngine == DatabaseEngine.Postgres)
            {
                ExpiredAccessTokenDeleter = new ExpiredAccessTokenDeleter(NpgsqlFactory.Instance, _connectionStringProvider);
                RawApiClientDetailsProvider = new EdFiAdminRawApiClientDetailsProvider(NpgsqlFactory.Instance, _connectionStringProvider);

                _dbFactory = NpgsqlFactory.Instance;
            }
            else if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                ExpiredAccessTokenDeleter = new ExpiredAccessTokenDeleter(SqlClientFactory.Instance, _connectionStringProvider);
                RawApiClientDetailsProvider = new EdFiAdminRawApiClientDetailsProvider(SqlClientFactory.Instance, _connectionStringProvider);

                _dbFactory = SqlClientFactory.Instance;
            }
            else
            {
                throw new NotSupportedException("Database engine not supported.");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Dispose without commit is an implicit rollback
            _transaction?.Dispose();
        }

        protected ApiClient LoadAnApiClient(Application application, int apiClientId)
        {
            var a = TestFixtureContext.Clients.Add(
                new ApiClient
                {
                    Key = "key",
                    Secret = "secret",
                    Name = "name",
                    IsApproved = true,
                    UseSandbox = true,
                    SandboxType = SandboxType.Minimal,
                    SecretIsHashed = false,
                    Application = application,
                    ApiClientId = apiClientId
                });

            TestFixtureContext.SaveChanges();
            return a;
        }

        protected ClientAccessToken LoadAnAccessToken(ApiClient client, DateTime expiration)
        {
            var a = TestFixtureContext.ClientAccessTokens.Add(
                new ClientAccessToken
                {
                    ApiClient = client,
                    Expiration = expiration,
                });

            TestFixtureContext.SaveChanges();

            return a;
        }

        protected Vendor LoadAVendor()
        {
            var a = TestFixtureContext.Vendors.Add(new Vendor());
            TestFixtureContext.SaveChanges();
            return a;
        }

        protected void LoadAVendorNamespacePrefix(Vendor vendor, string namespacePrefix)
        {
            vendor.VendorNamespacePrefixes.Add(
                new VendorNamespacePrefix
                {
                    NamespacePrefix = namespacePrefix,
                    Vendor = vendor
                });

            TestFixtureContext.SaveChanges();
        }

        protected Application LoadAnApplication(Vendor vendor, string claimSetName)
        {
            var a = TestFixtureContext.Applications.Add(
                new Application
                {
                    ClaimSetName = claimSetName,
                    Vendor = vendor,
                    OperationalContextUri = "uri://www.ed-fi.org"
                });

            TestFixtureContext.SaveChanges();

            return a;
        }

        protected ApplicationEducationOrganization LoadAnApplicationEducationOrganization(Application application,
            ApiClient client, int edOrgId)
        {
            var a = TestFixtureContext.ApplicationEducationOrganizations.Add(
                new ApplicationEducationOrganization
                {
                    Application = application,
                    Clients = new[] { client },
                    EducationOrganizationId = edOrgId
                });

            TestFixtureContext.SaveChanges();
            return a;
        }

        protected void LoadAProfile(Application application, string profileName)
        {
            TestFixtureContext.Profiles.Add(
                new Profile
                {
                    Applications = new[] { application },
                    ProfileName = profileName
                });

            TestFixtureContext.SaveChanges();
        }

        [TestFixture]
        public class Given_an_expired_token : AccessTokenClientRepoTests
        {
            [TestFixture]
            public class When_deleting_access_tokens : Given_an_expired_token
            {
                private ClientAccessToken _accessToken;

                protected override void Act()
                {
                    ExpiredAccessTokenDeleter.DeleteExpiredTokensAsync().Wait();
                }

                protected override void Arrange()
                {
                    base.Arrange();

                    var vendor = LoadAVendor();
                    var application = LoadAnApplication(vendor, "whatever");
                    var apiClient = LoadAnApiClient(application,1);
                    _accessToken = LoadAnAccessToken(apiClient, DateTime.UtcNow.AddSeconds(-10));
                }

                [Test]
                public void Should_delete_the_token()
                {
                    TestFixtureContext.ClientAccessTokens
                        .FirstOrDefault(x => x.Id == _accessToken.Id)
                        .ShouldBeNull();
                }
            }
        }

        [TestFixture]
        public class Given_an_unexpired_token : AccessTokenClientRepoTests
        {
            protected ClientAccessToken AccessToken;
            protected ApiClient Client;

            [TestFixture]
            public class When_deleting_access_tokens : Given_an_unexpired_token
            {
                protected override void Arrange()
                {
                    base.Arrange();

                    Client = LoadAnApiClient(null,0);
                    AccessToken = LoadAnAccessToken(Client, DateTime.UtcNow.AddSeconds(100));
                }

                protected override void Act()
                {
                    ExpiredAccessTokenDeleter.DeleteExpiredTokensAsync().Wait();
                }

                [Test]
                public void Should_ignore_the_token()
                {
                    TestFixtureContext.ClientAccessTokens
                        .FirstOrDefault(x => x.Id == AccessToken.Id)
                        .ShouldNotBeNull();
                }
            }

            [TestFixture]
            public class And_client_has_all_optional_data : Given_an_unexpired_token
            {
                protected IReadOnlyList<RawApiClientDetailsDataRow> Result;

                protected const string claimSetName = "Claim set name";
                protected const string namespacePrefix1 = "one";
                protected const string namespacePrefix2 = "two";
                protected const int edOrgId1 = 23;
                protected const int edOrgId2 = 34;
                protected const string profileName1 = "three";
                protected const string profileName2 = "four";
                protected const int apiClientId = 5;

                protected override void Arrange()
                {
                    base.Arrange();

                    var vendor = LoadAVendor();
                    LoadAVendorNamespacePrefix(vendor, namespacePrefix1);
                    LoadAVendorNamespacePrefix(vendor, namespacePrefix2);

                    var application = LoadAnApplication(vendor, claimSetName);

                    Client = LoadAnApiClient(application, apiClientId);
                    LoadAnApplicationEducationOrganization(application, Client, edOrgId1);
                    LoadAnApplicationEducationOrganization(application, Client, edOrgId2);

                    LoadAProfile(application, profileName1);
                    LoadAProfile(application, profileName2);

                    AccessToken = LoadAnAccessToken(Client, DateTime.UtcNow.AddSeconds(100));
                }

                protected override void Act()
                {
                    Result = RawApiClientDetailsProvider.GetRawClientDetailsDataAsync(AccessToken.Id)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
                }

                [TestFixture]
                public class When_getting_client_information : And_client_has_all_optional_data
                {
                    [Test]
                    public void Should_return_eight_records()
                    {
                        Result.ShouldNotBeNull();
                        Result.Count().ShouldBe(8);
                    }

                    [Test]
                    public void Should_include_the_ClaimSet_on_each_record()
                    {
                        Result.ShouldAllBe(x => x.ClaimSetName == claimSetName);
                    }

                    [Test]
                    public void Should_include_the_Key_on_each_record()
                    {
                        Result.ShouldAllBe(x => x.Key == Client.Key);
                    }

                    [Test]
                    public void Should_include_the_StudentIdentificationSystemDescriptor_on_each_record()
                    {
                        Result.ShouldAllBe(
                            x => x.StudentIdentificationSystemDescriptor == Client.StudentIdentificationSystemDescriptor);
                    }

                    [Test]
                    public void Should_include_UseSandbox_on_each_record()
                    {
                        Result.ShouldAllBe(x => x.UseSandbox == Client.UseSandbox);
                    }

                    [Test]
                    public void Should_have_four_records_with_first_EducationOrganizationId()
                    {
                        Result.Count(x => x.EducationOrganizationId == edOrgId1).ShouldBe(4);
                    }

                    [Test]
                    public void Should_have_four_records_with_second_EducationOrganizationId()
                    {
                        Result.Count(x => x.EducationOrganizationId == edOrgId2).ShouldBe(4);
                    }

                    [Test]
                    public void Should_have_four_records_with_first_NamespacePrefix()
                    {
                        Result.Count(x => x.NamespacePrefix == namespacePrefix1).ShouldBe(4);
                    }

                    [Test]
                    public void Should_have_four_records_with_second_NamespacePrefix()
                    {
                        Result.Count(x => x.NamespacePrefix == namespacePrefix2).ShouldBe(4);
                    }

                    [Test]
                    public void Should_have_four_records_with_first_ProfileName()
                    {
                        Result.Count(x => x.ProfileName == profileName1).ShouldBe(4);
                    }

                    [Test]
                    public void Should_have_four_records_with_second_ProfileName()
                    {
                        Result.Count(x => x.ProfileName == profileName2).ShouldBe(4);
                    }

                    [Test]
                    public void Should_include_apiClientId_on_each_record()
                    {
                        Result.ShouldAllBe(x => x.ApiClientId == Client.ApiClientId);
                    }
                }
            }

            [TestFixture]
            public class And_client_has_only_minimal_data : Given_an_unexpired_token
            {
                protected IReadOnlyList<RawApiClientDetailsDataRow> Result;

                protected override void Arrange()
                {
                    base.Arrange();

                    var application = LoadAnApplication(null, "Sandbox");
                    Client = LoadAnApiClient(application,5);
                    AccessToken = LoadAnAccessToken(Client, DateTime.UtcNow.AddSeconds(100));
                }

                protected override void Act()
                {
                    Result = RawApiClientDetailsProvider.GetRawClientDetailsDataAsync(AccessToken.Id)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();;
                }

                [TestFixture]
                public class When_getting_client_information : And_client_has_only_minimal_data
                {
                    [Test]
                    public void Should_return_one_record()
                    {
                        Result.ShouldNotBeNull();
                        Result.Count.ShouldBe(1);
                    }

                    [Test]
                    public void Should_have_null_EducationOrganizationId()
                    {
                        Result.ShouldAllBe(x => !x.EducationOrganizationId.HasValue);
                    }

                    [Test]
                    public void Should_have_null_ProfileName()
                    {
                        Result.ShouldAllBe(x => x.NamespacePrefix == null);
                    }

                    [Test]
                    public void Should_have_null_NamespacePrefix()
                    {
                        Result.ShouldAllBe(x => x.ProfileName == null);
                    }
                }
            }
        }
    }
}
