// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Sandbox.Provisioners;

// ReSharper disable once InconsistentNaming
namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox
{
    public class ClientAppRepoTests
    {
        [TestFixture]
        public class When_calling_the_clientAppRepo
        {
            private ClientAppRepo _clientAppRepo;
            private ApiClient _testClient;

            [OneTimeSetUp]
            public void Setup()
            {

                var sandboxProvisionerStub = A.Fake<ISandboxProvisioner>();
                var configValueProviderStub = A.Fake<IConfigValueProvider>();
                var usersContext = A.Fake<IUsersContext>();


                var usersContextFactory = A.Fake<IUsersContextFactory>();
                A.CallTo(() => usersContextFactory.CreateContext())
                    .Returns(usersContext);

                _clientAppRepo = new ClientAppRepo(usersContextFactory, sandboxProvisionerStub, configValueProviderStub);

                _testClient = new ApiClient(true)
                              {
                                  Name = "ClientAppRepoTest" + Guid.NewGuid()
                                                                   .ToString("N")
                              };

                var dbSet = new TestDbSet<ApiClient> {_testClient};

                A.CallTo(() => usersContext.Clients)
                    .Returns(dbSet);
            }


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
}
