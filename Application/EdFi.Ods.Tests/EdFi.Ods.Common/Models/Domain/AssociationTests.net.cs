// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_building_a_model_with_associations : TestFixtureBase
    {
        private DomainModel _domainModel;

        protected override void Act()
        {
            var domainModelBuilder = new DomainModelBuilder();

            // Perform the action to be tested
            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "Parent"),
                    new[]
                    {
                        new FullName("schema", "Child")
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "Parent",
                    new[]
                    {
                        new EntityPropertyDefinition("ParentId", new PropertyType(DbType.Int32), null, isIdentifying: true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_Parent",
                            new[]
                            {
                                "ParentId"
                            })
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "Child",
                    new[]
                    {
                        new EntityPropertyDefinition("ChildId", new PropertyType(DbType.Int32), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_Child",
                            new[]
                            {
                                "ChildId"
                            })
                    }));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "FK_Test"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "Parent"),
                    new[]
                    {
                        new EntityPropertyDefinition("ParentId", new PropertyType(DbType.Int32), null)
                    },
                    new FullName("schema", "Child"),
                    new[]
                    {
                        new EntityPropertyDefinition("ParentId", new PropertyType(DbType.Int32), null)
                    },
                    isIdentifying: false,
                    isRequired: true));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            _domainModel = domainModelBuilder.Build();
        }

        [Assert]
        public void Should_assign_entity_references_to_all_primary_and_secondary_properties()
        {
            var association = _domainModel.AssociationByFullName[new FullName("schema", "FK_Test")];

            Assert.That(
                association.PrimaryEntityAssociationProperties.All(
                    p => p.Entity == _domainModel.EntityByFullName[new FullName("schema", "Parent")]),
                "Primary property's Entity reference was not set.");

            Assert.That(
                association.SecondaryEntityAssociationProperties.All(
                    p => p.Entity == _domainModel.EntityByFullName[new FullName("schema", "Child")]),
                "Secondary property's Entity reference was not set.");
        }
    }
}
