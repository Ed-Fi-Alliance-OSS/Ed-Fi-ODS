// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using System;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class StudentUSIToEducationOrganizationIdAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_calling_studentUSI_to_educationOrganizationId_authView_should_not_get_duplicaterecords()
        {
             AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "StudentUSIToEducationOrganizationId");
        }

        [Test]
        public void When_enroll_student_in_school_should_get_access_from_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9701).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9701, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            AuthorizationViewHelper.ShouldContainStudentInSchoolOrDistrict(Connection, "StudentUSIToEducationOrganizationId", (9701, studentUSI));            
        }

        [Test]
        public void When_enroll_student_in_school_should_not_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9702).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9702, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainStudentInOtherSchoolOrDistrict(Connection, "StudentUSIToEducationOrganizationId", (9702, studentUSI));
        }

        [Test]
        public void When_enroll_student_in_both_school_should_get_access_from__both_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703).AddStudent(studentUniqueId)
                .Execute();
            
            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9703, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            Builder
               .AddSchool(9704)
               .Execute();

            Builder
                .AddStudentSchoolAssociation(9704, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var  expectedTuples = new (int, int)[] { (9703, studentUSI), (9704, studentUSI) };
            AuthorizationViewHelper.ShouldContainStudentInBothSchool(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }

        [Test]
        public void When_not_enroll_student_in__any_school_should_get_access_to_student_from_any_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            AuthorizationViewHelper.ShouldNotContainStudentInAnySchool(Connection, "StudentUSIToEducationOrganizationId", (0, studentUSI));
        }

        [Test]
        public void When_enroll_student_in_school_which_part_0f_district_should_get_access_from_school_and_district_also()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9705, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var expectedTuples = new (int, int)[] { (9705, studentUSI), (2200, studentUSI) };
            AuthorizationViewHelper.ShouldContainStudentInSchoolOrDistrict(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);

        }

        [Test]
        public void When_enroll_student_in_school_which_part_0f_district_should__not_get_access_from__anyother_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2201)
                .AddSchool(9706, 2201).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9706, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var expectedTuples = new (int, int)[] { (9706, studentUSI), (2201, studentUSI) };
            AuthorizationViewHelper.ShouldNotContainStudentInOtherSchoolOrDistrict(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);

        }
    }
}
