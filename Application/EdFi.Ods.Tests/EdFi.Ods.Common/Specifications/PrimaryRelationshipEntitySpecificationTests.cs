// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    public class PrimaryRelationshipEntitySpecificationTests
    {
        [TestFixture]
        public class When_determining_if_an_entity_or_resource_is_a_primaryRelationship : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_staffEducationOrganizationAssignmentAssociation_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(StaffEducationOrganizationAssignmentAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(StaffEducationOrganizationAssignmentAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_staffEducationOrganizationAssignmentAssociation_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(Api.Common.Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(Api.Common.Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_staffEducationOrganizationEmploymentAssociation_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(StaffEducationOrganizationEmploymentAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(StaffEducationOrganizationEmploymentAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_staffEducationOrganizationEmploymentAssociation_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(Api.Common.Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(Api.Common.Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_studentSchoolAssociation_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(StudentSchoolAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(StudentSchoolAssociation)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_studentSchoolAssociation_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            typeof(Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation)), Is.True),
                    () => Assert.That(
                        PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(
                            nameof(Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation)), Is.True)
                );
            }
        }
    }
}