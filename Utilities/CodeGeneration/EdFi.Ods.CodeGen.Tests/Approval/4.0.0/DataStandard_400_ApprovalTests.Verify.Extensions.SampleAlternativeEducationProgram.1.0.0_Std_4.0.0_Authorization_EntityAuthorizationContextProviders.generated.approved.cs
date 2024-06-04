
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

#region Aggregate Entity Includes
using EdFi.Ods.Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram;
#endregion

namespace EdFi.Ods.Api.Security.Authorization.ContextDataProviders.SampleAlternativeEducationProgram
{

    /// <summary>
    /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance for making authorization decisions for access to the samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation table of the StudentAlternativeEducationProgramAssociation aggregate in the Ods Database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationRelationshipsAuthorizationContextDataProvider<TContextData> : IRelationshipsAuthorizationContextDataProvider<IStudentAlternativeEducationProgramAssociation, TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Creates and returns an <see cref="TContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(IStudentAlternativeEducationProgramAssociation resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource", "The 'studentAlternativeEducationProgramAssociation' resource for obtaining authorization context data cannot be null.");

            var entity = resource as StudentAlternativeEducationProgramAssociation;

            dynamic contextData = new TContextData();
            contextData.EducationOrganizationId = entity.EducationOrganizationId == default(int) ? null as int? : entity.EducationOrganizationId; // Primary key property, Only Education Organization Id present
            // ProgramEducationOrganizationId = entity.ProgramEducationOrganizationId, // Primary key property, Role name applied
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
            return GetContextData((StudentAlternativeEducationProgramAssociation) resource);
        }
    }

}
