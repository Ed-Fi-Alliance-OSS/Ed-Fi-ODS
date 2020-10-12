// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.CommunityOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationServiceCenterAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PostSecondaryInstitutionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StateEducationAgencyAggregate.EdFi;
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
                            typeof(StateEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(StateEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_stateEducationAgency_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.StateEducationAgency.EdFi.StateEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.StateEducationAgency.EdFi.StateEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationServiceCenter_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(EducationServiceCenter)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(EducationServiceCenter)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationServiceCenter_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.EducationServiceCenter.EdFi.EducationServiceCenter)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.EducationServiceCenter.EdFi.EducationServiceCenter)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetwork_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(EducationOrganizationNetwork)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(EducationOrganizationNetwork)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetwork_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_localEducationAgency_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(LocalEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(LocalEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_localEducationAgency_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_school_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(School)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(School)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_school_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.School.EdFi.School)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.School.EdFi.School)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityOrganization_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(CommunityOrganization)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(CommunityOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityOrganization_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.CommunityOrganization.EdFi.CommunityOrganization)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.CommunityOrganization.EdFi.CommunityOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityProvider_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(CommunityProvider)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(CommunityProvider)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_communityProvider_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.CommunityProvider.EdFi.CommunityProvider)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.CommunityProvider.EdFi.CommunityProvider)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_postSecondaryInstitution_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(PostSecondaryInstitution)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(PostSecondaryInstitution)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_postSecondaryInstitution_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetworkAssociation_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(EducationOrganizationNetworkAssociation)),
                        Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(EducationOrganizationNetworkAssociation)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganizationNetworkAssociation_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            typeof(Api.Common.Models.Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation)), Is.True),
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(
                            nameof(Api.Common.Models.Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganization_base_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationBaseEntity(
                            nameof(EducationOrganization)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_educationOrganization_Identifier_property()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationOrganizationEntitySpecification.IsEducationOrganizationIdentifier(
                            nameof(EducationOrganization.EducationOrganizationId)), Is.True)
                );
            }
        }
    }
}