// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Shouldly;

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
            private DatabaseEngine _databaseEngine;

            [OneTimeSetUp]
            public void Setup()
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(TestContext.CurrentContext.TestDirectory)
                    .AddJsonFile("appsettings.json", false)
                    .AddJsonFile("appsettings.Development.json", true)
                    .AddEnvironmentVariables()
                    .Build();

                var engine = configuration.GetSection("ApiSettings").GetValue<string>("Engine");
                
                _databaseEngine = DatabaseEngine.TryParseEngine(engine);

                var connectionStringProvider = A.Fake<IAdminDatabaseConnectionStringProvider>();
                
                A.CallTo(() => connectionStringProvider.GetConnectionString()).Returns(
                    configuration.GetConnectionString("EdFi_Admin"));

                var usersContextFactory = new UsersContextFactory(connectionStringProvider, _databaseEngine);

                _clientAppRepo = new ClientAppRepo(usersContextFactory, configuration);

                _testClient = new ApiClient(true)
                {
                    Name = "ClientAppRepoTest" + Guid.NewGuid()
                        .ToString("N")
                };

                _clientAppRepo.UpdateClient(_testClient);
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
