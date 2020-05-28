using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Models.Requests.TPDM.AidTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorGetByExample
    {
        public int AidTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AidTypeDescriptorGetByIds() { }

        public AidTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorPost : Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorPut : Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorDelete : IHasIdentifier 
    {
        public AidTypeDescriptorDelete() { }

        public AidTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudents
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public bool AtriskIndicator { get; set; }
        public bool ELLEnrollment { get; set; }
        public bool ESLEnrollment { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public string GenderDescriptor { get; set; }
        public string GradeLevelDescriptor { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public int Mobility { get; set; }
        public short SchoolYear { get; set; }
        public bool Section504Enrollment { get; set; }
        public string SexDescriptor { get; set; }
        public bool SPEDEnrollment { get; set; }
        public bool TitleIEnrollment { get; set; }
        public string ValueTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentGetByIds() { }

        public AnonymizedStudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentPost : Resources.AnonymizedStudent.TPDM.AnonymizedStudent
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentPut : Resources.AnonymizedStudent.TPDM.AnonymizedStudent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentDelete : IHasIdentifier 
    {
        public AnonymizedStudentDelete() { }

        public AnonymizedStudentDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public decimal CumulativeGradePointAverage { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public decimal GPAMax { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public decimal SessionGradePointAverage { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentAcademicRecordGetByIds() { }

        public AnonymizedStudentAcademicRecordGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordPost : Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordPut : Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordDelete : IHasIdentifier 
    {
        public AnonymizedStudentAcademicRecordDelete() { }

        public AnonymizedStudentAcademicRecordDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentAssessments
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string AnonymizedStudentIdentifier { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string AssessmentTitle { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public string GradeLevelDescriptor { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public short TakenSchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentAssessmentGetByIds() { }

        public AnonymizedStudentAssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentPost : Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentPut : Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentDelete : IHasIdentifier 
    {
        public AnonymizedStudentAssessmentDelete() { }

        public AnonymizedStudentAssessmentDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationGetByExample
    {
        public DateTime AdministrationDate { get; set; }
        public string AnonymizedStudentIdentifier { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public short TakenSchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentAssessmentCourseAssociationGetByIds() { }

        public AnonymizedStudentAssessmentCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationPost : Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationPut : Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationDelete : IHasIdentifier 
    {
        public AnonymizedStudentAssessmentCourseAssociationDelete() { }

        public AnonymizedStudentAssessmentCourseAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationGetByExample
    {
        public DateTime AdministrationDate { get; set; }
        public string AnonymizedStudentIdentifier { get; set; }
        public string AssessmentIdentifier { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public short TakenSchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentAssessmentSectionAssociationGetByIds() { }

        public AnonymizedStudentAssessmentSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationPost : Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationPut : Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationDelete : IHasIdentifier 
    {
        public AnonymizedStudentAssessmentSectionAssociationDelete() { }

        public AnonymizedStudentAssessmentSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentCourseAssociationGetByIds() { }

        public AnonymizedStudentCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationPost : Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationPut : Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationDelete : IHasIdentifier 
    {
        public AnonymizedStudentCourseAssociationDelete() { }

        public AnonymizedStudentCourseAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public string CourseCode { get; set; }
        public string CourseRepeatCodeDescriptor { get; set; }
        public string CourseTitle { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public string FinalLetterGradeEarned { get; set; }
        public decimal FinalNumericGradeEarned { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentCourseTranscriptGetByIds() { }

        public AnonymizedStudentCourseTranscriptGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptPost : Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptPut : Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptDelete : IHasIdentifier 
    {
        public AnonymizedStudentCourseTranscriptDelete() { }

        public AnonymizedStudentCourseTranscriptDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentEducationOrganizationAssociationGetByIds() { }

        public AnonymizedStudentEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationPost : Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationPut : Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationDelete : IHasIdentifier 
    {
        public AnonymizedStudentEducationOrganizationAssociationDelete() { }

        public AnonymizedStudentEducationOrganizationAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationGetByExample
    {
        public string AnonymizedStudentIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public AnonymizedStudentSectionAssociationGetByIds() { }

        public AnonymizedStudentSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationPost : Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationPut : Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationDelete : IHasIdentifier 
    {
        public AnonymizedStudentSectionAssociationDelete() { }

        public AnonymizedStudentSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.Applicants
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public bool EconomicDisadvantaged { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool FirstGenerationStudent { get; set; }
        public string FirstName { get; set; }
        public string GenderDescriptor { get; set; }
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
        public string TeacherCandidateIdentifier { get; set; }
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
    public class ApplicantPost : Resources.Applicant.TPDM.Applicant
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantPut : Resources.Applicant.TPDM.Applicant
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

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicantProspectAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string ProspectIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicantProspectAssociationGetByIds() { }

        public ApplicantProspectAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationPost : Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationPut : Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationDelete : IHasIdentifier 
    {
        public ApplicantProspectAssociationDelete() { }

        public ApplicantProspectAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.Applications
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime AcceptedDate { get; set; }
        public string ApplicantIdentifier { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationIdentifier { get; set; }
        public string ApplicationSourceDescriptor { get; set; }
        public string ApplicationStatusDescriptor { get; set; }
        public bool CurrentEmployee { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FirstContactDate { get; set; }
        public string HighNeedsAcademicSubjectDescriptor { get; set; }
        public string HireStatusDescriptor { get; set; }
        public string HiringSourceDescriptor { get; set; }
        public Guid Id { get; set; }
        public DateTime WithdrawDate { get; set; }
        public string WithdrawReasonDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationGetByIds() { }

        public ApplicationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationPost : Resources.Application.TPDM.Application
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationPut : Resources.Application.TPDM.Application
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationDelete : IHasIdentifier 
    {
        public ApplicationDelete() { }

        public ApplicationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicationEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationEventGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public decimal ApplicationEvaluationScore { get; set; }
        public string ApplicationEventResultDescriptor { get; set; }
        public string ApplicationEventTypeDescriptor { get; set; }
        public string ApplicationIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public int SequenceNumber { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationEventGetByIds() { }

        public ApplicationEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventPost : Resources.ApplicationEvent.TPDM.ApplicationEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventPut : Resources.ApplicationEvent.TPDM.ApplicationEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventDelete : IHasIdentifier 
    {
        public ApplicationEventDelete() { }

        public ApplicationEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicationEventResultDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorGetByExample
    {
        public int ApplicationEventResultDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationEventResultDescriptorGetByIds() { }

        public ApplicationEventResultDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorPost : Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorPut : Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorDelete : IHasIdentifier 
    {
        public ApplicationEventResultDescriptorDelete() { }

        public ApplicationEventResultDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorGetByExample
    {
        public int ApplicationEventTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationEventTypeDescriptorGetByIds() { }

        public ApplicationEventTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorPost : Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorPut : Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorDelete : IHasIdentifier 
    {
        public ApplicationEventTypeDescriptorDelete() { }

        public ApplicationEventTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicationSourceDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorGetByExample
    {
        public int ApplicationSourceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationSourceDescriptorGetByIds() { }

        public ApplicationSourceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorPost : Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorPut : Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorDelete : IHasIdentifier 
    {
        public ApplicationSourceDescriptorDelete() { }

        public ApplicationSourceDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ApplicationStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorGetByExample
    {
        public int ApplicationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ApplicationStatusDescriptorGetByIds() { }

        public ApplicationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorPost : Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorPut : Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorDelete : IHasIdentifier 
    {
        public ApplicationStatusDescriptorDelete() { }

        public ApplicationStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorGetByExample
    {
        public int BackgroundCheckStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public BackgroundCheckStatusDescriptorGetByIds() { }

        public BackgroundCheckStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorPost : Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorPut : Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorDelete : IHasIdentifier 
    {
        public BackgroundCheckStatusDescriptorDelete() { }

        public BackgroundCheckStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorGetByExample
    {
        public int BackgroundCheckTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public BackgroundCheckTypeDescriptorGetByIds() { }

        public BackgroundCheckTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorPost : Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorPut : Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorDelete : IHasIdentifier 
    {
        public BackgroundCheckTypeDescriptorDelete() { }

        public BackgroundCheckTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorGetByExample
    {
        public int BoardCertificationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public BoardCertificationTypeDescriptorGetByIds() { }

        public BoardCertificationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorPost : Resources.BoardCertificationTypeDescriptor.TPDM.BoardCertificationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorPut : Resources.BoardCertificationTypeDescriptor.TPDM.BoardCertificationTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorDelete : IHasIdentifier 
    {
        public BoardCertificationTypeDescriptorDelete() { }

        public BoardCertificationTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CertificationExamStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorGetByExample
    {
        public int CertificationExamStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationExamStatusDescriptorGetByIds() { }

        public CertificationExamStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorPost : Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorPut : Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorDelete : IHasIdentifier 
    {
        public CertificationExamStatusDescriptorDelete() { }

        public CertificationExamStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CertificationExamTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorGetByExample
    {
        public int CertificationExamTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationExamTypeDescriptorGetByIds() { }

        public CertificationExamTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorPost : Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorPut : Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorDelete : IHasIdentifier 
    {
        public CertificationExamTypeDescriptorDelete() { }

        public CertificationExamTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CompleterAsStaffAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public CompleterAsStaffAssociationGetByIds() { }

        public CompleterAsStaffAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationPost : Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationPut : Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationDelete : IHasIdentifier 
    {
        public CompleterAsStaffAssociationDelete() { }

        public CompleterAsStaffAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorGetByExample
    {
        public int CoteachingStyleObservedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CoteachingStyleObservedDescriptorGetByIds() { }

        public CoteachingStyleObservedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorPost : Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorPut : Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorDelete : IHasIdentifier 
    {
        public CoteachingStyleObservedDescriptorDelete() { }

        public CoteachingStyleObservedDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CourseCourseTranscriptFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsGetByExample
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsGetByIds : IHasIdentifiers<Guid>
    {
        public CourseCourseTranscriptFactsGetByIds() { }

        public CourseCourseTranscriptFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsPost : Resources.CourseCourseTranscriptFacts.TPDM.CourseCourseTranscriptFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsPut : Resources.CourseCourseTranscriptFacts.TPDM.CourseCourseTranscriptFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsDelete : IHasIdentifier 
    {
        public CourseCourseTranscriptFactsDelete() { }

        public CourseCourseTranscriptFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsGetByExample
    {
        public decimal AggregatedGPAMax { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsGetByIds : IHasIdentifiers<Guid>
    {
        public CourseStudentAcademicRecordFactsGetByIds() { }

        public CourseStudentAcademicRecordFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsPost : Resources.CourseStudentAcademicRecordFacts.TPDM.CourseStudentAcademicRecordFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsPut : Resources.CourseStudentAcademicRecordFacts.TPDM.CourseStudentAcademicRecordFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsDelete : IHasIdentifier 
    {
        public CourseStudentAcademicRecordFactsDelete() { }

        public CourseStudentAcademicRecordFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CourseStudentAssessmentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentTitle { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public string GradeLevelDescriptor { get; set; }
        public Guid Id { get; set; }
        public short TakenSchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public CourseStudentAssessmentFactsGetByIds() { }

        public CourseStudentAssessmentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsPost : Resources.CourseStudentAssessmentFacts.TPDM.CourseStudentAssessmentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsPut : Resources.CourseStudentAssessmentFacts.TPDM.CourseStudentAssessmentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsDelete : IHasIdentifier 
    {
        public CourseStudentAssessmentFactsDelete() { }

        public CourseStudentAssessmentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.CourseStudentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsGetByExample
    {
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public CourseStudentFactsGetByIds() { }

        public CourseStudentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsPost : Resources.CourseStudentFacts.TPDM.CourseStudentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsPut : Resources.CourseStudentFacts.TPDM.CourseStudentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsDelete : IHasIdentifier 
    {
        public CourseStudentFactsDelete() { }

        public CourseStudentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsGetByExample
    {
        public string CourseTitle { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationCourseTranscriptFactsGetByIds() { }

        public EducationOrganizationCourseTranscriptFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsPost : Resources.EducationOrganizationCourseTranscriptFacts.TPDM.EducationOrganizationCourseTranscriptFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsPut : Resources.EducationOrganizationCourseTranscriptFacts.TPDM.EducationOrganizationCourseTranscriptFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsDelete : IHasIdentifier 
    {
        public EducationOrganizationCourseTranscriptFactsDelete() { }

        public EducationOrganizationCourseTranscriptFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EducationOrganizationFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsGetByExample
    {
        public decimal AverageYearsInDistrictEmployed { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public decimal HiringRate { get; set; }
        public Guid Id { get; set; }
        public int NumberAdministratorsEmployed { get; set; }
        public int NumberStudentsEnrolled { get; set; }
        public int NumberTeachersEmployed { get; set; }
        public decimal PercentStudentsFreeReducedLunch { get; set; }
        public decimal PercentStudentsLimitedEnglishProficiency { get; set; }
        public decimal PercentStudentsSpecialEducation { get; set; }
        public decimal RetentionRate { get; set; }
        public decimal RetirementRate { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationFactsGetByIds() { }

        public EducationOrganizationFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsPost : Resources.EducationOrganizationFacts.TPDM.EducationOrganizationFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsPut : Resources.EducationOrganizationFacts.TPDM.EducationOrganizationFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsDelete : IHasIdentifier 
    {
        public EducationOrganizationFactsDelete() { }

        public EducationOrganizationFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsGetByExample
    {
        public decimal AggregatedGPAMax { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationStudentAcademicRecordFactsGetByIds() { }

        public EducationOrganizationStudentAcademicRecordFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsPost : Resources.EducationOrganizationStudentAcademicRecordFacts.TPDM.EducationOrganizationStudentAcademicRecordFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsPut : Resources.EducationOrganizationStudentAcademicRecordFacts.TPDM.EducationOrganizationStudentAcademicRecordFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsDelete : IHasIdentifier 
    {
        public EducationOrganizationStudentAcademicRecordFactsDelete() { }

        public EducationOrganizationStudentAcademicRecordFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentTitle { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public string GradeLevelDescriptor { get; set; }
        public Guid Id { get; set; }
        public short TakenSchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationStudentAssessmentFactsGetByIds() { }

        public EducationOrganizationStudentAssessmentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsPost : Resources.EducationOrganizationStudentAssessmentFacts.TPDM.EducationOrganizationStudentAssessmentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsPut : Resources.EducationOrganizationStudentAssessmentFacts.TPDM.EducationOrganizationStudentAssessmentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsDelete : IHasIdentifier 
    {
        public EducationOrganizationStudentAssessmentFactsDelete() { }

        public EducationOrganizationStudentAssessmentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EducationOrganizationStudentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationStudentFactsGetByIds() { }

        public EducationOrganizationStudentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsPost : Resources.EducationOrganizationStudentFacts.TPDM.EducationOrganizationStudentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsPut : Resources.EducationOrganizationStudentFacts.TPDM.EducationOrganizationStudentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsDelete : IHasIdentifier 
    {
        public EducationOrganizationStudentFactsDelete() { }

        public EducationOrganizationStudentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EmploymentEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class EmploymentEventGetByExample
    {
        public bool EarlyHire { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EmploymentEventTypeDescriptor { get; set; }
        public DateTime HireDate { get; set; }
        public Guid Id { get; set; }
        public string InternalExternalHireDescriptor { get; set; }
        public bool MutualConsent { get; set; }
        public string RequisitionNumber { get; set; }
        public bool RestrictedChoice { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentEventGetByIds() { }

        public EmploymentEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventPost : Resources.EmploymentEvent.TPDM.EmploymentEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventPut : Resources.EmploymentEvent.TPDM.EmploymentEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventDelete : IHasIdentifier 
    {
        public EmploymentEventDelete() { }

        public EmploymentEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorGetByExample
    {
        public int EmploymentEventTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentEventTypeDescriptorGetByIds() { }

        public EmploymentEventTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorPost : Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorPut : Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorDelete : IHasIdentifier 
    {
        public EmploymentEventTypeDescriptorDelete() { }

        public EmploymentEventTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EmploymentSeparationEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EmploymentSeparationDate { get; set; }
        public DateTime EmploymentSeparationEnteredDate { get; set; }
        public string EmploymentSeparationReasonDescriptor { get; set; }
        public string EmploymentSeparationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public bool RemainingInDistrict { get; set; }
        public string RequisitionNumber { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentSeparationEventGetByIds() { }

        public EmploymentSeparationEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventPost : Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventPut : Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventDelete : IHasIdentifier 
    {
        public EmploymentSeparationEventDelete() { }

        public EmploymentSeparationEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorGetByExample
    {
        public int EmploymentSeparationReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentSeparationReasonDescriptorGetByIds() { }

        public EmploymentSeparationReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorPost : Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorPut : Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorDelete : IHasIdentifier 
    {
        public EmploymentSeparationReasonDescriptorDelete() { }

        public EmploymentSeparationReasonDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorGetByExample
    {
        public int EmploymentSeparationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentSeparationTypeDescriptorGetByIds() { }

        public EmploymentSeparationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorPost : Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorPut : Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorDelete : IHasIdentifier 
    {
        public EmploymentSeparationTypeDescriptorDelete() { }

        public EmploymentSeparationTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorGetByExample
    {
        public int EnglishLanguageExamDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EnglishLanguageExamDescriptorGetByIds() { }

        public EnglishLanguageExamDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorPost : Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorPut : Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorDelete : IHasIdentifier 
    {
        public EnglishLanguageExamDescriptorDelete() { }

        public EnglishLanguageExamDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorGetByExample
    {
        public int FederalLocaleCodeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public FederalLocaleCodeDescriptorGetByIds() { }

        public FederalLocaleCodeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorPost : Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorPut : Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorDelete : IHasIdentifier 
    {
        public FederalLocaleCodeDescriptorDelete() { }

        public FederalLocaleCodeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.FieldworkTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorGetByExample
    {
        public int FieldworkTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public FieldworkTypeDescriptorGetByIds() { }

        public FieldworkTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorPost : Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorPut : Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorDelete : IHasIdentifier 
    {
        public FieldworkTypeDescriptorDelete() { }

        public FieldworkTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.FundingSourceDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorGetByExample
    {
        public int FundingSourceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public FundingSourceDescriptorGetByIds() { }

        public FundingSourceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorPost : Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorPut : Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorDelete : IHasIdentifier 
    {
        public FundingSourceDescriptorDelete() { }

        public FundingSourceDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.GenderDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class GenderDescriptorGetByExample
    {
        public int GenderDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GenderDescriptorGetByIds() { }

        public GenderDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorPost : Resources.GenderDescriptor.TPDM.GenderDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorPut : Resources.GenderDescriptor.TPDM.GenderDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorDelete : IHasIdentifier 
    {
        public GenderDescriptorDelete() { }

        public GenderDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.HireStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorGetByExample
    {
        public int HireStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public HireStatusDescriptorGetByIds() { }

        public HireStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorPost : Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorPut : Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorDelete : IHasIdentifier 
    {
        public HireStatusDescriptorDelete() { }

        public HireStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.HiringSourceDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorGetByExample
    {
        public int HiringSourceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public HiringSourceDescriptorGetByIds() { }

        public HiringSourceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorPost : Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorPut : Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorDelete : IHasIdentifier 
    {
        public HiringSourceDescriptorDelete() { }

        public HiringSourceDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.InternalExternalHireDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorGetByExample
    {
        public int InternalExternalHireDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InternalExternalHireDescriptorGetByIds() { }

        public InternalExternalHireDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorPost : Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorPut : Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorDelete : IHasIdentifier 
    {
        public InternalExternalHireDescriptorDelete() { }

        public InternalExternalHireDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorGetByExample
    {
        public int LevelOfDegreeAwardedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LevelOfDegreeAwardedDescriptorGetByIds() { }

        public LevelOfDegreeAwardedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorPost : Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorPut : Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorDelete : IHasIdentifier 
    {
        public LevelOfDegreeAwardedDescriptorDelete() { }

        public LevelOfDegreeAwardedDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.LevelTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorGetByExample
    {
        public int LevelTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LevelTypeDescriptorGetByIds() { }

        public LevelTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorPost : Resources.LevelTypeDescriptor.TPDM.LevelTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorPut : Resources.LevelTypeDescriptor.TPDM.LevelTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorDelete : IHasIdentifier 
    {
        public LevelTypeDescriptorDelete() { }

        public LevelTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.OpenStaffPositionEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EventDate { get; set; }
        public Guid Id { get; set; }
        public string OpenStaffPositionEventStatusDescriptor { get; set; }
        public string OpenStaffPositionEventTypeDescriptor { get; set; }
        public string RequisitionNumber { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventGetByIds : IHasIdentifiers<Guid>
    {
        public OpenStaffPositionEventGetByIds() { }

        public OpenStaffPositionEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventPost : Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventPut : Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventDelete : IHasIdentifier 
    {
        public OpenStaffPositionEventDelete() { }

        public OpenStaffPositionEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorGetByExample
    {
        public int OpenStaffPositionEventStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OpenStaffPositionEventStatusDescriptorGetByIds() { }

        public OpenStaffPositionEventStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorPost : Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorPut : Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorDelete : IHasIdentifier 
    {
        public OpenStaffPositionEventStatusDescriptorDelete() { }

        public OpenStaffPositionEventStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorGetByExample
    {
        public int OpenStaffPositionEventTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OpenStaffPositionEventTypeDescriptorGetByIds() { }

        public OpenStaffPositionEventTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorPost : Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorPut : Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorDelete : IHasIdentifier 
    {
        public OpenStaffPositionEventTypeDescriptorDelete() { }

        public OpenStaffPositionEventTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorGetByExample
    {
        public int OpenStaffPositionReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OpenStaffPositionReasonDescriptorGetByIds() { }

        public OpenStaffPositionReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorPost : Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorPut : Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorDelete : IHasIdentifier 
    {
        public OpenStaffPositionReasonDescriptorDelete() { }

        public OpenStaffPositionReasonDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PerformanceMeasures
{ 
   
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime ActualDateOfPerformanceMeasure { get; set; }
        public bool Announced { get; set; }
        public string Comments { get; set; }
        public string CoteachingStyleObservedDescriptor { get; set; }
        public int DurationOfPerformanceMeasure { get; set; }
        public Guid Id { get; set; }
        public string PerformanceMeasureIdentifier { get; set; }
        public string PerformanceMeasureInstanceDescriptor { get; set; }
        public string PerformanceMeasureTypeDescriptor { get; set; }
        public DateTime ScheduleDateOfPerformanceMeasure { get; set; }
        public string TermDescriptor { get; set; }
        public TimeSpan TimeOfPerformanceMeasure { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceMeasureGetByIds() { }

        public PerformanceMeasureGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasurePost : Resources.PerformanceMeasure.TPDM.PerformanceMeasure
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasurePut : Resources.PerformanceMeasure.TPDM.PerformanceMeasure
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureDelete : IHasIdentifier 
    {
        public PerformanceMeasureDelete() { }

        public PerformanceMeasureDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationGetByExample
    {
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string PerformanceMeasureIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceMeasureCourseAssociationGetByIds() { }

        public PerformanceMeasureCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationPost : Resources.PerformanceMeasureCourseAssociation.TPDM.PerformanceMeasureCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationPut : Resources.PerformanceMeasureCourseAssociation.TPDM.PerformanceMeasureCourseAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationDelete : IHasIdentifier 
    {
        public PerformanceMeasureCourseAssociationDelete() { }

        public PerformanceMeasureCourseAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PerformanceMeasureFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string PerformanceMeasureTypeDescriptor { get; set; }
        public string RubricTitle { get; set; }
        public string RubricTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceMeasureFactsGetByIds() { }

        public PerformanceMeasureFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsPost : Resources.PerformanceMeasureFacts.TPDM.PerformanceMeasureFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsPut : Resources.PerformanceMeasureFacts.TPDM.PerformanceMeasureFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsDelete : IHasIdentifier 
    {
        public PerformanceMeasureFactsDelete() { }

        public PerformanceMeasureFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorGetByExample
    {
        public int PerformanceMeasureInstanceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceMeasureInstanceDescriptorGetByIds() { }

        public PerformanceMeasureInstanceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorPost : Resources.PerformanceMeasureInstanceDescriptor.TPDM.PerformanceMeasureInstanceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorPut : Resources.PerformanceMeasureInstanceDescriptor.TPDM.PerformanceMeasureInstanceDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorDelete : IHasIdentifier 
    {
        public PerformanceMeasureInstanceDescriptorDelete() { }

        public PerformanceMeasureInstanceDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorGetByExample
    {
        public int PerformanceMeasureTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceMeasureTypeDescriptorGetByIds() { }

        public PerformanceMeasureTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorPost : Resources.PerformanceMeasureTypeDescriptor.TPDM.PerformanceMeasureTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorPut : Resources.PerformanceMeasureTypeDescriptor.TPDM.PerformanceMeasureTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorDelete : IHasIdentifier 
    {
        public PerformanceMeasureTypeDescriptorDelete() { }

        public PerformanceMeasureTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.PreviousCareerDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorGetByExample
    {
        public int PreviousCareerDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PreviousCareerDescriptorGetByIds() { }

        public PreviousCareerDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorPost : Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorPut : Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorDelete : IHasIdentifier 
    {
        public PreviousCareerDescriptorDelete() { }

        public PreviousCareerDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventGetByExample
    {
        public Guid Id { get; set; }
        public bool MultipleSession { get; set; }
        public string ProfessionalDevelopmentOfferedByDescriptor { get; set; }
        public string ProfessionalDevelopmentReason { get; set; }
        public string ProfessionalDevelopmentTitle { get; set; }
        public bool Required { get; set; }
        public int TotalHours { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventGetByIds : IHasIdentifiers<Guid>
    {
        public ProfessionalDevelopmentEventGetByIds() { }

        public ProfessionalDevelopmentEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventPost : Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventPut : Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventDelete : IHasIdentifier 
    {
        public ProfessionalDevelopmentEventDelete() { }

        public ProfessionalDevelopmentEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorGetByExample
    {
        public int ProfessionalDevelopmentOfferedByDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProfessionalDevelopmentOfferedByDescriptorGetByIds() { }

        public ProfessionalDevelopmentOfferedByDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorPost : Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorPut : Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorDelete : IHasIdentifier 
    {
        public ProfessionalDevelopmentOfferedByDescriptorDelete() { }

        public ProfessionalDevelopmentOfferedByDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ProgramGatewayDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorGetByExample
    {
        public int ProgramGatewayDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramGatewayDescriptorGetByIds() { }

        public ProgramGatewayDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorPost : Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorPut : Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorDelete : IHasIdentifier 
    {
        public ProgramGatewayDescriptorDelete() { }

        public ProgramGatewayDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.Prospects
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProspectGetByExample
    {
        public bool Applied { get; set; }
        public bool EconomicDisadvantaged { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ElectronicMailAddress { get; set; }
        public bool FirstGenerationStudent { get; set; }
        public string FirstName { get; set; }
        public string GenderDescriptor { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public bool Met { get; set; }
        public string MiddleName { get; set; }
        public string Notes { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public int PreScreeningRating { get; set; }
        public string ProspectIdentifier { get; set; }
        public string ProspectTypeDescriptor { get; set; }
        public bool Referral { get; set; }
        public string ReferredBy { get; set; }
        public string SexDescriptor { get; set; }
        public string SocialMediaNetworkName { get; set; }
        public string SocialMediaUserName { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectGetByIds : IHasIdentifiers<Guid>
    {
        public ProspectGetByIds() { }

        public ProspectGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectPost : Resources.Prospect.TPDM.Prospect
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProspectPut : Resources.Prospect.TPDM.Prospect
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProspectDelete : IHasIdentifier 
    {
        public ProspectDelete() { }

        public ProspectDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendanceGetByExample
    {
        public DateTime AttendanceDate { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string ProfessionalDevelopmentTitle { get; set; }
        public string ProspectIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendanceGetByIds : IHasIdentifiers<Guid>
    {
        public ProspectProfessionalDevelopmentEventAttendanceGetByIds() { }

        public ProspectProfessionalDevelopmentEventAttendanceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendancePost : Resources.ProspectProfessionalDevelopmentEventAttendance.TPDM.ProspectProfessionalDevelopmentEventAttendance
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendancePut : Resources.ProspectProfessionalDevelopmentEventAttendance.TPDM.ProspectProfessionalDevelopmentEventAttendance
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendanceDelete : IHasIdentifier 
    {
        public ProspectProfessionalDevelopmentEventAttendanceDelete() { }

        public ProspectProfessionalDevelopmentEventAttendanceDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ProspectTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorGetByExample
    {
        public int ProspectTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProspectTypeDescriptorGetByIds() { }

        public ProspectTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorPost : Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorPut : Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorDelete : IHasIdentifier 
    {
        public ProspectTypeDescriptorDelete() { }

        public ProspectTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RecruitmentEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventGetByExample
    {
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public string EventTitle { get; set; }
        public Guid Id { get; set; }
        public string RecruitmentEventTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventGetByIds : IHasIdentifiers<Guid>
    {
        public RecruitmentEventGetByIds() { }

        public RecruitmentEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventPost : Resources.RecruitmentEvent.TPDM.RecruitmentEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventPut : Resources.RecruitmentEvent.TPDM.RecruitmentEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventDelete : IHasIdentifier 
    {
        public RecruitmentEventDelete() { }

        public RecruitmentEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorGetByExample
    {
        public int RecruitmentEventTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RecruitmentEventTypeDescriptorGetByIds() { }

        public RecruitmentEventTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorPost : Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorPut : Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorDelete : IHasIdentifier 
    {
        public RecruitmentEventTypeDescriptorDelete() { }

        public RecruitmentEventTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.Rubrics
{ 
   
    [ExcludeFromCodeCoverage]
    public class RubricGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public int InterRaterReliabilityScore { get; set; }
        public string RubricDescription { get; set; }
        public string RubricTitle { get; set; }
        public string RubricTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricGetByIds : IHasIdentifiers<Guid>
    {
        public RubricGetByIds() { }

        public RubricGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricPost : Resources.Rubric.TPDM.Rubric
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricPut : Resources.Rubric.TPDM.Rubric
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RubricDelete : IHasIdentifier 
    {
        public RubricDelete() { }

        public RubricDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RubricLevels
{ 
   
    [ExcludeFromCodeCoverage]
    public class RubricLevelGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string RubricLevelCode { get; set; }
        public string RubricTitle { get; set; }
        public string RubricTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelGetByIds : IHasIdentifiers<Guid>
    {
        public RubricLevelGetByIds() { }

        public RubricLevelGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelPost : Resources.RubricLevel.TPDM.RubricLevel
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelPut : Resources.RubricLevel.TPDM.RubricLevel
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelDelete : IHasIdentifier 
    {
        public RubricLevelDelete() { }

        public RubricLevelDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RubricLevelResponses
{ 
   
    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseGetByExample
    {
        public bool AreaOfRefinement { get; set; }
        public bool AreaOfReinforcement { get; set; }
        public string Comments { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public int NumericResponse { get; set; }
        public string PerformanceMeasureIdentifier { get; set; }
        public string RubricLevelCode { get; set; }
        public string RubricTitle { get; set; }
        public string RubricTypeDescriptor { get; set; }
        public string TextResponse { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseGetByIds : IHasIdentifiers<Guid>
    {
        public RubricLevelResponseGetByIds() { }

        public RubricLevelResponseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponsePost : Resources.RubricLevelResponse.TPDM.RubricLevelResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponsePut : Resources.RubricLevelResponse.TPDM.RubricLevelResponse
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseDelete : IHasIdentifier 
    {
        public RubricLevelResponseDelete() { }

        public RubricLevelResponseDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RubricLevelResponseFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string RubricLevelCode { get; set; }
        public string RubricTitle { get; set; }
        public string RubricTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsGetByIds : IHasIdentifiers<Guid>
    {
        public RubricLevelResponseFactsGetByIds() { }

        public RubricLevelResponseFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsPost : Resources.RubricLevelResponseFacts.TPDM.RubricLevelResponseFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsPut : Resources.RubricLevelResponseFacts.TPDM.RubricLevelResponseFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsDelete : IHasIdentifier 
    {
        public RubricLevelResponseFactsDelete() { }

        public RubricLevelResponseFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.RubricTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorGetByExample
    {
        public int RubricTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RubricTypeDescriptorGetByIds() { }

        public RubricTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorPost : Resources.RubricTypeDescriptor.TPDM.RubricTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorPut : Resources.RubricTypeDescriptor.TPDM.RubricTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorDelete : IHasIdentifier 
    {
        public RubricTypeDescriptorDelete() { }

        public RubricTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SalaryTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorGetByExample
    {
        public int SalaryTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SalaryTypeDescriptorGetByIds() { }

        public SalaryTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorPost : Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorPut : Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorDelete : IHasIdentifier 
    {
        public SalaryTypeDescriptorDelete() { }

        public SalaryTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SchoolStatusDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorGetByExample
    {
        public int SchoolStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolStatusDescriptorGetByIds() { }

        public SchoolStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorPost : Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorPut : Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorDelete : IHasIdentifier 
    {
        public SchoolStatusDescriptorDelete() { }

        public SchoolStatusDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SectionCourseTranscriptFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsGetByExample
    {
        public string CourseTitle { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public DateTime FactsAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsGetByIds : IHasIdentifiers<Guid>
    {
        public SectionCourseTranscriptFactsGetByIds() { }

        public SectionCourseTranscriptFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsPost : Resources.SectionCourseTranscriptFacts.TPDM.SectionCourseTranscriptFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsPut : Resources.SectionCourseTranscriptFacts.TPDM.SectionCourseTranscriptFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsDelete : IHasIdentifier 
    {
        public SectionCourseTranscriptFactsDelete() { }

        public SectionCourseTranscriptFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsGetByExample
    {
        public decimal AggregatedGPAMax { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsGetByIds : IHasIdentifiers<Guid>
    {
        public SectionStudentAcademicRecordFactsGetByIds() { }

        public SectionStudentAcademicRecordFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsPost : Resources.SectionStudentAcademicRecordFacts.TPDM.SectionStudentAcademicRecordFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsPut : Resources.SectionStudentAcademicRecordFacts.TPDM.SectionStudentAcademicRecordFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsDelete : IHasIdentifier 
    {
        public SectionStudentAcademicRecordFactsDelete() { }

        public SectionStudentAcademicRecordFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SectionStudentAssessmentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentTitle { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public string GradeLevelDescriptor { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public short TakenSchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public SectionStudentAssessmentFactsGetByIds() { }

        public SectionStudentAssessmentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsPost : Resources.SectionStudentAssessmentFacts.TPDM.SectionStudentAssessmentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsPut : Resources.SectionStudentAssessmentFacts.TPDM.SectionStudentAssessmentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsDelete : IHasIdentifier 
    {
        public SectionStudentAssessmentFactsDelete() { }

        public SectionStudentAssessmentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.SectionStudentFacts
{ 
   
    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsGetByExample
    {
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsGetByIds : IHasIdentifiers<Guid>
    {
        public SectionStudentFactsGetByIds() { }

        public SectionStudentFactsGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsPost : Resources.SectionStudentFacts.TPDM.SectionStudentFacts
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsPut : Resources.SectionStudentFacts.TPDM.SectionStudentFacts
    { 
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsDelete : IHasIdentifier 
    {
        public SectionStudentFactsDelete() { }

        public SectionStudentFactsDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffApplicantAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffApplicantAssociationGetByIds() { }

        public StaffApplicantAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationPost : Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationPut : Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationDelete : IHasIdentifier 
    {
        public StaffApplicantAssociationDelete() { }

        public StaffApplicantAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public short SchoolYear { get; set; }
        public string StaffEvaluationPeriodDescriptor { get; set; }
        public string StaffEvaluationTitle { get; set; }
        public string StaffEvaluationTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationGetByIds() { }

        public StaffEvaluationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPost : Resources.StaffEvaluation.TPDM.StaffEvaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPut : Resources.StaffEvaluation.TPDM.StaffEvaluation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationDelete : IHasIdentifier 
    {
        public StaffEvaluationDelete() { }

        public StaffEvaluationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationComponents
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationComponent { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string RubricReference { get; set; }
        public short SchoolYear { get; set; }
        public string StaffEvaluationTitle { get; set; }
        public string StaffEvaluationTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationComponentGetByIds() { }

        public StaffEvaluationComponentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentPost : Resources.StaffEvaluationComponent.TPDM.StaffEvaluationComponent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentPut : Resources.StaffEvaluationComponent.TPDM.StaffEvaluationComponent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentDelete : IHasIdentifier 
    {
        public StaffEvaluationComponentDelete() { }

        public StaffEvaluationComponentDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationComponentRatings
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingGetByExample
    {
        public decimal ComponentRating { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationComponent { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public DateTime StaffEvaluationDate { get; set; }
        public string StaffEvaluationRatingLevelDescriptor { get; set; }
        public string StaffEvaluationTitle { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationComponentRatingGetByIds() { }

        public StaffEvaluationComponentRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingPost : Resources.StaffEvaluationComponentRating.TPDM.StaffEvaluationComponentRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingPut : Resources.StaffEvaluationComponentRating.TPDM.StaffEvaluationComponentRating
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingDelete : IHasIdentifier 
    {
        public StaffEvaluationComponentRatingDelete() { }

        public StaffEvaluationComponentRatingDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationElements
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationComponent { get; set; }
        public string EvaluationElement { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string RubricReference { get; set; }
        public short SchoolYear { get; set; }
        public string StaffEvaluationTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationElementGetByIds() { }

        public StaffEvaluationElementGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementPost : Resources.StaffEvaluationElement.TPDM.StaffEvaluationElement
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementPut : Resources.StaffEvaluationElement.TPDM.StaffEvaluationElement
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementDelete : IHasIdentifier 
    {
        public StaffEvaluationElementDelete() { }

        public StaffEvaluationElementDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationElementRatings
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public decimal ElementRating { get; set; }
        public string EvaluationComponent { get; set; }
        public string EvaluationElement { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public DateTime StaffEvaluationDate { get; set; }
        public string StaffEvaluationRatingLevelDescriptor { get; set; }
        public string StaffEvaluationTitle { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationElementRatingGetByIds() { }

        public StaffEvaluationElementRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingPost : Resources.StaffEvaluationElementRating.TPDM.StaffEvaluationElementRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingPut : Resources.StaffEvaluationElementRating.TPDM.StaffEvaluationElementRating
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingDelete : IHasIdentifier 
    {
        public StaffEvaluationElementRatingDelete() { }

        public StaffEvaluationElementRatingDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorGetByExample
    {
        public int StaffEvaluationPeriodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationPeriodDescriptorGetByIds() { }

        public StaffEvaluationPeriodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorPost : Resources.StaffEvaluationPeriodDescriptor.TPDM.StaffEvaluationPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorPut : Resources.StaffEvaluationPeriodDescriptor.TPDM.StaffEvaluationPeriodDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorDelete : IHasIdentifier 
    {
        public StaffEvaluationPeriodDescriptorDelete() { }

        public StaffEvaluationPeriodDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationRatings
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluatedByStaffUniqueId { get; set; }
        public Guid Id { get; set; }
        public decimal Rating { get; set; }
        public short SchoolYear { get; set; }
        public DateTime StaffEvaluationDate { get; set; }
        public string StaffEvaluationRatingLevelDescriptor { get; set; }
        public string StaffEvaluationTitle { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationRatingGetByIds() { }

        public StaffEvaluationRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingPost : Resources.StaffEvaluationRating.TPDM.StaffEvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingPut : Resources.StaffEvaluationRating.TPDM.StaffEvaluationRating
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingDelete : IHasIdentifier 
    {
        public StaffEvaluationRatingDelete() { }

        public StaffEvaluationRatingDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorGetByExample
    {
        public int StaffEvaluationRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationRatingLevelDescriptorGetByIds() { }

        public StaffEvaluationRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorPost : Resources.StaffEvaluationRatingLevelDescriptor.TPDM.StaffEvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorPut : Resources.StaffEvaluationRatingLevelDescriptor.TPDM.StaffEvaluationRatingLevelDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorDelete : IHasIdentifier 
    {
        public StaffEvaluationRatingLevelDescriptorDelete() { }

        public StaffEvaluationRatingLevelDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorGetByExample
    {
        public int StaffEvaluationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEvaluationTypeDescriptorGetByIds() { }

        public StaffEvaluationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorPost : Resources.StaffEvaluationTypeDescriptor.TPDM.StaffEvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorPut : Resources.StaffEvaluationTypeDescriptor.TPDM.StaffEvaluationTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorDelete : IHasIdentifier 
    {
        public StaffEvaluationTypeDescriptorDelete() { }

        public StaffEvaluationTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventGetByExample
    {
        public string AbsenceEventCategoryDescriptor { get; set; }
        public string AbsenceEventReason { get; set; }
        public DateTime EventDate { get; set; }
        public decimal HoursAbsent { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StaffFieldworkAbsenceEventGetByIds() { }

        public StaffFieldworkAbsenceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventPost : Resources.StaffFieldworkAbsenceEvent.TPDM.StaffFieldworkAbsenceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventPut : Resources.StaffFieldworkAbsenceEvent.TPDM.StaffFieldworkAbsenceEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventDelete : IHasIdentifier 
    {
        public StaffFieldworkAbsenceEventDelete() { }

        public StaffFieldworkAbsenceEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffFieldworkExperiences
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public string FieldworkTypeDescriptor { get; set; }
        public decimal HoursCompleted { get; set; }
        public Guid Id { get; set; }
        public string ProgramGatewayDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceGetByIds : IHasIdentifiers<Guid>
    {
        public StaffFieldworkExperienceGetByIds() { }

        public StaffFieldworkExperienceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperiencePost : Resources.StaffFieldworkExperience.TPDM.StaffFieldworkExperience
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperiencePut : Resources.StaffFieldworkExperience.TPDM.StaffFieldworkExperience
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceDelete : IHasIdentifier 
    {
        public StaffFieldworkExperienceDelete() { }

        public StaffFieldworkExperienceDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffFieldworkExperienceSectionAssociationGetByIds() { }

        public StaffFieldworkExperienceSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationPost : Resources.StaffFieldworkExperienceSectionAssociation.TPDM.StaffFieldworkExperienceSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationPut : Resources.StaffFieldworkExperienceSectionAssociation.TPDM.StaffFieldworkExperienceSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationDelete : IHasIdentifier 
    {
        public StaffFieldworkExperienceSectionAssociationDelete() { }

        public StaffFieldworkExperienceSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendanceGetByExample
    {
        public DateTime AttendanceDate { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public Guid Id { get; set; }
        public string ProfessionalDevelopmentTitle { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendanceGetByIds : IHasIdentifiers<Guid>
    {
        public StaffProfessionalDevelopmentEventAttendanceGetByIds() { }

        public StaffProfessionalDevelopmentEventAttendanceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendancePost : Resources.StaffProfessionalDevelopmentEventAttendance.TPDM.StaffProfessionalDevelopmentEventAttendance
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendancePut : Resources.StaffProfessionalDevelopmentEventAttendance.TPDM.StaffProfessionalDevelopmentEventAttendance
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendanceDelete : IHasIdentifier 
    {
        public StaffProfessionalDevelopmentEventAttendanceDelete() { }

        public StaffProfessionalDevelopmentEventAttendanceDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffProspectAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string ProspectIdentifier { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffProspectAssociationGetByIds() { }

        public StaffProspectAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationPost : Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationPut : Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationDelete : IHasIdentifier 
    {
        public StaffProspectAssociationDelete() { }

        public StaffProspectAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffStudentGrowthMeasures
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureGetByExample
    {
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string ResultDatatypeTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string StaffStudentGrowthMeasureIdentifier { get; set; }
        public string StaffUniqueId { get; set; }
        public decimal StandardError { get; set; }
        public int StudentGrowthActualScore { get; set; }
        public DateTime StudentGrowthMeasureDate { get; set; }
        public bool StudentGrowthMet { get; set; }
        public int StudentGrowthNCount { get; set; }
        public int StudentGrowthTargetScore { get; set; }
        public string StudentGrowthTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureGetByIds : IHasIdentifiers<Guid>
    {
        public StaffStudentGrowthMeasureGetByIds() { }

        public StaffStudentGrowthMeasureGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasurePost : Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasurePut : Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureDelete : IHasIdentifier 
    {
        public StaffStudentGrowthMeasureDelete() { }

        public StaffStudentGrowthMeasureDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string StaffStudentGrowthMeasureIdentifier { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffStudentGrowthMeasureCourseAssociationGetByIds() { }

        public StaffStudentGrowthMeasureCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationPost : Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationPut : Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationDelete : IHasIdentifier 
    {
        public StaffStudentGrowthMeasureCourseAssociationDelete() { }

        public StaffStudentGrowthMeasureCourseAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string StaffStudentGrowthMeasureIdentifier { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffStudentGrowthMeasureEducationOrganizationAssociationGetByIds() { }

        public StaffStudentGrowthMeasureEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationPost : Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationPut : Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationDelete : IHasIdentifier 
    {
        public StaffStudentGrowthMeasureEducationOrganizationAssociationDelete() { }

        public StaffStudentGrowthMeasureEducationOrganizationAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StaffStudentGrowthMeasureIdentifier { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffStudentGrowthMeasureSectionAssociationGetByIds() { }

        public StaffStudentGrowthMeasureSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationPost : Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationPut : Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationDelete : IHasIdentifier 
    {
        public StaffStudentGrowthMeasureSectionAssociationDelete() { }

        public StaffStudentGrowthMeasureSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string ProgramAssignmentDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string StaffUniqueId { get; set; }
        public int TeacherPreparationProviderId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffTeacherPreparationProviderAssociationGetByIds() { }

        public StaffTeacherPreparationProviderAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationPost : Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationPut : Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationDelete : IHasIdentifier 
    {
        public StaffTeacherPreparationProviderAssociationDelete() { }

        public StaffTeacherPreparationProviderAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public bool StudentRecordAccess { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffTeacherPreparationProviderProgramAssociationGetByIds() { }

        public StaffTeacherPreparationProviderProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationPost : Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationPut : Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationDelete : IHasIdentifier 
    {
        public StaffTeacherPreparationProviderProgramAssociationDelete() { }

        public StaffTeacherPreparationProviderProgramAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorGetByExample
    {
        public int StudentGrowthTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGrowthTypeDescriptorGetByIds() { }

        public StudentGrowthTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorPost : Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorPut : Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorDelete : IHasIdentifier 
    {
        public StudentGrowthTypeDescriptorDelete() { }

        public StudentGrowthTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TalentManagementGoals
{ 
   
    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalGetByExample
    {
        public string GoalTitle { get; set; }
        public decimal GoalValue { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalGetByIds : IHasIdentifiers<Guid>
    {
        public TalentManagementGoalGetByIds() { }

        public TalentManagementGoalGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalPost : Resources.TalentManagementGoal.TPDM.TalentManagementGoal
    {
    }

    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalPut : Resources.TalentManagementGoal.TPDM.TalentManagementGoal
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalDelete : IHasIdentifier 
    {
        public TalentManagementGoalDelete() { }

        public TalentManagementGoalDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidates
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string DisplacementStatus { get; set; }
        public bool EconomicDisadvantaged { get; set; }
        public string EnglishLanguageExamDescriptor { get; set; }
        public bool FirstGenerationStudent { get; set; }
        public string FirstName { get; set; }
        public string GenderDescriptor { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LimitedEnglishProficiencyDescriptor { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PreviousCareerDescriptor { get; set; }
        public string ProfileThumbnail { get; set; }
        public bool ProgramComplete { get; set; }
        public string SexDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public decimal TuitionCost { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateGetByIds() { }

        public TeacherCandidateGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidatePost : Resources.TeacherCandidate.TPDM.TeacherCandidate
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidatePut : Resources.TeacherCandidate.TPDM.TeacherCandidate
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateDelete : IHasIdentifier 
    {
        public TeacherCandidateDelete() { }

        public TeacherCandidateDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordGetByExample
    {
        public decimal ContentGradePointAverage { get; set; }
        public decimal ContentGradePointEarned { get; set; }
        public decimal CumulativeAttemptedCreditConversion { get; set; }
        public decimal CumulativeAttemptedCredits { get; set; }
        public string CumulativeAttemptedCreditTypeDescriptor { get; set; }
        public decimal CumulativeEarnedCreditConversion { get; set; }
        public decimal CumulativeEarnedCredits { get; set; }
        public string CumulativeEarnedCreditTypeDescriptor { get; set; }
        public decimal CumulativeGradePointAverage { get; set; }
        public decimal CumulativeGradePointsEarned { get; set; }
        public int EducationOrganizationId { get; set; }
        public string GradeValueQualifier { get; set; }
        public Guid Id { get; set; }
        public string ProgramGatewayDescriptor { get; set; }
        public DateTime ProjectedGraduationDate { get; set; }
        public short SchoolYear { get; set; }
        public decimal SessionAttemptedCreditConversion { get; set; }
        public decimal SessionAttemptedCredits { get; set; }
        public string SessionAttemptedCreditTypeDescriptor { get; set; }
        public decimal SessionEarnedCreditConversion { get; set; }
        public decimal SessionEarnedCredits { get; set; }
        public string SessionEarnedCreditTypeDescriptor { get; set; }
        public decimal SessionGradePointAverage { get; set; }
        public decimal SessionGradePointsEarned { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TermDescriptor { get; set; }
        public string TPPDegreeTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateAcademicRecordGetByIds() { }

        public TeacherCandidateAcademicRecordGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordPost : Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordPut : Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordDelete : IHasIdentifier 
    {
        public TeacherCandidateAcademicRecordDelete() { }

        public TeacherCandidateAcademicRecordDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorGetByExample
    {
        public int TeacherCandidateCharacteristicDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateCharacteristicDescriptorGetByIds() { }

        public TeacherCandidateCharacteristicDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorPost : Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorPut : Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorDelete : IHasIdentifier 
    {
        public TeacherCandidateCharacteristicDescriptorDelete() { }

        public TeacherCandidateCharacteristicDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptGetByExample
    {
        public string AlternativeCourseCode { get; set; }
        public string AlternativeCourseTitle { get; set; }
        public decimal AttemptedCreditConversion { get; set; }
        public decimal AttemptedCredits { get; set; }
        public string AttemptedCreditTypeDescriptor { get; set; }
        public string CourseAttemptResultDescriptor { get; set; }
        public string CourseCode { get; set; }
        public int CourseEducationOrganizationId { get; set; }
        public string CourseRepeatCodeDescriptor { get; set; }
        public string CourseTitle { get; set; }
        public decimal EarnedCreditConversion { get; set; }
        public decimal EarnedCredits { get; set; }
        public string EarnedCreditTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinalLetterGradeEarned { get; set; }
        public decimal FinalNumericGradeEarned { get; set; }
        public Guid Id { get; set; }
        public string MethodCreditEarnedDescriptor { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TermDescriptor { get; set; }
        public string WhenTakenGradeLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateCourseTranscriptGetByIds() { }

        public TeacherCandidateCourseTranscriptGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptPost : Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptPut : Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptDelete : IHasIdentifier 
    {
        public TeacherCandidateCourseTranscriptDelete() { }

        public TeacherCandidateCourseTranscriptDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventGetByExample
    {
        public string AbsenceEventCategoryDescriptor { get; set; }
        public string AbsenceEventReason { get; set; }
        public DateTime EventDate { get; set; }
        public decimal HoursAbsent { get; set; }
        public Guid Id { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateFieldworkAbsenceEventGetByIds() { }

        public TeacherCandidateFieldworkAbsenceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventPost : Resources.TeacherCandidateFieldworkAbsenceEvent.TPDM.TeacherCandidateFieldworkAbsenceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventPut : Resources.TeacherCandidateFieldworkAbsenceEvent.TPDM.TeacherCandidateFieldworkAbsenceEvent
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventDelete : IHasIdentifier 
    {
        public TeacherCandidateFieldworkAbsenceEventDelete() { }

        public TeacherCandidateFieldworkAbsenceEventDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public string FieldworkTypeDescriptor { get; set; }
        public decimal HoursCompleted { get; set; }
        public Guid Id { get; set; }
        public string ProgramGatewayDescriptor { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateFieldworkExperienceGetByIds() { }

        public TeacherCandidateFieldworkExperienceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperiencePost : Resources.TeacherCandidateFieldworkExperience.TPDM.TeacherCandidateFieldworkExperience
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperiencePut : Resources.TeacherCandidateFieldworkExperience.TPDM.TeacherCandidateFieldworkExperience
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceDelete : IHasIdentifier 
    {
        public TeacherCandidateFieldworkExperienceDelete() { }

        public TeacherCandidateFieldworkExperienceDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateFieldworkExperienceSectionAssociationGetByIds() { }

        public TeacherCandidateFieldworkExperienceSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationPost : Resources.TeacherCandidateFieldworkExperienceSectionAssociation.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationPut : Resources.TeacherCandidateFieldworkExperienceSectionAssociation.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateFieldworkExperienceSectionAssociationDelete() { }

        public TeacherCandidateFieldworkExperienceSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendanceGetByExample
    {
        public DateTime AttendanceDate { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public Guid Id { get; set; }
        public string ProfessionalDevelopmentTitle { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendanceGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateProfessionalDevelopmentEventAttendanceGetByIds() { }

        public TeacherCandidateProfessionalDevelopmentEventAttendanceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendancePost : Resources.TeacherCandidateProfessionalDevelopmentEventAttendance.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendancePut : Resources.TeacherCandidateProfessionalDevelopmentEventAttendance.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendanceDelete : IHasIdentifier 
    {
        public TeacherCandidateProfessionalDevelopmentEventAttendanceDelete() { }

        public TeacherCandidateProfessionalDevelopmentEventAttendanceDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateStaffAssociationGetByIds() { }

        public TeacherCandidateStaffAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationPost : Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationPut : Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateStaffAssociationDelete() { }

        public TeacherCandidateStaffAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureGetByExample
    {
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string ResultDatatypeTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public decimal StandardError { get; set; }
        public int StudentGrowthActualScore { get; set; }
        public DateTime StudentGrowthMeasureDate { get; set; }
        public bool StudentGrowthMet { get; set; }
        public int StudentGrowthNCount { get; set; }
        public int StudentGrowthTargetScore { get; set; }
        public string StudentGrowthTypeDescriptor { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateStudentGrowthMeasureGetByIds() { }

        public TeacherCandidateStudentGrowthMeasureGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasurePost : Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasurePut : Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureDelete : IHasIdentifier 
    {
        public TeacherCandidateStudentGrowthMeasureDelete() { }

        public TeacherCandidateStudentGrowthMeasureDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateStudentGrowthMeasureCourseAssociationGetByIds() { }

        public TeacherCandidateStudentGrowthMeasureCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationPost : Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationPut : Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateStudentGrowthMeasureCourseAssociationDelete() { }

        public TeacherCandidateStudentGrowthMeasureCourseAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByIds() { }

        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationPost : Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationPut : Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationDelete() { }

        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FactAsOfDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public string TeacherCandidateStudentGrowthMeasureIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateStudentGrowthMeasureSectionAssociationGetByIds() { }

        public TeacherCandidateStudentGrowthMeasureSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationPost : Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationPut : Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateStudentGrowthMeasureSectionAssociationDelete() { }

        public TeacherCandidateStudentGrowthMeasureSectionAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationGetByExample
    {
        public short ClassOfSchoolYear { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTypeDescriptor { get; set; }
        public DateTime ExitWithdrawDate { get; set; }
        public string ExitWithdrawTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
        public int TeacherPreparationProviderId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateTeacherPreparationProviderAssociationGetByIds() { }

        public TeacherCandidateTeacherPreparationProviderAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationPost : Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationPut : Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateTeacherPreparationProviderAssociationDelete() { }

        public TeacherCandidateTeacherPreparationProviderAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string ReasonExitedDescriptor { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherCandidateTeacherPreparationProviderProgramAssociationGetByIds() { }

        public TeacherCandidateTeacherPreparationProviderProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationPost : Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationPut : Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationDelete : IHasIdentifier 
    {
        public TeacherCandidateTeacherPreparationProviderProgramAssociationDelete() { }

        public TeacherCandidateTeacherPreparationProviderProgramAssociationDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorGetByExample
    {
        public int TeacherPreparationProgramTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherPreparationProgramTypeDescriptorGetByIds() { }

        public TeacherPreparationProgramTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorPost : Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorPut : Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorDelete : IHasIdentifier 
    {
        public TeacherPreparationProgramTypeDescriptorDelete() { }

        public TeacherPreparationProgramTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherPreparationProviders
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderGetByExample
    {
        public string FederalLocaleCodeDescriptor { get; set; }
        public int SchoolId { get; set; }
        public int TeacherPreparationProviderId { get; set; }
        public int UniversityId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherPreparationProviderGetByIds() { }

        public TeacherPreparationProviderGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderPost : Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderPut : Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderDelete : IHasIdentifier 
    {
        public TeacherPreparationProviderDelete() { }

        public TeacherPreparationProviderDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms
{ 
   
    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string MajorSpecialization { get; set; }
        public string MinorSpecialization { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string TeacherPreparationProgramTypeDescriptor { get; set; }
        public string TPPProgramPathwayDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramGetByIds : IHasIdentifiers<Guid>
    {
        public TeacherPreparationProviderProgramGetByIds() { }

        public TeacherPreparationProviderProgramGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramPost : Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramPut : Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramDelete : IHasIdentifier 
    {
        public TeacherPreparationProviderProgramDelete() { }

        public TeacherPreparationProviderProgramDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ThemeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorGetByExample
    {
        public int ThemeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ThemeDescriptorGetByIds() { }

        public ThemeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorPost : Resources.ThemeDescriptor.TPDM.ThemeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorPut : Resources.ThemeDescriptor.TPDM.ThemeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorDelete : IHasIdentifier 
    {
        public ThemeDescriptorDelete() { }

        public ThemeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorGetByExample
    {
        public int TPPDegreeTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TPPDegreeTypeDescriptorGetByIds() { }

        public TPPDegreeTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorPost : Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorPut : Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorDelete : IHasIdentifier 
    {
        public TPPDegreeTypeDescriptorDelete() { }

        public TPPDegreeTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorGetByExample
    {
        public int TPPProgramPathwayDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TPPProgramPathwayDescriptorGetByIds() { }

        public TPPProgramPathwayDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorPost : Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorPut : Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorDelete : IHasIdentifier 
    {
        public TPPProgramPathwayDescriptorDelete() { }

        public TPPProgramPathwayDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.Universities
{ 
   
    [ExcludeFromCodeCoverage]
    public class UniversityGetByExample
    {
        public string FederalLocaleCodeDescriptor { get; set; }
        public int SchoolId { get; set; }
        public int UniversityId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class UniversityGetByIds : IHasIdentifiers<Guid>
    {
        public UniversityGetByIds() { }

        public UniversityGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class UniversityPost : Resources.University.TPDM.University
    {
    }

    [ExcludeFromCodeCoverage]
    public class UniversityPut : Resources.University.TPDM.University
    { 
    }

    [ExcludeFromCodeCoverage]
    public class UniversityDelete : IHasIdentifier 
    {
        public UniversityDelete() { }

        public UniversityDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.ValueTypeDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorGetByExample
    {
        public int ValueTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ValueTypeDescriptorGetByIds() { }

        public ValueTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorPost : Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorPut : Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorDelete : IHasIdentifier 
    {
        public ValueTypeDescriptorDelete() { }

        public ValueTypeDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Models.Requests.TPDM.WithdrawReasonDescriptors
{ 
   
    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorGetByExample
    {
        public int WithdrawReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public WithdrawReasonDescriptorGetByIds() { }

        public WithdrawReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorPost : Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorPut : Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor
    { 
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorDelete : IHasIdentifier 
    {
        public WithdrawReasonDescriptorDelete() { }

        public WithdrawReasonDescriptorDelete(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

