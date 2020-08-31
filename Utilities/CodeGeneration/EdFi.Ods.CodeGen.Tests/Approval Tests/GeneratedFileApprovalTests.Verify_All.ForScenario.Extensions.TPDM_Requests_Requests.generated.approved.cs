using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorGetByExample
    {
        public int AccreditationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AccreditationStatusDescriptorGetByIds() { }

        public AccreditationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorPost : Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorPut : Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorDelete : IHasIdentifier
    {
        public AccreditationStatusDescriptorDelete() { }

        public AccreditationStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AidTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentAcademicRecords
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentAssessments
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentCourseAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.AnonymizedStudentSectionAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Applicants
{

    [ExcludeFromCodeCoverage]
    public class ApplicantGetByExample
    {
        public string ApplicantIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public bool EconomicDisadvantaged { get; set; }
        public bool FirstGenerationStudent { get; set; }
        public string FirstName { get; set; }
        public string GenderDescriptor { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicantProspectAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Applications
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
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public string HighNeedsAcademicSubjectDescriptor { get; set; }
        public string HireStatusDescriptor { get; set; }
        public string HiringSourceDescriptor { get; set; }
        public Guid Id { get; set; }
        public DateTime WithdrawDate { get; set; }
        public string WithdrawReasonDescriptor { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicationEvents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Certifications
{

    [ExcludeFromCodeCoverage]
    public class CertificationGetByExample
    {
        public string CertificationFieldDescriptor { get; set; }
        public string CertificationIdentifier { get; set; }
        public string CertificationLevelDescriptor { get; set; }
        public string CertificationStandardDescriptor { get; set; }
        public string CertificationTitle { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EducatorRoleDescriptor { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string InstructionalSettingDescriptor { get; set; }
        public string MinimumDegreeDescriptor { get; set; }
        public string Namespace { get; set; }
        public string PopulationServedDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationGetByIds() { }

        public CertificationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationPost : Resources.Certification.TPDM.Certification
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationPut : Resources.Certification.TPDM.Certification
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationDelete : IHasIdentifier
    {
        public CertificationDelete() { }

        public CertificationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationExams
{

    [ExcludeFromCodeCoverage]
    public class CertificationExamGetByExample
    {
        public string CertificationExamIdentifier { get; set; }
        public string CertificationExamTitle { get; set; }
        public string CertificationExamTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationExamGetByIds() { }

        public CertificationExamGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamPost : Resources.CertificationExam.TPDM.CertificationExam
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamPut : Resources.CertificationExam.TPDM.CertificationExam
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamDelete : IHasIdentifier
    {
        public CertificationExamDelete() { }

        public CertificationExamDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationExamResults
{

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultGetByExample
    {
        public int AttemptNumber { get; set; }
        public DateTime CertificationExamDate { get; set; }
        public string CertificationExamIdentifier { get; set; }
        public bool CertificationExamPassIndicator { get; set; }
        public decimal CertificationExamScore { get; set; }
        public string CertificationExamStatusDescriptor { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationExamResultGetByIds() { }

        public CertificationExamResultGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultPost : Resources.CertificationExamResult.TPDM.CertificationExamResult
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultPut : Resources.CertificationExamResult.TPDM.CertificationExamResult
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultDelete : IHasIdentifier
    {
        public CertificationExamResultDelete() { }

        public CertificationExamResultDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorGetByExample
    {
        public int CertificationFieldDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationFieldDescriptorGetByIds() { }

        public CertificationFieldDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorPost : Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorPut : Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorDelete : IHasIdentifier
    {
        public CertificationFieldDescriptorDelete() { }

        public CertificationFieldDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorGetByExample
    {
        public int CertificationLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationLevelDescriptorGetByIds() { }

        public CertificationLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorPost : Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorPut : Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorDelete : IHasIdentifier
    {
        public CertificationLevelDescriptorDelete() { }

        public CertificationLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorGetByExample
    {
        public int CertificationRouteDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationRouteDescriptorGetByIds() { }

        public CertificationRouteDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorPost : Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorPut : Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorDelete : IHasIdentifier
    {
        public CertificationRouteDescriptorDelete() { }

        public CertificationRouteDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorGetByExample
    {
        public int CertificationStandardDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CertificationStandardDescriptorGetByIds() { }

        public CertificationStandardDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorPost : Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorPut : Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorDelete : IHasIdentifier
    {
        public CertificationStandardDescriptorDelete() { }

        public CertificationStandardDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CompleterAsStaffAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CredentialEvents
{

    [ExcludeFromCodeCoverage]
    public class CredentialEventGetByExample
    {
        public DateTime CredentialEventDate { get; set; }
        public string CredentialEventReason { get; set; }
        public string CredentialEventTypeDescriptor { get; set; }
        public string CredentialIdentifier { get; set; }
        public Guid Id { get; set; }
        public string StateOfIssueStateAbbreviationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialEventGetByIds() { }

        public CredentialEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventPost : Resources.CredentialEvent.TPDM.CredentialEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventPut : Resources.CredentialEvent.TPDM.CredentialEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventDelete : IHasIdentifier
    {
        public CredentialEventDelete() { }

        public CredentialEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorGetByExample
    {
        public int CredentialEventTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialEventTypeDescriptorGetByIds() { }

        public CredentialEventTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorPost : Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorPut : Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorDelete : IHasIdentifier
    {
        public CredentialEventTypeDescriptorDelete() { }

        public CredentialEventTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors
{

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorGetByExample
    {
        public int CredentialStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialStatusDescriptorGetByIds() { }

        public CredentialStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorPost : Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorPut : Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorDelete : IHasIdentifier
    {
        public CredentialStatusDescriptorDelete() { }

        public CredentialStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.DegreeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorGetByExample
    {
        public int DegreeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DegreeDescriptorGetByIds() { }

        public DegreeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorPost : Resources.DegreeDescriptor.TPDM.DegreeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorPut : Resources.DegreeDescriptor.TPDM.DegreeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorDelete : IHasIdentifier
    {
        public DegreeDescriptorDelete() { }

        public DegreeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorGetByExample
    {
        public int EducatorRoleDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducatorRoleDescriptorGetByIds() { }

        public EducatorRoleDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorPost : Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorPut : Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorDelete : IHasIdentifier
    {
        public EducatorRoleDescriptorDelete() { }

        public EducatorRoleDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EmploymentEvents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EmploymentEventTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EmploymentSeparationEvents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Evaluations
{

    [ExcludeFromCodeCoverage]
    public class EvaluationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public int InterRaterReliabilityScore { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationGetByIds() { }

        public EvaluationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPost : Resources.Evaluation.TPDM.Evaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPut : Resources.Evaluation.TPDM.Evaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationDelete : IHasIdentifier
    {
        public EvaluationDelete() { }

        public EvaluationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElements
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public int SortOrder { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementGetByIds() { }

        public EvaluationElementGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementPost : Resources.EvaluationElement.TPDM.EvaluationElement
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementPut : Resources.EvaluationElement.TPDM.EvaluationElement
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementDelete : IHasIdentifier
    {
        public EvaluationElementDelete() { }

        public EvaluationElementDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElementRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingGetByExample
    {
        public string AreaOfRefinement { get; set; }
        public string AreaOfReinforcement { get; set; }
        public string Comments { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationElementRatingLevelDescriptor { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string Feedback { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementRatingGetByIds() { }

        public EvaluationElementRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingPost : Resources.EvaluationElementRating.TPDM.EvaluationElementRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingPut : Resources.EvaluationElementRating.TPDM.EvaluationElementRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingDelete : IHasIdentifier
    {
        public EvaluationElementRatingDelete() { }

        public EvaluationElementRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorGetByExample
    {
        public int EvaluationElementRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationElementRatingLevelDescriptorGetByIds() { }

        public EvaluationElementRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorPost : Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorPut : Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorDelete : IHasIdentifier
    {
        public EvaluationElementRatingLevelDescriptorDelete() { }

        public EvaluationElementRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationObjectives
{

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string EvaluationTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRating { get; set; }
        public decimal MinRating { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public int SortOrder { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationObjectiveGetByIds() { }

        public EvaluationObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectivePost : Resources.EvaluationObjective.TPDM.EvaluationObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectivePut : Resources.EvaluationObjective.TPDM.EvaluationObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveDelete : IHasIdentifier
    {
        public EvaluationObjectiveDelete() { }

        public EvaluationObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingGetByExample
    {
        public string Comments { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string ObjectiveRatingLevelDescriptor { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationObjectiveRatingGetByIds() { }

        public EvaluationObjectiveRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingPost : Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingPut : Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingDelete : IHasIdentifier
    {
        public EvaluationObjectiveRatingDelete() { }

        public EvaluationObjectiveRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorGetByExample
    {
        public int EvaluationPeriodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationPeriodDescriptorGetByIds() { }

        public EvaluationPeriodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorPost : Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorPut : Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorDelete : IHasIdentifier
    {
        public EvaluationPeriodDescriptorDelete() { }

        public EvaluationPeriodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationRatings
{

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationRatingLevelDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationRatingGetByIds() { }

        public EvaluationRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingPost : Resources.EvaluationRating.TPDM.EvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingPut : Resources.EvaluationRating.TPDM.EvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingDelete : IHasIdentifier
    {
        public EvaluationRatingDelete() { }

        public EvaluationRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorGetByExample
    {
        public int EvaluationRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationRatingLevelDescriptorGetByIds() { }

        public EvaluationRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorPost : Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorPut : Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorDelete : IHasIdentifier
    {
        public EvaluationRatingLevelDescriptorDelete() { }

        public EvaluationRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorGetByExample
    {
        public int EvaluationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EvaluationTypeDescriptorGetByIds() { }

        public EvaluationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorPost : Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorPut : Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorDelete : IHasIdentifier
    {
        public EvaluationTypeDescriptorDelete() { }

        public EvaluationTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FieldworkExperiences
{

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public string FieldworkTypeDescriptor { get; set; }
        public decimal HoursCompleted { get; set; }
        public Guid Id { get; set; }
        public string ProgramGatewayDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceGetByIds : IHasIdentifiers<Guid>
    {
        public FieldworkExperienceGetByIds() { }

        public FieldworkExperienceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperiencePost : Resources.FieldworkExperience.TPDM.FieldworkExperience
    {
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperiencePut : Resources.FieldworkExperience.TPDM.FieldworkExperience
    {
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceDelete : IHasIdentifier
    {
        public FieldworkExperienceDelete() { }

        public FieldworkExperienceDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations
{

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string FieldworkIdentifier { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public FieldworkExperienceSectionAssociationGetByIds() { }

        public FieldworkExperienceSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationPost : Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationPut : Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationDelete : IHasIdentifier
    {
        public FieldworkExperienceSectionAssociationDelete() { }

        public FieldworkExperienceSectionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.FundingSourceDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.GenderDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Goals
{

    [ExcludeFromCodeCoverage]
    public class GoalGetByExample
    {
        public DateTime AssignmentDate { get; set; }
        public string Comments { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool CompletedIndicator { get; set; }
        public DateTime DueDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public string GoalDescription { get; set; }
        public string GoalTitle { get; set; }
        public string GoalTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GoalGetByIds : IHasIdentifiers<Guid>
    {
        public GoalGetByIds() { }

        public GoalGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GoalPost : Resources.Goal.TPDM.Goal
    {
    }

    [ExcludeFromCodeCoverage]
    public class GoalPut : Resources.Goal.TPDM.Goal
    {
    }

    [ExcludeFromCodeCoverage]
    public class GoalDelete : IHasIdentifier
    {
        public GoalDelete() { }

        public GoalDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.GoalTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorGetByExample
    {
        public int GoalTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GoalTypeDescriptorGetByIds() { }

        public GoalTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorPost : Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorPut : Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorDelete : IHasIdentifier
    {
        public GoalTypeDescriptorDelete() { }

        public GoalTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.HireStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.HiringSourceDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors
{

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorGetByExample
    {
        public int InstructionalSettingDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InstructionalSettingDescriptorGetByIds() { }

        public InstructionalSettingDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorPost : Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorPut : Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorDelete : IHasIdentifier
    {
        public InstructionalSettingDescriptorDelete() { }

        public InstructionalSettingDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.InternalExternalHireDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorGetByExample
    {
        public int ObjectiveRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ObjectiveRatingLevelDescriptorGetByIds() { }

        public ObjectiveRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorPost : Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorPut : Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorDelete : IHasIdentifier
    {
        public ObjectiveRatingLevelDescriptorDelete() { }

        public ObjectiveRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluations
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationGetByIds() { }

        public PerformanceEvaluationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationPost : Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationPut : Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationDelete : IHasIdentifier
    {
        public PerformanceEvaluationDelete() { }

        public PerformanceEvaluationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingGetByExample
    {
        public DateTime ActualDate { get; set; }
        public int ActualDuration { get; set; }
        public TimeSpan ActualTime { get; set; }
        public bool Announced { get; set; }
        public string Comments { get; set; }
        public string CoteachingStyleObservedDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationRatingLevelDescriptor { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public short SchoolYear { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationRatingGetByIds() { }

        public PerformanceEvaluationRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingPost : Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingPut : Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingDelete : IHasIdentifier
    {
        public PerformanceEvaluationRatingDelete() { }

        public PerformanceEvaluationRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorGetByExample
    {
        public int PerformanceEvaluationRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationRatingLevelDescriptorGetByIds() { }

        public PerformanceEvaluationRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorPost : Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorPut : Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorDelete : IHasIdentifier
    {
        public PerformanceEvaluationRatingLevelDescriptorDelete() { }

        public PerformanceEvaluationRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorGetByExample
    {
        public int PerformanceEvaluationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceEvaluationTypeDescriptorGetByIds() { }

        public PerformanceEvaluationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorPost : Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorPut : Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorDelete : IHasIdentifier
    {
        public PerformanceEvaluationTypeDescriptorDelete() { }

        public PerformanceEvaluationTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents
{

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventGetByExample
    {
        public Guid Id { get; set; }
        public bool MultipleSession { get; set; }
        public string Namespace { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances
{

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendanceGetByExample
    {
        public DateTime AttendanceDate { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PersonId { get; set; }
        public string ProfessionalDevelopmentTitle { get; set; }
        public string SourceSystemDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendanceGetByIds : IHasIdentifiers<Guid>
    {
        public ProfessionalDevelopmentEventAttendanceGetByIds() { }

        public ProfessionalDevelopmentEventAttendanceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendancePost : Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendancePut : Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendanceDelete : IHasIdentifier
    {
        public ProfessionalDevelopmentEventAttendanceDelete() { }

        public ProfessionalDevelopmentEventAttendanceDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Prospects
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
        public string PersonId { get; set; }
        public int PreScreeningRating { get; set; }
        public string ProspectIdentifier { get; set; }
        public string ProspectTypeDescriptor { get; set; }
        public bool Referral { get; set; }
        public string ReferredBy { get; set; }
        public string SexDescriptor { get; set; }
        public string SocialMediaNetworkName { get; set; }
        public string SocialMediaUserName { get; set; }
        public string SourceSystemDescriptor { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ProspectTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.QuantitativeMeasures
{

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string QuantitativeMeasureDatatypeDescriptor { get; set; }
        public string QuantitativeMeasureIdentifier { get; set; }
        public string QuantitativeMeasureTypeDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureGetByIds : IHasIdentifiers<Guid>
    {
        public QuantitativeMeasureGetByIds() { }

        public QuantitativeMeasureGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasurePost : Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasurePut : Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDelete : IHasIdentifier
    {
        public QuantitativeMeasureDelete() { }

        public QuantitativeMeasureDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorGetByExample
    {
        public int QuantitativeMeasureDatatypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public QuantitativeMeasureDatatypeDescriptorGetByIds() { }

        public QuantitativeMeasureDatatypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorPost : Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorPut : Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorDelete : IHasIdentifier
    {
        public QuantitativeMeasureDatatypeDescriptorDelete() { }

        public QuantitativeMeasureDatatypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores
{

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public string QuantitativeMeasureIdentifier { get; set; }
        public short SchoolYear { get; set; }
        public decimal ScoreValue { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public decimal StandardError { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreGetByIds : IHasIdentifiers<Guid>
    {
        public QuantitativeMeasureScoreGetByIds() { }

        public QuantitativeMeasureScoreGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScorePost : Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScorePut : Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreDelete : IHasIdentifier
    {
        public QuantitativeMeasureScoreDelete() { }

        public QuantitativeMeasureScoreDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorGetByExample
    {
        public int QuantitativeMeasureTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public QuantitativeMeasureTypeDescriptorGetByIds() { }

        public QuantitativeMeasureTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorPost : Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorPut : Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorDelete : IHasIdentifier
    {
        public QuantitativeMeasureTypeDescriptorDelete() { }

        public QuantitativeMeasureTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RecruitmentEvents
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RubricDimensions
{

    [ExcludeFromCodeCoverage]
    public class RubricDimensionGetByExample
    {
        public string CriterionDescription { get; set; }
        public int DimensionOrder { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public int RubricRating { get; set; }
        public string RubricRatingLevelDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public RubricDimensionGetByIds() { }

        public RubricDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionPost : Resources.RubricDimension.TPDM.RubricDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionPut : Resources.RubricDimension.TPDM.RubricDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionDelete : IHasIdentifier
    {
        public RubricDimensionDelete() { }

        public RubricDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors
{

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorGetByExample
    {
        public int RubricRatingLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RubricRatingLevelDescriptorGetByIds() { }

        public RubricRatingLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorPost : Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorPut : Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorDelete : IHasIdentifier
    {
        public RubricRatingLevelDescriptorDelete() { }

        public RubricRatingLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SchoolStatusDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffApplicantAssociations
{

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationGetByExample
    {
        public string ApplicantIdentifier { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffProspectAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffStudentGrowthMeasures
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.StudentGrowthTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations
{

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyResponseTeacherCandidateTargetAssociationGetByIds() { }

        public SurveyResponseTeacherCandidateTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationPost : Resources.SurveyResponseTeacherCandidateTargetAssociation.TPDM.SurveyResponseTeacherCandidateTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationPut : Resources.SurveyResponseTeacherCandidateTargetAssociation.TPDM.SurveyResponseTeacherCandidateTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationDelete : IHasIdentifier
    {
        public SurveyResponseTeacherCandidateTargetAssociationDelete() { }

        public SurveyResponseTeacherCandidateTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationPeriodDescriptor { get; set; }
        public string EvaluationTitle { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string PerformanceEvaluationTypeDescriptor { get; set; }
        public string PersonId { get; set; }
        public short SchoolYear { get; set; }
        public decimal ScoreValue { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionAggregateResponseGetByIds() { }

        public SurveySectionAggregateResponseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponsePost : Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponsePut : Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseDelete : IHasIdentifier
    {
        public SurveySectionAggregateResponseDelete() { }

        public SurveySectionAggregateResponseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
        public string TeacherCandidateIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionResponseTeacherCandidateTargetAssociationGetByIds() { }

        public SurveySectionResponseTeacherCandidateTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationPost : Resources.SurveySectionResponseTeacherCandidateTargetAssociation.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationPut : Resources.SurveySectionResponseTeacherCandidateTargetAssociation.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationDelete : IHasIdentifier
    {
        public SurveySectionResponseTeacherCandidateTargetAssociationDelete() { }

        public SurveySectionResponseTeacherCandidateTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidates
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
        public string PersonId { get; set; }
        public string PreviousCareerDescriptor { get; set; }
        public string ProfileThumbnail { get; set; }
        public bool ProgramComplete { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateAcademicRecords
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateCourseTranscripts
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateStaffAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherPreparationProviders
{

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderGetByExample
    {
        public string AccreditationStatusDescriptor { get; set; }
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TeacherPreparationProviderPrograms
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TPPDegreeTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.TPPProgramPathwayDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.Universities
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.ValueTypeDescriptors
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

namespace EdFi.Ods.Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors
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

