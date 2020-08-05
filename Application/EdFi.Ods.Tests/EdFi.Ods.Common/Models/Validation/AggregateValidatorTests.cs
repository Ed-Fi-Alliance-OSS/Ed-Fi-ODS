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
    public class When_building_a_domain_model_containing_an_aggregate_using_an_undefined_schema : LegacyTestFixtureBase
    {
        private DomainModelBuilder _domainModelBuilder;

        protected override void Arrange()
        {
            _domainModelBuilder = CreateDomainModel();
        }

        protected override void Act()
        {
            var domainModel = _domainModelBuilder.Build();
        }

        private static DomainModelBuilder CreateDomainModel()
        {
            var entityDefinitions = new[]
                                    {
                                        new EntityDefinition(
                                            "UndefinedSchema",
                                            "Entity1",
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

            var associationDefinitions = new AssociationDefinition[]
                                         { };

            var aggredateDefinitions = new[]
                                       {
                                           new AggregateDefinition(
                                               new FullName("UndefinedSchema", "Entity1"),
                                               new FullName[0])
                                       };

            //  schema names do not match the names on the AggregateDefinition
            var schemaDefinition = new SchemaDefinition("logicalName", "DefinedSchema");

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
        public void Should_indicate_that_the_aggregate_uses_an_undefined_schema()
        {
            Assert.That(ActualException, Is.Not.Null);
            ActualException.MessageShouldContain("Aggregate 'UndefinedSchema.Entity1' uses an undefined schema.");
        }
    }

    public class When_building_a_domain_model_containing_an_aggregate_using_a_defined_schema : LegacyTestFixtureBase
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
                                            "DefinedSchema",
                                            "Entity1",
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

            var associationDefinitions = new AssociationDefinition[]
                                         { };

            var aggredateDefinitions = new[]
                                       {
                                           new AggregateDefinition(
                                               new FullName("DefinedSchema", "Entity1"),
                                               new FullName[]
                                               { })
                                       };

            //  schema names do not match the names on the AggregateDefinition
            var schemaDefinition = new SchemaDefinition("logicalName", "DefinedSchema");

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
        public void Should_build_the_domain_model_without_validation_errors()
        {
            Assert.That(ActualException, Is.Null);
        }
    }
}
