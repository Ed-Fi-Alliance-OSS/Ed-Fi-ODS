using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Api.Architecture;

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-References-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_References_IncludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-References-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_References_IncludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-References-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_References_ExcludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-References-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_References_ExcludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_IncludeAll_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_IncludeAll_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class StaffGetByExample
    {
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffGetByIds : IHasIdentifiers<Guid>
    {
        public StaffGetByIds() { }

        public StaffGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Test-Profile-StaffOnly-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Test-Profile-StaffOnly-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffDelete : IHasIdentifier
    {
        public StaffDelete() { }

        public StaffDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-StudentOnly-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll_Writable.Student
    {
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-StudentOnly-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll_Writable.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-StudentOnly2-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll_Writable.Student
    {
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-StudentOnly2-Resource-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll_Writable.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly
{
    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-WriteOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-WriteOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-BaseClass-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-BaseClass-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-BaseClass-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-BaseClass-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-Filtered-To-IncludeOnly-Specific-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-Filtered-To-IncludeOnly-Specific-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-Filtered-To-ExcludeOnly-Specific-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Resource-Child-Collection-Filtered-To-ExcludeOnly-Specific-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors
{

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByExample
    {
        public DateTime AdministrationDate { get; set; }
        public DateTime AdministrationEndDate { get; set; }
        public string AdministrationEnvironmentDescriptor { get; set; }
        public string AdministrationLanguageDescriptor { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string EventCircumstanceDescriptor { get; set; }
        public string EventDescription { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PlatformTypeDescriptor { get; set; }
        public string ReasonNotTestedDescriptor { get; set; }
        public string RetestIndicatorDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string SerialNumber { get; set; }
        public string StudentAssessmentIdentifier { get; set; }
        public string StudentUniqueId { get; set; }
        public string WhenAssessedGradeLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAssessmentGetByIds() { }

        public StudentAssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentAssessment.Test-Profile-Resource-Nested-Child-Collection-Filtered-To-IncludeOnly-Specific-Types-and-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPost : Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentAssessment.Test-Profile-Resource-Nested-Child-Collection-Filtered-To-IncludeOnly-Specific-Types-and-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPut : Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentDelete : IHasIdentifier
    {
        public StudentAssessmentDelete() { }

        public StudentAssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors
{

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByExample
    {
        public DateTime AdministrationDate { get; set; }
        public DateTime AdministrationEndDate { get; set; }
        public string AdministrationEnvironmentDescriptor { get; set; }
        public string AdministrationLanguageDescriptor { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string EventCircumstanceDescriptor { get; set; }
        public string EventDescription { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PlatformTypeDescriptor { get; set; }
        public string ReasonNotTestedDescriptor { get; set; }
        public string RetestIndicatorDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string SerialNumber { get; set; }
        public string StudentAssessmentIdentifier { get; set; }
        public string StudentUniqueId { get; set; }
        public string WhenAssessedGradeLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAssessmentGetByIds() { }

        public StudentAssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentAssessment.Test-Profile-Resource-Nested-Child-Collection-Filtered-To-ExcludeOnly-Specific-Types-and-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPost : Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentAssessment.Test-Profile-Resource-Nested-Child-Collection-Filtered-To-ExcludeOnly-Specific-Types-and-Descriptors.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPut : Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentDelete : IHasIdentifier
    {
        public StudentAssessmentDelete() { }

        public StudentAssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Student-and-School-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_Student_and_School_Include_All_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-Student-and-School-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_Student_and_School_Include_All_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-Student-and-School-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Test_Profile_Student_and_School_Include_All_Writable.Student
    {
    }

    [ProfileContentType("application/vnd.ed-fi.student.Test-Profile-Student-and-School-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Test_Profile_Student_and_School_Include_All_Writable.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByExample
    {
        public string CharterStatusDescriptor { get; set; }
        public int EducationServiceCenterId { get; set; }
        public string LocalEducationAgencyCategoryDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public int ParentLocalEducationAgencyId { get; set; }
        public int StateEducationAgencyId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByIds : IHasIdentifiers<Guid>
    {
        public LocalEducationAgencyGetByIds() { }

        public LocalEducationAgencyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.localEducationAgency.Test-Profile-EdOrgs-Resources-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPost : Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.LocalEducationAgency
    {
    }

    [ProfileContentType("application/vnd.ed-fi.localEducationAgency.Test-Profile-EdOrgs-Resources-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPut : Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.LocalEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyDelete : IHasIdentifier
    {
        public LocalEducationAgencyDelete() { }

        public LocalEducationAgencyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-EdOrgs-Resources-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-EdOrgs-Resources-Child-Collection-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByExample
    {
        public string CharterStatusDescriptor { get; set; }
        public int EducationServiceCenterId { get; set; }
        public string LocalEducationAgencyCategoryDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public int ParentLocalEducationAgencyId { get; set; }
        public int StateEducationAgencyId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByIds : IHasIdentifiers<Guid>
    {
        public LocalEducationAgencyGetByIds() { }

        public LocalEducationAgencyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.localEducationAgency.Test-Profile-EdOrgs-Resources-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPost : Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.LocalEducationAgency
    {
    }

    [ProfileContentType("application/vnd.ed-fi.localEducationAgency.Test-Profile-EdOrgs-Resources-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPut : Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.LocalEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyDelete : IHasIdentifier
    {
        public LocalEducationAgencyDelete() { }

        public LocalEducationAgencyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-EdOrgs-Resources-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.School
    {
    }

    [ProfileContentType("application/vnd.ed-fi.school.Test-Profile-EdOrgs-Resources-Child-Collection-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi.Student_Readable_Restricted
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object
{

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByExample
    {
        public bool AdaptiveAssessment { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentFamily { get; set; }
        public string AssessmentForm { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string AssessmentTitle { get; set; }
        public int AssessmentVersion { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRawScore { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
        public DateTime RevisionDate { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentGetByIds() { }

        public AssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentDelete : IHasIdentifier
    {
        public AssessmentDelete() { }

        public AssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Excludes_Embedded_Object
{

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByExample
    {
        public bool AdaptiveAssessment { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentFamily { get; set; }
        public string AssessmentForm { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string AssessmentTitle { get; set; }
        public int AssessmentVersion { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRawScore { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
        public DateTime RevisionDate { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentGetByIds() { }

        public AssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentDelete : IHasIdentifier
    {
        public AssessmentDelete() { }

        public AssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Includes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.Assessment-Writable-Includes-Embedded-Object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentPost : Resources.Assessment.EdFi.Assessment_Writable_Includes_Embedded_Object_Writable.Assessment
    {
    }

    [ProfileContentType("application/vnd.ed-fi.assessment.Assessment-Writable-Includes-Embedded-Object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentPut : Resources.Assessment.EdFi.Assessment_Writable_Includes_Embedded_Object_Writable.Assessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentDelete : IHasIdentifier
    {
        public AssessmentDelete() { }

        public AssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Excludes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.Assessment-Writable-Excludes-Embedded-Object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentPost : Resources.Assessment.EdFi.Assessment_Writable_Excludes_Embedded_Object_Writable.Assessment
    {
    }

    [ProfileContentType("application/vnd.ed-fi.assessment.Assessment-Writable-Excludes-Embedded-Object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentPut : Resources.Assessment.EdFi.Assessment_Writable_Excludes_Embedded_Object_Writable.Assessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentDelete : IHasIdentifier
    {
        public AssessmentDelete() { }

        public AssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Readable_Excludes_Optional_References
{

    [ExcludeFromCodeCoverage]
    public class AcademicWeekGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public int TotalInstructionalDays { get; set; }
        public string WeekIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekGetByIds : IHasIdentifiers<Guid>
    {
        public AcademicWeekGetByIds() { }

        public AcademicWeekGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekDelete : IHasIdentifier
    {
        public AcademicWeekDelete() { }

        public AcademicWeekDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Writable_Excludes_Optional_References
{
    [ProfileContentType("application/vnd.ed-fi.academicWeek.Academic-Week-Writable-Excludes-Optional-References.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AcademicWeekPost : Resources.AcademicWeek.EdFi.Academic_Week_Writable_Excludes_Optional_References_Writable.AcademicWeek
    {
    }

    [ProfileContentType("application/vnd.ed-fi.academicWeek.Academic-Week-Writable-Excludes-Optional-References.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AcademicWeekPut : Resources.AcademicWeek.EdFi.Academic_Week_Writable_Excludes_Optional_References_Writable.AcademicWeek
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekDelete : IHasIdentifier
    {
        public AcademicWeekDelete() { }

        public AcademicWeekDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_For_Composites_With_Multiple_Resources
{

    [ExcludeFromCodeCoverage]
    public class StaffGetByExample
    {
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffGetByIds : IHasIdentifiers<Guid>
    {
        public StaffGetByIds() { }

        public StaffGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffDelete : IHasIdentifier
    {
        public StaffDelete() { }

        public StaffDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_Profile_For_Composites_With_Multiple_Resources
{

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LimitedEnglishProficiencyDescriptor { get; set; }
        public string LoginId { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string ProfileThumbnail { get; set; }
        public string SexDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentEducationOrganizationAssociationGetByIds() { }

        public StudentEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationDelete : IHasIdentifier
    {
        public StudentEducationOrganizationAssociationDelete() { }

        public StudentEducationOrganizationAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical
{

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LimitedEnglishProficiencyDescriptor { get; set; }
        public string LoginId { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string ProfileThumbnail { get; set; }
        public string SexDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentEducationOrganizationAssociationGetByIds() { }

        public StudentEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationDelete : IHasIdentifier
    {
        public StudentEducationOrganizationAssociationDelete() { }

        public StudentEducationOrganizationAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.Test-ParentNonAbstractBaseClass-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.Test-ParentNonAbstractBaseClass-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.Test-ParentNonAbstractBaseClass-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.Test-ParentNonAbstractBaseClass-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ProfileContentType("application/vnd.ed-fi.studentSpecialEducationProgramAssociation.StudentSpecialEducationProgramAssociation-Derived-Association-IncludeAll.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll_Writable.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_IncludeOnly
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByExample
    {
        public string CalendarCode { get; set; }
        public short ClassOfSchoolYear { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool EmployedWhileEnrolled { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryGradeLevelDescriptor { get; set; }
        public string EntryGradeLevelReasonDescriptor { get; set; }
        public string EntryTypeDescriptor { get; set; }
        public DateTime ExitWithdrawDate { get; set; }
        public string ExitWithdrawTypeDescriptor { get; set; }
        public decimal FullTimeEquivalency { get; set; }
        public string GraduationPlanTypeDescriptor { get; set; }
        public short GraduationSchoolYear { get; set; }
        public Guid Id { get; set; }
        public bool PrimarySchool { get; set; }
        public bool RepeatGradeIndicator { get; set; }
        public string ResidencyStatusDescriptor { get; set; }
        public bool SchoolChoiceTransfer { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string StudentUniqueId { get; set; }
        public bool TermCompletionIndicator { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolAssociationGetByIds() { }

        public StudentSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationDelete : IHasIdentifier
    {
        public StudentSchoolAssociationDelete() { }

        public StudentSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByExample
    {
        public string CalendarCode { get; set; }
        public short ClassOfSchoolYear { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool EmployedWhileEnrolled { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryGradeLevelDescriptor { get; set; }
        public string EntryGradeLevelReasonDescriptor { get; set; }
        public string EntryTypeDescriptor { get; set; }
        public DateTime ExitWithdrawDate { get; set; }
        public string ExitWithdrawTypeDescriptor { get; set; }
        public decimal FullTimeEquivalency { get; set; }
        public string GraduationPlanTypeDescriptor { get; set; }
        public short GraduationSchoolYear { get; set; }
        public Guid Id { get; set; }
        public bool PrimarySchool { get; set; }
        public bool RepeatGradeIndicator { get; set; }
        public string ResidencyStatusDescriptor { get; set; }
        public bool SchoolChoiceTransfer { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string StudentUniqueId { get; set; }
        public bool TermCompletionIndicator { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolAssociationGetByIds() { }

        public StudentSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationDelete : IHasIdentifier
    {
        public StudentSchoolAssociationDelete() { }

        public StudentSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

