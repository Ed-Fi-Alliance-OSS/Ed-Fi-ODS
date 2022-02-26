// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using QuickGraph;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class EducationOrganizationIdNamesProvider : IEducationOrganizationIdNamesProvider
    {
        private readonly Lazy<BidirectionalGraph<string, Edge<string>>> _edOrgIdGraph;
        private readonly Lazy<string[]> _concreteEducationOrganizationIdNames;
        private Lazy<HashSet<(string, string)>> _accessibleSegments;

        public EducationOrganizationIdNamesProvider(IDomainModelProvider domainModelProvider)
        {
            _edOrgIdGraph = new Lazy<BidirectionalGraph<string, Edge<string>>>(
                () =>
                {
                    // Get the EducationOrganization base entity
                    var edOrgEntity = domainModelProvider.GetDomainModel().EducationOrganizationBaseEntity();

                    // Process all derived entities for their concrete primary key names
                    var directedGraph = new BidirectionalGraph<string, Edge<string>>();

                    var derivedEntities = edOrgEntity.DerivedEntities;

                    directedGraph.AddVertexRange(derivedEntities.Select(e => e.Identifier.Properties.Single().PropertyName));

                    directedGraph.AddEdgeRange(
                        derivedEntities.SelectMany(
                            entity =>
                            {
                                string currentEntityPropertyName = entity.Identifier.Properties.Single().PropertyName;

                                // Identify parent key(s) for the EdOrg hierarchy 
                                var parentEdOrgAssociations = entity.Properties.SelectMany(
                                    p => p.IncomingAssociations.Where(
                                        a => a.AssociationType == AssociationViewType.ManyToOne
                                            && (a.OtherEntity.IsEducationOrganizationBaseEntity()
                                                || a.OtherEntity.IsEducationOrganizationDerivedEntity())
                                            && !a.IsSelfReferencing));

                                return parentEdOrgAssociations.SelectMany(
                                    a => a.OtherEntity.IsEducationOrganizationBaseEntity()
                                        // For abstract EducationOrganizationId references, add edges for all permutations of other *concrete* EdOrgIds to the current entity property
                                        ? directedGraph.Vertices.Where(v => v != currentEntityPropertyName).Select(v => new Edge<string>(v, currentEntityPropertyName))
                                        // For concrete EdOrg associations, just add the single edge
                                        : new[] { new Edge<string>(a.OtherProperties.Single().PropertyName, currentEntityPropertyName)});
                            }));

                    return directedGraph;
                });

            _accessibleSegments = new Lazy<HashSet<(string, string)>>(
                () =>
                {
                    var accessibleSegments = new HashSet<(string, string)>();

                    var allSegments = _edOrgIdGraph.Value.Vertices
                        .SelectMany(v => GetAccessibleVertices(v).Select(av => (v, av)));

                    foreach (var segment in allSegments)
                    {
                        accessibleSegments.Add(segment);
                    }

                    return accessibleSegments;
                    
                    IEnumerable<string> GetAccessibleVertices(string vertex)
                    {
                        foreach (var outEdge in _edOrgIdGraph.Value.OutEdges(vertex))
                        {
                            // Return the direct edges
                            yield return outEdge.Target;

                            // Recursively find and return all reachable vertices
                            foreach (string accessibleVertex in GetAccessibleVertices(outEdge.Target))
                            {
                                yield return accessibleVertex;
                            }
                        }
                    }

                });

            _concreteEducationOrganizationIdNames = new Lazy<string[]>(() => _edOrgIdGraph.Value.Vertices.ToArray());
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.GetAllNames" />
        public string[] GetAllNames()
        {
            return new[] { "EducationOrganizationId" }.Concat(_concreteEducationOrganizationIdNames.Value).ToArray();
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.GetConcreteNames" />
        public string[] GetConcreteNames()
        {
            return _concreteEducationOrganizationIdNames.Value;
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.IsEducationOrganizationIdAccessible" />
        public bool IsEducationOrganizationIdAccessible(
            string sourceEducationOrganizationIdPropertyName,
            string targetEducationOrganizationId)
        {
            if (sourceEducationOrganizationIdPropertyName == targetEducationOrganizationId)
            {
                return true;
            }
            
            return _accessibleSegments.Value.Contains((sourceEducationOrganizationIdPropertyName, targetEducationOrganizationId));
        }
    }
}
