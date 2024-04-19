// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models.GraphML;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickGraph;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [ApplyOdsRouteRootTemplate]
    [Route($"metadata/{RouteConstants.DataManagementRoutePrefix}/dependencies")]
    public class AggregateDependencyController : ControllerBase
    {
        private readonly IResourceLoadGraphFactory _resourceLoadGraphFactory;
        private readonly ILogContextAccessor _logContextAccessor;

        private readonly ILog _logger = LogManager.GetLogger(typeof(AggregateDependencyController));
        private readonly bool _isEnabled;

        public AggregateDependencyController(
            ApiSettings apiSettings,
            IResourceLoadGraphFactory resourceLoadGraphFactory,
            ILogContextAccessor logContextAccessor)
        {
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.AggregateDependencies.GetConfigKeyName());
            _resourceLoadGraphFactory = resourceLoadGraphFactory;
            _logContextAccessor = logContextAccessor;
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
                var groupedLoadOrder = GetGroupedLoadOrder(_resourceLoadGraphFactory.CreateResourceLoadGraph()).ToList();
                ModifyLoadOrderForAuthorizationConcerns(groupedLoadOrder);
                return Request.GetTypedHeaders().Accept != null
                    && Request.GetTypedHeaders().Accept.Any(a => a.MediaType.Value.EqualsIgnoreCase(CustomMediaContentTypes.GraphML))
                ? Ok(CreateGraphML(_resourceLoadGraphFactory.CreateResourceLoadGraph()))
                : Ok(groupedLoadOrder);
            }
            catch (NonAcyclicGraphException e)
            {
                // return a bad request if a circular reference occurs, with the path information of the reference.
                string message = e.Message.Replace($"{Environment.NewLine}    is used by ", " -> ")
                    .Replace(Environment.NewLine, " ");

                return BadRequest(
                    new BadRequestException(
                        "scenario12.",
                        new[] { message })
                    {
                        CorrelationId = _logContextAccessor.GetCorrelationId()
                    }.AsSerializableModel());
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

        private static void ModifyLoadOrderForAuthorizationConcerns(IList<ResourceLoadOrder> resources)
        {
            ApplyStudentTransformation(resources);
            ApplyStaffTransformation(resources);
            ApplyContactTransformation(resources);
        }

        private static void ApplyContactTransformation(IList<ResourceLoadOrder> resources)
        {
            // StudentContactAssociation must be created before Contacts can be updated.
            // StudentSchoolAssociation must be created before Contacts can be updated.
            // StudentSchoolAssociation must be created before StudentContactAssociations can be updated.
            var contactCreate = resources
                .SingleOrDefault(r => r.Resource is "/ed-fi/parents" or "/ed-fi/contacts");

            if (contactCreate == null)
            {
                return;
            }

            var studentContactAssociation = resources
                .Single(r => r.Resource is "/ed-fi/studentParentAssociations" or "/ed-fi/studentContactAssociations");

            var studentSchoolAssociation = resources
                .Single(r => r.Resource == "/ed-fi/studentSchoolAssociations");

            var higherOrder = Math.Max(studentContactAssociation.Order, studentSchoolAssociation.Order);

            var contactUpdate = new ResourceLoadOrder
            {
                Resource = contactCreate.Resource,
                Order = higherOrder + 1,
                Operations = new List<string> { "Update" }
            };

            contactCreate.Operations.Remove("Update");

            resources.Insert(
                resources.IndexOf(resources.FirstOrDefault(r => r.Order == contactUpdate.Order) ?? resources[^1])
                , contactUpdate
            );
        }

        private static void ApplyStaffTransformation(IList<ResourceLoadOrder> resources)
        {
            // StaffEducationOrganizationEmploymentAssociation or StaffEducationOrganizationAssignmentAssociation
            //must be created before Staff can be updated.
            var staffCreate = resources
                .SingleOrDefault(r => r.Resource == "/ed-fi/staffs");

            if (staffCreate == null)
            {
                return;
            }

            var staffEducationOrganizationEmploymentAssociation = resources
                .Single(r => r.Resource == "/ed-fi/staffEducationOrganizationEmploymentAssociations");

            var staffEducationOrganizationAssignmentAssociation = resources
                .Single(r => r.Resource == "/ed-fi/staffEducationOrganizationAssignmentAssociations");

            var highestOrder = Math.Max(
                staffEducationOrganizationAssignmentAssociation.Order, staffEducationOrganizationEmploymentAssociation.Order);

            var staffUpdate = new ResourceLoadOrder()
            {
                Resource = staffCreate.Resource,
                Order = highestOrder + 1,
                Operations = new List<string> { "Update" }
            };

            staffCreate.Operations.Remove("Update");

            resources.Insert(
                resources.IndexOf(resources.FirstOrDefault(r => r.Order == staffUpdate.Order) ?? resources[^1])
                , staffUpdate
            );
        }

        private static void ApplyStudentTransformation(IList<ResourceLoadOrder> resources)
        {
            var studentCreate = resources
                .SingleOrDefault(r => r.Resource == "/ed-fi/students");

            if (studentCreate == null)
            {
                return;
            }


            var studentSchoolAssociation = resources
                .Single(r => r.Resource == "/ed-fi/studentSchoolAssociations");

            var studentUpdate = new ResourceLoadOrder()
            {
                Resource = studentCreate.Resource,
                Order = studentSchoolAssociation.Order + 1,
                Operations = new List<string> { "Update" }
            };

            studentCreate.Operations.Remove("Update");

            resources.Insert(
                resources.IndexOf(resources.FirstOrDefault(r => r.Order == studentUpdate.Order) ?? resources[^1])
                , studentUpdate
            );
        }
    }
}
