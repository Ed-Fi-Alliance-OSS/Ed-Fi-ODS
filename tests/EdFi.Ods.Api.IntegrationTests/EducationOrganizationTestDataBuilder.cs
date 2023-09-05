// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Text;
using EdFi.Ods.Api.Common.Models.Resources.Person.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationServiceCenterAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.OrganizationDepartmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StateEducationAgencyAggregate.EdFi;

namespace EdFi.Ods.Api.IntegrationTests
{
    public class EducationOrganizationTestDataBuilder
    {
        private IDbConnection Connection { get; set; }
        private readonly StringBuilder _sql = new StringBuilder();
        public int TestLocalEducationAgencyCategoryDescriptorId { get; private set; }
        public int TestProviderStatusDescriptorId { get; private set; }
        public int TestProviderCategoryDescriptorId { get; private set; }
        public int TestGradeLevelDescriptorId { get; private set; }
        public int TestEmploymentStatusDescriptorId { get; private set; }
        public int TestStaffClassificationDescriptorId { get; private set; }
        public int TestResponsibilityDescriptorId { get; private set; }


        private EducationOrganizationTestDataBuilder()
        {
        }

        public static EducationOrganizationTestDataBuilder Initialize(IDbConnection connection)
        {
            var builder = new EducationOrganizationTestDataBuilder { Connection = connection };

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT LocalEducationAgencyCategoryDescriptorId FROM edfi.LocalEducationAgencyCategoryDescriptor;";
            builder.TestLocalEducationAgencyCategoryDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT ProviderStatusDescriptorId FROM edfi.ProviderStatusDescriptor;";
            builder.TestProviderStatusDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT ProviderCategoryDescriptorId FROM edfi.ProviderCategoryDescriptor;";
            builder.TestProviderCategoryDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT GradeLevelDescriptorId FROM edfi.GradeLevelDescriptor;";
            builder.TestGradeLevelDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT EmploymentStatusDescriptorId FROM edfi.EmploymentStatusDescriptor;";
            builder.TestEmploymentStatusDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT StaffClassificationDescriptorId FROM edfi.StaffClassificationDescriptor;";
            builder.TestStaffClassificationDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            command.CommandText = "SELECT ResponsibilityDescriptorId FROM edfi.ResponsibilityDescriptor;";
            builder.TestResponsibilityDescriptorId = Convert.ToInt32(command.ExecuteScalar());

            return builder;
        }


        public EducationOrganizationTestDataBuilder AddStaffEducationOrganizationEmploymentAssociation(long schoolId, int staffUSI, DateTime? entryDate = null)
        {

            if (!entryDate.HasValue)
            {
                entryDate = DateTime.UtcNow.Date;
            }

            _sql.AppendLine($@"INSERT INTO edfi.StaffEducationOrganizationEmploymentAssociation (
                                EducationOrganizationId, 
                                StaffUSI, 
                                EmploymentStatusDescriptorId, 
                                HireDate)
                               VALUES (
                                {schoolId}, 
                                {staffUSI}, 
                                {TestEmploymentStatusDescriptorId}, 
                                '{ entryDate }');"

            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStaffEducationOrganizationAssignmentAssociation(long schoolId, int staffUSI, DateTime? entryDate = null)
        {

            if (!entryDate.HasValue)
            {
                entryDate = DateTime.UtcNow.Date;
            }

            _sql.AppendLine(
                $@"INSERT INTO edfi.StaffEducationOrganizationAssignmentAssociation (
                    EducationOrganizationId, 
                    StaffUSI, 
                    StaffClassificationDescriptorId, 
                    BeginDate)
                   VALUES (
                    {schoolId}, 
                    {staffUSI}, 
                    {TestStaffClassificationDescriptorId}, 
                    '{ entryDate }');"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStaff(string newGuidId)
        {
            _sql.AppendLine(
                $@"INSERT INTO edfi.Staff (
                    FirstName, 
                    LastSurname, 
                    BirthDate, 
                    StaffUniqueId)
                VALUES (
                    '{newGuidId}', 
                    '{newGuidId}', 
                    '{ DateTime.Now }', 
                    '{newGuidId}');"
            );
            return this;
        }

        protected EducationOrganizationTestDataBuilder AddEducationOrganization(long educationOrganizationId, string educationOrganizationType)
        {
            _sql.AppendLine(
                $@"INSERT INTO edfi.EducationOrganization (
                    EducationOrganizationId,
                    NameOfInstitution,
                    Discriminator)
                VALUES (
                    {educationOrganizationId},
                    '{educationOrganizationId}NameOfInstitution',
                    'edfi.{educationOrganizationType}');"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder DeleteEducationOrganization(long educationOrganizationId)
        {
            _sql.AppendLine($"DELETE FROM edfi.EducationOrganization WHERE EducationOrganizationId = {educationOrganizationId};");

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStateEducationAgency(long stateEducationAgencyId)
        {
            // Nameof usage is intentional here, by creating a dependency on generated entities
            // this ensures compilation errors if the organization subtype is removed
            AddEducationOrganization(stateEducationAgencyId, nameof(StateEducationAgency));

            _sql.AppendLine(
                $@"INSERT INTO edfi.StateEducationAgency (
                    StateEducationAgencyId)
                VALUES (
                    {stateEducationAgencyId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddEducationServiceCenter(long educationServiceCenterId, long? stateEducationAgencyId = null)
        {
            AddEducationOrganization(educationServiceCenterId, nameof(EducationServiceCenter));

            _sql.AppendLine(
                $@"INSERT INTO edfi.EducationServiceCenter (
                    EducationServiceCenterId,
                    StateEducationAgencyId)
                VALUES (
                    {educationServiceCenterId},
                    {ToSqlValue(stateEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddLocalEducationAgency(long localEducationAgencyId, long? stateEducationAgencyId = null, long? educationServiceCenterId = null, long? pontactLocalEducationAgencyId = null)
        {
            AddEducationOrganization(localEducationAgencyId, nameof(LocalEducationAgency));

            _sql.AppendLine(
                $@"INSERT INTO edfi.LocalEducationAgency (
                    LocalEducationAgencyId,
                    LocalEducationAgencyCategoryDescriptorId,
                    StateEducationAgencyId,
                    EducationServiceCenterId,
                    ParentLocalEducationAgencyId)
                VALUES (
                    {localEducationAgencyId},
                    {TestLocalEducationAgencyCategoryDescriptorId},
                    {ToSqlValue(stateEducationAgencyId)},
                    {ToSqlValue(educationServiceCenterId)},
                    {ToSqlValue(pontactLocalEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder UpdateLocalEducationAgency(long localEducationAgencyId, long? stateEducationAgencyId = null, long? educationServiceCenterId = null, long? pontactLocalEducationAgencyId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.LocalEducationAgency SET
                    StateEducationAgencyId = {ToSqlValue(stateEducationAgencyId)},
                    EducationServiceCenterId = {ToSqlValue(educationServiceCenterId)},
                    ParentLocalEducationAgencyId = {ToSqlValue(pontactLocalEducationAgencyId)}
                WHERE LocalEducationAgencyId = {localEducationAgencyId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddSchool(long schoolId, long? localEducationAgencyId = null)
        {
            AddEducationOrganization(schoolId, nameof(School));

            _sql.AppendLine(
                $@"INSERT INTO edfi.School (
                    SchoolId,
                    LocalEducationAgencyId)
                VALUES (
                    {schoolId},
                    {ToSqlValue(localEducationAgencyId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStudent(string newGuidId)
        {          
            _sql.AppendLine(
                $@"INSERT INTO edfi.Student (
                    FirstName,
                    LastSurname,
                    BirthDate,
                    StudentUniqueId)
                VALUES (
                    '{newGuidId}',
                    '{newGuidId}',
                    '{DateTime.UtcNow.Date}',
                    '{newGuidId}');"
            );

           return this;
        }

        public EducationOrganizationTestDataBuilder AddStudentSchoolAssociation(long schoolId, int studentUSI, DateTime? entryDate = null)
        {
            if (!entryDate.HasValue)
            {
                entryDate = DateTime.UtcNow.Date;
            }

            _sql.AppendLine(
                $@"INSERT INTO edfi.StudentSchoolAssociation (
                    SchoolId,
                    StudentUSI,
                    EntryDate,
                    EntryGradeLevelDescriptorId)
                VALUES (
                    {schoolId},
                    {studentUSI},
                    '{entryDate}',
                    {TestGradeLevelDescriptorId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddStudentEducationOrganizationResponsibilityAssociation(long schoolId, int studentUSI, DateTime? entryDate = null)
        {
            if (!entryDate.HasValue)
            {
                entryDate = DateTime.UtcNow.Date;
            }

            _sql.AppendLine(
                $@"INSERT INTO edfi.StudentEducationOrganizationResponsibilityAssociation (
                    BeginDate,
                    EducationOrganizationId,
                    StudentUSI,
                    ResponsibilityDescriptorId)
                VALUES (
                    '{entryDate}',
                    {schoolId},
                    {studentUSI},
                    {TestResponsibilityDescriptorId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder UpdateSchool(long schoolId, long? localEducationAgencyId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.School SET
                    LocalEducationAgencyId = {ToSqlValue(localEducationAgencyId)}
                WHERE SchoolId = {schoolId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddOrganizationDepartment(long organizationDepartmentId, long? contactEducationOrganizationId = null)
        {
            AddEducationOrganization(organizationDepartmentId, nameof(OrganizationDepartment));

            _sql.AppendLine(
                $@"INSERT INTO edfi.OrganizationDepartment (
                    OrganizationDepartmentId,
                    ParentEducationOrganizationId)
                VALUES (
                    {organizationDepartmentId},
                    {ToSqlValue(contactEducationOrganizationId)});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder UpdateOrganizationDepartment(long organizationDepartmentId, long? contactEducationOrganizationId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.OrganizationDepartment SET
                    ParentEducationOrganizationId = {ToSqlValue(contactEducationOrganizationId)}
                WHERE OrganizationDepartmentId = {organizationDepartmentId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddCommunityOrganization(long communityOrganizationId)
        {
            AddEducationOrganization(communityOrganizationId, nameof(CommunityOrganization));

            _sql.AppendLine(
                $@"INSERT INTO edfi.CommunityOrganization (
                    CommunityOrganizationId)
                VALUES (
                    {communityOrganizationId});"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddCommunityProvider(long communityProviderId, long? communityOrganizationId = null)
        {
            AddEducationOrganization(communityProviderId, nameof(CommunityProvider));

            _sql.AppendLine(
                $@"INSERT INTO edfi.CommunityProvider (
                    CommunityProviderId,
                    CommunityOrganizationId,
                    ProviderStatusDescriptorId,
                    ProviderCategoryDescriptorId)
                VALUES (
                    {communityProviderId},
                    {ToSqlValue(communityOrganizationId)},
                    {TestProviderStatusDescriptorId},
                    {TestProviderCategoryDescriptorId});"
            );

            return this;
        }
        
        public EducationOrganizationTestDataBuilder UpdateCommunityProvider(long communityProviderId, long? communityOrganizationId = null)
        {
            _sql.AppendLine(
                $@"UPDATE edfi.CommunityProvider SET
                    CommunityOrganizationId = {ToSqlValue(communityOrganizationId)}
                WHERE CommunityProviderId = {communityProviderId};"
            );

            return this;
        }

        public EducationOrganizationTestDataBuilder AddContact(string newGuidId)
        {
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection); // Used to provide compatability with data standard versions <v5.0 where Contact is named Parent

            _sql.AppendLine(
                $@"INSERT INTO edfi.{contactPersonType} (
                    FirstName,
                    LastSurname,
                    {contactPersonType}UniqueId)
                VALUES(
                    '{newGuidId}',
                    '{newGuidId}',
                    '{newGuidId}');"
            );

            return this;
        }
        
        public EducationOrganizationTestDataBuilder AddStudentContactAssociation(int contactUSI, int studentUSI)
        {
            var contactPersonType = AuthorizationViewHelper.GetContactPersonType(Connection);
            var studentContactAssociationTableName = $"edfi.Student{contactPersonType}Association"; // Used to provide compatability with data standard versions <v5.0 where Contact is named Parent
            
            _sql.AppendLine(
                 $@"INSERT INTO {studentContactAssociationTableName} ({contactPersonType}USI,StudentUSI)
                VALUES ({contactUSI}, {studentUSI});");

            return this;
        }

        private string ToSqlValue<T>(T? input) where T : struct
        {
            return input.HasValue
                ? input.Value.ToString()
                : "null";
        }

        public int Execute()
        {
            using var command = Connection.CreateCommand();
            command.CommandText = _sql.ToString();
            var result = command.ExecuteNonQuery();

            _sql.Clear();
            return result;
        }
    }
}
