using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Api.Architecture;

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

