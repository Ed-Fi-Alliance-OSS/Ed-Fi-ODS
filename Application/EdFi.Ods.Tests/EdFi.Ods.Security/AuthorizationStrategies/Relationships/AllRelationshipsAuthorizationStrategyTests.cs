// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using FakeItEasy.Configuration;
using NUnit.Framework;
using QuickGraph;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    using context_data_provider = IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>;
    using context_data_provider_factory = IRelationshipsAuthorizationContextDataProviderFactory<RelationshipsAuthorizationContextData>;

    // Dependency type aliases (for readability)
    using context_data_transformer = IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>;
    using edorgs_and_people_strategy = RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>;
    using education_organization_cache = IEducationOrganizationCache;
    using education_organization_hierarchy_provider = IEducationOrganizationHierarchyProvider;
    using segments_to_filters_converter = IAuthorizationSegmentsToFiltersConverter;

    // -------------------------------------------------------
    // NOTE: This is an exploratory style of unit testing.
    // -------------------------------------------------------
    public static class FeatureExtensions
    {
        public static IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData> that_returns_property_names(
            this IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData> dependency,
            params string[] propertyNames)
        {
            A.CallTo(() =>
                dependency.GetAuthorizationContextPropertyNames())
                .Returns(propertyNames);

            return dependency;
        }

        public static IRelationshipsAuthorizationContextDataProviderFactory<RelationshipsAuthorizationContextData> that_always_returns(
            this IRelationshipsAuthorizationContextDataProviderFactory<RelationshipsAuthorizationContextData> dependency,
            IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData> provider)
        {
            A.CallTo(() =>
                dependency.GetProvider(A<Type>.Ignored))
                .Returns(provider);

            return dependency;
        }

        public static IEducationOrganizationCache that_always_returns_a_Local_Education_Agency_for(
            this IEducationOrganizationCache dependency,
            int educationOrganizationId)
        {
            A.CallTo(() =>
                dependency
                    .GetEducationOrganizationIdentifiers(educationOrganizationId))
                    .Returns(
                           new EducationOrganizationIdentifiers(
                               educationOrganizationId,
                               "LocalEducationAgency",
                               localEducationAgencyId: educationOrganizationId));

            return dependency;
        }

        // public static IReturnValueArgumentValidationConfiguration<EducationOrganizationIdentifiers> that_given_an_education_organization_id_of(
        //     this IEducationOrganizationCache dependency,
        //     int educationOrganizationId)
        // {
        //     return 
        //         A.CallTo(() => dependency.GetEducationOrganizationIdentifiers(educationOrganizationId));
        // }

        public static IEducationOrganizationHierarchyProvider that_always_returns_an_empty_graph(
            this IEducationOrganizationHierarchyProvider dependency)
        {
            A.CallTo(() =>
                    dependency
                        .GetEducationOrganizationHierarchy())
                        .Returns(new AdjacencyGraph<string, Edge<string>>());

            return dependency;
        }

        public static IReturnValueArgumentValidationConfiguration<RelationshipsAuthorizationContextData> that_given_entity(
            this context_data_provider dependency,
            object entity)
        {
            return A.CallTo(() => dependency.GetContextData(entity));
        }

        public static context_data_transformer that_just_performs_a_passthrough_on_the_context_data(
            this context_data_transformer dependency,
            RelationshipsAuthorizationContextData contextData)
        {
            A.CallTo(() => dependency.GetConcreteAuthorizationContextData(contextData))
                      .Returns(contextData);

            return dependency;
        }
    }

    // -------------------------------------------------------
    // NOTE: This is an exploratory style of unit testing.
    // -------------------------------------------------------
    [TestFixture]
    public class Feature_Authorizing_a_request
    {
        private static Claim Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(params int[] educationOrganizationIds)
        {
            return JsonClaimHelper.CreateClaim("xyz", new EdFiResourceClaimValue("read", new List<int>(educationOrganizationIds)));
        }

        private static EdFiAuthorizationContext Given_an_authorization_context_with_entity_data(object entity)
        {
            return new EdFiAuthorizationContext(new ClaimsPrincipal(), new[] { "resource" }, "action", entity);
        }

        private class passthrough_context_data_transformer : context_data_transformer
        {
            public RelationshipsAuthorizationContextData GetConcreteAuthorizationContextData(
                RelationshipsAuthorizationContextData authorizationContextData)
            {
                return authorizationContextData;
            }
        }

        public class When_authorizing_a_multiple_item_request
            : ScenarioFor<edorgs_and_people_strategy>
        {
            protected override void Arrange()
            {
                Given<context_data_provider>()
                   .that_returns_property_names(
                        Supplied(
                            "propertyNames",
                            new[]
                            {
                                "LocalEducationAgencyId", "StaffUSI"
                            }));

                Given<context_data_provider_factory>()
                   .that_always_returns(Given<context_data_provider>());

                Given<education_organization_cache>()
                   .that_always_returns_a_Local_Education_Agency_for(Supplied("LocalEducationAgencyId", 999));

                Supplied("entity", new object());

                Supplied(Given_an_authorization_context_with_entity_data(Supplied("entity")));

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));
            }

            protected override void Act()
            {
                var authorizationFilters = SystemUnderTest.GetAuthorizationFilters(
                    new[] {Supplied<Claim>()},
                    Supplied<EdFiAuthorizationContext>());
            }

            [Assert]
            public void
                Should_call_segments_converter_to_convert_segments_built_based_on_the_supplied_claims_with_the_supplied_entity_type_and_filter_builder()
            {
                int expectedSegmentLength = Supplied<string[]>("propertyNames").Length;

                A.CallTo(
                        () =>
                            Given<segments_to_filters_converter>()
                                .Convert(
                                    A<IReadOnlyList<ClaimsAuthorizationSegment>>.That.Matches(
                                        asc => asc.Count == expectedSegmentLength)))
                    .MustHaveHappened();
            }
        }

        public class When_authorizing_a_multiple_item_request_with_multiple_edorg_types
            : ScenarioFor<edorgs_and_people_strategy>
        {
            protected override void Arrange()
            {
                Given<context_data_provider>()
                   .that_returns_property_names(
                        Supplied(
                            "propertyNames",
                            new[]
                            {
                                "SchoolId", "StaffUSI"
                            }));

                Given<context_data_provider_factory>()
                   .that_always_returns(Given<context_data_provider>());

                Supplied("LocalEducationAgencyId", 999);
                Supplied("SchoolId", 888);

                A.CallTo(() =>
                    Given<education_organization_cache>()
                        .GetEducationOrganizationIdentifiers(Supplied<int>("LocalEducationAgencyId")))
                        .Returns(
                            new EducationOrganizationIdentifiers(
                                Supplied<int>("LocalEducationAgencyId"),
                                "LocalEducationAgency"));

                A.CallTo(() =>
                    Given<education_organization_cache>()
                        .GetEducationOrganizationIdentifiers(Supplied<int>("SchoolId")))
                   .Returns(new EducationOrganizationIdentifiers(Supplied<int>("SchoolId"), "School"));

                Supplied("entity", new object());

                Supplied(Given_an_authorization_context_with_entity_data(Supplied("entity")));

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId"),
                        Supplied<int>("SchoolId")));
            }

            protected override void Act()
            {
                SystemUnderTest.GetAuthorizationFilters(
                    new[]
                    {
                        Supplied<Claim>()
                    },
                    Supplied<EdFiAuthorizationContext>());
            }

            [Assert]
            public void Should_NOT_throw_a_NotSupportedException()
            {
                ActualException.ShouldNotBeOfType<NotSupportedException>();
            }
            
            
            [Assert]
            public void Should_call_segments_converter_to_convert_segments_built_based_on_the_supplied_claims_with_the_supplied_entity_type_and_filter_builder()
            {
                int expectedSegmentLength = Supplied<string[]>("propertyNames").Length;

                A.CallTo(
                        () =>
                            Given<segments_to_filters_converter>()
                                .Convert(
                                    A<IReadOnlyList<ClaimsAuthorizationSegment>>.That.Matches(
                                        asc => asc.Count == expectedSegmentLength)))
                    .MustHaveHappened();
            }
        }

        public class When_authorizing_a_single_item_request_with_correct_claims_for_request
            : ScenarioFor<RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>>
        {
            private class TestEntity
            {
                public TestEntity(int localEducationAgencyId, int staffUSI)
                {
                    LocalEducationAgencyId = localEducationAgencyId;
                    StaffUSI = staffUSI;
                }

                public int LocalEducationAgencyId { get; }

                public int StaffUSI { get; }
            }

            protected override void Arrange()
            {
                Supplied(
                    "entity",
                    new TestEntity(
                        Supplied("LocalEducationAgencyId", 999),
                        Supplied("StaffUSI", 123)));

                Supplied(
                    new RelationshipsAuthorizationContextData
                    {
                        LocalEducationAgencyId = Supplied<int>("LocalEducationAgencyId"),
                        StaffUSI = Supplied<int>("StaffUSI")
                    });

                Given<education_organization_cache>()
                   .that_always_returns_a_Local_Education_Agency_for(Supplied<int>("LocalEducationAgencyId"));

                Given<education_organization_hierarchy_provider>()
                   .that_always_returns_an_empty_graph();

                Given<context_data_transformer>(
                    new passthrough_context_data_transformer());

                Given<context_data_provider>()
                   .that_returns_property_names(
                        Supplied(
                            "propertyNames",
                            new[]
                            {
                                "LocalEducationAgencyId", "StaffUSI"
                            }))
                   .that_given_entity(Supplied("entity"))
                   .Returns(Supplied<RelationshipsAuthorizationContextData>());

                Given<context_data_provider_factory>()
                   .that_always_returns(Given<context_data_provider>());

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));
            }

            protected override void Act()
            {
                SystemUnderTest.AuthorizeSingleItemAsync(
                    new[]
                    {
                        Supplied<Claim>()
                    },
                    Given_an_authorization_context_with_entity_data(Supplied("entity")),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                ActualException.ShouldBeNull();
            }
        }

        public class When_authorizing_a_single_item_request_with_all_claim_values_needed_for_local_request_authorization
            : ScenarioFor<RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>>
        {
            private class TestEntity
            {
                public TestEntity(int localEducationAgencyId)
                {
                    LocalEducationAgencyId = localEducationAgencyId;
                }

                public int LocalEducationAgencyId { get; }
            }

            protected override void Arrange()
            {
                Supplied(
                    "entity",
                    new TestEntity(
                        Supplied("LocalEducationAgencyId", 999)));

                Supplied(
                    new RelationshipsAuthorizationContextData
                    {
                        LocalEducationAgencyId = Supplied<int>("LocalEducationAgencyId")
                    });

                Given<education_organization_cache>()
                   .that_always_returns_a_Local_Education_Agency_for(Supplied<int>("LocalEducationAgencyId"));

                Given<education_organization_hierarchy_provider>()
                   .that_always_returns_an_empty_graph();

                Given<context_data_transformer>(
                    new passthrough_context_data_transformer());

                Given<context_data_provider>()
                   .that_returns_property_names(
                        Supplied(
                            "propertyNames",
                            new[]
                            {
                                "LocalEducationAgencyId"
                            }))
                   .that_given_entity(Supplied("entity"))
                   .Returns(Supplied<RelationshipsAuthorizationContextData>());

                Given<context_data_provider_factory>()
                   .that_always_returns(Given<context_data_provider>());

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));
            }

            protected override void Act()
            {
                SystemUnderTest.AuthorizeSingleItemAsync(
                    new[]
                    {
                        Supplied<Claim>()
                    },
                    Given_an_authorization_context_with_entity_data(Supplied("entity")),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_not_call_through_to_verify_the_segments()
            {
                A.CallTo(() =>
                    Given<IAuthorizationSegmentsVerifier>()
                        .VerifyAsync(A<IReadOnlyList<ClaimsAuthorizationSegment>>.Ignored, A<CancellationToken>.Ignored))
                    .MustNotHaveHappened();
            }
        }

        public class When_authorizing_a_single_item_request_with_claim_needed_for_local_request_authorization_but_EdOrg_values_dont_match
            : ScenarioFor<RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>>
        {
            private class TestEntity
            {
                public TestEntity(int localEducationAgencyId)
                {
                    LocalEducationAgencyId = localEducationAgencyId;
                }

                public int LocalEducationAgencyId { get; }
            }

            protected override void Arrange()
            {
                Supplied(
                    "entity",
                    new TestEntity(
                        Supplied("LocalEducationAgencyId", 999)));

                Supplied(
                    new RelationshipsAuthorizationContextData
                    {
                        LocalEducationAgencyId = Supplied<int>("LocalEducationAgencyId")
                    });

                Given<education_organization_cache>()
                   .that_always_returns_a_Local_Education_Agency_for(Supplied<int>("LocalEducationAgencyId"))
                   .that_always_returns_a_Local_Education_Agency_for(777);

                Given<education_organization_hierarchy_provider>()
                   .that_always_returns_an_empty_graph();

                Given<context_data_transformer>(
                    new passthrough_context_data_transformer());

                Given<context_data_provider>()
                   .that_returns_property_names(
                        Supplied(
                            "propertyNames",
                            new[]
                            {
                                "LocalEducationAgencyId"
                            }))
                   .that_given_entity(Supplied("entity"))
                   .Returns(Supplied<RelationshipsAuthorizationContextData>());

                Given<context_data_provider_factory>()
                   .that_always_returns(Given<context_data_provider>());

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(777));
            }

            protected override void Act()
            {
                SystemUnderTest.AuthorizeSingleItemAsync(
                    new[]
                    {
                        Supplied<Claim>()
                    },
                    Given_an_authorization_context_with_entity_data(Supplied("entity")),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_EdFiSecurityException_indicating_the_claims_did_not_provide_authorization_for_the_request()
            {
                ActualException.ShouldBeExceptionType<EdFiSecurityException>();
                ActualException.MessageShouldContain("Access to the requested");
            }
        }
    }
}
