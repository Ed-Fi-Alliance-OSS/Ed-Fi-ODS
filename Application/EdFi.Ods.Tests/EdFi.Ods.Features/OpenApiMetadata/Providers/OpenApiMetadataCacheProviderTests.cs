//SPDX-License-Identifier: Apache-2.0
//Licensed to the Ed-Fi Alliance under one or more agreements.
//The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
//See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Composites;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Metadata.StreamProviders.Composites;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Composites.Test;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Extensions;
using EdFi.Ods.Features.IdentityManagement;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.OpenApiMetadataContentProviders;
using EdFi.Ods.Features.RouteInformations;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Providers
{
    [TestFixture]
    public class OpenApiMetadataCacheProviderTests
    {
        protected static IOpenApiUpconversionProvider OpenApiV3UpconversionProvider = A.Fake<IOpenApiUpconversionProvider>();

        protected static IDomainModelProvider DomainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;
        protected static IResourceModelProvider
            ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider
            SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;
        protected static IOpenApiContentProvider[] TestOpenApiContentProviders = { new IdentityOpenApiContentProvider(OpenApiV3UpconversionProvider) };

        private static IEnumerable<IOpenApiMetadataRouteInformation> GetTestRouteInformation()
        {
            yield return new AllOpenApiMetadataRouteInformation();
            yield return new CompositesOpenApiMetadataRouteInformation();
            yield return new ResourceTypeOpenMetadataRouteInformation();
            yield return new SchemaOpenApiMetadataRouteInformation();
            yield return new ChangeQueriesOpenApiMetadataRouteInformation();
            yield return new IdentityOpenApiMetadataRouteInformation();
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public class When_requesting_the_sdk_gen_section_from_the_cache : TestFixtureBase
        {
            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;


            protected override void Arrange()
            {
                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                var resourceModelProvider = Stub<IResourceModelProvider>();
                
                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._)).ReturnsLazily(x => x.Arguments.Get<string>(0));

                var openApiContentProviders = new List<IOpenApiContentProvider>();

                ICompositesMetadataStreamsProvider[] compositesMetadataStreamsProviders =
                    { new AppDomainEmbeddedResourcesCompositesMetadataStreamsProvider() };

                var compositesMetadataProvider = new CompositesMetadataProvider(compositesMetadataStreamsProviders);

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositesMetadataProvider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityProvider = new IdentityOpenApiContentProvider(OpenApiV3UpconversionProvider);

                openApiContentProviders.Add(identityProvider);

                openApiContentProviders.Add(compositeOpenApiContentProvider);

                openApiContentProviders.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    openApiContentProviders,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: true)
                    .ToList();
            }

            [Test]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Test]
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi3_0)))
                        .Select(
                            swaggerDocument => (Action)(() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }

            [Test]
            public void Should_contain_sdk_gen_and_extension_extensions()
            {
                Assert.That(
                    _actualMetadata.Select(x => x.Section)
                        .Distinct(),
                    Is.EquivalentTo(
                        new[]
                        {
                            "Other",
                            "SDKGen",
                            "Extensions",
                            "Composites"
                        }));
            }
        }

        public class When_requesting_the_swagger_ui_section_from_the_cache : TestFixtureBase
        {
            private ICompositesMetadataProvider _compositesMetadataProvider;
            private IProfileResourceModelProvider _profileResourceModelProvider;
            private IProfileResourceNamesProvider _profileResourceNamesProvider;
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;


            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();

                _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();

                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                A.CallTo(() => _profileResourceNamesProvider.GetProfileResourceNames())
                    .Returns(new List<ProfileAndResourceNames>());

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();

                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();
                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    TestOpenApiContentProviders,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: false)
                    .Where(x => x.Section.Equals("SwaggerUI"))
                    .ToList();
            }

            [Assert]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Assert]
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi3_0)))
                        .Select(
                            swaggerDocument =>
                                (Action)
                                (() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }
        }

        public class When_requesting_the_other_ui_section_from_the_cache : TestFixtureBase
        {
            private ICompositesMetadataProvider _compositesMetadataProvider;
            private IProfileResourceModelProvider _profileResourceModelProvider;
            private IProfileResourceNamesProvider _profileResourceNamesProvider;
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;

            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();

                _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();

                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                A.CallTo(() => _profileResourceNamesProvider.GetProfileResourceNames())
                    .Returns(new List<ProfileAndResourceNames>());

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();

                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();
                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    TestOpenApiContentProviders,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: false)
                    .Where(x => x.Section.Equals("Other"))
                    .ToList();
            }

            [Test]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Test]
            public void Should_be_a_valid_v2_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi2_0)))
                        .Select(
                            swaggerDocument => (Action)(() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }

            [Test]
            public void Should_be_a_valid_v3_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => new OpenApiStringReader().Read(m.Metadata(OpenApiSpecVersion.OpenApi3_0), out _))
                        .Select(
                            swaggerDocument => (Action)(() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }
        }

        [Ignore("These tests are failed as the profile feature is not implemented with openapi")]
        public class When_requesting_the_profiles_section_from_the_cache : TestFixtureBase
        {
            private ICompositesMetadataProvider _compositesMetadataProvider;
            private IProfileResourceModelProvider _profileResourceModelProvider;
            private IProfileResourceNamesProvider _profileResourceNamesProvider;
            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                IProfilesMetadataStreamsProvider[] profileMetadataStreamsProviders =
                {
                    new AppDomainEmbeddedResourcesProfilesMetadataStreamsProvider()
                };

                IProfileDefinitionsProvider[] profileDefinitionsProviders =
                {
                    new EmbeddedResourceProfileDefinitionsProvider(
                        new ProfileMetadataValidator(ResourceModelProvider),
                        profileMetadataStreamsProviders)
                };

                var profileResourceMetadataProvider = new ProfileMetadataProvider(
                    profileDefinitionsProviders);

                _profileResourceNamesProvider = new ProfileResourceNamesProvider(
                    profileResourceMetadataProvider);

                var profileValidationReporter = A.Fake<IProfileValidationReporter>();

                _profileResourceModelProvider = new ProfileResourceModelProvider(
                    ResourceModelProvider,
                    profileResourceMetadataProvider,
                    profileValidationReporter);

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();
                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var defaultPageSizeLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSizeLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    TestOpenApiContentProviders,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: false)
                    .Where(x => x.Section.Equals("Profiles"))
                    .ToList();
            }

            [Test]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Test]
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(
                            m => new
                            {
                                ApiContent = m,
                                SwaggerDocument = OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi3_0))
                            })
                        .Select(
                            d => (Action)(() => Assert.That(
                               d.SwaggerDocument, Is.Not.Null, $"ApiContent Name: {d.ApiContent.Name}")))
                        .ToArray());
            }

            [Test]
            public void Should_be_a_swagger_document_for_each_distinct_profile_in_the_ProfileResourceNamesProvider()
            {
                var profileNames = _profileResourceNamesProvider.GetProfileResourceNames()
                    .Select(n => n.ProfileName)
                    .Distinct();

                Assert.That(
                    _actualMetadata.Select(m => m.Name),
                    Is.EquivalentTo(profileNames));
            }
        }

        public class When_requesting_the_composites_section_from_the_cache : TestFixtureBase
        {
            private CompositesMetadataProvider _compositesMetadataProvider;
            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;


            protected override void Arrange()
            {
                ICompositesMetadataStreamsProvider[] compositesMetadataStreamsProviders =
                    { new AppDomainEmbeddedResourcesCompositesMetadataStreamsProvider() };

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                _compositesMetadataProvider = new CompositesMetadataProvider(compositesMetadataStreamsProviders);

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                _compositesMetadataProvider = new CompositesMetadataProvider(compositesMetadataStreamsProviders);

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var _resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => _resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                var openapicontentproviderlist = new List<IOpenApiContentProvider>();

                var compositemetadataprovider = new CompositesMetadataProvider(compositesMetadataStreamsProviders);

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositemetadataprovider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityprovider = new IdentityOpenApiContentProvider(OpenApiV3UpconversionProvider);

                openapicontentproviderlist.Add(identityprovider);

                openapicontentproviderlist.Add(compositeOpenApiContentProvider);

                openapicontentproviderlist.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    openapicontentproviderlist,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: false)
                    .Where(x => x.Section.Equals("Composites"))
                    .ToList();
            }

            [Test]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Test]
            public void Should_be_a_valid_v2_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(
                            m => new
                            {
                                ApiContent = m,
                                SwaggerDocument = OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi2_0))
                            })
                        .Select(
                            d => (Action)(() => Assert.That(
                               d.SwaggerDocument, Is.Not.Null, $"ApiContent Name: {d.ApiContent.Name}")))
                        .ToArray());
            }

            [Test]
            public void Should_be_a_valid_v3_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => new OpenApiStringReader().Read(m.Metadata(OpenApiSpecVersion.OpenApi3_0), out _))
                        .Select(
                            swaggerDocument => (Action)(() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }

            [Test]
            public void Should_be_a_swagger_document_for_each_category_in_the_CompositesMetadataProvider()
            {
                var compositeCategoryNames = _compositesMetadataProvider.GetAllCategories()
                    .Select(c => c.Name);

                Assert.That(
                    _actualMetadata.Select(m => m.Name)
                        .OrderBy(n => n),
                    Is.EquivalentTo(compositeCategoryNames));
            }
        }

        public class When_requesting_the_extensions_section_from_the_cache : TestFixtureBase
        {
            private ISchemaNameMapProvider _schemaNameMapProvider;

            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            private List<OpenApiContent> _actualMetadata;
            
            private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;


            protected override void Arrange()
            {
                _schemaNameMapProvider =
                    new SchemaNameMapProvider(
                        DomainModelProvider.GetDomainModel()
                            .Schemas);

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var _resourceModelProvider = Stub<IResourceModelProvider>();
                
                _resourceIdentificationCodePropertiesProvider = Stub<IResourceIdentificationCodePropertiesProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => _resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                var openapicontentproviderlist = new List<IOpenApiContentProvider>();

                ICompositesMetadataStreamsProvider[] compositesMetadataStreamsProviders =
                    { new AppDomainEmbeddedResourcesCompositesMetadataStreamsProvider() };

                var compositemetadataprovider = new CompositesMetadataProvider(compositesMetadataStreamsProviders);

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodePropertiesProvider,
                    new FakeOpenApiIdentityProvider());

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositemetadataprovider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityprovider = new IdentityOpenApiContentProvider(OpenApiV3UpconversionProvider);

                openapicontentproviderlist.Add(identityprovider);

                openapicontentproviderlist.Add(compositeOpenApiContentProvider);

                openapicontentproviderlist.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider,
                    GetTestRouteInformation().ToList(),
                    openapicontentproviderlist,
                    openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: true)
                    .Where(x => x.Section.Equals("Extensions"))
                    .ToList();
            }

            [Test]
            public void Should_have_entries_for_the_section()
            {
                Assert.That(_actualMetadata, Is.Not.Empty);
            }

            [Test]
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata(OpenApiSpecVersion.OpenApi2_0)))
                        .Select(
                            swaggerDocument => (Action)(() => Assert.That(swaggerDocument, Is.Not.Null)))
                        .ToArray());
            }

            [Test]
            public void Should_be_a_valid_swagger_document_for_each_extension_schema_in_the_domain_model()
            {
                var extensionUriSegments = DomainModelProvider.GetDomainModel()
                    .Schemas.Select(
                        d => _schemaNameMapProvider.GetSchemaMapByLogicalName(d.LogicalName)
                            .UriSegment)
                    .Where(
                        s =>
                            !s.Equals(EdFiConventions.UriSegment));

                Assert.That(_actualMetadata.Select(m => m.Name), Is.EquivalentTo(extensionUriSegments));
            }
        }

        public class When_requesting_a_section_from_the_cache_for_which_no_route_was_registered : TestFixtureBase
        {
            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                var _openAPIMetadataRouteInformation = Stub<IList<IOpenApiMetadataRouteInformation>>();
                var _resourceIdentificationCodeProperties = Stub<IResourceIdentificationCodePropertiesProvider>();
                var _openApiContentProviders = Stub<IList<IOpenApiContentProvider>>();

                A.CallTo(() => OpenApiV3UpconversionProvider.GetUpconvertedOpenApiJson(A<string>._))
                    .ReturnsLazily(x => (new OpenApiStringReader().Read(x.Arguments.Get<string>(0), out _))
                        .SerializeAsJson(OpenApiSpecVersion.OpenApi3_0));

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration().GetValue<int>("DefaultPageSizeLimit"));

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    new FakeFeatureManager(), defaultPageSieLimitProvider,
                    OpenApiV3UpconversionProvider,
                    _resourceIdentificationCodeProperties,
                    new FakeOpenApiIdentityProvider());

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourcemodeldata = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourcemodeldata);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider, _openAPIMetadataRouteInformation, _openApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.ResetCacheInitialization();

                _actualMetadata = _openApiMetadataCacheProvider
                    .GetAllSectionDocuments(sdk: false)
                    .Where(x => x.Section.Equals(MetadataRouteConstants.Profiles))
                    .ToList();
            }

            [Test]
            public void Should_not_have_entries_present_in_the_cache()
            {
                Assert.That(_actualMetadata, Is.Empty);
            }
        }
    }
}
