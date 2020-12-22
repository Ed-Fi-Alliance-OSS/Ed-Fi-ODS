// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    /// <summary>
    /// Contains the details necessary for performing query filtering for relationship-based authorization.
    /// </summary>
    public class RelationshipBasedAuthorizationFilterDetails
    {
        /// <summary>
        /// Gets or sets the <see cref="FullName" /> of the education organization associated with the API client's EducationOrganizationIds for this filter.
        /// </summary>
        public FullName ClaimEducationOrganizationEntityName { get; set; }
        
        /// <summary>
        /// Gets or sets the EducationOrganizationIds of the eduction organization type specified by <see cref="ClaimEducationOrganizationEntityName"/>.
        /// </summary>
        public int[] ClaimEducationOrganizationIds { get; set; }

        /// <summary>
        /// Gets or sets the name of the authorization view column associated with the API client's EducationOrganizationId-based claim.
        /// </summary>
        public string ClaimViewColumnName { get; set; }

        /// <summary>
        /// Gets or sets the name of the column in the aggregate root table that is relevant to the authorization context for the current request.
        /// </summary>
        public string TargetEntityColumnName { get; set; }

        /// <summary>
        /// Gets or sets the name of the authorization view column relevant to the authorization context for the current API request.
        /// </summary>
        public string TargetViewColumnName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EntityProperty.DefiningProperty" /> of the property that is relevant to the authorization context for the current API request. 
        /// </summary>
        public EntityProperty TargetDefiningProperty { get; set; }

        /// <summary>
        /// Gets or sets the name of the view to be used for performing relationship-based authorization filtering.
        /// </summary>
        public string ViewName { get; set; }
    }
}
