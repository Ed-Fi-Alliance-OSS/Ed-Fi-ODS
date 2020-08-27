// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DomainModelBuilderTests
    {
        public class When_an_aggregate_is_built_with_missing_members : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "TheAggregate"),
                        new[]
                        {
                            new FullName("schema", "Entity1"), new FullName("schema", "Entity2")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "TheAggregate",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Entity1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                var model = builder.Build();
            }

            [Assert]
            public void Should_throw_an_exception_with_a_message_identifying_the_missing_entity()
            {
                ActualException.MessageShouldContain("could not be found");
                ActualException.MessageShouldContain("schema.Entity2");
            }
        }

        public class When_attempting_to_add_the_same_entity_to_multiple_aggregates : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate1"),
                        new[]
                        {
                            new FullName("schema", "Entity1"), new FullName("schema", "Entity2")
                        }));

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate2"),
                        new[]
                        {
                            new FullName("schema", "Entity2")
                        }));
            }

            [Assert]
            public void Should_indicate_that_the_entity_has_already_been_added()
            {
                ActualException.MessageShouldContain("key has already been added");
            }
        }

        public class When_an_entity_is_added_but_is_not_part_of_any_aggregate : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate1"),
                        new[]
                        {
                            new FullName("schema", "Entity1")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Aggregate1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Entity1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Entity2",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                var model = builder.Build();
            }

            [Assert]
            public void Should_indicate_that_the_entity_has_not_been_assigned_to_any_aggregate()
            {
                ActualException.MessageShouldContain("schema.Entity2");
                ActualException.MessageShouldContain("not assigned to any aggregate");
            }
        }

        public class When_an_association_is_added_for_which_the_target_entity_does_not_exist
            : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate1"),
                        new[]
                        {
                            new FullName("schema", "SourceEntity")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Aggregate1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "SourceEntity",
                        new[]
                        {
                            CreateInt32Property()
                        },
                        new EntityIdentifierDefinition[0]));

                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "association1"),
                        Cardinality.OneToZeroOrMore,
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
                        false));

                var model = builder.Build();
            }

            private static EntityPropertyDefinition CreateInt32Property()
            {
                return new EntityPropertyDefinition(
                    "Property1",
                    new PropertyType(DbType.Int32),
                    null);
            }

            [Assert]
            public void Should_indicate_that_the_secondary_entity_of_the_association_does_not_exist()
            {
                ActualException.MessageShouldContain("schema.TargetEntity");
                ActualException.MessageShouldContain("not found");
            }
        }

        public class When_an_association_is_added_for_which_the_source_entity_does_not_exist
            : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate1"),
                        new[]
                        {
                            new FullName("schema", "TargetEntity")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Aggregate1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "TargetEntity",
                        new[]
                        {
                            CreateInt32Property()
                        },
                        new EntityIdentifierDefinition[0]));

                builder.AddAssociation(
                    new AssociationDefinition(
                        new FullName("schema", "association1"),
                        Cardinality.OneToZeroOrMore,
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
                        false));

                var model = builder.Build();
            }

            private static EntityPropertyDefinition CreateInt32Property()
            {
                return new EntityPropertyDefinition(
                    "Property1",
                    new PropertyType(DbType.Int32),
                    null);
            }

            [Assert]
            public void Should_indicate_that_the_primary_entity_of_the_association_does_not_exist()
            {
                ActualException.MessageShouldContain("primary");
                ActualException.MessageShouldContain("schema.SourceEntity");
                ActualException.MessageShouldContain("could not be found");
            }
        }

        public class When_an_entity_is_added_with_auth_as_the_schema : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddAggregate(
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate1"),
                        new[]
                        {
                            new FullName(SystemConventions.AuthSchema, "Entity1")
                        }));

                builder.AddEntity(
                    new EntityDefinition(
                        "schema",
                        "Aggregate1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                builder.AddEntity(
                    new EntityDefinition(
                        SystemConventions.AuthSchema,
                        "Entity1",
                        new EntityPropertyDefinition[0],
                        new EntityIdentifierDefinition[0]));

                var model = builder.Build();
            }

            [Assert]
            public void Should_indicate_that_the_reserved_auth_schema_was_used_by_the_entity()
            {
                ActualException.MessageShouldContain(
                    $"Entity 'auth.Entity1' uses the reserved schema '{SystemConventions.AuthSchema}'.");
            }
        }

        public class When_a_schema_is_added_using_the_reserved_physical_name_auth : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(
                    new SchemaDefinition("TestLogicalName", SystemConventions.AuthSchema));

                builder.Build();
            }

            [Assert]
            public void Should_indicate_that_auth_is_a_reserved_physical_schema_name()
            {
                Assert.That(ActualException, Is.Not.Null);

                ActualException.MessageShouldContain(
                    $"Schema '{SystemConventions.AuthSchema}' is reserved for system use.");
            }
        }

        public class When_the_domainModel_has_auth_as_schema_logicalName : TestFixtureBase
        {
            private DomainModel _model;

            protected override void Act()
            {
                var builder = new DomainModelBuilder();

                builder.AddSchema(
                    new SchemaDefinition(SystemConventions.AuthSchema, "TestPhysicalName"));

                _model = builder.Build();
            }

            [Assert]
            public void Should_indicate_that_domainModel_schema_logicalName_is_auth()
            {
                Assert.That(_model, Is.Not.Null);
                Assert.That(ActualException, Is.Null);
            }
        }
    }
}
