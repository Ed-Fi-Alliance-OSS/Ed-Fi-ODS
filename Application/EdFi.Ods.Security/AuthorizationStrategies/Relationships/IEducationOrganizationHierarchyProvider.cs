// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using QuickGraph;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Defines a method for obtaining a graph representing the education organization type hierarchy.
    /// </summary>
    public interface IEducationOrganizationHierarchyProvider
    {
        /// <summary>
        /// Gets the Education Organization type hierarchy represented as a graph.
        /// </summary>
        /// <returns>The hierarchy represented as a graph.</returns>
        AdjacencyGraph<string, Edge<string>> GetEducationOrganizationHierarchy();
    }
}
