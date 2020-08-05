// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Caching
{
    /// <summary>
    /// Defines a method for obtaining all the education organizations identifiers 
    /// associated with a specific education organization, by identifier.
    /// </summary>
    public interface IEducationOrganizationCache
    {
        /// <summary>
        /// Finds the <see cref="EdFi.Ods.Api.Caching.EducationOrganizationIdentifiers"/> for the specified <paramref name="educationOrganizationId"/>, or <b>null</b>.
        /// </summary>
        /// <param name="educationOrganizationId">The generic Education Organization identifier for which to search.</param>
        /// <returns>The matching <see cref="EdFi.Ods.Api.Caching.EducationOrganizationIdentifiers"/>; otherwise <b>null</b>.</returns>
        EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(int educationOrganizationId);

        // TODO: GKM - Rather than return null, convert to use Try semantics?
        // TODO: GKM - For EdOrg extensibility, we will want to make this interface generic, like the services on the dashboards.
    }
}
