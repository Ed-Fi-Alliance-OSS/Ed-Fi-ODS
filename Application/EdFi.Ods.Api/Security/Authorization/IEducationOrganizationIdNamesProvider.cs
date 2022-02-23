// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Defines a method for obtaining the names of the concrete education organization ids in the current model.
    /// </summary>
    public interface IEducationOrganizationIdNamesProvider
    {
        /// <summary>
        /// Gets the names of the all education organization ids in the current model, including the abstract representation.
        /// </summary>
        /// <returns>An array containing all the education organization id property names.</returns>
        string[] GetAllNames();

        /// <summary>
        /// Gets the names of the <i>concrete</i> education organization ids in the current model.
        /// </summary>
        /// <returns>An array containing the concrete property names.</returns>
        string[] GetConcreteNames();

        /// <summary>
        /// Indicates whether the supplied source and target education organization id property names are accessible through
        /// the Ed-Fi model, and thus valid for authorization purposes.
        /// </summary>
        /// <param name="sourceEducationOrganizationIdPropertyName">The property name of the source education organization id endpoint.</param>
        /// <param name="targetEducationOrganizationId">The property name of the target education organization id endpoint.</param>
        /// <returns><b>true</b> if the target property is accessible from the source; otherwise <b>false</b>.</returns>
        bool IsEducationOrganizationIdAccessible(
            string sourceEducationOrganizationIdPropertyName,
            string targetEducationOrganizationId);
    }
}
