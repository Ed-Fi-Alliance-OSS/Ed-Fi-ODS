// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests.DataStandard500
{
    [TestFixture]
    public class EducationOrganizationIdToStudentUsiAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_student_is_enrolled_in_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9705, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Student);
        }

        [Test]
        public void When_student_is_enrolled_in_multiple_schools_should_not_return_duplicate_records_those_schools()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703)
                .AddSchool(9704)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9703, studentUsi, DateTime.UtcNow.Date)
                .AddStudentSchoolAssociation(9704, studentUsi, DateTime.UtcNow.Date.AddYears(-1))
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Student);
        }

        [Test]
        public void When_student_is_enrolled_in_a_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9701)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9701, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (long, int)[] { (9701, studentUsi) };

            AuthorizationViewHelper.ShouldContainTuples<long,int>(
                Connection, PersonType.Student, expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_one_school_should_not_have_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9722)
                .AddSchool(9702)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            ;

            Builder
                .AddStudentSchoolAssociation(9702, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (long, int)[] { (9722, studentUsi)};

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Student, expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_multiple_schools_should_have_access_from_those_schools()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9703)
                .AddSchool(9704)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9703, studentUsi, DateTime.UtcNow.Date)
                .AddStudentSchoolAssociation(9704, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (long, int)[]
            {
                (9703, studentUsi),
                (9704, studentUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples<long,int>(
                Connection, PersonType.Student, expectedTuples);
        }

        [Test]
        public void When_student_is_not_enrolled_should_not_have_access_to_student_from_any_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(4500)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            var expectedTuples = new (long, int)[] { (4500, studentUsi)};

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Student, expectedTuples);
        }

        [Test]
        public void When_student_is_enrolled_in_school_that_belongs_to_a_district_should_have_access_from_school_and_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2200)
                .AddSchool(9705, 2200)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9705, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (long, int)[]
            {
                (9705, studentUsi),
                (2200, studentUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(
                Connection, PersonType.Student, expectedTuples);
        }

        [Test]
        public void
            When_student_is_enrolled_in_school_that_belongs_to_a_district_should_not_have_access_from_another_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(2201)
                .AddLocalEducationAgency(2221)
                .AddSchool(9706, 2201)
                .AddSchool(9776, 2221)
                .AddStudent(studentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9706, studentUsi, DateTime.UtcNow.Date)
                .Execute();

            var expectedTuples = new (long, int)[]
            {
                (2221, studentUsi),
                (9776, studentUsi)
            };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Student, expectedTuples);
        }
    }
}
