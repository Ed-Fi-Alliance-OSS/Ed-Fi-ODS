
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.TPDM;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentAcademicRecordAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentAssessmentCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentAssessmentSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentCourseTranscriptAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentEducationOrganizationAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.AnonymizedStudentSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicantAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicantProspectAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicationEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CompleterAsStaffAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CourseCourseTranscriptFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CourseStudentAcademicRecordFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CourseStudentAssessmentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CourseStudentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationCourseTranscriptFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationStudentAcademicRecordFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationStudentAssessmentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationStudentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EmploymentEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EmploymentSeparationEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceMeasureCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceMeasureFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ProspectAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ProspectProfessionalDevelopmentEventAttendanceAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricLevelAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricLevelResponseAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricLevelResponseFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SectionCourseTranscriptFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SectionStudentAcademicRecordFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SectionStudentAssessmentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SectionStudentFactsAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffApplicantAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationComponentAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationComponentRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationElementAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationElementRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEvaluationRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffFieldworkAbsenceEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffFieldworkExperienceAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffFieldworkExperienceSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffProfessionalDevelopmentEventAttendanceAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffProspectAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffTeacherPreparationProviderAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffTeacherPreparationProviderProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateAcademicRecordAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateCourseTranscriptAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateFieldworkExperienceSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateStaffAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateStudentGrowthMeasureCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateStudentGrowthMeasureSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateTeacherPreparationProviderProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherPreparationProviderAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherPreparationProviderProgramAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.UniversityAggregate.TPDM;
#endregion

namespace EdFi.Ods.Security.Authorization.ContextDataProviders.TPDM
{ 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentAcademicRecord table of the AnonymizedStudentAcademicRecord aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAcademicRecordRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentAcademicRecord, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentAcademicRecord resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentAcademicRecord' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentAcademicRecord;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentAcademicRecord) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentAssessmentCourseAssociation table of the AnonymizedStudentAssessmentCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentAssessmentCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentAssessmentCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentAssessmentCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentAssessmentCourseAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentAssessmentCourseAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentAssessmentSectionAssociation table of the AnonymizedStudentAssessmentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentAssessmentSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentAssessmentSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentAssessmentSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentAssessmentSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentAssessmentSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentAssessmentSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentCourseAssociation table of the AnonymizedStudentCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentCourseAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentCourseAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentCourseTranscript table of the AnonymizedStudentCourseTranscript aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentCourseTranscriptRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentCourseTranscript, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentCourseTranscript resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentCourseTranscript' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentCourseTranscript;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentCourseTranscript) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentEducationOrganizationAssociation table of the AnonymizedStudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentEducationOrganizationAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentEducationOrganizationAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentEducationOrganizationAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.AnonymizedStudentSectionAssociation table of the AnonymizedStudentSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AnonymizedStudentSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IAnonymizedStudentSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IAnonymizedStudentSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'anonymizedStudentSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as AnonymizedStudentSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((AnonymizedStudentSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Applicant table of the Applicant aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicantRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IApplicant, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IApplicant resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'applicant' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Applicant;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((Applicant) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.ApplicantProspectAssociation table of the ApplicantProspectAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicantProspectAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IApplicantProspectAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IApplicantProspectAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'applicantProspectAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ApplicantProspectAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((ApplicantProspectAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Application table of the Application aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IApplication, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IApplication resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'application' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Application;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((Application) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.ApplicationEvent table of the ApplicationEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicationEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IApplicationEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IApplicationEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'applicationEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ApplicationEvent;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((ApplicationEvent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CompleterAsStaffAssociation table of the CompleterAsStaffAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CompleterAsStaffAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICompleterAsStaffAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICompleterAsStaffAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'completerAsStaffAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CompleterAsStaffAssociation;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((CompleterAsStaffAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CourseCourseTranscriptFacts table of the CourseCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseCourseTranscriptFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseCourseTranscriptFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseCourseTranscriptFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseCourseTranscriptFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseCourseTranscriptFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((CourseCourseTranscriptFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CourseStudentAcademicRecordFacts table of the CourseStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseStudentAcademicRecordFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseStudentAcademicRecordFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseStudentAcademicRecordFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseStudentAcademicRecordFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseStudentAcademicRecordFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((CourseStudentAcademicRecordFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CourseStudentAssessmentFacts table of the CourseStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseStudentAssessmentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseStudentAssessmentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseStudentAssessmentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseStudentAssessmentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseStudentAssessmentFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((CourseStudentAssessmentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CourseStudentFacts table of the CourseStudentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CourseStudentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICourseStudentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICourseStudentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'courseStudentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CourseStudentFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((CourseStudentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducationOrganizationCourseTranscriptFacts table of the EducationOrganizationCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCourseTranscriptFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationCourseTranscriptFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationCourseTranscriptFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationCourseTranscriptFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationCourseTranscriptFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EducationOrganizationCourseTranscriptFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducationOrganizationFacts table of the EducationOrganizationFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EducationOrganizationFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducationOrganizationStudentAcademicRecordFacts table of the EducationOrganizationStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAcademicRecordFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationStudentAcademicRecordFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationStudentAcademicRecordFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationStudentAcademicRecordFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationStudentAcademicRecordFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EducationOrganizationStudentAcademicRecordFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducationOrganizationStudentAssessmentFacts table of the EducationOrganizationStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentAssessmentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationStudentAssessmentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationStudentAssessmentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationStudentAssessmentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationStudentAssessmentFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EducationOrganizationStudentAssessmentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducationOrganizationStudentFacts table of the EducationOrganizationStudentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationStudentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducationOrganizationStudentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducationOrganizationStudentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educationOrganizationStudentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducationOrganizationStudentFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EducationOrganizationStudentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EmploymentEvent table of the EmploymentEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EmploymentEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEmploymentEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEmploymentEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'employmentEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EmploymentEvent;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EmploymentEvent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EmploymentSeparationEvent table of the EmploymentSeparationEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EmploymentSeparationEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEmploymentSeparationEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEmploymentSeparationEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'employmentSeparationEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EmploymentSeparationEvent;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((EmploymentSeparationEvent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.OpenStaffPositionEvent table of the OpenStaffPositionEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IOpenStaffPositionEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IOpenStaffPositionEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'openStaffPositionEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as OpenStaffPositionEvent;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((OpenStaffPositionEvent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.PerformanceMeasureCourseAssociation table of the PerformanceMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPerformanceMeasureCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPerformanceMeasureCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceMeasureCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceMeasureCourseAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((PerformanceMeasureCourseAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.PerformanceMeasureFacts table of the PerformanceMeasureFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceMeasureFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPerformanceMeasureFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPerformanceMeasureFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceMeasureFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceMeasureFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((PerformanceMeasureFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Prospect table of the Prospect aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProspectRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IProspect, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IProspect resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'prospect' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Prospect;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((Prospect) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.ProspectProfessionalDevelopmentEventAttendance table of the ProspectProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProspectProfessionalDevelopmentEventAttendanceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IProspectProfessionalDevelopmentEventAttendance, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IProspectProfessionalDevelopmentEventAttendance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'prospectProfessionalDevelopmentEventAttendance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as ProspectProfessionalDevelopmentEventAttendance;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((ProspectProfessionalDevelopmentEventAttendance) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Rubric table of the Rubric aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRubric, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRubric resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubric' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Rubric;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((Rubric) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RubricLevel table of the RubricLevel aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricLevelRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRubricLevel, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRubricLevel resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubricLevel' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RubricLevel;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((RubricLevel) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RubricLevelResponse table of the RubricLevelResponse aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRubricLevelResponse, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRubricLevelResponse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubricLevelResponse' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RubricLevelResponse;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((RubricLevelResponse) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RubricLevelResponseFacts table of the RubricLevelResponseFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricLevelResponseFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRubricLevelResponseFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRubricLevelResponseFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubricLevelResponseFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RubricLevelResponseFacts;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((RubricLevelResponseFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.SectionCourseTranscriptFacts table of the SectionCourseTranscriptFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionCourseTranscriptFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISectionCourseTranscriptFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISectionCourseTranscriptFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionCourseTranscriptFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionCourseTranscriptFacts;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((SectionCourseTranscriptFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.SectionStudentAcademicRecordFacts table of the SectionStudentAcademicRecordFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionStudentAcademicRecordFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISectionStudentAcademicRecordFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISectionStudentAcademicRecordFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionStudentAcademicRecordFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionStudentAcademicRecordFacts;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((SectionStudentAcademicRecordFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.SectionStudentAssessmentFacts table of the SectionStudentAssessmentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionStudentAssessmentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISectionStudentAssessmentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISectionStudentAssessmentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionStudentAssessmentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionStudentAssessmentFacts;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((SectionStudentAssessmentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.SectionStudentFacts table of the SectionStudentFacts aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SectionStudentFactsRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISectionStudentFacts, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISectionStudentFacts resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'sectionStudentFacts' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SectionStudentFacts;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((SectionStudentFacts) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffApplicantAssociation table of the StaffApplicantAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffApplicantAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffApplicantAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffApplicantAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffApplicantAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffApplicantAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffApplicantAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluation table of the StaffEvaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((StaffEvaluation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluationComponent table of the StaffEvaluationComponent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluationComponent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluationComponent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluationComponent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluationComponent;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((StaffEvaluationComponent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluationComponentRating table of the StaffEvaluationComponentRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationComponentRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluationComponentRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluationComponentRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluationComponentRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluationComponentRating;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffEvaluationComponentRating) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluationElement table of the StaffEvaluationElement aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluationElement, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluationElement resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluationElement' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluationElement;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((StaffEvaluationElement) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluationElementRating table of the StaffEvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationElementRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluationElementRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluationElementRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluationElementRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluationElementRating;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffEvaluationElementRating) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEvaluationRating table of the StaffEvaluationRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEvaluationRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEvaluationRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEvaluationRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEvaluationRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEvaluationRating;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // EvaluatedByStaffUSI = entity.EvaluatedByStaffUSI, // Not part of primary key
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "EvaluatedByStaffUSI",
                    "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StaffEvaluationRating) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffFieldworkAbsenceEvent table of the StaffFieldworkAbsenceEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkAbsenceEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffFieldworkAbsenceEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffFieldworkAbsenceEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffFieldworkAbsenceEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffFieldworkAbsenceEvent;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffFieldworkAbsenceEvent) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffFieldworkExperience table of the StaffFieldworkExperience aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffFieldworkExperience, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffFieldworkExperience resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffFieldworkExperience' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffFieldworkExperience;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffFieldworkExperience) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffFieldworkExperienceSectionAssociation table of the StaffFieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffFieldworkExperienceSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffFieldworkExperienceSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffFieldworkExperienceSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffFieldworkExperienceSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffFieldworkExperienceSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffFieldworkExperienceSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffProfessionalDevelopmentEventAttendance table of the StaffProfessionalDevelopmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffProfessionalDevelopmentEventAttendanceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffProfessionalDevelopmentEventAttendance, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffProfessionalDevelopmentEventAttendance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffProfessionalDevelopmentEventAttendance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffProfessionalDevelopmentEventAttendance;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffProfessionalDevelopmentEventAttendance) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffProspectAssociation table of the StaffProspectAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffProspectAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffProspectAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffProspectAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffProspectAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffProspectAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffProspectAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffStudentGrowthMeasure table of the StaffStudentGrowthMeasure aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffStudentGrowthMeasure, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffStudentGrowthMeasure resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffStudentGrowthMeasure' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffStudentGrowthMeasure;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffStudentGrowthMeasure) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffStudentGrowthMeasureCourseAssociation table of the StaffStudentGrowthMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffStudentGrowthMeasureCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffStudentGrowthMeasureCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffStudentGrowthMeasureCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffStudentGrowthMeasureCourseAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffStudentGrowthMeasureCourseAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation table of the StaffStudentGrowthMeasureEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffStudentGrowthMeasureEducationOrganizationAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffStudentGrowthMeasureEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffStudentGrowthMeasureEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffStudentGrowthMeasureEducationOrganizationAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffStudentGrowthMeasureEducationOrganizationAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffStudentGrowthMeasureSectionAssociation table of the StaffStudentGrowthMeasureSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffStudentGrowthMeasureSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffStudentGrowthMeasureSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffStudentGrowthMeasureSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffStudentGrowthMeasureSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffStudentGrowthMeasureSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffStudentGrowthMeasureSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffTeacherPreparationProviderAssociation table of the StaffTeacherPreparationProviderAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffTeacherPreparationProviderAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffTeacherPreparationProviderAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffTeacherPreparationProviderAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffTeacherPreparationProviderAssociation;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffTeacherPreparationProviderAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffTeacherPreparationProviderProgramAssociation table of the StaffTeacherPreparationProviderProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffTeacherPreparationProviderProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffTeacherPreparationProviderProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffTeacherPreparationProviderProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffTeacherPreparationProviderProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffTeacherPreparationProviderProgramAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((StaffTeacherPreparationProviderProgramAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidate table of the TeacherCandidate aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidate, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidate resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidate' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidate;

            dynamic contextData = new TContextData();
            // StudentUSI = entity.StudentUSI, // Not part of primary key
            return (TContextData) contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((TeacherCandidate) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateAcademicRecord table of the TeacherCandidateAcademicRecord aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateAcademicRecordRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateAcademicRecord, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateAcademicRecord resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateAcademicRecord' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateAcademicRecord;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateAcademicRecord) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateCourseTranscript table of the TeacherCandidateCourseTranscript aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateCourseTranscriptRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateCourseTranscript, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateCourseTranscript resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateCourseTranscript' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateCourseTranscript;

            dynamic contextData = new TContextData();
            // CourseEducationOrganizationId = entity.CourseEducationOrganizationId, // Primary key property, Role name applied
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // SchoolId = entity.SchoolId, // Not part of primary key
            return (TContextData) contextData;
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
                    // "SchoolId",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((TeacherCandidateCourseTranscript) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateFieldworkExperienceSectionAssociation table of the TeacherCandidateFieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateFieldworkExperienceSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateFieldworkExperienceSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateFieldworkExperienceSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateFieldworkExperienceSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateFieldworkExperienceSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateFieldworkExperienceSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateStaffAssociation table of the TeacherCandidateStaffAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStaffAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateStaffAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateStaffAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateStaffAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateStaffAssociation;

            dynamic contextData = new TContextData();
            contextData.StaffUSI = entity.StaffUSI == default(int) ? null as int? : entity.StaffUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateStaffAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation table of the TeacherCandidateStudentGrowthMeasureCourseAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureCourseAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateStudentGrowthMeasureCourseAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateStudentGrowthMeasureCourseAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateStudentGrowthMeasureCourseAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateStudentGrowthMeasureCourseAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateStudentGrowthMeasureCourseAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation table of the TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateStudentGrowthMeasureEducationOrganizationAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation table of the TeacherCandidateStudentGrowthMeasureSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateStudentGrowthMeasureSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateStudentGrowthMeasureSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateStudentGrowthMeasureSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateStudentGrowthMeasureSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateStudentGrowthMeasureSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateStudentGrowthMeasureSectionAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation table of the TeacherCandidateTeacherPreparationProviderProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherCandidateTeacherPreparationProviderProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherCandidateTeacherPreparationProviderProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherCandidateTeacherPreparationProviderProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherCandidateTeacherPreparationProviderProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherCandidateTeacherPreparationProviderProgramAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherCandidateTeacherPreparationProviderProgramAssociation) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherPreparationProvider table of the TeacherPreparationProvider aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherPreparationProvider, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherPreparationProvider resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherPreparationProvider' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherPreparationProvider;

            dynamic contextData = new TContextData();
            // SchoolId = entity.SchoolId, // Not part of primary key
            return (TContextData) contextData;
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
            return GetContextData((TeacherPreparationProvider) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.TeacherPreparationProviderProgram table of the TeacherPreparationProviderProgram aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TeacherPreparationProviderProgramRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ITeacherPreparationProviderProgram, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ITeacherPreparationProviderProgram resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'teacherPreparationProviderProgram' resource for obtaining authorization context data cannot be null.");

            var entity = resource as TeacherPreparationProviderProgram;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            return (TContextData) contextData;
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
            return GetContextData((TeacherPreparationProviderProgram) resource);
        } 
    } 

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.University table of the University aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class UniversityRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IUniversity, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {     
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IUniversity resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'university' resource for obtaining authorization context data cannot be null.");

            var entity = resource as University;

            dynamic contextData = new TContextData();
            // SchoolId = entity.SchoolId, // Not part of primary key
            return (TContextData) contextData;
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
            return GetContextData((University) resource);
        } 
    } 

}
