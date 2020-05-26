using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Models.Requests.GrandBend.Applicants
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

    [ExcludeFromCodeCoverage]
    public class ApplicantPost : Resources.Applicant.GrandBend.Applicant
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.GrandBend.Applicant
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

