using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Common.ExceptionHandling.SampleStudentTranscript
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
            { "InstitutionControlDescriptor_PK", new IndexDetails { IndexName = "InstitutionControlDescriptor_PK", TableName = "InstitutionControlDescriptor", ColumnNames = new List<string> { "InstitutionControlDescriptorId" } } },
            { "InstitutionLevelDescriptor_PK", new IndexDetails { IndexName = "InstitutionLevelDescriptor_PK", TableName = "InstitutionLevelDescriptor", ColumnNames = new List<string> { "InstitutionLevelDescriptorId" } } },
            { "FK_PostSecondaryOrganization_InstitutionControlDescriptor", new IndexDetails { IndexName = "FK_PostSecondaryOrganization_InstitutionControlDescriptor", TableName = "PostSecondaryOrganization", ColumnNames = new List<string> { "InstitutionControlDescriptorId" } } },
            { "FK_PostSecondaryOrganization_InstitutionLevelDescriptor", new IndexDetails { IndexName = "FK_PostSecondaryOrganization_InstitutionLevelDescriptor", TableName = "PostSecondaryOrganization", ColumnNames = new List<string> { "InstitutionLevelDescriptorId" } } },
            { "PostSecondaryOrganization_PK", new IndexDetails { IndexName = "PostSecondaryOrganization_PK", TableName = "PostSecondaryOrganization", ColumnNames = new List<string> { "NameOfInstitution" } } },
            { "UX_PostSecondaryOrganization_Id", new IndexDetails { IndexName = "UX_PostSecondaryOrganization_Id", TableName = "PostSecondaryOrganization", ColumnNames = new List<string> { "Id" } } },
            { "SpecialEducationGraduationStatusDescriptor_PK", new IndexDetails { IndexName = "SpecialEducationGraduationStatusDescriptor_PK", TableName = "SpecialEducationGraduationStatusDescriptor", ColumnNames = new List<string> { "SpecialEducationGraduationStatusDescriptorId" } } },
            { "FK_StudentAcademicRecordClassRankingExtension_SpecialEducationGraduationStatusDescriptor", new IndexDetails { IndexName = "FK_StudentAcademicRecordClassRankingExtension_SpecialEducationGraduationStatusDescriptor", TableName = "StudentAcademicRecordClassRankingExtension", ColumnNames = new List<string> { "SpecialEducationGraduationStatusDescriptorId" } } },
            { "StudentAcademicRecordClassRankingExtension_PK", new IndexDetails { IndexName = "StudentAcademicRecordClassRankingExtension_PK", TableName = "StudentAcademicRecordClassRankingExtension", ColumnNames = new List<string> { "EducationOrganizationId", "SchoolYear", "StudentUSI", "TermDescriptorId" } } },
            { "FK_StudentAcademicRecordExtension_PostSecondaryOrganization", new IndexDetails { IndexName = "FK_StudentAcademicRecordExtension_PostSecondaryOrganization", TableName = "StudentAcademicRecordExtension", ColumnNames = new List<string> { "NameOfInstitution" } } },
            { "FK_StudentAcademicRecordExtension_SubmissionCertificationDescriptor", new IndexDetails { IndexName = "FK_StudentAcademicRecordExtension_SubmissionCertificationDescriptor", TableName = "StudentAcademicRecordExtension", ColumnNames = new List<string> { "SubmissionCertificationDescriptorId" } } },
            { "StudentAcademicRecordExtension_PK", new IndexDetails { IndexName = "StudentAcademicRecordExtension_PK", TableName = "StudentAcademicRecordExtension", ColumnNames = new List<string> { "EducationOrganizationId", "SchoolYear", "StudentUSI", "TermDescriptorId" } } },
            { "SubmissionCertificationDescriptor_PK", new IndexDetails { IndexName = "SubmissionCertificationDescriptor_PK", TableName = "SubmissionCertificationDescriptor", ColumnNames = new List<string> { "SubmissionCertificationDescriptorId" } } },
        };
    }
}
