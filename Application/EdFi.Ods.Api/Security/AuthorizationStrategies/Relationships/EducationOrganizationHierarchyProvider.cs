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
    /// Provides the core Ed-Fi education organization type hierarchy, with methods for expanding 
    /// on the Ed-Fi core education types.
    /// </summary>
    public class EducationOrganizationHierarchyProvider : IEducationOrganizationHierarchyProvider
    {
        private IDomainModelProvider _domainModelProvider { get; set; }

        private readonly Lazy<AdjacencyGraph<string, Edge<string>>> _educationOrganizationHierarchy;
        public EducationOrganizationHierarchyProvider(IDomainModelProvider domainModelProvider)
        {
            _domainModelProvider = domainModelProvider;
            _educationOrganizationHierarchy = new Lazy<AdjacencyGraph<string, Edge<string>>>(() => AddRelatedOrganizations());
        }

        /// <summary>
        /// Adds a relationship between two types of education organizations to the hierarchy.
        /// </summary>
        private AdjacencyGraph<string, Edge<string>> AddRelatedOrganizations()
        {
            var domainModel = _domainModelProvider.GetDomainModel();

            var concreteEdOrgEntities = domainModel.Entities.Where(entity => entity.IsEducationOrganizationDerivedEntity());

            var graph = new AdjacencyGraph<string, Edge<string>>();

            var EducationOrganizationHierarchyProvider = concreteEdOrgEntities
                .SelectMany(entity => entity.Properties
                        .Select(p => new
                        {
                            Property = p,
                            ParentEgOrgAssociation = p.IncomingAssociations.SingleOrDefault(a =>
                                a.AssociationType == AssociationViewType.ManyToOne
                                && !a.IsSelfReferencing
                                && (a.OtherEntity.IsEducationOrganizationBaseEntity()
                                    || a.OtherEntity.IsEducationOrganizationDerivedEntity()))
                        })
                        .Where(x => x.ParentEgOrgAssociation != null)
                        .Select(x => new
                        {
                            SourcePropertyName = x.ParentEgOrgAssociation.PropertyMappings.Single().OtherProperty.PropertyName,
                            TargetPropertyName = entity.Identifier.Properties.Single().PropertyName,
                            SourceIsAbstract = x.ParentEgOrgAssociation.OtherEntity.IsAbstract
                        }))
                .SelectMany(x => {
                    if (x.SourceIsAbstract)
                    {
                        return concreteEdOrgEntities
                            .Select(e => new { SourcePropertyName = e.Identifier.Properties.Single().PropertyName, TargetPropertyName = x.TargetPropertyName })
                            .Where(y => y.SourcePropertyName != y.TargetPropertyName);
                    }
                    else
                    {
                        return (new[] { x }).Select(y => new { SourcePropertyName = y.SourcePropertyName, TargetPropertyName = y.TargetPropertyName });
                    }
                })
                .ToArray();

            foreach (var edge in EducationOrganizationHierarchyProvider)
            {
                graph.AddVerticesAndEdge(new Edge<string>(edge.SourcePropertyName, edge.TargetPropertyName));
            }
            return graph;
        }

        /// <summary>
        /// Gets the Education Organization type hierarchy represented as a graph.
        /// </summary>
        /// <returns>The hierarchy represented as a graph.</returns>
        public virtual AdjacencyGraph<string, Edge<string>> GetEducationOrganizationHierarchy()
        {
            return _educationOrganizationHierarchy.Value;
        }
    }
}
