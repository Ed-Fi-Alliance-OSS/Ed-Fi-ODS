﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;
using Newtonsoft.Json;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Factories
{
    [TestFixture]
    public class OpenApiMetadataDocumentFactoryTests
    {
        protected static IOpenApiUpconversionProvider OpenApiV3UpconversionProvider = A.Fake<IOpenApiUpconversionProvider>();
        
        private static readonly IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider = A.Fake<IResourceIdentificationCodePropertiesProvider>();

        protected static IResourceModelProvider
            ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider
            SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public class When_creating_a_openapimetadata_document_for_list_of_resources_for_a_single_instance_ods : TestFixtureBase
        {
            private IOpenApiMetadataResourceStrategy _stubbedOpenApiMetadataResourceStrategy;
            private string _actualJson;
            private OpenApiMetadataDocument _openApiMetadataDoc;
            private OpenApiMetadataDocumentContext _openApiMetadataDocumentContext;
            private IOpenApiMetadataDocumentFactory _openApiMetadataDocumentFactory;

            protected override void Arrange()
            {
                _openApiMetadataDocumentContext = DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext;

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                var openApiMetadataResources = _openApiMetadataDocumentContext.ResourceModel.GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _stubbedOpenApiMetadataResourceStrategy = Stub<IOpenApiMetadataResourceStrategy>();

                A.CallTo(() => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(A<OpenApiMetadataDocumentContext>._))
                    .Returns(openApiMetadataResources);

                var defaultPageSizeLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));
                _openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSizeLimitProvider, OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());
            }

            protected override void Act()
            {
                _actualJson = _openApiMetadataDocumentFactory
                    .Create(_stubbedOpenApiMetadataResourceStrategy, _openApiMetadataDocumentContext, OpenApiSpecVersion.OpenApi2_0);

                _openApiMetadataDoc = JsonConvert.DeserializeObject<OpenApiMetadataDocument>(
                    _actualJson,
                    new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
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
                A.CallTo(() => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(_openApiMetadataDocumentContext))
                    .MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_deserialize_into_a_openapimetadata_document()
            {
                Assert.That(_openApiMetadataDoc, Is.Not.Null);
            }

            [Assert]
            public void Should_set_info()
            {
                Assert.That(_openApiMetadataDoc.info, Is.Not.Null);
            }

            [Assert]
            public void Should_set_securityDefinitions()
            {
                Assert.That(_openApiMetadataDoc.securityDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_security()
            {
                Assert.That(_openApiMetadataDoc.security, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_tags()
            {
                Assert.That(_openApiMetadataDoc.tags, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_paths()
            {
                Assert.That(_openApiMetadataDoc.paths, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_definitions()
            {
                Assert.That(_openApiMetadataDoc.definitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_parameters()
            {
                Assert.That(_openApiMetadataDoc.parameters, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_responses()
            {
                Assert.That(_openApiMetadataDoc.responses, Is.Not.Empty);
            }
        }

        public class When_creating_a_openapimetadata_document_for_list_of_resources_for_a_year_specific_ods : TestFixtureBase
        {
            private IOpenApiMetadataResourceStrategy _stubbedOpenApiMetadataResourceStrategy;
            private string _actualJson;
            private OpenApiMetadataDocument _openApiMetadataDoc;
            private OpenApiMetadataDocumentContext _openApiMetadataDocumentContext;
            private OpenApiMetadataDocumentFactory _openApiMetadataDocumentFactory;

            protected override void Arrange()
            {
                _openApiMetadataDocumentContext = DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext;

                var openApiMetadataResources = _openApiMetadataDocumentContext.ResourceModel.GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _stubbedOpenApiMetadataResourceStrategy = Stub<IOpenApiMetadataResourceStrategy>();

                A.CallTo(() => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(A<OpenApiMetadataDocumentContext>._))
                    .Returns(openApiMetadataResources);

                var defaultPageSizeLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                _openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSizeLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());
            }

            protected override void Act()
            {
                _actualJson = _openApiMetadataDocumentFactory.Create(
                    _stubbedOpenApiMetadataResourceStrategy, _openApiMetadataDocumentContext,
                    OpenApiSpecVersion.OpenApi2_0);

                _openApiMetadataDoc = JsonConvert.DeserializeObject<OpenApiMetadataDocument>(
                    _actualJson,
                    new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
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
                A.CallTo(
                    () => _stubbedOpenApiMetadataResourceStrategy.GetFilteredResources(
                        A<OpenApiMetadataDocumentContext>.That.IsEqualTo(_openApiMetadataDocumentContext))).MustHaveHappened();
            }

            [Assert]
            public void Should_deserialize_into_a_openapimetadata_document()
            {
                Assert.That(_openApiMetadataDoc, Is.Not.Null);
            }

            [Assert]
            public void Should_set_info()
            {
                Assert.That(_openApiMetadataDoc.info, Is.Not.Null);
            }

            [Assert]
            public void Should_set_securityDefinitions()
            {
                Assert.That(_openApiMetadataDoc.securityDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_security()
            {
                Assert.That(_openApiMetadataDoc.security, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_tags()
            {
                Assert.That(_openApiMetadataDoc.tags, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_paths()
            {
                Assert.That(_openApiMetadataDoc.paths, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_definitions()
            {
                Assert.That(_openApiMetadataDoc.definitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_parameters()
            {
                Assert.That(_openApiMetadataDoc.parameters, Is.Not.Empty);
            }

            [Assert]
            public void Should_set_responses()
            {
                Assert.That(_openApiMetadataDoc.responses, Is.Not.Empty);
            }
        }
    }
}
