// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Admin.DataAccess;
using EdFi.Ods.Admin.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace EdFi.Ods.Admin.Tests.Initialization
{
    public class InitializationSectionTests
    {
        [TestFixture]
        public class When_loading_an_initialization_section
        {
            [Test]
            public void Should_load_initialization_section()
            {
                //Arrange
                var config = new ConfigurationBuilder()
                    .SetBasePath(TestContext.CurrentContext.TestDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile("InitializationTest1.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                var serviceCollection = new ServiceCollection();
                serviceCollection.AddOptions();
                serviceCollection.Configure<InitializationOptions>(config.GetSection("initialization"));

                var serviceProvider = serviceCollection.BuildServiceProvider();

                //Act
                var section = serviceProvider.GetService<IOptions<InitializationOptions>>().Value;

                //Assert
                Assert.IsNotNull(section);
                Assert.AreEqual(true, section.Enabled);
                var users = section.Users;
                Assert.AreEqual(1, users.Length);

                var user = users[0];
                Assert.AreEqual("Test Admin", user.Name);
                Assert.AreEqual("test@ed-fi.org", user.Email);
                Assert.AreEqual("***REMOVED***", user.Password);

                var namespacePrefixes = user.NamespacePrefixes;
                Assert.AreEqual(2, namespacePrefixes.Length);
                Assert.AreEqual("uri://ed-fi.org", namespacePrefixes[0]);
                Assert.AreEqual("uri://gbisd.edu", namespacePrefixes[1]);

                var sandboxes = user.Sandboxes;
                Assert.AreEqual(2, sandboxes.Length);

                var sandbox = sandboxes[0];
                Assert.AreEqual("Populated Demonstration Sandbox", sandbox.Name);
                Assert.AreEqual("populatedSandbox", sandbox.Key);
                Assert.AreEqual("populatedSandboxSecret", sandbox.Secret);
                Assert.AreEqual(true, sandbox.Refresh);
                Assert.AreEqual(SandboxType.Sample, sandbox.Type);

                var secondSandbox = sandboxes[1];
                Assert.AreEqual("Minimal Demonstration Sandbox", secondSandbox.Name);
                Assert.AreEqual("populatedSandbox2", secondSandbox.Key);
                Assert.AreEqual("populatedSandboxSecret2", secondSandbox.Secret);
                Assert.AreEqual(true, secondSandbox.Refresh);
                Assert.AreEqual(SandboxType.Minimal, secondSandbox.Type);
            }
        }
    }
}
#endif