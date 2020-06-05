// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Standard;
using EdFi.Ods.Tests.TestExtension;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NUnit.Framework;
using Test.Common;
using Component = Castle.MicroKernel.Registration.Component;
using ExtensionNHibernateConfigurationProvider = EdFi.Ods.Tests.TestExtension.NHibernate.ExtensionNHibernateConfigurationProvider;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.NHibernate.Architecture
{

    internal class NHibernateConfiguratorTests
    {
        [Ignore("Broken Tests")]
        public class When_configurating_nHibernate_extensions : LegacyTestFixtureBase
        {
            private WindsorContainerEx _container;
            private Configuration _configuration;
            private List<PersistentClass> _persistentClasses;
            private const string CoreTableName = "StaffLeave";
            private const string MappedExtensionProperty = "Extensions";
            private const string MappedAggregateExtensionProperty = "AggregateExtensions";

            protected override void Arrange()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Test_TestExtension>();
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard>();

                _container = new WindsorContainerEx();

                _container.Register(
                    Component
                       .For<IResourceModelProvider>()
                       .ImplementedBy<ResourceModelProvider>());

                _container.Register(
                    Component.For<IExtensionNHibernateConfigurationProvider>()
                             .ImplementedBy<ExtensionNHibernateConfigurationProvider>());

                _container.Register(
                    Component.For<IFilterCriteriaApplicatorProvider>()
                        .ImplementedBy<FilterCriteriaApplicatorProvider>());

                _container.Register(Component.For<IOrmMappingFileDataProvider>()
                    .UsingFactoryMethod(kernel => new OrmMappingFileDataProvider(kernel.Resolve<IAssembliesProvider>(), DatabaseEngine.SqlServer, "EdFi.Ods.Standard"))
                );

                _container.Register(Component.For<IAssembliesProvider>().ImplementedBy<AssembliesProvider>());
            }

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                // NHibernate initialization
                // NOTE when the container is configured, extensions are registered within the container.
#pragma warning disable 618
                // TODO: Remove with ODS-2973, deprecated by ODS-2974
                new LegacyNHibernateConfigurator().Configure(_container);
#pragma warning restore 618

                _configuration = _container.Resolve<Configuration>();

                _persistentClasses = _configuration.ClassMappings
                                                   .Where(
                                                        m => m.Table.Name.Equals(
                                                            CoreTableName,
                                                            StringComparison.InvariantCultureIgnoreCase))
                                                   .ToList();
            }

            [Test]
            public void Should_contain_the_core_entity()
            {
                Assert.That(
                    _persistentClasses.Any(),
                    "The configuration class mappings does not contain the core entity.This can be happen when the property specified by the dynamic entity does not exist on the core entity.");
            }

            [Test]
            public void Should_have_class_mappings_in_the_nHibernate_configuration()
            {
                Assert.That(_configuration.ClassMappings.Any(), "The configuration does not have any mappings");
            }

            [Test]
            public void Should_have_the_aggregate_extension_mapped_to_the_core_entity()
            {
                var extensionProperty = _persistentClasses
                   .FirstOrDefault(
                        x => x.UnjoinedPropertyIterator
                              .Any(
                                   y =>
                                       y.Name.Equals(
                                           MappedAggregateExtensionProperty,
                                           StringComparison.InvariantCultureIgnoreCase)));

                Assert.That(extensionProperty, Is.Not.Null, "Aggregate Extension property does not exist on the core entity");
            }

            [Test]
            public void Should_have_the_extension_property_mapped_to_the_core_entity()
            {
                var extensionProperty = _persistentClasses
                   .FirstOrDefault(
                        x => x.UnjoinedPropertyIterator
                              .Any(
                                   y =>
                                       y.Name.Equals(
                                           MappedExtensionProperty,
                                           StringComparison.InvariantCultureIgnoreCase)));

                Assert.That(extensionProperty, Is.Not.Null, "Extension property does not exist on the core entity");
            }
        }
    }
}
