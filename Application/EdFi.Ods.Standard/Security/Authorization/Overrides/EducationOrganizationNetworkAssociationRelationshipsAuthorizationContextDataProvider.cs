// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi;

namespace EdFi.Ods.Standard.Security.Authorization.Overrides
{
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
            // contextData.EducationOrganizationNetworkId = entity.EducationOrganizationNetworkId == default(long) ? null as long? : entity.EducationOrganizationNetworkId; // Primary key property, Only Education Organization Id present
            contextData.EducationOrganizationId = entity.MemberEducationOrganizationId; // Primary key property, Role name applied
            return contextData;
        }

        /// <summary>
        ///  Creates and returns a signature key based on the resource, which can then be used to get and instance of IEdFiSignatureAuthorizationProvider
        /// </summary>
        public string[] GetAuthorizationContextPropertyNames()
        {
            var properties = new string[]
                 {
                    // "EducationOrganizationNetworkId",
                    "MemberEducationOrganizationId",
                 };

            return properties;
        }

        /// <summary>
        /// Creates and returns an <see cref="RelationshipsAuthorizationContextData"/> instance based on the supplied resource.
        /// </summary>
        public TContextData GetContextData(object resource)
        {
            return GetContextData((EducationOrganizationNetworkAssociation)resource);
        }
    }
}
