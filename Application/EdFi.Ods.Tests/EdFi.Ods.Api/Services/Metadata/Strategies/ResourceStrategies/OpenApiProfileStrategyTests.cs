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
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Strategies.ResourceStrategies
{
    [TestFixture]
    public class OpenApiProfileStrategyTests
    {
        private static readonly IResourceModelProvider _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        private class SwaggerResourceProfileComparer : IEqualityComparer<SwaggerResource>
        {
            public bool Equals(SwaggerResource x, SwaggerResource y)
            {
                return x.Name == y.Name
                       && x.Readable == y.Readable
                       && x.Writable == y.Writable;
            }

            public int GetHashCode(SwaggerResource obj)
            {
                return obj.GetHashCode();
            }
        }

        public class When_list_of_resources_is_filtered_with_profile_strategy
            : TestFixtureBase
        {
            private TestProfileResourceNamesProvider _testProfileResourceNamesProvider;
            private ISchemaNameMapProvider _schemaNameMapProvider;
            private SwaggerDocumentContext _swaggerDocumentContext;
            private IEnumerable<SwaggerResource> _actualFilteredResources;
            private IEnumerable<SwaggerResource> _expectedFilteredResources;

            private class TestProfileResourceNamesProvider : IProfileMetadataProvider
            {
                private readonly string _profileDefinition = @"<Profile name='Test-ParentNonAbstractBaseClass-ExcludeOnly'>
                                                <Resource name='StudentSpecialEducationProgramAssociation'>
                                                  <ReadContentType memberSelection='ExcludeOnly'>
                                                    <Property name='SpecialEducationHoursPerWeek'/>
                                                  </ReadContentType>
                                                  <WriteContentType memberSelection='IncludeAll'/>
                                                </Resource>
                                                <Resource name='GeneralStudentProgramAssociation'>
                                                  <ReadContentType memberSelection='IncludeOnly'/>
                                                </Resource>
                                              </Profile>";

                bool IProfileMetadataProvider.HasProfileData => true;

                public XElement GetProfileDefinition(string profileName)
                {
                    return XElement.Parse(_profileDefinition);
                }
            }

            protected override void Arrange()
            {
                _testProfileResourceNamesProvider = new TestProfileResourceNamesProvider();

                var studentProgramAssociation = _resourceModelProvider.GetResourceModel()
                                                                     .GetResourceByFullName(
                                                                          new FullName(
                                                                              EdFiConventions
                                                                                 .PhysicalSchemaName,
                                                                              "GeneralStudentProgramAssociation"));

                var studentSpecialEducationProgramAssociation = _resourceModelProvider
                                                               .GetResourceModel()
                                                               .GetResourceByFullName(
                                                                    new FullName(
                                                                        EdFiConventions
                                                                           .PhysicalSchemaName,
                                                                        "StudentSpecialEducationProgramAssociation"));

                _expectedFilteredResources = new[]
                                             {
                                                 new SwaggerResource(studentProgramAssociation)
                                                 {
                                                     Name = "generalStudentProgramAssociation_Readable", Readable = true
                                                 },
                                                 new SwaggerResource(studentProgramAssociation)
                                                 {
                                                     Name = "generalStudentProgramAssociation_Readable", Readable = true,
                                                     ContextualResource = studentSpecialEducationProgramAssociation
                                                 },
                                                 new SwaggerResource(studentProgramAssociation)
                                                 {
                                                     Name = "generalStudentProgramAssociation_StudentSpecialEducationProgramAssociation_Readable",
                                                     Readable = true
                                                 },
                                                 new SwaggerResource(studentProgramAssociation)
                                                 {
                                                     Name = "generalStudentProgramAssociation_StudentSpecialEducationProgramAssociation_Writable",
                                                     Writable = true
                                                 },
                                                 new SwaggerResource(studentSpecialEducationProgramAssociation)
                                                 {
                                                     Name = "studentSpecialEducationProgramAssociation_Readable", Readable = true
                                                 },
                                                 new SwaggerResource(studentSpecialEducationProgramAssociation)
                                                 {
                                                     Name = "studentSpecialEducationProgramAssociation_Writable", Writable = true
                                                 }
                                             };

                _schemaNameMapProvider = Stub<ISchemaNameMapProvider>();

                var profileResourceModel =
                    new ProfileResourceModel(
                        _resourceModelProvider.GetResourceModel(),
                        _testProfileResourceNamesProvider.GetProfileDefinition("ProfileName"));

                _swaggerDocumentContext =
                    new SwaggerDocumentContext(
                        _resourceModelProvider.GetResourceModel())
                    {
                        ProfileContext =
                            new SwaggerProfileContext
                            {
                                ProfileName = "ProfileName", ProfileResourceModel = profileResourceModel
                            }
                    };
            }

            protected override void Act()
            {
                _actualFilteredResources =
                    new OpenApiProfileStrategy().GetFilteredResources(_swaggerDocumentContext)
                                                .ToList();
            }

            [Assert]
            public void Should_not_return_empty_list_of_filtered_resources() 
            {
                _actualFilteredResources.ShouldNotBeEmpty();
            }

            [Assert]
            public void Should_return_a_list_of_swagger_resources_which_all_are_assigned_readable_or_writable()
            {
                _actualFilteredResources.ShouldAllBe(r => r.Readable || r.Writable);
            }

            [Assert]
            public void Should_return_a_list_of_swagger_resources_which_all_assigned_a_value_of_true_for_IsProfileResource()
            {
                _actualFilteredResources.ShouldAllBe(r => r.IsProfileResource);
            }

            [Assert]
            public void Should_return_comprehensive_list_of_swagger_resources_for_the_provided_profile()
            {
                AssertHelper.All(
                    _actualFilteredResources
                       .Select(
                            r =>
                                (Action)
                                (() => _expectedFilteredResources.Contains(r, new SwaggerResourceProfileComparer())
                                                                 .ShouldBeTrue()))
                       .ToArray());
            }

            [Assert]
            public void Should_not_contains_a_writable_swagger_resource_for_a_readonly_profile_resource()
            {
                _actualFilteredResources.ShouldNotContain(r => r.Name.EqualsIgnoreCase("GeneralStudentProgramAssociation") && r.Writable);
            }

            [Assert]
            public void Should_contain_correctly_named_derived_resource_if_profile_contains_corresponding_base_resource()
            {
                _actualFilteredResources.ShouldContain(
                        r => r.Name.EqualsIgnoreCase("generalStudentProgramAssociation_StudentSpecialEducationProgramAssociation_Readable"));
            }

            [Assert]
            public void Should_contain_a_base_resource_in_correct_context_when_derived_resource_present_in_profile()
            {
                _actualFilteredResources.ShouldContain(
                    r =>
                        r.Name.EqualsIgnoreCase("generalStudentProgramAssociation_Readable")
                        && r.Readable
                        && (r.ContextualResource != null
                            ? r.ContextualResource.Name
                            : null) == "StudentSpecialEducationProgramAssociation");
            }
        }
    }
}
