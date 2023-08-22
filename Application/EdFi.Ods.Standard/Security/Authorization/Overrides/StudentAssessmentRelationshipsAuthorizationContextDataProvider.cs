using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.Ods.Standard.Security.Authorization.Overrides
{
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
            contextData.SchoolId = entity.ReportedSchoolId; // Role name applied and not part of primary key
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
                    "ReportedSchoolId",
                    "StudentUSI",
                 };

            return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessment)resource);
        }
    }


}
