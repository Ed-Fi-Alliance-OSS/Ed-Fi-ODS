﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common.Models
{
    public class ProfileResourceModelProviderTests
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity1"), Array.Empty<FullName>()));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity2",
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity2"), Array.Empty<FullName>()));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity3",
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

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema1", "TestEntity3"), Array.Empty<FullName>()));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema1", "schema1"));

            return new ResourceModel(domainModelBuilder.Build());
        }

        public class When_building_ProfileResourceModels_for_Profiles_by_name
            : ScenarioFor<ProfileResourceModelProvider>
        {
            private ProfileResourceModel _actualProfile1ResourceModel;
            private ProfileResourceModel _actualProfile2ResourceModel;
            private ProfileResourceModelProvider profileresourceModelProvider;
            private IResourceModelProvider resourceModelProvider;
            private IProfileMetadataProvider profileMetadaProvider;
            protected override void Arrange()
            {
                resourceModelProvider = A.Fake<IResourceModelProvider>();
                profileMetadaProvider = A.Fake<IProfileMetadataProvider>();
                A.CallTo(() => profileMetadaProvider.GetProfileDefinitionsByName())
                    .Returns(new Dictionary<string, XElement>()
                    {
                        {"Profile1", 
                        XElement.Parse(
                            @"
                            <Profile name='Profile1'>
                                <Resource name='TestEntity1' logicalSchema='schema1'>
                                    <ReadContentType memberSelection='IncludeOnly'>
                                        <Property name='StringProperty1' />
                                    </ReadContentType>
                                    <WriteContentType memberSelection='IncludeOnly'>
                                        <Property name='DateProperty1' />
                                    </WriteContentType>
                                </Resource>
                            </Profile>")},
                        {"Profile2", 
                        XElement.Parse(
                            @"
                            <Profile name='Profile2'>
                                <Resource name='TestEntity2' logicalSchema='schema1'>
                                    <ReadContentType memberSelection='IncludeOnly'>
                                        <Property name='StringProperty1' />
                                    </ReadContentType>
                                </Resource>
                                <Resource name='TestEntity3' logicalSchema='schema1'>
                                    <WriteContentType memberSelection='IncludeOnly'>
                                        <Property name='DateProperty1' />
                                    </WriteContentType>
                                </Resource>
                            </Profile>")}});

                A.CallTo(() => resourceModelProvider.GetResourceModel())
                    .Returns(GetTestResourceModel());

                var profileValidationReporter = A.Fake<IProfileValidationReporter>();

                profileresourceModelProvider = new ProfileResourceModelProvider(
                    resourceModelProvider,
                    profileMetadaProvider,
                    profileValidationReporter);
            }

            protected override void Act()
            {
                _actualProfile1ResourceModel = profileresourceModelProvider.GetProfileResourceModel("Profile1");
                _actualProfile2ResourceModel = profileresourceModelProvider.GetProfileResourceModel("Profile2");
                var ignored = profileresourceModelProvider.GetProfileResourceModel("ProfileX");
            }

            [Assert]
            public void Should_create_ProfileResourceModels_with_the_same_number_of_resources_as_is_included_in_the_Profile_definition()
            {
                Assert.That(_actualProfile1ResourceModel.ResourceByName, Has.Count.EqualTo(1));
                Assert.That(_actualProfile2ResourceModel.ResourceByName, Has.Count.EqualTo(2));
            }

            [Assert]
            public void Should_throw_an_exception_for_Profiles_that_dont_exist()
            {
                Assert.That(ActualException, Is.Not.Null);

                ActualException.ShouldBeExceptionType<KeyNotFoundException>();
            }
        }
    }
}
