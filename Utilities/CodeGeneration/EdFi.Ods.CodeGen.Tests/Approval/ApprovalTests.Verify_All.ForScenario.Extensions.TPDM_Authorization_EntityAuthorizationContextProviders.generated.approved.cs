
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.TPDM;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.ApplicationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.ApplicationEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CandidateAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CandidateRelationshipToStaffAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CertificationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.CertificationExamAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM;
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
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.QuantitativeMeasureScoreAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RecruitmentEventAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RecruitmentEventAttendanceAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricDimensionAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.StaffEducatorPreparationProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.SurveySectionAggregateResponseAggregate.TPDM;
#endregion

namespace EdFi.Ods.Security.Authorization.ContextDataProviders.TPDM
{

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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.Candidate table of the Candidate aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICandidate, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICandidate resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidate' resource for obtaining authorization context data cannot be null.");

            var entity = resource as Candidate;

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
            return GetContextData((Candidate) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CandidateEducatorPreparationProgramAssociation table of the CandidateEducatorPreparationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateEducatorPreparationProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICandidateEducatorPreparationProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICandidateEducatorPreparationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidateEducatorPreparationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CandidateEducatorPreparationProgramAssociation;

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
            return GetContextData((CandidateEducatorPreparationProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.CandidateRelationshipToStaffAssociation table of the CandidateRelationshipToStaffAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CandidateRelationshipToStaffAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<ICandidateRelationshipToStaffAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(ICandidateRelationshipToStaffAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'candidateRelationshipToStaffAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as CandidateRelationshipToStaffAssociation;

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
            return GetContextData((CandidateRelationshipToStaffAssociation) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.EducatorPreparationProgram table of the EducatorPreparationProgram aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EducatorPreparationProgramRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IEducatorPreparationProgram, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IEducatorPreparationProgram resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'educatorPreparationProgram' resource for obtaining authorization context data cannot be null.");

            var entity = resource as EducatorPreparationProgram;

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
            return GetContextData((EducatorPreparationProgram) resource);
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
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // SchoolId = entity.SchoolId, // Not part of primary key
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
                    // "EducationOrganizationId",
                    // "SchoolId",
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RecruitmentEvent table of the RecruitmentEvent aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRecruitmentEvent, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRecruitmentEvent resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'recruitmentEvent' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RecruitmentEvent;

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
            return GetContextData((RecruitmentEvent) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.RecruitmentEventAttendance table of the RecruitmentEventAttendance aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RecruitmentEventAttendanceRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IRecruitmentEventAttendance, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IRecruitmentEventAttendance resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'recruitmentEventAttendance' resource for obtaining authorization context data cannot be null.");

            var entity = resource as RecruitmentEventAttendance;

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
            return GetContextData((RecruitmentEventAttendance) resource);
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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.StaffEducatorPreparationProgramAssociation table of the StaffEducatorPreparationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StaffEducatorPreparationProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStaffEducatorPreparationProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStaffEducatorPreparationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'staffEducatorPreparationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StaffEducatorPreparationProgramAssociation;

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
            return GetContextData((StaffEducatorPreparationProgramAssociation) resource);
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

}
