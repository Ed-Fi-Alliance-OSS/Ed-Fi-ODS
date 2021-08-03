// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using System;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class ParentUSIToEducationOrganizationIdAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805, 5601).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (9805, parentUSI), (5601, parentUSI) };

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, parentUSI,2, expectedTuples);
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9801).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9801, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, (9801, parentUSI));
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_should_not_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9902)
                .AddSchool(9802).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9802, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (9902, parentUSI)};
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, expectedTuples);

        }

        [Test]
        public void When_parent_assigned_to_a_student_in_both_school_should_have_access_from_both_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            Builder
                .AddSchool(9804)
                .Execute();

            Builder
                .AddStudentSchoolAssociation(9804, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId",
                PersonType.Parent, new[] { (9803, parentUSI), (9804, parentUSI) });
        }

        [Test]
        public void When_parent_not_assigned_to_a_student_in_any_school_should_not_have_access_from_any_school()
        {
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9899)
                .AddParent(parentUniqueId)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            var expectedTuples = new[] { (9899, parentUSI) };
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, expectedTuples);
        }


        [Test]
        public void When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_have_access_from_school_and_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805,5601).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (9805, parentUSI), (5601, parentUSI) };
            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, expectedTuples);
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_have_access_from_another_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddLocalEducationAgency(5692)
                .AddLocalEducationAgency(5602)
                .AddSchool(9899)
                .AddSchool(9806, 5602).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9806, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (5692, parentUSI), (9899, parentUSI)};
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", PersonType.Parent, expectedTuples);
        }

        [Test]
        public void When_parent_assigned_to_multiple_students_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);
            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var anotherStudentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddStudent(anotherStudentUniqueId)
                .Execute();

            var anotherStudentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, anotherStudentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, anotherStudentUSI, DateTime.UtcNow.Date.AddYears(-2))
                .Execute();

            Builder
                .AddStudentParentAssociation(parentUSI, anotherStudentUSI)
                .Execute();

            var expectedTuples = new[] { (9803, parentUSI) };

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "ParentUSIToEducationOrganizationId",
            PersonType.Parent, parentUSI,1, expectedTuples);
         }

        [Test]
        public void When_multiple_parent_assigned_to_a_student_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var parentUSI = AuthorizationViewHelper.GetParentUSI(Connection, parentUniqueId);
            var studentUSI = AuthorizationViewHelper.GetStudentUSI(Connection, studentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUSI, DateTime.UtcNow.Date)
                .Execute();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var anotherParentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddParent(anotherParentUniqueId)
                .Execute();

            var anotherParentUSI = AuthorizationViewHelper.GetParentUSI(Connection, anotherParentUniqueId);

            Builder
                .AddStudentParentAssociation(anotherParentUSI, studentUSI)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "ParentUSIToEducationOrganizationId",
                PersonType.Parent, parentUSI, 1, new[] { (9803, parentUSI) });
            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "ParentUSIToEducationOrganizationId",
                PersonType.Parent, anotherParentUSI, 1, new[] { (9803, anotherParentUSI) });
        }
    }
}
