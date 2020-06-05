// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using QuickGraph;
using EntitySpecification = EdFi.Ods.Common.Specifications.EntitySpecification;

namespace EdFi.Ods.Api.Common.Models.GraphML
{
    public class GraphML
    {
        public string Id { get; set; }

        public IList<Node> Nodes { get; set; }

        public IList<Edge> Edges { get; set; }

        public static GraphML Create(BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph)
        {
            return new GraphML
            {
                Id = "EdFi Dependencies",
                Nodes = graph.Vertices
                    .Where(
                        x => EntitySpecification.HasResourceRepresentation(x.Entity))
                    .Select(
                        x =>
                        {
                            var entity = x.ContextualConcreteEntity ?? x.Entity;

                            return new Node
                            {
                                Id =
                                    $"/{entity.SchemaUriSegment()}/{entity.PluralName.ToCamelCase()}"
                            };
                        })
                    .Distinct(Node.NodeComparer)
                    .ToList(),
                Edges = graph.Edges
                    .Where(
                        x => EntitySpecification.HasResourceRepresentation(x.Source.Entity))
                    .Select(
                        x =>
                        {
                            var source = x.Source.ContextualConcreteEntity ?? x.Source.Entity;
                            var target = x.Target.ContextualConcreteEntity ?? x.Target.Entity;

                            return new Edge
                            {
                                Source = $"/{source.SchemaUriSegment()}/{source.PluralName.ToCamelCase()}",
                                Target = $"/{target.SchemaUriSegment()}/{target.PluralName.ToCamelCase()}"
                            };
                        })
                    .Distinct(Edge.SourceTargetComparer)
                    .ToList()
            };
        }
    }
}
