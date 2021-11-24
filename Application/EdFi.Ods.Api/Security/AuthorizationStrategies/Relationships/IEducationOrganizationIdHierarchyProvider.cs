// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using QuickGraph;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Gets a directed graph derived from the semantic API model containing the property names of the concrete education organization
    /// ids and the hierarchical relationships between them.
    /// </summary>
    /// <returns>The accessible paths between concrete education organizations represented as a directed graph.</returns>
    public interface IEducationOrganizationIdHierarchyProvider
    {
        /// <summary>
        /// Gets a graph derived from the semantic API model containing the accessible paths between education organization ids 
        /// based on the education organization relational hierarchy.
        /// </summary>
        /// <returns>The accessible paths between concrete education organizations represented as a graph.</returns>
        AdjacencyGraph<string, Edge<string>> GetEducationOrganizationIdHierarchy();
    }
}
