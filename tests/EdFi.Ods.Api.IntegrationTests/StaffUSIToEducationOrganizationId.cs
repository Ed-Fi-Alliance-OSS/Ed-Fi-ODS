// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class StaffUSIToEducationOrganizationId : DatabaseTestFixtureBase
    {
        
        [Test]
        public void When_staff_is_employed_by_school_the_same_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(9991).AddStaff(staffUniqueId).Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(9991, staffUniqueId).Execute();

            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 9991 });
        }


        [Test]
        public void When_staff_is_assigned_to_school_the_same_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(9991).AddStaff(staffUniqueId).Execute();

            Builder.StaffEducationOrganizationAssignmentAssociation(9991, staffUniqueId).Execute();

            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 9991 });
        }

        [Test]
        public void When_staff_is_employed_by_only_one_school_no_other_school_or_district_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(4321).AddStaff(staffUniqueId)
                   .AddSchool(6789) //Staff should not have access from this school
                   .Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(4321, staffUniqueId).Execute();

            AuthorizationViewHelper.ShouldNotContainStaffInOtherSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321 });
        }

        [Test]
        public void When_staff_is_assigned_to_only_one_school_no_other_school_or_district_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(4321)
                   .AddSchool(6789) //Staff should not have access from this school
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationAssignmentAssociation(4321, staffUniqueId).Execute();

            AuthorizationViewHelper.ShouldNotContainStaffInOtherSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321 });
        }

        [Test]
        public void When_staff_is_assigned_to_dual_schools_both_schools_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(4321)
                   .AddSchool(6789) //Staff should not have access from this school
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationAssignmentAssociation(4321, staffUniqueId)
                   .StaffEducationOrganizationAssignmentAssociation(6789, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321 });
        }

        [Test]
        public void When_staff_is_employed_to_dual_schools_both_schools_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(4321)
                   .AddSchool(6789) //Staff should not have access from this school
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(4321, staffUniqueId)
                   .StaffEducationOrganizationEmploymentAssociation(6789, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 6789 });
        }

        [Test]
        public void When_person_is_added_to_staff_table_but_not_employed_or_assigned_by_a_school_view_should_not_return_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddSchool(4321)
                   .AddStaff(staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldNotContainStaffInOtherSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>());
        }

        [Test]
        public void When_staff_is_employed_and_assigned_to_a_school_duplicate_records_should_not_return_from_view()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddLocalEducationAgency(1234)
                .AddSchool(4321, 1234)
                .AddStaff(staffUniqueId)
                .Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(4321, staffUniqueId)
                   .StaffEducationOrganizationAssignmentAssociation(4321, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldNotHaveDuplicateStaffSegments(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 1234 });
        }

        [Test]
        public void When_staff_is_employed_to_a_school_thats_part_of_a_district_district_and_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddLocalEducationAgency(1234)
                   .AddSchool(4321, 1234)
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(4321, staffUniqueId)
                   .Execute();


            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 1234 });
        }

        [Test]
        public void When_staff_is_assigned_to_a_school_thats_part_of_a_district_district_and_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddLocalEducationAgency(1234)
                   .AddSchool(4321, 1234)
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationAssignmentAssociation(4321, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldContainStaffInSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 1234 });
        }

        [Test]
        public void When_staff_is_assigned_to_a_school_thats_part_of_a_district_no_other_district_or_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddLocalEducationAgency(1234)
                   .AddLocalEducationAgency(9999)
                   .AddSchool(4321, 1234)
                   .AddSchool(6789, 1234)
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationAssignmentAssociation(4321, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldNotContainStaffInOtherSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 1234 });
        }

        [Test]
        public void When_staff_is_employed_to_a_school_thats_part_of_a_district_no_other_district_or_school_should_have_access_to_staff()
        {
            var staffUniqueId = Guid.NewGuid().ToString("N");

            Builder.AddLocalEducationAgency(1234)
                   .AddLocalEducationAgency(9999)
                   .AddSchool(4321, 1234)
                   .AddSchool(6789, 1234)
                   .AddStaff(staffUniqueId)
                   .Execute();

            Builder.StaffEducationOrganizationEmploymentAssociation(4321, staffUniqueId)
                   .Execute();

            AuthorizationViewHelper.ShouldNotContainStaffInOtherSchoolOrDistrict(Connection, "StaffUSIToEducationOrganizationId", staffUniqueId, new List<int>() { 4321, 1234 });
        }
    }
}
