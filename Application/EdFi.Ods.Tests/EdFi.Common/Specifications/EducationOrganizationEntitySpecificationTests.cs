// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;
using NHibernateEntities = EdFi.Ods.Entities.NHibernate;
using ModelResources = EdFi.Ods.Api.Common.Models.Resources;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EducationOrganizationEntitySpecificationTests
    {
        public class When_determining_if_an_entity_or_resource_is_a_educationOrganization : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_stateEducationAgency_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.StateEducationAgencyAggregate.EdFi.StateEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.StateEducationAgencyAggregate.EdFi.StateEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_stateEducationAgency_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.StateEducationAgency.EdFi.StateEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.StateEducationAgency.EdFi.StateEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationServiceCenter_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.EducationServiceCenterAggregate.EdFi.EducationServiceCenter)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.EducationServiceCenterAggregate.EdFi.EducationServiceCenter)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationServiceCenter_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.EducationServiceCenter.EdFi.EducationServiceCenter)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.EducationServiceCenter.EdFi.EducationServiceCenter)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetwork_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.EducationOrganizationNetworkAggregate.EdFi.EducationOrganizationNetwork)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.EducationOrganizationNetworkAggregate.EdFi.EducationOrganizationNetwork)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetwork_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_localEducationAgency_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_localEducationAgency_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.LocalEducationAgency.EdFi.LocalEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.LocalEducationAgency.EdFi.LocalEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_school_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.SchoolAggregate.EdFi.School)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.SchoolAggregate.EdFi.School)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_school_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.School.EdFi.School)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.School.EdFi.School)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityOrganization_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.CommunityOrganizationAggregate.EdFi.CommunityOrganization)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.CommunityOrganizationAggregate.EdFi.CommunityOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityOrganization_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.CommunityOrganization.EdFi.CommunityOrganization)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.CommunityOrganization.EdFi.CommunityOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityProvider_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.CommunityProviderAggregate.EdFi.CommunityProvider)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.CommunityProviderAggregate.EdFi.CommunityProvider)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityProvider_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.CommunityProvider.EdFi.CommunityProvider)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.CommunityProvider.EdFi.CommunityProvider)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_postSecondaryInstitution_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.PostSecondaryInstitutionAggregate.EdFi.PostSecondaryInstitution)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.PostSecondaryInstitutionAggregate.EdFi.PostSecondaryInstitution)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_postSecondaryInstitution_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetworkAssociation_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(NHibernateEntities.EducationOrganizationNetworkAssociationAggregate.EdFi.EducationOrganizationNetworkAssociation)),
                        Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(NHibernateEntities.EducationOrganizationNetworkAssociationAggregate.EdFi.EducationOrganizationNetworkAssociation)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetworkAssociation_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(ModelResources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(ModelResources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganization_base_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationBaseEntity(
                            nameof(NHibernateEntities.EducationOrganizationAggregate.EdFi.EducationOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganization_Identifier_property()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationIdentifier(
                            nameof(NHibernateEntities.EducationOrganizationAggregate.EdFi.EducationOrganization.EducationOrganizationId)), Is.True)
                );
            }
        }
    }
}
