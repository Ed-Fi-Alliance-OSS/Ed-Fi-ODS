// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using QuickGraph;

namespace EdFi.Ods.Security.Extensions
{
    public static class AdjacencyGraphExtensions
    {
        public static IEnumerable<TVertex> GetDescendantsOrSelf<TVertex, TEdge>(
            this AdjacencyGraph<TVertex, TEdge> graph,
            TVertex vertex)
            where TEdge : IEdge<TVertex>
        {
            return new[]
                   {
                       vertex
                   }.Concat(graph.GetDescendants(vertex));
        }

        public static IEnumerable<TVertex> GetDescendants<TVertex, TEdge>(
            this AdjacencyGraph<TVertex, TEdge> graph,
            TVertex vertex)
            where TEdge : IEdge<TVertex>
        {
            IEnumerable<TEdge> edges;

            if (!graph.TryGetOutEdges(vertex, out edges))
            {
                yield break;
            }

            foreach (var edge in edges)
            {
                yield return edge.Target;

                foreach (var descendant in GetDescendants(graph, edge.Target))
                {
                    yield return descendant;
                }
            }
        }
    }
}
