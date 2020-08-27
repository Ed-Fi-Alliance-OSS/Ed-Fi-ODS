// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.InversionOfControl
{
    [TestFixture]
    public class RegistrationMethodsInstallerBaseTests
    {
        public class When_registering_components_using_method_signature_conventions : ScenarioFor<FakeRegistrationMethodsInstaller>
        {
            protected override void Act()
            {
                SystemUnderTest.Install(
                    Given<IWindsorContainer>(), 
                    Given<IConfigurationStore>());
            }

            [Test]
            public void Should_invoke_the_protected_virtual_registration_method()
            {
                SystemUnderTest.ProtectedVirtualCalled.ShouldBeTrue();
            }

            [Test]
            public void Should_invoke_the_protected_non_virtual_registration_method()
            {
                SystemUnderTest.ProtectedCalled.ShouldBeTrue();                
            }

            [Test]
            public void Should_invoke_the_private_registration_method()
            {
                SystemUnderTest.PrivateCalled.ShouldBeTrue();
            }

            [Test]
            public void Should_NOT_invoke_the_public_registration_method()
            {
                SystemUnderTest.PublicCalled.ShouldBeFalse();
            }

            [Test]
            public void Should_NOT_invoke_the_registration_method_with_the_wrong_name_prefix()
            {
                SystemUnderTest.WrongMethodPrefixCalled.ShouldBeFalse();
            }

            [Test]
            public void Should_NOT_invoke_the_registration_method_with_the_wrong_method_signature()
            {
                SystemUnderTest.WrongSignatureCalled.ShouldBeFalse();
            }
        }

        public class FakeRegistrationMethodsInstaller : RegistrationMethodsInstallerBase
        {
            public bool PublicCalled { get; private set; }

            public bool ProtectedVirtualCalled { get; private set; }

            public bool ProtectedCalled { get; private set; }

            public bool PrivateCalled { get; private set; }

            public bool WrongSignatureCalled { get; private set; }

            public bool WrongMethodPrefixCalled { get; private set; }
            
            protected virtual void RegisterSomethingProtectedVirtual(IWindsorContainer container)
            {
                ProtectedVirtualCalled = true;
            }

            protected void RegisterSomethingProtected(IWindsorContainer container)
            {
                ProtectedCalled = true;
            }

            private void RegisterSomethingPrivate(IWindsorContainer container)
            {
                PrivateCalled = true;
            }

            public void RegisterSomethingPublic(IWindsorContainer container)
            {
                PublicCalled = true;
            }

            private void RegisterWithWrongSignature(IWindsorContainer container, IConfigurationStore configurationStore)
            {
                WrongSignatureCalled = true;
            }

            protected void XRegisterSomethingWithWrongMethodPrefix(IWindsorContainer container)
            {
                WrongMethodPrefixCalled = true;
            }
        }
    }
}
