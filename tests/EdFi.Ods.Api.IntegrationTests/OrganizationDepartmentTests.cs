// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public abstract class OrganizationDepartmentTests : DatabaseTestFixtureBase
    {
        [Test]
        public void
            When_inserting_and_deleting_organization_department_without_local_education_agency_or_school_should_update_tuples()
        {
            Builder
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_organization_department_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_organization_department_with_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_without_local_education_agency_to_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));

            Builder
                .UpdateOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_without_school_to_with_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));

            Builder
                .UpdateOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_with_local_education_agency_to_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .UpdateOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_with_school_to_without_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .UpdateOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (900, 9001));
        }
    }
}
