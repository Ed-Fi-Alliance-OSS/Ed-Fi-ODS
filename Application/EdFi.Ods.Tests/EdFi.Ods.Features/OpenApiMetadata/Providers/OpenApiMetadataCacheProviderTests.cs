//SPDX-License-Identifier: Apache-2.0
//Licensed to the Ed-Fi Alliance under one or more agreements.
//The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
//See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Database.NamingConventions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Composites.Test;
using EdFi.Ods.Features.ChangeQueries.Repositories;
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
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Providers
{
    [TestFixture]
    public class OpenApiMetadataCacheProviderTests
    {
        protected static IDomainModelProvider DomainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;
        protected static IResourceModelProvider
            ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider
            SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;
        protected static IOpenApiContentProvider[] TestOpenApiContentProviders = { new IdentityOpenApiContentProvider() };

        private static IEnumerable<IOpenApiMetadataRouteInformation> GetTestRouteInformation(ApiSettings apiSettings)
        {
            yield return new AllOpenApiMetadataRouteInformation(apiSettings);
            yield return new CompositesOpenApiMetadataRouteInformation(apiSettings);
            yield return new ResourceTypeOpenMetadataRouteInformation(apiSettings);
            yield return new SchemaOpenApiMetadataRouteInformation(apiSettings);
            yield return new ChangeQueriesOpenApiMetadataRouteInformation(apiSettings);
            yield return new IdentityOpenApiMetadataRouteInformation(apiSettings);
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        private static ApiSettings CreateApiSettings()
        {
            return new ApiSettings
            {
                Mode = "sandbox",
                Features = new List<Feature>
                {
                    new Feature
                    {
                        Name = "Composites",
                        IsEnabled = true
                    },
                    new Feature
                    {
                        Name = "Profiles",
                        IsEnabled = true
                    },
                    new Feature
                    {
                        Name = "Extensions",
                        IsEnabled = true
                    },
                    new Feature
                    {
                        Name = "ChangeQueries",
                        IsEnabled = true
                    },
                    new Feature
                    {
                        Name = "OpenApiMetadata",
                        IsEnabled = true
                    },
                    new Feature
                    {
                        Name = IdentityManagementConstants.FeatureName,
                        IsEnabled = true
                    }
                }
            };
        }

        public class When_requesting_the_sdk_gen_section_from_the_cache : TestFixtureBase
        {
            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                var apiSettings = CreateApiSettings();

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                var openApiContentProviders = new List<IOpenApiContentProvider>();

                var compositesMetadataProvider = new CompositesMetadataProvider();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    apiSettings, defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositesMetadataProvider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityProvider = new IdentityOpenApiContentProvider();

                openApiContentProviders.Add(identityProvider);

                openApiContentProviders.Add(compositeOpenApiContentProvider);

                openApiContentProviders.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider, GetTestRouteInformation(apiSettings).ToList(), openApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata))
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

            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                var apiSettings = CreateApiSettings();
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();

                _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();

                A.CallTo(() => _profileResourceNamesProvider.GetProfileResourceNames())
                    .Returns(new List<ProfileAndResourceNames>());

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();

                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    apiSettings, defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();
                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider, GetTestRouteInformation(apiSettings).ToList(), TestOpenApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata))
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

            private OpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();

                _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();

                A.CallTo(() => _profileResourceNamesProvider.GetProfileResourceNames())
                    .Returns(new List<ProfileAndResourceNames>());

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();

                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    CreateApiSettings(), defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();
                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider, GetTestRouteInformation(CreateApiSettings()).ToList(), TestOpenApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata))
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
            private List<OpenApiContent> _actualMetadata;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => _compositesMetadataProvider.GetAllCategories())
                    .Returns(new List<CompositeCategory>());

                _profileResourceNamesProvider = new ProfileResourceNamesProvider();

                _profileResourceModelProvider = new ProfileResourceModelProvider(
                    ResourceModelProvider, new ProfileResourceNamesProvider());

                var _openAPIMetadataRouteInformation = Stub<List<IOpenApiMetadataRouteInformation>>();
                var _openApiContentProviders = Stub<List<IOpenApiContentProvider>>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var defaultPageSizeLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    CreateApiSettings(), defaultPageSizeLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider, GetTestRouteInformation(CreateApiSettings()).ToList(), TestOpenApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
                                SwaggerDocument = OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata)
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

            protected override void Arrange()
            {
                _compositesMetadataProvider = new CompositesMetadataProvider();

                var apiSettings = CreateApiSettings();

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                _compositesMetadataProvider = new CompositesMetadataProvider();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var _resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => _resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                var openapicontentproviderlist = new List<IOpenApiContentProvider>();

                var compositemetadataprovider = new CompositesMetadataProvider();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    apiSettings, defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositemetadataprovider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityprovider = new IdentityOpenApiContentProvider();

                openapicontentproviderlist.Add(identityprovider);

                openapicontentproviderlist.Add(compositeOpenApiContentProvider);

                openapicontentproviderlist.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider, GetTestRouteInformation(apiSettings).ToList(), openapicontentproviderlist, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
            public void Should_be_a_valid_swagger_document_for_each_entry()
            {
                AssertHelper.All(
                    _actualMetadata.Select(
                            m => new
                            {
                                ApiContent = m,
                                SwaggerDocument = OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata)
                            })
                        .Select(
                            d => (Action)(() => Assert.That(
                               d.SwaggerDocument, Is.Not.Null, $"ApiContent Name: {d.ApiContent.Name}")))
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

            protected override void Arrange()
            {
                _schemaNameMapProvider =
                    new SchemaNameMapProvider(
                        DomainModelProvider.GetDomainModel()
                            .Schemas);

                var apiSettings = CreateApiSettings();

                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                var openApiMetadataRouteInformation = new List<IOpenApiMetadataRouteInformation>();

                var _resourceModelProvider = Stub<IResourceModelProvider>();

                var resourceModel = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => _resourceModelProvider.GetResourceModel()).Returns(resourceModel);

                var openapicontentproviderlist = new List<IOpenApiContentProvider>();

                var compositemetadataprovider = new CompositesMetadataProvider();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    apiSettings, defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var compositeOpenApiContentProvider = new CompositesOpenApiContentProvider(
                    compositemetadataprovider, ResourceModelProvider, openApiMetadataDocumentFactory);

                var extensionsOpenApiContentProvider = new ExtensionsOpenApiContentProvider(
                    DomainModelProvider, ResourceModelProvider, SchemaNameMapProvider, openApiMetadataDocumentFactory);

                var identityprovider = new IdentityOpenApiContentProvider();

                openapicontentproviderlist.Add(identityprovider);

                openapicontentproviderlist.Add(compositeOpenApiContentProvider);

                openapicontentproviderlist.Add(extensionsOpenApiContentProvider);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    ResourceModelProvider, GetTestRouteInformation(apiSettings).ToList(), openapicontentproviderlist, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
                    _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeOpenApiMetadataDocument(m.Metadata))
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

                var _openApiContentProviders = Stub<IList<IOpenApiContentProvider>>();

                var defaultPageSieLimitProvider = new DefaultPageSizeLimitProvider(GetConfiguration());

                var openApiMetadataDocumentFactory = new OpenApiMetadataDocumentFactory(
                    CreateApiSettings(), defaultPageSieLimitProvider,
                    new TrackedChangesIdentifierProjectionsProvider(new SqlServerDatabaseNamingConvention()));

                var resourceModelProvider = Stub<IResourceModelProvider>();

                var resourcemodeldata = ResourceModelProvider.GetResourceModel();

                A.CallTo(() => resourceModelProvider.GetResourceModel()).Returns(resourcemodeldata);

                _openApiMetadataCacheProvider = new OpenApiMetadataCacheProvider(
                    resourceModelProvider, _openAPIMetadataRouteInformation, _openApiContentProviders, openApiMetadataDocumentFactory);
            }

            protected override void Act()
            {
                _openApiMetadataCacheProvider.InitializeCache();

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
