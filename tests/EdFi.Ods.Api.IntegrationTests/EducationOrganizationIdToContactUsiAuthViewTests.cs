// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class EducationOrganizationIdToContactUsiAuthViewTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_contact_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_return_duplicate_records()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805, 5601)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, contactPersonType);
        }

        [Test]
        public void When_contact_assigned_to_a_student_in_school_should_have_access_from_that_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9801)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9801, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            var expectedTuples = new (long, long)[] { (9801, contactUsi) };

            AuthorizationViewHelper.ShouldContainTuples(Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void When_contact_assigned_to_a_student_in_school_should_not_access_from_other_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9902)
                .AddSchool(9802)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9802, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            var expectedTuples = new (long, long)[] { (9902, contactUsi) };

            AuthorizationViewHelper.ShouldNotContainTuples(Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void When_contact_assigned_to_a_student_in_both_school_should_have_access_from_both_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .AddSchool(9804)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentSchoolAssociation(9804, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            var expectedTuples = new (long, long)[]
            {
                (9803, contactUsi),
                (9804, contactUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void When_contact_not_assigned_to_a_student_in_any_school_should_not_have_access_from_any_school()
        {
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9899)
                .AddContact(contactUniqueId)
                .Execute();

            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            var expectedTuples = new (long, long)[] { (9899, contactUsi) };

            AuthorizationViewHelper.ShouldNotContainTuples(
                Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void
            When_contact_assigned_to_a_student_in_school_that_belongs_to_a_district_should_have_access_from_school_and_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddLocalEducationAgency(5601)
                .AddSchool(9805, 5601)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9805, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            var expectedTuples = new (long, long)[]
            {
                (9805, contactUsi),
                (5601, contactUsi)
            };

            AuthorizationViewHelper.ShouldContainTuples(Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void
            When_contact_assigned_to_a_student_in_school_that_belongs_to_a_district_should_not_have_access_from_another_school_or_district()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddLocalEducationAgency(5692)
                .AddLocalEducationAgency(5602)
                .AddSchool(9899)
                .AddSchool(9806, 5602)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .Execute();

            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9806, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .Execute();

            var expectedTuples = new (long, long)[]
            {
                (5692, contactUsi),
                (9899, contactUsi)
            };

            AuthorizationViewHelper.ShouldNotContainTuples(Connection, contactPersonType, expectedTuples);
        }

        [Test]
        public void When_contact_assigned_to_multiple_students_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var anotherStudentUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .AddStudent(anotherStudentUniqueId)
                .Execute();

            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);
            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var anotherStudentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, anotherStudentUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .AddStudentSchoolAssociation(9803, anotherStudentUsi, DateTime.UtcNow.Date.AddYears(-2))
                .AddStudentContactAssociation(contactUsi, anotherStudentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, contactPersonType);
        }

        [Test]
        public void When_multiple_contact_assigned_to_a_student_in_a_school_should_have_not_access_duplicate_from_a_school()
        {
            var studentUniqueId = Guid.NewGuid().ToString("N");
            var contactUniqueId = Guid.NewGuid().ToString("N");
            var anothercontactUniqueId = Guid.NewGuid().ToString("N");
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);

            Builder
                .AddSchool(9803)
                .AddStudent(studentUniqueId)
                .AddContact(contactUniqueId)
                .AddContact(anothercontactUniqueId)
                .Execute();

            var contactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, contactUniqueId);
            var studentUsi = AuthorizationViewHelper.GetPersonUsi(Connection, PersonType.Student, studentUniqueId);
            var anothercontactUsi = AuthorizationViewHelper.GetPersonUsi(Connection, contactPersonType, anothercontactUniqueId);

            Builder
                .AddStudentSchoolAssociation(9803, studentUsi, DateTime.UtcNow.Date)
                .AddStudentContactAssociation(contactUsi, studentUsi)
                .AddStudentContactAssociation(anothercontactUsi, studentUsi)
                .Execute();

            AuthorizationViewHelper.ShouldNotContainDuplicate(Connection, contactPersonType);
        }
    }
}
