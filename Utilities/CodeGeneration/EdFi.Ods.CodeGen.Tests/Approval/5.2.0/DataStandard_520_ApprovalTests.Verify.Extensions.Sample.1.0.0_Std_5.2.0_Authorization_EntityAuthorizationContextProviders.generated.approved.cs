
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.Sample;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.BusRouteAggregate.Sample;
using EdFi.Ods.Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample;
using EdFi.Ods.Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample;
#endregion

namespace EdFi.Ods.Api.Security.Authorization.ContextDataProviders.Sample
{

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the sample.BusRoute table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BusRouteRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IBusRoute>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IBusRoute resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'busRoute' resource for obtaining authorization context data cannot be null.");

            var entity = resource as BusRoute;

            dynamic contextData = new RelationshipsAuthorizationContextData();
            // EducationOrganizationId = entity.EducationOrganizationId, // Not part of primary key
            // StaffUSI = entity.StaffUSI, // Not part of primary key
            return (RelationshipsAuthorizationContextData) contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    // "EducationOrganizationId",
                    // "StaffUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((BusRoute) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the sample.StudentArtProgramAssociation table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentArtProgramAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentArtProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentArtProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentArtProgramAssociation;

            dynamic contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return (RelationshipsAuthorizationContextData) contextData;
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
            return GetContextData((StudentArtProgramAssociation) resource);
        }
    }

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the sample.StudentGraduationPlanAssociation table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentGraduationPlanAssociation>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentGraduationPlanAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentGraduationPlanAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentGraduationPlanAssociation;

            dynamic contextData = new RelationshipsAuthorizationContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(long) ? null as long? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // StaffUSI = entity.StaffUSI, // Not part of primary key
            contextData.StudentUSI = entity.StudentUSI == default(int) ? null as int? : entity.StudentUSI; // Primary key property, USI
            return (RelationshipsAuthorizationContextData) contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
           var properties = new string[]
                {
                    "EducationOrganizationId",
                    // "StaffUSI",
                    "StudentUSI",
                };

           return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentGraduationPlanAssociation) resource);
        }
    }

}
