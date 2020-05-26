// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Utils.Extensions;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    /// <summary>
    /// Creates a graph containing entities and their dependencies at an operation level.
    /// </summary>
    public class EntityWithDataOperationGraphFactory : IEntityWithDataOperationGraphFactory
    {
        private readonly Lazy<BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>> _bidirectionalGraph;
        private readonly Lazy<BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>> _bidirectionalGraphWithTransformations;

        public EntityWithDataOperationGraphFactory(
            IDomainModelProvider domainModelProvider,
            IEntityWithDataOperationTransformer[] entityWithDataOperationTransformers)
        {
            if (domainModelProvider == null)
            {
                throw new ArgumentNullException(nameof(domainModelProvider));
            }

            _bidirectionalGraph = new Lazy<BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>>(
                () => CreateGraph(domainModelProvider, entityWithDataOperationTransformers, includeTransformations: false));

            _bidirectionalGraphWithTransformations = new Lazy<BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>>(
                () => CreateGraph(domainModelProvider, entityWithDataOperationTransformers, includeTransformations: true));
        }

        /// <summary>
        /// Creates a new graph containing the Ed-Fi model's entities and their dependencies at an
        /// operation level, optionally performing the predefined graph transformations.
        /// </summary>
        /// <param name="includeTransformations">Indicates whether to perform predefined graph transformations
        /// on the graph (e.g. based on known authorization constraints -- first create students, then create student
        /// school associations, then update students).
        /// </param>
        /// <returns>A new graph instance.</returns>
        public BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> CreateGraph(bool includeTransformations)
        {
            return includeTransformations
                ? _bidirectionalGraphWithTransformations.Value.Clone()
                : _bidirectionalGraph.Value.Clone();
        }

        private BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> CreateGraph(
            IDomainModelProvider domainModelProvider,
            IEntityWithDataOperationTransformer[] entityWithDataOperationTransformers,
            bool includeTransformations)
        {
            var dataOperationGraph = BuildDataOperationGraph(domainModelProvider.GetDomainModel().ToAggregateGraph());

            //Validate no circular dependencies
            dataOperationGraph.ValidateGraph();

            if (includeTransformations)
            {
                // Invoke all the graph transformers
                entityWithDataOperationTransformers.ForEach(x => x.Transform(dataOperationGraph));

                //Validate no circular dependencies
                dataOperationGraph.ValidateGraph();
            }

            return dataOperationGraph;
        }

        private BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> BuildDataOperationGraph(
            BidirectionalGraph<Entity, AssociationEdge> aggregateGraph)
        {
            var executionGraph = new BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>();

            var aggregateRootVertices = aggregateGraph
                                       .Vertices
                                       .Where(e => e.IsAggregateRoot)
                                       .Select(
                                            r =>
                                                new DataOperationGraphByAggregateRoot
                                                {
                                                    AggregateRoot = r, DataOperationGraph = BuildAggregateDataOperationSubgraph(aggregateGraph, r)
                                                })
                                       .ToList();

            // Add the Create/Update vertices (for regular entities, and non-abstract base entities), without connecting edges (Updates out-of-the-box can execute without constraint)
            executionGraph.AddVertexRange(
                aggregateRootVertices
                   .Where(x => !x.AggregateRoot.IsAbstract)
                   .SelectMany(
                        x => new[]
                             {
                                 new EntityWithDataOperation(x.AggregateRoot, DataOperation.Create, x.DataOperationGraph),
                                 new EntityWithDataOperation(x.AggregateRoot, DataOperation.Update, x.DataOperationGraph)
                             }));

            // Add the Create/Update vertices (for base entities with concrete context), without connecting edges (Updates out-of-the-box can execute without constraint)
            executionGraph.AddVertexRange(
                aggregateRootVertices
                   .Where(x => x.AggregateRoot.IsBase)
                   .SelectMany(
                        x => x.AggregateRoot.DerivedEntities.SelectMany(
                            dx =>
                            {
                                var subGraph = BuildAggregateDataOperationSubgraph(aggregateGraph, x.AggregateRoot, dx);

                                return new[]
                                       {
                                           new EntityWithDataOperation(x.AggregateRoot, DataOperation.Create, dx, subGraph),
                                           new EntityWithDataOperation(x.AggregateRoot, DataOperation.Update, dx, subGraph)
                                       };
                            })));

            // From the original graph, get all the edges between aggregate roots (excluding those that are self-recursive or involve EdFi Types)
            var allInterAggregateEdges =
                aggregateGraph.Edges

                               // Do not use edges that are self-recursive (this information is available on the Entity itself)
                              .Where(e => !ModelComparers.Entity.Equals(e.Source, e.Target))

                               // Only use edges that are between aggregate roots
                              .Where(e => e.Source.IsAggregateRoot && e.Target.IsAggregateRoot)
                              .ToList();

            // Add the edges for the concrete Create vertices (excludes abstract base types)
            executionGraph.AddVerticesAndEdgeRange(
                allInterAggregateEdges

                    // Only deal with non-abstract aggregates
                   .Where(associationEdge => !associationEdge.Source.IsAbstract && !associationEdge.Target.IsAbstract)

                    // Only deal with non-inheritance relationships
                   .Where(associationEdge => associationEdge.Association.Cardinality != Cardinality.OneToOneInheritance)
                   .Select(
                        associationEdge =>
                            new DataOperationEdge
                            {
                                Source = new EntityWithDataOperation(associationEdge.Source, DataOperation.Create),
                                Target = new EntityWithDataOperation(associationEdge.Target, DataOperation.Create)
                            }));

            //Add the edges to the graph from a concrete vertices to bases with derived context.
            executionGraph.AddVerticesAndEdgeRange(
                allInterAggregateEdges

                    // Only deal with non-abstract aggregate sources and abstract targets.
                   .Where(associationEdge => !associationEdge.Source.IsAbstract && associationEdge.Target.IsBase)

                    // Only deal with non-inheritance relationships
                   .Where(associationEdge => associationEdge.Association.Cardinality != Cardinality.OneToOneInheritance)
                   .SelectMany(
                        associationEdge => associationEdge.Target.DerivedEntities.Select(
                            de => new DataOperationEdge
                                  {
                                      Source = new EntityWithDataOperation(
                                          associationEdge.Source,
                                          DataOperation.Create),
                                      Target = new EntityWithDataOperation(
                                          associationEdge.Target,
                                          DataOperation.Create,
                                          de)
                                  })));

            // Add the edges for the Create vertices with derived entity context, for base types
            executionGraph.AddVerticesAndEdgeRange(
                allInterAggregateEdges

                    // Only deal with inheritance relationships
                   .Where(associationEdge => associationEdge.Association.Cardinality == Cardinality.OneToOneInheritance)
                   .Select(
                        associationEdge =>
                            new DataOperationEdge
                            {
                                Source = new EntityWithDataOperation(associationEdge.Source, DataOperation.Create, associationEdge.Target),
                                Target = new EntityWithDataOperation(associationEdge.Target, DataOperation.Create)
                            }));

            // Make sure we don't execute a dependency of an abstract base entity before the derived entities have been processed
            var relevantEntitiesGroupedByBaseEntity = aggregateGraph
                                                     .Vertices
                                                     .Where(e => e.IsBase && e.IsAggregateRoot)
                                                     .GroupBy(
                                                          e => e,
                                                          e =>
                                                              new
                                                              {
                                                                  BaseEntity = e, e.DerivedEntities,

                                                                  //Get aggregate roots of any dependencies of the abstract aggregate that are not derived, members of its own aggregate, or an abstract base.
                                                                  Children = e.OutgoingAssociations.Where(
                                                                                   a => a.AssociationType != AssociationViewType.ToDerived)
                                                                              .Select(a => a.OtherEntity)
                                                                              .Where(
                                                                                   oe => !e.Aggregate.Members.Contains(oe, ModelComparers.Entity)
                                                                                         && !oe.Aggregate.AggregateRoot.IsAbstract)
                                                                              .Select(oe => oe.Aggregate.AggregateRoot)
                                                                              .ToArray()
                                                              },
                                                          ModelComparers.Entity)
                                                     .ToList();

            foreach (var grouping in relevantEntitiesGroupedByBaseEntity)
            {
                // Add Create edges to ensure that derived classes are created before base class dependencies
                var edges = grouping.SelectMany(
                    g =>
                        from d in g.DerivedEntities
                        from c in g.Children
                        select new DataOperationEdge
                               {
                                   Source = new EntityWithDataOperation(d, DataOperation.Create),
                                   Target = new EntityWithDataOperation(c, DataOperation.Create)
                               });

                executionGraph.AddEdgeRange(edges);
            }

            foreach (var grouping in relevantEntitiesGroupedByBaseEntity)
            {
                // Add Create edges to ensure that dependencies between the concrete derived classes are respected at the base level
                // (i.e. LEA and its EdOrg is fully processed before School and its EdOrg is started)
                var edges = grouping.SelectMany(
                                         g =>

                                             // From the derived entities' children's incoming associations from other entities
                                         {
                                             return g.DerivedEntities.SelectMany(
                                                          x =>
                                                              x.Aggregate.Members.Where(j => !ModelComparers.Entity.Equals(j, x))
                                                               .SelectMany(aaia => aaia.IncomingAssociations)
                                                      )
                                                     .Where(a => a.ThisEntity.Aggregate != a.OtherEntity.Aggregate)
                                                     .Where(
                                                          e => g.DerivedEntities.Contains(e.OtherEntity, ModelComparers.Entity) &&
                                                               !ModelComparers.Entity.Equals(e.ThisEntity, e.OtherEntity))
                                                     .Select(
                                                          e => new DataOperationEdge
                                                               {
                                                                   Source = new EntityWithDataOperation(
                                                                       e.OtherEntity.BaseEntity,
                                                                       DataOperation.Create,
                                                                       e.OtherEntity),
                                                                   Target =
                                                                       new EntityWithDataOperation(
                                                                           e.ThisEntity.Aggregate.AggregateRoot.BaseEntity,
                                                                           DataOperation.Create,
                                                                           e.ThisEntity.Aggregate.AggregateRoot)
                                                               });
                                         })
                                    .Concat(
                                         grouping.SelectMany(
                                             g =>

                                                 // From the derived entities' external children
                                                 from e in g.DerivedEntities.SelectMany(x => x.NonNavigableChildren)

                                                 // Where the other entity is in the same inheritance hierarchy
                                                 where g.DerivedEntities.Contains(e.OtherEntity, ModelComparers.Entity) &&
                                                       !ModelComparers.Entity.Equals(e.ThisEntity, e.OtherEntity)
                                                 select new DataOperationEdge
                                                        {
                                                            Source = new EntityWithDataOperation(e.ThisEntity, DataOperation.Create), Target =
                                                                new EntityWithDataOperation(
                                                                    e.OtherEntity.BaseEntity,
                                                                    DataOperation.Create,
                                                                    e.OtherEntity)
                                                        }))
                                    .ToList();

                executionGraph.AddEdgeRange(edges);
            }

            return executionGraph;
        }

        private BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> BuildAggregateDataOperationSubgraph(
            BidirectionalGraph<Entity, AssociationEdge> aggregateGraph,
            Entity aggregateRootEntity,
            Entity concreteContextualEntity = null)
        {
            if (!aggregateRootEntity.IsAggregateRoot)
            {
                throw new ArgumentException($"Entity '{aggregateRootEntity.FullName}' is not an aggregate root.");
            }

            // Identify the child entities within the aggregate and any entity extensions within it.
            var childEntities = aggregateRootEntity.Aggregate.Members
                                                   .Union(aggregateRootEntity.Extensions)
                                                   .Union(aggregateRootEntity.Aggregate.Members.SelectMany(m => m.Extensions))
                                                   .Except(aggregateRootEntity)
                                                   .ToList();

            // No children?  No graph to process
            if (!childEntities.Any())
            {
                return null;
            }

            // Add the vertices and edges between the members
            var aggregateExecutionGraph = new BidirectionalGraph<EntityWithDataOperation, DataOperationEdge>();

            aggregateExecutionGraph.AddVertexRange(
                childEntities
                   .Select(e => new EntityWithDataOperation(e, DataOperation.None, concreteContextualEntity)));

            aggregateExecutionGraph.AddVerticesAndEdgeRange(
                aggregateGraph
                   .Edges
                   .Where(e => childEntities.Contains(e.Source) && childEntities.Contains(e.Target))
                   .Select(
                        associationEdge =>
                            new DataOperationEdge
                            {
                                Source = new EntityWithDataOperation(associationEdge.Source, DataOperation.None, concreteContextualEntity),
                                Target = new EntityWithDataOperation(associationEdge.Target, DataOperation.None, concreteContextualEntity)
                            }));

            return aggregateExecutionGraph;
        }

        private class DataOperationGraphByAggregateRoot
        {
            public Entity AggregateRoot { get; set; }

            public BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> DataOperationGraph { get; set; }
        }
    }
}
