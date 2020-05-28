using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;
using EdFi.Ods.Api.Architecture;

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_Include_All
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Include_All_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Include_All_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedInclude
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Applicant_MixedInclude_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Applicant_MixedInclude_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff
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

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Staff_and_Prospect_MixedExclude2
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude2_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Staff_and_Prospect_MixedExclude2_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude2
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Applicant_MixedInclude2_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Applicant_MixedInclude2_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants.Applicant_MixedInclude1
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string SexDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantGetByIds() { }

        public ApplicantGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude1.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Applicant_MixedInclude1_Writable.Applicant
    {
    }

    [ProfileContentType("application/vnd.ed-fi.applicant.Applicant-MixedInclude1.writable+json")]
    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Applicant_MixedInclude1_Writable.Applicant
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantDelete : IHasIdentifier 
    {
        public ApplicantDelete() { }

        public ApplicantDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.Students.EdFi.Student_Include_All
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

    [ProfileContentType("application/vnd.ed-fi.student.Student-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Student_Include_All_Writable.Student
    {
    }

    [ProfileContentType("application/vnd.ed-fi.student.Student-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Student_Include_All_Writable.Student
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

