using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Common.ExceptionHandling.SampleAlternativeEducationProgram
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
            { "AlternativeEducationEligibilityReasonDescriptor_PK", new IndexDetails { IndexName = "AlternativeEducationEligibilityReasonDescriptor_PK", TableName = "AlternativeEducationEligibilityReasonDescriptor", ColumnNames = new List<string> { "AlternativeEducationEligibilityReasonDescriptorId" } } },
            { "FK_StudentAlternativeEducationProgramAssociation_AlternativeEducationEligibilityReasonDescriptor", new IndexDetails { IndexName = "FK_StudentAlternativeEducationProgramAssociation_AlternativeEducationEligibilityReasonDescriptor", TableName = "StudentAlternativeEducationProgramAssociation", ColumnNames = new List<string> { "AlternativeEducationEligibilityReasonDescriptorId" } } },
            { "StudentAlternativeEducationProgramAssociation_PK", new IndexDetails { IndexName = "StudentAlternativeEducationProgramAssociation_PK", TableName = "StudentAlternativeEducationProgramAssociation", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "FK_StudentAlternativeEducationProgramAssociationMeetingTime_StudentAlternativeEducationProgramAssociation", new IndexDetails { IndexName = "FK_StudentAlternativeEducationProgramAssociationMeetingTime_StudentAlternativeEducationProgramAssociation", TableName = "StudentAlternativeEducationProgramAssociationMeetingTime", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI" } } },
            { "StudentAlternativeEducationProgramAssociationMeetingTime_PK", new IndexDetails { IndexName = "StudentAlternativeEducationProgramAssociationMeetingTime_PK", TableName = "StudentAlternativeEducationProgramAssociationMeetingTime", ColumnNames = new List<string> { "BeginDate", "EducationOrganizationId", "ProgramEducationOrganizationId", "ProgramName", "ProgramTypeDescriptorId", "StudentUSI", "EndTime", "StartTime" } } },
        };
    }
}
