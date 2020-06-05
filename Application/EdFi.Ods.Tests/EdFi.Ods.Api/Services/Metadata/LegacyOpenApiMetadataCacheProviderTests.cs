// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web.Http.Routing;
// using EdFi.Ods.Api.Common.Constants;
// using EdFi.Ods.Api.Common.Models;
// using EdFi.Ods.Api.Common.Providers;
// using EdFi.Ods.Api.Extensions;
// using EdFi.Ods.Api.Services.Metadata;
// using EdFi.Ods.Common;
// using EdFi.Ods.Common.Conventions;
// using EdFi.Ods.Common.Extensions;
// using EdFi.Ods.Common.Metadata;
// using EdFi.Ods.Common.Models;
// using EdFi.Ods.Composites.Test;
// using EdFi.Ods.Features.OpenApiMetadata;
// using EdFi.Ods.Features.OpenApiMetadata.Providers;
// using EdFi.Ods.Profiles.Test;
// using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
// using NUnit.Framework;
// using Rhino.Mocks;
// using Test.Common;
//
// namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata
// {
//     [TestFixture]
//     [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//     public class LegacyOpenApiMetadataCacheProviderTests
//     {
//         protected static IDomainModelProvider DomainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;
//         protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;
//
//         protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;
//         protected static IOpenApiContentProvider[] TestOpenApiContentProviders = {
//                                                                                      new IdentityOpenApiContentProvider()
//                                                                                  };
//
//
//         private static IEnumerable<IHttpRoute> GetTestRoutes()
//         {
//             var httpRoutes = new List<IHttpRoute>();
//
//             foreach (var route in typeof(MetadataRouteConstants).GetProperties())
//             {
//                 var httpRouteStub = MockRepository.GenerateStub<IHttpRoute>();
//
//                 httpRouteStub.Stub(x => x.DataTokens)
//                              .Return(
//                                   new Dictionary<string, object>
//                                   {
//                                       {
//                                           "Name", route.GetValue(null)
//                                       }
//                                   });
//
//                 httpRoutes.Add(httpRouteStub);
//             }
//
//             return httpRoutes.ToArray();
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_sdk_gen_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//             private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();
//                 AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Profiles_Test>();
//
//                 _compositesMetadataProvider = new CompositesMetadataProvider();
//
//                 _profileResourceNamesProvider = new ProfileResourceNamesProvider();
//                 _profileResourceModelProvider = new ProfileResourceModelProvider(ResourceModelProvider, new ProfileResourceNamesProvider());
//
//                 // var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//                 //
//                 // openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                 //                                 .Return(GetTestRoutes());
//                 //
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: true)
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata))
//                 //                    .Select(
//                 //                         swaggerDocument => (Action) (() => Assert.That(swaggerDocument, Is.Not.Null)))
//                 //                    .ToArray());
//             }
//
//             [Assert]
//             public void Should_contain_sdk_gen_and_extension_extensions()
//             {
//                 Assert.That(
//                     _actualMetadata.Select(x => x.Section)
//                                    .Distinct(),
//                     Is.EquivalentTo(
//                         new[]
//                         {
//                             OpenApiMetadataSections.SdkGen,
//                             OpenApiMetadataSections.Extensions,
//                             OpenApiMetadataSections.Composites,
//                             OpenApiMetadataSections.Profiles,
//                             OpenApiMetadataSections.Other
//                         }));
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_swagger_ui_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             // private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();
//
//                 _compositesMetadataProvider.Stub(x => x.GetAllCategories())
//                                            .Return(new List<CompositeCategory>());
//
//                 _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();
//
//                 _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();
//
//                 _profileResourceNamesProvider.Stub(x => x.GetProfileResourceNames())
//                                              .Return(new List<ProfileAndResourceNames>());
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(GetTestRoutes());
//
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: false)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.SwaggerUi))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata))
//                 //                    .Select(
//                 //                         swaggerDocument =>
//                 //                             (Action)
//                 //                             (() => Assert.That(swaggerDocument, Is.Not.Null)))
//                 //                    .ToArray());
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_other_ui_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             // private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();
//
//                 _compositesMetadataProvider.Stub(x => x.GetAllCategories())
//                                            .Return(new List<CompositeCategory>());
//
//                 _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();
//
//                 _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();
//
//                 _profileResourceNamesProvider.Stub(x => x.GetProfileResourceNames())
//                                              .Return(new List<ProfileAndResourceNames>());
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(GetTestRoutes());
//
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: false)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.Other))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata))
//                 //                    .Select(
//                 //                         swaggerDocument => (Action) (() => Assert.That(swaggerDocument, Is.Not.Null)))
//                 //                    .ToArray());
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_profiles_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             // private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Profiles_Test>();
//
//                 _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();
//
//                 _compositesMetadataProvider.Stub(x => x.GetAllCategories())
//                                            .Return(new List<CompositeCategory>());
//
//                 _profileResourceNamesProvider = new ProfileResourceNamesProvider();
//                 _profileResourceModelProvider = new ProfileResourceModelProvider(ResourceModelProvider, new ProfileResourceNamesProvider());
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(GetTestRoutes());
//
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: false)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.Profiles))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(
//                 //                         m => new
//                 //                              {
//                 //                                  ApiContent = m, SwaggerDocument = OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata)
//                 //                              })
//                 //                    .Select(
//                 //                         d => (Action) (() => Assert.That(d.SwaggerDocument, Is.Not.Null, $"ApiContent Name: {d.ApiContent.Name}")))
//                 //                    .ToArray());
//             }
//
//             [Assert]
//             public void Should_be_a_swagger_document_for_each_distinct_profile_in_the_ProfileResourceNamesProvider()
//             {
//                 var profileNames = _profileResourceNamesProvider.GetProfileResourceNames()
//                                                                 .Select(n => n.ProfileName)
//                                                                 .Distinct();
//
//                 Assert.That(
//                     _actualMetadata.Select(m => m.Name),
//                     Is.EquivalentTo(profileNames));
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_composites_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             // private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();
//
//                 _compositesMetadataProvider = new CompositesMetadataProvider();
//                 _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();
//                 _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();
//
//                 _profileResourceNamesProvider.Stub(x => x.GetProfileResourceNames())
//                                              .Return(new List<ProfileAndResourceNames>());
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(GetTestRoutes());
//                 //
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: false)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.Composites))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(
//                 //                         m => new
//                 //                              {
//                 //                                  ApiContent = m, SwaggerDocument = OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata)
//                 //                              })
//                 //                    .Select(
//                 //                         d => (Action) (() => Assert.That(d.SwaggerDocument, Is.Not.Null, $"ApiContent Name: {d.ApiContent.Name}")))
//                 //                    .ToArray());
//             }
//
//             [Assert]
//             public void Should_be_a_swagger_document_for_each_category_in_the_CompositesMetadataProvider()
//             {
//                 var compositeCategoryNames = _compositesMetadataProvider.GetAllCategories()
//                                                                         .Select(c => c.Name);
//
//                 // Assert.That(
//                 //     _actualMetadata.Select(m => m.Name)
//                 //                    .OrderBy(n => n),
//                 //     Is.EquivalentTo(compositeCategoryNames));
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_the_extensions_section_from_the_cache : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//             private ISchemaNameMapProvider _schemaNameMapProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             // private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();
//
//                 _compositesMetadataProvider.Stub(x => x.GetAllCategories())
//                                            .Return(new List<CompositeCategory>());
//
//                 _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();
//                 _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();
//
//                 _profileResourceNamesProvider.Stub(x => x.GetProfileResourceNames())
//                                              .Return(new List<ProfileAndResourceNames>());
//
//                 _schemaNameMapProvider =
//                     new SchemaNameMapProvider(
//                         DomainModelProvider.GetDomainModel()
//                                            .Schemas);
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(GetTestRoutes());
//                 //
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     _schemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: true)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.Extensions))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_have_entries_for_the_section()
//             {
//                 Assert.That(_actualMetadata, Is.Not.Empty);
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_entry()
//             {
//                 // AssertHelper.All(
//                 //     _actualMetadata.Select(m => OpenApiMetadataHelper.DeserializeSwaggerDocument(m.Metadata))
//                 //                    .Select(
//                 //                         swaggerDocument => (Action) (() => Assert.That(swaggerDocument, Is.Not.Null)))
//                 //                    .ToArray());
//             }
//
//             [Assert]
//             public void Should_be_a_valid_swagger_document_for_each_extension_schema_in_the_domain_model()
//             {
//                 var extensionUriSegments = DomainModelProvider.GetDomainModel()
//                                                               .Schemas.Select(
//                                                                    d => _schemaNameMapProvider.GetSchemaMapByLogicalName(d.LogicalName)
//                                                                                               .UriSegment)
//                                                               .Where(
//                                                                    s =>
//                                                                        !s.Equals(EdFiConventions.UriSegment));
//
//                 Assert.That(_actualMetadata.Select(m => m.Name), Is.EquivalentTo(extensionUriSegments));
//             }
//         }
//
//         [Ignore("Needs refactoring to new OpenApiMetadata Controller")]
//         public class When_requesting_a_section_from_the_cache_for_which_no_route_was_registered : LegacyTestFixtureBase
//         {
//             private ICompositesMetadataProvider _compositesMetadataProvider;
//             private IProfileResourceModelProvider _profileResourceModelProvider;
//             private IProfileResourceNamesProvider _profileResourceNamesProvider;
//
//             // private LegacyOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
//
//             private List<OpenApiContent> _actualMetadata;
//
//             protected override void Arrange()
//             {
//                 _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();
//
//                 _compositesMetadataProvider.Stub(x => x.GetAllCategories())
//                                            .Return(new List<CompositeCategory>());
//
//                 _profileResourceModelProvider = Stub<IProfileResourceModelProvider>();
//
//                 _profileResourceNamesProvider = Stub<IProfileResourceNamesProvider>();
//
//                 _profileResourceNamesProvider.Stub(x => x.GetProfileResourceNames())
//                                              .Return(new List<ProfileAndResourceNames>());
//
//                 var openApiMetadataRouteProviderStub = Stub<IOpenApiMetadataRouteProvider>();
//
//                 openApiMetadataRouteProviderStub.Stub(x => x.GetAllRoutes())
//                                                 .Return(
//                                                      GetTestRoutes()
//                                                         .Where(r => r.GetDataTokenRouteName() != MetadataRouteConstants.Profiles));
//
//                 // _openApiMetadataCacheProvider = new LegacyOpenApiMetadataCacheProvider(
//                 //     DomainModelProvider,
//                 //     ResourceModelProvider,
//                 //     _profileResourceModelProvider,
//                 //     _profileResourceNamesProvider,
//                 //     _compositesMetadataProvider,
//                 //     SchemaNameMapProvider,
//                 //     openApiMetadataRouteProviderStub,
//                 //     TestOpenApiContentProviders);
//             }
//
//             protected override void Act()
//             {
//                 // _openApiMetadataCacheProvider.InitializeCache();
//                 //
//                 // _actualMetadata = _openApiMetadataCacheProvider
//                 //                  .GetAllSectionDocuments(sdk: false)
//                 //                  .Where(x => x.Section.Equals(OpenApiMetadataSections.Profiles))
//                 //                  .ToList();
//             }
//
//             [Assert]
//             public void Should_not_have_entries_present_in_the_cache()
//             {
//                 Assert.That(_actualMetadata, Is.Empty);
//             }
//         }
//     }
// }
