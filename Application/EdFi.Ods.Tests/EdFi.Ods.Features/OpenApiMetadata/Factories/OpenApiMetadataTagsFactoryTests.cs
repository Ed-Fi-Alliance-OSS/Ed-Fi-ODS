// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Factories
{
    [TestFixture]
    public class OpenApiMetadataTagsFactoryTests
    {
        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class When_creating_tags_for_a_list_of_resources_using_a_single_instance_or_year_specific_ods : TestFixtureBase
        {
            private IList<Tag> _actualTags;
            private string[] _actualTagNames;

            protected override void Act()
            {
                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualTags = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext,
                        new OpenApiMetadataDomainFilter(null))
                    .Create(openApiMetadataResources);

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

        public class When_creating_tags_with_domain_filtering_excluding_single_domain : TestFixtureBase
        {
            private IList<Tag> _actualTags;

            protected override void Act()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "SchoolCalendar"
                };

                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualTags = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext,
                        new OpenApiMetadataDomainFilter(apiSettings))
                    .Create(openApiMetadataResources);
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
            public void Should_include_resources_with_empty_or_null_domains()
            {
                // AbsenceEventCategoryDescriptor(Domains: Empty) tags should still be included
                var absenceEventCategoryDescriptorTags = _actualTags.Where(k => k.name.Contains("absenceEventCategoryDescriptors")).ToList();
                Assert.That(absenceEventCategoryDescriptorTags, Is.Not.Empty);
            }

            [Assert]
            public void Should_include_resources_with_mixed_domains_when_not_all_domains_are_excluded()
            {
                // GradingPeriod(Domains: SchoolCalendar, StudentAcademicRecord, ReportCard) tags should still be included
                var gradingPeriodTags = _actualTags.Where(k => k.name.Contains("gradingPeriods")).ToList();
                Assert.That(gradingPeriodTags, Is.Not.Empty);
            }

            [Assert]
            public void Should_exclude_resources_where_all_domains_are_excluded()
            {
                // AcademicWeek(Domains: SchoolCalendar) tags should be excluded
                var academicWeekTags = _actualTags.Where(k => k.name.Contains("academicWeeks")).ToList();
                Assert.That(academicWeekTags, Is.Empty);
            }
        }

        public class When_creating_tags_with_domain_filtering_excluding_multiple_domains : TestFixtureBase
        {
            private IList<Tag> _actualTags;

            protected override void Act()
            {
                // Create API settings that exclude multiple domains
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "SchoolCalendar, StudentAcademicRecord, ReportCard"
                };

                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualTags = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext,
                        new OpenApiMetadataDomainFilter(apiSettings))
                    .Create(openApiMetadataResources);
            }

            [Assert]
            public void Should_exclude_resources_from_excluded_domains()
            {
                // GradingPeriod(Domains: SchoolCalendar, StudentAcademicRecord, ReportCard) tags should be excluded
                var gradingPeriodTags = _actualTags.Where(k => k.name.Contains("gradingPeriods")).ToList();
                Assert.That(gradingPeriodTags, Is.Empty);
            }

            [Assert]
            public void Should_include_resources_from_non_excluded_domains()
            {
                // StudentAssessment(Domains: Assessment, StudentAssessment) tags should still be included
                var studentAssessmentTags = _actualTags.Where(k => k.name.Contains("studentAssessments")).ToList();
                Assert.That(studentAssessmentTags, Is.Not.Empty);
            }
        }

        public class When_creating_tags_with_empty_domain_exclusion_list : TestFixtureBase
        {
            private IList<Tag> _actualTags;

            protected override void Act()
            {
                // Create API settings with empty exclusion list
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = ""
                };

                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualTags = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext,
                        new OpenApiMetadataDomainFilter(apiSettings))
                    .Create(openApiMetadataResources);
            }

            [Assert]
            public void Should_include_all_resources_when_no_domains_are_excluded()
            {
                // All resources should be included when no domains are excluded
                var allResources = ResourceModelProvider.GetResourceModel().GetAllResources().ToList();
                var expectedTagCount = allResources.Count;

                Assert.That(_actualTags.Count, Is.EqualTo(expectedTagCount),
                    "All resources should be included when domain exclusion list is empty");
            }
        }

        public class When_creating_tags_with_null_api_settings : TestFixtureBase
        {
            private IList<Tag> _actualTags;

            protected override void Act()
            {
                var openApiMetadataResources = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Select(r => new OpenApiMetadataResource(r))
                    .ToList();

                _actualTags = OpenApiMetadataDocumentFactoryHelper.CreateOpenApiMetadataTagsFactory(
                        DomainModelDefinitionsProviderHelper.DefaultopenApiMetadataDocumentContext,
                        new OpenApiMetadataDomainFilter(null))
                    .Create(openApiMetadataResources);
            }

            [Assert]
            public void Should_include_all_resources_when_api_settings_is_null()
            {
                // All resources should be included when no domains are excluded
                var allResources = ResourceModelProvider.GetResourceModel().GetAllResources().ToList();
                var expectedTagCount = allResources.Count;

                Assert.That(_actualTags.Count, Is.EqualTo(expectedTagCount),
                    "All resources should be included when domain exclusion list is empty");
            }
        }
    }
}