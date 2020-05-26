// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.Windsor;
using EdFi.Ods.CodeGen._Installers;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Installers
{
    [TestFixture]
    public class AppConfigInstallerTests
    {
        public class When_using_the_app_config_installer : TestFixtureBase
        {
            private IConfigurationRoot _configuration;
            private IWindsorContainer _container;

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller());
            }

            protected override void Act()
            {
                _configuration = _container.Resolve<IConfigurationRoot>();
            }

            [Test]
            public void Should_contain_the_connection_string()
            {
                _configuration.GetConnectionString("EdFi_Ods_Empty").ShouldNotBeNullOrEmpty();
            }

            [Test]
            public void Should_contain_the_location_of_the_code_repositories()
            {
                //TODO FIX ME
                // var codeRepositoryPath = _configuration[DirectoryConventions.CodeRepositoryPath];
                //
                // AssertAll(
                //     () => codeRepositoryPath.Should().NotBeNullOrEmpty(),
                //     () => File.Exists(codeRepositoryPath).Should().BeTrue());
            }
        }
    }
}
