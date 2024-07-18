// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
    public class StudentAssessmentRelationshipsAuthorizationContextDataProvider : IRelationshipsAuthorizationContextDataProvider<IStudentAssessment>
    {
        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(IStudentAssessment resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource), "The 'studentAssessment' resource for obtaining authorization context data cannot be null.");
            }

            var entity = resource as StudentAssessment;

            var contextData = new RelationshipsAuthorizationContextData 
            { 
                SchoolId = entity.ReportedSchoolId, // Role name applied and not part of primary key
                StudentUSI = entity.StudentUSI == default ? null : entity.StudentUSI // Primary key property, USI
            };

            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
            var properties = new[]
                 {
                    "ReportedSchoolId",
                    "StudentUSI",
                 };

            return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return GetContextData((StudentAssessment)resource);
        }
    }
}
