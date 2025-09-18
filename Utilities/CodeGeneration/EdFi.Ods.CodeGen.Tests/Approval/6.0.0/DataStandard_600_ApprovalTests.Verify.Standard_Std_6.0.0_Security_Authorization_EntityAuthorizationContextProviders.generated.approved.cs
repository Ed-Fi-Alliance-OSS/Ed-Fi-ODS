
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.AcademicWeekAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AccountabilityRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ApplicationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ApplicationEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentAdministrationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentAdministrationParticipationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.BellScheduleAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CalendarAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CalendarDateAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CandidateIdentificationCodeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CandidateRelationshipToStaffAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CertificationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CertificationExamAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CertificationExamResultAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ChartOfAccountAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ClassPeriodAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CohortAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderLicenseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CompetencyObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ContactAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ContactIdentificationCodeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseOfferingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseTranscriptAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.DisciplineActionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.DisciplineIncidentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationIdentificationCodeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationInterventionPrescriptionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationPeerAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationServiceCenterAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducatorPreparationProgramAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationElementAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationElementRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EvaluationRubricDimensionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.FeederSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.FieldworkExperienceAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.FieldworkExperienceSectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.FinancialAidAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GeneralStudentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GoalAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GradeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GradebookEntryAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GradingPeriodAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GraduationPlanAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.InterventionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.InterventionPrescriptionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.InterventionStudyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalAccountAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalActualAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalBudgetAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalContractedStaffAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalEncumbranceAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocalPayrollAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LocationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.OpenStaffPositionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.OpenStaffPositionEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.OrganizationDepartmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PathAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PathPhaseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PostSecondaryEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PostSecondaryInstitutionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramEvaluationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramEvaluationElementAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramEvaluationObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureScoreAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.RecruitmentEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.RecruitmentEventAttendanceAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ReportCardAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.RestraintEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.RubricDimensionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SectionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SectionAttendanceTakenEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SessionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffAbsenceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffCohortAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffDemographicAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffDirectoryAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffDisciplineIncidentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducatorPreparationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffIdentificationCodeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffSectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StateEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAcademicRecordAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentEducationOrganizationAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentRegistrationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentRegistrationBatteryPartAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCohortAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCompetencyObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentContactAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCTEProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDemographicAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDirectoryAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDisciplineIncidentBehaviorAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDisciplineIncidentNonOffenderAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationAssessmentAccommodationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationResponsibilityAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentGradebookEntryAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentHealthAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentHomelessProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentIdentificationCodeAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentInterventionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentInterventionAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentLanguageInstructionProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentMigrantEducationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentNeglectedOrDelinquentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentPathAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentPathMilestoneStatusAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentPathPhaseStatusAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramEvaluationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolFoodServiceProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSection504ProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSectionAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSpecialEducationProgramEligibilityAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentTitleIPartAProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentTransportationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyCourseAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseEducationOrganizationTargetAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseStaffTargetAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveySectionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveySectionAggregateResponseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveySectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveySectionResponseEducationOrganizationTargetAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveySectionResponseStaffTargetAssociationAggregate.EdFi;
#endregion

namespace EdFi.Ods.Api.Security.Authorization.ContextDataProviders.EdFi
{

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.AcademicWeek table of the AcademicWeek aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AcademicWeekRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IAcademicWeek>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IAcademicWeek resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'academicWeek' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AcademicWeek;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((AcademicWeek) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.AccountabilityRating table of the AccountabilityRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IAccountabilityRating>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IAccountabilityRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'accountabilityRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AccountabilityRating;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((AccountabilityRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Application table of the Application aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IApplication>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IApplication resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'application' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Application;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Application) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ApplicationEvent table of the ApplicationEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicationEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IApplicationEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IApplicationEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'applicationEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ApplicationEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ApplicationEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Assessment table of the Assessment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssessmentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IAssessment>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IAssessment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'assessment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Assessment;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Assessment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.AssessmentAdministration table of the AssessmentAdministration aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssessmentAdministrationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IAssessmentAdministration>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IAssessmentAdministration resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'assessmentAdministration' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AssessmentAdministration;

            var contextData = new RelationshipsAuthorizationContextData();
            // AssigningEducationOrganizationId = entity.AssigningEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "AssigningEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((AssessmentAdministration) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.AssessmentAdministrationParticipation table of the AssessmentAdministrationParticipation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssessmentAdministrationParticipationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IAssessmentAdministrationParticipation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IAssessmentAdministrationParticipation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'assessmentAdministrationParticipation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AssessmentAdministrationParticipation;

            var contextData = new RelationshipsAuthorizationContextData();
            // AssigningEducationOrganizationId = entity.AssigningEducationOrganizationId, // Primary key property, Role name applied
            // ParticipatingEducationOrganizationId = entity.ParticipatingEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "AssigningEducationOrganizationId",
                    // "ParticipatingEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((AssessmentAdministrationParticipation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.BellSchedule table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BellScheduleRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IBellSchedule>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IBellSchedule resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'bellSchedule' resource for obtaining authorization context data cannot be null.");

            var entity = resource as BellSchedule;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((BellSchedule) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Calendar table of the Calendar aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CalendarRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICalendar>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICalendar resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'calendar' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Calendar;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Calendar) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CalendarDate table of the CalendarDate aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CalendarDateRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICalendarDate>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICalendarDate resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'calendarDate' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CalendarDate;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CalendarDate) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CandidateEducatorPreparationProgramAssociation table of the CandidateEducatorPreparationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICandidateEducatorPreparationProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICandidateEducatorPreparationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidateEducatorPreparationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CandidateEducatorPreparationProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CandidateEducatorPreparationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CandidateIdentificationCode table of the CandidateIdentificationCode aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateIdentificationCodeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICandidateIdentificationCode>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICandidateIdentificationCode resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidateIdentificationCode' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CandidateIdentificationCode;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CandidateIdentificationCode) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CandidateRelationshipToStaffAssociation table of the CandidateRelationshipToStaffAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateRelationshipToStaffAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICandidateRelationshipToStaffAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICandidateRelationshipToStaffAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidateRelationshipToStaffAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CandidateRelationshipToStaffAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CandidateRelationshipToStaffAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Certification table of the Certification aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CertificationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICertification>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICertification resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'certification' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Certification;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Certification) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CertificationExam table of the CertificationExam aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CertificationExamRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICertificationExam>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICertificationExam resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'certificationExam' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CertificationExam;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CertificationExam) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CertificationExamResult table of the CertificationExamResult aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CertificationExamResultRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICertificationExamResult>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICertificationExamResult resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'certificationExamResult' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CertificationExamResult;

            var contextData = new RelationshipsAuthorizationContextData();
            // CertificationExamStudentUSI = entity.CertificationExamStudentUSI, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "CertificationExamStudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CertificationExamResult) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ChartOfAccount table of the ChartOfAccount aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ChartOfAccountRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IChartOfAccount>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IChartOfAccount resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'chartOfAccount' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ChartOfAccount;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ChartOfAccount) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ClassPeriod table of the ClassPeriod aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ClassPeriodRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IClassPeriod>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IClassPeriod resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'classPeriod' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ClassPeriod;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ClassPeriod) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Cohort table of the Cohort aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CohortRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICohort>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICohort resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'cohort' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Cohort;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Cohort) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityOrganization table of the CommunityOrganization aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICommunityOrganization>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICommunityOrganization resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityOrganization' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityOrganization;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.CommunityOrganizationId = entity.CommunityOrganizationId == default(long) ? null as long? : entity.CommunityOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "CommunityOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CommunityOrganization) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityProvider table of the CommunityProvider aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityProviderRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICommunityProvider>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICommunityProvider resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityProvider' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityProvider;

            var contextData = new RelationshipsAuthorizationContextData();
            // CommunityOrganizationId = entity.CommunityOrganizationId, // Not part of primary key
            contextData.CommunityProviderId = entity.CommunityProviderId == default(long) ? null as long? : entity.CommunityProviderId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "CommunityOrganizationId",
                    "CommunityProviderId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CommunityProvider) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityProviderLicense table of the CommunityProviderLicense aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicenseRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICommunityProviderLicense>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICommunityProviderLicense resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityProviderLicense' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityProviderLicense;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.CommunityProviderId = entity.CommunityProviderId == default(long) ? null as long? : entity.CommunityProviderId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "CommunityProviderId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CommunityProviderLicense) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CompetencyObjective table of the CompetencyObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CompetencyObjectiveRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICompetencyObjective>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICompetencyObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'competencyObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CompetencyObjective;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CompetencyObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Contact table of the Contact aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IContact>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IContact resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'contact' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Contact;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.ContactUSI = entity.ContactUSI == default(int) ? null as int? : entity.ContactUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "ContactUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Contact) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ContactIdentificationCode table of the ContactIdentificationCode aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactIdentificationCodeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IContactIdentificationCode>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IContactIdentificationCode resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'contactIdentificationCode' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ContactIdentificationCode;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.ContactUSI = entity.ContactUSI == default(int) ? null as int? : entity.ContactUSI; // Primary key property, USI
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "ContactUSI",
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ContactIdentificationCode) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Course table of the Course aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICourse>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICourse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'course' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Course;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Course) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CourseOffering table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseOfferingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICourseOffering>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICourseOffering resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseOffering' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseOffering;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CourseOffering) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CourseTranscript table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseTranscriptRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ICourseTranscript>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ICourseTranscript resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseTranscript' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseTranscript;

            var contextData = new RelationshipsAuthorizationContextData();
            // CourseEducationOrganizationId = entity.CourseEducationOrganizationId, // Primary key property, Role name applied
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ExternalEducationOrganizationId = entity.ExternalEducationOrganizationId, // Role name applied and not part of primary key
            // ResponsibleTeacherStaffUSI = entity.ResponsibleTeacherStaffUSI, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "CourseEducationOrganizationId",
                    "EducationOrganizationId",
                    // "ExternalEducationOrganizationId",
                    // "ResponsibleTeacherStaffUSI",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((CourseTranscript) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.DisciplineAction table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DisciplineActionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IDisciplineAction>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IDisciplineAction resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'disciplineAction' resource for obtaining authorization context data cannot be null.");

            var entity = resource as DisciplineAction;

            var contextData = new RelationshipsAuthorizationContextData();
            // AssignmentSchoolId = entity.AssignmentSchoolId, // Role name applied and not part of primary key
            // ResponsibilitySchoolId = entity.ResponsibilitySchoolId, // Role name applied and not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "AssignmentSchoolId",
                    // "ResponsibilitySchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((DisciplineAction) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.DisciplineIncident table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IDisciplineIncident>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IDisciplineIncident resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'disciplineIncident' resource for obtaining authorization context data cannot be null.");

            var entity = resource as DisciplineIncident;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((DisciplineIncident) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganization table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganization>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganization resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganization' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganization;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganization) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationIdentificationCode table of the EducationOrganizationIdentificationCode aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCodeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationIdentificationCode>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganizationIdentificationCode resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationIdentificationCode' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationIdentificationCode;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationIdentificationCode) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationInterventionPrescriptionAssociation table of the EducationOrganizationInterventionPrescriptionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationInterventionPrescriptionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganizationInterventionPrescriptionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationInterventionPrescriptionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationInterventionPrescriptionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // InterventionPrescriptionEducationOrganizationId = entity.InterventionPrescriptionEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "InterventionPrescriptionEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationInterventionPrescriptionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationNetwork table of the EducationOrganizationNetwork aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationNetwork>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganizationNetwork resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationNetwork' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationNetwork;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationNetworkId = entity.EducationOrganizationNetworkId == default(long) ? null as long? : entity.EducationOrganizationNetworkId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationNetworkId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationNetwork) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationNetworkAssociation table of the EducationOrganizationNetworkAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationNetworkAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganizationNetworkAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationNetworkAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationNetworkAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationNetworkId = entity.EducationOrganizationNetworkId == default(long) ? null as long? : entity.EducationOrganizationNetworkId; // Primary key property, Only Education Organization Id present
            // MemberEducationOrganizationId = entity.MemberEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationNetworkId",
                    // "MemberEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationNetworkAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationPeerAssociation table of the EducationOrganizationPeerAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationPeerAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationOrganizationPeerAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationPeerAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationPeerAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // PeerEducationOrganizationId = entity.PeerEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "PeerEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationPeerAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationServiceCenter table of the EducationServiceCenter aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducationServiceCenter>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducationServiceCenter resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationServiceCenter' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationServiceCenter;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationServiceCenterId = entity.EducationServiceCenterId == default(long) ? null as long? : entity.EducationServiceCenterId; // Primary key property, Only Education Organization Id present
            // StateEducationAgencyId = entity.StateEducationAgencyId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationServiceCenterId",
                    // "StateEducationAgencyId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducationServiceCenter) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducatorPreparationProgram table of the EducatorPreparationProgram aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEducatorPreparationProgram>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEducatorPreparationProgram resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educatorPreparationProgram' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducatorPreparationProgram;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EducatorPreparationProgram) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Evaluation table of the Evaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Evaluation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Evaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationElement table of the EvaluationElement aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationElement>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationElement resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationElement' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationElement;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationElement) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationElementRating table of the EvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationElementRating>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationElementRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationElementRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationElementRating;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationElementRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationObjective table of the EvaluationObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationObjective>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationObjective;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationObjectiveRating table of the EvaluationObjectiveRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationObjectiveRating>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationObjectiveRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationObjectiveRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationObjectiveRating;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationObjectiveRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationRating table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationRating>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationRating;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // SchoolId = entity.SchoolId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EvaluationRubricDimension table of the EvaluationRubricDimension aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationRubricDimensionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IEvaluationRubricDimension>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IEvaluationRubricDimension resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationRubricDimension' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationRubricDimension;

            var contextData = new RelationshipsAuthorizationContextData();
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ProgramEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((EvaluationRubricDimension) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.FeederSchoolAssociation table of the FeederSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IFeederSchoolAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IFeederSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'feederSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FeederSchoolAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // FeederSchoolId = entity.FeederSchoolId, // Primary key property, Role name applied
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "FeederSchoolId",
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((FeederSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.FieldworkExperience table of the FieldworkExperience aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IFieldworkExperience>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IFieldworkExperience resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'fieldworkExperience' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FieldworkExperience;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // SchoolId = entity.SchoolId, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    // "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((FieldworkExperience) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.FieldworkExperienceSectionAssociation table of the FieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IFieldworkExperienceSectionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IFieldworkExperienceSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'fieldworkExperienceSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FieldworkExperienceSectionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((FieldworkExperienceSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.FinancialAid table of the FinancialAid aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FinancialAidRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IFinancialAid>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IFinancialAid resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'financialAid' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FinancialAid;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((FinancialAid) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GeneralStudentProgramAssociation table of the GeneralStudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GeneralStudentProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGeneralStudentProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGeneralStudentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'generalStudentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GeneralStudentProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((GeneralStudentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Goal table of the Goal aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GoalRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGoal>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGoal resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'goal' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Goal;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Goal) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Grade table of the Grade aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGrade>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGrade resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'grade' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Grade;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Grade) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GradebookEntry table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradebookEntryRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGradebookEntry>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGradebookEntry resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'gradebookEntry' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GradebookEntry;

            var contextData = new RelationshipsAuthorizationContextData();
            // SchoolId = entity.SchoolId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((GradebookEntry) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GradingPeriod table of the GradingPeriod aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradingPeriodRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGradingPeriod>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGradingPeriod resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'gradingPeriod' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GradingPeriod;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((GradingPeriod) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GraduationPlan table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GraduationPlanRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IGraduationPlan>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IGraduationPlan resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'graduationPlan' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GraduationPlan;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((GraduationPlan) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Intervention table of the Intervention aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IIntervention>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IIntervention resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'intervention' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Intervention;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Intervention) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.InterventionPrescription table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IInterventionPrescription>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IInterventionPrescription resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'interventionPrescription' resource for obtaining authorization context data cannot be null.");

            var entity = resource as InterventionPrescription;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((InterventionPrescription) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.InterventionStudy table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionStudyRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IInterventionStudy>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IInterventionStudy resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'interventionStudy' resource for obtaining authorization context data cannot be null.");

            var entity = resource as InterventionStudy;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // InterventionPrescriptionEducationOrganizationId = entity.InterventionPrescriptionEducationOrganizationId, // Role name applied and not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "InterventionPrescriptionEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((InterventionStudy) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalAccount table of the LocalAccount aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalAccountRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalAccount>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalAccount resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localAccount' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalAccount;

            var contextData = new RelationshipsAuthorizationContextData();
            // ChartOfAccountEducationOrganizationId = entity.ChartOfAccountEducationOrganizationId, // Role name applied and not part of primary key
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ChartOfAccountEducationOrganizationId",
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalAccount) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalActual table of the LocalActual aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalActualRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalActual>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalActual resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localActual' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalActual;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalActual) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalBudget table of the LocalBudget aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalBudgetRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalBudget>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalBudget resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localBudget' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalBudget;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalBudget) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalContractedStaff table of the LocalContractedStaff aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalContractedStaff>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalContractedStaff resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localContractedStaff' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalContractedStaff;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalContractedStaff) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalEducationAgency table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalEducationAgency>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalEducationAgency resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localEducationAgency' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalEducationAgency;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationServiceCenterId = entity.EducationServiceCenterId, // Not part of primary key
            contextData.LocalEducationAgencyId = entity.LocalEducationAgencyId == default(long) ? null as long? : entity.LocalEducationAgencyId; // Primary key property, Only Education Organization Id present
            // ParentLocalEducationAgencyId = entity.ParentLocalEducationAgencyId, // Role name applied and not part of primary key
            // StateEducationAgencyId = entity.StateEducationAgencyId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationServiceCenterId",
                    "LocalEducationAgencyId",
                    // "ParentLocalEducationAgencyId",
                    // "StateEducationAgencyId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalEducationAgency) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalEncumbrance table of the LocalEncumbrance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalEncumbranceRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalEncumbrance>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalEncumbrance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localEncumbrance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalEncumbrance;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalEncumbrance) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalPayroll table of the LocalPayroll aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalPayrollRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocalPayroll>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocalPayroll resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localPayroll' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalPayroll;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((LocalPayroll) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Location table of the Location aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ILocation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ILocation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'location' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Location;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Location) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.OpenStaffPosition table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IOpenStaffPosition>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IOpenStaffPosition resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'openStaffPosition' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OpenStaffPosition;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((OpenStaffPosition) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.OpenStaffPositionEvent table of the OpenStaffPositionEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IOpenStaffPositionEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IOpenStaffPositionEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'openStaffPositionEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OpenStaffPositionEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((OpenStaffPositionEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.OrganizationDepartment table of the OrganizationDepartment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IOrganizationDepartment>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IOrganizationDepartment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'organizationDepartment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OrganizationDepartment;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.OrganizationDepartmentId = entity.OrganizationDepartmentId == default(long) ? null as long? : entity.OrganizationDepartmentId; // Primary key property, Only Education Organization Id present
            // ParentEducationOrganizationId = entity.ParentEducationOrganizationId, // Role name applied and not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "OrganizationDepartmentId",
                    // "ParentEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((OrganizationDepartment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Path table of the Path aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PathRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPath>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPath resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'path' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Path;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Path) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PathPhase table of the PathPhase aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PathPhaseRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPathPhase>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPathPhase resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'pathPhase' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PathPhase;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((PathPhase) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PerformanceEvaluation table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPerformanceEvaluation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPerformanceEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceEvaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceEvaluation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((PerformanceEvaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PerformanceEvaluationRating table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPerformanceEvaluationRating>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPerformanceEvaluationRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceEvaluationRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceEvaluationRating;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((PerformanceEvaluationRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PostSecondaryEvent table of the PostSecondaryEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPostSecondaryEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPostSecondaryEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'postSecondaryEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PostSecondaryEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            // PostSecondaryInstitutionId = entity.PostSecondaryInstitutionId, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "PostSecondaryInstitutionId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((PostSecondaryEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PostSecondaryInstitution table of the PostSecondaryInstitution aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IPostSecondaryInstitution>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IPostSecondaryInstitution resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'postSecondaryInstitution' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PostSecondaryInstitution;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.PostSecondaryInstitutionId = entity.PostSecondaryInstitutionId == default(long) ? null as long? : entity.PostSecondaryInstitutionId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "PostSecondaryInstitutionId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((PostSecondaryInstitution) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Program table of the Program aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProgramRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IProgram>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IProgram resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'program' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Program;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Program) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ProgramEvaluation table of the ProgramEvaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProgramEvaluationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IProgramEvaluation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IProgramEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'programEvaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ProgramEvaluation;

            var contextData = new RelationshipsAuthorizationContextData();
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ProgramEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ProgramEvaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ProgramEvaluationElement table of the ProgramEvaluationElement aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProgramEvaluationElementRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IProgramEvaluationElement>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IProgramEvaluationElement resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'programEvaluationElement' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ProgramEvaluationElement;

            var contextData = new RelationshipsAuthorizationContextData();
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ProgramEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ProgramEvaluationElement) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ProgramEvaluationObjective table of the ProgramEvaluationObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProgramEvaluationObjectiveRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IProgramEvaluationObjective>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IProgramEvaluationObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'programEvaluationObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ProgramEvaluationObjective;

            var contextData = new RelationshipsAuthorizationContextData();
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ProgramEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ProgramEvaluationObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.QuantitativeMeasure table of the QuantitativeMeasure aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IQuantitativeMeasure>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IQuantitativeMeasure resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'quantitativeMeasure' resource for obtaining authorization context data cannot be null.");

            var entity = resource as QuantitativeMeasure;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((QuantitativeMeasure) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.QuantitativeMeasureScore table of the QuantitativeMeasureScore aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IQuantitativeMeasureScore>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IQuantitativeMeasureScore resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'quantitativeMeasureScore' resource for obtaining authorization context data cannot be null.");

            var entity = resource as QuantitativeMeasureScore;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((QuantitativeMeasureScore) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.RecruitmentEvent table of the RecruitmentEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IRecruitmentEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IRecruitmentEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'recruitmentEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RecruitmentEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((RecruitmentEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.RecruitmentEventAttendance table of the RecruitmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventAttendanceRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IRecruitmentEventAttendance>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IRecruitmentEventAttendance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'recruitmentEventAttendance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RecruitmentEventAttendance;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((RecruitmentEventAttendance) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ReportCard table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ReportCardRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IReportCard>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IReportCard resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'reportCard' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ReportCard;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // GradingPeriodSchoolId = entity.GradingPeriodSchoolId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "GradingPeriodSchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((ReportCard) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.RestraintEvent table of the RestraintEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RestraintEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IRestraintEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IRestraintEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'restraintEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RestraintEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((RestraintEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.RubricDimension table of the RubricDimension aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricDimensionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IRubricDimension>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IRubricDimension resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubricDimension' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RubricDimension;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((RubricDimension) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.School table of the School aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SchoolRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISchool>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISchool resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'school' resource for obtaining authorization context data cannot be null.");

            var entity = resource as School;

            var contextData = new RelationshipsAuthorizationContextData();
            // LocalEducationAgencyId = entity.LocalEducationAgencyId, // Not part of primary key
            // PostSecondaryInstitutionId = entity.PostSecondaryInstitutionId, // Not part of primary key
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "LocalEducationAgencyId",
                    // "PostSecondaryInstitutionId",
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((School) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Section table of the Section aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISection>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISection resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'section' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Section;

            var contextData = new RelationshipsAuthorizationContextData();
            // LocationSchoolId = entity.LocationSchoolId, // Role name applied and not part of primary key
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "LocationSchoolId",
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Section) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SectionAttendanceTakenEvent table of the SectionAttendanceTakenEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISectionAttendanceTakenEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISectionAttendanceTakenEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionAttendanceTakenEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionAttendanceTakenEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            // StaffUSI = entity.StaffUSI, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    // "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SectionAttendanceTakenEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Session table of the Session aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SessionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISession>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISession resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'session' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Session;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Session) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Staff table of the Staff aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaff>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaff resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staff' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Staff;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Staff) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffAbsenceEvent table of the StaffAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffAbsenceEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffAbsenceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffAbsenceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffAbsenceEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffAbsenceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffCohortAssociation table of the StaffCohortAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffCohortAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffCohortAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffCohortAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffCohortAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffCohortAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffDemographic table of the StaffDemographic aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffDemographicRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffDemographic>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffDemographic resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffDemographic' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffDemographic;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffDemographic) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffDirectory table of the StaffDirectory aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffDirectoryRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffDirectory>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffDirectory resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffDirectory' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffDirectory;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffDirectory) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffDisciplineIncidentAssociation table of the StaffDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffDisciplineIncidentAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffDisciplineIncidentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffDisciplineIncidentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffDisciplineIncidentAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffDisciplineIncidentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducationOrganizationAssignmentAssociation table of the StaffEducationOrganizationAssignmentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffEducationOrganizationAssignmentAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffEducationOrganizationAssignmentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducationOrganizationAssignmentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducationOrganizationAssignmentAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // EmploymentEducationOrganizationId = entity.EmploymentEducationOrganizationId, // Role name applied and not part of primary key
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "EmploymentEducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducationOrganizationAssignmentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducationOrganizationEmploymentAssociation table of the StaffEducationOrganizationEmploymentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffEducationOrganizationEmploymentAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffEducationOrganizationEmploymentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducationOrganizationEmploymentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducationOrganizationEmploymentAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducationOrganizationEmploymentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducatorPreparationProgramAssociation table of the StaffEducatorPreparationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducatorPreparationProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffEducatorPreparationProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffEducatorPreparationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducatorPreparationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducatorPreparationProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducatorPreparationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffIdentificationCode table of the StaffIdentificationCode aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffIdentificationCodeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffIdentificationCode>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffIdentificationCode resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffIdentificationCode' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffIdentificationCode;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffIdentificationCode) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffLeave table of the StaffLeave aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffLeaveRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffLeave>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffLeave resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffLeave' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffLeave;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffLeave) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffProgramAssociation table of the StaffProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ProgramEducationOrganizationId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffSchoolAssociation table of the StaffSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffSchoolAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffSchoolAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffSectionAssociation table of the StaffSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStaffSectionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStaffSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffSectionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StaffSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StateEducationAgency table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStateEducationAgency>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStateEducationAgency resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'stateEducationAgency' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StateEducationAgency;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StateEducationAgencyId = entity.StateEducationAgencyId == default(long) ? null as long? : entity.StateEducationAgencyId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StateEducationAgencyId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StateEducationAgency) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Student table of the Student aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'student' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Student;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Student) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAcademicRecord table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAcademicRecord>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAcademicRecord resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAcademicRecord' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAcademicRecord;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAcademicRecord) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessment table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAssessment>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAssessment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessment;

            var contextData = new RelationshipsAuthorizationContextData();
            // ReportedSchoolId = entity.ReportedSchoolId, // Role name applied and not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ReportedSchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessmentEducationOrganizationAssociation table of the StudentAssessmentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAssessmentEducationOrganizationAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAssessmentEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessmentEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessmentEducationOrganizationAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessmentEducationOrganizationAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessmentRegistration table of the StudentAssessmentRegistration aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentRegistrationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAssessmentRegistration>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAssessmentRegistration resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessmentRegistration' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessmentRegistration;

            var contextData = new RelationshipsAuthorizationContextData();
            // AssigningEducationOrganizationId = entity.AssigningEducationOrganizationId, // Primary key property, Role name applied
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ReportingEducationOrganizationId = entity.ReportingEducationOrganizationId, // Role name applied and not part of primary key
            // ScheduledEducationOrganizationId = entity.ScheduledEducationOrganizationId, // Role name applied and not part of primary key
            // ScheduledStudentUSI = entity.ScheduledStudentUSI, // Not part of primary key
            // SchoolId = entity.SchoolId, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            // TestingEducationOrganizationId = entity.TestingEducationOrganizationId, // Role name applied and not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "AssigningEducationOrganizationId",
                    "EducationOrganizationId",
                    // "ReportingEducationOrganizationId",
                    // "ScheduledEducationOrganizationId",
                    // "ScheduledStudentUSI",
                    // "SchoolId",
                    "StudentUSI",
                    // "TestingEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessmentRegistration) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessmentRegistrationBatteryPartAssociation table of the StudentAssessmentRegistrationBatteryPartAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentRegistrationBatteryPartAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAssessmentRegistrationBatteryPartAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAssessmentRegistrationBatteryPartAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessmentRegistrationBatteryPartAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessmentRegistrationBatteryPartAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // AssigningEducationOrganizationId = entity.AssigningEducationOrganizationId, // Primary key property, Role name applied
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "AssigningEducationOrganizationId",
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessmentRegistrationBatteryPartAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCohortAssociation table of the StudentCohortAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentCohortAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentCohortAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCohortAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCohortAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentCohortAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCompetencyObjective table of the StudentCompetencyObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectiveRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentCompetencyObjective>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentCompetencyObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCompetencyObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCompetencyObjective;

            var contextData = new RelationshipsAuthorizationContextData();
            // GradingPeriodSchoolId = entity.GradingPeriodSchoolId, // Primary key property, Role name applied
            // ObjectiveEducationOrganizationId = entity.ObjectiveEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "GradingPeriodSchoolId",
                    // "ObjectiveEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentCompetencyObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentContactAssociation table of the StudentContactAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentContactAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentContactAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentContactAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentContactAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentContactAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.ContactUSI = entity.ContactUSI == default(int) ? null as int? : entity.ContactUSI; // Primary key property, USI
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "ContactUSI",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentContactAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCTEProgramAssociation table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentCTEProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentCTEProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCTEProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCTEProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentCTEProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDemographic table of the StudentDemographic aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDemographicRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentDemographic>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentDemographic resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDemographic' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDemographic;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentDemographic) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDirectory table of the StudentDirectory aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDirectoryRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentDirectory>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentDirectory resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDirectory' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDirectory;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentDirectory) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDisciplineIncidentBehaviorAssociation table of the StudentDisciplineIncidentBehaviorAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentDisciplineIncidentBehaviorAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentDisciplineIncidentBehaviorAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDisciplineIncidentBehaviorAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDisciplineIncidentBehaviorAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentDisciplineIncidentBehaviorAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDisciplineIncidentNonOffenderAssociation table of the StudentDisciplineIncidentNonOffenderAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentDisciplineIncidentNonOffenderAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentDisciplineIncidentNonOffenderAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDisciplineIncidentNonOffenderAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDisciplineIncidentNonOffenderAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentDisciplineIncidentNonOffenderAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentEducationOrganizationAssessmentAccommodation table of the StudentEducationOrganizationAssessmentAccommodation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssessmentAccommodationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentEducationOrganizationAssessmentAccommodation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentEducationOrganizationAssessmentAccommodation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentEducationOrganizationAssessmentAccommodation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentEducationOrganizationAssessmentAccommodation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentEducationOrganizationAssessmentAccommodation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentEducationOrganizationAssociation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentEducationOrganizationAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentEducationOrganizationAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentEducationOrganizationAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentEducationOrganizationResponsibilityAssociation table of the StudentEducationOrganizationResponsibilityAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentEducationOrganizationResponsibilityAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentEducationOrganizationResponsibilityAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentEducationOrganizationResponsibilityAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentEducationOrganizationResponsibilityAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentEducationOrganizationResponsibilityAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentGradebookEntry table of the StudentGradebookEntry aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentGradebookEntry>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentGradebookEntry resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentGradebookEntry' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentGradebookEntry;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentGradebookEntry) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentHealth table of the StudentHealth aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentHealthRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentHealth>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentHealth resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentHealth' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentHealth;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentHealth) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentHomelessProgramAssociation table of the StudentHomelessProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentHomelessProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentHomelessProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentHomelessProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentHomelessProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentHomelessProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentIdentificationCode table of the StudentIdentificationCode aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentIdentificationCodeRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentIdentificationCode>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentIdentificationCode resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentIdentificationCode' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentIdentificationCode;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentIdentificationCode) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentInterventionAssociation table of the StudentInterventionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentInterventionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentInterventionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentInterventionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentInterventionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // CohortEducationOrganizationId = entity.CohortEducationOrganizationId, // Role name applied and not part of primary key
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "CohortEducationOrganizationId",
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentInterventionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentInterventionAttendanceEvent table of the StudentInterventionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentInterventionAttendanceEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentInterventionAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentInterventionAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentInterventionAttendanceEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentInterventionAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentLanguageInstructionProgramAssociation table of the StudentLanguageInstructionProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentLanguageInstructionProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentLanguageInstructionProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentLanguageInstructionProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentLanguageInstructionProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentLanguageInstructionProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentMigrantEducationProgramAssociation table of the StudentMigrantEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentMigrantEducationProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentMigrantEducationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentMigrantEducationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentMigrantEducationProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentMigrantEducationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentNeglectedOrDelinquentProgramAssociation table of the StudentNeglectedOrDelinquentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentNeglectedOrDelinquentProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentNeglectedOrDelinquentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentNeglectedOrDelinquentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentNeglectedOrDelinquentProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentNeglectedOrDelinquentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentPath table of the StudentPath aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentPathRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentPath>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentPath resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentPath' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentPath;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentPath) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentPathMilestoneStatus table of the StudentPathMilestoneStatus aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentPathMilestoneStatusRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentPathMilestoneStatus>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentPathMilestoneStatus resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentPathMilestoneStatus' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentPathMilestoneStatus;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentPathMilestoneStatus) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentPathPhaseStatus table of the StudentPathPhaseStatus aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentPathPhaseStatusRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentPathPhaseStatus>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentPathPhaseStatus resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentPathPhaseStatus' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentPathPhaseStatus;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentPathPhaseStatus) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentProgramAssociation table of the StudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentProgramAttendanceEvent table of the StudentProgramAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentProgramAttendanceEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentProgramAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentProgramAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentProgramAttendanceEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentProgramAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentProgramEvaluation table of the StudentProgramEvaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentProgramEvaluationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentProgramEvaluation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentProgramEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentProgramEvaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentProgramEvaluation;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            // StaffEvaluatorStaffUSI = entity.StaffEvaluatorStaffUSI, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    // "StaffEvaluatorStaffUSI",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentProgramEvaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // NextYearSchoolId = entity.NextYearSchoolId, // Role name applied and not part of primary key
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    // "NextYearSchoolId",
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolAttendanceEvent table of the StudentSchoolAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolAttendanceEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSchoolAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolAttendanceEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolFoodServiceProgramAssociation table of the StudentSchoolFoodServiceProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolFoodServiceProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSchoolFoodServiceProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolFoodServiceProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolFoodServiceProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolFoodServiceProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSection504ProgramAssociation table of the StudentSection504ProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSection504ProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSection504ProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSection504ProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSection504ProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSection504ProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSection504ProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSectionAssociation table of the StudentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSectionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSectionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            // DualCreditEducationOrganizationId = entity.DualCreditEducationOrganizationId, // Role name applied and not part of primary key
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "DualCreditEducationOrganizationId",
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSectionAttendanceEvent table of the StudentSectionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSectionAttendanceEvent>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSectionAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSectionAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSectionAttendanceEvent;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSectionAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSpecialEducationProgramAssociation table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSpecialEducationProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSpecialEducationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSpecialEducationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSpecialEducationProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSpecialEducationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSpecialEducationProgramEligibilityAssociation table of the StudentSpecialEducationProgramEligibilityAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramEligibilityAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentSpecialEducationProgramEligibilityAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentSpecialEducationProgramEligibilityAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSpecialEducationProgramEligibilityAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSpecialEducationProgramEligibilityAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentSpecialEducationProgramEligibilityAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentTitleIPartAProgramAssociation table of the StudentTitleIPartAProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentTitleIPartAProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentTitleIPartAProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentTitleIPartAProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentTitleIPartAProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "ProgramEducationOrganizationId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentTitleIPartAProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentTransportation table of the StudentTransportation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentTransportationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentTransportation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentTransportation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentTransportation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentTransportation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            // TransportationEducationOrganizationId = entity.TransportationEducationOrganizationId, // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StudentUSI",
                    // "TransportationEducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentTransportation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Survey table of the Survey aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurvey>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurvey resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'survey' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Survey;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // SchoolId = entity.SchoolId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    // "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((Survey) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyCourseAssociation table of the SurveyCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveyCourseAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveyCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyCourseAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveyCourseAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyProgramAssociation table of the SurveyProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveyProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveyProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyProgramAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveyProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponse table of the SurveyResponse aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveyResponse>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveyResponse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponse' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponse;

            var contextData = new RelationshipsAuthorizationContextData();
            // ContactUSI = entity.ContactUSI, // Not part of primary key
            // StaffUSI = entity.StaffUSI, // Not part of primary key
            // StudentUSI = entity.StudentUSI, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "ContactUSI",
                    // "StaffUSI",
                    // "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponse) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponseEducationOrganizationTargetAssociation table of the SurveyResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveyResponseEducationOrganizationTargetAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveyResponseEducationOrganizationTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponseEducationOrganizationTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponseEducationOrganizationTargetAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponseEducationOrganizationTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponseStaffTargetAssociation table of the SurveyResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveyResponseStaffTargetAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveyResponseStaffTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponseStaffTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponseStaffTargetAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponseStaffTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySection table of the SurveySection aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveySection>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveySection resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySection' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySection;

            var contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveySection) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionAggregateResponse table of the SurveySectionAggregateResponse aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveySectionAggregateResponse>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveySectionAggregateResponse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionAggregateResponse' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionAggregateResponse;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionAggregateResponse) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionAssociation table of the SurveySectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveySectionAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveySectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.SchoolId = entity.SchoolId == default(long) ? null as long? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionResponseEducationOrganizationTargetAssociation table of the SurveySectionResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveySectionResponseEducationOrganizationTargetAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveySectionResponseEducationOrganizationTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionResponseEducationOrganizationTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionResponseEducationOrganizationTargetAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionResponseEducationOrganizationTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionResponseStaffTargetAssociation table of the SurveySectionResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<ISurveySectionResponseStaffTargetAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(ISurveySectionResponseStaffTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionResponseStaffTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionResponseStaffTargetAssociation;

            var contextData = new RelationshipsAuthorizationContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionResponseStaffTargetAssociation) resource);
        }
    }

}
