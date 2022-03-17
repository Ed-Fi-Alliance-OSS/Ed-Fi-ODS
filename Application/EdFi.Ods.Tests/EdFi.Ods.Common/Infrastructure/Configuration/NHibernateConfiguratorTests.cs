// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.TestFixture;
using FakeItEasy;
using NHibernate.Mapping;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Configuration
{
    [TestFixture]
    public class NHibernateConfiguratorTests
    {
        public class When_configurating_nHibernate_extensions : TestFixtureBase
        {
            private NHibernate.Cfg.Configuration _configuration;
            private List<PersistentClass> _persistentClasses;
            private const string CoreTableName = "StaffLeave";
            private const string MappedExtensionProperty = "Extensions";
            private const string MappedAggregateExtensionProperty = "AggregateExtensions";

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var extensionConfigurationProviders = A.Fake<IEnumerable<ExtensionNHibernateConfigurationProvider>>();
                var beforeBindMappingActivities = A.Fake<IEnumerable<INHibernateBeforeBindMappingActivity>>();
                var authorizationStrategyConfigurators = A.Fake<IEnumerable<IAuthorizationFilterDefinitionsFactory>>();
                var configurationActivities = A.Fake<IEnumerable<INHibernateConfigurationActivity>>();

                var connectionStringProvider = A.Fake<IOdsDatabaseConnectionStringProvider>();
                var assembliesProvider = A.Fake<AssembliesProvider>();
                DatabaseEngine engine = DatabaseEngine.SqlServer;
                var ormMappingFileDataProvider = new OrmMappingFileDataProvider(assembliesProvider, engine, OrmMappingFileConventions.OrmMappingAssembly);

                var nHibernateConfigurator = new NHibernateConfigurator(extensionConfigurationProviders, beforeBindMappingActivities,
                    authorizationStrategyConfigurators, configurationActivities, ormMappingFileDataProvider, connectionStringProvider);
                _configuration = nHibernateConfigurator.Configure();

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
            public void Should_not_have_the_aggregate_extension_mapped_to_the_core_entity()
            {
                var extensionProperty = _persistentClasses
                    .FirstOrDefault(
                        x => x.UnjoinedPropertyIterator
                            .Any(
                                y =>
                                    y.Name.Equals(
                                        MappedAggregateExtensionProperty,
                                        StringComparison.InvariantCultureIgnoreCase)));

                Assert.That(extensionProperty, Is.Null, "Aggregate Extension property does not exist on the core entity");
            }

            [Test]
            public void Should_not_have_the_extension_property_mapped_to_the_core_entity()
            {
                var extensionProperty = _persistentClasses
                    .FirstOrDefault(
                        x => x.UnjoinedPropertyIterator
                            .Any(
                                y =>
                                    y.Name.Equals(
                                        MappedExtensionProperty,
                                        StringComparison.InvariantCultureIgnoreCase)));

                Assert.That(extensionProperty, Is.Null, "Extension property does not exist on the core entity");
            }
        }
    }
}