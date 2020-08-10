// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Admin.Initialization;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Admin.Services;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using EdFi.Ods.Sandbox.Repositories;

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Services
{
    [TestFixture]
    public class ClientCreatorTests
    {
        public class When_creating_a_sandbox_client : TestFixtureBase
        {
            private ApiClient _apiClient;

            protected override void Arrange()
            {
                const int VendorId = 444;
                const SandboxType SandboxType = SandboxType.Minimal;

                var defaultApplicationCreator = A.Fake<IDefaultApplicationCreator>();

                var application = new Application {ApplicationName = "Application.ApplicationName"};
                application.CreateApplicationEducationOrganization(111);
                application.CreateApplicationEducationOrganization(222);
                application.CreateApplicationEducationOrganization(333);

                A.CallTo(
                        () =>
                            defaultApplicationCreator.FindOrCreateUpdatedDefaultSandboxApplication(VendorId, SandboxType))
                    .Returns(application);

                ApiClient apiClient = new ApiClient {Name = "ApiClient.Name"};

                var clientAppRepo = A.Fake<IClientAppRepo>();
                var user = new User {Vendor = new Vendor {VendorId = VendorId}};

                var sandboxClientCreateModel = new SandboxInitializationModel
                {
                    Name = "SandboxInitializationModel.Name",
                    SandboxType = SandboxType
                };

                A.CallTo(
                    () => clientAppRepo.SetupDefaultSandboxClient(
                        sandboxClientCreateModel.Name,
                        sandboxClientCreateModel.SandboxType,
                        null,
                        null,
                        user.UserId,
                        application.ApplicationId)).Returns(apiClient);

                var clientAppConfigValueProviderRepo = A.Fake<IConfigValueProvider>();

                var sandboxProvisioner = A.Fake<ISandboxProvisioner>();

                var creator = new ClientCreator(clientAppConfigValueProviderRepo, clientAppRepo, defaultApplicationCreator, sandboxProvisioner);
                _apiClient = creator.CreateNewSandboxClient(sandboxClientCreateModel, user);
            }

            [Test]
            public void Should_attempt_to_create_new_client()
            {
                _apiClient.ShouldNotBeNull();
            }
        }

        public class
            When_creating_a_sandbox_client_and_the_maximum_number_of_clients_pre_application_has_not_been_reached :
                TestFixtureBase
        {
            private IConfigValueProvider _configValueProvider;
            private IClientAppRepo _clientAppRepo;
            private IDefaultApplicationCreator _defaultApplicationCreator;
            private ClientCreator _clientCreator;
            private User _user;
            private ISandboxProvisioner _sandboxProvisioner;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();

                _clientAppRepo = A.Fake<IClientAppRepo>();

                _defaultApplicationCreator = A.Fake<IDefaultApplicationCreator>();

                _sandboxProvisioner = A.Fake<ISandboxProvisioner>();

                _clientCreator = new ClientCreator(_configValueProvider, _clientAppRepo, _defaultApplicationCreator, _sandboxProvisioner);

                _user = A.Fake<User>();
                A.CallTo(() => _user.ApiClients).Returns(new List<ApiClient>());
            }

            protected override void Act()
            {
                _ = _clientCreator.CreateNewSandboxClient(A.Fake<SandboxInitializationModel>(), _user);
            }

            [Test]
            public void Should_attempt_to_get_config_value()
            {
                A.CallTo(() => _configValueProvider.GetValue(A<string>._)).MustHaveHappened();
            }

            [Test]
            public void Should_not_throw_an_error()
            {
                ActualException.ShouldBeNull();
            }

            [Test]
            public void Should_call_to_setup_a_new_sandbox_client()
            {
                A.CallTo(
                        () => _clientAppRepo.SetupDefaultSandboxClient(
                            A<string>._,
                            A<SandboxType>._,
                            A<string>._,
                            A<string>._,
                            A<int>._,
                            A<int>._))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_call_to_find_the_default_sandbox_client()
            {
                A.CallTo(
                    () => _defaultApplicationCreator
                        .FindOrCreateUpdatedDefaultSandboxApplication(A<int>._, A<SandboxType>._)).MustHaveHappened();
            }
        }

        public class
            When_creating_a_sandbox_client_and_the_maximum_number_of_clients_pre_application_has_been_reached : TestFixtureBase
        {
            private IConfigValueProvider _configValueProvider;
            private IClientAppRepo _clientAppRepo;
            private IDefaultApplicationCreator _defaultApplicationCreator;
            private ClientCreator _clientCreator;
            private User _user;
            private ISandboxProvisioner _sandboxProvisioner;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                A.CallTo(() => _configValueProvider.GetValue(A<string>._)).Returns("5");

                _clientAppRepo = A.Fake<IClientAppRepo>();

                _defaultApplicationCreator = A.Fake<IDefaultApplicationCreator>();

                _sandboxProvisioner = A.Fake<ISandboxProvisioner>();

                _clientCreator = new ClientCreator(_configValueProvider, _clientAppRepo, _defaultApplicationCreator, _sandboxProvisioner);

                _user = A.Fake<User>();

                A.CallTo(() => _user.ApiClients).Returns(
                    new List<ApiClient>
                    {
                        A.Fake<ApiClient>(),
                        A.Fake<ApiClient>(),
                        A.Fake<ApiClient>(),
                        A.Fake<ApiClient>(),
                        A.Fake<ApiClient>()
                    });
            }

            protected override void Act()
            {
                _ = _clientCreator.CreateNewSandboxClient(A.Fake<SandboxInitializationModel>(), _user);
            }

            [Test]
            public void Should_attempt_to_get_config_value()
            {
                A.CallTo(() => _configValueProvider.GetValue(A<string>._)).MustHaveHappened();
            }

            [Test]
            public void Should_throw_an_error()
            {
                ActualException.ShouldBeOfType<ArgumentOutOfRangeException>();
            }

            [Test]
            public void Should_not_call_to_setup_a_new_sandbox_client()
            {
                A.CallTo(
                        () => _clientAppRepo.SetupDefaultSandboxClient(
                            A<string>._,
                            A<SandboxType>._,
                            A<string>._,
                            A<string>._,
                            A<int>._,
                            A<int>._))
                    .MustNotHaveHappened();
            }

            [Test]
            public void Should_not_call_to_find_the_default_sandbox_client()
            {
                A.CallTo(
                    () => _defaultApplicationCreator
                        .FindOrCreateUpdatedDefaultSandboxApplication(A<int>._, A<SandboxType>._)).MustNotHaveHappened();
            }
        }
    }
}
