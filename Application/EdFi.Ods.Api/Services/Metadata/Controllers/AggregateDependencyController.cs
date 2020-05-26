// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Specifications;
using QuickGraph;

namespace EdFi.Ods.Api.Services.Metadata.Controllers
{
    public class AggregateDependencyController : ApiController
    {
        private readonly IEntityWithDataOperationGraphFactory _entityWithDataOperationGraphFactory;

        public AggregateDependencyController(IEntityWithDataOperationGraphFactory entityWithDataOperationGraphFactory)
        {
            if (entityWithDataOperationGraphFactory == null)
            {
                throw new ArgumentNullException(nameof(entityWithDataOperationGraphFactory));
            }

            _entityWithDataOperationGraphFactory = entityWithDataOperationGraphFactory;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            if (Request.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue(CustomMediaContentTypes.GraphML)))
            {
                return Ok(GraphML.Create(_entityWithDataOperationGraphFactory.CreateGraph(includeTransformations: false)));
            }

            var aggregateLoadOrders = SortEntities(_entityWithDataOperationGraphFactory.CreateGraph(includeTransformations: true))
                                     .Where(
                                          x => EntitySpecification.HasResourceRepresentation(x.Item1.Entity))
                                     .ToList();

            return Ok(aggregateLoadOrders.Select(x => AggregateLoadOrder.Create(x.Item1, x.Item2)));
        }

        private IEnumerable<Tuple<EntityWithDataOperation, int>> SortEntities(
            BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> executionGraph)
        {
            var visited = new ConcurrentDictionary<EntityWithDataOperation, bool>(executionGraph.Vertices.ToDictionary(k => k, v => false));
            var resolved = new List<Tuple<EntityWithDataOperation, int>>();

            int groupSet = 0;

            while (visited.Values.Any(x => x == false))
            {
                var executableItemGroupings = GetUnvisitedVertices(executionGraph, visited);

                // this embedded convention allows for grouping of resources that can be run in parallel and in what order
                groupSet++;

                foreach (var grouping in executableItemGroupings)
                {
                    var operation = grouping.Aggregate(
                        DataOperation.None, (current, entityWithDataOperation) => current | entityWithDataOperation.DataOperation);

                    var distinctEntity = grouping
                                        .Select(x => x.Entity)
                                        .Distinct()
                                        .ToList();

                    var entity = distinctEntity.FirstOrDefault();

                    var distinctConcreteContext = grouping
                                                 .Select(x => x.ContextualConcreteEntity)
                                                 .Distinct()
                                                 .ToList();

                    var contextualConcreteEntity = distinctConcreteContext.FirstOrDefault();

                    // Don't sort updates independently unless the corresponding create operation has been sorted independently
                    if (operation == DataOperation.Update &&
                        !visited[new EntityWithDataOperation(entity, DataOperation.Create, contextualConcreteEntity)])
                    {
                        continue;
                    }

                    var withDataOperations = new[]
                                             {
                                                 new EntityWithDataOperation(
                                                     entity,
                                                     DataOperation.Create & operation,
                                                     contextualConcreteEntity),
                                                 new EntityWithDataOperation(
                                                     entity,
                                                     DataOperation.Update & operation,
                                                     contextualConcreteEntity)
                                             }.Where(x => x.DataOperation != DataOperation.None);

                    UpdateVisitedVertices(withDataOperations, visited);

                    var resolvedEntity = new EntityWithDataOperation(entity, operation, contextualConcreteEntity);

                    resolved.Add(new Tuple<EntityWithDataOperation, int>(resolvedEntity, groupSet));
                }
            }

            return resolved;
        }

        private static void UpdateVisitedVertices(IEnumerable<EntityWithDataOperation> withDataOperations, ConcurrentDictionary<EntityWithDataOperation, bool> visited)
        {
            foreach (var withDataOperation in withDataOperations)
            {
                visited[withDataOperation] = true;
            }
        }

        private static List<IGrouping<string, EntityWithDataOperation>> GetUnvisitedVertices(
            BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> executionGraph,
            ConcurrentDictionary<EntityWithDataOperation, bool> visited)
        {
            return executionGraph.Vertices
                                 .GroupJoin(
                                      executionGraph.Edges,
                                      v => v,
                                      e => e.Target,
                                      (v, edges) =>
                                      {
                                          return new
                                                 {
                                                     Vertex = v,
                                                     UnexecutedDependencyCount = edges.Count(e => !e.Source.Equals(v) && !visited[e.Source])
                                                 };
                                      })
                                 .Where(vc => vc.UnexecutedDependencyCount == 0 && !visited[vc.Vertex])
                                 .Select(vc => vc.Vertex)
                                 .GroupBy(
                                      x => $"{x.Entity.FullName}|{(x.ContextualConcreteEntity == null ? string.Empty : x.ContextualConcreteEntity.FullName.ToString())}",
                                      x => x)
                                 .ToList();
        }
    }
}
