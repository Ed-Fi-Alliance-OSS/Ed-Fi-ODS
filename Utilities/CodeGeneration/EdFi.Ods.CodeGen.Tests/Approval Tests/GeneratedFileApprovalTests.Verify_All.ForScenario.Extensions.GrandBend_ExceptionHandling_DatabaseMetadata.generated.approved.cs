using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.Ods.Api.ExceptionHandling.GrandBend
{
    [ExcludeFromCodeCoverage]
    public class DatabaseMetadataProvider : IDatabaseMetadataProvider
    {
        public IndexDetails GetIndexDetails(string indexName)
        {
            IndexDetails indexDetails = null;

            IndexDetailsByName.TryGetValue(indexName, out indexDetails);

            return indexDetails;
        }

        private static readonly Dictionary<string, IndexDetails> IndexDetailsByName = new Dictionary<string, IndexDetails>(StringComparer.InvariantCultureIgnoreCase) {
            { "Applicant_PK", new IndexDetails { IndexName = "Applicant_PK", TableName = "Applicant", ColumnNames = new List<string> { "ApplicantIdentifier", "EducationOrganizationId" } } },
            { "FK_Applicant_AcademicSubjectDescriptor", new IndexDetails { IndexName = "FK_Applicant_AcademicSubjectDescriptor", TableName = "Applicant", ColumnNames = new List<string> { "HighlyQualifiedAcademicSubjectDescriptorId" } } },
            { "FK_Applicant_CitizenshipStatusDescriptor", new IndexDetails { IndexName = "FK_Applicant_CitizenshipStatusDescriptor", TableName = "Applicant", ColumnNames = new List<string> { "CitizenshipStatusDescriptorId" } } },
            { "FK_Applicant_EducationOrganization", new IndexDetails { IndexName = "FK_Applicant_EducationOrganization", TableName = "Applicant", ColumnNames = new List<string> { "EducationOrganizationId" } } },
            { "FK_Applicant_LevelOfEducationDescriptor", new IndexDetails { IndexName = "FK_Applicant_LevelOfEducationDescriptor", TableName = "Applicant", ColumnNames = new List<string> { "HighestCompletedLevelOfEducationDescriptorId" } } },
            { "FK_Applicant_SexDescriptor", new IndexDetails { IndexName = "FK_Applicant_SexDescriptor", TableName = "Applicant", ColumnNames = new List<string> { "SexDescriptorId" } } },
            { "UX_Applicant_Id", new IndexDetails { IndexName = "UX_Applicant_Id", TableName = "Applicant", ColumnNames = new List<string> { "Id" } } },
            { "ApplicantAddress_PK", new IndexDetails { IndexName = "ApplicantAddress_PK", TableName = "ApplicantAddress", ColumnNames = new List<string> { "AddressTypeDescriptorId", "ApplicantIdentifier", "EducationOrganizationId" } } },
            { "FK_ApplicantAddress_AddressTypeDescriptor", new IndexDetails { IndexName = "FK_ApplicantAddress_AddressTypeDescriptor", TableName = "ApplicantAddress", ColumnNames = new List<string> { "AddressTypeDescriptorId" } } },
            { "FK_ApplicantAddress_Applicant", new IndexDetails { IndexName = "FK_ApplicantAddress_Applicant", TableName = "ApplicantAddress", ColumnNames = new List<string> { "ApplicantIdentifier", "EducationOrganizationId" } } },
            { "FK_ApplicantAddress_StateAbbreviationDescriptor", new IndexDetails { IndexName = "FK_ApplicantAddress_StateAbbreviationDescriptor", TableName = "ApplicantAddress", ColumnNames = new List<string> { "StateAbbreviationDescriptorId" } } },
            { "StaffExtension_PK", new IndexDetails { IndexName = "StaffExtension_PK", TableName = "StaffExtension", ColumnNames = new List<string> { "StaffUSI" } } },
        };
    }
}