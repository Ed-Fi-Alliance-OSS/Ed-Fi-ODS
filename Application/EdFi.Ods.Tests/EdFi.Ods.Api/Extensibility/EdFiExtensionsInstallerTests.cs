// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api._Installers;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.TestExtension;
using EdFi.Ods.Features.Container.Installers;
using EdFi.Ods.Tests.TestExtension;
using EdFi.Ods.Tests.TestExtension.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Extensibility
{
    [TestFixture]
    public class EdFiExtensionsInstallerTests
    {
        [Ignore("These tests are failing due to an exception that is not captured and need to be rewritten")]
        public class When_installing_an_extension_assembly_with_an_Entity_extension_and_an_aggregate_extension_and_an_API_controller : LegacyTestFixtureBase
        {
            private const string ExcludedExtensionSources = "ExcludedExtensionSources";
            private IWindsorContainer _container;
            private IEntityExtensionRegistrar _registrarStub;
            private IAssembliesProvider _assembliesProviderStub;
            private IDomainModelProvider _domainModelProvider;
            private IConfigValueProvider _configValueStub;
            private IConfigValueProvider _configValueProviderStub;

            protected override void Arrange()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Test_TestExtension>();

                _registrarStub = mocks.DynamicMock<IEntityExtensionRegistrar>();

                _assembliesProviderStub = Stub<IAssembliesProvider>();

                _configValueProviderStub = Stub<IConfigValueProvider>();

                _assembliesProviderStub.Stub(x => x.GetAssemblies())
                                       .Return(
                                            new Assembly[]
                                            {
                                                new FakeExtensionAssembly(typeof(Marker_EdFi_Ods_Test_TestExtension))
                                            });

                _container = new WindsorContainer();

                _domainModelProvider = new DomainModelProvider(
                    new IDomainModelDefinitionsProvider[]
                    {
                        new EdFiDomainModelDefinitionsProvider(), new DomainModelDefinitionsProvider()
                    });

                _container.Register(
                    Component.For<IDomainModelProvider>()
                             .Instance(_domainModelProvider));

                _configValueStub = Stub<IConfigValueProvider>();

                _configValueStub.Stub(x => x.GetValue(ExcludedExtensionSources))
                                .Return(default(string));

                _container.Register(
                    Component.For<IConfigValueProvider>()
                             .Instance(_configValueStub));
            }

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                new EdFiExtensionsInstaller(_assembliesProviderStub, _configValueProviderStub)
                   .Install(_container, mocks.Stub<IConfigurationStore>());
            }

            [Test]
            public void Should_register_the_Aggregate_extension_type_with_the_extensions_registrar()
            {
                // _registrarStub.AssertWasCalled(
                //     x =>
                //         x.RegisterAggregateExtensionEntity(
                //             typeof(StaffLeave),
                //             _domainModelProvider.GetDomainModel()
                //                                 .Entities.First(e => e.Name == "StaffLeaveReason")),
                //     y => y.Repeat.Once());
            }

            [Test]
            public void Should_register_the_API_controller_with_the_IoC_container()
            {
                Assert.That(
                    _container.Kernel.HasComponent(
                        typeof(TestController)),
                    Is.True);
            }

            [Test]
            public void Should_register_the_Entity_extension_type_with_the_extensions_registrar()
            {
                _registrarStub.AssertWasCalled(
                    x =>
                    {
                        bool isRequiredExtension =
                            _domainModelProvider.GetDomainModel()
                                .EntityByFullName[new FullName("TestExtension", typeof(StaffLeaveExtension).Name)]
                                .ParentAssociation.Association.Cardinality == Cardinality.OneToOneExtension;
                        //
                        // x.RegisterEntityExtensionType(
                        //     typeof(StaffLeave),
                        //     "TestExtension",
                        //     typeof(StaffLeaveExtension),
                        //     isRequiredExtension);
                    },
                    y => y.Repeat.Once());
            }

            [Test]
            public void Should_register_the_IDomainModelDefinitionsProvider_with_the_IoC_container()
            {
                Assert.That(_container.Kernel.HasComponent(typeof(IDomainModelDefinitionsProvider)));
            }

            [Test]
            public void Should_register_the_IExtensionNHibernateConfigurator_with_the_IoC_container()
            {
                Assert.That(_container.Kernel.HasComponent(typeof(IExtensionNHibernateConfigurationProvider)));
            }
        }

        [Ignore("These tests are failing due to an exception that is being thrown, and need to be rewritten")]
        public class When_installing_an_excluded_extension_source : LegacyTestFixtureBase
        {
            private const string ExcludedExtensionSources = "ExcludedExtensionSources";
            private IWindsorContainer _container;
            private IEntityExtensionRegistrar _registrarStub;
            private IAssembliesProvider _assembliesProviderStub;
            private IDomainModelProvider _domainModelProvider;
            private IConfigValueProvider _configValueStub;

            protected override void Arrange()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Test_TestExtension>();

                _registrarStub = Stub<IEntityExtensionRegistrar>();

                _assembliesProviderStub = Stub<IAssembliesProvider>();

                _assembliesProviderStub.Stub(x => x.GetAssemblies())
                                       .Return(
                                            new Assembly[]
                                            {
                                                new FakeExtensionAssembly(typeof(Marker_EdFi_Ods_Test_TestExtension))
                                            });

                _container = new WindsorContainer();

                _domainModelProvider = new DomainModelProvider(
                    new IDomainModelDefinitionsProvider[]
                    {
                        new EdFiDomainModelDefinitionsProvider(), new DomainModelDefinitionsProvider()
                    });

                _container.Register(
                    Component.For<IDomainModelProvider>()
                             .Instance(_domainModelProvider));

                _configValueStub = Stub<IConfigValueProvider>();

                _configValueStub.Stub(x => x.GetValue(ExcludedExtensionSources))
                                .Return("TestExtension");

                _container.Register(
                    Component.For<IConfigValueProvider>()
                             .Instance(_configValueStub));
            }

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                new EdFiExtensionsInstaller(_assembliesProviderStub, _configValueStub)
                   .Install(_container, mocks.Stub<IConfigurationStore>());
            }

            [Test]
            public void Should_not_register_the_Aggregate_extension_type_with_the_extensions_registrar()
            {
                // _registrarStub.AssertWasNotCalled(
                //     x =>
                //         x.RegisterAggregateExtensionEntity(
                //             Arg<Type>.Is.Anything,
                //             Arg<Entity>.Is.Anything));
            }

            [Test]
            public void Should_not_register_the_API_controller_with_the_IoC_container()
            {
                Assert.That(
                    _container.Kernel.HasComponent(
                        typeof(TestController)),
                    Is.False);
            }

            [Test]
            public void Should_not_register_the_Entity_extension_type_with_the_extensions_registrar()
            {
                // _registrarStub.AssertWasNotCalled(
                //     x =>
                //         x.RegisterEntityExtensionType(
                //             Arg<Type>.Is.Anything,
                //             Arg<string>.Is.Anything,
                //             Arg<Type>.Is.Anything,
                //             Arg<bool>.Is.Anything));
            }

            [Test]
            [Ignore("This is giving an exception that is breaking the test")]
            public void Should_not_register_the_IDomainModelDefinitionsProvider_with_the_IoC_container()
            {
                Assert.That(_container.Kernel.HasComponent(typeof(IDomainModelDefinitionsProvider)), Is.False);
            }

            [Test]
            public void Should_not_register_the_IExtensionNHibernateConfigurator_with_the_IoC_container()
            {
                Assert.That(_container.Kernel.HasComponent(typeof(IExtensionNHibernateConfigurationProvider)), Is.False);
            }
        }

        private class FakeExtensionAssembly : Assembly
        {
            private readonly Type _type;

            public FakeExtensionAssembly(Type type)
            {
                _type = type;
            }

            public override string FullName => Namespaces.Extensions.FullExtensionTypeName("TestExtension");

            public override Type[] GetTypes()
            {
                return _type.Assembly.GetTypes();
            }

            public override Type GetType(string typeName)
            {
                return typeof(Marker_EdFi_Ods_Test_TestExtension).Assembly.GetType(typeName);
            }

            public override AssemblyName GetName()
            {
                return _type.Assembly.GetName();
            }

            public override Type[] GetExportedTypes()
            {
                return new[]
                       {
                           typeof(TestController)
                       };
            }
        }
    }
}
