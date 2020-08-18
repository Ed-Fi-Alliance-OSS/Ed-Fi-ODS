// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Sandbox.Security;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using EdFi.Ods.Sandbox.Provisioners;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    [TestFixture]
    public class EdFiAdminApiClientIdentityProviderTests
    {
        public class When_calling_GetApiClientIdentity : TestFixtureBase
        {
            private TransactionScope _transaction;
            private ApiClient _testClient;
            private IApiClientIdentityProvider _apiClientIdentityProvider;
            private readonly int[] _expectedEducationOrganizations =
            {
                123, 321
            };
            private readonly string[] _expectedProfiles =
            {
                "profile1", "profile2", "profile3"
            };
            private ApiClientIdentity _actualApiClientIdentity;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();

                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                var edOrgs = _expectedEducationOrganizations
                            .Select(
                                 edOrgId =>
                                     new ApplicationEducationOrganization
                                     {
                                         EducationOrganizationId = edOrgId
                                     })
                            .ToList();

                var profiles = _expectedProfiles.Select(
                                                     profile => new Profile
                                                                {
                                                                    ProfileName = profile
                                                                })
                                                .ToList();

                var application = new Application
                                  {
                                      Profiles = profiles, ClaimSetName = "MyTestClaimSetName", Vendor = new Vendor
                                                                                                         {
                                                                                                             VendorNamespacePrefixes =
                                                                                                                 new List<VendorNamespacePrefix>
                                                                                                                 {
                                                                                                                     new VendorNamespacePrefix
                                                                                                                     {
                                                                                                                         NamespacePrefix =
                                                                                                                             "MyTestNamespacePrefix"
                                                                                                                     }
                                                                                                                 }
                                                                                                         },
                                      OperationalContextUri = "uri://ed-fi-api-host.org"
                                  };

                _testClient = new ApiClient(true)
                              {
                                  Name = $"ClientAppRepoTest{Guid.NewGuid():N}", Application = application, ApplicationEducationOrganizations = edOrgs
                              };

                using (var context = new SqlServerUsersContext())
                {
                    context.Clients.Add(_testClient);
                    context.SaveChanges();
                }

                _apiClientIdentityProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _actualApiClientIdentity = _apiClientIdentityProvider.GetApiClientIdentity(_testClient.Key);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_get_client_identity()
            {
                Assert.That(_actualApiClientIdentity, Is.Not.Null);
                Assert.That(_actualApiClientIdentity.ClaimSetName, Is.EqualTo(_testClient.Application.ClaimSetName));
                Assert.That(_actualApiClientIdentity.Key, Is.EqualTo(_testClient.Key));

                Assert.That(
                    _actualApiClientIdentity.NamespacePrefixes,
                    Is.EqualTo(_testClient.Application.Vendor.VendorNamespacePrefixes.Select(vnp => vnp.NamespacePrefix)));

                Assert.That(_actualApiClientIdentity.EducationOrganizationIds, Is.EquivalentTo(_expectedEducationOrganizations));
                Assert.That(_actualApiClientIdentity.Profiles, Is.EquivalentTo(_expectedProfiles));
            }
        }

        public class When_calling_GetApiClientIdentity_with_null_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientIdentityProvider _apiClientIdentityProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();

                var usersContextFactory = Stub<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientIdentityProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientIdentityProvider.GetApiClientIdentity(null);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }

        public class When_calling_GetApiClientIdentity_with_empty_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientIdentityProvider _apiClientIdentityProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientIdentityProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientIdentityProvider.GetApiClientIdentity(string.Empty);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }

        public class When_calling_GetApiClientIdentity_with_invalid_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientIdentityProvider _apiClientIdentityProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientIdentityProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientIdentityProvider.GetApiClientIdentity("InvalidKey");
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }

        public class When_calling_GetSecret : TestFixtureBase
        {
            private TransactionScope _transaction;
            private ApiClient _testClient;
            private IApiClientSecretProvider _apiClientSecretProvider;
            private ApiClientSecret _actualApiClientSecret;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _testClient = new ApiClient(true)
                              {
                                  Name = $"ClientAppRepoTest{Guid.NewGuid():N}", Secret = "MySecret"
                              };

                using (var context = new SqlServerUsersContext())
                {
                    context.Clients.Add(_testClient);
                    context.SaveChanges();
                }

                _apiClientSecretProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _actualApiClientSecret = _apiClientSecretProvider.GetSecret(_testClient.Key);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_get_client_secret()
            {
                Assert.That(_actualApiClientSecret, Is.Not.Null);
                Assert.That(_actualApiClientSecret.Secret, Is.EqualTo(_testClient.Secret));
            }
        }

        public class When_calling_GetSecret_with_null_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientSecretProvider _apiClientSecretProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientSecretProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientSecretProvider.GetSecret(null);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }

        public class When_calling_GetSecret_with_empty_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientSecretProvider _apiClientSecretProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientSecretProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientSecretProvider.GetSecret(string.Empty);
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }

        public class When_calling_GetSecret_with_invalid_key : TestFixtureBase
        {
            private TransactionScope _transaction;
            private IApiClientSecretProvider _apiClientSecretProvider;

            protected override void Arrange()
            {
                _transaction = new TransactionScope();

                var configValueProviderStub = Stub<IConfigValueProvider>();
                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(new SqlServerUsersContext());

                var clientAppRepo = new ClientAppRepo(usersContextFactory, configValueProviderStub);

                _apiClientSecretProvider = new EdFiAdminApiClientIdentityProvider(clientAppRepo);
            }

            protected override void Act()
            {
                _apiClientSecretProvider.GetSecret("InvalidKey");
            }

            [OneTimeTearDown]
            protected void AfterBehaviorExecution()
            {
                _transaction.Dispose();
            }

            [Test]
            public void Should_throw_argument_exception()
            {
                Assert.That(ActualException, Is.TypeOf<ArgumentException>());
            }
        }
    }
}
