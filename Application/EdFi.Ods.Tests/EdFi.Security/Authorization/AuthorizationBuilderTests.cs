// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Security.Authorization
{
    public class Feature_building_claims_authorization_segments
    {
        public class When_building_a_single_segment_for_a_claimset_that_has_no_education_organization_identifiers
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values

            protected override void Act()
            {
                // Execute code under test
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_that_has_no_educationOrganizations(),
                    Given_a_cache_that_indicates_no_organizations_exist(),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI);

                builder.GetSegments();
            }

            [Assert]
            public void Should_throw_a_security_exception_indicating_there_were_no_claim_values_available()
            {
                ActualException.ShouldBeExceptionType<EdFiSecurityException>();
            }
        }

        public class When_building_a_single_segment_for_a_Local_Education_Agency_that_does_not_exist
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values

            protected override void Act()
            {
                // Execute code under test
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_for_some_LocalEducationAgency(),
                    Given_a_cache_that_indicates_no_organizations_exist(),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI);

                builder.GetSegments();
            }

            [Assert]
            public void Should_throw_a_security_exception_indicating_there_were_no_claim_values_available()
            {
                ActualException.ShouldBeExceptionType<EdFiSecurityException>();
            }
        }

        public class When_building_a_single_segment_for_two_Local_Education_Agencies_where_one_exists_and_one_does_not
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private IReadOnlyList<ClaimsAuthorizationSegment> _actualSegments;

            protected override void Act()
            {
                // Execute code under test
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_for_LocalEducationAgencies(888, 999),
                    Given_a_cache_that_indicates_the_only_EducationOrganizationId_that_exists_is(888),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith(x => x.StaffUSI);

                _actualSegments = builder.GetSegments();
            }

            [Assert]
            public void Should_return_a_segment_with_the_existing_LocalEducationAgencyId_as_the_value()
            {
                _actualSegments.Count.ShouldBe(1);

                _actualSegments.First()
                               .ClaimsEndpoints.Single()
                               .Value.ShouldBe(888);
            }
        }

        public class When_building_segments_using_a_string_array_of_2_property_names
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private IReadOnlyList<ClaimsAuthorizationSegment> _actualSegments;

            protected override void Act()
            {
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_for_some_LocalEducationAgency(),
                    Given_a_cache_that_indicates_all_education_organizations_exist_and_are_schools(),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith(
                    new[]
                    {
                        "StudentUSI", "StaffUSI"
                    });

                _actualSegments = builder.GetSegments();
            }

            [Assert]
            public void Should_create_a_segment_for_each_supplied_property_name()
            {
                _actualSegments.Count.ShouldBe(2);
            }

            [Assert]
            public void Should_create_first_segment_as_a_school_to_the_first_supplied_property_name()
            {
                _actualSegments.ElementAt(0)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(0)
                               .SubjectEndpoint.Name.ShouldBe("StudentUSI");
            }

            [Assert]
            public void Should_create_second_segment_as_a_school_to_the_second_supplied_property_name()
            {
                _actualSegments.ElementAt(1)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(1)
                               .SubjectEndpoint.Name.ShouldBe("StaffUSI");
            }
        }

        public class When_building_segments_using_2_calls_with_individual_property_names
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private IReadOnlyList<ClaimsAuthorizationSegment> _actualSegments;

            protected override void Act()
            {
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_for_some_LocalEducationAgency(),
                    Given_a_cache_that_indicates_all_education_organizations_exist_and_are_schools(),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith("StudentUSI");
                builder.ClaimsMustBeAssociatedWith("StaffUSI");

                _actualSegments = builder.GetSegments();
            }

            [Assert]
            public void Should_create_a_segment_for_each_supplied_property_name()
            {
                _actualSegments.Count.ShouldBe(2);
            }

            [Assert]
            public void Should_create_first_segment_as_a_school_to_the_first_supplied_property_name()
            {
                _actualSegments.ElementAt(0)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(0)
                               .SubjectEndpoint.Name.ShouldBe("StudentUSI");
            }

            [Assert]
            public void Should_create_second_segment_as_a_school_to_the_second_supplied_property_name()
            {
                _actualSegments.ElementAt(1)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(1)
                               .SubjectEndpoint.Name.ShouldBe("StaffUSI");
            }
        }

        public class When_building_segments_using_2_calls_with_individual_property_names_and_one_with_an_authorization_path_modifier
            : LegacyTestFixtureBase
        {
            // Supplied values

            // Actual values
            private IReadOnlyList<ClaimsAuthorizationSegment> _actualSegments;

            protected override void Act()
            {
                var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                    Given_a_claimset_with_a_claim_for_some_LocalEducationAgency(),
                    Given_a_cache_that_indicates_all_education_organizations_exist_and_are_schools(),
                    Given_authorization_context_data_with_some_StaffUniqueId());

                builder.ClaimsMustBeAssociatedWith("StudentUSI", "OverTheRiverAndThroughTheWoods");
                builder.ClaimsMustBeAssociatedWith("StaffUSI");

                _actualSegments = builder.GetSegments();
            }

            [Assert]
            public void Should_create_a_segment_for_each_supplied_property_name()
            {
                _actualSegments.Count.ShouldBe(2);
            }

            [Assert]
            public void
                Should_create_first_segment_as_a_school_to_the_first_supplied_property_name_with_the_supplied_authorization_path_modifer_intact()
            {
                _actualSegments.ElementAt(0)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(0)
                               .SubjectEndpoint.Name.ShouldBe("StudentUSI");

                _actualSegments.ElementAt(0)
                               .AuthorizationPathModifier.ShouldBe("OverTheRiverAndThroughTheWoods");
            }

            [Assert]
            public void Should_create_second_segment_as_a_school_to_the_second_supplied_property_name_with_no_authorization_path_modifier()
            {
                _actualSegments.ElementAt(1)
                               .ClaimsEndpoints.All(x => x.Name == "SchoolId")
                               .ShouldBeTrue();

                _actualSegments.ElementAt(1)
                               .SubjectEndpoint.Name.ShouldBe("StaffUSI");

                _actualSegments.ElementAt(1)
                               .AuthorizationPathModifier.ShouldBeNull();
            }
        }

        #region Givens

        private static IEducationOrganizationCache Given_a_cache_that_indicates_no_organizations_exist()
        {
            return MockRepository.GenerateStub<IEducationOrganizationCache>();
        }

        private static IEducationOrganizationCache Given_a_cache_that_indicates_all_education_organizations_exist_and_are_schools()
        {
            var educationOrganizationCache = MockRepository.GenerateStub<IEducationOrganizationCache>();

            educationOrganizationCache.Stub(x => x.GetEducationOrganizationIdentifiers(Arg<int>.Is.Anything))
                                      .Return(new EducationOrganizationIdentifiers(0, "School"));

            return educationOrganizationCache;
        }

        private static IEnumerable<Claim> Given_a_claimset_with_a_claim_for_some_LocalEducationAgency()
        {
            return new[]
                   {
                       JsonClaimHelper.CreateClaim(
                           "someResource",
                           new EdFiResourceClaimValue(
                               "something",
                               new List<int>
                               {
                                   999
                               }))
                   };
        }

        private static IEducationOrganizationCache Given_a_cache_that_indicates_the_only_EducationOrganizationId_that_exists_is(
            int educationOrganizationId)
        {
            var educationOrganizationCache = MockRepository.GenerateStub<IEducationOrganizationCache>();

            educationOrganizationCache.Stub(x => x.GetEducationOrganizationIdentifiers(educationOrganizationId))
                                      .Return(
                                           new EducationOrganizationIdentifiers(educationOrganizationId, "LocalEducationAgency"));

            return educationOrganizationCache;
        }

        private static IEnumerable<Claim> Given_a_claimset_with_a_claim_for_LocalEducationAgencies(params int[] localEducationAgencyIds)
        {
            return new[]
                   {
                       JsonClaimHelper.CreateClaim(
                           "someResource",
                           new EdFiResourceClaimValue("something", new List<int>(localEducationAgencyIds)))
                   };
        }

        private static IEnumerable<Claim> Given_a_claimset_with_a_claim_that_has_no_educationOrganizations()
        {
            return new[]
                   {
                       JsonClaimHelper.CreateClaim(
                           "someResource",
                           new EdFiResourceClaimValue("something", null as List<int>))
                   };
        }

        private static RelationshipsAuthorizationContextData
            Given_authorization_context_data_with_some_StaffUniqueId()
        {
            return new RelationshipsAuthorizationContextData
            {
                StaffUSI = 1234
            };
        }

        #endregion
    }

    public class
        When_building_authorization_segments_for_LocalEducationAgency_claims_to_be_associated_with_a_StaffUniqueId_and_a_simple_value_association_rule_for_the_contextual_School_to_be_associated_with_the_StaffUniqueId
        : LegacyTestFixtureBase
    {
        private ClaimsAuthorizationSegment _actualLocalEducationAgencySegment;

        // Dependencies
        private IEducationOrganizationCache _educationOrganizationCache;
        private EdFiResourceClaimValue _suppliedEdFiResourceClaimValue;

        // Actual values
        private IReadOnlyList<ClaimsAuthorizationSegment> actualAuthorizationSegments;
        private List<Claim> suppliedClaims;

        // Supplied values
        private RelationshipsAuthorizationContextData suppliedContextData;

        protected override void EstablishContext()
        {
            #region Commented out code for integration testing against SQL Server

            //private IDatabaseConnectionStringProvider connectionStringProvider;

            //connectionStringProvider = mocks.Stub<IDatabaseConnectionStringProvider>();
            //connectionStringProvider.Stub(x => x.GetConnectionString())
            //    .Return(@"Server=(local);Database=database;User Id=user;Password=xxxxx");

            //var executor = new EdFiOdsAuthorizationRulesExecutor(connectionStringProvider);
            //executor.Execute(actualAuthorizationRules);

            #endregion

            suppliedContextData = new RelationshipsAuthorizationContextData
            {
                SchoolId = 880001,
                StaffUSI = 738953 //340DFAFA-D39B-4A38-BEA4-AD705CC7EB7C
            };

            _suppliedEdFiResourceClaimValue = new EdFiResourceClaimValue(
                "manage",
                new List<int>
                {
                    780, 880, 980
                });

            suppliedClaims = new List<Claim>
                             {
                                 JsonClaimHelper.CreateClaim(
                                     "http://ed-fi.org/ods/identity/claims/domains/generalData",
                                     _suppliedEdFiResourceClaimValue)
                             };

            _educationOrganizationCache = Stub<IEducationOrganizationCache>();

            _educationOrganizationCache.Stub(
                                            x =>
                                                x.GetEducationOrganizationIdentifiers(Arg<int>.Is.Anything))
                                       .Return(new EducationOrganizationIdentifiers(0, "LocalEducationAgency"));
        }

        protected override void ExecuteBehavior()
        {
            var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                suppliedClaims,
                _educationOrganizationCache,
                suppliedContextData);

            actualAuthorizationSegments = builder
                                         .ClaimsMustBeAssociatedWith(x => x.StaffUSI)
                                         .GetSegments();

            _actualLocalEducationAgencySegment = actualAuthorizationSegments.SingleOrDefault(
                s =>
                    s.SubjectEndpoint.Name == "LocalEducationAgencyId"
                    || s.ClaimsEndpoints.All(
                        x => x.Name == "LocalEducationAgencyId"));
        }

        [Test]
        public void Should_create_1_claims_authorization_segment()
        {
            actualAuthorizationSegments.Count().ShouldBe(1);
        }

        [Test]
        public void Should_require_the_StaffUSI_to_be_associated_with_one_of_the_claims_LocalEducationAgencyIds()
        {
            var staffUniqueIdEndpointWithValue = _actualLocalEducationAgencySegment.SubjectEndpoint
                as AuthorizationSegmentEndpointWithValue;

            staffUniqueIdEndpointWithValue.ShouldNotBeNull(
                "The staffUSI endpoint in the claims based authorization segment did not have a contextual value.");

            staffUniqueIdEndpointWithValue.Name.ShouldBe("StaffUSI");
            staffUniqueIdEndpointWithValue.Value.ShouldBe(suppliedContextData.StaffUSI);

            // Make sure the counts are the same
            _actualLocalEducationAgencySegment.ClaimsEndpoints.Count()
                                              .ShouldBe(_suppliedEdFiResourceClaimValue.EducationOrganizationIds.Count);

            // Make sure all the LEA Ids are present
            _actualLocalEducationAgencySegment.ClaimsEndpoints.Select(x => (int)x.Value)
                                              .All(cv => _suppliedEdFiResourceClaimValue.EducationOrganizationIds.Contains(cv))
                                              .ShouldBeTrue();

            _actualLocalEducationAgencySegment.ClaimsEndpoints.Select(x => x.Name)
                                              .All(n => n == "LocalEducationAgencyId")
                                              .ShouldBeTrue();
        }

        [Test]
        public void Should_return_a_LocalEducationAgency_segment()
        {
            _actualLocalEducationAgencySegment.ShouldNotBeNull();
        }

        [Test]
        public void Should_target_the_StaffUniqueId_by_name_and_contextual_value_in_the_LocalEducationAgency_segment()
        {
            _actualLocalEducationAgencySegment.SubjectEndpoint.Name.ShouldBe("StaffUSI");
            var endpointWithValue = _actualLocalEducationAgencySegment.SubjectEndpoint as AuthorizationSegmentEndpointWithValue;

            endpointWithValue.ShouldNotBeNull(
                "The target endpoint of the claim authorization segment endpoint did not contain a value from the supplied context.");

            endpointWithValue.Value.ShouldBe(suppliedContextData.StaffUSI);
        }
    }

    public class
        When_building_authorization_segments_for_LocalEducationAgency_claims_to_be_associated_with_a_Student_with_an_alternative_authorization_path
        : LegacyTestFixtureBase
    {
        private ClaimsAuthorizationSegment _actualLocalEducationAgencySegment;

        // Dependencies
        private IEducationOrganizationCache _educationOrganizationCache;
        private EdFiResourceClaimValue _suppliedEdFiResourceClaimValue;

        // Actual values
        private IReadOnlyList<ClaimsAuthorizationSegment> _actualAuthorizationSegments;
        private List<Claim> suppliedClaims;

        // Supplied values
        private RelationshipsAuthorizationContextData suppliedContextData;

        protected override void EstablishContext()
        {
            suppliedContextData = new RelationshipsAuthorizationContextData
            {
                StudentUSI = 11111
            };

            _suppliedEdFiResourceClaimValue = new EdFiResourceClaimValue(
                "manage",
                new List<int>
                {
                    1, 2, 3
                });

            suppliedClaims = new List<Claim>
                             {
                                 JsonClaimHelper.CreateClaim(
                                     "http://ed-fi.org/ods/identity/claims/domains/generalData",
                                     _suppliedEdFiResourceClaimValue)
                             };

            _educationOrganizationCache = Stub<IEducationOrganizationCache>();

            _educationOrganizationCache.Stub(
                                            x =>
                                                x.GetEducationOrganizationIdentifiers(Arg<int>.Is.Anything))
                                       .Return(new EducationOrganizationIdentifiers(0, "LocalEducationAgency"));
        }

        protected override void ExecuteBehavior()
        {
            var builder = new AuthorizationBuilder<RelationshipsAuthorizationContextData>(
                suppliedClaims,
                _educationOrganizationCache,
                suppliedContextData);

            _actualAuthorizationSegments = builder
                                          .ClaimsMustBeAssociatedWith(x => x.StudentUSI, "OverTheRiverAndThroughTheWoods")
                                          .GetSegments();

            _actualLocalEducationAgencySegment = _actualAuthorizationSegments.FirstOrDefault(
                s =>
                    s.SubjectEndpoint.Name == "LocalEducationAgencyId"
                    || s.ClaimsEndpoints.All(
                        x => x.Name == "LocalEducationAgencyId"));
        }

        [Assert]
        public void Should_use_authorization_path_modifier_for_authorizing_the_segment()
        {
            Assert.That(
                _actualLocalEducationAgencySegment.AuthorizationPathModifier,
                Is.EqualTo("OverTheRiverAndThroughTheWoods"));
        }

        [Test]
        public void Should_create_a_single_claims_authorization_segment()
        {
            _actualAuthorizationSegments.Count().ShouldBe(1);
        }

        [Test]
        public void Should_require_the_StudentUSI_to_be_associated_with_one_of_the_claims_LocalEducationAgencyIds()
        {
            var studentUSIEndpointWithValue = _actualLocalEducationAgencySegment.SubjectEndpoint
                as AuthorizationSegmentEndpointWithValue;

            studentUSIEndpointWithValue.ShouldNotBeNull(
                "The StudentUSI endpoint in the claims based authorization segment did not have a contextual value.");

            studentUSIEndpointWithValue.Name.ShouldBe("StudentUSI");
            studentUSIEndpointWithValue.Value.ShouldBe(suppliedContextData.StudentUSI);

            // Make sure the counts are the same
            _actualLocalEducationAgencySegment.ClaimsEndpoints.Count()
                                              .ShouldBe(_suppliedEdFiResourceClaimValue.EducationOrganizationIds.Count);

            // Make sure all the LEA Ids are present
            _actualLocalEducationAgencySegment.ClaimsEndpoints.Select(x => (int)x.Value)
                                              .All(cv => _suppliedEdFiResourceClaimValue.EducationOrganizationIds.Contains(cv))
                                              .ShouldBeTrue();

            _actualLocalEducationAgencySegment.ClaimsEndpoints.Select(x => x.Name)
                                              .All(n => n == "LocalEducationAgencyId")
                                              .ShouldBeTrue();
        }

        [Test]
        public void Should_return_a_LocalEducationAgency_segment()
        {
            _actualLocalEducationAgencySegment.ShouldNotBeNull();
        }

        [Test]
        public void Should_target_the_StaffUniqueId_by_name_and_contextual_value_in_the_LocalEducationAgency_segment()
        {
            _actualLocalEducationAgencySegment.SubjectEndpoint.Name.ShouldBe("StudentUSI");
            var endpointWithValue = _actualLocalEducationAgencySegment.SubjectEndpoint as AuthorizationSegmentEndpointWithValue;

            endpointWithValue.ShouldNotBeNull(
                "The target endpoint of the claim authorization segment endpoint did not contain a value from the supplied context.");

            endpointWithValue.Value.ShouldBe(suppliedContextData.StudentUSI);
        }
    }
}
