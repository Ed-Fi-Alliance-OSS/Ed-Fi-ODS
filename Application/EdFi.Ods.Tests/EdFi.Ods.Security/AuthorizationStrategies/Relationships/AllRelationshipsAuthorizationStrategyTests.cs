// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using FakeItEasy.Configuration;
using NUnit.Framework;
using Shouldly;
using Test.Common;

/*
namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    using context_data_provider = IRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>;
    using context_data_provider_factory = IRelationshipsAuthorizationContextDataProviderFactory<RelationshipsAuthorizationContextData>;

    // Dependency type aliases (for readability)
    using edorgs_and_people_strategy = RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>;

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

        public static IReturnValueArgumentValidationConfiguration<RelationshipsAuthorizationContextData> that_given_entity(
            this context_data_provider dependency,
            object entity)
        {
            return A.CallTo(() => dependency.GetContextData(entity));
        }

        public static IDomainModelProvider that_always_returns(
            this IDomainModelProvider dependency,
            DomainModel domainModel)
        {
            A.CallTo(() => dependency.GetDomainModel())
                .Returns(domainModel);

            return dependency;
        }
    }

    // -------------------------------------------------------
    // NOTE: This is an exploratory style of unit testing.
    // -------------------------------------------------------
    [TestFixture]
    public class Feature_Authorizing_a_request
    {
        // private static Claim Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(params int[] educationOrganizationIds)
        // {
        //     return JsonClaimHelper.CreateClaim("xyz", new EdFiResourceClaimValue("read", new List<int>(educationOrganizationIds)));
        // }

        private static EdFiAuthorizationContext Given_an_authorization_context_with_entity_data(ApiKeyContext apiKeyContext, object entity)
        {
            return new EdFiAuthorizationContext(
                apiKeyContext,
                new ClaimsPrincipal(),
                new Resource("Ignored"),
                new[] { "resource" },
                "action",
                entity);
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

                Supplied("entity", new object());

                Supplied(Given_an_authorization_context_with_entity_data(
                    ApiKeyContextHelper.GetApiKeyContextWithEdOrgIds(Supplied<int>("LocalEducationAgencyId")),
                    Supplied("entity")));

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));
            }

            protected override void Act()
            {
                var authorizationFilters = SystemUnderTest.GetAuthorizationStrategyFiltering(
                    new[] { Supplied<EdFiResourceClaim>() },
                    Supplied<EdFiAuthorizationContext>());
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

                Supplied("entity", new object());

                Supplied(Given_an_authorization_context_with_entity_data(
                    ApiKeyContextHelper.GetApiKeyContextWithEdOrgIds(
                        Supplied<int>("LocalEducationAgencyId"),
                        Supplied<int>("SchoolId")),
                    Supplied("entity")));

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId"),
                        Supplied<int>("SchoolId")));
            }

            protected override void Act()
            {
                SystemUnderTest.GetAuthorizationStrategyFiltering(
                    new[]
                    {
                        Supplied<EdFiResourceClaim>()
                    },
                    Supplied<EdFiAuthorizationContext>());
            }

            [Assert]
            public void Should_NOT_throw_a_NotSupportedException()
            {
                ActualException.ShouldNotBeOfType<NotSupportedException>();
            }
        }

        public class When_authorizing_a_single_item_request_with_correct_claims_for_request
            : ScenarioFor<RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>>
        {
            [Schema("TestSchema")]
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

                Supplied(Given_an_authorization_context_with_entity_data(
                    ApiKeyContextHelper.GetApiKeyContextWithEdOrgIds(
                        Supplied<int>("LocalEducationAgencyId")),
                    Supplied("entity")));
                
                Given<context_data_provider_factory>()
                    .that_always_returns(Given<context_data_provider>());

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));

                var domainModel = CreateValidDomainModel().Build();
                Given<IDomainModelProvider>().that_always_returns(domainModel);
            }

            protected override void Act()
            {
                SystemUnderTest.GetAuthorizationStrategyFiltering(
                    new[] { Supplied<EdFiResourceClaim>() },
                    Supplied<EdFiAuthorizationContext>());
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                ActualException.ShouldBeNull();
            }

            private static DomainModelBuilder CreateValidDomainModel()
            {
                var entityDefinitions = new[]
                {
                    new EntityDefinition(
                        "TestSchema",
                        "TestEntity",
                        new[]
                        {
                            new EntityPropertyDefinition("LocalEducationAgencyId", new PropertyType(DbType.Int32)),
                            new EntityPropertyDefinition("StaffUSI", new PropertyType(DbType.Int32))
                        },
                        Array.Empty<EntityIdentifierDefinition>())
                };

                var associationDefinitions = Array.Empty<AssociationDefinition>();

                var aggregateDefinitions = new[]
                {
                    new AggregateDefinition(
                        new FullName("TestSchema", "TestEntity"),
                        Array.Empty<FullName>()
                    )
                };

                var schemaDefinition = new SchemaDefinition("logicalName", "TestSchema");

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggregateDefinitions,
                    entityDefinitions,
                    associationDefinitions);

                var builder = new DomainModelBuilder();

                builder.AddDomainModelDefinitionsList(
                    new List<DomainModelDefinitions>
                    {
                        modelDefinitions
                    });

                return builder;
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

                Supplied(Given_an_authorization_context_with_entity_data(
                    ApiKeyContextHelper.GetApiKeyContextWithEdOrgIds(
                        Supplied<int>("LocalEducationAgencyId")),
                    Supplied("entity")));
                
                Given<context_data_provider_factory>()
                    .that_always_returns(Given<context_data_provider>());

                Supplied(
                    Given_a_claim_for_an_arbitrary_resource_for_EducationOrganization_identifiers(
                        Supplied<int>("LocalEducationAgencyId")));
            }

            protected override void Act()
            {
                SystemUnderTest.GetAuthorizationStrategyFiltering(
                    new[] { Supplied<EdFiResourceClaim>() },
                    Supplied<EdFiAuthorizationContext>());
            }
        }
    }
}
*/