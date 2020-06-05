// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using FakeItEasy;
using Newtonsoft.Json;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerDocumentFactoryTests
    {
        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class When_creating_a_swagger_document_for_list_of_resources_for_a_single_instance_ods : TestFixtureBase
        {
            private IOpenApiMetadataResourceStrategy _stubbedOpenApiMetadataResourceStrategy;
            private string _actualJson;
            private OpenApiMetadataDocument _swaggerDoc;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _swaggerDocumentContext = DomainModelDefinitionsProviderHelper.DefaultSwaggerDocumentContext;

                var swaggerResources = _swaggerDocumentContext.ResourceModel.GetAllResources()
                                                              .Select(r => new SwaggerResource(r))
                                                              .ToList();

                _stubbedOpenApiMetadataResourceStrategy = Stub<IOpenApiMetadataResourceStrategy>();

                A.CallTo(() => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(A<SwaggerDocumentContext>._))
                 .Returns(swaggerResources);
            }

            protected override void Act()
            {
                _actualJson = new SwaggerDocumentFactory(_swaggerDocumentContext)
                   .Create(_stubbedOpenApiMetadataResourceStrategy);

                _swaggerDoc = JsonConvert.DeserializeObject<OpenApiMetadataDocument>(
                    _actualJson,
                    new JsonSerializerSettings
                    {
                        MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                    });
            }

            [Assert]
            public void Should_create_the_json_document()
            {
                Assert.That(_actualJson, Is.Not.Null);
            }

            [Assert]
            public void Should_have_data_in_the_json_document()
            {
                Assert.That(_actualJson, Is.Not.Empty);
            }

            [Assert]
            public void Should_filter_the_resources()
            {
                A.CallTo(() => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(_swaggerDocumentContext)).MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_deserialize_into_a_swagger_document()
            {
                Assert.That(_swaggerDoc, Is.Not.Null);
            }

            [Assert]
            public void Should_set_info()
            {
                Assert.That(_swaggerDoc.info, Is.Not.Null);
            }

            [Assert]
            public void Should_set_securityDefinitions()
            {
                Assert.That(_swaggerDoc.securityDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_security()
            {
                Assert.That(_swaggerDoc.security, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_tags()
            {
                Assert.That(_swaggerDoc.tags, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_paths()
            {
                Assert.That(_swaggerDoc.paths, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_definitions()
            {
                Assert.That(_swaggerDoc.definitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_parameters()
            {
                Assert.That(_swaggerDoc.parameters, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_responses()
            {
                Assert.That(_swaggerDoc.responses, Is.Not.Empty);
            }
        }

        public class When_creating_a_swagger_document_for_list_of_resources_for_a_year_specific_ods : LegacyTestFixtureBase
        {
            private IOpenApiMetadataResourceStrategy _stubbedOpenApiMetadataResourceStrategy;
            private string _actualJson;
            private OpenApiMetadataDocument _swaggerDoc;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _swaggerDocumentContext = DomainModelDefinitionsProviderHelper.DefaultSwaggerDocumentContext;

                var swaggerResources = _swaggerDocumentContext.ResourceModel.GetAllResources()
                                                              .Select(r => new SwaggerResource(r))
                                                              .ToList();

                _stubbedOpenApiMetadataResourceStrategy = Stub<IOpenApiMetadataResourceStrategy>();

                _stubbedOpenApiMetadataResourceStrategy.Stub(x => x.GetFilteredResources(Arg<SwaggerDocumentContext>.Is.Anything))
                                                       .Return(swaggerResources);
            }

            protected override void Act()
            {
                _actualJson = new SwaggerDocumentFactory(_swaggerDocumentContext).Create(_stubbedOpenApiMetadataResourceStrategy);

                _swaggerDoc = JsonConvert.DeserializeObject<OpenApiMetadataDocument>(
                    _actualJson,
                    new JsonSerializerSettings
                    {
                        MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                    });
            }

            [Assert]
            public void Should_create_the_json_document()
            {
                Assert.That(_actualJson, Is.Not.Null);
            }

            [Assert]
            public void Should_have_data_in_the_json_document()
            {
                Assert.That(_actualJson, Is.Not.Empty);
            }

            [Assert]
            public void Should_filter_the_resources()
            {
                _stubbedOpenApiMetadataResourceStrategy.AssertWasCalled(
                    x => x.GetFilteredResources(Arg<SwaggerDocumentContext>.Is.Equal(_swaggerDocumentContext)),
                    x => x.Repeat.Once());
            }

            [Assert]
            public void Should_deserialize_into_a_swagger_document()
            {
                Assert.That(_swaggerDoc, Is.Not.Null);
            }

            [Assert]
            public void Should_set_info()
            {
                Assert.That(_swaggerDoc.info, Is.Not.Null);
            }

            [Assert]
            public void Should_set_securityDefinitions()
            {
                Assert.That(_swaggerDoc.securityDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_security()
            {
                Assert.That(_swaggerDoc.security, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_tags()
            {
                Assert.That(_swaggerDoc.tags, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_paths()
            {
                Assert.That(_swaggerDoc.paths, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_definitions()
            {
                Assert.That(_swaggerDoc.definitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_parameters()
            {
                Assert.That(_swaggerDoc.parameters, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_responses()
            {
                Assert.That(_swaggerDoc.responses, Is.Not.Empty);
            }
        }
    }
}
