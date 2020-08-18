// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_getting_a_namespace_for_an_extension_entity : TestFixtureBase
    {
        [Assert]
        public void Should_return_the_correct_namespace_for_an_entity_and_an_extension_of_that_entity()
        {
            var domainModelBuilder = new DomainModelBuilder();

            var fullName = new FullName("edfi", "TestEntity1");
            var fullName1 = new FullName("schema2", "TestEntity1Extension");
            var associationProperty = new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true);

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    fullName.Schema,
                    fullName.Name,
                    new[]
                    {
                        associationProperty,
                        new EntityPropertyDefinition("StringProperty1", new PropertyType(DbType.String)),
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date))
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK",
                            new[]
                            {
                                "KeyProperty1"
                            },
                            isPrimary: true)
                    }));

            domainModelBuilder.AddAggregate(new AggregateDefinition(fullName, new FullName[0]));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    fullName1.Schema,
                    fullName1.Name,
                    new[]
                    {
                        associationProperty,
                        new EntityPropertyDefinition("StringProperty1", new PropertyType(DbType.String)),
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date))
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK",
                            new[]
                            {
                                "KeyProperty1"
                            },
                            isPrimary: true)
                    }));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema2", "FromCore"),
                    Cardinality.OneToOneExtension,
                    fullName,
                    new[]
                    {
                        associationProperty
                    },
                    fullName1,
                    new[]
                    {
                        associationProperty
                    },
                    true,
                    true));

            domainModelBuilder.AddSchema(new SchemaDefinition("EdFi", fullName.Schema));
            domainModelBuilder.AddSchema(new SchemaDefinition("schema2", "schema2"));

            var domainModel = domainModelBuilder.Build();

            string entityNamespace = domainModel.EntityByFullName[fullName]
                                                .AggregateNamespace(EdFiConventions.ProperCaseName);

            string entityName = domainModel.EntityByFullName[fullName]
                                           .Name;

            string entityExtensionNamespace = domainModel.EntityByFullName[fullName1]
                                                         .AggregateNamespace("TestEntity1ExtensionProperCaseName");

            string entityExtensionName = domainModel.EntityByFullName[fullName1]
                                                    .Name;

            Assert.That(
                entityNamespace.Equals($"{Namespaces.Entities.NHibernate.BaseNamespace}.{entityName}Aggregate.{EdFiConventions.ProperCaseName}"));

            Assert.That(
                entityExtensionNamespace.Equals(
                    $"{Namespaces.Entities.NHibernate.BaseNamespace}.{entityName}Aggregate.TestEntity1ExtensionProperCaseName"));
        }
    }
}
