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
        public void When_querying_parentUSI_to_educationOrganizationId_authView_it_should_not_return_duplicate_records()
        {
            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, "ParentUSIToEducationOrganizationId");
        }

        [Test]
        public void When_parent_assigned_to_a_student_in_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9801).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9801, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId", (9801, parentUSI));
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

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9802, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (9902, parentUSI)};
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", expectedTuples);

        }

        [Test]
        public void When_parent_assigned_to_a_student_in_both_school_should_have_access_from_both_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9803).AddStudent(studentUniqueId).AddParent(parentUniqueId)
                .Execute();

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9803, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            Builder
                .AddSchool(9804)
                .Execute();

            Builder
                .AddStudentSchoolAssociation(9804, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId", new[] { (9803, parentUSI), (9804, parentUSI) });
        }

        [Test]
        public void When_parent_not_assigned_to_a_student_in_any_school_should_not_have_access_from_any_school()
        {
            var parentUniqueId = Guid.NewGuid().ToString("N");

            Builder
                .AddSchool(9899)
                .AddParent(parentUniqueId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            var expectedTuples = new[] { (9899, parentUSI) };
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", expectedTuples);
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

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9805, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (9805, parentUSI), (5601, parentUSI) };
            AuthorizationViewHelper.ShouldContainTuples(Connection, "ParentUSIToEducationOrganizationId", expectedTuples);
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

            var studentUSI = Builder
                 .GetStudentUSI(studentUniqueId)
                 .ExecuteScalar();

            Builder
                .AddStudentSchoolAssociation(9806, studentUSI, Builder.TestGradeLevelDescriptorId)
                .Execute();

            var parentUSI = Builder
                .GetParentUSI(parentUniqueId)
                .ExecuteScalar();

            Builder
                .AddStudentParentAssociation(parentUSI, studentUSI)
                .Execute();

            var expectedTuples = new[] { (5692, parentUSI), (9899, parentUSI)};
            AuthorizationViewHelper.ShouldNotContainTuples(Connection, "ParentUSIToEducationOrganizationId", expectedTuples);
        }
    }
}
