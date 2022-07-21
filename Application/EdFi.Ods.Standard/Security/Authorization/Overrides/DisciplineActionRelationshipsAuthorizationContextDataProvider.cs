// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.NHibernate.DisciplineActionAggregate.EdFi;

namespace EdFi.Ods.Standard.Security.Authorization.Overrides
{
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
            contextData.SchoolId = entity.ResponsibilitySchoolId; // Role name applied and not part of primary key
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
                   "ResponsibilitySchoolId",
                   "StudentUSI",
                 };

            return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((DisciplineAction)resource);
        }
    }
}