// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.TestFixture;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_adding_a_unifying_association_to_an_entity_before_the_parent_association : TestFixtureBase
    {
        private Entity _childEntity;
        private Association _parentOneToManyAssociation;
        private Association _unifyingNonParentAssociation;

        protected override void Act()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "AParent"),
                    new[]
                    {
                        new FullName("schema", "AChild")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "AParent2"),
                    new FullName[0]));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "AParent",
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1a", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_AParent",
                            new[]
                            {
                                "Primary1a", "Primary1b"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "AChild",
                    new[]
                    {
                        new EntityPropertyDefinition("ChildProperty1", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("ChildProperty2", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_AChild",
                            new[]
                            {
                                "Primary1a", "Primary1b", "Primary2"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "AParent2",
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_AParent2",
                            new[]
                            {
                                "Primary2", "Primary1b"
                            },
                            true)
                    }));

            // Add non-parent identifying association first so that the Primary1b property is used in the target entity.
            var unifyingNonParentAssociationFqn = new FullName("schema", "AParent2AChild");

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    unifyingNonParentAssociationFqn,
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "AParent2"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new FullName("schema", "AChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    true,
                    true));

            // Add parent identifying association second so that the Primary1b property is NOT used in the target entity.
            var oneToManyAssociationFqn = new FullName("schema", "AParent2AChild2");

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    oneToManyAssociationFqn,
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "AParent"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1a", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new FullName("schema", "AChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1a", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Primary1b", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            var model = domainModelBuilder.Build();

            _childEntity = model.EntityByFullName[new FullName("schema", "AChild")];

            _unifyingNonParentAssociation = model.AssociationByFullName[unifyingNonParentAssociationFqn];
            _parentOneToManyAssociation = model.AssociationByFullName[oneToManyAssociationFqn];
        }

        [Test]
        public virtual void Should_indicate_all_properties_found_on_the_child_entity_belong_to_that_entity()
        {
            Assert.That(_childEntity.Properties.All(p => p.Entity == _childEntity), Is.True);
        }

        [Test]
        public virtual void
            Should_indicate_all_properties_related_to_the_parent_association_and_its_property_mappings_indicate_they_are_from_the_parent()
        {
            // Parent association properties
            Assert.That(_childEntity.ParentAssociation.ThisProperties.All(x => x.IsFromParent));
            Assert.That(_childEntity.ParentAssociation.PropertyMappings.All(x => x.ThisProperty.IsFromParent));
            Assert.That(_childEntity.ParentAssociation.Inverse.OtherProperties.All(x => x.IsFromParent));
            Assert.That(_childEntity.ParentAssociation.Inverse.PropertyMappings.All(x => x.OtherProperty.IsFromParent));
            Assert.That(_childEntity.ParentAssociation.Inverse.Association.SecondaryEntityAssociationProperties.All(x => x.EntityProperty.IsFromParent));
        }

        [Test]
        public virtual void Should_indicate_that_all_child_properties_received_from_the_parent_are_from_the_parent()
        {
            // Direct child entity property lookup by name
            Assert.That(
                _childEntity.PropertyByName["Primary1a"]
                            .IsFromParent,
                Is.True);

            Assert.That(
                _childEntity.PropertyByName["Primary1b"]
                            .IsFromParent,
                Is.True);

            // Child identifier properties, matched by name
            var primary1aFromIdentifier = _childEntity.Identifier.Properties.Single(p => p.PropertyName == "Primary1a");
            var primary1bFromIdentifier = _childEntity.Identifier.Properties.Single(p => p.PropertyName == "Primary1b");

            Assert.That(primary1aFromIdentifier.IsFromParent, Is.True);
            Assert.That(primary1bFromIdentifier.IsFromParent, Is.True);
        }

        [Test]
        public virtual void Should_indicate_that_all_non_unified_child_properties_received_from_the_unifying_association_are_NOT_from_the_parent()
        {
            // Direct child entity property lookup by name
            Assert.That(
                _childEntity.PropertyByName["Primary2"]
                            .IsFromParent,
                Is.False);

            // Identifier property
            var primary2FromIdentifier = _childEntity.Identifier.Properties.Single(p => p.PropertyName == "Primary2");
            Assert.That(primary2FromIdentifier.IsFromParent, Is.False);
        }

        [Test]
        public virtual void Should_indicate_that_all_secondary_properties_on_the_parent_association_are_from_the_parent()
        {
            // Parent association properties
            Assert.That(_parentOneToManyAssociation.SecondaryEntityAssociationProperties, Has.Length.GreaterThan(0));

            _parentOneToManyAssociation.SecondaryEntityAssociationProperties
                                       .ForEach(p => Assert.That(p.EntityProperty.IsFromParent, p.PropertyName));
        }

        [Test]
        public virtual void Should_indicate_that_NON_UNIFIED_properties_of_incoming_non_parent_association_is_NOT_from_parent()
        {
            var nonUnifiedProperties = _unifyingNonParentAssociation.SecondaryEntityAssociationProperties
                                                                    .Except(
                                                                         _parentOneToManyAssociation.SecondaryEntityAssociationProperties,
                                                                         ModelComparers.AssociationPropertyNameOnly)
                                                                    .ToList();

            Assert.That(nonUnifiedProperties, Has.Count.GreaterThan(0));
            nonUnifiedProperties.ForEach(p => Assert.That(p.EntityProperty.IsFromParent, Is.False, p.PropertyName + " is from parent?"));
        }

        [Test]
        public virtual void Should_indicate_that_unified_properties_of_incoming_non_parent_association_is_from_parent()
        {
            var unifiedProperties = _unifyingNonParentAssociation.SecondaryEntityAssociationProperties
                                                                 .Intersect(
                                                                      _parentOneToManyAssociation.SecondaryEntityAssociationProperties,
                                                                      ModelComparers.AssociationPropertyNameOnly)
                                                                 .ToList();

            Assert.That(unifiedProperties, Has.Count.GreaterThan(0));
            unifiedProperties.ForEach(p => Assert.That(p.EntityProperty.IsFromParent, Is.True, p.PropertyName + " is from parent?"));
        }
    }
}
