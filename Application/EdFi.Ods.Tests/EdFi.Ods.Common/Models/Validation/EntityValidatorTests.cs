// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Validation
{
    public class EntityValidatorTests
    {
        public class When_building_a_domain_model_with_an_entity_using_an_undefined_schema : LegacyTestFixtureBase
        {
            private DomainModelBuilder _domainModelBuilder;

            protected override void Arrange()
            {
                _domainModelBuilder = CreateFaultyDomainModel();
            }

            protected override void Act()
            {
                var domainModel = _domainModelBuilder.Build();
            }

            private static DomainModelBuilder CreateFaultyDomainModel()
            {
                var entityDefinitions = new[]
                                        {
                                            new EntityDefinition(
                                                "DefinedSchema",
                                                "RootEntity",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                },
                                                new[]
                                                {
                                                    new EntityIdentifierDefinition(
                                                        "PK",
                                                        new[]
                                                        {
                                                            "KeyProperty1", "KeyProperty2"
                                                        },
                                                        isPrimary: true)
                                                },
                                                true),

                                            // The line that follows is causing the failure.  The 1st value should be "schema1", not "schema2"
                                            new EntityDefinition(
                                                "UndefinedSchema",
                                                "ChildEntity",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                },
                                                new[]
                                                {
                                                    new EntityIdentifierDefinition(
                                                        "PK",
                                                        new[]
                                                        {
                                                            "KeyProperty1", "KeyProperty2"
                                                        },
                                                        isPrimary: true)
                                                },
                                                true)
                                        };

                var associationDefinitions = new AssociationDefinition[0];

                var aggregateDefinitions = new[]
                                           {
                                               new AggregateDefinition(
                                                   new FullName("DefinedSchema", "RootEntity"),
                                                   new[]
                                                   {
                                                       new FullName("UndefinedSchema", "ChildEntity")
                                                   })
                                           };

                var schemaDefinition = new SchemaDefinition("logicalName", "DefinedSchema");

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggregateDefinitions,
                    entityDefinitions,
                    associationDefinitions);

                var domainModelDefinitionsProvider = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

                domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                              .Return(modelDefinitions);

                DomainModelBuilder builder = new DomainModelBuilder();

                builder.AddDomainModelDefinitionsList(
                    new List<DomainModelDefinitions>
                    {
                        domainModelDefinitionsProvider.GetDomainModelDefinitions()
                    });

                return builder;
            }

            [Test]
            public void Should_indicate_that_the_entity_uses_an_undefined_schema()
            {
                Assert.That(ActualException, Is.Not.Null);
                ActualException.MessageShouldContain("Entity 'UndefinedSchema.ChildEntity' uses an undefined schema.");
            }
        }

        public class When_building_a_domain_model_with_all_entities_using_defined_schemas : LegacyTestFixtureBase
        {
            private DomainModelBuilder _domainModelBuilder;
            private DomainModel _domainModel;

            protected override void Arrange()
            {
                _domainModelBuilder = CreateValidDomainModel();
            }

            protected override void Act()
            {
                _domainModel = _domainModelBuilder.Build();
            }

            private static DomainModelBuilder CreateValidDomainModel()
            {
                var entityDefinitions = new[]
                                        {
                                            new EntityDefinition(
                                                "DefinedSchema",
                                                "RootEntity",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                },
                                                new[]
                                                {
                                                    new EntityIdentifierDefinition(
                                                        "PK",
                                                        new[]
                                                        {
                                                            "KeyProperty1", "KeyProperty2"
                                                        },
                                                        isPrimary: true)
                                                },
                                                true),

                                            // The line that follows is causing the failure.  The 1st value should be "schema1", not "schema2"
                                            new EntityDefinition(
                                                "DefinedSchema",
                                                "ChildEntity",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                },
                                                new[]
                                                {
                                                    new EntityIdentifierDefinition(
                                                        "PK",
                                                        new[]
                                                        {
                                                            "KeyProperty1", "KeyProperty2"
                                                        },
                                                        isPrimary: true)
                                                },
                                                true)
                                        };

                var associationDefinitions = new AssociationDefinition[0];

                var aggregateDefinitions = new[]
                                           {
                                               new AggregateDefinition(
                                                   new FullName("DefinedSchema", "RootEntity"),
                                                   new[]
                                                   {
                                                       new FullName("DefinedSchema", "ChildEntity")
                                                   })
                                           };

                var schemaDefinition = new SchemaDefinition("logicalName", "DefinedSchema");

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggregateDefinitions,
                    entityDefinitions,
                    associationDefinitions);

                var domainModelDefinitionsProvider = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

                domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                              .Return(modelDefinitions);

                DomainModelBuilder builder = new DomainModelBuilder();

                builder.AddDomainModelDefinitionsList(
                    new List<DomainModelDefinitions>
                    {
                        domainModelDefinitionsProvider.GetDomainModelDefinitions()
                    });

                return builder;
            }

            [Test]
            public void Should_build_the_domain_model_without_validation_errors()
            {
                Assert.That(ActualException, Is.Null);
            }
        }
    }
}
