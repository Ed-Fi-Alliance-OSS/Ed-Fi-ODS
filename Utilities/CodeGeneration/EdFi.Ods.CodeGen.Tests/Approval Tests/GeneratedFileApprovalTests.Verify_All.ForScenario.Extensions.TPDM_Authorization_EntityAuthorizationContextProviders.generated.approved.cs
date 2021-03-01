
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
using EdFi.Ods.Entities.NHibernate.ApplicantProspectAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicationEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CertificationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CertificationExamAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CompleterAsStaffAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EmploymentEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EmploymentSeparationEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationElementAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationElementRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.FieldworkExperienceAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.FieldworkExperienceSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.GoalAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ProspectAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureScoreAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricDimensionAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffApplicantAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffProspectAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureCourseAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffStudentGrowthMeasureSectionAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffTeacherPreparationProviderAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffTeacherPreparationProviderProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SurveySectionAggregateResponseAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateAcademicRecordAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.TeacherCandidateCourseTranscriptAggregate.TPDM;
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Certification table of the Certification aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CertificationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICertification, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICertification resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'certification' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Certification;

            dynamic contextData = new TContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return (TContextData) contextData;
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
            return GetContextData((Certification) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CertificationExam table of the CertificationExam aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CertificationExamRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICertificationExam, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICertificationExam resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'certificationExam' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CertificationExam;

            dynamic contextData = new TContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return (TContextData) contextData;
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
            return GetContextData((CertificationExam) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Evaluation table of the Evaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Evaluation;

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
            return GetContextData((Evaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EvaluationElement table of the EvaluationElement aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluationElement, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluationElement resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationElement' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationElement;

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
            return GetContextData((EvaluationElement) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EvaluationElementRating table of the EvaluationElementRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationElementRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluationElementRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluationElementRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationElementRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationElementRating;

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
            return GetContextData((EvaluationElementRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EvaluationObjective table of the EvaluationObjective aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluationObjective, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluationObjective resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationObjective' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationObjective;

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
            return GetContextData((EvaluationObjective) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EvaluationObjectiveRating table of the EvaluationObjectiveRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationObjectiveRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluationObjectiveRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluationObjectiveRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationObjectiveRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationObjectiveRating;

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
            return GetContextData((EvaluationObjectiveRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EvaluationRating table of the EvaluationRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EvaluationRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEvaluationRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEvaluationRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'evaluationRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EvaluationRating;

            dynamic contextData = new TContextData();
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
            return GetContextData((EvaluationRating) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.FieldworkExperience table of the FieldworkExperience aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IFieldworkExperience, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IFieldworkExperience resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'fieldworkExperience' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FieldworkExperience;

            dynamic contextData = new TContextData();
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return (TContextData) contextData;
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
            return GetContextData((FieldworkExperience) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.FieldworkExperienceSectionAssociation table of the FieldworkExperienceSectionAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FieldworkExperienceSectionAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IFieldworkExperienceSectionAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IFieldworkExperienceSectionAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'fieldworkExperienceSectionAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FieldworkExperienceSectionAssociation;

            dynamic contextData = new TContextData();
            contextData.SchoolId = entity.SchoolId == default(int) ? null as int? : entity.SchoolId; // Primary key property, Only Education Organization Id present
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
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
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((FieldworkExperienceSectionAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Goal table of the Goal aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GoalRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IGoal, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IGoal resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'goal' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Goal;

            dynamic contextData = new TContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            return (TContextData) contextData;
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
            return GetContextData((Goal) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.PerformanceEvaluation table of the PerformanceEvaluation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPerformanceEvaluation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPerformanceEvaluation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceEvaluation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceEvaluation;

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
            return GetContextData((PerformanceEvaluation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.PerformanceEvaluationRating table of the PerformanceEvaluationRating aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PerformanceEvaluationRatingRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IPerformanceEvaluationRating, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IPerformanceEvaluationRating resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'performanceEvaluationRating' resource for obtaining authorization context data cannot be null.");

            var entity = resource as PerformanceEvaluationRating;

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
            return GetContextData((PerformanceEvaluationRating) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.QuantitativeMeasure table of the QuantitativeMeasure aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IQuantitativeMeasure, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IQuantitativeMeasure resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'quantitativeMeasure' resource for obtaining authorization context data cannot be null.");

            var entity = resource as QuantitativeMeasure;

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
            return GetContextData((QuantitativeMeasure) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.QuantitativeMeasureScore table of the QuantitativeMeasureScore aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class QuantitativeMeasureScoreRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IQuantitativeMeasureScore, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IQuantitativeMeasureScore resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'quantitativeMeasureScore' resource for obtaining authorization context data cannot be null.");

            var entity = resource as QuantitativeMeasureScore;

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
            return GetContextData((QuantitativeMeasureScore) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RubricDimension table of the RubricDimension aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RubricDimensionRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRubricDimension, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRubricDimension resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'rubricDimension' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RubricDimension;

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
            return GetContextData((RubricDimension) resource);
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
            return GetContextData((StaffApplicantAssociation) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.SurveySectionAggregateResponse table of the SurveySectionAggregateResponse aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SurveySectionAggregateResponseRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ISurveySectionAggregateResponse, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ISurveySectionAggregateResponse resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'surveySectionAggregateResponse' resource for obtaining authorization context data cannot be null.");

            var entity = resource as SurveySectionAggregateResponse;

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
            return GetContextData((SurveySectionAggregateResponse) resource);
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
