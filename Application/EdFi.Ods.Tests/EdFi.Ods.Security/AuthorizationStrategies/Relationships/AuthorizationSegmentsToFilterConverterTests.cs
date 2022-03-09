// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.TestFixture;
using FakeItEasy;
using FakeItEasy.Configuration;
using NHibernate;
using NHibernate.Metadata;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    // -------------------------------------------------------
    // NOTE: This is an exploratory style of unit testing.
    // -------------------------------------------------------
    public static class Feature_Converting_segments_to_filters_Extensions
    {
        public static IReturnValueArgumentValidationConfiguration<IClassMetadata> that_given_entity_type(
            this ISessionFactory dependency,
            Type entity)
        {
            return A.CallTo(() => dependency.GetClassMetadata(entity));
        }

        public static IClassMetadata that_returns_property_names(
            this IClassMetadata dependency,
            string[] propertyNames)
        {
            A.CallTo(() => dependency.PropertyNames)
                .Returns(propertyNames);

            return dependency;
        }

        public static IEducationOrganizationCache that_returns_everything_as_an_education_organization_type_of(
            this IEducationOrganizationCache dependency,
            string educationOrganizationType)
        {
            A.CallTo(() => dependency.GetEducationOrganizationIdentifiers(999))
                .Returns(new EducationOrganizationIdentifiers(999, educationOrganizationType));

            return dependency;
        }

        public static IReturnValueArgumentValidationConfiguration<EducationOrganizationIdentifiers>
            that_given_education_organization_id(
            this IEducationOrganizationCache dependency,
            int identifier)
        {
            return A.CallTo(() => dependency.GetEducationOrganizationIdentifiers(identifier));
        }
    }

    public class Feature_Converting_segments_to_filters
    {
        private static AuthorizationBuilder<RelationshipsAuthorizationContextData>
            Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
            IEducationOrganizationCache cache,
            params int[] identifiers)
        {
            var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                new[]
                {
                    JsonClaimHelper.CreateClaim(
                        "someResource", new EdFiResourceClaimValue("action", new List<int>(identifiers)))
                },
                cache);

            return builder;
        }

        public class TestEntityType { }

        public class When_converting_to_filters_from_an_empty_segments_collection
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            protected override void Act()
            {
                _actualFilters = SystemUnderTest.Convert(new ClaimsAuthorizationSegment[0]);
            }

            [Assert]
            public void Should_return_a_null_filters_dictionary()
            {
                _actualFilters.Count.ShouldBe(0);
            }
        }

        public class When_converting_to_filters_from_a_single_segment_for_a_LocalEducationAgency_claim_to_SchoolId
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            // Actual values
            protected override void Arrange()
            {
                Given<IClassMetadata>()
                    .that_returns_property_names(new string[0]);

                Given<ISessionFactory>()
                    .that_given_entity_type(Supplied("entityType", typeof(TestEntityType)))
                    .Returns(The<IClassMetadata>());

                Given<IEducationOrganizationCache>()
                    .that_returns_everything_as_an_education_organization_type_of("LocalEducationAgency");

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999);

                builder.ClaimsMustBeAssociatedWith(x => x.SchoolId);
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void Should_create_a_single_filter_named_for_the_segment_endpoint_values()
            {
                _actualFilters.Count.ShouldBe(1);

                _actualFilters.Single().FilterName.ShouldBe($"{RelationshipAuthorizationConventions.FilterNamePrefix}ToSchoolId");
            }

            [Assert]
            public void Should_assign_parameter_value_matching_the_claim_education_organization_type_and_value()
            {
                var actualFilter = _actualFilters.Single();
                var parameterValues = actualFilter.ClaimParameterValues as object[];

                parameterValues.Count().ShouldBe(1);

                actualFilter.ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName);

                parameterValues
                    .ShouldBe(
                        new object[] {999});
            }
        }

        public class
            When_converting_to_filters_from_a_single_segment_for_a_LocalEducationAgency_claim_to_a_StudentUSI_using_an_authorization_path_modifier
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            // Actual values
            protected override void Arrange()
            {
                Given<IClassMetadata>()
                    .that_returns_property_names(new string[0]);

                Given<ISessionFactory>()
                    .that_given_entity_type(Supplied("entityType", typeof(TestEntityType)))
                    .Returns(The<IClassMetadata>());

                Given<IEducationOrganizationCache>()
                    .that_returns_everything_as_an_education_organization_type_of("LocalEducationAgency");

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999);

                builder.ClaimsMustBeAssociatedWith(x => x.StudentUSI, "OverTheRiverAndThroughTheWoods");
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void
                Should_create_a_single_filter_named_for_the_segment_endpoint_values_applying_the_authorization_path_modifier_as_a_suffix()
            {
                _actualFilters.Count.ShouldBe(1);

                _actualFilters.Single().FilterName
                    .ShouldBe($"{RelationshipAuthorizationConventions.FilterNamePrefix}ToStudentUSIOverTheRiverAndThroughTheWoods");
            }

            [Assert]
            public void Should_assign_parameter_value_matching_the_claim_education_organization_type_and_value()
            {
                var actualFilter = _actualFilters.Single();
                var parameterValues = actualFilter.ClaimParameterValues as object[];

                parameterValues.Count().ShouldBe(1);

                actualFilter.ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName);

                parameterValues
                    .ShouldBe(
                        new object[] {999});
            }
        }

        public class When_converting_to_filters_from_segments_that_have_multiple_education_organization_types
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            // Supplied values

            // Actual values
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            // Dependencies

            protected override void Arrange()
            {
                Given<IEducationOrganizationCache>()
                    .that_given_education_organization_id(999)
                    .Returns(new EducationOrganizationIdentifiers(999, "LocalEducationAgency"));

                Given<IEducationOrganizationCache>()
                    .that_given_education_organization_id(1000)
                    .Returns(new EducationOrganizationIdentifiers(1000, "School"));

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999,
                    1000);

                builder.ClaimsMustBeAssociatedWith(x => x.SchoolId);
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void Should_NOT_throw_a_NotSupportedException()
            {
                ActualException.ShouldNotBeOfType<NotSupportedException>();
            }

            [Assert]
            public void Should_return_ONE_combined_filter()
            {
                _actualFilters.ShouldSatisfyAllConditions(
                    () => _actualFilters.Count.ShouldBe(1),
                    () => _actualFilters[0].FilterName.ShouldBe($"{RelationshipAuthorizationConventions.FilterNamePrefix}ToSchoolId"),
                    () => _actualFilters[0].ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName),
                    () => _actualFilters[0].SubjectEndpointName.ShouldBe("SchoolId"),
                    () => _actualFilters[0].ClaimParameterValues.ShouldBe(new object[] { 999, 1000 }));
            }
        }

        public class When_converting_to_filters_from_a_segment_that_have_the_same_endpoint_types
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            protected override void Arrange()
            {
                Given<IEducationOrganizationCache>()
                    .that_given_education_organization_id(999)
                    .Returns(new EducationOrganizationIdentifiers(999, "LocalEducationAgency"));

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999);

                builder.ClaimsMustBeAssociatedWith(x => x.LocalEducationAgencyId);
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void Should_create_a_single_filter_named_for_the_matching_segment_endpoint_types()
            {
                _actualFilters.Count.ShouldBe(1);

                _actualFilters.Single().FilterName
                    .ShouldBe($"{RelationshipAuthorizationConventions.FilterNamePrefix}ToLocalEducationAgencyId");
            }

            [Assert]
            public void Should_assign_parameter_value_matching_the_claim_education_organization_type_and_value()
            {
                var actualFilter = _actualFilters.Single();
                var parameterValues = actualFilter.ClaimParameterValues as object[];

                parameterValues.Count().ShouldBe(1);

                actualFilter.ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName);

                parameterValues
                    .ShouldBe(
                        new object[] {999});
            }
        }

        public class When_converting_to_filters_from_multiple_segments_with_the_same_target_types
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            protected override void Arrange()
            {
                Given<IEducationOrganizationCache>()
                    .that_given_education_organization_id(999)
                    .Returns(new EducationOrganizationIdentifiers(999, "LocalEducationAgency"));

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999);

                builder.ClaimsMustBeAssociatedWith(x => x.SchoolId);
                builder.ClaimsMustBeAssociatedWith(x => x.SchoolId);
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void Should_not_include_redundant_values_in_the_filter_values()
            {
                var actualFilter = _actualFilters.Single();
                var parameterValues = actualFilter.ClaimParameterValues;

                parameterValues.Count().ShouldBe(1);

                actualFilter.ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName);

                parameterValues
                    .ShouldBe(
                        new object[] {999});
            }
        }

        public class
            When_converting_to_filters_from_a_segment_with_a_target_endpoint_that_is_a_uniqueId_for_an_entity_WITHOUT_a_uniqueId_property
            : ScenarioFor<AuthorizationSegmentsToFiltersConverter>
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            protected override void Arrange()
            {
                Given<IEducationOrganizationCache>()
                    .that_given_education_organization_id(999)
                    .Returns(new EducationOrganizationIdentifiers(999, "LocalEducationAgency"));

                var builder = Given_an_authorization_builder_with_claim_assigned_education_organization_ids(
                    The<IEducationOrganizationCache>(),
                    999);

                builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI);
                Supplied(builder.GetSegments());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilters = SystemUnderTest.Convert(
                    Supplied<IReadOnlyList<ClaimsAuthorizationSegment>>());
            }

            [Assert]
            public void
                Should_convert_UniqueId_properties_to_USI_in_the_constructed_view_name_when_the_property_DOES_NOT_exist_on_the_targeted_entity()
            {
                var filter = _actualFilters.Single();
                var viewName = filter.FilterName;

                viewName.ShouldNotContain("ToStaffUniqueId");
                viewName.ShouldContain("ToStaffUSI");
            }
        }

        [TestFixture]
        public class When_converting_to_filters_with_multiple_types_of_EdOrgs : TestFixtureBase
        {
            private IReadOnlyList<AuthorizationFilterDetails> _actualFilters;

            protected override void Act()
            {
                var claimsAndValues = new[]
                {
                    Tuple.Create("LocalEducationAgencyId", (object) 12456),
                    Tuple.Create("PostSecondaryInstitutionId", (object) 987654),
                };

                var studentSegmentEndpoint = new AuthorizationSegmentEndpoint("StudentUSI", typeof(int));
                
                var suppliedSegments = new[]
                {
                    new ClaimsAuthorizationSegment(claimsAndValues, studentSegmentEndpoint)
                };
                
                var converter = new AuthorizationSegmentsToFiltersConverter();
                _actualFilters = converter.Convert(suppliedSegments);
            }

            [Test]
            public void Should_combine_EdOrg_types_into_a_single_filter()
            {
                _actualFilters.Count.ShouldBe(1);
            }

            [Test]
            public void Should_rename_the_EdOrg_based_claim_endpoint_name_to_the_generalized_convention()
            {
                _actualFilters.Single().ClaimParameterName.ShouldBe(RelationshipAuthorizationConventions.ClaimsParameterName);
            }
            
            [Test]
            public void Should_combine_the_EdOrgIds_into_a_single_array()
            {
                var claimValues = _actualFilters.Single().ClaimParameterValues;
                    
                claimValues.ShouldBe(new object[] { 12456, 987654 });
            }
        }
    }
}
