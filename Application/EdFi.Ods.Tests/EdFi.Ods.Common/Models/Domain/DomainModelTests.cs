// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Tests.TestExtension;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    public class DomainModelTests
    {
        public class When_constructing_a_DomainModel_with_definitions_arguments : LegacyTestFixtureBase
        {
            private AggregateDefinition _agDefinition;
            private EntityDefinition _entityDefinition1;
            private EntityDefinition _entityDefinition2;
            private EntityDefinition _entityDefinition3;
            private EntityDefinition _entityDefinition4;
            private SchemaDefinition _schemaDefinition;
            private AssociationDefinition _associateDefinition;

            private DomainModel _domainModel;
            private IDomainModelDefinitionsProvider _domainModelDefinitionsProvider;

            protected override void Arrange()
            {
                _agDefinition = new AggregateDefinition(
                    new FullName("schema", "Aggregate"),
                    new[]
                    {
                        new FullName("schema", "AChild"), new FullName("schema", "SourceEntity"), new FullName("schema", "TargetEntity")
                    });

                _entityDefinition1 = new EntityDefinition(
                    "schema",
                    "Aggregate",
                    new EntityPropertyDefinition[0],
                    new EntityIdentifierDefinition[0]);

                _entityDefinition2 = new EntityDefinition(
                    "schema",
                    "AChild",
                    new EntityPropertyDefinition[0],
                    new EntityIdentifierDefinition[0]);

                _entityDefinition3 = new EntityDefinition(
                    "schema",
                    "SourceEntity",
                    new [] { CreateInt32Property(isIdentifying: true)},
                    new [] { new EntityIdentifierDefinition("PK", new [] {"Property1"}, isPrimary: true) });

                _entityDefinition4 = new EntityDefinition(
                    "schema",
                    "TargetEntity",
                    new EntityPropertyDefinition[0],
                    new EntityIdentifierDefinition[0]);

                _schemaDefinition = new SchemaDefinition("Logical Schema", "schema");

                _associateDefinition = new AssociationDefinition(
                    new FullName("schema", "association1"),
                    Cardinality.OneToOneOrMore,
                    new FullName("schema", "SourceEntity"),
                    new[]
                    {
                        CreateInt32Property()
                    },
                    new FullName("schema", "TargetEntity"),
                    new[]
                    {
                        CreateInt32Property()
                    },
                    false,
                    false);

                _domainModelDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

                _domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                               .Return(
                                                    new DomainModelDefinitions(
                                                        _schemaDefinition,
                                                        new[]
                                                        {
                                                            _agDefinition
                                                        },
                                                        new[]
                                                        {
                                                            _entityDefinition1, _entityDefinition2, _entityDefinition3, _entityDefinition4
                                                        },
                                                        new[]
                                                        {
                                                            _associateDefinition
                                                        }));
            }

            protected override void Act()
            {
                IDomainModelProvider domainModelProvider =
                    new DomainModelProvider(
                        new[]
                        {
                            _domainModelDefinitionsProvider
                        });

                _domainModel = domainModelProvider.GetDomainModel();
            }

            private static EntityPropertyDefinition CreateInt32Property(bool isIdentifying = false)
            {
                return new EntityPropertyDefinition("Property1", new PropertyType(DbType.Int32), null, isIdentifying);
            }

            [Test]
            public void Should_be_one_association()
            {
                Assert.That(_domainModel.AssociationByFullName.Values.Count(), Is.EqualTo(1));
            }

            [Test]
            public void Should_contain_1_schema()
            {
                Assert.That(_domainModel.Schemas.Count, Is.EqualTo(1));
            }

            [Test]
            public void Should_contain_4_entities()
            {
                Assert.That(_domainModel.EntityByFullName.Keys.Count(), Is.EqualTo(4));
            }

            [Test]
            public void Should_contain_one_aggregate()
            {
                Assert.That(_domainModel.AggregateByName.Keys.Count(), Is.EqualTo(1));
            }

            [Test]
            public void Should_make_input_schema_value()
            {
                var schema = _domainModel.Schemas.Single();

                AssertHelper.All(
                    () =>
                        Assert.AreEqual(
                            _schemaDefinition.LogicalName,
                            schema.LogicalName,
                            "LogicalName=" + schema.LogicalName),
                    () =>
                        Assert.AreEqual(
                            _schemaDefinition.PhysicalName,
                            schema.PhysicalName,
                            "PhysicalName=" + schema.PhysicalName));
            }

            [Test]
            public void Should_match_elements_in_input_entity1()
            {
                var entity1 = _domainModel.EntityByFullName.Values.Single(x => x.Name == _entityDefinition1.Name);

                AssertHelper.All(
                    () =>
                        Assert.AreEqual(
                            _entityDefinition1.Name,
                            entity1.Name,
                            "Entity1.Name=" + entity1.Name),
                    () => Assert.That(entity1.Schema, Is.EqualTo(_entityDefinition1.Schema)));
            }

            [Test]
            public void Should_match_elements_in_input_entity2()
            {
                var entity2 = _domainModel.EntityByFullName.Values.Single(x => x.Name == _entityDefinition2.Name);

                AssertHelper.All(
                    () =>
                        Assert.AreEqual(
                            _entityDefinition2.Name,
                            entity2.Name,
                            "Entity2.Name=" + entity2.Name),
                    () =>
                        Assert.AreEqual(
                            _entityDefinition2.Schema,
                            entity2.Schema,
                            "Entity2.Schema=" + entity2.Schema));
            }

            [Test]
            public void Should_match_elements_of_the_input_aggregate()
            {
                var aggregate = _domainModel.AggregateByName.Values.First();

                AssertHelper.All(
                    () =>
                        Assert.That(
                            aggregate.AggregateRoot.Name,
                            Is.EqualTo(_agDefinition.AggregateRootEntityName.Name)),
                    () =>
                        Assert.That(
                            aggregate.AggregateRoot.Schema,
                            Is.EqualTo(_agDefinition.AggregateRootEntityName.Schema)));
            }

            [Test]
            public void Should_match_input_association_elements()
            {
                var association = _domainModel.AssociationByFullName.Values.Single();

                AssertHelper.All(
                    () =>
                        Assert.That(
                            association.FullName.Name,
                            Is.EqualTo(_associateDefinition.FullName.Name)),
                    () => Assert.That(
                        association.FullName.Schema,
                        Is.EqualTo(_associateDefinition.FullName.Schema)),
                    () =>
                        Assert.That(association.IsRequired, Is.EqualTo(_associateDefinition.IsRequired)),
                    () => Assert.That(
                        association.PrimaryEntityFullName.Name,
                        Is.EqualTo(_associateDefinition.PrimaryEntityFullName.Name)),
                    () => Assert.That(
                        association.SecondaryEntityFullName.Name,
                        Is.EqualTo(_associateDefinition.SecondaryEntityFullName.Name)));
            }
        }

        public class When_constructing_a_domain_model_with_aggregate_extensions_present : LegacyTestFixtureBase
        {
            private IDomainModelDefinitionsProvider _extensionDefinitionsProvider;
            private DomainModel _domainModel;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                _extensionDefinitionsProvider = new DomainModelDefinitionsProvider();

                _domainModelProvider =
                    new DomainModelProvider(
                        new[]
                        {
                            _extensionDefinitionsProvider, new EdFiDomainModelDefinitionsProvider()
                        });
            }

            protected override void Act()
            {
                _domainModel = _domainModelProvider.GetDomainModel();
            }

            [Test]
            public void Resulting_model_should_contain_aggregate_extension_entities_as_members_of_edfi_aggregates()
            {
                var aggregateExtensionContainingAggregates = _domainModel.Entities.Where(e => e.IsAggregateExtension)
                                                                         .Select(e => e.Aggregate);

                AssertHelper.All(
                    aggregateExtensionContainingAggregates
                       .Select(
                            a =>
                                (Action)
                                (() =>
                                     Assert.That(
                                         a.AggregateRoot.IsEdFiStandardEntity,
                                         Is.True,
                                         $@"Aggregate extension {a.FullName} is not part of an Ed-Fi standard Aggregate")))
                       .ToArray());
            }

            [Test]
            public void Resulting_model_should_contain_aggregate_extension_entities_with_an_association_back_to_edfi_entity()
            {
                var actualAggregateExtensionEntities = _domainModel.Entities.Where(e => e.IsAggregateExtension);

                AssertHelper.All(
                    actualAggregateExtensionEntities
                       .Select(
                            e =>
                                (Action)
                                (() =>
                                     Assert.That(
                                         e.IncomingAssociations.Any(a => a.OtherEntity.IsEdFiStandardEntity),
                                         Is.True,
                                         $@"Association from aggregate extension entity to Ed-Fi standard entity not found for {e.FullName}")))
                       .ToArray());
            }

            [Test]
            public void Resulting_model_should_contain_expected_aggregate_extension_entities()
            {
                var actualAggregateExtensionEntities = _domainModel.Entities.Where(e => e.IsAggregateExtension)
                                                                   .Select(e => e.FullName);

                var expectedAggregateExtensionEntities = _extensionDefinitionsProvider.GetDomainModelDefinitions()
                                                                                      .AggregateExtensionDefinitions
                                                                                      .FirstOrDefault()
                                                                                     ?.ExtensionEntityNames;

                Assert.That(actualAggregateExtensionEntities, Is.EquivalentTo(expectedAggregateExtensionEntities));
            }
        }
    }
}
