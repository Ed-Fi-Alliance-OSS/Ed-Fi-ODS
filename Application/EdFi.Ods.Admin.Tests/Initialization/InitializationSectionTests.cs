// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.IO;
using EdFi.Admin.DataAccess;
using EdFi.Ods.Admin.Initialization;
using EdFi.Ods.Admin.Models;
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
                var fileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = Path.Combine(TestContext.CurrentContext.TestDirectory, "InitializationTest1.config")
                };

                var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                //Act
                var section = config.GetSection("initialization") as InitializationSection;

                //Assert
                Assert.IsNotNull(section);
                Assert.AreEqual(true, section.Enabled);
                var users = section.Users;
                Assert.AreEqual(1, users.Count);

                var user = users[0];
                Assert.AreEqual("Test Admin", user.Name);
                Assert.AreEqual("test@ed-fi.org", user.Email);
                Assert.AreEqual("***REMOVED***", user.Password);

                var sandboxes = user.Sandboxes;
                Assert.AreEqual(2, sandboxes.Count);

                var sandbox = sandboxes[0];
                Assert.AreEqual("Populated Demonstration Sandbox", sandbox.Name);
                Assert.AreEqual("populatedSandbox", sandbox.Key);
                Assert.AreEqual("populatedSandboxSecret", sandbox.Secret);
                Assert.AreEqual(true, sandbox.Refresh);
                Assert.AreEqual(SandboxType.Sample, sandbox.Type);
            }
        }
    }
}
