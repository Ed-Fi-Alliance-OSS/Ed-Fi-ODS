// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Models.GraphML;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickGraph;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [Route("dependencies")]
    [AllowAnonymous]
    public class AggregateDependencyController : ControllerBase
    {
        private readonly IEntityWithDataOperationGraphFactory _entityWithDataOperationGraphFactory;
        private readonly bool _isEnabled;

        public AggregateDependencyController(ApiSettings apiSettings, IEntityWithDataOperationGraphFactory entityWithDataOperationGraphFactory = null)
        {
            _entityWithDataOperationGraphFactory = entityWithDataOperationGraphFactory;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.AggregateDependencies.GetConfigKeyName());
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            if (Request.Headers["Accept"]
                .ToString()
                .EqualsIgnoreCase(CustomMediaContentTypes.GraphML))

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
            var visited =
                new ConcurrentDictionary<EntityWithDataOperation, bool>(executionGraph.Vertices.ToDictionary(k => k, v => false));

            var resolved = new List<Tuple<EntityWithDataOperation, int>>();

            int groupSet = 0;

            while (visited.Values.Any(x => x == false))
            {
                var executableItemGroupings = GetUnvisitedVertices();

                // this embedded convention allows for grouping of resources that can be run in parallel and in what order
                groupSet++;

                foreach (var grouping in executableItemGroupings)
                {
                    var operation = grouping.Aggregate(
                        DataOperation.None,
                        (current, entityWithBulkOperation) => current | entityWithBulkOperation.DataOperation);

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

                    UpdateVisitedVertices();

                    var resolvedEntity = new EntityWithDataOperation(entity, operation, contextualConcreteEntity);

                    resolved.Add(new Tuple<EntityWithDataOperation, int>(resolvedEntity, groupSet));

                    void UpdateVisitedVertices()
                    {
                        foreach (var withDataOperation in withDataOperations)
                        {
                            visited[withDataOperation] = true;
                        }
                    }
                }
            }

            return resolved;

            List<IGrouping<string, EntityWithDataOperation>> GetUnvisitedVertices()
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
}
#endif