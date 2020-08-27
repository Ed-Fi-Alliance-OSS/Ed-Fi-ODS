using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Providers;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Homograph
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
            { "Name_PK", new IndexDetails { IndexName = "Name_PK", TableName = "Name", ColumnNames = new List<string> { "FirstName", "LastSurname" } } },
            { "UX_Name_Id", new IndexDetails { IndexName = "UX_Name_Id", TableName = "Name", ColumnNames = new List<string> { "Id" } } },
            { "Parent_PK", new IndexDetails { IndexName = "Parent_PK", TableName = "Parent", ColumnNames = new List<string> { "ParentFirstName", "ParentLastSurname" } } },
            { "UX_Parent_Id", new IndexDetails { IndexName = "UX_Parent_Id", TableName = "Parent", ColumnNames = new List<string> { "Id" } } },
            { "FK_ParentAddress_Parent", new IndexDetails { IndexName = "FK_ParentAddress_Parent", TableName = "ParentAddress", ColumnNames = new List<string> { "ParentFirstName", "ParentLastSurname" } } },
            { "ParentAddress_PK", new IndexDetails { IndexName = "ParentAddress_PK", TableName = "ParentAddress", ColumnNames = new List<string> { "City", "ParentFirstName", "ParentLastSurname" } } },
            { "FK_ParentStudentSchoolAssociation_Parent", new IndexDetails { IndexName = "FK_ParentStudentSchoolAssociation_Parent", TableName = "ParentStudentSchoolAssociation", ColumnNames = new List<string> { "ParentFirstName", "ParentLastSurname" } } },
            { "FK_ParentStudentSchoolAssociation_StudentSchoolAssociation", new IndexDetails { IndexName = "FK_ParentStudentSchoolAssociation_StudentSchoolAssociation", TableName = "ParentStudentSchoolAssociation", ColumnNames = new List<string> { "SchoolName", "StudentFirstName", "StudentLastSurname" } } },
            { "ParentStudentSchoolAssociation_PK", new IndexDetails { IndexName = "ParentStudentSchoolAssociation_PK", TableName = "ParentStudentSchoolAssociation", ColumnNames = new List<string> { "ParentFirstName", "ParentLastSurname", "SchoolName", "StudentFirstName", "StudentLastSurname" } } },
            { "FK_School_SchoolYearType", new IndexDetails { IndexName = "FK_School_SchoolYearType", TableName = "School", ColumnNames = new List<string> { "SchoolYear" } } },
            { "School_PK", new IndexDetails { IndexName = "School_PK", TableName = "School", ColumnNames = new List<string> { "SchoolName" } } },
            { "UX_School_Id", new IndexDetails { IndexName = "UX_School_Id", TableName = "School", ColumnNames = new List<string> { "Id" } } },
            { "SchoolAddress_PK", new IndexDetails { IndexName = "SchoolAddress_PK", TableName = "SchoolAddress", ColumnNames = new List<string> { "SchoolName" } } },
            { "SchoolYearType_PK", new IndexDetails { IndexName = "SchoolYearType_PK", TableName = "SchoolYearType", ColumnNames = new List<string> { "SchoolYear" } } },
            { "UX_SchoolYearType_Id", new IndexDetails { IndexName = "UX_SchoolYearType_Id", TableName = "SchoolYearType", ColumnNames = new List<string> { "Id" } } },
            { "Staff_PK", new IndexDetails { IndexName = "Staff_PK", TableName = "Staff", ColumnNames = new List<string> { "StaffFirstName", "StaffLastSurname" } } },
            { "UX_Staff_Id", new IndexDetails { IndexName = "UX_Staff_Id", TableName = "Staff", ColumnNames = new List<string> { "Id" } } },
            { "FK_StaffAddress_Staff", new IndexDetails { IndexName = "FK_StaffAddress_Staff", TableName = "StaffAddress", ColumnNames = new List<string> { "StaffFirstName", "StaffLastSurname" } } },
            { "StaffAddress_PK", new IndexDetails { IndexName = "StaffAddress_PK", TableName = "StaffAddress", ColumnNames = new List<string> { "City", "StaffFirstName", "StaffLastSurname" } } },
            { "FK_StaffStudentSchoolAssociation_Staff", new IndexDetails { IndexName = "FK_StaffStudentSchoolAssociation_Staff", TableName = "StaffStudentSchoolAssociation", ColumnNames = new List<string> { "StaffFirstName", "StaffLastSurname" } } },
            { "FK_StaffStudentSchoolAssociation_StudentSchoolAssociation", new IndexDetails { IndexName = "FK_StaffStudentSchoolAssociation_StudentSchoolAssociation", TableName = "StaffStudentSchoolAssociation", ColumnNames = new List<string> { "SchoolName", "StudentFirstName", "StudentLastSurname" } } },
            { "StaffStudentSchoolAssociation_PK", new IndexDetails { IndexName = "StaffStudentSchoolAssociation_PK", TableName = "StaffStudentSchoolAssociation", ColumnNames = new List<string> { "SchoolName", "StaffFirstName", "StaffLastSurname", "StudentFirstName", "StudentLastSurname" } } },
            { "FK_Student_SchoolYearType", new IndexDetails { IndexName = "FK_Student_SchoolYearType", TableName = "Student", ColumnNames = new List<string> { "SchoolYear" } } },
            { "Student_PK", new IndexDetails { IndexName = "Student_PK", TableName = "Student", ColumnNames = new List<string> { "StudentFirstName", "StudentLastSurname" } } },
            { "UX_Student_Id", new IndexDetails { IndexName = "UX_Student_Id", TableName = "Student", ColumnNames = new List<string> { "Id" } } },
            { "FK_StudentAddress_Student", new IndexDetails { IndexName = "FK_StudentAddress_Student", TableName = "StudentAddress", ColumnNames = new List<string> { "StudentFirstName", "StudentLastSurname" } } },
            { "StudentAddress_PK", new IndexDetails { IndexName = "StudentAddress_PK", TableName = "StudentAddress", ColumnNames = new List<string> { "City", "StudentFirstName", "StudentLastSurname" } } },
            { "FK_StudentSchoolAssociation_School", new IndexDetails { IndexName = "FK_StudentSchoolAssociation_School", TableName = "StudentSchoolAssociation", ColumnNames = new List<string> { "SchoolName" } } },
            { "FK_StudentSchoolAssociation_Student", new IndexDetails { IndexName = "FK_StudentSchoolAssociation_Student", TableName = "StudentSchoolAssociation", ColumnNames = new List<string> { "StudentFirstName", "StudentLastSurname" } } },
            { "StudentSchoolAssociation_PK", new IndexDetails { IndexName = "StudentSchoolAssociation_PK", TableName = "StudentSchoolAssociation", ColumnNames = new List<string> { "SchoolName", "StudentFirstName", "StudentLastSurname" } } },
            { "UX_StudentSchoolAssociation_Id", new IndexDetails { IndexName = "UX_StudentSchoolAssociation_Id", TableName = "StudentSchoolAssociation", ColumnNames = new List<string> { "Id" } } },
        };
    }
}
