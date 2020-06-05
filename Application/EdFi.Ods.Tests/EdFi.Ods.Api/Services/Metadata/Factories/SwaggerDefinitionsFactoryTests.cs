// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerDefinitionsFactoryTests
    {
        protected static IResourceModelProvider
            ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;
        protected static ISchemaNameMapProvider
            SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class
            When_creating_definitions_for_list_of_resources_using_a_single_instance_or_year_specific_ods : TestFixtureBase
        {
            private IDictionary<string, Schema> _actualDefinitions;
            private IList<Resource> _resources;
            private IList<Schema> _actualEdfiResourceDefinitions;
            private IDictionary<string, List<string>> _actualPropertyNamesByDefinitionName;
            private IDictionary<string, List<string>> _expectedPropertyNamesByDefinitionName;
            private List<string> _expectedDefinitionNames;
            private List<Schema> _actualExtendableEdfiResourceDefinitions;
            private SwaggerDefinitionsFactoryDefaultNamingStrategy _namingStrategy;

            protected override void Arrange()
            {
                _resources = ResourceModelProvider.GetResourceModel().GetAllResources().ToList();
                _expectedPropertyNamesByDefinitionName = ExpectedPropertyNamesByDefinitionName(_resources);
                _namingStrategy = new SwaggerDefinitionsFactoryDefaultNamingStrategy();

                _expectedDefinitionNames = _resources
                    .Select(x => _namingStrategy.GetResourceName(x, new SwaggerResource(x)).ToCamelCase()).ToList();
            }

            protected override void Act()
            {
                _actualDefinitions = SwaggerDocumentFactoryHelper
                    .CreateSwaggerDefinitionsFactory(
                        new SwaggerDocumentContext(ResourceModelProvider.GetResourceModel())
                        {
                            RenderType = RenderType.GeneralizedExtensions
                        }).Create(_resources.Select(r => new SwaggerResource(r)).ToList());

                _actualEdfiResourceDefinitions = _resources.Where(r => r.IsEdFiStandardResource).Select(r => r.Name.ToCamelCase())
                    .Where(_actualDefinitions.ContainsKey).Select(r => _actualDefinitions[r]).ToList();

                // link definitions are excluded here and tested in a separate assertion.
                _actualExtendableEdfiResourceDefinitions = _resources.Where(r => r.IsEdFiStandardResource && !r.Entity.IsLookup)
                    .Select(r => r.Name.ToCamelCase()).Where(_actualDefinitions.ContainsKey).Select(r => _actualDefinitions[r])
                    .ToList();

                _actualPropertyNamesByDefinitionName = _actualDefinitions.Where(d => d.Key != "link").Select(
                    d => new
                    {
                        DefinitionName =
                            d.Key,

                        // Separate tests verify that these properties must exist in resource definitions
                        Properties = d.Value.properties.Keys.Except(
                            new[]
                            {
                                "_ext",
                                "_etag",
                                "link"
                            }).ToList()
                    }).ToDictionary(k => k.DefinitionName, v => v.Properties);
            }

            [Assert]
            public void Should_not_be_empty()
            {
                Assert.That(_actualDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_contain_a_definition_for_all_resources_and_children()
            {
                Assert.That(
                    _actualDefinitions.Keys.Except(new[] {"link"}), Is.EquivalentTo(_expectedPropertyNamesByDefinitionName.Keys));
            }

            [Assert]
            public void Should_be_created_with_all_resource_definitions_containing_an_etag_property()
            {
                AssertHelper.All(
                    _expectedDefinitionNames.Select(x => _actualDefinitions[x])
                        .Select(x => (Action) (() => Assert.That(x.properties.Keys, Has.Member("_etag")))).ToArray());
            }

            [Assert]
            public void Should_be_created_with_all_edfi_resource_definitions_containing_an_ext_property()
            {
                // _ext property contains any entity-extensions present for the given edfi resource.
                AssertHelper.All(
                    _actualExtendableEdfiResourceDefinitions
                        .Select(x => (Action) (() => Assert.That(x.properties.Keys, Has.Member("_ext")))).ToArray());
            }

            [Assert]
            public void Should_be_created_with_all_reference_definitions_containing_a_link_property()
            {
                AssertHelper.All(
                    _actualDefinitions.Where(d => d.Key.EndsWith("Reference")).Select(
                        x => (Action) (() => Assert.That(x.Value.properties.Keys, Has.Member("link")))).ToArray());
            }

            [Assert]
            public void Should_be_created_with_link_definition()
            {
                Assert.That(_actualDefinitions.Keys, Has.Member("link"));
            }

            [Assert]
            public void Should_be_created_with_resource_definitions_which_contain_complete_list_of_expected_properties()
            {
                // Assert expected definition property keys are equivalent to actual definition property keys.
                AssertHelper.All(
                    _expectedPropertyNamesByDefinitionName.Select(
                            x => (Action) (() => Assert.That(
                                _actualPropertyNamesByDefinitionName[x.Key], Is.EquivalentTo(x.Value), $"Resource = {x.Key}")))
                        .ToArray());
            }
        }

        private static IDictionary<string, List<string>> ExpectedPropertyNamesByDefinitionName(IEnumerable<Resource> resources)
        {
            var namingStrategy = new SwaggerDefinitionsFactoryDefaultNamingStrategy();

            var definitions = resources.Select(
                d => new
                {
                    DefinitionName = namingStrategy.GetResourceName(d, new SwaggerResource(d)),
                    Properties = d.UnifiedKeyAllProperties().Select(p => p.JsonPropertyName).Concat(
                            d.Collections.Select(
                                c => c.IsDerivedEntityATypeEntity() && c.IsInherited
                                    ? c.Association.OtherEntity.PluralName.ToCamelCase()
                                    : c.JsonPropertyName)).Concat(d.EmbeddedObjects.Select(e => e.JsonPropertyName))
                        .Concat(d.References.Select(r => r.PropertyName.ToCamelCase()))
                }).Concat(
                resources.SelectMany(r => r.AllContainedItemTypes).Select(
                    i => new
                    {
                        DefinitionName = namingStrategy.GetContainedItemTypeName(
                            new SwaggerResource(new Resource("TestResource")), i).ToCamelCase(),
                        Properties = i.Properties
                            .Select(p => UniqueIdSpecification.GetUniqueIdPropertyName(p.JsonPropertyName))
                            .Concat(i.Collections.Select(c => c.JsonPropertyName))
                            .Concat(i.EmbeddedObjects.Select(e => e.JsonPropertyName))
                            .Concat(i.References.Select(r => r.PropertyName.ToCamelCase()))
                    })).Concat(
                resources.SelectMany(x => x.AllContainedReferences).Distinct(ModelComparers.ReferenceTypeNameOnly).Select(
                    reference => new
                    {
                        DefinitionName = namingStrategy.GetReferenceName(new Resource("TestResource"), reference),
                        Properties = reference.ReferenceTypeProperties.Where(p => p.IsIdentifying).Select(
                            p => UniqueIdSpecification.GetUniqueIdPropertyName(p.JsonPropertyName))
                    })).ToList();

            return definitions.GroupBy(x => x.DefinitionName).Select(x => x.First()).ToDictionary(
                k => k.DefinitionName.ToCamelCase(), v => v.Properties.ToList());
        }

        public class
            When_creating_definitions_for_list_of_profile_resources_using_a_single_instance_or_year_specific_ods :
                LegacyTestFixtureBase
        {
            private IDictionary<string, Schema> _actualDefinitions;
            private IList<SwaggerResource> _swaggerResources;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _swaggerDocumentContext =
                    new SwaggerDocumentContext(ResourceModelProvider.GetResourceModel())
                    {
                        ProfileContext = new SwaggerProfileContext()
                    };

                string profileDefinition =
                    @"<Profile name='Test-ParentNonAbstractBaseClass-ExcludeOnly'> <Resource name='StudentSpecialEducationProgramAssociation'> <ReadContentType memberSelection='ExcludeOnly'> <Property name='SpecialEducationHoursPerWeek'/> </ReadContentType> <WriteContentType memberSelection='IncludeAll'/> </Resource> <Resource name='Staff'> <ReadContentType memberSelection='IncludeOnly'> <Extension name='GrandBend'  memberSelection='IncludeOnly' logicalSchema='GrandBend'> <Property name='Tenured'/> </Extension> </ReadContentType> <WriteContentType memberSelection='IncludeAll' /> </Resource> <Resource name='StudentProgramAssociation'> <ReadContentType memberSelection='IncludeOnly'/> </Resource> </Profile>";

                var profileResourceModel = new ProfileResourceModel(
                    ResourceModelProvider.GetResourceModel(), XElement.Parse(profileDefinition));

                var readableResourceModel = profileResourceModel.ResourceByName.Values.Where(r => r.Readable != null);
                var writableResourceModel = profileResourceModel.ResourceByName.Values.Where(r => r.Writable != null);
                var edFiSchemaPrefix = "edFi";

                _swaggerResources = readableResourceModel
                    .Select(
                        r => new SwaggerResource(r.Readable)
                        {
                            Name =
                                $"{edFiSchemaPrefix}_{CompositeTermInflector.MakeSingular(r.Readable.Name)}_{ContentTypeUsage.Readable}"
                                    .ToCamelCase(),
                            Readable = true,
                            IsProfileResource = true
                        }).Concat(
                        writableResourceModel.Select(
                            r => new SwaggerResource(r.Writable)
                            {
                                Name =
                                    $"{edFiSchemaPrefix}_{CompositeTermInflector.MakeSingular(r.Writable.Name)}_{ContentTypeUsage.Writable}"
                                        .ToCamelCase(),
                                Writable = true,
                                IsProfileResource = true
                            })).ToList();
            }

            protected override void Act()
            {
                _actualDefinitions = SwaggerDocumentFactoryHelper.CreateSwaggerDefinitionsFactory(_swaggerDocumentContext)
                    .Create(_swaggerResources);
            }

            [Assert]
            public void Should_return_a_non_empty_list_of_definitions()
            {
                Assert.That(_actualDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_return_a_list_of_definitions_with_a_content_type_usage_appended_to_name()
            {
                AssertHelper.All(
                    _actualDefinitions.Keys.Where(k => !k.EndsWith("Reference")).Except(new[] {"link"}).Select(
                        k => (Action) (() => Assert.That(
                            k.EndsWithIgnoreCase($"_{ContentTypeUsage.Readable}") ||
                            k.EndsWithIgnoreCase($"_{ContentTypeUsage.Writable}"), Is.True,
                            $@"Definition name {k} does not end with a content type usage"))).ToArray());
            }

            [Assert]
            public void Should_return_filtered_profile_resource_definitions_with_correctly_excluded_properties()
            {
                var actualProperties = _actualDefinitions["edFi_studentSpecialEducationProgramAssociation_readable"].properties;
                string excludedProperty = "specialEducationHoursPerWeek";

                Assert.That(
                    !actualProperties.ContainsKey(excludedProperty), Is.True,
                    $"Excluded property {excludedProperty} detected in property list for definition");
            }

            [Assert]
            public void Should_return_filtered_profile_resource_definitions_with_correctly_named_definition_references()
            {
                var definitionReferences = _actualDefinitions.Values.Where(v => v.items != null).Select(v => v.items.@ref);

                AssertHelper.All(
                    definitionReferences.Select(
                        r => (Action) (() => Assert.That(
                            r.EndsWith($"_{ContentTypeUsage.Readable}") || r.EndsWith($"_{ContentTypeUsage.Writable}"), Is.True,
                            $@"Definition reference {r} does not end with a content type usage"))).ToArray());
            }

            [Assert]
            public void Should_return_filtered_profile_resource_definitions_with_included_profile_extension_bridge_definition()
            {
                var expectedProfileExtensionBridgeDefinition = "staffExtensions_readable";

                Assert.That(
                    _actualDefinitions.Keys.Contains(expectedProfileExtensionBridgeDefinition), Is.True,
                    $"Expected profile extension bridge {expectedProfileExtensionBridgeDefinition} not found in actual definitions.");
            }

            [Assert]
            public void Should_return_filtered_profile_resource_definitions_with_included_profile_extensions()
            {
                var expectedProfileExtension = "grandBend_staffExtension_readable";

                Assert.That(
                    _actualDefinitions.Keys.Contains(expectedProfileExtension), Is.True,
                    $"Expected profile extension {expectedProfileExtension} not found in actual definitions.");
            }

            [Assert]
            public void
                Should_return_filtered_profile_extension_resource_definitions_with_correctly_included_extension_properties()
            {
                var expectedProfileExtension = "grandBend_staffExtension_readable";
                var expectedProfileExtensionProperties = new[] {"tenured"};

                Assert.That(
                    _actualDefinitions["grandBend_staffExtension_readable"].properties.Keys,
                    Is.EquivalentTo(expectedProfileExtensionProperties),
                    $"Expected profile extension {expectedProfileExtension} properties {string.Join(", ", expectedProfileExtensionProperties)} not found in actual definition.");
            }
        }

        public class
            When_creating_definitions_for_list_of_composite_resources_using_a_single_instance_or_year_specific_ods :
                TestFixtureBase
        {
            private IDictionary<string, Schema> _actualDefinitions;
            private IList<SwaggerResource> _swaggerResources;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _swaggerDocumentContext = new SwaggerDocumentContext(ResourceModelProvider.GetResourceModel())
                {
                    CompositeContext = new SwaggerCompositeContext {CategoryName = OpenApiCompositeHelper.CategoryName}
                };

                var definitions = new List<XElement>(OpenApiCompositeHelper.CompositeDefinitions).ToReadOnlyList();
                var routes = new List<XElement>(OpenApiCompositeHelper.Routes).ToReadOnlyList();
                var compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                A.CallTo(() => compositesMetadataProvider.TryGetCompositeDefinitions(A<string>._, A<string>._, out definitions))
                    .Returns(true);

                A.CallTo(() => compositesMetadataProvider.TryGetRoutes(A<string>._, A<string>._, out routes)).Returns(true);

                _swaggerResources = new OpenApiCompositeStrategy(compositesMetadataProvider)
                    .GetFilteredResources(_swaggerDocumentContext).ToList();
            }

            protected override void Act()
            {
                _actualDefinitions = SwaggerDocumentFactoryHelper.CreateSwaggerDefinitionsFactory(_swaggerDocumentContext)
                    .Create(_swaggerResources);
            }

            [Assert]
            public void Should_return_a_non_empty_list_of_definitions()
            {
                Assert.That(_actualDefinitions, Is.Not.Empty);
            }

            [Assert]
            public void Should_return_a_correctly_constructed_linked_collection_definition()
            {
                // Linked collection definition names are constructed by compounding each collection level name.
                var expectedLinkedCollectionDefinitionName =
                    "assessment_objectiveAssessment_objectiveAssessmentLearningObjective_learningObjectiveLearningStandard_learningStandardIdentificationCode";

                var actualCollectionsDefinition = _actualDefinitions[expectedLinkedCollectionDefinitionName];

                var expectedCollectionProperties = new[]
                {
                    "contentStandardName",
                    "identificationCode"
                };

                AssertHelper.All(
                    () => Assert.That(
                        actualCollectionsDefinition, Is.Not.Null,
                        $"No definition found for expected linked collection definition {expectedLinkedCollectionDefinitionName}"),
                    () => Assert.That(
                        actualCollectionsDefinition.properties.Keys, Is.EquivalentTo(expectedCollectionProperties)));
            }

            [Assert]
            public void Should_return_a_correctly_constructed_resource_reference_definition_specified_in_composite_definition()
            {
                var expectedReferenceDefinitionName =
                    "assessment_objectiveAssessment_objectiveAssessmentLearningObjective_learningObjectiveLearningStandard";

                var expectedReferenceProperties = new[]
                {
                    "id",
                    "description",
                    "learningStandardId",
                    "namespace",
                    "courseTitle",
                    "learningStandardItemCode",
                    "successCriteria",
                    "uri",
                    "learningStandardIdentificationCodes"
                };

                Schema actualReferenceDefinition;
                _actualDefinitions.TryGetValue(expectedReferenceDefinitionName, out actualReferenceDefinition);

                AssertHelper.All(
                    () => Assert.That(
                        actualReferenceDefinition, Is.Not.Null,
                        $"No definition found for expected reference definition {expectedReferenceDefinitionName}"),
                    () => Assert.That(actualReferenceDefinition.properties.Keys, Is.EquivalentTo(expectedReferenceProperties)));
            }
        }
    }
}
