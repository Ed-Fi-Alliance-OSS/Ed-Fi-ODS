// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models.GraphML;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using log4net;
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
        private readonly IResourceLoadGraphFactory _resourceLoadGraphFactory;

        private readonly ILog _logger = LogManager.GetLogger(typeof(AggregateDependencyController));
        private readonly bool _isEnabled;

        public AggregateDependencyController(ApiSettings apiSettings, IResourceLoadGraphFactory resourceLoadGraphFactory)
        {
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.AggregateDependencies.GetConfigKeyName());
            _resourceLoadGraphFactory = resourceLoadGraphFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            try
            {
                return Request.Headers["Accept"].ToString().EqualsIgnoreCase(CustomMediaContentTypes.GraphML)
                    ? Ok(CreateGraphML(_resourceLoadGraphFactory.CreateResourceLoadGraph()))
                    : Ok(GetGroupedLoadOrder(_resourceLoadGraphFactory.CreateResourceLoadGraph()));
            }
            catch (NonAcyclicGraphException e)
            {
                // return a bad request if a circular reference occurs, with the path information of the reference.
                string message = e.Message.Replace($"{Environment.NewLine}    is used by ", " -> ")
                    .Replace(Environment.NewLine, " ");

                return BadRequest(message);
            }
        }

        // ReSharper disable once InconsistentNaming
        private static GraphML CreateGraphML(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            return new GraphML
            {
                Id = "EdFi Dependencies",
                Nodes = resourceGraph.Vertices
                    .Select(r => new GraphMLNode {Id = GetNodeId(r)})
                    .OrderBy(n => n.Id)
                    .ToList(),
                Edges = resourceGraph.Edges
                    .Select(edge => new GraphMLEdge(GetNodeId(edge.Source), GetNodeId(edge.Target)))
                    .GroupBy(x => x.Source)
                    .OrderBy(g => g.Key)
                    .SelectMany(g => g.OrderBy(x => x.Target))
                    .ToList()
            };
        }

        private static IEnumerable<ResourceLoadOrder> GetGroupedLoadOrder(
            BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            int groupNumber = 1;

            var executionGraph = resourceGraph.Clone();

            var loadableResources = GetLoadableResources();

            while (loadableResources.Any())
            {
                foreach (Resource loadableResource in loadableResources)
                {
                    executionGraph.RemoveVertex(loadableResource);

                    yield return new ResourceLoadOrder
                    {
                        Resource = GetNodeId(loadableResource),
                        Order = groupNumber
                    };
                }

                groupNumber++;

                loadableResources = GetLoadableResources();
            }

            List<Resource> GetLoadableResources()
            {
                return executionGraph.Vertices.Where(v => !executionGraph.InEdges(v).Any())
                    .OrderBy(GetNodeId)
                    .ToList();
            }
        }

        private static string GetNodeId(Resource resource)
            => $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}";
    }
}
#endif
