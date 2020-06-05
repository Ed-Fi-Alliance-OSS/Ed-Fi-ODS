// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Castle.Windsor;
using EdFi.Ods.Common;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Features.Profiles;
using EdFi.Ods.Profiles.Test;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup.InstallerTests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ProfilesInstallerTests
    {
        public class When_installing_profiles_using_the_profiles_installer : TestFixtureBase
        {
            private WindsorContainer _systemUnderTest;
            private IAssembliesProvider _assemblyProvider;

            protected override void Arrange()
            {
                _systemUnderTest = new WindsorContainerEx();

                _assemblyProvider = Stub<IAssembliesProvider>();

                A.CallTo(() => _assemblyProvider.GetAssemblies())
                    .Returns(
                        new []
                        {
                            // Possible assembly from a nuget 
                            Assembly.GetAssembly(typeof(IWindsorContainer)), 

                            // Profile Assembly we are looking for.
                            Assembly.GetAssembly(typeof(Marker_EdFi_Ods_Profiles_Test)),

                            // EdFi.Ods.Common
                            Assembly.GetAssembly(typeof(IMappable))
                        });
            }

            protected override void Act()
            {
                _systemUnderTest.Install(new ProfilesInstaller(_assemblyProvider));
            }

            [Test]
            public void Should_be_able_to_resolve_a_ApiController()
            {
                // Since we are not in a web scope, we can only inspect that the controllers are registered, so in this case we are using a known controller.
                _systemUnderTest.Kernel
                    .HasComponent(
                        "EdFi.Ods.Api.Services.Controllers.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object.AssessmentsController")
                    .ShouldBeTrue();
            }
        }
    }
}
