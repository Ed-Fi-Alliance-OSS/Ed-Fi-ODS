
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.AcademicWeekAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AccountabilityRatingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.BellScheduleAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CalendarAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CalendarDateAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ChartOfAccountAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ClassPeriodAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CohortAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CommunityProviderLicenseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CompetencyObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseOfferingAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CourseTranscriptAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.DisciplineActionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.DisciplineIncidentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationInterventionPrescriptionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationPeerAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationServiceCenterAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.FeederSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.GeneralStudentProgramAssociationAggregate.EdFi;
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
using EdFi.Ods.Entities.NHibernate.OrganizationDepartmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ParentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PostSecondaryEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.PostSecondaryInstitutionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ReportCardAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.RestraintEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SectionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SectionAttendanceTakenEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SessionAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffAbsenceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffCohortAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffDisciplineIncidentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationContactAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffLeaveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StaffSectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StateEducationAgencyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAcademicRecordAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentEducationOrganizationAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCohortAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCompetencyObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentCTEProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDisciplineIncidentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDisciplineIncidentBehaviorAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentDisciplineIncidentNonOffenderAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationResponsibilityAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentGradebookEntryAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentHomelessProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentInterventionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentInterventionAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentLanguageInstructionProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentLearningObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentMigrantEducationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentNeglectedOrDelinquentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentParentAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSchoolFoodServiceProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSectionAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSectionAttendanceEventAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentTitleIPartAProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyCourseAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseEducationOrganizationTargetAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SurveyResponseStaffTargetAssociationAggregate.EdFi;
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
    public class AcademicWeekRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAcademicWeek, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAcademicWeek resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'academicWeek' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AcademicWeek;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((AcademicWeek) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.AccountabilityRating table of the AccountabilityRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAccountabilityRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAccountabilityRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'accountabilityRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AccountabilityRating;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((AccountabilityRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Assessment table of the Assessment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssessmentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAssessment, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAssessment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'assessment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Assessment;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Assessment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.BellSchedule table of the BellSchedule aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BellScheduleRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IBellSchedule, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IBellSchedule resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'bellSchedule' resource for obtaining authorization context data cannot be null.");

            var entity = resource as BellSchedule;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((BellSchedule) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Calendar table of the Calendar aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CalendarRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICalendar, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICalendar resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'calendar' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Calendar;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Calendar) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CalendarDate table of the CalendarDate aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CalendarDateRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICalendarDate, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICalendarDate resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'calendarDate' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CalendarDate;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CalendarDate) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ChartOfAccount table of the ChartOfAccount aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ChartOfAccountRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IChartOfAccount, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IChartOfAccount resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'chartOfAccount' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ChartOfAccount;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((ChartOfAccount) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ClassPeriod table of the ClassPeriod aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ClassPeriodRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IClassPeriod, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IClassPeriod resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'classPeriod' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ClassPeriod;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((ClassPeriod) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Cohort table of the Cohort aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CohortRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICohort, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICohort resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'cohort' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Cohort;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Cohort) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityOrganization table of the CommunityOrganization aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICommunityOrganization, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICommunityOrganization resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityOrganization' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityOrganization;

            var contextData = new TContextData();
            contextData.CommunityOrganizationId = entity.CommunityOrganizationId == default(int) ? null as int? : entity.CommunityOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CommunityOrganization) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityProvider table of the CommunityProvider aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityProviderRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICommunityProvider, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICommunityProvider resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityProvider' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityProvider;

            var contextData = new TContextData();
            // CommunityOrganizationId = entity.CommunityOrganizationId, // Not part of primary key
            contextData.CommunityProviderId = entity.CommunityProviderId == default(int) ? null as int? : entity.CommunityProviderId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CommunityProvider) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CommunityProviderLicense table of the CommunityProviderLicense aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicenseRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICommunityProviderLicense, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICommunityProviderLicense resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'communityProviderLicense' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CommunityProviderLicense;

            var contextData = new TContextData();
            contextData.CommunityProviderId = entity.CommunityProviderId == default(int) ? null as int? : entity.CommunityProviderId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CommunityProviderLicense) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CompetencyObjective table of the CompetencyObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CompetencyObjectiveRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICompetencyObjective, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICompetencyObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'competencyObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CompetencyObjective;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CompetencyObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Course table of the Course aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourse, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'course' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Course;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Course) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CourseOffering table of the CourseOffering aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseOfferingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseOffering, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseOffering resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseOffering' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseOffering;

            var contextData = new TContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CourseOffering) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.CourseTranscript table of the CourseTranscript aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseTranscriptRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseTranscript, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseTranscript resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseTranscript' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseTranscript;

            var contextData = new TContextData();
            // CourseEducationOrganizationId = entity.CourseEducationOrganizationId, // Primary key property, Role name applied
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ExternalEducationOrganizationId = entity.ExternalEducationOrganizationId, // Role name applied and not part of primary key
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
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((CourseTranscript) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.DisciplineAction table of the DisciplineAction aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DisciplineActionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IDisciplineAction, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IDisciplineAction resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'disciplineAction' resource for obtaining authorization context data cannot be null.");

            var entity = resource as DisciplineAction;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((DisciplineAction) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.DisciplineIncident table of the DisciplineIncident aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IDisciplineIncident, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IDisciplineIncident resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'disciplineIncident' resource for obtaining authorization context data cannot be null.");

            var entity = resource as DisciplineIncident;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((DisciplineIncident) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganization table of the EducationOrganization aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganization, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganization resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganization' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganization;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganization) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationInterventionPrescriptionAssociation table of the EducationOrganizationInterventionPrescriptionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationInterventionPrescriptionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationInterventionPrescriptionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationInterventionPrescriptionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationInterventionPrescriptionAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationInterventionPrescriptionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationNetwork table of the EducationOrganizationNetwork aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationNetwork, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationNetwork resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationNetwork' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationNetwork;

            var contextData = new TContextData();
            contextData.EducationOrganizationNetworkId = entity.EducationOrganizationNetworkId == default(int) ? null as int? : entity.EducationOrganizationNetworkId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationNetwork) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationNetworkAssociation table of the EducationOrganizationNetworkAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationNetworkAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationNetworkAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationNetworkAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationNetworkAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationNetworkId = entity.EducationOrganizationNetworkId == default(int) ? null as int? : entity.EducationOrganizationNetworkId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationNetworkAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationOrganizationPeerAssociation table of the EducationOrganizationPeerAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationPeerAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationPeerAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationPeerAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationPeerAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationPeerAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.EducationServiceCenter table of the EducationServiceCenter aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationServiceCenter, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationServiceCenter resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationServiceCenter' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationServiceCenter;

            var contextData = new TContextData();
            contextData.EducationServiceCenterId = entity.EducationServiceCenterId == default(int) ? null as int? : entity.EducationServiceCenterId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationServiceCenter) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.FeederSchoolAssociation table of the FeederSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IFeederSchoolAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IFeederSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'feederSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FeederSchoolAssociation;

            var contextData = new TContextData();
            // FeederSchoolId = entity.FeederSchoolId, // Primary key property, Role name applied
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((FeederSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GeneralStudentProgramAssociation table of the GeneralStudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GeneralStudentProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGeneralStudentProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGeneralStudentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'generalStudentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GeneralStudentProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((GeneralStudentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Grade table of the Grade aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradeRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGrade, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGrade resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'grade' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Grade;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Grade) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GradebookEntry table of the GradebookEntry aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradebookEntryRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGradebookEntry, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGradebookEntry resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'gradebookEntry' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GradebookEntry;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((GradebookEntry) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GradingPeriod table of the GradingPeriod aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GradingPeriodRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGradingPeriod, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGradingPeriod resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'gradingPeriod' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GradingPeriod;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((GradingPeriod) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.GraduationPlan table of the GraduationPlan aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GraduationPlanRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGraduationPlan, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGraduationPlan resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'graduationPlan' resource for obtaining authorization context data cannot be null.");

            var entity = resource as GraduationPlan;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((GraduationPlan) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Intervention table of the Intervention aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IIntervention, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IIntervention resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'intervention' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Intervention;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Intervention) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.InterventionPrescription table of the InterventionPrescription aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IInterventionPrescription, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IInterventionPrescription resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'interventionPrescription' resource for obtaining authorization context data cannot be null.");

            var entity = resource as InterventionPrescription;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((InterventionPrescription) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.InterventionStudy table of the InterventionStudy aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InterventionStudyRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IInterventionStudy, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IInterventionStudy resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'interventionStudy' resource for obtaining authorization context data cannot be null.");

            var entity = resource as InterventionStudy;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((InterventionStudy) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalAccount table of the LocalAccount aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalAccountRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalAccount, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalAccount resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localAccount' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalAccount;

            var contextData = new TContextData();
            // ChartOfAccountEducationOrganizationId = entity.ChartOfAccountEducationOrganizationId, // Role name applied and not part of primary key
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalAccount) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalActual table of the LocalActual aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalActualRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalActual, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalActual resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localActual' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalActual;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalActual) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalBudget table of the LocalBudget aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalBudgetRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalBudget, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalBudget resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localBudget' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalBudget;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalBudget) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalContractedStaff table of the LocalContractedStaff aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalContractedStaff, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalContractedStaff resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localContractedStaff' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalContractedStaff;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalContractedStaff) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalEducationAgency table of the LocalEducationAgency aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalEducationAgency, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalEducationAgency resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localEducationAgency' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalEducationAgency;

            var contextData = new TContextData();
            // EducationServiceCenterId = entity.EducationServiceCenterId, // Not part of primary key
            contextData.LocalEducationAgencyId = entity.LocalEducationAgencyId == default(int) ? null as int? : entity.LocalEducationAgencyId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalEducationAgency) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalEncumbrance table of the LocalEncumbrance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalEncumbranceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalEncumbrance, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalEncumbrance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localEncumbrance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalEncumbrance;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalEncumbrance) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.LocalPayroll table of the LocalPayroll aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocalPayrollRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocalPayroll, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocalPayroll resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'localPayroll' resource for obtaining authorization context data cannot be null.");

            var entity = resource as LocalPayroll;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((LocalPayroll) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Location table of the Location aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LocationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ILocation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ILocation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'location' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Location;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Location) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.OpenStaffPosition table of the OpenStaffPosition aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IOpenStaffPosition, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IOpenStaffPosition resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'openStaffPosition' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OpenStaffPosition;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((OpenStaffPosition) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.OrganizationDepartment table of the OrganizationDepartment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IOrganizationDepartment, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IOrganizationDepartment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'organizationDepartment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OrganizationDepartment;

            var contextData = new TContextData();
            contextData.OrganizationDepartmentId = entity.OrganizationDepartmentId == default(int) ? null as int? : entity.OrganizationDepartmentId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((OrganizationDepartment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Parent table of the Parent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ParentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IParent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IParent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'parent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Parent;

            var contextData = new TContextData();
            contextData.ParentUSI = entity.ParentUSI == default(int) ? null as int? : entity.ParentUSI; // Primary key property, USI
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "ParentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Parent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PostSecondaryEvent table of the PostSecondaryEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPostSecondaryEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPostSecondaryEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'postSecondaryEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PostSecondaryEvent;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((PostSecondaryEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.PostSecondaryInstitution table of the PostSecondaryInstitution aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPostSecondaryInstitution, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPostSecondaryInstitution resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'postSecondaryInstitution' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PostSecondaryInstitution;

            var contextData = new TContextData();
            contextData.PostSecondaryInstitutionId = entity.PostSecondaryInstitutionId == default(int) ? null as int? : entity.PostSecondaryInstitutionId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((PostSecondaryInstitution) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Program table of the Program aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProgramRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IProgram, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IProgram resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'program' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Program;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Program) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.ReportCard table of the ReportCard aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ReportCardRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IReportCard, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IReportCard resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'reportCard' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ReportCard;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((ReportCard) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.RestraintEvent table of the RestraintEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RestraintEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRestraintEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRestraintEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'restraintEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RestraintEvent;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((RestraintEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.School table of the School aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SchoolRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISchool, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISchool resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'school' resource for obtaining authorization context data cannot be null.");

            var entity = resource as School;

            var contextData = new TContextData();
            // LocalEducationAgencyId = entity.LocalEducationAgencyId, // Not part of primary key
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
                    "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((School) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Section table of the Section aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISection, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISection resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'section' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Section;

            var contextData = new TContextData();
            // LocationSchoolId = entity.LocationSchoolId, // Role name applied and not part of primary key
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Section) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SectionAttendanceTakenEvent table of the SectionAttendanceTakenEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISectionAttendanceTakenEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISectionAttendanceTakenEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionAttendanceTakenEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionAttendanceTakenEvent;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SectionAttendanceTakenEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Session table of the Session aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SessionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISession, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISession resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'session' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Session;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Session) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Staff table of the Staff aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaff, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaff resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staff' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Staff;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Staff) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffAbsenceEvent table of the StaffAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffAbsenceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffAbsenceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffAbsenceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffAbsenceEvent;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffAbsenceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffCohortAssociation table of the StaffCohortAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffCohortAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffCohortAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffCohortAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffCohortAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffCohortAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffDisciplineIncidentAssociation table of the StaffDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffDisciplineIncidentAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffDisciplineIncidentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffDisciplineIncidentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffDisciplineIncidentAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffDisciplineIncidentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducationOrganizationAssignmentAssociation table of the StaffEducationOrganizationAssignmentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEducationOrganizationAssignmentAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEducationOrganizationAssignmentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducationOrganizationAssignmentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducationOrganizationAssignmentAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducationOrganizationAssignmentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducationOrganizationContactAssociation table of the StaffEducationOrganizationContactAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEducationOrganizationContactAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEducationOrganizationContactAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducationOrganizationContactAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducationOrganizationContactAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducationOrganizationContactAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffEducationOrganizationEmploymentAssociation table of the StaffEducationOrganizationEmploymentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEducationOrganizationEmploymentAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEducationOrganizationEmploymentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducationOrganizationEmploymentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducationOrganizationEmploymentAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffEducationOrganizationEmploymentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffLeave table of the StaffLeave aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffLeaveRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffLeave, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffLeave resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffLeave' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffLeave;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffLeave) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffProgramAssociation table of the StaffProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffProgramAssociation;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffSchoolAssociation table of the StaffSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffSchoolAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffSchoolAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StaffSectionAssociation table of the StaffSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffSectionAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StateEducationAgency table of the StateEducationAgency aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStateEducationAgency, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStateEducationAgency resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'stateEducationAgency' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StateEducationAgency;

            var contextData = new TContextData();
            contextData.StateEducationAgencyId = entity.StateEducationAgencyId == default(int) ? null as int? : entity.StateEducationAgencyId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StateEducationAgency) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Student table of the Student aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'student' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Student;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Student) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAcademicRecord table of the StudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentAcademicRecord, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentAcademicRecord resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAcademicRecord' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAcademicRecord;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentAcademicRecord) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessment table of the StudentAssessment aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentAssessment, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentAssessment resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessment' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessment;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessment) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentAssessmentEducationOrganizationAssociation table of the StudentAssessmentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentAssessmentEducationOrganizationAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentAssessmentEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAssessmentEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAssessmentEducationOrganizationAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessmentEducationOrganizationAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCohortAssociation table of the StudentCohortAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentCohortAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentCohortAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCohortAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCohortAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentCohortAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCompetencyObjective table of the StudentCompetencyObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectiveRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentCompetencyObjective, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentCompetencyObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCompetencyObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCompetencyObjective;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentCompetencyObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentCTEProgramAssociation table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentCTEProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentCTEProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentCTEProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentCTEProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentCTEProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDisciplineIncidentAssociation table of the StudentDisciplineIncidentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentDisciplineIncidentAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentDisciplineIncidentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDisciplineIncidentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDisciplineIncidentAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentDisciplineIncidentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDisciplineIncidentBehaviorAssociation table of the StudentDisciplineIncidentBehaviorAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentDisciplineIncidentBehaviorAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentDisciplineIncidentBehaviorAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDisciplineIncidentBehaviorAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDisciplineIncidentBehaviorAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentDisciplineIncidentBehaviorAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentDisciplineIncidentNonOffenderAssociation table of the StudentDisciplineIncidentNonOffenderAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentDisciplineIncidentNonOffenderAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentDisciplineIncidentNonOffenderAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentDisciplineIncidentNonOffenderAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentDisciplineIncidentNonOffenderAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentDisciplineIncidentNonOffenderAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentEducationOrganizationAssociation table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentEducationOrganizationAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentEducationOrganizationAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentEducationOrganizationAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentEducationOrganizationResponsibilityAssociation table of the StudentEducationOrganizationResponsibilityAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentEducationOrganizationResponsibilityAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentEducationOrganizationResponsibilityAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentEducationOrganizationResponsibilityAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentEducationOrganizationResponsibilityAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentEducationOrganizationResponsibilityAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentGradebookEntry table of the StudentGradebookEntry aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentGradebookEntry, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentGradebookEntry resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentGradebookEntry' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentGradebookEntry;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentGradebookEntry) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentHomelessProgramAssociation table of the StudentHomelessProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentHomelessProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentHomelessProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentHomelessProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentHomelessProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentHomelessProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentInterventionAssociation table of the StudentInterventionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentInterventionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentInterventionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentInterventionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentInterventionAssociation;

            var contextData = new TContextData();
            // CohortEducationOrganizationId = entity.CohortEducationOrganizationId, // Role name applied and not part of primary key
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentInterventionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentInterventionAttendanceEvent table of the StudentInterventionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentInterventionAttendanceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentInterventionAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentInterventionAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentInterventionAttendanceEvent;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentInterventionAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentLanguageInstructionProgramAssociation table of the StudentLanguageInstructionProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentLanguageInstructionProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentLanguageInstructionProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentLanguageInstructionProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentLanguageInstructionProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentLanguageInstructionProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentLearningObjective table of the StudentLearningObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectiveRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentLearningObjective, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentLearningObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentLearningObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentLearningObjective;

            var contextData = new TContextData();
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
                    // "GradingPeriodSchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentLearningObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentMigrantEducationProgramAssociation table of the StudentMigrantEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentMigrantEducationProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentMigrantEducationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentMigrantEducationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentMigrantEducationProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentMigrantEducationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentNeglectedOrDelinquentProgramAssociation table of the StudentNeglectedOrDelinquentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentNeglectedOrDelinquentProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentNeglectedOrDelinquentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentNeglectedOrDelinquentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentNeglectedOrDelinquentProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentNeglectedOrDelinquentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentParentAssociation table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentParentAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentParentAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentParentAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentParentAssociation;

            var contextData = new TContextData();
            contextData.ParentUSI = entity.ParentUSI == default(int) ? null as int? : entity.ParentUSI; // Primary key property, USI
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
                    "ParentUSI",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentParentAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentProgramAssociation table of the StudentProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentProgramAttendanceEvent table of the StudentProgramAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentProgramAttendanceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentProgramAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentProgramAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentProgramAttendanceEvent;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentProgramAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSchoolAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolAssociation;

            var contextData = new TContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
                    "SchoolId",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolAttendanceEvent table of the StudentSchoolAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolAttendanceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSchoolAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolAttendanceEvent;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSchoolFoodServiceProgramAssociation table of the StudentSchoolFoodServiceProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSchoolFoodServiceProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSchoolFoodServiceProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSchoolFoodServiceProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSchoolFoodServiceProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSchoolFoodServiceProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSectionAssociation table of the StudentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSectionAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSectionAttendanceEvent table of the StudentSectionAttendanceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSectionAttendanceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSectionAttendanceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSectionAttendanceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSectionAttendanceEvent;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSectionAttendanceEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentSpecialEducationProgramAssociation table of the StudentSpecialEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentSpecialEducationProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentSpecialEducationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentSpecialEducationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentSpecialEducationProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentSpecialEducationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.StudentTitleIPartAProgramAssociation table of the StudentTitleIPartAProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentTitleIPartAProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentTitleIPartAProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentTitleIPartAProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentTitleIPartAProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentTitleIPartAProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.Survey table of the Survey aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurvey, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurvey resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'survey' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Survey;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((Survey) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyCourseAssociation table of the SurveyCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveyCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveyCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyCourseAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveyCourseAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyProgramAssociation table of the SurveyProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveyProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveyProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyProgramAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveyProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponse table of the SurveyResponse aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveyResponse, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveyResponse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponse' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponse;

            var contextData = new TContextData();
            // ParentUSI = entity.ParentUSI, // Not part of primary key
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
                    // "ParentUSI",
                    // "StaffUSI",
                    // "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponse) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponseEducationOrganizationTargetAssociation table of the SurveyResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveyResponseEducationOrganizationTargetAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveyResponseEducationOrganizationTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponseEducationOrganizationTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponseEducationOrganizationTargetAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponseEducationOrganizationTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveyResponseStaffTargetAssociation table of the SurveyResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveyResponseStaffTargetAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveyResponseStaffTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveyResponseStaffTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveyResponseStaffTargetAssociation;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveyResponseStaffTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionAssociation table of the SurveySectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveySectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveySectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionAssociation;

            var contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionResponseEducationOrganizationTargetAssociation table of the SurveySectionResponseEducationOrganizationTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveySectionResponseEducationOrganizationTargetAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveySectionResponseEducationOrganizationTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionResponseEducationOrganizationTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionResponseEducationOrganizationTargetAssociation;

            var contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionResponseEducationOrganizationTargetAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the edfi.SurveySectionResponseStaffTargetAssociation table of the SurveySectionResponseStaffTargetAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveySectionResponseStaffTargetAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveySectionResponseStaffTargetAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionResponseStaffTargetAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionResponseStaffTargetAssociation;

            var contextData = new TContextData();
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
        public TContextData GetContextData(object resource)
        {
            return GetContextData((SurveySectionResponseStaffTargetAssociation) resource);
        }
    }

}
