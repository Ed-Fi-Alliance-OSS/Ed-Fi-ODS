// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using QuickGraph;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Provides the core Ed-Fi education organization type hierarchy, with methods for expanding 
    /// on the Ed-Fi core education types.
    /// </summary>
    public class EducationOrganizationHierarchyProvider : IEducationOrganizationHierarchyProvider
    {
        // Constants matching the core Ed-Fi types of education organizations
        protected const string EducationServiceCenter = "EducationServiceCenter";
        protected const string LocalEducationAgency = "LocalEducationAgency";
        protected const string School = "School";
        protected const string StateEducationAgency = "StateEducationAgency";

        private readonly AdjacencyGraph<string, Edge<string>> _graph = new AdjacencyGraph<string, Edge<string>>();

        public EducationOrganizationHierarchyProvider()
        {
            // Define the referential structure of the core ODS EducationOrganization-related tables
            AddRelatedOrganizations(StateEducationAgency, EducationServiceCenter);
            AddRelatedOrganizations(StateEducationAgency, LocalEducationAgency);
            AddRelatedOrganizations(EducationServiceCenter, LocalEducationAgency);
            AddRelatedOrganizations(LocalEducationAgency, School);
        }

        /// <summary>
        /// Gets the Education Organization type hierarchy represented as a graph.
        /// </summary>
        /// <returns>The hierarchy represented as a graph.</returns>
        public virtual AdjacencyGraph<string, Edge<string>> GetEducationOrganizationHierarchy()
        {
            return _graph;
        }

        /// <summary>
        /// Adds a relationship between two types of education organizations to the hierarchy.
        /// </summary>
        /// <param name="parentType">The type of the parent education organization (e.g. LocalEducationAgency).</param>
        /// <param name="childType">The type of the child education organization (e.g. School).</param>
        protected void AddRelatedOrganizations(string parentType, string childType)
        {
            _graph.AddVerticesAndEdge(
                new Edge<string>(
                    parentType,
                    childType));
        }
    }
}
