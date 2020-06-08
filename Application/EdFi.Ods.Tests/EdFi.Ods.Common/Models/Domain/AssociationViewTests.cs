// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Agg = EdFi.Ods.Common.Models.Definitions.AggregateDefinition;
using E = EdFi.Ods.Common.Models.Definitions.EntityDefinition;
using EId = EdFi.Ods.Common.Models.Definitions.EntityIdentifierDefinition;
using EP = EdFi.Ods.Common.Models.Definitions.EntityPropertyDefinition;
using PT = EdFi.Ods.Common.Models.Domain.PropertyType;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AssociationViewTests
    {
        [TestFixture]
        public class When_an_AssociationView_represents_a_self_referencing_relationship : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("schema", "schema"));

                builder.AddAggregate(new AggregateDefinition(new FullName("schema", "Thing"), new FullName[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                // Direct, self-recursive relationship
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "selfReferencingAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateInt32Property("ParentProperty1")
                        },
                        isIdentifying: false,
                        isRequired: false));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
            }

            private static EP CreateInt32Property(string name)
            {
                return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null);
            }

            private static EP CreateIdentifyingInt32Property(string name)
            {
                return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null, isIdentifying: true);
            }

            [Assert]
            public void Should_indicate_that_the_self_one_to_many_association_is_non_navigable()
            {
                var selfOneToManyAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfOneToManyAssociation.IsNavigable, Is.False);
            }

            [Assert]
            public void Should_indicate_that_the_self_one_to_many_association_DOES_NOT_have_a_role_name()
            {
                var selfOneToManyAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfOneToManyAssociation.RoleName, Is.Null);
            }

            [Assert]
            public void Should_indicate_that_the_self_many_to_one_association_associates_members_of_the_same_aggregate()
            {
                var selfManyToOneAssociation =
                    _entity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfManyToOneAssociation.AssociatesEntitiesOfTheSameAggregate, Is.True);
            }

            [Assert]
            public void Should_indicate_that_the_self_many_to_one_association_is_non_navigable()
            {
                var selfManyToOneAssociation =
                    _entity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfManyToOneAssociation.IsNavigable, Is.False);
            }

            [Assert]
            public void Should_indicate_that_the_self_many_to_one_association_has_a_role_name_of_Parent()
            {
                var selfManyToOneAssociation =
                    _entity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfManyToOneAssociation.RoleName, Is.EqualTo("Parent"));
            }

            [Assert]
            public void Should_indicate_that_the_self_one_to_many_association_associates_members_of_the_same_aggregate()
            {
                var selfOneToManyAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "selfReferencingAssociation"));

                Assert.That(selfOneToManyAssociation.AssociatesEntitiesOfTheSameAggregate, Is.True);
            }
        }

        [TestFixture]
        public class
            When_evaluating_two_identifying_one_to_many_relationships_to_the_same_entity_with_a_role_name_applied_to_only_one_of_the_relationships
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "Property1", "RelatedProperty1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_primary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryOutgoingAssociation = _entity.OutgoingAssociations
                                                        .Single(x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_outgoing_associations_IS_a_self_referencing_many_to_many_relationships()
            {
                var secondayOutgoingAssociation = _entity.OutgoingAssociations
                                                         .Single(x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(secondayOutgoingAssociation.IsSelfReferencingManyToMany, Is.True);
            }

            [Assert]
            public void Should_indicate_that_the_primary_incoming_association_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                   .Single(
                                                                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_incoming_associations_IS_a_self_referencing_many_to_many_relationships()
            {
                var secondayIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                    .Single(
                                                                         x => x.Association.FullName == new FullName(
                                                                                  "schema",
                                                                                  "secondaryAssociation"));

                Assert.That(secondayIncomingAssociation.IsSelfReferencingManyToMany, Is.True);
            }
        }

        [TestFixture]
        public class
            When_evaluating_three_identifying_one_to_many_relationships_to_the_same_entity_with_a_role_name_applied_to_only_one_of_the_relationships
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("Schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "Property1", "RelatedProperty1", "RelatedTooProperty1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                // Third (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "tertiaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedTooProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_primary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryOutgoingAssociation = _entity.OutgoingAssociations
                                                        .Single(x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayOutgoingAssociation = _entity.OutgoingAssociations
                                                         .Single(x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(secondayOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_primary_incoming_association_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                   .Single(
                                                                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_incoming_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                    .Single(
                                                                         x => x.Association.FullName == new FullName(
                                                                                  "schema",
                                                                                  "secondaryAssociation"));

                Assert.That(secondayIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }
        }

        [TestFixture]
        public class
            When_evaluating_two_NON_IDENTIFYING_one_to_many_relationships_to_the_same_entity_with_a_role_name_applied_to_only_one_of_the_relationships
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("Schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        isIdentifying: false,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: false,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_primary_outgoing_associations_is_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryOutgoingAssociation = _entity.OutgoingAssociations
                                                        .Single(x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_outgoing_associations_is_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayOutgoingAssociation = _entity.OutgoingAssociations
                                                         .Single(x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(secondayOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_primary_incoming_association_is_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                   .Single(
                                                                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_incoming_associations_is_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                    .Single(
                                                                         x => x.Association.FullName == new FullName(
                                                                                  "schema",
                                                                                  "secondaryAssociation"));

                Assert.That(secondayIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }
        }

        [TestFixture]
        public class When_evaluating_two_identifying_one_to_many_relationships_to_the_same_entity_with_role_names_applied_to_both
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("Schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "RelatedProperty1", "RelatedTooProperty1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        },
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedTooProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_primary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryOutgoingAssociation = _entity.OutgoingAssociations
                                                        .Single(x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayOutgoingAssociation = _entity.OutgoingAssociations
                                                         .Single(x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(secondayOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_primary_incoming_association_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                   .Single(
                                                                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_incoming_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                    .Single(
                                                                         x => x.Association.FullName == new FullName(
                                                                                  "schema",
                                                                                  "secondaryAssociation"));

                Assert.That(secondayIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }
        }

        [TestFixture]
        public class When_evaluating_two_one_to_many_relationships_to_the_same_entity_with_a_role_name_applied_to_the_primary_identifying_association
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("Schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new[]
                        {
                            CreateInt32Property("Property2")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "RelatedProperty1", "Property2"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        isIdentifying: false,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_primary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryOutgoingAssociation = _entity.OutgoingAssociations
                                                        .Single(x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_outgoing_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayOutgoingAssociation = _entity.OutgoingAssociations
                                                         .Single(x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(secondayOutgoingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_primary_incoming_association_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var primaryIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                   .Single(
                                                                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(primaryIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_incoming_associations_IS_NOT_a_self_referencing_many_to_many_relationships()
            {
                var secondayIncomingAssociation = _associativeEntity.IncomingAssociations
                                                                    .Single(
                                                                         x => x.Association.FullName == new FullName(
                                                                                  "schema",
                                                                                  "secondaryAssociation"));

                Assert.That(secondayIncomingAssociation.IsSelfReferencingManyToMany, Is.Not.True);
            }
        }

        [TestFixture]
        public class When_AssociationViews_represent_a_self_referencing_many_to_many_relationship_within_the_same_aggregate : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("Schema", "schema"));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            new FullName("schema", "RelatedThing")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "Property1", "RelatedProperty1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("Property1")
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            [Assert]
            public void Should_indicate_that_the_associations_involved_in_the_self_many_to_many_relationship_associate_members_of_the_same_aggregate()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.AssociatesEntitiesOfTheSameAggregate, Is.True);
                Assert.That(selfOneToManySecondaryAssociation.AssociatesEntitiesOfTheSameAggregate, Is.True);
            }

            // Primary Association of the self referencing many-to-many
            [Assert]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_is_NOT_a_self_recursive_many_to_many_association()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.IsSelfReferencingManyToMany, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_DOES_NOT_have_a_role_name()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.RoleName, Is.Null);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_is_navigable_because_the_associative_entity_is_a_member_of_the_same_aggregate()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.IsNavigable, Is.True);
            }

            // Associative entity's view of the primary association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_is_NOT_a_self_recursive_many_to_many_association()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.IsSelfReferencingManyToMany, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_has_a_role_name_of_Related()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.RoleName, Is.EqualTo("Related"));
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_has_an_association_name_of_RelatedAnEntities()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.Name, Is.EqualTo("RelatedThing"));
            }

            // Associative entity's view of the secondary Association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_is_a_self_recursive_many_to_many_association()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.IsSelfReferencingManyToMany, Is.True);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_is_NOT_navigable_even_though_its_in_the_same_aggregate()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.IsNavigable, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_DOES_NOT_have_a_role_name()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.RoleName, Is.Null);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_is_navigable_because_the_associative_entity_is_a_member_of_the_same_aggregate()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.IsNavigable, Is.True);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_has_a_role_name_of_Related()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.RoleName, Is.EqualTo("Related"));
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_has_an_association_name_of_RelatedASelfManyToManyEntities()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.Name, Is.EqualTo("RelatedRelatedThings"));

                // TODO: GKM - ODS-1182 - Assert.That(selfOneToManySecondaryAssociation.Name, Is.EqualTo("RelatedThingsForRelatedThing"));
            }

            // Secondary Association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_is_a_self_recursive_many_to_many_association()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.IsSelfReferencingManyToMany, Is.True);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_is_NOT_navigable_even_though_its_in_the_same_aggregate()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.IsNavigable, Is.False);
            }
        }

        [TestFixture]
        public class When_AssociationViews_represent_a_self_referencing_many_to_many_relationship_but_the_associative_entity_is_in_its_own_aggregate
            : TestFixtureBase
        {
            private DomainModel _domainModel;
            private Entity _entity;
            private Entity _associativeEntity;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(new SchemaDefinition("schema", "schema"));

                builder.AddAggregate(new AggregateDefinition(new FullName("schema", "Thing"), new FullName[0]));
                builder.AddAggregate(new AggregateDefinition(new FullName("schema", "RelatedThing"), new FullName[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Thing",
                        new[]
                        {
                            CreateIdentifyingInt32Property()
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_2",
                                new[]
                                {
                                    "Property1"
                                },
                                isPrimary: true)
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RelatedThing",
                        new EntityPropertyDefinition[0],
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_3",
                                new[]
                                {
                                    "Property1", "RelatedProperty1"
                                },
                                isPrimary: true)
                        }));

                // Primary association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "primaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property()
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property()
                        },
                        isIdentifying: true,
                        isRequired: true));

                // Secondary (non-navigable) association of the associative entity (for the self-recursive many-to-many relationship)
                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "secondaryAssociation"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Thing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property()
                        },
                        new FullName("schema", "RelatedThing"),
                        new[]
                        {
                            CreateIdentifyingInt32Property("RelatedProperty1")
                        }, // Role-named secondary association
                        isIdentifying: true,
                        isRequired: true));

                _domainModel = builder.Build();

                _entity = _domainModel.EntityByFullName[new FullName("schema", "Thing")];
                _associativeEntity = _domainModel.EntityByFullName[new FullName("schema", "RelatedThing")];
            }

            private static EP CreateInt32Property(string name = "Property1")
            {
                return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null);
            }

            private static EP CreateIdentifyingInt32Property(string name = "Property1")
            {
                return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null, isIdentifying: true);
            }

            [Assert]
            public void Should_indicate_that_the_self_many_to_many_associations_DO_NOT_associate_members_of_the_same_aggregate()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.AssociatesEntitiesOfTheSameAggregate, Is.False);
                Assert.That(selfOneToManySecondaryAssociation.AssociatesEntitiesOfTheSameAggregate, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_DOES_NOT_have_a_role_name()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.RoleName, Is.Null);
            }

            // Associative entity's view of the primary association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_is_NOT_a_self_recursive_many_to_many_association()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.IsSelfReferencingManyToMany, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_primary_association_in_the_self_many_to_many_relationship_is_NOT_navigable_because_the_associative_entity_is_NOT_a_member_of_the_same_aggregate()
            {
                var selfManyToOnePrimaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfManyToOnePrimaryAssociation.IsNavigable, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_has_a_role_name_of_Related()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.RoleName, Is.EqualTo("Related"));
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_has_an_association_name_of_RelatedAnEntities()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.Name, Is.EqualTo("RelatedThing"));
            }

            // Associative entity's view of the secondary Association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_is_a_self_recursive_many_to_many_association()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.IsSelfReferencingManyToMany, Is.True);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_incoming_associative_entitys_secondary_association_in_the_self_many_to_many_relationship_is_NOT_navigable()
            {
                var selfManyToOneSecondaryAssociation =
                    _associativeEntity.IncomingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfManyToOneSecondaryAssociation.IsNavigable, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_DOES_NOT_have_a_role_name()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.RoleName, Is.Null);
            }

            // Primary Association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_is_NOT_a_self_recursive_many_to_many_association()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.IsSelfReferencingManyToMany, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_primary_association_in_the_self_many_to_many_relationship_is_NOT_navigable_because_the_associative_entity_is_NOT_a_member_of_the_same_aggregate()
            {
                var selfOneToManyPrimaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "primaryAssociation"));

                Assert.That(selfOneToManyPrimaryAssociation.IsNavigable, Is.False);
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_has_a_role_name_with_a_To_suffix_appended()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.RoleName, Is.EqualTo("Related"));
            }

            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_has_an_association_name_of_RelatedASelfManyToManyEntities()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.Name, Is.EqualTo("RelatedRelatedThings"));

                // TODO: GKM - ODS-1182 - Assert.That(selfOneToManySecondaryAssociation.Name, Is.EqualTo("RelatedThingsForRelatedThing"));
            }

            // Secondary Association of the self referencing many-to-many
            [Test]
            public virtual void
                Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_is_a_self_recursive_many_to_many_association()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.IsSelfReferencingManyToMany, Is.True);
            }

            [Test]
            public virtual void Should_indicate_that_the_outgoing_secondary_association_in_the_self_many_to_many_relationship_is_NOT_navigable()
            {
                var selfOneToManySecondaryAssociation =
                    _entity.OutgoingAssociations.Single(
                        x => x.Association.FullName == new FullName("schema", "secondaryAssociation"));

                Assert.That(selfOneToManySecondaryAssociation.IsNavigable, Is.False);
            }
        }

        [TestFixture]
        public class When_an_AssociationView_targets_an_entity_that_is_an_entity_extension : TestFixtureBase
        {
            private DomainModel _model;

            protected override void Arrange()
            {
                // Set up mocked dependences and supplied values
                var bldr = new DomainModelBuilder();

                bldr.AddSchema(new SchemaDefinition("schema", "extension"));
                bldr.AddSchema(new SchemaDefinition("edfi", "edfi"));

                bldr.AddAggregate(
                    new AggregateDefinition(
                        new FullName("extension", "FundingSourceDescriptor"),
                        new[]
                        {
                            new FullName("extension", "FundingSourceDescriptor")
                        }));

                bldr.AddAggregate(
                    new AggregateDefinition(
                        new FullName("extension", "FundingSourceType"),
                        new[]
                        {
                            new FullName("extension", "FundingSourceType")
                        }));

                bldr.AddAggregate(
                    new AggregateDefinition(
                        new FullName("edfi", "Descriptor"),
                        new[]
                        {
                            new FullName("edfi", "Descriptor")
                        }));

                bldr.AddAggregate(
                    new AggregateDefinition(
                        new FullName("edfi", "OpenStaffPosition"),
                        new[]
                        {
                            new FullName("edfi", "OpenStaffPosition")
                        })); //, new FullName("edfi", "OpenStaffPositionAcademicSubject"), new FullName("edfi", "OpenStaffPositionInstructionalGradeLevel") });

                bldr.AddEntity(
                    new EntityDefinition(
                        "extension",
                        "FundingSourceDescriptor",
                        new EP[0],
                        new[]
                        {
                            new EId(
                                "PK_FundingSourceDescriptor",
                                new[]
                                {
                                    "FundingSourceDescriptorId"
                                },
                                true)
                        },
                        false,
                        ""));

                bldr.AddEntity(
                    new EntityDefinition(
                        "edfi",
                        "Descriptor",
                        new[]
                        {
                            new EP(
                                "DescriptorId",
                                new PT(DbType.Int32, 0, 10, 0, false),
                                "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                true,
                                true),
                            new EP(
                                "Namespace",
                                new PT(DbType.String, 255, 0, 0, false),
                                "A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.",
                                false,
                                false),
                            new EP(
                                "CodeValue",
                                new PT(DbType.String, 50, 0, 0, false),
                                "A code or abbreviation that is used to refer to the descriptor.",
                                false,
                                false),
                            new EP(
                                "ShortDescription",
                                new PT(DbType.String, 75, 0, 0, false),
                                "A shortened description for the descriptor.",
                                false,
                                false),
                            new EP("Description", new PT(DbType.String, 1024, 0, 0, true), "The description of the descriptor.", false, false),
                            new EP(
                                "PriorDescriptorId",
                                new PT(DbType.Int32, 0, 10, 0, true),
                                "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                false,
                                false),
                            new EP(
                                "EffectiveBeginDate",
                                new PT(DbType.Date, 0, 0, 0, true),
                                "The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.",
                                false,
                                false),
                            new EP(
                                "EffectiveEndDate",
                                new PT(DbType.Date, 0, 0, 0, true),
                                "The end date of the period when the descriptor is in effect.",
                                false,
                                false),
                            new EP("Id", new PT(DbType.Guid, 0, 0, 0, false), "", false, false),
                            new EP("LastModifiedDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                            new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                        },
                        new[]
                        {
                            new EId(
                                "PK_Descriptor",
                                new[]
                                {
                                    "DescriptorId"
                                },
                                true),
                            new EId(
                                "UK_Descriptor",
                                new[]
                                {
                                    "Namespace", "CodeValue"
                                },
                                false),
                            new EId(
                                "UX_Descriptor_Id",
                                new[]
                                {
                                    "Id"
                                },
                                false)
                        },
                        true,
                        "This is the base entity for the descriptor pattern."));

                bldr.AddEntity(
                    new EntityDefinition(
                        "extension",
                        "FundingSourceType",
                        new[]
                        {
                            new EP("FundingSourceTypeId", new PT(DbType.Int32, 0, 10, 0, false), "", true, true),
                            new EP("CodeValue", new PT(DbType.String, 50, 0, 0, false), "", false, false),
                            new EP("Description", new PT(DbType.String, 1024, 0, 0, false), "", false, false),
                            new EP("ShortDescription", new PT(DbType.String, 450, 0, 0, false), "", false, false),
                            new EP("Id", new PT(DbType.Guid, 0, 0, 0, false), "", false, false),
                            new EP("LastModifiedDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                            new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                        },
                        new[]
                        {
                            new EId(
                                "PK_FundingSourceType",
                                new[]
                                {
                                    "FundingSourceTypeId"
                                },
                                true)
                        },
                        false,
                        ""));

                bldr.AddEntity(
                    new EntityDefinition(
                        "edfi",
                        "OpenStaffPosition",
                        new[]
                        {
                            new EP(
                                "EducationOrganizationId",
                                new PT(DbType.Int32, 0, 10, 0, false),
                                "Added as local property rather than an association from EdOrg for test simplicity.",
                                true,
                                false),
                            new EP(
                                "RequisitionNumber",
                                new PT(DbType.String, 20, 0, 0, false),
                                "The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.",
                                true,
                                false),
                            new EP("DatePosted", new PT(DbType.Date, 0, 0, 0, false), "Date the OpenStaffPosition was posted.", false, false),
                            new EP(
                                "PositionTitle",
                                new PT(DbType.String, 100, 0, 0, true),
                                "The descriptive name of an individual's position.",
                                false,
                                false),
                            new EP(
                                "DatePostingRemoved",
                                new PT(DbType.Date, 0, 0, 0, true),
                                "The date the posting was removed or filled.",
                                false,
                                false),
                            new EP("Id", new PT(DbType.Guid, 0, 0, 0, false), "", false, false),
                            new EP("LastModifiedDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                            new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                        },
                        new[]
                        {
                            new EId(
                                "PK_OpenStaffPosition",
                                new[]
                                {
                                    "EducationOrganizationId", "RequisitionNumber"
                                },
                                true),
                            new EId(
                                "UX_OpenStaffPosition_Id",
                                new[]
                                {
                                    "Id"
                                },
                                false)
                        },
                        false,
                        "This entity represents an open staff position that the education organization is seeking to fill."));

                bldr.AddEntity(
                    new EntityDefinition(
                        "extension",
                        "OpenStaffPositionExtension",
                        new[]
                        {
                            new EP("FullTimeEquivalency", new PT(DbType.Decimal, 0, 3, 2, false), "", false, false),
                            new EP("IsActive", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                            new EP("MaxSalary", new PT(DbType.Decimal, 0, 9, 2, true), "", false, false),
                            new EP("MinSalary", new PT(DbType.Decimal, 0, 9, 2, true), "", false, false),
                            new EP("HighNeedAcademicSubject", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                            new EP("PositionControlNumber", new PT(DbType.String, 20, 0, 0, true), "", false, false),
                            new EP("TotalBudgeted", new PT(DbType.Decimal, 0, 9, 2, true), "", false, false)
                        },
                        new[]
                        {
                            new EId(
                                "PK_OpenStaffPositionExtension",
                                new[]
                                {
                                    "EducationOrganizationId", "RequisitionNumber"
                                },
                                true)
                        },
                        false,
                        ""));

                bldr.AddAssociation(
                    new AssociationDefinition(
                        new FullName("extension", "FK_FundingSourceDescriptor_Descriptor_DescriptorId"),
                        Cardinality.OneToOneInheritance,
                        new FullName("edfi", "Descriptor"),
                        new[]
                        {
                            new EP(
                                "DescriptorId",
                                new PT(DbType.Int32, 0, 10, 0, false),
                                "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                true,
                                true)
                        },
                        new FullName("extension", "FundingSourceDescriptor"),
                        new[]
                        {
                            new EP("FundingSourceDescriptorId", new PT(DbType.Int32, 0, 10, 0, false), "", true, true)
                        },
                        true,
                        true));

                bldr.AddAssociation(
                    new AssociationDefinition(
                        new FullName("extension", "FK_OpenStaffPositionExtension_OpenStaffPosition_EducationOrganizationId"),
                        Cardinality.OneToOneExtension,
                        new FullName("edfi", "OpenStaffPosition"),
                        new[]
                        {
                            new EP(
                                "EducationOrganizationId",
                                new PT(DbType.Int32, 0, 10, 0, false),
                                "EducationOrganization Identity Column",
                                true,
                                false),
                            new EP(
                                "RequisitionNumber",
                                new PT(DbType.String, 20, 0, 0, false),
                                "The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.",
                                true,
                                false)
                        },
                        new FullName("extension", "OpenStaffPositionExtension"),
                        new[]
                        {
                            new EP("EducationOrganizationId", new PT(DbType.Int32, 0, 10, 0, false), "", true, false),
                            new EP("RequisitionNumber", new PT(DbType.String, 20, 0, 0, false), "", true, false)
                        },
                        true,
                        true));

                bldr.AddAssociation(
                    new AssociationDefinition(
                        new FullName("extension", "FK_OpenStaffPositionExtension_FundingSourceDescriptor_FundingSourceDescriptorId"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("extension", "FundingSourceDescriptor"),
                        new[]
                        {
                            new EP("FundingSourceDescriptorId", new PT(DbType.Int32, 0, 10, 0, false), "", false, false)
                        },
                        new FullName("extension", "OpenStaffPositionExtension"),
                        new[]
                        {
                            new EP("FundingSourceDescriptorId", new PT(DbType.Int32, 0, 10, 0, true), "", false, false)
                        },
                        false,
                        false));

                bldr.AddAssociation(
                    new AssociationDefinition(
                        new FullName("extension", "FK_FundingSourceDescriptor_FundingSourceType_FundingSourceTypeId"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("extension", "FundingSourceType"),
                        new[]
                        {
                            new EP("FundingSourceTypeId", new PT(DbType.Int32, 0, 10, 0, false), "", false, true)
                        },
                        new FullName("extension", "FundingSourceDescriptor"),
                        new[]
                        {
                            new EP("FundingSourceTypeId", new PT(DbType.Int32, 0, 10, 0, false), "", false, false)
                        },
                        false,
                        true));

                _model = bldr.Build();
            }

            [Assert]
            public void Should_NOT_include_the_suffix_Extension_in_the_association_name()
            {
                var descriptor = _model.EntityByFullName[new FullName("extension", "FundingSourceDescriptor")];
                var association = descriptor.NonNavigableChildren.Single();

                Assert.That(association.Name, Is.EqualTo("OpenStaffPositions"));
            }

            [Test]
            public virtual void Should_indicate_the_association_is_non_navigable()
            {
                var descriptor = _model.EntityByFullName[new FullName("extension", "FundingSourceDescriptor")];

                var association = descriptor.OutgoingAssociations.Single();

                Assert.That(association.IsNavigable, Is.False);
            }
        }

        public class When_finding_the_inverse_of_an_AssociationView : TestFixtureBase
        {
            private Entity _parentEntity;
            private Entity _childEntity;
            private Entity _parentEntityOneToOne;
            private Entity _parentEntityExtension;
            private Entity _derivedEntity;

            protected override void Act()
            {
                var domainModelBuilder = new DomainModelBuilder();

                domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));
                domainModelBuilder.AddSchema(new SchemaDefinition("another", "another"));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new FullName("schema", "AChild"), new FullName("schema", "AParentOneToOne")
                        }));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "ADerived"),
                        new FullName[0]));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AParent",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AParent",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AChild",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AChild",
                                new[]
                                {
                                    "Primary1", "Primary2"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "ADerived",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary3", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_ADerived",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "another",
                        "AParentExtension",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true),
                            new EntityPropertyDefinition("ExtensionProperty1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AParentExtension",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AParentOneToOne",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true),
                            new EntityPropertyDefinition("OneToOneProperty1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AParentOneToOne",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "AChild"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToOne,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "AParentOneToOne"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToOneExtension,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("another", "AParentExtension"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToOneInheritance,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "ADerived"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                var model = domainModelBuilder.Build();

                _parentEntity = model.EntityByFullName[new FullName("schema", "AParent")];
                _childEntity = model.EntityByFullName[new FullName("schema", "AChild")];
                _derivedEntity = model.EntityByFullName[new FullName("schema", "ADerived")];
                _parentEntityExtension = model.EntityByFullName[new FullName("another", "AParentExtension")];
                _parentEntityOneToOne = model.EntityByFullName[new FullName("schema", "AParentOneToOne")];
            }

            [Test]
            public virtual void Should_find_inverse_associations_for_extension_associations()
            {
                var outboundExtension =
                    _parentEntity.OutgoingAssociations
                                 .Single(a => a.AssociationType == AssociationViewType.ToExtension);

                var inboundExtension = _parentEntityExtension.IncomingAssociations.Single();

                // Sanity check -- make sure we're comparing the views for the same association
                Assert.That(outboundExtension.Association, Is.EqualTo(inboundExtension.Association));

                Assert.That(
                    outboundExtension.Inverse,
                    Is.EqualTo(inboundExtension),
                    "Inverse failed from the CORE side of the EXTENSION association.");

                Assert.That(
                    inboundExtension.Inverse,
                    Is.EqualTo(outboundExtension),
                    "Inverse failed from the EXTENSION side of the EXTENSION association.");

                Assert.That(
                    inboundExtension.AssociationType,
                    Is.EqualTo(AssociationViewType.FromCore),
                    "Inverse association was not of the expected type.");
            }

            [Test]
            public virtual void Should_find_inverse_associations_for_inheritance_associations()
            {
                var toDerived =
                    _parentEntity.OutgoingAssociations
                                 .Single(a => a.AssociationType == AssociationViewType.ToDerived);

                var fromBase = _derivedEntity.IncomingAssociations.Single();

                // Sanity check -- make sure we're comparing the views for the same association
                Assert.That(toDerived.Association, Is.EqualTo(fromBase.Association));

                Assert.That(toDerived.Inverse, Is.EqualTo(fromBase), "Inverse failed from the BASE side of the INHERITANCE association.");
                Assert.That(fromBase.Inverse, Is.EqualTo(toDerived), "Inverse failed from the DERIVED side of the INHERITANCE association.");
                Assert.That(fromBase.AssociationType, Is.EqualTo(AssociationViewType.FromBase), "Inverse association was not of the expected type.");
            }

            [Test]
            public virtual void Should_find_inverse_associations_for_one_to_many_associations()
            {
                var outboundOneToMany =
                    _parentEntity.OutgoingAssociations
                                 .Single(a => a.AssociationType == AssociationViewType.OneToMany);

                var inboundManyToOne = _childEntity.IncomingAssociations.Single();

                // Sanity check -- make sure we're comparing the views for the same association
                Assert.That(outboundOneToMany.Association, Is.EqualTo(inboundManyToOne.Association));

                Assert.That(
                    outboundOneToMany.Inverse,
                    Is.EqualTo(inboundManyToOne),
                    "Inverse failed from the ONE side of the ONE-TO-MANY association.");

                Assert.That(
                    inboundManyToOne.Inverse,
                    Is.EqualTo(outboundOneToMany),
                    "Inverse failed from the MANY side of the ONE-TO-MANY association.");

                Assert.That(
                    inboundManyToOne.AssociationType,
                    Is.EqualTo(AssociationViewType.ManyToOne),
                    "Inverse association was not of the expected type.");
            }

            [Test]
            public virtual void Should_find_inverse_associations_for_one_to_one_associations()
            {
                var outboundOneToOne =
                    _parentEntity.OutgoingAssociations
                                 .Single(a => a.AssociationType == AssociationViewType.OneToOneOutgoing);

                var inboundOneToOne = _parentEntityOneToOne.IncomingAssociations.Single();

                // Sanity check -- make sure we're comparing the views for the same association
                Assert.That(outboundOneToOne.Association, Is.EqualTo(inboundOneToOne.Association));

                Assert.That(
                    outboundOneToOne.Inverse,
                    Is.EqualTo(inboundOneToOne),
                    "Inverse failed from the OUTBOUND side of the ONE-TO-ONE association.");

                Assert.That(
                    inboundOneToOne.Inverse,
                    Is.EqualTo(outboundOneToOne),
                    "Inverse failed from the INBOUND side of the ONE-TO-ONE association.");

                Assert.That(
                    inboundOneToOne.AssociationType,
                    Is.EqualTo(AssociationViewType.OneToOneIncoming),
                    "Inverse association was not of the expected type.");
            }
        }

        [TestFixture]
        public class When_determining_the_name_of_a_one_to_many_association : TestFixtureBase
        {
            private Entity _childEntity;
            private Entity _parentEntity;
            private Entity _multiChildEntity;

            protected override void Act()
            {
                var domainModelBuilder = new DomainModelBuilder();

                domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new FullName("schema", "AParent")
                        }));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "AChild"),
                        new[]
                        {
                            new FullName("schema", "AChild")
                        }));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "AMultiChild"),
                        new[]
                        {
                            new FullName("schema", "AMultiChild")
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AParent",
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AParent",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AChild",
                        new[]
                        {
                            new EntityPropertyDefinition("Role1Primary1", new PropertyType(DbType.Int32), string.Empty, true),
                            new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AChild",
                                new[]
                                {
                                    "Primary1"
                                },
                                true)
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "AMultiChild",
                        new[]
                        {
                            new EntityPropertyDefinition("Role1Primary1", new PropertyType(DbType.Int32), string.Empty, true),
                            new EntityPropertyDefinition("Role2Primary1", new PropertyType(DbType.Int32), string.Empty, true),
                            new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK_AMultiChild",
                                new[]
                                {
                                    "Primary2"
                                },
                                true)
                        }));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "AChild"),
                        new[]
                        {
                            new EntityPropertyDefinition("Role1Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "AMultiChild"),
                        new[]
                        {
                            new EntityPropertyDefinition("Role1Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        ModelTestUtility.GetRandomFullName("schema"),
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "AParent"),
                        new[]
                        {
                            new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        new FullName("schema", "AMultiChild"),
                        new[]
                        {
                            new EntityPropertyDefinition("Role2Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                        },
                        true,
                        true));

                var model = domainModelBuilder.Build();

                _parentEntity = model.EntityByFullName[new FullName("schema", "AParent")];
                _childEntity = model.EntityByFullName[new FullName("schema", "AChild")];
                _multiChildEntity = model.EntityByFullName[new FullName("schema", "AMultiChild")];
            }

            [Test]
            public virtual void Should_apply_role_name_to_association_when_multiple_one_to_many_associations_are_present()
            {
                var multiChildAssociations = _parentEntity.OutgoingAssociations
                                                          .Where(a => a.OtherEntity == _multiChildEntity)
                                                          .OrderBy(a => a.Name);

                Assert.That(
                    multiChildAssociations.ElementAt(0)
                                          .Name,
                    Is.EqualTo("Role1AMultiChildren"));

                Assert.That(
                    multiChildAssociations.ElementAt(1)
                                          .Name,
                    Is.EqualTo("Role2AMultiChildren"));
            }

            [Test]
            public virtual void Should_not_apply_role_name_to_association_when_a_single_one_to_many_association_is_present()
            {
                var childAssociation = _parentEntity.OutgoingAssociations
                                                    .Single(a => a.OtherEntity == _childEntity);

                Assert.That(childAssociation.Name, Is.EqualTo("AChildren"));
            }

            [Test]
            public virtual void Should_return_a_null_role_name_when_a_single_one_to_many_association_is_present()
            {
                var childAssociation = _parentEntity.OutgoingAssociations
                                                    .Single(a => a.OtherEntity == _childEntity);

                Assert.That(childAssociation.RoleName, Is.Null);
            }

            [Test]
            public virtual void Should_return_a_role_name_when_multiple_one_to_many_associations_are_present()
            {
                var multiChildAssociations = _parentEntity.OutgoingAssociations
                                                          .Where(a => a.OtherEntity == _multiChildEntity)
                                                          .OrderBy(a => a.Name);

                Assert.That(
                    multiChildAssociations.ElementAt(0)
                                          .RoleName,
                    Is.EqualTo("Role1"));

                Assert.That(
                    multiChildAssociations.ElementAt(1)
                                          .RoleName,
                    Is.EqualTo("Role2"));
            }
        }

        public class When_initializing_the_AssociationViewType_from_the_association_Cardinality : TestFixtureBase
        {
            private DomainModel _domainModel;

            protected override void Act()
            {
                // Perform the action to be tested
                var domainModelBuilder = new DomainModelBuilder();

                domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Parent",
                        new[]
                        {
                            new EP("Property1", new PropertyType(DbType.Int32), null, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK",
                                new[]
                                {
                                    "Property1"
                                })
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "RequiredChild",
                        new[]
                        {
                            new EP("Property2", new PropertyType(DbType.Int32), null, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK",
                                new[]
                                {
                                    "Property1", "Property2"
                                })
                        }));

                domainModelBuilder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "OptionalChild",
                        new[]
                        {
                            new EP("Property2", new PropertyType(DbType.Int32), null, true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK",
                                new[]
                                {
                                    "Property1", "Property2"
                                })
                        }));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "requiredassociation"),

                        // Required collection
                        Cardinality.OneToOneOrMore,
                        new FullName("schema", "Parent"),
                        new[]
                        {
                            new EP("Property1", new PropertyType(DbType.Int32), null, true)
                        },
                        new FullName("schema", "RequiredChild"),
                        new[]
                        {
                            new EP("Property1", new PropertyType(DbType.Int32), null, true)
                        },
                        isIdentifying: true,
                        isRequired: true
                    ));

                domainModelBuilder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "optionalassociation"),

                        // Optional collection
                        Cardinality.OneToZeroOrMore,
                        new FullName("schema", "Parent"),
                        new[]
                        {
                            new EP("Property1", new PropertyType(DbType.Int32), null, true)
                        },
                        new FullName("schema", "OptionalChild"),
                        new[]
                        {
                            new EP("Property1", new PropertyType(DbType.Int32), null, true)
                        },
                        isIdentifying: true,
                        isRequired: true
                    ));

                domainModelBuilder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Parent"),
                        new[]
                        {
                            new FullName("schema", "RequiredChild"), new FullName("schema", "OptionalChild")
                        }));

                _domainModel = domainModelBuilder.Build();
            }

            [Assert]
            public void Should_represent_an_association_with_OneToOneOrMore_cardinality_as_OneToMany_and_ManyToOne_association_views()
            {
                Assert.That(
                    _domainModel
                       .EntityByFullName[new FullName("Schema", "RequiredChild")]
                       .ParentAssociation
                       .AssociationType,
                    Is.EqualTo(AssociationViewType.ManyToOne));

                Assert.That(
                    _domainModel
                       .EntityByFullName[new FullName("Schema", "RequiredChild")]
                       .ParentAssociation
                       .Inverse
                       .AssociationType,
                    Is.EqualTo(AssociationViewType.OneToMany));
            }

            [Assert]
            public void Should_represent_an_association_with_OneToZeroOrMore_cardinality_as_OneToMany_and_ManyToOne_association_views()
            {
                Assert.That(
                    _domainModel
                       .EntityByFullName[new FullName("Schema", "OptionalChild")]
                       .ParentAssociation
                       .AssociationType,
                    Is.EqualTo(AssociationViewType.ManyToOne));

                Assert.That(
                    _domainModel
                       .EntityByFullName[new FullName("Schema", "OptionalChild")]
                       .ParentAssociation
                       .Inverse
                       .AssociationType,
                    Is.EqualTo(AssociationViewType.OneToMany));
            }
        }

        public class When_evaluating_AssociationViews_through_entity_associations_as_soft_dependencies : TestFixtureBase
        {
            private DomainModel _domainModel;
            private List<AssociationView> _inheritanceAssociations;
            private List<AssociationView> _extensionAssociations;
            private IEnumerable<AssociationView> _outgoingRelationships;
            private IEnumerable<AssociationView> _navigableAssociations;
            private IEnumerable<AssociationView> _nonNavigableOptionalManyToOneAssociations;
            private IEnumerable<AssociationView> _nonNavigableOptionalOneToOneIncomingAssociations;
            private List<AssociationView> _untestedAssociations;
            private IEnumerable<AssociationView> _topLevelRequiredManyToOneAssociations;
            private IEnumerable<AssociationView> _requiredCollectionChildrenWithRequiredAssociations;
            private IEnumerable<AssociationView> _optionalCollectionChildrenWithRequiredAssociations;
            private IEnumerable<AssociationView> _requiredEmbeddedObjectsWithRequiredAssociations;
            private IEnumerable<AssociationView> _optionalEmbeddedObjectsWithRequiredAssociations;
            private IEnumerable<AssociationView> _selfReferencingAssociations;

            protected override void Act()
            {
                _domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

                var allAssociations = _domainModel.AssociationViewsByEntityFullName
                    .SelectMany(x => x.Value)
                    .ToList();

                _selfReferencingAssociations = allAssociations.Where(
                    a => a.AssociationType == AssociationViewType.ManyToOne && a.IsSelfReferencing)
                    .ToList();
                
                _inheritanceAssociations = allAssociations.Where(a => 
                        a.AssociationType == AssociationViewType.FromBase
                        || a.AssociationType == AssociationViewType.ToDerived)
                    .ToList();

                _extensionAssociations = allAssociations.Where(a => 
                        a.AssociationType == AssociationViewType.FromCore
                        || a.AssociationType == AssociationViewType.ToExtension)
                    .ToList();

                _navigableAssociations = allAssociations.Where(a => 
                        a.IsNavigable
                        && a.AssociationType != AssociationViewType.ToExtension
                        && a.AssociationType != AssociationViewType.FromCore)
                    .ToList();

                _outgoingRelationships = allAssociations.Where(a => 
                    !a.IsNavigable
                    && (a.AssociationType == AssociationViewType.OneToOneOutgoing
                        || a.AssociationType == AssociationViewType.OneToMany))
                    .ToList();

                _nonNavigableOptionalManyToOneAssociations = allAssociations.Where(a =>
                    !a.IsNavigable && !a.IsSelfReferencing && !a.IsRequired
                    && a.AssociationType == AssociationViewType.ManyToOne)
                    .ToList();
                
                _nonNavigableOptionalOneToOneIncomingAssociations = allAssociations.Where(a => 
                    a.AssociationType == AssociationViewType.OneToOneIncoming && !a.IsNavigable && !a.IsRequired)
                    .ToList();

                _topLevelRequiredManyToOneAssociations = allAssociations.Where(
                    a => a.AssociationType == AssociationViewType.ManyToOne
                        && !a.IsNavigable
                        && a.IsRequired
                        && a.ThisEntity.IsAggregateRoot)
                    .ToList();

                var childRequiredManyToOneAssociations = allAssociations.Where(
                        a => a.AssociationType == AssociationViewType.ManyToOne
                            && !a.IsNavigable
                            && a.IsRequired
                            && !a.ThisEntity.IsAggregateRoot)
                    .ToList();
                    
                _requiredCollectionChildrenWithRequiredAssociations = childRequiredManyToOneAssociations
                    .Where(a => a.ThisEntity.ParentAssociation.AssociationType != AssociationViewType.OneToOneIncoming)
                    .Where(a =>
                        a.ThisEntity.ParentAssociation.Inverse.IsRequiredCollection
                        && a.ThisEntity.Parent?.ParentAssociation?.Inverse?.IsRequiredCollection != false
                        && a.ThisEntity.Parent?.Parent?.ParentAssociation?.Inverse?.IsRequiredCollection != false
                        && a.ThisEntity.Parent?.Parent?.Parent?.ParentAssociation?.Inverse?.IsRequiredCollection != false)
                    .ToList();

                _optionalCollectionChildrenWithRequiredAssociations = childRequiredManyToOneAssociations
                    .Where(a => a.ThisEntity.ParentAssociation.AssociationType != AssociationViewType.OneToOneIncoming)
                    .Where(a => 
                        (!a.ThisEntity.ParentAssociation.Inverse.IsRequiredCollection)  
                            || (a.ThisEntity.Parent?.Parent != null && !a.ThisEntity.Parent.ParentAssociation.Inverse.IsRequiredCollection)
                            || (a.ThisEntity?.Parent?.Parent?.Parent != null && !a.ThisEntity.Parent.Parent.ParentAssociation.Inverse.IsRequiredCollection))
                    .ToList();

                _requiredEmbeddedObjectsWithRequiredAssociations = childRequiredManyToOneAssociations
                    .Where(a => a.ThisEntity.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming)
                    .Where(a =>
                        a.ThisEntity.ParentAssociation.Inverse.IsRequired
                        // Check one level up for required child items (if it's in the there)
                        && (a.ThisEntity.Parent.Parent == null 
                            || (a.ThisEntity.Parent.ParentAssociation.AssociationType == AssociationViewType.ManyToOne 
                                && a.ThisEntity.Parent.ParentAssociation.Inverse.IsRequiredCollection) 
                            || (a.ThisEntity.Parent.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming 
                                && a.ThisEntity.Parent.ParentAssociation.Inverse.IsRequired))
                        // Check two levels up for required child items (if it's in the there)
                        && (a.ThisEntity.Parent.Parent?.Parent == null 
                            || (a.ThisEntity.Parent.Parent.ParentAssociation.AssociationType == AssociationViewType.ManyToOne 
                                && a.ThisEntity.Parent.Parent.ParentAssociation.Inverse.IsRequiredCollection)
                            || (a.ThisEntity.Parent.Parent.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming
                                && a.ThisEntity.Parent.Parent.ParentAssociation.Inverse.IsRequired)))
                    .ToList();

                _optionalEmbeddedObjectsWithRequiredAssociations = childRequiredManyToOneAssociations
                    .Where(a => a.ThisEntity.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming)
                    .Where(a =>
                        !a.ThisEntity.ParentAssociation.Inverse.IsRequired
                        // Check one level up for optional child items (if it's in the there)
                        || (a.ThisEntity.Parent.Parent != null 
                            && ((a.ThisEntity.Parent.ParentAssociation.AssociationType == AssociationViewType.ManyToOne && !a.ThisEntity.Parent.ParentAssociation.Inverse.IsRequiredCollection) 
                                || (a.ThisEntity.Parent.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming && !a.ThisEntity.Parent.ParentAssociation.Inverse.IsRequired)))
                        // Check two levels up for optional child items (if it's in the there)
                        || (a.ThisEntity.Parent.Parent?.Parent != null 
                            && ((a.ThisEntity.Parent.Parent.ParentAssociation.AssociationType == AssociationViewType.ManyToOne && !a.ThisEntity.Parent.Parent.ParentAssociation.Inverse.IsRequiredCollection)
                                || (a.ThisEntity.Parent.Parent.ParentAssociation.AssociationType == AssociationViewType.OneToOneIncoming && !a.ThisEntity.Parent.Parent.ParentAssociation.Inverse.IsRequired))))
                    .ToList();

                _untestedAssociations = allAssociations
                    .Remove(_selfReferencingAssociations, nameof(_selfReferencingAssociations))
                    .Remove(_inheritanceAssociations, nameof(_inheritanceAssociations))
                    .Remove(_extensionAssociations, nameof(_extensionAssociations))
                    .Remove(_navigableAssociations, nameof(_navigableAssociations))
                    .Remove(_outgoingRelationships, nameof(_outgoingRelationships))
                    .Remove(_nonNavigableOptionalManyToOneAssociations, nameof(_nonNavigableOptionalManyToOneAssociations))
                    .Remove(_nonNavigableOptionalOneToOneIncomingAssociations, nameof(_nonNavigableOptionalOneToOneIncomingAssociations))
                    .Remove(_topLevelRequiredManyToOneAssociations, nameof(_topLevelRequiredManyToOneAssociations))
                    .Remove(_requiredCollectionChildrenWithRequiredAssociations, nameof(_requiredCollectionChildrenWithRequiredAssociations))
                    .Remove(_optionalCollectionChildrenWithRequiredAssociations, nameof(_optionalCollectionChildrenWithRequiredAssociations))
                    .Remove(_requiredEmbeddedObjectsWithRequiredAssociations, nameof(_requiredEmbeddedObjectsWithRequiredAssociations))
                    .Remove(_optionalEmbeddedObjectsWithRequiredAssociations, nameof(_optionalEmbeddedObjectsWithRequiredAssociations))
                    .ToList();
            }

            [Test]
            public void Should_indicate_self_referencing_associations_ARE_soft_dependencies()
            {
                if (!_selfReferencingAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }
                
                _selfReferencingAssociations.ShouldAllBe(av => av.IsSoftDependency == true);
            }
            
            [Test]
            public void Should_indicate_association_views_that_are_involved_in_inheritance_ARE_NOT_soft_dependencies()
            {
                if (!_inheritanceAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }
                
                _inheritanceAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }
            
            [Test]
            public void Should_indicate_all_associations_that_are_involved_in_extensions_ARE_NOT_soft_dependencies()
            {
                if (!_extensionAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _extensionAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }
            
            [Test]
            public void Should_indicate_all_outgoing_associations_ARE_NOT_soft_dependencies()
            {
                if (!_outgoingRelationships.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _outgoingRelationships.ShouldAllBe(av => av.IsSoftDependency == false);
            }

            [Test]
            public void Should_indicate_all_navigable_relationships_ARE_NOT_soft_dependencies()
            {
                if (!_navigableAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _navigableAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }

            [Test]
            public void Should_indicate_optional_many_to_one_associations_ARE_soft_dependencies()
            {
                if (!_nonNavigableOptionalManyToOneAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _nonNavigableOptionalManyToOneAssociations.ShouldAllBe(av => av.IsSoftDependency == true);
            }
            
            [Test]
            public void Should_indicate_optional_one_to_one_incoming_associations_ARE_soft_dependencies()
            {
                if (!_nonNavigableOptionalOneToOneIncomingAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }
                
                _nonNavigableOptionalOneToOneIncomingAssociations.ShouldAllBe(av => av.IsSoftDependency == true);
            }

            [Test]
            public void Should_indicate_top_level_required_many_to_one_associations_ARE_NOT_soft_dependencies()
            {
                if (!_topLevelRequiredManyToOneAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }
                
                _topLevelRequiredManyToOneAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }

            [Test]
            public void Should_indicate_required_child_items_with_required_references_ARE_NOT_soft_dependencies()
            {
                if (!_requiredCollectionChildrenWithRequiredAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _requiredCollectionChildrenWithRequiredAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }
            
            [Test]
            public void Should_indicate_optional_child_items_with_required_references_ARE_soft_dependencies()
            {
                if (!_optionalCollectionChildrenWithRequiredAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _optionalCollectionChildrenWithRequiredAssociations.ShouldAllBe(av => av.IsSoftDependency == true);
            }
            
            [Test]
            public void Should_indicate_required_embedded_objects_with_required_references_ARE_NOT_soft_dependencies()
            {
                if (!_requiredEmbeddedObjectsWithRequiredAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _requiredEmbeddedObjectsWithRequiredAssociations.ShouldAllBe(av => av.IsSoftDependency == false);
            }
            
            [Test]
            public void Should_indicate_optional_embedded_objects_with_required_references_ARE_soft_dependencies()
            {
                if (!_optionalEmbeddedObjectsWithRequiredAssociations.Any())
                {
                    Assert.Inconclusive("No associations available to exercise test.");
                }

                _optionalEmbeddedObjectsWithRequiredAssociations.ShouldAllBe(av => av.IsSoftDependency == true);
            }
            
            [Test]
            public void All_associations_should_have_been_tested()
            {
                _untestedAssociations.ShouldBeEmpty();
            }
        }

        public class When_evaluating_AssociationViews_through_resource_references_as_soft_dependencies : TestFixtureBase
        {
            private DomainModel _domainModel;
            private ResourceModel _resourceModel;

            protected override void Act()
            {
                _domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();
                _resourceModel = new ResourceModel(_domainModel);
            }

            [Assert]
            public void Should_indicate_that_a_required_reference_on_a_resource_root_is_NOT_a_soft_dependency()
            {
                var association = 
                    _resourceModel.GetAllResources()
                    .SelectMany(res => res.References.Where(r => r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();

                association.ShouldNotBeNull();
                association.IsSoftDependency.ShouldBe(false);
            }
            
            [Assert]
            public void Should_indicate_that_an_optional_reference_on_a_resource_root_IS_a_soft_dependency()
            {
                var association = 
                    _resourceModel.GetAllResources()
                    .SelectMany(res => res.References.Where(r => !r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();

                association.ShouldNotBeNull();
                association.IsSoftDependency.ShouldBe(true);
            }
            
            [Assert]
            public void Should_indicate_that_an_optional_reference_on_an_item_in_an_optional_resource_child_collection_IS_a_soft_dependency()
            {
                var association = _resourceModel.GetAllResources()
                    .SelectMany(res => res.Collections)
                    .Where(c => !c.Association.IsRequiredCollection)
                    .SelectMany(c => c.ItemType.References.Where(r => !r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();

                if (association == null)
                {
                    Assert.Inconclusive("Unable to find an optional reference on an item in an optional collection for testing.");
                }

                association.ShouldNotBeNull();
                association.IsSoftDependency.ShouldBe(true);
            }
            
            [Assert]
            public void Should_indicate_that_a_required_reference_on_an_item_in_an_optional_child_collection_IS_a_soft_dependency()
            {
                var association = _resourceModel.GetAllResources()
                    .SelectMany(res => res.Collections)
                    .Where(c => !c.Association.IsRequiredCollection)
                    .SelectMany(c => c.ItemType.References.Where(r => r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();
                
                if (association == null)
                {
                    Assert.Inconclusive("Unable to find a required reference on a optional collection for testing.");
                }
                
                association.IsSoftDependency.ShouldBe(true);
            }
            
            [Assert]
            public void Should_indicate_that_an_optional_reference_on_an_item_in_a_required_collection_IS_a_soft_dependency()
            {
                var association = _resourceModel.GetAllResources()
                    .SelectMany(res => res.Collections)
                    .Where(c => c.Association.IsRequiredCollection)
                    .SelectMany(c => c.ItemType.References.Where(r => !r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();
                
                if (association == null)
                {
                    Assert.Inconclusive("Unable to find an optional reference on a required collection for testing.");
                }

                association.IsSoftDependency.ShouldBe(true);
            }

            [Assert]
            public void Should_indicate_that_a_required_reference_on_an_item_in_a_required_collection_IS_NOT_a_soft_dependency()
            {
                var association = _resourceModel.GetAllResources()
                    .SelectMany(res => res.Collections)
                    .Where(c => c.Association.IsRequiredCollection)
                    .SelectMany(c => c.ItemType.References.Where(r => r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();

                if (association == null)
                {
                    Assert.Inconclusive("Unable to find a required reference on a required collection for testing.");
                }

                association.IsSoftDependency.ShouldBe(false);
            }

            [Assert]
            public void Should_indicate_that_all_optional_references_on_embedded_objects_ARE_soft_dependencies()
            {
                var associations = _resourceModel.GetAllResources()
                    .SelectMany(res => res.EmbeddedObjects)
                    // .Where(eo => eo.Association.IsRequired)
                    .SelectMany(eo => eo.ObjectType.References.Where(r => !r.IsRequired))
                    .Select(r => r.Association)
                    .ToList();

                if (!associations.Any())
                {
                    Assert.Inconclusive("Unable to find an optional reference on an embedded object for testing.");
                }
                
                associations.All(a => a.IsSoftDependency).ShouldBe(true);
            }

            [Assert]
            public void Should_indicate_that_a_required_reference_on_a_required_embedded_object_IS_NOT_a_soft_dependency()
            {
                var association = _resourceModel.GetAllResources()
                    .SelectMany(res => res.EmbeddedObjects)
                    .Where(eo => eo.Association.IsRequired)
                    .SelectMany(eo => eo.ObjectType.References.Where(r => r.IsRequired))
                    .Select(r => r.Association)
                    .FirstOrDefault();

                if (association == null)
                {
                    Assert.Inconclusive("Unable to find a required reference on a required embedded object for testing.");
                }
                
                association.IsSoftDependency.ShouldBe(false);
            }
        }

        private static EP CreateInt32Property(string name)
        {
            return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null);
        }

        private static EP CreateIdentifyingInt32Property(string name)
        {
            return new EntityPropertyDefinition(name, new PropertyType(DbType.Int32), null, isIdentifying: true);
        }
    }

    static class ListExtensions
    {
        private static readonly ConcurrentDictionary<IEnumerable, List<Tuple<string, string>>> _itemsRemovedByList 
            = new ConcurrentDictionary<IEnumerable, List<Tuple<string,string>>>();
        
        static object locker = new object();
        
        public static List<T> Remove<T>(this List<T> list, IEnumerable<T> items, string description)
        {
            lock (locker)
            {    
                var trackingList = _itemsRemovedByList.GetOrAdd(list, x => new List<Tuple<string, string>>());

                foreach (T item in items.ToList())
                {
                    if (!list.Remove(item))
                    {
                        var trackedItems = trackingList.Where(x => x.Item1 == item.ToString()).ToArray();

                        if (trackedItems.Length > 1)
                        {
                            throw new Exception(
                                $"Multiple items matched on remove: {string.Join(", ", trackedItems.Select(x => x.Item1))}");
                        }

                        var trackedItem = trackedItems.Single();
                        
                        Console.WriteLine($"'{description}' is covering '{item}', but it was already covered by '{trackedItem.Item2}'.");
                    }
                    else
                    {
                        trackingList.Add(Tuple.Create(item.ToString(), description));
                    }
                }
    
                return list;
            }
        }
    }
}
