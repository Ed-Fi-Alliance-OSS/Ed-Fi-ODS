// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    public static class DomainModelExtensions
    {
        public static BidirectionalGraph<Entity, AssociationEdge> ToEntityGraph(this DomainModel domainModel)
        {
            var graph = new BidirectionalGraph<Entity, AssociationEdge>();

            graph.AddVertexRange(domainModel.EntityByFullName.Values);

            graph.AddEdgeRange(
                domainModel
                   .AssociationViewsByEntityFullName.Values
                   .SelectMany(x => x.Select(y => y.Association))
                   .Distinct(ModelComparers.Association)
                   .Select(y => new AssociationEdge(y, domainModel)));

            return graph;
        }

        public static BidirectionalGraph<Entity, AssociationEdge> ToAggregateGraph(this DomainModel domainModel)
        {
            var graph = new BidirectionalGraph<Entity, AssociationEdge>();

            graph.AddVertexRange(domainModel.EntityByFullName.Values);

            // Get all the one to one/many outbound associations
            var associations = domainModel
                              .AssociationViewsByEntityFullName.Values
                              .SelectMany(
                                   x => x.Select(
                                       y => new
                                            {
                                                Association = y.Association, AssociationView = y
                                            }))
                              .Where(
                                   x =>

                                       // Include one-to-one and one-to-many relationships
                                       x.AssociationView.AssociationType == AssociationViewType.OneToMany
                                       || x.AssociationView.AssociationType == AssociationViewType.OneToOneOutgoing

                                       // Inheritance relationships from concrete base types
                                       || x.AssociationView.AssociationType == AssociationViewType.ToDerived)
                              .ToList();

            // Find the outbound associations that are spanning aggregates
            var aggregateOutboundAssociations = associations
                                               .Where(
                                                    a => a.AssociationView.ThisEntity.Aggregate != a.AssociationView.OtherEntity.Aggregate
                                                         || a.Association.IsSelfReferencing)
                                               .ToList();

            // For outbound edges spanning aggregates, move the target to the aggregate root.
            // isIdentifying and isRequired are not retained.
            // with the changes to the construction of the association we need to create a definition first, then we can create an association.
            var outboundAssociationsRelocatedToAggregateRoot =
                aggregateOutboundAssociations.Select(
                                                  a => new AssociationDefinition(
                                                      a.Association.FullName,
                                                      a.Association.Cardinality,
                                                      a.AssociationView.ThisEntity.FullName,
                                                      new EntityPropertyDefinition[0],
                                                      a.AssociationView.OtherEntity.Aggregate.FullName,
                                                      new EntityPropertyDefinition[0],
                                                      isIdentifying: a.Association.IsIdentifying,
                                                      isRequired: a.AssociationView.Inverse.IsSoftDependency))
                                             .Select(definition => new Association(domainModel, definition));

            // Add the edges for entities within an aggregate, and inter-aggregate dependencies as associations from the aggregate roots
            graph.AddEdgeRange(
                associations
                   .Select(x => x.Association)
                   .Except(aggregateOutboundAssociations.Select(x => x.Association), ModelComparers.Association)
                   .Concat(outboundAssociationsRelocatedToAggregateRoot)
                   .Select(a => new AssociationEdge(a, domainModel)));

            return graph;
        }
    }
}
