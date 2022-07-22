// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Factories
{
    [TestFixture]
    public class OpenApiMetadataPathsFactoryTests
    {
        protected const string EndPoint = "/ed-fi/{0}";

        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

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
                    }
                }
            };
        }
        public class When_creating_paths_for_a_list_of_resources_using_a_single_instance_or_a_year_specific_ods : TestFixtureBase
        {
            private IDictionary<string, PathItem> _actualPaths;

            protected override void Act()
            {
                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualPaths = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataPathsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext, CreateApiSettings())
                    .Create(openApiMetadataResources, false);
            }

            [Assert]
            public void Should_not_be_empty()
            {
                Assert.That(_actualPaths, Is.Not.Empty);
            }

            [Assert]
            public void Should_contain_entries_for_students()
            {
                AssertHasPathEntry("students");
            }

            [Assert]
            public void Should_contain_entries_for_academicWeeks()
            {
                AssertHasPathEntry("academicWeeks");
            }

            [Assert]
            public void Should_contain_deletes_entries_for_academicWeeks()
            {
                var endpoint = string.Format(EndPoint, "academicWeeks/deletes");

                AssertHelper.All(
                    () => Assert.That(_actualPaths.Keys, Has.Member(endpoint)),
                    () => Assert.That(
                        _actualPaths[endpoint].get?.responses?.GetValueOrDefault("200")?.schema?.items?.@ref,
                        Is.EqualTo("#/definitions/trackedChanges_edFi_academicWeekDelete")));
            }

            [Assert]
            public void Should_contain_keyChanges_entries_for_academicWeeks()
            {
                var endpoint = string.Format(EndPoint, "academicWeeks/keyChanges");

                AssertHelper.All(
                    () => Assert.That(_actualPaths.Keys, Has.Member(endpoint)),
                    () => Assert.That(
                        _actualPaths[endpoint].get?.responses?.GetValueOrDefault("200")?.schema?.items?.@ref,
                        Is.EqualTo("#/definitions/trackedChanges_edFi_academicWeekKeyChange")));
            }

            [Assert]
            public void Should_contain_entries_for_studentCharacteristicDescriptors()
            {
                AssertHasPathEntry("studentCharacteristicDescriptors");
            }

            [Assert]
            public void Should_only_have_get_and_post_operations_only_for_students_without_an_id()
            {
                AssertHasGetAndPostOperations("students");
            }

            [Assert]
            public void Should_only_have_get_and_post_operations_only_for_academicWeeks_without_an_id()
            {
                AssertHasGetAndPostOperations("academicWeeks");
            }

            [Assert]
            public void Should_only_have_get_and_post_operations_only_for_studentCharacteristicDescriptors_without_an_id()
            {
                AssertHasGetAndPostOperations("studentCharacteristicDescriptors");
            }

            [Assert]
            public void Should_only_have_all_operations_except_post_for_students_with_an_id()
            {
                AssertHasAllOperationsExceptPost("students");
            }

            [Assert]
            public void Should_only_have_all_operations_except_post_for_academicWeeks_with_an_id()
            {
                AssertHasAllOperationsExceptPost("academicWeeks");
            }

            [Assert]
            public void Should_only_have_all_operations_except_post_for_studentCharacteristicDescriptors_without_an_id()
            {
                AssertHasAllOperationsExceptPost("studentCharacteristicDescriptors");
            }

            private void AssertHasPathEntry(string resourceName)
            {
                var endpoint = string.Format(EndPoint, resourceName);

                AssertHelper.All(
                    () => Assert.That(_actualPaths.Keys, Has.Member(endpoint)),
                    () => Assert.That(_actualPaths.Keys, Has.Member(endpoint + "/{id}"))
                );
            }

            private void AssertHasGetAndPostOperations(string resourceName)
            {
                var pathItem = _actualPaths[string.Format(EndPoint, resourceName)];

                AssertHelper.All(
                    () => Assert.That(pathItem.get, Is.Not.Null),
                    () => Assert.That(pathItem.put, Is.Null),
                    () => Assert.That(pathItem.post, Is.Not.Null),
                    () => Assert.That(pathItem.delete, Is.Null)
                );
            }

            private void AssertHasAllOperationsExceptPost(string resourceName)
            {
                var pathItem = _actualPaths[string.Format(EndPoint, resourceName) + "/{id}"];

                AssertHelper.All(
                    () => Assert.That(pathItem.get, Is.Not.Null),
                    () => Assert.That(pathItem.put, Is.Not.Null),
                    () => Assert.That(pathItem.post, Is.Null),
                    () => Assert.That(pathItem.delete, Is.Not.Null)
                );
            }
        }

        public class When_creating_paths_for_a_list_of_resources_using_a_single_instance_or_a_year_specific_ods_with_change_queries_disabled : TestFixtureBase
        {
            private IDictionary<string, PathItem> _actualPaths;

            protected override void Act()
            {
                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                var appSettings = CreateApiSettings();
                appSettings.Features.Single(f => f.Name == "ChangeQueries").IsEnabled = false;

                _actualPaths = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataPathsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext, appSettings)
                    .Create(openApiMetadataResources, false);
            }

            [Assert]
            public void Should_not_be_empty()
            {
                Assert.That(_actualPaths, Is.Not.Empty);
            }

            [Assert]
            public void Should_not_contain_deletes_entries_for_academicWeeks()
            {
                var endpoint = string.Format(EndPoint, "academicWeeks/deletes");
                Assert.That(_actualPaths.Keys, Has.No.Member(endpoint));
            }

            [Assert]
            public void Should_not_contain_keyChanges_entries_for_academicWeeks()
            {
                var endpoint = string.Format(EndPoint, "academicWeeks/keyChanges");
                Assert.That(_actualPaths.Keys, Has.No.Member(endpoint));
            }
        }

        public class When_creating_paths_for_list_of_profile_resources_using_a_single_instance_or_year_specific_ods
            : TestFixtureBase
        {
            private IDictionary<string, PathItem> _actualPaths;
            private IList<OpenApiMetadataResource> _openApiMetadataResources;
            private OpenApiMetadataDocumentContext _openApiMetadataDocumentContext;

            protected override void Arrange()
            {
                _openApiMetadataDocumentContext =
                    new OpenApiMetadataDocumentContext(
                        ResourceModelProvider.GetResourceModel())
                    {
                        ProfileContext = new OpenApiMetadataProfileContext
                        {
                            ProfileName = "Test-ParentNonAbstractBaseClass-ExcludeOnly"
                        },
                        RenderType = RenderType.GeneralizedExtensions
                    };

                string profileDefinition = @"<Profile name='Test-ParentNonAbstractBaseClass-ExcludeOnly'>
                                                <Resource name='StudentSpecialEducationProgramAssociation'>
                                                  <ReadContentType memberSelection='ExcludeOnly'>
                                                    <Property name='SpecialEducationHoursPerWeek'/>
                                                  </ReadContentType>
                                                  <WriteContentType memberSelection='IncludeAll'/>
                                                </Resource>
                                                <Resource name='StudentProgramAssociation'>
                                                  <ReadContentType memberSelection='IncludeOnly'/>
                                                </Resource>
                                              </Profile>";

                var profileResourceModel =
                    new ProfileResourceModel(
                        ResourceModelProvider.GetResourceModel(),
                        XElement.Parse(profileDefinition));

                var readableResourceModel =
                    profileResourceModel.ResourceByName.Values.Where(r => r.Readable != null);

                var writableResourceModel =
                    profileResourceModel.ResourceByName.Values.Where(r => r.Writable != null);

                _openApiMetadataResources = readableResourceModel
                    .Select(
                        r => new OpenApiMetadataResource(r.Readable)
                        {
                            Name =
                                $"{CompositeTermInflector.MakeSingular(r.Readable.Name)}_{ContentTypeUsage.Readable}"
                                    .ToCamelCase(),
                            Readable = true, IsProfileResource = true
                        })
                    .Concat(
                        writableResourceModel.Select(
                            r => new OpenApiMetadataResource(r.Writable)
                            {
                                Name =
                                    $"{CompositeTermInflector.MakeSingular(r.Writable.Name)}_{ContentTypeUsage.Writable}"
                                        .ToCamelCase(),
                                Writable = true, IsProfileResource = true
                            }
                        ))
                    .ToList();
            }

            protected override void Act()
            {
                _actualPaths = OpenApiMetadataDocumentFactoryHelper
                    .CreateOpenApiMetadataPathsFactory(_openApiMetadataDocumentContext, CreateApiSettings())
                    .Create(_openApiMetadataResources, false);
            }

            [Assert]
            public void Should_return_a_non_empty_list_of_paths()
            {
                Assert.That(_actualPaths, Is.Not.Empty);
            }

            [Assert]
            public void Should_return_a_list_of_paths_with_correct_operation_content_types()
            {
                var paths = _actualPaths.Values;

                var pathOperationContentTypes = paths.SelectMany(p => p.get?.produces ?? Enumerable.Empty<string>())
                    .Concat(
                        paths.SelectMany(
                            p => p.put?.consumes ?? Enumerable.Empty<string>()))
                    .Concat(
                        paths.SelectMany(
                            p => p.post?.consumes ?? Enumerable.Empty<string>()))
                    .Concat(
                        paths.SelectMany(
                            p => p.delete?.consumes ?? Enumerable.Empty<string>()));

                var operationContentTypeRegex = new Regex(
                    "application\\/vnd.ed-fi.(\\w+).test-parentnonabstractbaseclass-excludeonly.(readable|writable)\\+json");

                AssertHelper.All(
                    pathOperationContentTypes
                        .Select(
                            c =>
                                (Action)
                                (() =>
                                    Assert.That(
                                        operationContentTypeRegex.IsMatch(c),
                                        Is.True,
                                        $@"Path operation content type 
                                        {c} does not match expected pattern 
                                        {
                                                "application/vnd.ed-fi.(\\w+).Test-parentnonabstractbaseclass-excludeonly.(readable|writable)+json"
                                            }.")))
                        .ToArray());
            }

            [Assert]
            public void Should_return_a_list_of_paths_with_correct_content_type_appended_to_schema_reference_for_post_operations()
            {
                var paths = _actualPaths.Values;

                var postOperationReference = paths.Select(
                        p => p.post?.parameters[0]
                            ?.schema?.@ref)
                    .Where(r => r != null);

                var refContentTypeRegex = new Regex("(\\w+)_(readable|writable)");

                AssertHelper.All(
                    postOperationReference
                        .Select(
                            c =>
                                (Action)
                                (() =>
                                    Assert.That(
                                        refContentTypeRegex.IsMatch(c),
                                        Is.True,
                                        $@"Path reference content type
                                        {c} does not match expected pattern 
                                        {"(\\w+)_(readable|writable)"}")))
                        .ToArray());
            }

            [Assert]
            public void Should_return_a_profile_resource_get_path_with_parameters_correctly_filtered_by_profile()
            {
                var getPath = _actualPaths.FirstOrDefault(
                    p => p.Key == "/ed-fi/studentSpecialEducationProgramAssociations");

                string filteredParameterName = "SpecialEducationHoursPerWeek";

                Assert.That(
                    getPath.Value.get.parameters.All(p => p.name != filteredParameterName),
                    Is.True,
                    $@"Resource property {filteredParameterName} 
                     was not correctly filtered from parameter list in get operation for path {getPath.Key}");
            }
        }
    }
}