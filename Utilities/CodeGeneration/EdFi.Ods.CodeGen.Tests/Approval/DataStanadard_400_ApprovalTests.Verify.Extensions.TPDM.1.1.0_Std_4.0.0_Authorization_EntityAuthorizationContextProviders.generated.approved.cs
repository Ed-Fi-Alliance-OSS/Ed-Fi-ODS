
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.TPDM;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationElementAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationElementRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.EvaluationRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.FinancialAidAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM;
using EdFi.Ods.Entities.NHibernate.RubricDimensionAggregate.TPDM;
#endregion

namespace EdFi.Ods.Api.Security.Authorization.ContextDataProviders.TPDM
{

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
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the tpdm.FinancialAid table of the FinancialAid aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FinancialAidRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IFinancialAid, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IFinancialAid resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'financialAid' resource for obtaining authorization context data cannot be null.");

            var entity = resource as FinancialAid;

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
            return GetContextData((FinancialAid) resource);
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

}
