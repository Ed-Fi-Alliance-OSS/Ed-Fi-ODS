using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.TPDM
{
    [ExcludeFromCodeCoverage]
    public class AccreditationStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor, Entities.NHibernate.AccreditationStatusDescriptorAggregate.TPDM.AccreditationStatusDescriptor>
    {
        public AccreditationStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AidTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor, Entities.NHibernate.AidTypeDescriptorAggregate.TPDM.AidTypeDescriptor>
    {
        public AidTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudent.TPDM.AnonymizedStudent, Entities.NHibernate.AnonymizedStudentAggregate.TPDM.AnonymizedStudent>
    {
        public AnonymizedStudentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord, Entities.NHibernate.AnonymizedStudentAcademicRecordAggregate.TPDM.AnonymizedStudentAcademicRecord>
    {
        public AnonymizedStudentAcademicRecordCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment, Entities.NHibernate.AnonymizedStudentAssessmentAggregate.TPDM.AnonymizedStudentAssessment>
    {
        public AnonymizedStudentAssessmentCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation, Entities.NHibernate.AnonymizedStudentAssessmentCourseAssociationAggregate.TPDM.AnonymizedStudentAssessmentCourseAssociation>
    {
        public AnonymizedStudentAssessmentCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation, Entities.NHibernate.AnonymizedStudentAssessmentSectionAssociationAggregate.TPDM.AnonymizedStudentAssessmentSectionAssociation>
    {
        public AnonymizedStudentAssessmentSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation, Entities.NHibernate.AnonymizedStudentCourseAssociationAggregate.TPDM.AnonymizedStudentCourseAssociation>
    {
        public AnonymizedStudentCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript, Entities.NHibernate.AnonymizedStudentCourseTranscriptAggregate.TPDM.AnonymizedStudentCourseTranscript>
    {
        public AnonymizedStudentCourseTranscriptCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation, Entities.NHibernate.AnonymizedStudentEducationOrganizationAssociationAggregate.TPDM.AnonymizedStudentEducationOrganizationAssociation>
    {
        public AnonymizedStudentEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation, Entities.NHibernate.AnonymizedStudentSectionAssociationAggregate.TPDM.AnonymizedStudentSectionAssociation>
    {
        public AnonymizedStudentSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Applicant.TPDM.Applicant, Entities.NHibernate.ApplicantAggregate.TPDM.Applicant>
    {
        public ApplicantCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation, Entities.NHibernate.ApplicantProspectAssociationAggregate.TPDM.ApplicantProspectAssociation>
    {
        public ApplicantProspectAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Application.TPDM.Application, Entities.NHibernate.ApplicationAggregate.TPDM.Application>
    {
        public ApplicationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicationEvent.TPDM.ApplicationEvent, Entities.NHibernate.ApplicationEventAggregate.TPDM.ApplicationEvent>
    {
        public ApplicationEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventResultDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor, Entities.NHibernate.ApplicationEventResultDescriptorAggregate.TPDM.ApplicationEventResultDescriptor>
    {
        public ApplicationEventResultDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor, Entities.NHibernate.ApplicationEventTypeDescriptorAggregate.TPDM.ApplicationEventTypeDescriptor>
    {
        public ApplicationEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor, Entities.NHibernate.ApplicationSourceDescriptorAggregate.TPDM.ApplicationSourceDescriptor>
    {
        public ApplicationSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ApplicationStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor, Entities.NHibernate.ApplicationStatusDescriptorAggregate.TPDM.ApplicationStatusDescriptor>
    {
        public ApplicationStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor, Entities.NHibernate.BackgroundCheckStatusDescriptorAggregate.TPDM.BackgroundCheckStatusDescriptor>
    {
        public BackgroundCheckStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BackgroundCheckTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor, Entities.NHibernate.BackgroundCheckTypeDescriptorAggregate.TPDM.BackgroundCheckTypeDescriptor>
    {
        public BackgroundCheckTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Certification.TPDM.Certification, Entities.NHibernate.CertificationAggregate.TPDM.Certification>
    {
        public CertificationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationExam.TPDM.CertificationExam, Entities.NHibernate.CertificationExamAggregate.TPDM.CertificationExam>
    {
        public CertificationExamCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamResultCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationExamResult.TPDM.CertificationExamResult, Entities.NHibernate.CertificationExamResultAggregate.TPDM.CertificationExamResult>
    {
        public CertificationExamResultCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor, Entities.NHibernate.CertificationExamStatusDescriptorAggregate.TPDM.CertificationExamStatusDescriptor>
    {
        public CertificationExamStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationExamTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor, Entities.NHibernate.CertificationExamTypeDescriptorAggregate.TPDM.CertificationExamTypeDescriptor>
    {
        public CertificationExamTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationFieldDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor, Entities.NHibernate.CertificationFieldDescriptorAggregate.TPDM.CertificationFieldDescriptor>
    {
        public CertificationFieldDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor, Entities.NHibernate.CertificationLevelDescriptorAggregate.TPDM.CertificationLevelDescriptor>
    {
        public CertificationLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationRouteDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor, Entities.NHibernate.CertificationRouteDescriptorAggregate.TPDM.CertificationRouteDescriptor>
    {
        public CertificationRouteDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CertificationStandardDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor, Entities.NHibernate.CertificationStandardDescriptorAggregate.TPDM.CertificationStandardDescriptor>
    {
        public CertificationStandardDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation, Entities.NHibernate.CompleterAsStaffAssociationAggregate.TPDM.CompleterAsStaffAssociation>
    {
        public CompleterAsStaffAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CoteachingStyleObservedDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor, Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM.CoteachingStyleObservedDescriptor>
    {
        public CoteachingStyleObservedDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CredentialEvent.TPDM.CredentialEvent, Entities.NHibernate.CredentialEventAggregate.TPDM.CredentialEvent>
    {
        public CredentialEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor, Entities.NHibernate.CredentialEventTypeDescriptorAggregate.TPDM.CredentialEventTypeDescriptor>
    {
        public CredentialEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor, Entities.NHibernate.CredentialStatusDescriptorAggregate.TPDM.CredentialStatusDescriptor>
    {
        public CredentialStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class DegreeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.DegreeDescriptor.TPDM.DegreeDescriptor, Entities.NHibernate.DegreeDescriptorAggregate.TPDM.DegreeDescriptor>
    {
        public DegreeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EducatorRoleDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor, Entities.NHibernate.EducatorRoleDescriptorAggregate.TPDM.EducatorRoleDescriptor>
    {
        public EducatorRoleDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EmploymentEvent.TPDM.EmploymentEvent, Entities.NHibernate.EmploymentEventAggregate.TPDM.EmploymentEvent>
    {
        public EmploymentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor, Entities.NHibernate.EmploymentEventTypeDescriptorAggregate.TPDM.EmploymentEventTypeDescriptor>
    {
        public EmploymentEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent, Entities.NHibernate.EmploymentSeparationEventAggregate.TPDM.EmploymentSeparationEvent>
    {
        public EmploymentSeparationEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor, Entities.NHibernate.EmploymentSeparationReasonDescriptorAggregate.TPDM.EmploymentSeparationReasonDescriptor>
    {
        public EmploymentSeparationReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor, Entities.NHibernate.EmploymentSeparationTypeDescriptorAggregate.TPDM.EmploymentSeparationTypeDescriptor>
    {
        public EmploymentSeparationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EnglishLanguageExamDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor, Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM.EnglishLanguageExamDescriptor>
    {
        public EnglishLanguageExamDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Evaluation.TPDM.Evaluation, Entities.NHibernate.EvaluationAggregate.TPDM.Evaluation>
    {
        public EvaluationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationElement.TPDM.EvaluationElement, Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElement>
    {
        public EvaluationElementCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating, Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRating>
    {
        public EvaluationElementRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor, Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.TPDM.EvaluationElementRatingLevelDescriptor>
    {
        public EvaluationElementRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationObjective.TPDM.EvaluationObjective, Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjective>
    {
        public EvaluationObjectiveCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating, Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRating>
    {
        public EvaluationObjectiveRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationPeriodDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor, Entities.NHibernate.EvaluationPeriodDescriptorAggregate.TPDM.EvaluationPeriodDescriptor>
    {
        public EvaluationPeriodDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationRating.TPDM.EvaluationRating, Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRating>
    {
        public EvaluationRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor, Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.TPDM.EvaluationRatingLevelDescriptor>
    {
        public EvaluationRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class EvaluationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor, Entities.NHibernate.EvaluationTypeDescriptorAggregate.TPDM.EvaluationTypeDescriptor>
    {
        public EvaluationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FederalLocaleCodeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor, Entities.NHibernate.FederalLocaleCodeDescriptorAggregate.TPDM.FederalLocaleCodeDescriptor>
    {
        public FederalLocaleCodeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.FieldworkExperience.TPDM.FieldworkExperience, Entities.NHibernate.FieldworkExperienceAggregate.TPDM.FieldworkExperience>
    {
        public FieldworkExperienceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation, Entities.NHibernate.FieldworkExperienceSectionAssociationAggregate.TPDM.FieldworkExperienceSectionAssociation>
    {
        public FieldworkExperienceSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FieldworkTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor, Entities.NHibernate.FieldworkTypeDescriptorAggregate.TPDM.FieldworkTypeDescriptor>
    {
        public FieldworkTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FundingSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor, Entities.NHibernate.FundingSourceDescriptorAggregate.TPDM.FundingSourceDescriptor>
    {
        public FundingSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class GenderDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.GenderDescriptor.TPDM.GenderDescriptor, Entities.NHibernate.GenderDescriptorAggregate.TPDM.GenderDescriptor>
    {
        public GenderDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class GoalCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Goal.TPDM.Goal, Entities.NHibernate.GoalAggregate.TPDM.Goal>
    {
        public GoalCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class GoalTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor, Entities.NHibernate.GoalTypeDescriptorAggregate.TPDM.GoalTypeDescriptor>
    {
        public GoalTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class HireStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor, Entities.NHibernate.HireStatusDescriptorAggregate.TPDM.HireStatusDescriptor>
    {
        public HireStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class HiringSourceDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor, Entities.NHibernate.HiringSourceDescriptorAggregate.TPDM.HiringSourceDescriptor>
    {
        public HiringSourceDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class InstructionalSettingDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor, Entities.NHibernate.InstructionalSettingDescriptorAggregate.TPDM.InstructionalSettingDescriptor>
    {
        public InstructionalSettingDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class InternalExternalHireDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor, Entities.NHibernate.InternalExternalHireDescriptorAggregate.TPDM.InternalExternalHireDescriptor>
    {
        public InternalExternalHireDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfDegreeAwardedDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor, Entities.NHibernate.LevelOfDegreeAwardedDescriptorAggregate.TPDM.LevelOfDegreeAwardedDescriptor>
    {
        public LevelOfDegreeAwardedDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor, Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.TPDM.ObjectiveRatingLevelDescriptor>
    {
        public ObjectiveRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent, Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM.OpenStaffPositionEvent>
    {
        public OpenStaffPositionEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor, Entities.NHibernate.OpenStaffPositionEventStatusDescriptorAggregate.TPDM.OpenStaffPositionEventStatusDescriptor>
    {
        public OpenStaffPositionEventStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor, Entities.NHibernate.OpenStaffPositionEventTypeDescriptorAggregate.TPDM.OpenStaffPositionEventTypeDescriptor>
    {
        public OpenStaffPositionEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor, Entities.NHibernate.OpenStaffPositionReasonDescriptorAggregate.TPDM.OpenStaffPositionReasonDescriptor>
    {
        public OpenStaffPositionReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation, Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluation>
    {
        public PerformanceEvaluationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating, Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRating>
    {
        public PerformanceEvaluationRatingCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor, Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.TPDM.PerformanceEvaluationRatingLevelDescriptor>
    {
        public PerformanceEvaluationRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor, Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.TPDM.PerformanceEvaluationTypeDescriptor>
    {
        public PerformanceEvaluationTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class PreviousCareerDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor, Entities.NHibernate.PreviousCareerDescriptorAggregate.TPDM.PreviousCareerDescriptor>
    {
        public PreviousCareerDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent, Entities.NHibernate.ProfessionalDevelopmentEventAggregate.TPDM.ProfessionalDevelopmentEvent>
    {
        public ProfessionalDevelopmentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance, Entities.NHibernate.ProfessionalDevelopmentEventAttendanceAggregate.TPDM.ProfessionalDevelopmentEventAttendance>
    {
        public ProfessionalDevelopmentEventAttendanceCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProfessionalDevelopmentOfferedByDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor, Entities.NHibernate.ProfessionalDevelopmentOfferedByDescriptorAggregate.TPDM.ProfessionalDevelopmentOfferedByDescriptor>
    {
        public ProfessionalDevelopmentOfferedByDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGatewayDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor, Entities.NHibernate.ProgramGatewayDescriptorAggregate.TPDM.ProgramGatewayDescriptor>
    {
        public ProgramGatewayDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.Prospect.TPDM.Prospect, Entities.NHibernate.ProspectAggregate.TPDM.Prospect>
    {
        public ProspectCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ProspectTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor, Entities.NHibernate.ProspectTypeDescriptorAggregate.TPDM.ProspectTypeDescriptor>
    {
        public ProspectTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure, Entities.NHibernate.QuantitativeMeasureAggregate.TPDM.QuantitativeMeasure>
    {
        public QuantitativeMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureDatatypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor, Entities.NHibernate.QuantitativeMeasureDatatypeDescriptorAggregate.TPDM.QuantitativeMeasureDatatypeDescriptor>
    {
        public QuantitativeMeasureDatatypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore, Entities.NHibernate.QuantitativeMeasureScoreAggregate.TPDM.QuantitativeMeasureScore>
    {
        public QuantitativeMeasureScoreCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor, Entities.NHibernate.QuantitativeMeasureTypeDescriptorAggregate.TPDM.QuantitativeMeasureTypeDescriptor>
    {
        public QuantitativeMeasureTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent, Entities.NHibernate.RecruitmentEventAggregate.TPDM.RecruitmentEvent>
    {
        public RecruitmentEventCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RecruitmentEventTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor, Entities.NHibernate.RecruitmentEventTypeDescriptorAggregate.TPDM.RecruitmentEventTypeDescriptor>
    {
        public RecruitmentEventTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricDimensionCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.RubricDimension.TPDM.RubricDimension, Entities.NHibernate.RubricDimensionAggregate.TPDM.RubricDimension>
    {
        public RubricDimensionCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class RubricRatingLevelDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor, Entities.NHibernate.RubricRatingLevelDescriptorAggregate.TPDM.RubricRatingLevelDescriptor>
    {
        public RubricRatingLevelDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SalaryTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor, Entities.NHibernate.SalaryTypeDescriptorAggregate.TPDM.SalaryTypeDescriptor>
    {
        public SalaryTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolStatusDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor, Entities.NHibernate.SchoolStatusDescriptorAggregate.TPDM.SchoolStatusDescriptor>
    {
        public SchoolStatusDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation, Entities.NHibernate.StaffApplicantAssociationAggregate.TPDM.StaffApplicantAssociation>
    {
        public StaffApplicantAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation, Entities.NHibernate.StaffProspectAssociationAggregate.TPDM.StaffProspectAssociation>
    {
        public StaffProspectAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure, Entities.NHibernate.StaffStudentGrowthMeasureAggregate.TPDM.StaffStudentGrowthMeasure>
    {
        public StaffStudentGrowthMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation, Entities.NHibernate.StaffStudentGrowthMeasureCourseAssociationAggregate.TPDM.StaffStudentGrowthMeasureCourseAssociation>
    {
        public StaffStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation, Entities.NHibernate.StaffStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation>
    {
        public StaffStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation, Entities.NHibernate.StaffStudentGrowthMeasureSectionAssociationAggregate.TPDM.StaffStudentGrowthMeasureSectionAssociation>
    {
        public StaffStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation, Entities.NHibernate.StaffTeacherPreparationProviderAssociationAggregate.TPDM.StaffTeacherPreparationProviderAssociation>
    {
        public StaffTeacherPreparationProviderAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation, Entities.NHibernate.StaffTeacherPreparationProviderProgramAssociationAggregate.TPDM.StaffTeacherPreparationProviderProgramAssociation>
    {
        public StaffTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGrowthTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor, Entities.NHibernate.StudentGrowthTypeDescriptorAggregate.TPDM.StudentGrowthTypeDescriptor>
    {
        public StudentGrowthTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseTeacherCandidateTargetAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SurveyResponseTeacherCandidateTargetAssociation.TPDM.SurveyResponseTeacherCandidateTargetAssociation, Entities.NHibernate.SurveyResponseTeacherCandidateTargetAssociationAggregate.TPDM.SurveyResponseTeacherCandidateTargetAssociation>
    {
        public SurveyResponseTeacherCandidateTargetAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse, Entities.NHibernate.SurveySectionAggregateResponseAggregate.TPDM.SurveySectionAggregateResponse>
    {
        public SurveySectionAggregateResponseCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseTeacherCandidateTargetAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.SurveySectionResponseTeacherCandidateTargetAssociation.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation, Entities.NHibernate.SurveySectionResponseTeacherCandidateTargetAssociationAggregate.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation>
    {
        public SurveySectionResponseTeacherCandidateTargetAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidate.TPDM.TeacherCandidate, Entities.NHibernate.TeacherCandidateAggregate.TPDM.TeacherCandidate>
    {
        public TeacherCandidateCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord, Entities.NHibernate.TeacherCandidateAcademicRecordAggregate.TPDM.TeacherCandidateAcademicRecord>
    {
        public TeacherCandidateAcademicRecordCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCharacteristicDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor, Entities.NHibernate.TeacherCandidateCharacteristicDescriptorAggregate.TPDM.TeacherCandidateCharacteristicDescriptor>
    {
        public TeacherCandidateCharacteristicDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript, Entities.NHibernate.TeacherCandidateCourseTranscriptAggregate.TPDM.TeacherCandidateCourseTranscript>
    {
        public TeacherCandidateCourseTranscriptCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation, Entities.NHibernate.TeacherCandidateStaffAssociationAggregate.TPDM.TeacherCandidateStaffAssociation>
    {
        public TeacherCandidateStaffAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureAggregate.TPDM.TeacherCandidateStudentGrowthMeasure>
    {
        public TeacherCandidateStudentGrowthMeasureCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureCourseAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureCourseAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation, Entities.NHibernate.TeacherCandidateStudentGrowthMeasureSectionAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation>
    {
        public TeacherCandidateStudentGrowthMeasureSectionAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation, Entities.NHibernate.TeacherCandidateTeacherPreparationProviderAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderAssociation>
    {
        public TeacherCandidateTeacherPreparationProviderAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation, Entities.NHibernate.TeacherCandidateTeacherPreparationProviderProgramAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation>
    {
        public TeacherCandidateTeacherPreparationProviderProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProgramTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor, Entities.NHibernate.TeacherPreparationProgramTypeDescriptorAggregate.TPDM.TeacherPreparationProgramTypeDescriptor>
    {
        public TeacherPreparationProgramTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider, Entities.NHibernate.TeacherPreparationProviderAggregate.TPDM.TeacherPreparationProvider>
    {
        public TeacherPreparationProviderCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram, Entities.NHibernate.TeacherPreparationProviderProgramAggregate.TPDM.TeacherPreparationProviderProgram>
    {
        public TeacherPreparationProviderProgramCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TPPDegreeTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor, Entities.NHibernate.TPPDegreeTypeDescriptorAggregate.TPDM.TPPDegreeTypeDescriptor>
    {
        public TPPDegreeTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class TPPProgramPathwayDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor, Entities.NHibernate.TPPProgramPathwayDescriptorAggregate.TPDM.TPPProgramPathwayDescriptor>
    {
        public TPPProgramPathwayDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class UniversityCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.University.TPDM.University, Entities.NHibernate.UniversityAggregate.TPDM.University>
    {
        public UniversityCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class ValueTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor, Entities.NHibernate.ValueTypeDescriptorAggregate.TPDM.ValueTypeDescriptor>
    {
        public ValueTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class WithdrawReasonDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Common.Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor, Entities.NHibernate.WithdrawReasonDescriptorAggregate.TPDM.WithdrawReasonDescriptor>
    {
        public WithdrawReasonDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
