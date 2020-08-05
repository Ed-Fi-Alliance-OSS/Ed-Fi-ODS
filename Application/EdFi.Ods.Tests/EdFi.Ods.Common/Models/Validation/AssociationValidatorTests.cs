// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Validation
{
    public class AssociationValidatorTests
    {
        public class When_AssociationValidator_detects_a_faulty_association_schema : LegacyTestFixtureBase
        {
            private DomainModelBuilder domainModelBuilder;

            protected override void Arrange()
            {
                domainModelBuilder = CreateFaultyDomainModel();
            }

            protected override void Act()
            {
                var domainModel = domainModelBuilder.Build();
            }

            private static DomainModelBuilder CreateFaultyDomainModel()
            {
                var entityDefinitions = new[]
                                        {
                                            new EntityDefinition(
                                                "schema1",
                                                "CoreEntity",
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
                                            new EntityDefinition(
                                                "schema1",
                                                "Collection1Item",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                                                    new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.Int32), null, true)
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

                var associationDefinitions = new[]
                                             {
                                                 new AssociationDefinition(

                                                     //  The line that follows contains bad data
                                                     new FullName("UndefinedSchemaName", "FK_CoreEntityCollection"),
                                                     Cardinality.OneToZeroOrMore,
                                                     new FullName("schema1", "CoreEntity"),
                                                     new[]
                                                     {
                                                         new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                     },
                                                     new FullName("schema1", "Collection1Item"),
                                                     new[]
                                                     {
                                                         new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                     },
                                                     isIdentifying: true,
                                                     isRequired: true)
                                             };

                var aggredateDefinitions = new[]
                                           {
                                               new AggregateDefinition(
                                                   new FullName("schema1", "CoreEntity"),
                                                   new[]
                                                   {
                                                       new FullName("schema1", "Collection1Item")
                                                   })
                                           };

                //  schema names do not match the names on the AggregateDefinition
                var schemaDefinition = new SchemaDefinition("logicalName", "schema1");

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggredateDefinitions,
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
            public void Ensure_that_the_ActualException_contains_error_text()
            {
                Assert.That(ActualException, Is.Not.Null);
                Assert.That(ActualException.Message.Contains("is not located in the Schema-Definitions"), Is.True);
            }
        }

        public class When_AssociationValidator_detects_a_good_association_schema : LegacyTestFixtureBase
        {
            private DomainModel _domainModel;
            private DomainModelBuilder domainModelBuilder;

            protected override void Arrange()
            {
                domainModelBuilder = CreateValidDomainModel();
            }

            protected override void Act()
            {
                _domainModel = domainModelBuilder.Build();
            }

            private static DomainModelBuilder CreateValidDomainModel()
            {
                var entityDefinitions = new[]
                                        {
                                            new EntityDefinition(
                                                "schema1",
                                                "CoreEntity",
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
                                            new EntityDefinition(
                                                "schema1",
                                                "Collection1Item",
                                                new[]
                                                {
                                                    new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                                                    new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.Int32), null, true)
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

                var associationDefinitions = new[]
                                             {
                                                 new AssociationDefinition(
                                                     new FullName("schema1", "FK_CoreEntityCollection"),
                                                     Cardinality.OneToZeroOrMore,
                                                     new FullName("schema1", "CoreEntity"),
                                                     new[]
                                                     {
                                                         new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                     },
                                                     new FullName("schema1", "Collection1Item"),
                                                     new[]
                                                     {
                                                         new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                     },
                                                     isIdentifying: true,
                                                     isRequired: true)
                                             };

                var aggredateDefinitions = new[]
                                           {
                                               new AggregateDefinition(
                                                   new FullName("schema1", "CoreEntity"),
                                                   new[]
                                                   {
                                                       new FullName("schema1", "Collection1Item")
                                                   })
                                           };

                //  schema names do not match the names on the AggregateDefinition
                var schemaDefinition = new SchemaDefinition("logicalName", "schema1");

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggredateDefinitions,
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
            public void Ensure_that_the_ActualException_should_be_null()
            {
                Assert.That(ActualException, Is.Null);
            }

            [Test]
            public void Ensure_that_the_domain_model_is_not_null()
            {
                Assert.That(_domainModel, Is.Not.Null);
            }
        }
    }
}
