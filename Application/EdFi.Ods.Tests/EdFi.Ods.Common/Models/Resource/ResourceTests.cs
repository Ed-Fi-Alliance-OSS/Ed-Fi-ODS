// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    public class When_building_a_resource_based_on_a_derived_entity_with_conflicting_names
        : LegacyTestFixtureBase
    {
        private ResourceModel _actualResourceModel;

        // Supplied values

        // Actual values

        // Dependencies

        protected override void Arrange()
        {
            // Initialize dependencies
        }

        protected override void Act()
        {
            // Execute code under test
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "BaseEntity",
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BaseEntityName", new PropertyType(DbType.String, 50, isNullable: false), null, false),
                        new EntityPropertyDefinition("BaseEntityOther1", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_BaseEntity",
                            new[]
                            {
                                "BaseEntityId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "BaseEntityChild",
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityChildId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BaseEntityChildName", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_BaseEntityChild",
                            new[]
                            {
                                "BaseEntityId", "BaseEntityChildId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "BaseEntityOtherChildOne",
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityOtherChildId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BaseEntityChildName", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_BaseEntityOtherChildOne",
                            new[]
                            {
                                "BaseEntityId", "BaseEntityOtherChildId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "DerivedEntity",
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityName", new PropertyType(DbType.String, 50, isNullable: false), null, false),
                        new EntityPropertyDefinition("DerivedEntityOther2", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_DerivedEntityOtherTwo",
                            new[]
                            {
                                "DerivedEntityId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "DerivedEntityChild",
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityChildId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("DerivedEntityChildName", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_DerivedEntityChild",
                            new[]
                            {
                                "DerivedEntityId", "DerivedEntityChildId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "DerivedEntityOtherChildTwo",
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityOtherChildId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("DerivedEntityChildName", new PropertyType(DbType.String, 50, isNullable: false), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_DerivedEntityOtherChild1",
                            new[]
                            {
                                "DerivedEntityId", "DerivedEntityOtherChildId"
                            },
                            true)
                    }));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "BaseEntity2DerivedEntity"),
                    Cardinality.OneToOneInheritance,
                    new FullName("schema", "BaseEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "DerivedEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "BaseEntity2BaseEntityChild"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "BaseEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "BaseEntityChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "BaseEntity2BaseEntityOtherChildOne"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "BaseEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "BaseEntityOtherChildOne"),
                    new[]
                    {
                        new EntityPropertyDefinition("BaseEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "BaseEntity2DerivedEntityChild"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "DerivedEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "DerivedEntityChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "BaseEntity2DerivedEntityOtherChildTwo"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "DerivedEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "DerivedEntityOtherChildTwo"),
                    new[]
                    {
                        new EntityPropertyDefinition("DerivedEntityId", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "BaseEntity"),
                    new[]
                    {
                        new FullName("schema", "BaseEntityChild"), new FullName("schema", "BaseEntityOtherChildOne")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "DerivedEntity"),
                    new[]
                    {
                        new FullName("schema", "DerivedEntityChild"), new FullName("schema", "DerivedEntityOtherChildTwo")
                    }));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            _actualResourceModel = domainModelBuilder.Build()
                                                     .ResourceModel;
        }

        [Assert]
        public void Should_not_apply_the_entity_prefix_removal_convention_to_properties_where_conflicts_would_result()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);

            Assert.That(memberNames, Contains.Item("baseEntityName"));
            Assert.That(memberNames, Contains.Item("derivedEntityName"));
        }

        [Assert]
        public void Should_not_apply_the_entity_prefix_removal_convention_to_properties_where_conflict_would_not_result()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);
            Assert.That(memberNames, Contains.Item("baseEntityOther1"));
            Assert.That(memberNames, Contains.Item("derivedEntityOther2"));
        }

        [Assert]
        public void Should_not_apply_the_entity_prefix_removal_convention_to_collections_where_conflicts_would_result()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);

            Assert.That(memberNames, Contains.Item("baseEntityChildren"));
            Assert.That(memberNames, Contains.Item("derivedEntityChildren"));
        }

        [Assert]
        public void Should_apply_the_entity_prefix_removal_convention_to_collections_where_conflict_would_not_result()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);

            Assert.That(memberNames, Contains.Item("otherChildOnes"));
            Assert.That(memberNames, Contains.Item("otherChildTwos"));
        }

        [Assert]
        public void Should_not_include_the_base_entity_inheritance_association_property_in_the_resource()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);

            Assert.That(memberNames, Has.No.Member("baseEntityId"));
        }

        [Assert]
        public void Should_include_the_derived_entity_inheritance_association_property_in_the_resource()
        {
            var actualResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "DerivedEntity"));
            var memberNames = actualResource.AllMembers.Select(m => m.JsonPropertyName);

            Assert.That(memberNames, Has.Member("derivedEntityId"));
        }
    }

    public class When_build_a_resource_model_with_references
        : LegacyTestFixtureBase
    {
        private ResourceModel _actualResourceModel;

        // Supplied values

        // Actual values

        // Dependencies

        protected override void Arrange()
        {
            // Initialize dependencies
        }

        protected override void Act()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootOne",
                    new[]
                    {
                        new EntityPropertyDefinition("RootOneId", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootOne",
                            new[]
                            {
                                "RootOneId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootTwo",
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootTwo",
                            new[]
                            {
                                "RootTwoId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootTwoEmbeddedObject",
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoEmbeddedObjectName", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootTwoEmbeddedObject",
                            new[]
                            {
                                "RootTwoId", "RootTwoEmbeddedObjectName"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootTwoChild",
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoChildName", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootTwoChild",
                            new[]
                            {
                                "RootTwoId", "RootTwoChildName"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootTwoGrandChild",
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoGrandChildName", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        // TODO: GKM - Need to add validation of entity identifier properties
                        new EntityIdentifierDefinition(
                            "PK_RootTwoChild",
                            new[]
                            {
                                "RootTwoId", "RootTwoChildName", "RootTwoGrandChildName"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootThree",
                    new[]
                    {
                        new EntityPropertyDefinition("RootThreeId", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootThree",
                            new[]
                            {
                                "RootThreeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootFour",
                    new[]
                    {
                        new EntityPropertyDefinition("RootFourId", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootFour",
                            new[]
                            {
                                "RootFourId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "RootFive",
                    new[]
                    {
                        new EntityPropertyDefinition("RootFiveId", new PropertyType(DbType.Int32), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_RootFive",
                            new[]
                            {
                                "RootFiveId"
                            },
                            true)
                    }));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "OneToZeroOrMore"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootOne"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootOneId", new PropertyType(DbType.Int32), null)
                    },
                    new FullName("schema", "RootTwo"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootOneId", new PropertyType(DbType.Int32), null)
                    },
                    false,
                    false));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "OneToOne"),
                    Cardinality.OneToOne,
                    new FullName("schema", "RootTwo"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "RootTwoEmbeddedObject"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "OneToZeroOrMore4"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootTwo"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "RootTwoChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "OneToZeroOrMore2"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootTwoChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("RootTwoChildName", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema", "RootTwoGrandChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootTwoId", new PropertyType(DbType.Int32), null),
                        new EntityPropertyDefinition("RootTwoChildName", new PropertyType(DbType.Int32), null)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "associationOneToZeroOrMore"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootThree"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootThreeId", new PropertyType(DbType.Int32), null)
                    },
                    new FullName("schema", "RootTwoChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootThreeId", new PropertyType(DbType.Int32), null)
                    },
                    false,
                    false));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "associationOneToZeroOrMore2"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootFour"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootFourId", new PropertyType(DbType.Int32), null)
                    },
                    new FullName("schema", "RootTwoGrandChild"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootFourId", new PropertyType(DbType.Int32), null)
                    },
                    false,
                    false));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "associationOneToZeroOrMore3"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "RootFive"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootFiveId", new PropertyType(DbType.Int32), null)
                    },
                    new FullName("schema", "RootTwoEmbeddedObject"),
                    new[]
                    {
                        new EntityPropertyDefinition("RootFiveId", new PropertyType(DbType.Int32), null)
                    },
                    false,
                    false));

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema", "RootOne"), new FullName[0]));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "RootTwo"),
                    new[]
                    {
                        new FullName("schema", "RootTwoChild"),
                        new FullName("schema", "RootTwoGrandChild"),
                        new FullName("schema", "RootTwoEmbeddedObject")
                    }));

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema", "RootThree"), new FullName[0]));
            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema", "RootFour"), new FullName[0]));
            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema", "RootFive"), new FullName[0]));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            _actualResourceModel = domainModelBuilder.Build()
                                                     .ResourceModel;
        }

        [Assert]
        public void Should_have_a_count_of_references_reflecting_all_descendants_and_embedded_objects()
        {
            var rootTwoResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "RootTwo"));
            var allReferences = rootTwoResource.AllContainedReferences;

            Assert.That(allReferences, Has.Count.EqualTo(4));
        }

        [Assert]
        public void Should_include_references_from_main_resource()
        {
            var rootTwoResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "RootTwo"));
            var allReferences = rootTwoResource.AllContainedReferences;

            Assert.That(allReferences.Select(r => r.ReferencedResourceName), Has.Member("RootOne"));
        }

        [Assert]
        public void Should_include_references_from_immediate_children()
        {
            var rootTwoResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "RootTwo"));
            var allReferences = rootTwoResource.AllContainedReferences;

            Assert.That(allReferences.Select(r => r.ReferencedResourceName), Has.Member("RootThree"));
        }

        [Assert]
        public void Should_include_references_from_descendants()
        {
            var rootTwoResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "RootTwo"));
            var allReferences = rootTwoResource.AllContainedReferences;

            Assert.That(allReferences.Select(r => r.ReferencedResourceName), Has.Member("RootFour"));
        }

        [Assert]
        public void Should_include_references_from_embedded_objects()
        {
            var rootTwoResource = _actualResourceModel.GetResourceByFullName(new FullName("schema", "RootTwo"));
            var allReferences = rootTwoResource.AllContainedReferences;

            Assert.That(allReferences.Select(r => r.ReferencedResourceName), Has.Member("RootFive"));
        }
    }

    public class When_building_a_resource_model : LegacyTestFixtureBase
    {
        private IDomainModelProvider _domainModelProvider;
        private ResourceModelProvider _resourceModelProvider;
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;

        // For diagramming "crow's feet" notation in ASCII diagrams -- ⪫⪪⩚⩛ Δ  ɅV
        protected override void Arrange()
        {
            var definitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            definitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                               .Return(
                                    new DomainModelDefinitions(
                                        new SchemaDefinition("schema1", "schema1"),
                                        new[]
                                        {
                                            new AggregateDefinition(new FullName("schema1", "Entity1"), new FullName[0])
                                        },
                                        new[]
                                        {
                                            new EntityDefinition(
                                                "schema1",
                                                "Entity1",
                                                new EntityPropertyDefinition[0],
                                                new EntityIdentifierDefinition[0])
                                        },
                                        new AssociationDefinition[]
                                        { },
                                        new AggregateExtensionDefinition[]
                                        { }));

            _domainModelProvider = new DomainModelProvider(
                new[]
                {
                    definitionsProvider
                });

            _resourceModelProvider = new ResourceModelProvider(_domainModelProvider);
        }

        protected override void Act()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            _actualResource = resourceModel.GetResourceByFullName(new FullName("Schema1", "Entity1"));
        }

        [Assert]
        public void Should_have_same_fullname_as_entity()
        {
            Assert.That(_actualResource.FullName, Is.EqualTo(new FullName("schema1", "Entity1")));
        }
    }

    public class When_building_a_resource_model_with_no_entity : LegacyTestFixtureBase
    {
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;

        protected override void Act()
        {
            _actualResource = new global::EdFi.Ods.Common.Models.Resource.Resource("Entity1");
        }

        [Assert]
        public void Should_have_same_fullname_as_entity()
        {
            Assert.That(_actualResource.FullName.Schema, Is.Null);
        }
    }

    public class When_building_a_domain_model_with_an_entity_with_an_implicit_entity_embedded_object_extension : LegacyTestFixtureBase
    {
        private IDomainModelProvider _domainModelProvider;
        private ResourceModelProvider _resourceModelProvider;
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;
        private Extension _actualExtension;
        private readonly string _edfiSchema = EdFiConventions.PhysicalSchemaName;
        private readonly string _edfiLogicalName = EdFiConventions.LogicalName;

        // For diagramming "crow's feet" notation in ASCII diagrams -- ⪫⪪⩚⩛ Δ  ɅV
        protected override void Arrange()
        {
            // Create an aggregate with a single entity containing an extension embedded object
            //
            //             (Entity1)
            //                 |
            //                 +---- (ExtensionEmbeddedObject1)
            //
            var definitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            definitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                               .Return(
                                    new DomainModelDefinitions(
                                        new SchemaDefinition(_edfiLogicalName, _edfiSchema),
                                        new[]
                                        {
                                            new AggregateDefinition(new FullName(_edfiSchema, "Entity1"), new FullName[0])
                                        },
                                        new[]
                                        {
                                            new EntityDefinition(
                                                _edfiSchema,
                                                "Entity1",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition(
                                                        "StudentUSI",
                                                        new PropertyType(DbType.Int32, 0, 10, 0, false),
                                                        null,
                                                        true,
                                                        true)
                                                },
                                                new EntityIdentifierDefinition[0])
                                        },
                                        new AssociationDefinition[]
                                        { },
                                        new AggregateExtensionDefinition[]
                                        { }));

            var extensionDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            extensionDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                        .Return(
                                             new DomainModelDefinitions(
                                                 new SchemaDefinition("schemaX", "schemaX"),
                                                 new AggregateDefinition[]
                                                 { },
                                                 new[]
                                                 {
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "Extension1Entity1",
                                                         new[]
                                                         {
                                                             new EntityPropertyDefinition("Name", new PropertyType(DbType.Int32), null, true)
                                                         },
                                                         new EntityIdentifierDefinition[0])
                                                 },
                                                 new[]
                                                 {
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToOne,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "Extension1Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true)
                                                 },
                                                 new[]
                                                 {
                                                     new AggregateExtensionDefinition(
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new[]
                                                         {
                                                             new FullName("schemaX", "Extension1Entity1")
                                                         })
                                                 }));

            _domainModelProvider = new DomainModelProvider(
                new[]
                {
                    definitionsProvider, extensionDefinitionsProvider
                });

            _resourceModelProvider = new ResourceModelProvider(_domainModelProvider);
        }

        protected override void Act()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            _actualResource = resourceModel.GetResourceByFullName(new FullName(_edfiSchema, "Entity1"));

            _actualExtension = _actualResource.Extensions.FirstOrDefault();
        }

        [Assert]
        public void Should_create_a_single_extension_class_implicitly()
        {
            Assert.That(_actualResource.Extensions, Has.Count.EqualTo(1));
        }

        [Assert]
        public void Should_assign_the_object_type_schema_proper_case_name_for_the_implicit_extension()
        {
            Assert.That(_actualExtension.ObjectType.SchemaProperCaseName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void
            Should_assign_the_property_name_for_the_implicit_extension_class_using_ProperCaseName_conventions_based_on_the_physical_schema_name()
        {
            Assert.That(_actualExtension.PropertyName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void
            Should_assign_the_object_type_name_for_the_implicit_extension_class_using_a_suffix_of_Extension_applied_to_the_containing_entitys_name()
        {
            Assert.That(_actualExtension.ObjectType.Name, Is.EqualTo("Entity1Extension"));
        }

        [Assert]
        public void Should_assign_the_resource_schema_name_for_the_implicit_extension_class_to_the_physical_schema_of_the_aggregate_extension()
        {
            Assert.That(_actualExtension.ObjectType.FullName.Schema, Is.EqualTo("schemaX"));
        }

        [Assert]
        public void Should_not_have_an_entity_reference_for_the_implicitly_created_extension_class()
        {
            Assert.That(_actualExtension.ObjectType.Entity, Is.Null);
        }

        [Assert]
        public void Should_expose_the_extension_collection_on_the_implicitly_created_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.EmbeddedObjectByName.ContainsKey("Extension1Entity1"),
                "Unable to find the extension collection on the implicit extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_embedded_object_on_the_main_resource()
        {
            Assert.That(
                _actualResource.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                Is.False,
                "The extension embedded object was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_collection_on_the_main_resource()
        {
            Assert.That(
                _actualResource.CollectionByName.ContainsKey("Extension1Entity1s"),
                Is.False,
                "The extension collection was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_preserve_properties_on_embedded_object()
        {
            Assert.That(
                _actualExtension.ObjectType.EmbeddedObjectByName["Extension1Entity1"]
                                .ObjectType.Properties,
                Has.Count.EqualTo(1));
        }
    }

    public class When_building_a_domain_model_with_an_entity_with_an_implicit_entity_collection_extension : LegacyTestFixtureBase
    {
        private IDomainModelProvider _domainModelProvider;
        private ResourceModelProvider _resourceModelProvider;
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;
        private Extension _actualExtension;
        private readonly string _edfiSchema = EdFiConventions.PhysicalSchemaName;
        private readonly string _edfiLogicalName = EdFiConventions.LogicalName;

        // For diagramming "crow's feet" notation in ASCII diagrams -- ⪫⪪⩚⩛ Δ  ɅV
        protected override void Arrange()
        {
            // Create an aggregate with a single entity containing an extension collection
            //
            //             (Entity1) --⪪ (ExtensionEntity1)
            //
            var definitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            definitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                               .Return(
                                    new DomainModelDefinitions(
                                        new SchemaDefinition(_edfiLogicalName, _edfiSchema),
                                        new[]
                                        {
                                            new AggregateDefinition(new FullName(_edfiSchema, "Entity1"), new FullName[0])
                                        },
                                        new[]
                                        {
                                            new EntityDefinition(
                                                _edfiSchema,
                                                "Entity1",
                                                new EntityPropertyDefinition[0],
                                                new EntityIdentifierDefinition[0])
                                        },
                                        new AssociationDefinition[]
                                        { },
                                        new AggregateExtensionDefinition[]
                                        { }));

            var extensionDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            extensionDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                        .Return(
                                             new DomainModelDefinitions(
                                                 new SchemaDefinition("schemaX", "schemaX"),
                                                 new AggregateDefinition[0]
                                                 { },
                                                 new[]
                                                 {
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "Extension1Entity1",
                                                         new[]
                                                         {
                                                             new EntityPropertyDefinition("Name", new PropertyType(DbType.Int32), null, true)
                                                         },
                                                         new EntityIdentifierDefinition[0])
                                                 },
                                                 new[]
                                                 {
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToZeroOrMore,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "Extension1Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true)
                                                 },
                                                 new[]
                                                 {
                                                     new AggregateExtensionDefinition(
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new[]
                                                         {
                                                             new FullName("schemaX", "Extension1Entity1")
                                                         })
                                                 }));

            _domainModelProvider = new DomainModelProvider(
                new[]
                {
                    definitionsProvider, extensionDefinitionsProvider
                });

            _resourceModelProvider = new ResourceModelProvider(_domainModelProvider);
        }

        protected override void Act()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            _actualResource = resourceModel.GetResourceByFullName(new FullName(_edfiSchema, "Entity1"));

            _actualExtension = _actualResource.Extensions.FirstOrDefault();
        }

        [Assert]
        public void Should_create_a_single_extension_class_implicitly()
        {
            Assert.That(_actualResource.Extensions, Has.Count.EqualTo(1));
        }

        [Assert]
        public void Should_assign_the_object_type_schema_proper_case_name_for_the_implicit_extension()
        {
            Assert.That(_actualExtension.ObjectType.SchemaProperCaseName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void
            Should_assign_the_property_name_for_the_implicit_extension_class_using_ProperCaseName_conventions_based_on_the_physical_schema_name()
        {
            Assert.That(_actualExtension.PropertyName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void
            Should_assign_the_object_type_name_for_the_implicit_extension_class_using_a_suffix_of_Extension_applied_to_the_containing_entitys_name()
        {
            Assert.That(_actualExtension.ObjectType.Name, Is.EqualTo("Entity1Extension"));
        }

        [Assert]
        public void Should_assign_the_resource_schema_name_for_the_implicit_extension_class_to_the_physical_schema_of_the_aggregate_extension()
        {
            Assert.That(_actualExtension.ObjectType.FullName.Schema, Is.EqualTo("schemaX"));
        }

        [Assert]
        public void Should_not_have_an_entity_reference_for_the_implicitly_created_extension_class()
        {
            Assert.That(_actualExtension.ObjectType.Entity, Is.Null);
        }

        [Assert]
        public void Should_expose_the_extension_collection_on_the_implicitly_created_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.CollectionByName.ContainsKey("Extension1Entity1s"),
                "Unable to find the extension collection on the implicit extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_embedded_object_on_the_main_resource()
        {
            Assert.That(
                _actualResource.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                Is.False,
                "The extension embedded object was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_collection_on_the_main_resource()
        {
            Assert.That(
                _actualResource.CollectionByName.ContainsKey("Extension1Entity1s"),
                Is.False,
                "The extension collection was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void
            Should_reassign_the_extension_collections_parent_to_be_the_implicitly_added_extension_class_rather_than_the_main_resource_being_extended()
        {
            var resourceClassExtension = _actualResource.ExtensionByName["SchemaX"]
                                                        .ObjectType;

            var collection = resourceClassExtension.CollectionByName["Extension1Entity1s"];

            AssertHelper.All(
                () => Assert.That(collection.Parent, Is.SameAs(resourceClassExtension)),
                () => Assert.That(collection.ParentFullName.Name, Is.EqualTo("Entity1Extension")),
                () => Assert.That(collection.ParentFullName.Schema, Is.EqualTo("schemaX"))
            );
        }

        [Assert]
        public void Should_preserve_properties_on_extension_collection()
        {
            var collection = _actualExtension.ObjectType.CollectionByName["Extension1Entity1s"];
            Assert.That(collection.ItemType.Properties, Has.Count.EqualTo(1));
        }
    }

    public class
        When_building_a_domain_model_with_an_entity_WITHOUT_an_explicit_entity_extension_and_aggregate_extensions_consisting_of_an_extension_collection_and_embedded_object
        : LegacyTestFixtureBase
    {
        private IDomainModelProvider _domainModelProvider;
        private ResourceModelProvider _resourceModelProvider;
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;
        private Extension _actualExtension;
        private readonly string _edfiSchema = EdFiConventions.PhysicalSchemaName;
        private readonly string _edfiLogicalName = EdFiConventions.LogicalName;

        // For diagramming "crow's feet" notation in ASCII diagrams -- ⪫⪪⩚⩛ Δ  ɅV
        protected override void Arrange()
        {
            // Create an aggregate with a single entity containing an extension collection
            //
            //             (Entity1) --⪪ (ExtensionEntity1)
            //                 |
            //                 +---- (ExtensionEmbeddedObject1)
            //
            var definitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            definitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                               .Return(
                                    new DomainModelDefinitions(
                                        new SchemaDefinition(_edfiLogicalName, _edfiSchema),
                                        new[]
                                        {
                                            new AggregateDefinition(new FullName(_edfiSchema, "Entity1"), new FullName[0])
                                        },
                                        new[]
                                        {
                                            new EntityDefinition(
                                                _edfiSchema,
                                                "Entity1",
                                                new EntityPropertyDefinition[0],
                                                new EntityIdentifierDefinition[0])
                                        },
                                        new AssociationDefinition[]
                                        { },
                                        new AggregateExtensionDefinition[]
                                        { }));

            var extensionDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            extensionDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                        .Return(
                                             new DomainModelDefinitions(
                                                 new SchemaDefinition("schemaX", "schemaX"),
                                                 new AggregateDefinition[0]
                                                 { },
                                                 new[]
                                                 {
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "ExtensionEntity1",
                                                         new EntityPropertyDefinition[0],
                                                         new EntityIdentifierDefinition[0]),
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "ExtensionEmbeddedObject1",
                                                         new EntityPropertyDefinition[0],
                                                         new EntityIdentifierDefinition[0])
                                                 },
                                                 new[]
                                                 {
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToZeroOrMore,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "ExtensionEntity1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true),
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToOne,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "ExtensionEmbeddedObject1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true)
                                                 },
                                                 new[]
                                                 {
                                                     new AggregateExtensionDefinition(
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new[]
                                                         {
                                                             new FullName("schemaX", "ExtensionEntity1"),
                                                             new FullName("schemaX", "ExtensionEmbeddedObject1")
                                                         })
                                                 }));

            _domainModelProvider = new DomainModelProvider(
                new[]
                {
                    definitionsProvider, extensionDefinitionsProvider
                });

            _resourceModelProvider = new ResourceModelProvider(_domainModelProvider);
        }

        protected override void Act()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            _actualResource = resourceModel.GetResourceByFullName(new FullName(_edfiSchema, "Entity1"));

            _actualExtension = _actualResource.Extensions.FirstOrDefault();
        }

        [Assert]
        public void Should_create_a_single_extension_class_implicitly()
        {
            Assert.That(_actualResource.Extensions, Has.Count.EqualTo(1));
        }

        [Assert]
        public void
            Should_assign_the_property_name_for_the_implicit_extension_class_using_ProperCaseName_conventions_based_on_the_physical_schema_name()
        {
            Assert.That(_actualExtension.PropertyName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void
            Should_assign_the_object_type_name_for_the_implicit_extension_class_using_a_suffix_of_Extension_applied_to_the_containing_entitys_name()
        {
            Assert.That(_actualExtension.ObjectType.Name, Is.EqualTo("Entity1Extension"));
        }

        [Assert]
        public void Should_assign_the_resource_schema_name_for_the_implicit_extension_class_to_the_physical_schema_of_the_aggregate_extension()
        {
            Assert.That(_actualExtension.ObjectType.FullName.Schema, Is.EqualTo("schemaX"));
        }

        [Assert]
        public void Should_not_have_an_entity_reference_for_the_implicitly_created_extension_class()
        {
            Assert.That(_actualExtension.ObjectType.Entity, Is.Null);
        }

        [Assert]
        public void Should_expose_the_extension_collection_on_the_implicitly_created_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.CollectionByName.ContainsKey("ExtensionEntity1s"),
                "Unable to find the extension collection on the implicit extension object.");
        }

        [Assert]
        public void Should_expose_the_extension_embedded_object_on_the_implicitly_created_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                "Unable to find the extension embedded on the implicit extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_embedded_object_on_the_main_resource()
        {
            Assert.That(
                _actualResource.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                Is.False,
                "The extension embedded object was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_collection_on_the_main_resource()
        {
            Assert.That(
                _actualResource.CollectionByName.ContainsKey("ExtensionEntity1s"),
                Is.False,
                "The extension collection was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void
            Should_reassign_the_extension_collections_parent_to_be_the_implicitly_added_extension_class_rather_than_the_main_resource_being_extended()
        {
            var resourceClassExtension = _actualResource.ExtensionByName["SchemaX"]
                                                        .ObjectType;

            var collection = resourceClassExtension.CollectionByName["ExtensionEntity1s"];

            Assert.That(collection.Parent, Is.SameAs(resourceClassExtension));
            Assert.That(collection.ParentFullName.Name, Is.EqualTo("Entity1Extension"));
            Assert.That(collection.ParentFullName.Schema, Is.EqualTo("schemaX"));
        }
    }

    public class
        When_building_a_domain_model_with_an_entity_WITH_an_explicit_entity_extension_and_aggregate_extensions_consisting_of_an_extension_collection_and_embedded_object
        : LegacyTestFixtureBase
    {
        // Supplied values

        // Actual values
        private global::EdFi.Ods.Common.Models.Resource.Resource _actualResource;
        private IReadOnlyList<ResourceChildItem> _actualContainedItemTypes;
        private Extension _actualExtension;

        // External dependencies
        private IDomainModelProvider _domainModelProvider;
        private ResourceModelProvider _resourceModelProvider;
        private readonly string _edfiSchema = EdFiConventions.PhysicalSchemaName;
        private readonly string _edfiLogicalName = EdFiConventions.LogicalName;

        // For diagramming "crow's feet" notation in ASCII diagrams -- ⪫⪪⩚⩛ Δ  ɅV
        protected override void Arrange()
        {
            // Create an aggregate with a single entity containing an extension, and an extension collection and embedded object
            //
            //             (Entity1) --⪪ (ExtensionEntity1)
            //                |  |
            //                |  +---- (ExtensionEmbeddedObject1)
            //                |
            //       (Entity1Extension)
            //
            var definitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            definitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                               .Return(
                                    new DomainModelDefinitions(
                                        new SchemaDefinition(_edfiLogicalName, _edfiSchema),
                                        new[]
                                        {
                                            new AggregateDefinition(new FullName(_edfiSchema, "Entity1"), new FullName[0])
                                        },
                                        new[]
                                        {
                                            new EntityDefinition(
                                                _edfiSchema,
                                                "Entity1",
                                                new EntityPropertyDefinition[0],
                                                new EntityIdentifierDefinition[0])
                                        },
                                        new AssociationDefinition[]
                                        { },
                                        new AggregateExtensionDefinition[]
                                        { }));

            var extensionDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

            extensionDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                        .Return(
                                             new DomainModelDefinitions(
                                                 new SchemaDefinition("schemaX", "schemaX"),
                                                 new AggregateDefinition[0]
                                                 { },
                                                 new[]
                                                 {
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "Entity1Extension",
                                                         new[]
                                                         {
                                                             new EntityPropertyDefinition
                                                             {
                                                                 PropertyName = "Property1", PropertyType = new PropertyType(DbType.Int32)
                                                             },
                                                             new EntityPropertyDefinition
                                                             {
                                                                 PropertyName = "Property2", PropertyType = new PropertyType(DbType.String)
                                                             }
                                                         },
                                                         new EntityIdentifierDefinition[0]),
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "ExtensionEntity1",
                                                         new EntityPropertyDefinition[0],
                                                         new EntityIdentifierDefinition[0]),
                                                     new EntityDefinition(
                                                         "schemaX",
                                                         "ExtensionEmbeddedObject1",
                                                         new EntityPropertyDefinition[0],
                                                         new EntityIdentifierDefinition[0])
                                                 },
                                                 new[]
                                                 {
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToOneExtension,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "Entity1Extension"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true),
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToZeroOrMore,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "ExtensionEntity1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true),
                                                     new AssociationDefinition(
                                                         new FullName(
                                                             "schemaX",
                                                             Guid.NewGuid()
                                                                 .ToString()),
                                                         Cardinality.OneToOne,
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new EntityPropertyDefinition[0],
                                                         new FullName("schemaX", "ExtensionEmbeddedObject1"),
                                                         new EntityPropertyDefinition[0],
                                                         true,
                                                         true)
                                                 },
                                                 new[]
                                                 {
                                                     new AggregateExtensionDefinition(
                                                         new FullName(_edfiSchema, "Entity1"),
                                                         new[]
                                                         {
                                                             new FullName("schemaX", "ExtensionEntity1"),
                                                             new FullName("schemaX", "ExtensionEmbeddedObject1")
                                                         })
                                                 }));

            _domainModelProvider = new DomainModelProvider(
                new[]
                {
                    definitionsProvider, extensionDefinitionsProvider
                });

            _resourceModelProvider = new ResourceModelProvider(_domainModelProvider);
        }

        protected override void Act()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            _actualResource = resourceModel.GetResourceByFullName(new FullName(_edfiSchema, "Entity1"));

            _actualExtension = _actualResource.Extensions.FirstOrDefault();

            _actualContainedItemTypes = _actualResource.AllContainedItemTypes;
        }

        [Assert]
        public void Should_create_a_single_extension_class()
        {
            Assert.That(_actualResource.Extensions, Has.Count.EqualTo(1));
        }

        [Assert]
        public void Should_assign_the_property_name_for_the_extension_class_using_ProperCaseName_conventions_based_on_the_physical_schema_name()
        {
            Assert.That(_actualExtension.PropertyName, Is.EqualTo("SchemaX"));
        }

        [Assert]
        public void Should_assign_the_object_type_name_for_the_extension_class_using_a_suffix_of_Extension_applied_to_the_containing_entitys_name()
        {
            Assert.That(_actualExtension.ObjectType.Name, Is.EqualTo("Entity1Extension"));
        }

        [Assert]
        public void Should_expose_the_extension_properties()
        {
            Assert.That(_actualExtension.ObjectType.Properties, Has.Count.EqualTo(2));
            Assert.That(_actualExtension.ObjectType.PropertyByName["Property1"], Is.Not.Null);
            Assert.That(_actualExtension.ObjectType.PropertyByName["Property2"], Is.Not.Null);
        }

        [Assert]
        public void Should_expose_the_extension_collection_on_the_explicit_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.CollectionByName.ContainsKey("ExtensionEntity1s"),
                "Unable to find the extension collection on the implicit extension object.");
        }

        [Assert]
        public void Should_expose_the_extension_embedded_object_on_the_explicit_extension_object()
        {
            Assert.That(
                _actualExtension.ObjectType.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                "Unable to find the extension embedded object on the implicit extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_embedded_object_on_the_main_resource()
        {
            Assert.That(
                _actualResource.EmbeddedObjectByName.ContainsKey("ExtensionEmbeddedObject1"),
                Is.False,
                "The extension embedded object was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_not_expose_the_extension_collection_on_the_main_resource()
        {
            Assert.That(
                _actualResource.CollectionByName.ContainsKey("ExtensionEntity1s"),
                Is.False,
                "The extension collection was found on the main resource, but it should have been moved to the extension object.");
        }

        [Assert]
        public void Should_assign_the_entity_extensions_EdFi_Standard_association_to_reference_the_entity_that_is_being_extended()
        {
            var entityExtension = _domainModelProvider.GetDomainModel()
                                                      .EntityByFullName[new FullName("schemaX", "Entity1Extension")];

            var extendedEntity = _domainModelProvider.GetDomainModel()
                                                     .EntityByFullName[new FullName(_edfiSchema, "Entity1")];

            Assert.That(entityExtension.EdFiStandardEntityAssociation.OtherEntity, Is.SameAs(extendedEntity));
            Assert.That(entityExtension.EdFiStandardEntity, Is.SameAs(extendedEntity));
        }

        [Assert]
        public void Should_make_the_extension_entity_a_navigable_child_of_the_standard_entity()
        {
            var extendedEntity = _domainModelProvider.GetDomainModel()
                                                     .EntityByFullName[new FullName(_edfiSchema, "Entity1")];

            var extensionEntity = _domainModelProvider.GetDomainModel()
                                                      .EntityByFullName[new FullName("schemaX", "ExtensionEntity1")];

            Assert.That(
                extendedEntity.NavigableChildren
                              .Where(x => x.OtherEntity.Schema == "schemaX")
                              .Select(x => x.OtherEntity)
                              .Single(),
                Is.SameAs(extensionEntity));
        }

        [Assert]
        public void Should_not_include_the_main_resource_itself_in_the_list_of_its_contained_item_types()
        {
            Assert.That(
                _actualContainedItemTypes.SingleOrDefault(x => x.Name == _edfiSchema),
                Is.Null,
                "The resource itself was included in the list of 'contained' item types.");
        }

        [Assert]
        public void Should_include_the_resource_class_for_the_entity_extension_in_the_resources_contained_item_types()
        {
            Assert.That(
                _actualContainedItemTypes.SingleOrDefault(x => x.Name == "Entity1Extension"),
                Is.Not.Null,
                "The extension class was not included.");
        }

        [Assert]
        public void Should_include_the_resource_class_for_the_extension_collection_in_the_resources_contained_item_types()
        {
            Assert.That(
                _actualContainedItemTypes.SingleOrDefault(x => x.Name == "ExtensionEntity1"),
                Is.Not.Null,
                "The extension class was not included.");
        }

        [Assert]
        public void Should_include_the_resource_class_for_the_extension_embedded_object_in_the_resources_contained_item_types()
        {
            Assert.That(
                _actualContainedItemTypes.SingleOrDefault(x => x.Name == "ExtensionEmbeddedObject1"),
                Is.Not.Null,
                "The extension class was not included.");
        }

        [Assert]
        public void Should_not_include_any_other_item_types_in_the_resources_contained_item_types()
        {
            var expectedItemTypes = new[]
                                    {
                                        "Entity1Extension", "ExtensionEntity1", "ExtensionEmbeddedObject1"
                                    };

            Assert.That(
                _actualContainedItemTypes.Select(x => x.Name)
                                         .Except(expectedItemTypes)
                                         .Count(),
                Is.EqualTo(0));
        }

        [Assert]
        public void Should_reassign_the_extension_collections_parent_to_be_the_extension_class_rather_than_the_main_resource_being_extended()
        {
            var extensionResourceClass = _actualResource.ExtensionByName["SchemaX"]
                                                        .ObjectType;

            var collection = extensionResourceClass.CollectionByName["ExtensionEntity1s"];

            Assert.That(collection.Parent, Is.SameAs(extensionResourceClass));
            Assert.That(collection.ParentFullName, Is.EqualTo(new FullName("schemaX", "Entity1Extension")));
        }
    }
}
