// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Admin.DataAccess.Models;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Admin.DataAccess.UnitTests
{
    public class UserTests
    {
        [TestFixture]
        public class When_creating_a_sandbox_client_without_specifying_a_key_and_secret
        {
            private User _user;
            private ApiClient _client;

            [OneTimeSetUp]
            public void Setup()
            {
                _user = new User();
                _client = _user.AddSandboxClient("MyClientName", SandboxType.Minimal, string.Empty, string.Empty);
            }

            [Test]
            public void Should_add_client_to_user()
            {
                var clients = _user.ApiClients.ToArray();
                clients.Length.ShouldBe(1);

                clients[0]
                   .ShouldBeSameAs(_client);
            }

            [Test]
            public void Should_set_approved_status_to_true()
            {
                _client.IsApproved.ShouldBeTrue();
            }

            [Test]
            public void Should_set_key_and_secret_to_a_random_value()
            {
                _client.Key.ShouldNotBeNull();
                _client.Key.Length.ShouldBeGreaterThan(0);
                _client.Secret.ShouldNotBeNull();
                _client.Secret.Length.ShouldBeGreaterThan(0);
            }

            [Test]
            public void Should_set_sandbox_to_true()
            {
                _client.UseSandbox.ShouldBeTrue();
            }

            [Test]
            public void Should_set_sandbox_type()
            {
                _client.SandboxType.ShouldBe(SandboxType.Minimal);
            }

            [Test]
            public void Should_set_the_client_name()
            {
                _client.Name.ShouldBe("MyClientName");
            }
        }
    }
}
