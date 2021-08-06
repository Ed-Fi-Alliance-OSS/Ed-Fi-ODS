// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class StaffUSIToEducationOrganizationIdAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_staff_is_employed_in_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9705, staffUsi, DateTime.Now)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Staff);
        }

        [Test]
        public void When_staff_is_assigned_to_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9705, staffUsi, DateTime.Now)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Staff);
        }

        [Test]
        public void When_staff_is_employed_and_assigned_to_same_school_view_should_not_return_duplicate_records_from_the_school()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9704)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9704, staffUsi, DateTime.Now)
                .AddStaffEducationOrganizationEmploymentAssociation(9704, staffUsi, DateTime.Now)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Staff);
        }

        [Test]
        public void When_staff_is_employed_in_a_school_staff_should_have_access_from_that_school()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9701)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9701, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, (9701, staffUsi));
        }

        [Test]
        public void When_staff_is_assigned_in_a_school_staff_should_have_access_from_that_school()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9701)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9701, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, (9701, staffUsi));
        }

        [Test]
        public void When_staff_is_employed_to_one_school_staff_should_not_have_access_from_other_school()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9722)
                .AddSchool(9702)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);
            ;

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9702, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[] { (9722, staffUsi) };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_assigned_to_one_school_staff_should_not_have_access_from_other_school()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9722)
                .AddSchool(9702)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);
            ;

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9702, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[] { (9722, staffUsi) };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_employed_to_multiple_schools_staff_should_have_access_from_those_schools()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703)
                .AddSchool(9704)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9703, staffUsi, DateTime.UtcNow.Date)
                .AddStaffEducationOrganizationEmploymentAssociation(9704, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (int, int)[]
            {
                (9703, staffUsi),
                (9704, staffUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_assigned_to_multiple_schools_staff_should_have_access_from_those_schools()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703)
                .AddSchool(9704)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9703, staffUsi, DateTime.UtcNow.Date)
                .AddStaffEducationOrganizationAssignmentAssociation(9704, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (int, int)[]
            {
                (9703, staffUsi),
                (9704, staffUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_not_employed_and_not_assigned_by_any_school_staff_should_not_have_access_from_any_school()
        {
            var staffId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(4500)
                .AddStaff(staffId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffId);

            var expectedTuples = new[] { (4500, staffUsi) };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_employed_to_school_that_belongs_to_a_district_staff_should_have_access_from_school_and_district()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9705, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (int, int)[]
            {
                (9705, staffUsi),
                (2200, staffUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_assigned_to_school_that_belongs_to_a_district_staff_should_have_access_from_school_and_district()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9705, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (int, int)[]
            {
                (9705, staffUsi),
                (2200, staffUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_employed_by_school_that_belongs_to_a_district_staff_should_not_have_access_from_another_school_or_district()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2201)
                .AddLocalEducationAgency(2221)
                .AddSchool(9706, 2201)
                .AddSchool(9776, 2221)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationEmploymentAssociation(9706, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[]
            {
                (2221, staffUsi),
                (9776, staffUsi)
            };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }

        [Test]
        public void When_staff_is_assigned_to_school_that_belongs_to_a_district_staff_should_not_have_access_from_another_school_or_district()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2201)
                .AddLocalEducationAgency(2221)
                .AddSchool(9706, 2201)
                .AddSchool(9776, 2221)
                .AddStaff(staffUniqueId)
                .Execute();

            var staffUsi = AuthorizationViewHelper.GetStaffUsi(Connection, staffUniqueId);

            Builder
                .AddStaffEducationOrganizationAssignmentAssociation(9706, staffUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[]
            {
                (2221, staffUsi),
                (9776, staffUsi)
            };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Staff, expectedTuples);
        }
    }
}
