// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using QuickGraph;
using System;
using System.Linq;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Provides a method for obtaining a directed graph derived from the semantic API model containing the property names of
    /// the concrete education organization ids and the hierarchical relationships between them.
    /// </summary>
    public class EducationOrganizationIdHierarchyProvider : IEducationOrganizationIdHierarchyProvider
    {
        private readonly Lazy<AdjacencyGraph<string, Edge<string>>> _educationOrganizationHierarchy;
        
        public EducationOrganizationIdHierarchyProvider(IDomainModelProvider domainModelProvider)
        {
            _educationOrganizationHierarchy = new Lazy<AdjacencyGraph<string, Edge<string>>>(
                () => BuildEducationOrganizationGraph(domainModelProvider));
        }

        /// <summary>
        /// Builds a directed graph derived from the semantic API model containing the property names of the concrete education organization
        /// ids and the hierarchical relationships between them.
        /// </summary>
        private AdjacencyGraph<string, Edge<string>> BuildEducationOrganizationGraph(IDomainModelProvider domainModelProvider)
        {
            var domainModel = domainModelProvider.GetDomainModel();

            var concreteEdOrgEntities = domainModel.Entities
                .Where(entity => entity.IsEducationOrganizationDerivedEntity())
                .ToArray();

            var graph = new AdjacencyGraph<string, Edge<string>>();

            var educationOrganizationHierarchyTuples = concreteEdOrgEntities
                .SelectMany(entity => entity.Properties
                    // Project properties with their parent Education Organization association (if any)
                    .Select(p => new
                    {
                        Property = p,
                        ParentEdOrgAssociation = p.IncomingAssociations.SingleOrDefault(a =>
                            a.AssociationType == AssociationViewType.ManyToOne
                            && !a.IsSelfReferencing
                            && (a.OtherEntity.IsEducationOrganizationBaseEntity()
                                || a.OtherEntity.IsEducationOrganizationDerivedEntity()))
                    })
                    // Filter out properties that are not references to a parent Education Organizations
                    .Where(x => x.ParentEdOrgAssociation != null)
                    // Project a tuple containing the property names as endpoints, noting whether the parent EdOrg is abstract
                    .Select(x => new
                    {
                        SourcePropertyName = x.ParentEdOrgAssociation.PropertyMappings.Single().OtherProperty.PropertyName,
                        TargetPropertyName = entity.Identifier.Properties.Single().PropertyName,
                        SourceIsAbstract = x.ParentEdOrgAssociation.OtherEntity.IsAbstract
                    }))
                // Expand projection of all tuples with an abstract source endpoint to include all known concrete EdOrg sub-types
                .SelectMany(tuple => {
                    if (tuple.SourceIsAbstract)
                    {
                        return concreteEdOrgEntities
                            // Project the final tuple for use in building the graph
                            .Select(e => new
                            {
                                SourcePropertyName = e.Identifier.Properties.Single().PropertyName, 
                                TargetPropertyName = tuple.TargetPropertyName
                            })
                            // Filter out self-referencing tuple entries
                            .Where(x => x.SourcePropertyName != x.TargetPropertyName);
                    }

                    return (new[] { tuple })
                        // Project the final tuple
                        .Select(x => new
                        {
                            SourcePropertyName = x.SourcePropertyName, 
                            TargetPropertyName = x.TargetPropertyName
                        });
                })
                .ToArray();

            // Create the graph from the tuples derived from the API model
            foreach (var edgeTuple in educationOrganizationHierarchyTuples)
            {
                graph.AddVerticesAndEdge(new Edge<string>(edgeTuple.SourcePropertyName, edgeTuple.TargetPropertyName));
            }
            
            return graph;
        }

        /// <summary>
        /// Gets a directed graph derived from the semantic API model containing the property names of the concrete education organization
        /// ids and the hierarchical relationships between them.
        /// </summary>
        /// <returns>The accessible paths between concrete education organizations represented as a directed graph.</returns>
        public virtual AdjacencyGraph<string, Edge<string>> GetEducationOrganizationIdHierarchy()
        {
            return _educationOrganizationHierarchy.Value;
        }
    }
}
