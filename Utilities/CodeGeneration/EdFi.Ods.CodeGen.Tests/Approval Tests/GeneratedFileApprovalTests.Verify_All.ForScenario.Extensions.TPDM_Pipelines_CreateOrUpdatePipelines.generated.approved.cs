using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.TPDM
{
    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor, Entities.NHibernate.AidTypeDescriptorAggregate.TPDM.AidTypeDescriptor>
    {
        public AidTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudent.TPDM.AnonymizedStudent, Entities.NHibernate.AnonymizedStudentAggregate.TPDM.AnonymizedStudent>
    {
        public AnonymizedStudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord, Entities.NHibernate.AnonymizedStudentAcademicRecordAggregate.TPDM.AnonymizedStudentAcademicRecord>
    {
        public AnonymizedStudentAcademicRecordCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment, Entities.NHibernate.AnonymizedStudentAssessmentAggregate.TPDM.AnonymizedStudentAssessment>
    {
        public AnonymizedStudentAssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation, Entities.NHibernate.AnonymizedStudentAssessmentCourseAssociationAggregate.TPDM.AnonymizedStudentAssessmentCourseAssociation>
    {
        public AnonymizedStudentAssessmentCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation, Entities.NHibernate.AnonymizedStudentAssessmentSectionAssociationAggregate.TPDM.AnonymizedStudentAssessmentSectionAssociation>
    {
        public AnonymizedStudentAssessmentSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation, Entities.NHibernate.AnonymizedStudentCourseAssociationAggregate.TPDM.AnonymizedStudentCourseAssociation>
    {
        public AnonymizedStudentCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript, Entities.NHibernate.AnonymizedStudentCourseTranscriptAggregate.TPDM.AnonymizedStudentCourseTranscript>
    {
        public AnonymizedStudentCourseTranscriptCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation, Entities.NHibernate.AnonymizedStudentEducationOrganizationAssociationAggregate.TPDM.AnonymizedStudentEducationOrganizationAssociation>
    {
        public AnonymizedStudentEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation, Entities.NHibernate.AnonymizedStudentSectionAssociationAggregate.TPDM.AnonymizedStudentSectionAssociation>
    {
        public AnonymizedStudentSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Applicant.TPDM.Applicant, Entities.NHibernate.ApplicantAggregate.TPDM.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation, Entities.NHibernate.ApplicantProspectAssociationAggregate.TPDM.ApplicantProspectAssociation>
    {
        public ApplicantProspectAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Application.TPDM.Application, Entities.NHibernate.ApplicationAggregate.TPDM.Application>
    {
        public ApplicationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicationEvent.TPDM.ApplicationEvent, Entities.NHibernate.ApplicationEventAggregate.TPDM.ApplicationEvent>
    {
        public ApplicationEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor, Entities.NHibernate.ApplicationEventResultDescriptorAggregate.TPDM.ApplicationEventResultDescriptor>
    {
        public ApplicationEventResultDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor, Entities.NHibernate.ApplicationEventTypeDescriptorAggregate.TPDM.ApplicationEventTypeDescriptor>
    {
        public ApplicationEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor, Entities.NHibernate.ApplicationSourceDescriptorAggregate.TPDM.ApplicationSourceDescriptor>
    {
        public ApplicationSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor, Entities.NHibernate.ApplicationStatusDescriptorAggregate.TPDM.ApplicationStatusDescriptor>
    {
        public ApplicationStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor, Entities.NHibernate.BackgroundCheckStatusDescriptorAggregate.TPDM.BackgroundCheckStatusDescriptor>
    {
        public BackgroundCheckStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor, Entities.NHibernate.BackgroundCheckTypeDescriptorAggregate.TPDM.BackgroundCheckTypeDescriptor>
    {
        public BackgroundCheckTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BoardCertificationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.BoardCertificationTypeDescriptor.TPDM.BoardCertificationTypeDescriptor, Entities.NHibernate.BoardCertificationTypeDescriptorAggregate.TPDM.BoardCertificationTypeDescriptor>
    {
        public BoardCertificationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor, Entities.NHibernate.CertificationExamStatusDescriptorAggregate.TPDM.CertificationExamStatusDescriptor>
    {
        public CertificationExamStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor, Entities.NHibernate.CertificationExamTypeDescriptorAggregate.TPDM.CertificationExamTypeDescriptor>
    {
        public CertificationExamTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation, Entities.NHibernate.CompleterAsStaffAssociationAggregate.TPDM.CompleterAsStaffAssociation>
    {
        public CompleterAsStaffAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor, Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM.CoteachingStyleObservedDescriptor>
    {
        public CoteachingStyleObservedDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CourseCourseTranscriptFacts.TPDM.CourseCourseTranscriptFacts, Entities.NHibernate.CourseCourseTranscriptFactsAggregate.TPDM.CourseCourseTranscriptFacts>
    {
        public CourseCourseTranscriptFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CourseStudentAcademicRecordFacts.TPDM.CourseStudentAcademicRecordFacts, Entities.NHibernate.CourseStudentAcademicRecordFactsAggregate.TPDM.CourseStudentAcademicRecordFacts>
    {
        public CourseStudentAcademicRecordFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CourseStudentAssessmentFacts.TPDM.CourseStudentAssessmentFacts, Entities.NHibernate.CourseStudentAssessmentFactsAggregate.TPDM.CourseStudentAssessmentFacts>
    {
        public CourseStudentAssessmentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.CourseStudentFacts.TPDM.CourseStudentFacts, Entities.NHibernate.CourseStudentFactsAggregate.TPDM.CourseStudentFacts>
    {
        public CourseStudentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EducationOrganizationCourseTranscriptFacts.TPDM.EducationOrganizationCourseTranscriptFacts, Entities.NHibernate.EducationOrganizationCourseTranscriptFactsAggregate.TPDM.EducationOrganizationCourseTranscriptFacts>
    {
        public EducationOrganizationCourseTranscriptFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EducationOrganizationFacts.TPDM.EducationOrganizationFacts, Entities.NHibernate.EducationOrganizationFactsAggregate.TPDM.EducationOrganizationFacts>
    {
        public EducationOrganizationFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EducationOrganizationStudentAcademicRecordFacts.TPDM.EducationOrganizationStudentAcademicRecordFacts, Entities.NHibernate.EducationOrganizationStudentAcademicRecordFactsAggregate.TPDM.EducationOrganizationStudentAcademicRecordFacts>
    {
        public EducationOrganizationStudentAcademicRecordFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EducationOrganizationStudentAssessmentFacts.TPDM.EducationOrganizationStudentAssessmentFacts, Entities.NHibernate.EducationOrganizationStudentAssessmentFactsAggregate.TPDM.EducationOrganizationStudentAssessmentFacts>
    {
        public EducationOrganizationStudentAssessmentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EducationOrganizationStudentFacts.TPDM.EducationOrganizationStudentFacts, Entities.NHibernate.EducationOrganizationStudentFactsAggregate.TPDM.EducationOrganizationStudentFacts>
    {
        public EducationOrganizationStudentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EmploymentEvent.TPDM.EmploymentEvent, Entities.NHibernate.EmploymentEventAggregate.TPDM.EmploymentEvent>
    {
        public EmploymentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor, Entities.NHibernate.EmploymentEventTypeDescriptorAggregate.TPDM.EmploymentEventTypeDescriptor>
    {
        public EmploymentEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent, Entities.NHibernate.EmploymentSeparationEventAggregate.TPDM.EmploymentSeparationEvent>
    {
        public EmploymentSeparationEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor, Entities.NHibernate.EmploymentSeparationReasonDescriptorAggregate.TPDM.EmploymentSeparationReasonDescriptor>
    {
        public EmploymentSeparationReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor, Entities.NHibernate.EmploymentSeparationTypeDescriptorAggregate.TPDM.EmploymentSeparationTypeDescriptor>
    {
        public EmploymentSeparationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor, Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM.EnglishLanguageExamDescriptor>
    {
        public EnglishLanguageExamDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor, Entities.NHibernate.FederalLocaleCodeDescriptorAggregate.TPDM.FederalLocaleCodeDescriptor>
    {
        public FederalLocaleCodeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor, Entities.NHibernate.FieldworkTypeDescriptorAggregate.TPDM.FieldworkTypeDescriptor>
    {
        public FieldworkTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor, Entities.NHibernate.FundingSourceDescriptorAggregate.TPDM.FundingSourceDescriptor>
    {
        public FundingSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.GenderDescriptor.TPDM.GenderDescriptor, Entities.NHibernate.GenderDescriptorAggregate.TPDM.GenderDescriptor>
    {
        public GenderDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor, Entities.NHibernate.HireStatusDescriptorAggregate.TPDM.HireStatusDescriptor>
    {
        public HireStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor, Entities.NHibernate.HiringSourceDescriptorAggregate.TPDM.HiringSourceDescriptor>
    {
        public HiringSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor, Entities.NHibernate.InternalExternalHireDescriptorAggregate.TPDM.InternalExternalHireDescriptor>
    {
        public InternalExternalHireDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor, Entities.NHibernate.LevelOfDegreeAwardedDescriptorAggregate.TPDM.LevelOfDegreeAwardedDescriptor>
    {
        public LevelOfDegreeAwardedDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class LevelTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.LevelTypeDescriptor.TPDM.LevelTypeDescriptor, Entities.NHibernate.LevelTypeDescriptorAggregate.TPDM.LevelTypeDescriptor>
    {
        public LevelTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent, Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM.OpenStaffPositionEvent>
    {
        public OpenStaffPositionEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor, Entities.NHibernate.OpenStaffPositionEventStatusDescriptorAggregate.TPDM.OpenStaffPositionEventStatusDescriptor>
    {
        public OpenStaffPositionEventStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor, Entities.NHibernate.OpenStaffPositionEventTypeDescriptorAggregate.TPDM.OpenStaffPositionEventTypeDescriptor>
    {
        public OpenStaffPositionEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor, Entities.NHibernate.OpenStaffPositionReasonDescriptorAggregate.TPDM.OpenStaffPositionReasonDescriptor>
    {
        public OpenStaffPositionReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PerformanceMeasure.TPDM.PerformanceMeasure, Entities.NHibernate.PerformanceMeasureAggregate.TPDM.PerformanceMeasure>
    {
        public PerformanceMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PerformanceMeasureCourseAssociation.TPDM.PerformanceMeasureCourseAssociation, Entities.NHibernate.PerformanceMeasureCourseAssociationAggregate.TPDM.PerformanceMeasureCourseAssociation>
    {
        public PerformanceMeasureCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PerformanceMeasureFacts.TPDM.PerformanceMeasureFacts, Entities.NHibernate.PerformanceMeasureFactsAggregate.TPDM.PerformanceMeasureFacts>
    {
        public PerformanceMeasureFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureInstanceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PerformanceMeasureInstanceDescriptor.TPDM.PerformanceMeasureInstanceDescriptor, Entities.NHibernate.PerformanceMeasureInstanceDescriptorAggregate.TPDM.PerformanceMeasureInstanceDescriptor>
    {
        public PerformanceMeasureInstanceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PerformanceMeasureTypeDescriptor.TPDM.PerformanceMeasureTypeDescriptor, Entities.NHibernate.PerformanceMeasureTypeDescriptorAggregate.TPDM.PerformanceMeasureTypeDescriptor>
    {
        public PerformanceMeasureTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor, Entities.NHibernate.PreviousCareerDescriptorAggregate.TPDM.PreviousCareerDescriptor>
    {
        public PreviousCareerDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent, Entities.NHibernate.ProfessionalDevelopmentEventAggregate.TPDM.ProfessionalDevelopmentEvent>
    {
        public ProfessionalDevelopmentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor, Entities.NHibernate.ProfessionalDevelopmentOfferedByDescriptorAggregate.TPDM.ProfessionalDevelopmentOfferedByDescriptor>
    {
        public ProfessionalDevelopmentOfferedByDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor, Entities.NHibernate.ProgramGatewayDescriptorAggregate.TPDM.ProgramGatewayDescriptor>
    {
        public ProgramGatewayDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Prospect.TPDM.Prospect, Entities.NHibernate.ProspectAggregate.TPDM.Prospect>
    {
        public ProspectCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ProspectProfessionalDevelopmentEventAttendance.TPDM.ProspectProfessionalDevelopmentEventAttendance, Entities.NHibernate.ProspectProfessionalDevelopmentEventAttendanceAggregate.TPDM.ProspectProfessionalDevelopmentEventAttendance>
    {
        public ProspectProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor, Entities.NHibernate.ProspectTypeDescriptorAggregate.TPDM.ProspectTypeDescriptor>
    {
        public ProspectTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent, Entities.NHibernate.RecruitmentEventAggregate.TPDM.RecruitmentEvent>
    {
        public RecruitmentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor, Entities.NHibernate.RecruitmentEventTypeDescriptorAggregate.TPDM.RecruitmentEventTypeDescriptor>
    {
        public RecruitmentEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Rubric.TPDM.Rubric, Entities.NHibernate.RubricAggregate.TPDM.Rubric>
    {
        public RubricCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RubricLevel.TPDM.RubricLevel, Entities.NHibernate.RubricLevelAggregate.TPDM.RubricLevel>
    {
        public RubricLevelCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RubricLevelResponse.TPDM.RubricLevelResponse, Entities.NHibernate.RubricLevelResponseAggregate.TPDM.RubricLevelResponse>
    {
        public RubricLevelResponseCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RubricLevelResponseFacts.TPDM.RubricLevelResponseFacts, Entities.NHibernate.RubricLevelResponseFactsAggregate.TPDM.RubricLevelResponseFacts>
    {
        public RubricLevelResponseFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.RubricTypeDescriptor.TPDM.RubricTypeDescriptor, Entities.NHibernate.RubricTypeDescriptorAggregate.TPDM.RubricTypeDescriptor>
    {
        public RubricTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor, Entities.NHibernate.SalaryTypeDescriptorAggregate.TPDM.SalaryTypeDescriptor>
    {
        public SalaryTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor, Entities.NHibernate.SchoolStatusDescriptorAggregate.TPDM.SchoolStatusDescriptor>
    {
        public SchoolStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SectionCourseTranscriptFacts.TPDM.SectionCourseTranscriptFacts, Entities.NHibernate.SectionCourseTranscriptFactsAggregate.TPDM.SectionCourseTranscriptFacts>
    {
        public SectionCourseTranscriptFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SectionStudentAcademicRecordFacts.TPDM.SectionStudentAcademicRecordFacts, Entities.NHibernate.SectionStudentAcademicRecordFactsAggregate.TPDM.SectionStudentAcademicRecordFacts>
    {
        public SectionStudentAcademicRecordFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SectionStudentAssessmentFacts.TPDM.SectionStudentAssessmentFacts, Entities.NHibernate.SectionStudentAssessmentFactsAggregate.TPDM.SectionStudentAssessmentFacts>
    {
        public SectionStudentAssessmentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.SectionStudentFacts.TPDM.SectionStudentFacts, Entities.NHibernate.SectionStudentFactsAggregate.TPDM.SectionStudentFacts>
    {
        public SectionStudentFactsCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation, Entities.NHibernate.StaffApplicantAssociationAggregate.TPDM.StaffApplicantAssociation>
    {
        public StaffApplicantAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluation.TPDM.StaffEvaluation, Entities.NHibernate.StaffEvaluationAggregate.TPDM.StaffEvaluation>
    {
        public StaffEvaluationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationComponent.TPDM.StaffEvaluationComponent, Entities.NHibernate.StaffEvaluationComponentAggregate.TPDM.StaffEvaluationComponent>
    {
        public StaffEvaluationComponentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationComponentRating.TPDM.StaffEvaluationComponentRating, Entities.NHibernate.StaffEvaluationComponentRatingAggregate.TPDM.StaffEvaluationComponentRating>
    {
        public StaffEvaluationComponentRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationElement.TPDM.StaffEvaluationElement, Entities.NHibernate.StaffEvaluationElementAggregate.TPDM.StaffEvaluationElement>
    {
        public StaffEvaluationElementCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationElementRating.TPDM.StaffEvaluationElementRating, Entities.NHibernate.StaffEvaluationElementRatingAggregate.TPDM.StaffEvaluationElementRating>
    {
        public StaffEvaluationElementRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationPeriodDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationPeriodDescriptor.TPDM.StaffEvaluationPeriodDescriptor, Entities.NHibernate.StaffEvaluationPeriodDescriptorAggregate.TPDM.StaffEvaluationPeriodDescriptor>
    {
        public StaffEvaluationPeriodDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationRating.TPDM.StaffEvaluationRating, Entities.NHibernate.StaffEvaluationRatingAggregate.TPDM.StaffEvaluationRating>
    {
        public StaffEvaluationRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationRatingLevelDescriptor.TPDM.StaffEvaluationRatingLevelDescriptor, Entities.NHibernate.StaffEvaluationRatingLevelDescriptorAggregate.TPDM.StaffEvaluationRatingLevelDescriptor>
    {
        public StaffEvaluationRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEvaluationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffEvaluationTypeDescriptor.TPDM.StaffEvaluationTypeDescriptor, Entities.NHibernate.StaffEvaluationTypeDescriptorAggregate.TPDM.StaffEvaluationTypeDescriptor>
    {
        public StaffEvaluationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffFieldworkAbsenceEvent.TPDM.StaffFieldworkAbsenceEvent, Entities.NHibernate.StaffFieldworkAbsenceEventAggregate.TPDM.StaffFieldworkAbsenceEvent>
    {
        public StaffFieldworkAbsenceEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffFieldworkExperience.TPDM.StaffFieldworkExperience, Entities.NHibernate.StaffFieldworkExperienceAggregate.TPDM.StaffFieldworkExperience>
    {
        public StaffFieldworkExperienceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffFieldworkExperienceSectionAssociation.TPDM.StaffFieldworkExperienceSectionAssociation, Entities.NHibernate.StaffFieldworkExperienceSectionAssociationAggregate.TPDM.StaffFieldworkExperienceSectionAssociation>
    {
        public StaffFieldworkExperienceSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffProfessionalDevelopmentEventAttendance.TPDM.StaffProfessionalDevelopmentEventAttendance, Entities.NHibernate.StaffProfessionalDevelopmentEventAttendanceAggregate.TPDM.StaffProfessionalDevelopmentEventAttendance>
    {
        public StaffProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation, Entities.NHibernate.StaffProspectAssociationAggregate.TPDM.StaffProspectAssociation>
    {
        public StaffProspectAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure, Entities.NHibernate.StaffStudentGrowthMeasureAggregate.TPDM.StaffStudentGrowthMeasure>
    {
        public StaffStudentGrowthMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation, Entities.NHibernate.StaffStudentGrowthMeasureCourseAssociationAggregate.TPDM.StaffStudentGrowthMeasureCourseAssociation>
    {
        public StaffStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation, Entities.NHibernate.StaffStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation>
    {
        public StaffStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation, Entities.NHibernate.StaffStudentGrowthMeasureSectionAssociationAggregate.TPDM.StaffStudentGrowthMeasureSectionAssociation>
    {
        public StaffStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation, Entities.NHibernate.StaffTeacherPreparationProviderAssociationAggregate.TPDM.StaffTeacherPreparationProviderAssociation>
    {
        public StaffTeacherPreparationProviderAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation, Entities.NHibernate.StaffTeacherPreparationProviderProgramAssociationAggregate.TPDM.StaffTeacherPreparationProviderProgramAssociation>
    {
        public StaffTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor, Entities.NHibernate.StudentGrowthTypeDescriptorAggregate.TPDM.StudentGrowthTypeDescriptor>
    {
        public StudentGrowthTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TalentManagementGoalCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TalentManagementGoal.TPDM.TalentManagementGoal, Entities.NHibernate.TalentManagementGoalAggregate.TPDM.TalentManagementGoal>
    {
        public TalentManagementGoalCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidate.TPDM.TeacherCandidate, Entities.NHibernate.TeacherCandidateAggregate.TPDM.TeacherCandidate>
    {
        public TeacherCandidateCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord, Entities.NHibernate.TeacherCandidateAcademicRecordAggregate.TPDM.TeacherCandidateAcademicRecord>
    {
        public TeacherCandidateAcademicRecordCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor, Entities.NHibernate.TeacherCandidateCharacteristicDescriptorAggregate.TPDM.TeacherCandidateCharacteristicDescriptor>
    {
        public TeacherCandidateCharacteristicDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript, Entities.NHibernate.TeacherCandidateCourseTranscriptAggregate.TPDM.TeacherCandidateCourseTranscript>
    {
        public TeacherCandidateCourseTranscriptCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkAbsenceEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateFieldworkAbsenceEvent.TPDM.TeacherCandidateFieldworkAbsenceEvent, Entities.NHibernate.TeacherCandidateFieldworkAbsenceEventAggregate.TPDM.TeacherCandidateFieldworkAbsenceEvent>
    {
        public TeacherCandidateFieldworkAbsenceEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateFieldworkExperience.TPDM.TeacherCandidateFieldworkExperience, Entities.NHibernate.TeacherCandidateFieldworkExperienceAggregate.TPDM.TeacherCandidateFieldworkExperience>
    {
        public TeacherCandidateFieldworkExperienceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateFieldworkExperienceSectionAssociation.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation, Entities.NHibernate.TeacherCandidateFieldworkExperienceSectionAssociationAggregate.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation>
    {
        public TeacherCandidateFieldworkExperienceSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateProfessionalDevelopmentEventAttendance.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance, Entities.NHibernate.TeacherCandidateProfessionalDevelopmentEventAttendanceAggregate.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance>
    {
        public TeacherCandidateProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation, Entities.NHibernate.TeacherCandidateStaffAssociationAggregate.TPDM.TeacherCandidateStaffAssociation>
    {
        public TeacherCandidateStaffAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureAggregate.TPDM.TeacherCandidateStudentGrowthMeasure>
    {
        public TeacherCandidateStudentGrowthMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureCourseAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureSectionAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation, Entities.NHibernate.TeacherCandidateTeacherPreparationProviderAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderAssociation>
    {
        public TeacherCandidateTeacherPreparationProviderAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation, Entities.NHibernate.TeacherCandidateTeacherPreparationProviderProgramAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation>
    {
        public TeacherCandidateTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor, Entities.NHibernate.TeacherPreparationProgramTypeDescriptorAggregate.TPDM.TeacherPreparationProgramTypeDescriptor>
    {
        public TeacherPreparationProgramTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider, Entities.NHibernate.TeacherPreparationProviderAggregate.TPDM.TeacherPreparationProvider>
    {
        public TeacherPreparationProviderCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram, Entities.NHibernate.TeacherPreparationProviderProgramAggregate.TPDM.TeacherPreparationProviderProgram>
    {
        public TeacherPreparationProviderProgramCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ThemeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ThemeDescriptor.TPDM.ThemeDescriptor, Entities.NHibernate.ThemeDescriptorAggregate.TPDM.ThemeDescriptor>
    {
        public ThemeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor, Entities.NHibernate.TPPDegreeTypeDescriptorAggregate.TPDM.TPPDegreeTypeDescriptor>
    {
        public TPPDegreeTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor, Entities.NHibernate.TPPProgramPathwayDescriptorAggregate.TPDM.TPPProgramPathwayDescriptor>
    {
        public TPPProgramPathwayDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class UniversityCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.University.TPDM.University, Entities.NHibernate.UniversityAggregate.TPDM.University>
    {
        public UniversityCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor, Entities.NHibernate.ValueTypeDescriptorAggregate.TPDM.ValueTypeDescriptor>
    {
        public ValueTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor, Entities.NHibernate.WithdrawReasonDescriptorAggregate.TPDM.WithdrawReasonDescriptor>
    {
        public WithdrawReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
