// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Security.Authorization {
    public interface IEducationOrganizationIdentifiersValueMapper
    {
        /// <summary>
        /// Gets the identifier values for a given state organization id value.
        /// </summary>
        /// <param name="stateOrganizationId">The stateOrganizationId of the education organization identifiers being requested.</param>
        /// <returns>The <see cref="EducationOrganizationIdentifiers"/> containing the requested stateOrganizationId,
        ///  and associated values; otherwise a <see cref="EducationOrganizationIdentifiers"/> instance
        /// containing default values.</returns>
        EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(string stateOrganizationId);

        /// <summary>
        /// Gets the identifier values for a given state organization id value.
        /// </summary>
        /// <param name="educationOrganizationId">The educationOrganizationId for the education organization identifiers being requested.</param>
        /// <returns>The <see cref="EducationOrganizationIdentifiers"/> containing the requested educationOrganizationId,
        ///  and associated values; otherwise a <see cref="EducationOrganizationIdentifiers"/> instance
        /// containing default values.</returns>
        EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(int educationOrganizationId);
    }
}