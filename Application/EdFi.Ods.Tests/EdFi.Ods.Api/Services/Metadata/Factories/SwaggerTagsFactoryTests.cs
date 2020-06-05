// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerTagsFactoryTests
    {
        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class When_creating_tags_for_a_list_of_resources_using_a_single_instance_or_year_specific_ods : TestFixtureBase
        {
            private IList<Tag> _actualTags;
            private string[] _actualTagNames;

            protected override void Act()
            {
                var swaggerResources = ResourceModelProvider.GetResourceModel()
                                                            .GetAllResources()
                                                            .Select(r => new SwaggerResource(r))
                                                            .ToList();

                _actualTags = SwaggerDocumentFactoryHelper.CreateSwaggerTagsFactory(
                                                               DomainModelDefinitionsProviderHelper.DefaultSwaggerDocumentContext)
                                                          .Create(swaggerResources);

                _actualTagNames = _actualTags.Select(x => x.name)
                                             .ToArray();
            }

            [Assert]
            public void Should_create_the_tags()
            {
                Assert.That(_actualTags, Is.Not.Null);
            }

            [Assert]
            public void Should_not_be_empty()
            {
                Assert.That(_actualTags, Is.Not.Empty);
            }

            [Assert]
            public void Should_contain_a_tag_for_academicWeek()
            {
                Assert.That(_actualTagNames, Has.Member("academicWeeks"));
            }

            [Assert]
            public void Should_contain_a_tag_for_student()
            {
                Assert.That(_actualTagNames, Has.Member("students"));
            }

            [Assert]
            public void Should_contain_a_tag_for_student_characteristic_descriptor()
            {
                Assert.That(_actualTagNames, Has.Member("studentCharacteristicDescriptors"));
            }
        }
    }
}
