// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims
{
    public interface IEducationOrganizationClaimsProvider
    {
        IList<EducationOrganizationClaims> GetEducationOrganizationClaims();
    }

    /// <summary>
    /// Contains EducationOrganizationIds derived from claims for a particular concrete type of Education Organization.
    /// </summary>
    public class EducationOrganizationClaims
    {
        public EducationOrganizationClaims(FullName entityFullName, int[] educationOrganizationIds)
        {
            EntityFullName = entityFullName;
            EducationOrganizationIds = educationOrganizationIds;
        }
        
        /// <summary>
        /// Gets or sets the <see cref="FullName" /> of the concrete Education Organization <see cref="Entity" />. 
        /// </summary>
        public FullName EntityFullName { get; }

        /// <summary>
        /// Gets or sets the EducationOrganizationIds associated with the concrete Education Organization type specified by the <see cref="EntityFullName" /> property.
        /// </summary>
        public int[] EducationOrganizationIds { get; }
    }
}
