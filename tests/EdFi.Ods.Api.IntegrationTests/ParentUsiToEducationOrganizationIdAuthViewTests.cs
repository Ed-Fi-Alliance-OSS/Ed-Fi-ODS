// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public abstract class ParentUsiToEducationOrganizationIdAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805, 5601)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Parent);
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9801)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9801, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, PersonType.Parent, (9801, parentUsi));
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_should_not_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9902)
                .AddSchool(9802)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9802, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            var expectedTuples = new[] {(9902, parentUsi)};

            AuthorizationViewHelper.ShouldNotContainTuples(Connection, PersonType.Parent, expectedTuples);
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_both_school_should_have_access_from_both_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .AddSchool(9804)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentSchoolAssociation(9804, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            var expectedTuples = new[]
            {
                (9803, parentUsi),
                (9804, parentUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(Connection, PersonType.Parent, expectedTuples);
        }

        [Test]
        public void When_parent_not_assigned_to_a_student_in_any_school_should_not_have_access_from_any_school()
        {
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9899)
                .AddParent(parentUniqueId)
                .Execute();

            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            var expectedTuples = new[] {(9899, parentUsi)};

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, PersonType.Parent, expectedTuples);
        }

        [Test]
        public void
            When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_have_access_from_school_and_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805, 5601)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            var expectedTuples = new[]
            {
                (9805, parentUsi),
                (5601, parentUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(Connection, PersonType.Parent, expectedTuples);
        }

        [Test]
        public void
            When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_have_access_from_another_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5692)
                .AddLocalEducationAgency(5602)
                .AddSchool(9899)
                .AddSchool(9806, 5602)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9806, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .Execute();

            var expectedTuples = new[]
            {
                (5692, parentUsi),
                (9899, parentUsi)
            };

            AuthorizationViewHelper.ShouldNotContainTuples(Connection, PersonType.Parent, expectedTuples);
        }

        [Test]
        public void When_parent_assigned_to_multiple_students_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");
            var anotherStudentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .AddStudent(anotherStudentUniqueId)
                .Execute();

            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);
            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var anotherStudentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, anotherStudentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .AddStudentSchoolAssociation(9803, anotherStudentUsi, DateTime.UtcNow.Date.AddYears(-2))
                .AddStudentParentAssociation(parentUsi, anotherStudentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Parent);
        }

        [Test]
        public void When_multiple_parent_assigned_to_a_student_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");
            var anotherParentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddParent(parentUniqueId)
                .AddParent(anotherParentUniqueId)
                .Execute();

            var parentUsi = AuthorizationViewHelper.GetParentUsi(Connection, parentUniqueId);
            var studentUsi = AuthorizationViewHelper.GetStudentUsi(Connection, studentUniqueId);
            var anotherParentUsi = AuthorizationViewHelper.GetParentUsi(Connection, anotherParentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentParentAssociation(parentUsi, studentUsi)
                .AddStudentParentAssociation(anotherParentUsi, studentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, PersonType.Parent);
        }
    }
}
