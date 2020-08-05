// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;
using Resource_Resource = EdFi.Ods.Common.Models.Resource.Resource;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ProfileResourceContentTypesTests
    {
        private static Resource_Resource GetTestResource()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity1",
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("StringProperty1", new PropertyType(DbType.String), null, false),
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date), null, false)
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity1"), new FullName[0]));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema1", "schema1"));
            domainModelBuilder.AddSchema(new SchemaDefinition("Ed-Fi", "edfi"));

            var resourceModel = new ResourceModel(domainModelBuilder.Build());

            var resource = resourceModel.GetResourceByFullName(new FullName("schema1", "TestEntity1"));

            return resource;
        }

        public class When_creating_the_ProfileResourceContentTypes_for_a_Profile_resource_with_both_read_and_write_content_types
            : TestFixtureBase
        {
            private ProfileResourceContentTypes _actualProfileResourceContentTypes;

            protected override void Act()
            {
                var resourceDefinition = XElement.Parse(
                    @"
<Resource name='TestEntity1' logicalSchema='schema1'>
    <ReadContentType memberSelection='IncludeOnly'>
        <Property name='StringProperty1' />
    </ReadContentType>
    <WriteContentType memberSelection='IncludeOnly'>
        <Property name='DateProperty1' />
    </WriteContentType>
</Resource>");

                _actualProfileResourceContentTypes =
                    new ProfileResourceContentTypes(
                        GetTestResource(),
                        resourceDefinition);
            }

            [Assert]
            public void Should_create_a_readable_resource_with_members_matching_the_ReadContentType_in_the_definition()
            {
                Assert.That(_actualProfileResourceContentTypes.Readable, Is.Not.Null);

                var allPropertyNames = _actualProfileResourceContentTypes.Readable.PropertyByName.Keys;

                Assert.That(
                    allPropertyNames,
                    Is.EquivalentTo(
                        new[]
                        {
                            "KeyProperty1", "StringProperty1"
                        }));
            }

            [Assert]
            public void Should_create_a_writable_resource_with_members_matching_the_WriteContentType_in_the_definition()
            {
                Assert.That(_actualProfileResourceContentTypes.Writable, Is.Not.Null);

                var allPropertyNames = _actualProfileResourceContentTypes.Writable.PropertyByName.Keys;

                Assert.That(
                    allPropertyNames,
                    Is.EquivalentTo(
                        new[]
                        {
                            "KeyProperty1", "DateProperty1"
                        }));
            }
        }

        public class When_creating_the_ProfileResourceContentTypes_for_a_Profile_resource_with_only_a_read_content_type
            : TestFixtureBase
        {
            private ProfileResourceContentTypes _actualProfileResourceContentTypes;

            protected override void Act()
            {
                var resourceDefinition = XElement.Parse(
                    @"
<Resource name='TestEntity1' logicalSchema='schema1'>
    <ReadContentType memberSelection='IncludeOnly'>
        <Property name='StringProperty1' />
    </ReadContentType>
</Resource>");

                _actualProfileResourceContentTypes =
                    new ProfileResourceContentTypes(
                        GetTestResource(),
                        resourceDefinition);
            }

            [Assert]
            public void Should_create_a_readable_resource_with_members_matching_the_ReadContentType_in_the_definition()
            {
                Assert.That(_actualProfileResourceContentTypes.Readable, Is.Not.Null);

                var allPropertyNames = _actualProfileResourceContentTypes.Readable.PropertyByName.Keys;

                Assert.That(
                    allPropertyNames,
                    Is.EquivalentTo(
                        new[]
                        {
                            "KeyProperty1", "StringProperty1"
                        }));
            }

            [Assert]
            public void Should_not_create_a_writable_resource()
            {
                Assert.That(_actualProfileResourceContentTypes.Writable, Is.Null);
            }
        }

        public class When_creating_the_ProfileResourceContentTypes_for_a_Profile_resource_with_only_a_write_content_type
            : TestFixtureBase
        {
            private ProfileResourceContentTypes _actualProfileResourceContentTypes;

            protected override void Act()
            {
                var resourceDefinition = XElement.Parse(
                    @"
<Resource name='TestEntity1' logicalSchema='schema1'>
    <WriteContentType memberSelection='IncludeOnly'>
        <Property name='DateProperty1' />
    </WriteContentType>
</Resource>");

                _actualProfileResourceContentTypes =
                    new ProfileResourceContentTypes(
                        GetTestResource(),
                        resourceDefinition);
            }

            [Assert]
            public void Should_not_create_a_readable_resource()
            {
                Assert.That(_actualProfileResourceContentTypes.Readable, Is.Null);
            }

            [Assert]
            public void Should_create_a_writable_resource_with_members_matching_the_WriteContentType_in_the_definition()
            {
                Assert.That(_actualProfileResourceContentTypes.Writable, Is.Not.Null);

                var allPropertyNames = _actualProfileResourceContentTypes.Writable.PropertyByName.Keys;

                Assert.That(
                    allPropertyNames,
                    Is.EquivalentTo(
                        new[]
                        {
                            "KeyProperty1", "DateProperty1"
                        }));
            }
        }
    }
}
