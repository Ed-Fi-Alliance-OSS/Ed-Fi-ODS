// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.NHibernate.AbsenceEventCategoryDescriptorAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentItemAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentScoreRangeLearningStandardAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.BalanceSheetDimensionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi;
using EdFi.Ods.Features.OpenApiMetadata.Strategies;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Strategies
{
    [TestFixture]
    public class OpenApiMetadataDomainFilterTests : TestFixtureBase
    {
        protected IDomainModelProvider _domainModelProvider;
        protected override void Arrange()
        {
            _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;
        }

        public class When_creating_filter_with_null_api_settings : OpenApiMetadataDomainFilterTests
        {
            private OpenApiMetadataDomainFilter _filter;
            private Entity _entityToTest;

            protected override void Act()
            {
                _filter = new OpenApiMetadataDomainFilter(null);
                var domainModel = _domainModelProvider.GetDomainModel();
                _entityToTest = domainModel.GetEntity<AssessmentItem>();   //Domains: Assessment, AssessmentMetadata
            }

            [Test]
            public void Should_not_have_exclusions()
            {
                Assert.That(_filter.HasExclusions, Is.False);
            }

            [Test]
            public void Should_not_exclude_any_entity()
            {
                Assert.That(_filter.ShouldExcludeByDomain(_entityToTest), Is.False);
            }
        }

        public class When_creating_filter_with_empty_exclusion_list : OpenApiMetadataDomainFilterTests
        {
            private OpenApiMetadataDomainFilter _filter;

            protected override void Act()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "   "
                };
                _filter = new OpenApiMetadataDomainFilter(apiSettings);
            }

            [Test]
            public void Should_not_have_exclusions()
            {
                Assert.That(_filter.HasExclusions, Is.False);
            }

            [Test]
            public void Should_not_exclude_any_entity()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentItem>();   //Domains: Assessment, AssessmentMetadata

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }
        }

        public class When_creating_filter_with_single_domain_exclusion : OpenApiMetadataDomainFilterTests
        {
            private OpenApiMetadataDomainFilter _filter;

            protected override void Act()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "Assessment"
                };
                _filter = new OpenApiMetadataDomainFilter(apiSettings);
            }

            [Test]
            public void Should_have_exclusions()
            {
                Assert.That(_filter.HasExclusions, Is.True);
            }

            [Test]
            public void Should_exclude_entity_with_only_excluded_domain()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentScoreRangeLearningStandard>(); //Domains: Assessment

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.True);
            }

            [Test]
            public void Should_not_exclude_entity_with_mixed_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentItem>();   //Domains: Assessment, AssessmentMetadata

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }

            [Test]
            public void Should_not_exclude_entity_with_non_excluded_domain()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<BalanceSheetDimension>();    //Domains: Finance

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }

            [Test]
            public void Should_not_exclude_entity_with_empty_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AbsenceEventCategoryDescriptor>();   //Domains: Empty

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }

            [Test]
            public void Should_not_exclude_null_entity()
            {
                Assert.That(_filter.ShouldExcludeByDomain(null), Is.False);
            }
        }

        public class When_creating_filter_with_multiple_domain_exclusions : OpenApiMetadataDomainFilterTests
        {
            private OpenApiMetadataDomainFilter _filter;

            protected override void Act()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "AssessmentMetadata, Assessment "
                };
                _filter = new OpenApiMetadataDomainFilter(apiSettings);
            }

            [Test]
            public void Should_have_exclusions()
            {
                Assert.That(_filter.HasExclusions, Is.True);
            }

            [Test]
            public void Should_contain_all_excluded_domains()
            {
                Assert.That(_filter.ExcludedDomains, Contains.Item("AssessmentMetadata"));
                Assert.That(_filter.ExcludedDomains, Contains.Item("Assessment"));
                Assert.That(_filter.ExcludedDomains.Count, Is.EqualTo(2));
            }

            [Test]
            public void Should_exclude_entity_with_only_excluded_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentScoreRangeLearningStandard>(); //Domains: Assessment

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.True);
            }

            [Test]
            public void Should_exclude_entity_with_matching_excluded_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentItem>();   //Domains: Assessment, AssessmentMetadata

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.True);
            }

            [Test]
            public void Should_not_exclude_entity_with_mixed_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<StudentAssessment>();   //Domains: Assessment, StudentAssessment

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }

            [Test]
            public void Should_not_exclude_entity_with_non_excluded_domains()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<BalanceSheetDimension>();    //Domains: Finance

                Assert.That(_filter.ShouldExcludeByDomain(entity), Is.False);
            }
        }

        public class When_testing_case_insensitive_domain_matching : OpenApiMetadataDomainFilterTests
        {
            [TestCase("Assessment")]
            [TestCase("assessment")]
            [TestCase("ASSESSMENT")]
            public void Should_exclude_entity_regardless_of_case(string excludedDomain)
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = excludedDomain
                };
                var filter = new OpenApiMetadataDomainFilter(apiSettings);

                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<AssessmentScoreRangeLearningStandard>(); //Domains: Assessment

                Assert.That(filter.ShouldExcludeByDomain(entity), Is.True);
            }
        }

        public class When_testing_whitespace_handling : OpenApiMetadataDomainFilterTests
        {
            [Test]
            public void Should_handle_whitespace_in_exclusion_list()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "  Student  ,  Assessment  ,  ,  EdOrg  "
                };
                var filter = new OpenApiMetadataDomainFilter(apiSettings);

                Assert.That(filter.HasExclusions, Is.True);
                Assert.That(filter.ExcludedDomains, Contains.Item("Student"));
                Assert.That(filter.ExcludedDomains, Contains.Item("Assessment"));
                Assert.That(filter.ExcludedDomains, Contains.Item("EdOrg"));
                Assert.That(filter.ExcludedDomains.Count, Is.EqualTo(3));
            }

            [Test]
            public void Should_ignore_empty_entries_in_exclusion_list()
            {
                var apiSettings = new ApiSettings
                {
                    DomainsExcludedFromOpenApi = "Student,,Assessment,,,"
                };
                var filter = new OpenApiMetadataDomainFilter(apiSettings);

                Assert.That(filter.ExcludedDomains.Count, Is.EqualTo(2));
                Assert.That(filter.ExcludedDomains, Contains.Item("Student"));
                Assert.That(filter.ExcludedDomains, Contains.Item("Assessment"));
            }
        }
    }
}
