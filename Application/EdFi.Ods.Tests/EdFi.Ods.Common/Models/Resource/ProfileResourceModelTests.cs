// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ProfileResourceModelTests
    {
        private static ResourceModel GetTestResourceModel()
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
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date), null, false),
                        new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid), null, false)
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

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity2",
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("StringProperty1", new PropertyType(DbType.String), null, false),
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date), null, false),
                        new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid), null, false)
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity2"), new FullName[0]));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity3",
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("StringProperty1", new PropertyType(DbType.String), null, false),
                        new EntityPropertyDefinition("DateProperty1", new PropertyType(DbType.Date), null, false),
                        new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid), null, false)
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity3"), new FullName[0]));

            domainModelBuilder.AddSchema(new SchemaDefinition("SchemaName", "schema1"));

            var resourceModel = new ResourceModel(domainModelBuilder.Build());

            return resourceModel;
        }

        public class When_creating_a_Profile_resource_model_from_a_Profile_definition_with_3_resources_with_content_types_of_Read_ReadWrite_and_Write
            : TestFixtureBase
        {
            private ProfileResourceModel _actualProfileResourceModel;

            protected override void Act()
            {
                var profileDefinition = XElement.Parse(
                    @"
<Profile name='Profile1'>
    <Resource name='TestEntity1' logicalSchema='SchemaName'>
        <ReadContentType memberSelection='IncludeOnly'>
            <Property name='StringProperty1' />
        </ReadContentType>
        <WriteContentType memberSelection='IncludeOnly'>
            <Property name='DateProperty1' />
        </WriteContentType>
    </Resource>
    <Resource name='TestEntity2' logicalSchema='SchemaName'>
        <ReadContentType memberSelection='IncludeOnly'>
            <Property name='StringProperty1' />
        </ReadContentType>
    </Resource>
    <Resource name='TestEntity3' logicalSchema='SchemaName'>
        <WriteContentType memberSelection='IncludeOnly'>
            <Property name='DateProperty1' />
        </WriteContentType>
    </Resource>
</Profile>");

                // Execute code under test
                _actualProfileResourceModel = new ProfileResourceModel(GetTestResourceModel(), profileDefinition);
            }

            [Assert]
            public void Should_create_a_ProfileResourceModel_with_3_resources()
            {
                Assert.That(_actualProfileResourceModel.ResourceByName, Has.Count.EqualTo(3));
            }

            [Assert]
            public void
                Should_create_a_ProfileResourceContentTypes_with_both_Readable_and_Writable_resources_for_the_Resource_definition_with_both_Read_and_Write_content_types()
            {
                var fullName = new FullName("schema1", "TestEntity1");
                var actualProfileResourceContentTypes = _actualProfileResourceModel.ResourceByName[fullName];

                var rr = actualProfileResourceContentTypes.Readable;
                IReadOnlyDictionary<string, ResourceProperty> ss = rr.PropertyByName;
                var ww = actualProfileResourceContentTypes.Writable;

                Assert.That(actualProfileResourceContentTypes.Readable, Is.Not.Null);

                Assert.That(
                    actualProfileResourceContentTypes.Readable.PropertyByName.Keys,
                    Is.EquivalentTo(
                        new[]
                        {
                            "Id", "KeyProperty1", "StringProperty1"
                        }));

                Assert.That(actualProfileResourceContentTypes.Writable, Is.Not.Null);

                Assert.That(
                    actualProfileResourceContentTypes.Writable.PropertyByName.Keys,
                    Is.EquivalentTo(
                        new[]
                        {
                            "Id", "KeyProperty1", "DateProperty1"
                        }));
            }

            [Assert]
            public void
                Should_create_a_ProfileResourceContentTypes_with_just_a_Readable_resource_for_the_Resource_definition_with_just_a_Read_content_type()
            {
                var fullName = new FullName("schema1", "TestEntity2");
                var actualProfileResourceContentTypes = _actualProfileResourceModel.ResourceByName[fullName];

                Assert.That(actualProfileResourceContentTypes.Readable, Is.Not.Null);

                Assert.That(
                    actualProfileResourceContentTypes.Readable.PropertyByName.Keys,
                    Is.EquivalentTo(
                        new[]
                        {
                            "Id", "KeyProperty1", "StringProperty1"
                        }));

                Assert.That(actualProfileResourceContentTypes.Writable, Is.Null);
            }

            [Assert]
            public void
                Should_create_a_ProfileResourceContentTypes_with_just_a_Writable_resource_for_the_Resource_definition_with_just_a_Write_content_type()
            {
                var fullName = new FullName("schema1", "TestEntity3");
                var actualProfileResourceContentTypes = _actualProfileResourceModel.ResourceByName[fullName];

                Assert.That(actualProfileResourceContentTypes.Readable, Is.Null);

                Assert.That(actualProfileResourceContentTypes.Writable, Is.Not.Null);

                Assert.That(
                    actualProfileResourceContentTypes.Writable.PropertyByName.Keys,
                    Is.EquivalentTo(
                        new[]
                        {
                            "Id", "KeyProperty1", "DateProperty1"
                        }));
            }

            [Assert]
            public void Should_include_Id_in_all_profiles_even_when_it_is_not_in_the_definition()
            {
                var fullName = new FullName("schema1", "TestEntity1");
                var fullName1 = new FullName("schema1", "TestEntity2");
                var fullName2 = new FullName("schema1", "TestEntity3");

                var actualProfileResourceContentTypes1 = _actualProfileResourceModel.ResourceByName[fullName];
                Assert.That(actualProfileResourceContentTypes1.Readable.PropertyByName.Keys, Contains.Item("Id"));
                Assert.That(actualProfileResourceContentTypes1.Writable.PropertyByName.Keys, Contains.Item("Id"));

                var actualProfileResourceContentTypes2 = _actualProfileResourceModel.ResourceByName[fullName1];
                Assert.That(actualProfileResourceContentTypes2.Readable.PropertyByName.Keys, Contains.Item("Id"));

                var actualProfileResourceContentTypes3 = _actualProfileResourceModel.ResourceByName[fullName2];
                Assert.That(actualProfileResourceContentTypes3.Writable.PropertyByName.Keys, Contains.Item("Id"));
            }
        }

        public class
            When_creating_a_Profile_resource_model_from_a_Profile_definition_with_implicit_aggregate_extensions_using_exclude_only_member_selection
            : TestFixtureBase
        {
            private XElement _profileDefinition;
            private ResourceModel _resourceModel;
            private ProfileResourceModel _actualProfileResourceModel;
            private global::EdFi.Ods.Common.Models.Resource.Resource _student;

            protected override void Arrange()
            {
                _profileDefinition = XElement.Parse(
                    @"
<Profile name='Profile1'>
    <Resource name='Student' logicalSchema='Ed-Fi'>
        <ReadContentType memberSelection='IncludeOnly'>
            <Extension name='Sample' memberSelection='IncludeOnly' logicalSchema='Sample'>
                <Property name='StudentPetPreference' memberSelection='ExcludeOnly'>
                    <Property name='MinimumWeight'/>
                </Property>
                <Collection name='StudentPets' memberSelection='ExcludeOnly'>
                    <Property name='IsFixed'/>
                </Collection>
            </Extension>
        </ReadContentType>
    </Resource>
</Profile>");

                _resourceModel = new DomainModelProvider(DomainModelDefinitionsProviderHelper.DefinitionProviders)
                                .GetDomainModel()
                                .ResourceModel;
            }

            protected override void Act()
            {
                _actualProfileResourceModel = new ProfileResourceModel(_resourceModel, _profileDefinition);
                _student = _actualProfileResourceModel.GetResourceByName(new FullName("edfi", "Student"));
            }

            [Assert]
            public void Should_have_a_sample_extension()
            {
                Assert.That(_student.ExtensionByName.Keys, Has.Member("Sample"));
            }

            [Assert]
            public void Should_have_a_student_pet_preference_embedded_object()
            {
                var extension = _student.ExtensionByName["Sample"]
                                        .ObjectType;

                Assert.That(extension.EmbeddedObjectByName.Keys, Has.Member("StudentPetPreference"));
            }

            [Assert]
            public void Should_have_a_student_pet_preference_embedded_object_without_a_minimum_weight_property()
            {
                var minimumWeightProperty = _student
                                           .ExtensionByName["Sample"]
                                           .ObjectType
                                           .EmbeddedObjectByName["StudentPetPreference"]
                                           .ObjectType
                                           .Properties.All(p => p.PropertyName == "MinimumWeight");

                Assert.That(minimumWeightProperty, Is.False);
            }

            [Assert]
            public void Should_have_a_student_pet_collection()
            {
                var extension = _student.ExtensionByName["Sample"]
                                        .ObjectType;

                Assert.That(extension.CollectionByName.Keys, Has.Member("StudentPets"));
            }

            [Assert]
            public void Should_have_a_student_pet_collection_without_an_is_fixed_property()
            {
                var isFixedProperties = _student
                                       .ExtensionByName["Sample"]
                                       .ObjectType
                                       .CollectionByName["StudentPets"]
                                       .ItemType
                                       .Properties.All(p => p.PropertyName == "IsFixed");

                Assert.That(isFixedProperties, Is.False);
            }
        }

        public class
            When_creating_a_Profile_resource_model_from_a_Profile_definition_with_implicit_aggregate_extensions_using_include_only_member_selection
            : TestFixtureBase
        {
            private XElement _profileDefinition;
            private ResourceModel _resourceModel;
            private ProfileResourceModel _actualProfileResourceModel;
            private global::EdFi.Ods.Common.Models.Resource.Resource _student;

            protected override void Arrange()
            {
                _profileDefinition = XElement.Parse(
                    @"
<Profile name='Profile1'>
    <Resource name='Student' logicalSchema='Ed-Fi'>
        <ReadContentType memberSelection='IncludeOnly'>
            <Extension name='Sample' memberSelection='IncludeOnly' logicalSchema='Sample'>
                <Property name='StudentPetPreference' memberSelection='IncludeOnly'>
                    <Property name='MinimumWeight'/>
                </Property>
                <Collection name='StudentPets' memberSelection='IncludeOnly'>
                    <Property name='IsFixed'/>
                </Collection>
            </Extension>
        </ReadContentType>
    </Resource>
</Profile>");

                _resourceModel = new DomainModelProvider(DomainModelDefinitionsProviderHelper.DefinitionProviders)
                                .GetDomainModel()
                                .ResourceModel;
            }

            protected override void Act()
            {
                _actualProfileResourceModel = new ProfileResourceModel(_resourceModel, _profileDefinition);
                _student = _actualProfileResourceModel.GetResourceByName(new FullName("edfi", "Student"));
            }

            [Assert]
            public void Should_have_a_sample_extension()
            {
                Assert.That(_student.ExtensionByName.Keys, Has.Member("Sample"));
            }

            [Assert]
            public void Should_have_a_student_pet_preference_embedded_object()
            {
                var extension = _student.ExtensionByName["Sample"]
                                        .ObjectType;

                Assert.That(extension.EmbeddedObjectByName.Keys, Has.Member("StudentPetPreference"));
            }

            [Assert]
            public void Should_have_a_student_pet_preference_embedded_object_with_1_property()
            {
                var embeddedObject = _student
                                    .ExtensionByName["Sample"]
                                    .ObjectType
                                    .EmbeddedObjectByName["StudentPetPreference"]
                                    .ObjectType;

                Assert.That(embeddedObject.Properties, Has.Count.EqualTo(1));
            }

            [Assert]
            public void Should_have_a_student_pet_preference_embedded_object_with_a_minimum_weight_property()
            {
                var minimumWeightProperties = _student
                                             .ExtensionByName["Sample"]
                                             .ObjectType
                                             .EmbeddedObjectByName["StudentPetPreference"]
                                             .ObjectType
                                             .Properties.Any(p => p.PropertyName == "MinimumWeight");

                Assert.That(minimumWeightProperties, Is.True);
            }

            [Assert]
            public void Should_have_a_student_pet_collection()
            {
                var extension = _student.ExtensionByName["Sample"]
                                        .ObjectType;

                Assert.That(extension.CollectionByName.Keys, Has.Member("StudentPets"));
            }

            [Assert]
            public void Should_have_a_student_pet_collection_with_2_properties()
            {
                var collection = _student
                                .ExtensionByName["Sample"]
                                .ObjectType
                                .CollectionByName["StudentPets"]
                                .ItemType;

                // There should be 2 properties, IsFixed as it is defined in the profile
                // and PetName as it is part of the identifier for the StudentPet
                Assert.That(collection.Properties, Has.Count.EqualTo(2));
            }

            public void Should_have_a_student_pet_collection_with_an_is_fixed_property()
            {
                var isFixedProperties = _student
                                       .ExtensionByName["Sample"]
                                       .ObjectType
                                       .CollectionByName["StudentPets"]
                                       .ItemType
                                       .Properties.Any(p => p.PropertyName == "IsFixed");

                Assert.That(isFixedProperties, Is.True);
            }
        }
    }
}
