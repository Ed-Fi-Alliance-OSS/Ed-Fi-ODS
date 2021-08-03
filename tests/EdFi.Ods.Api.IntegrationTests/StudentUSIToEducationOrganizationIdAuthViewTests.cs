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
        public void When_querying_studentUSI_to_educationOrganizationId_authView_it_should_not_return_duplicate_records()
        {
             AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "StudentUSIToEducationOrganizationId");
        }

        [Test]
        public void When_student_is_enrolled_in_a_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9701).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9701, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, "StudentUSIToEducationOrganizationId", (9701, studentUSI));
        }

        [Test]
        public void When_student_is_enrolled_in_one_school_should_not_have_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9722)
                .AddSchool(9702).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId); ;

            Builder
                .AddStudentSchoolAssociation(9702, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[] { (9722, studentUSI) };
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_multiple_schools_should_have_access_from_those_schools()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9703, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            Builder
               .AddSchool(9704)
               .Execute();

            Builder
                .AddStudentSchoolAssociation(9704, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var  expectedTuples = new (int, int)[] { (9703, studentUSI), (9704, studentUSI) };
            AuthorizationViewHelper.ShouldContainTuples(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }

        [Test]
        public void When_student_is_not_enrolled_should_not_have_access_to_student_from_any_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(4500)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            var expectedTuples = new[] { (4500, studentUSI) };
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_school_that_belongs_to_a_district_should_have_access_from_school_and_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9705, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (int, int)[] { (9705, studentUSI), (2200, studentUSI) };
            AuthorizationViewHelper.ShouldContainTuples(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_school_that_belongs_to_a_district_should_not_have_access_from_another_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2201)
                .AddLocalEducationAgency(2221)
                .AddSchool(9706, 2201)
                .AddSchool(9776, 2221).AddStudent(studentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9706, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new[] { (2221, studentUSI), (9776, studentUSI) };
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "StudentUSIToEducationOrganizationId", expectedTuples);
        }
    }
}
