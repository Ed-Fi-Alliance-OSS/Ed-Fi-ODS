// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <summary>
    /// Defines a method for obtaining the details for applying a filter using the name of the filter.
    /// </summary>
    public interface IAuthorizationFilterDefinitionProvider
    {
        /// <summary>
        /// Gets the details for applying the specified filter in various contexts.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <returns>The details for applying the filter in various contexts.</returns>
        AuthorizationFilterDefinition GetFilterDefinition(string filterName);
        
        /// <summary>
        /// Attempts to get the filter definition containing information for applying the specified filter in various contexts.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="authorizationFilterDefinition">The filter definition.</param>
        /// <returns><b>true</b> if the filter was found; otherwise <b>false</b>.</returns>
        bool TryGetAuthorizationFilterDefinition(string filterName, out AuthorizationFilterDefinition authorizationFilterDefinition);
    }
}
