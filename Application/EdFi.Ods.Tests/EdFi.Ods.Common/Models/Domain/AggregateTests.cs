// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_requesting_the_AggregateRoot_entity : TestFixtureBase
    {
        private DomainModel _domainModel;

        protected override void Act()
        {
            var domainModelDefinitions = new DomainModelDefinitions(
                new SchemaDefinition("schema", "schema"),
                new[]
                {
                    new AggregateDefinition(
                        new FullName("schema", "Aggregate"),
                        new[]
                        {
                            new FullName("schema", "AChild")
                        })
                },
                new[]
                {
                    new EntityDefinition("schema", "Aggregate", Array.Empty<EntityPropertyDefinition>(), Array.Empty<EntityIdentifierDefinition>()),
                    new EntityDefinition("schema", "AChild", Array.Empty<EntityPropertyDefinition>(), Array.Empty<EntityIdentifierDefinition>())
                },
                Array.Empty<AssociationDefinition>(),
                Array.Empty<AggregateExtensionDefinition>());

            var builder = new DomainModelBuilder(
                new[]
                {
                    domainModelDefinitions
                });

            _domainModel = builder.Build();
        }

        [Assert]
        public void Should_return_the_aggregate_root_entity_as_the_AggregateRoot()
        {
            var aggregate = _domainModel.AggregateByName[new FullName("schema", "Aggregate")];

            Assert.That(aggregate.AggregateRoot.FullName, Is.EqualTo(new FullName("schema", "Aggregate")));
        }
    }
}