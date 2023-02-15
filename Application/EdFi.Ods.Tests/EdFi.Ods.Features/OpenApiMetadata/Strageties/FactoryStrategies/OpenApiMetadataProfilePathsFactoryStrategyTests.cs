// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Strategies.FactoryStrategies
{
    [TestFixture]
    public class OpenApiMetadataProfilePathsFactoryStrategyTests
    {
        private static readonly IResourceModelProvider _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        private class OpenApiMetadataResourceProfileComparer : IEqualityComparer<OpenApiMetadataResource>
        {
            public bool Equals(OpenApiMetadataResource x, OpenApiMetadataResource y)
            {
                return x.Name == y.Name
                       && x.Readable == y.Readable
                       && x.Writable == y.Writable;
            }

            public int GetHashCode(OpenApiMetadataResource obj)
            {
                return obj.GetHashCode();
            }
        }

        public class When_th_openapimetadata_profile_paths_factory_strategy_is_applied_to_a_list_of_openapimetadata_resources
            : TestFixtureBase
        {
            private TestProfileResourceNamesProvider _testProfileResourceNamesProvider;
            private ISchemaNameMapProvider _schemaNameMapProviderStub;
            private OpenApiMetadataDocumentContext _openApiMetadataDocumentContext;
            private IEnumerable<OpenApiMetadataResource> _actualFilteredResources;
            private IEnumerable<OpenApiMetadataResource> _expectedFilteredResources;

            private class TestProfileResourceNamesProvider : IProfileMetadataProvider
            {
                private readonly string _profileDefinition = @"<Profile name='Test-ParentNonAbstractBaseClass-ExcludeOnly'>
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

                public IReadOnlyDictionary<string, XElement> ProfileDefinitionsByName => throw new NotImplementedException();

                public bool ContainsProfileDefinition(string profileName) => true;

                public XElement GetProfileDefinition(string profileName)
                {
                    return XElement.Parse(_profileDefinition);
                }

                public MetadataValidationResult[] GetValidationResults() => Array.Empty<MetadataValidationResult>();
            }

            protected override void Arrange()
            {
                _testProfileResourceNamesProvider = new TestProfileResourceNamesProvider();

                var studentProgramAssociation = _resourceModelProvider.GetResourceModel()
                    .GetResourceByFullName(
                        new FullName(
                            EdFiConventions
                                .PhysicalSchemaName,
                            "StudentProgramAssociation"));

                var studentSpecialEducationProgramAssociation = _resourceModelProvider
                    .GetResourceModel()
                    .GetResourceByFullName(
                        new FullName(
                            EdFiConventions
                                .PhysicalSchemaName,
                            "StudentSpecialEducationProgramAssociation"));

                _expectedFilteredResources = new[]
                {
                    new OpenApiMetadataResource(studentProgramAssociation)
                    {
                        Name = "studentProgramAssociation", Readable = true
                    },
                    new OpenApiMetadataResource(studentProgramAssociation)
                    {
                        Name = "studentProgramAssociation", Readable = true,
                        ContextualResource = studentSpecialEducationProgramAssociation
                    },
                    new OpenApiMetadataResource(studentProgramAssociation)
                    {
                        Name = "studentProgramAssociation_StudentSpecialEducationProgramAssociation", Readable = true,
                        Writable = true
                    },
                    new OpenApiMetadataResource(studentSpecialEducationProgramAssociation)
                    {
                        Name = "studentSpecialEducationProgramAssociation", Readable = true, Writable = true
                    }
                };

                _schemaNameMapProviderStub = Stub<ISchemaNameMapProvider>();

                var profileValidationReporter = A.Fake<IProfileValidationReporter>();
                
                var profileResourceModel =
                    new ProfileResourceModel(
                        _resourceModelProvider.GetResourceModel(),
                        _testProfileResourceNamesProvider.ProfileDefinitionsByName.GetValueOrThrow("ProfileName", "Unable to find profile '{0}'."),
                        profileValidationReporter);

                _openApiMetadataDocumentContext =
                    new OpenApiMetadataDocumentContext(
                        _resourceModelProvider.GetResourceModel())
                    {
                        ProfileContext =
                            new OpenApiMetadataProfileContext
                            {
                                ProfileName = "ProfileName",
                                ProfileResourceModel = profileResourceModel
                            }
                    };
            }

            protected override void Act()
            {
                _actualFilteredResources = new OpenApiMetadataPathsFactoryProfileStrategy(_openApiMetadataDocumentContext)
                    .ApplyStrategy(
                        new OpenApiProfileStrategy().GetFilteredResources(_openApiMetadataDocumentContext));
            }

            [Assert]
            public void Should_not_return_empty_list_of_filtered_resources()
            {
                Assert.That(_actualFilteredResources, Is.Not.Empty);
            }

            [Assert]
            public void Should_return_a_list_of_openapimetadata_resources_which_all_are_assigned_readable_or_writable()
            {
                Assert.That(
                    _actualFilteredResources.All(
                        r => r.Readable || r.Writable),
                    Is.True);
            }

            [Assert]
            public void Should_return_a_list_of_openapimetadata_resources_which_all_assigned_a_value_of_true_for_IsProfileResource()
            {
                Assert.That(
                    _actualFilteredResources.All(
                        r => r.IsProfileResource),
                    Is.True);
            }

            [Assert]
            public void Should_return_comprehensive_list_of_openapimetadata_paths_resources_for_the_applied_strategy()
            {
                AssertHelper.All(
                    _actualFilteredResources
                        .Select(
                            r =>
                                (Action)
                                (() =>
                                    Assert.That(
                                        _expectedFilteredResources.Contains(
                                            r,
                                            new OpenApiMetadataResourceProfileComparer()),
                                        Is.True,
                                        $"OpenApiMetadata Resource {r.Name} does not exist in expected")))
                        .ToArray());
            }
        }
    }
}