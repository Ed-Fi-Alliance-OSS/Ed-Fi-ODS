// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models.GraphML;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using log4net;
using QuickGraph;

namespace EdFi.Ods.Features.AggregateDependencies
{
    /// <summary>
    /// Builds each response of the aggregate dependencies endpoint the first time it is requested and keeps it for the
    /// life of the process. Registered as a singleton.
    /// </summary>
    /// <remarks>
    /// A circular dependency in the resource model is kept like a response, because the model cannot change without a
    /// restart. Any other exception is not kept, so the next request builds the response again.
    /// </remarks>
    public class AggregateDependencyProvider : IAggregateDependencyProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AggregateDependencyProvider));

        // ReSharper disable once InconsistentNaming
        private static readonly string edfi = EdFiConventions.PhysicalSchemaName;
        
        private static readonly FullName _studentFullName = $"{edfi}.Student";
        private static readonly FullName _staffFullName = $"{edfi}.Staff";
        private static readonly FullName _parentFullName = $"{edfi}.Parent";
        private static readonly FullName _contactFullName = $"{edfi}.Contact";

        private static readonly FullName _studentSchoolAssociationFullName = $"{edfi}.StudentSchoolAssociation";
        private static readonly FullName _staffEdOrgAssignmentAssociationFullName = $"{edfi}.StaffEducationOrganizationAssignmentAssociation";
        private static readonly FullName _staffEdOrgEmploymentAssociationFullName = $"{edfi}.StaffEducationOrganizationEmploymentAssociation";
        private static readonly FullName _studentParentAssociationFullName = $"{edfi}.StudentParentAssociation";
        private static readonly FullName _studentContactAssociationFullName = $"{edfi}.StudentContactAssociation";

        private const string RetrySuffix = "#Retry";

        private readonly IResourceLoadGraphFactory _resourceLoadGraphFactory;
        private readonly BuiltOnce<IReadOnlyList<ResourceLoadOrder>> _loadOrder;

        // ReSharper disable once InconsistentNaming
        private readonly BuiltOnce<GraphML> _graphML;

        public AggregateDependencyProvider(IResourceLoadGraphFactory resourceLoadGraphFactory)
        {
            _resourceLoadGraphFactory = resourceLoadGraphFactory;
            _loadOrder = new BuiltOnce<IReadOnlyList<ResourceLoadOrder>>(CreateLoadOrder, "load order");
            _graphML = new BuiltOnce<GraphML>(() => CreateGraphML(_resourceLoadGraphFactory.CreateResourceLoadGraph()), "GraphML");
        }

        public IReadOnlyList<ResourceLoadOrder> GetLoadOrder() => _loadOrder.Get();

        // ReSharper disable once InconsistentNaming
        public GraphML GetGraphML() => _graphML.Get();

        private IReadOnlyList<ResourceLoadOrder> CreateLoadOrder()
        {
            var groupedLoadOrder = GetGroupedLoadOrder(_resourceLoadGraphFactory.CreateResourceLoadGraph()).ToList();
            ModifyLoadOrderForAuthorizationConcerns(groupedLoadOrder);
            return groupedLoadOrder.AsReadOnly();
        }

        // ReSharper disable once InconsistentNaming
        private static GraphML CreateGraphML(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var retryNodeIdByPrimaryAssociationNodeId = new Dictionary<string, string>();

            var vertices = resourceGraph.Vertices
                .SelectMany(ApplyStandardSecurityVertexExpansions)
                .OrderBy(n => n.Id)
                .ToList();

            var edges = resourceGraph.Edges
                .SelectMany(ApplyStandardSecurityEdgeExpansions)
                .Distinct()
                .GroupBy(x => x.Source)
                .OrderBy(g => g.Key)
                .SelectMany(g => g.OrderBy(x => x.Target))
                .ToList();

            var graphMLExecutionGraph = new BidirectionalGraph<GraphMLNode, GraphMLEdge>();
            graphMLExecutionGraph.AddVertexRange(vertices);
            graphMLExecutionGraph.AddEdgeRange(edges);

            // Remove any cycles resulting from the application of standard security
            graphMLExecutionGraph.BreakCycles(edge => edge.AssociationView.IsSoftDependency);

            return new GraphML
            {
                Id = "EdFi Dependencies",
                Nodes = graphMLExecutionGraph.Vertices.ToArray(),
                Edges = graphMLExecutionGraph.Edges.ToArray(),
            };

            IEnumerable<GraphMLEdge> ApplyStandardSecurityEdgeExpansions(AssociationViewEdge edge)
            {
                // Add a dependency for the #Retry node of edges with person types as the source
                if ((edge.Source.FullName == _studentFullName && edge.Target.FullName == _studentSchoolAssociationFullName)
                    || (edge.Source.FullName == _staffFullName && (edge.Target.FullName == _staffEdOrgAssignmentAssociationFullName || edge.Target.FullName == _staffEdOrgEmploymentAssociationFullName))
                    || (edge.Source.FullName == _parentFullName && edge.Target.FullName == _studentParentAssociationFullName)
                    || (edge.Source.FullName == _contactFullName && edge.Target.FullName == _studentContactAssociationFullName))
                {
                    string primaryAssociationNodeId = GetNodeId(edge.Target);
                    string retryNodeId = $"{GetNodeId(edge.Source)}{RetrySuffix}";

                    // Capture the Retry node's relationship with the primary association for redirecting the dependencies
                    retryNodeIdByPrimaryAssociationNodeId[primaryAssociationNodeId] = retryNodeId; 

                    // Yield a new edge for the primary association as a dependency of the retry node
                    yield return new GraphMLEdge(new GraphMLNode(primaryAssociationNodeId), new GraphMLNode(retryNodeId));

                    // Yield the standard association edge
                    yield return new GraphMLEdge(
                        new GraphMLNode(GetNodeId(edge.Source)),
                        new GraphMLNode(GetNodeId(edge.Target)),
                        edge.AssociationView);
                }
                // Add copies of the downstream dependencies of the primary associations with the #Retry node
                else if (edge.Source.FullName == _studentSchoolAssociationFullName
                    || edge.Source.FullName == _staffEdOrgAssignmentAssociationFullName
                    || edge.Source.FullName == _staffEdOrgEmploymentAssociationFullName
                    || edge.Source.FullName == _studentContactAssociationFullName
                    || edge.Source.FullName == _studentParentAssociationFullName)
                {
                    // Yield an association edge relocated to the retry node instead
                    yield return new GraphMLEdge(
                        new GraphMLNode(retryNodeIdByPrimaryAssociationNodeId[GetNodeId(edge.Source)]),
                        new GraphMLNode(GetNodeId(edge.Target)),
                        edge.AssociationView);
                }
                // Yield the standard association edge
                else
                {
                    yield return new GraphMLEdge(
                        new GraphMLNode(GetNodeId(edge.Source)),
                        new GraphMLNode(GetNodeId(edge.Target)),
                        edge.AssociationView);
                }
            }

            IEnumerable<GraphMLNode> ApplyStandardSecurityVertexExpansions(Resource resource)
            {
                yield return new GraphMLNode { Id = GetNodeId(resource) };

                // Yield "retry" nodes for person types
                if (resource.FullName == _studentFullName
                    || resource.FullName == _staffFullName
                    || resource.FullName == _parentFullName
                    || resource.FullName == _contactFullName)
                {
                    yield return new GraphMLNode() { Id = $"{GetNodeId(resource)}{RetrySuffix}" };
                }
            }
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

        /// <summary>
        /// Holds a value built by the first caller. Callers that arrive while it is being built wait for it.
        /// </summary>
        private sealed class BuiltOnce<T>
            where T : class
        {
            private readonly Func<T> _build;
            private readonly string _description;
            private readonly object _lock = new();

            private T _value;
            private NonAcyclicGraphException _circularDependency;

            public BuiltOnce(Func<T> build, string description)
            {
                _build = build;
                _description = description;
            }

            public T Get()
            {
                lock (_lock)
                {
                    if (_value == null && _circularDependency == null)
                    {
                        try
                        {
                            _value = _build();
                        }
                        catch (NonAcyclicGraphException e)
                        {
                            _logger.Error($"The aggregate dependencies {_description} could not be built because the resource model has a circular dependency.", e);
                            _circularDependency = e;
                        }
                    }

                    if (_circularDependency != null)
                    {
                        throw _circularDependency;
                    }

                    return _value;
                }
            }
        }
    }
}
