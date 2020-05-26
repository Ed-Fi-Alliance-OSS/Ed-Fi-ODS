// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using QuickGraph;
using QuickGraph.Algorithms;

namespace EdFi.Ods.Common.Models.Graphs
{
    public static class BidirectionalGraphExtensions
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BidirectionalGraphExtensions));
        
        public static void ValidateGraph<TVertex, TEdge>(
            this BidirectionalGraph<TVertex, TEdge> graph)
            where TEdge : IEdge<TVertex>
        {
            // Initialize vertex, and current stack tracking 
            var visited = new HashSet<TVertex>(); 
            var stack = new List<TVertex>();
            var cycles = new List<Cycle<TVertex>>();
            
            // Call the recursive helper function to detect cycle in different DFS trees
            foreach (var vertex in graph.Vertices)
            {
                _logger.Debug($"Probing node '{vertex}' for cyclical dependencies...");
                graph.EnsureAcyclic(vertex, visited, stack, cycles);
            }

            if (cycles.Any())
            {
                string cycleExplanations = string.Join(
                    Environment.NewLine + Environment.NewLine,
                    cycles.Select(c => $"{string.Join(Environment.NewLine + "    is used by ", c.Path.Select(x => x.ToString()))}"));

                string dependencyPluralization = (cycles.Count == 1
                    ? "dependency"
                    : "dependencies");

                throw new NonAcyclicGraphException($@"Circular {dependencyPluralization} found:{Environment.NewLine}{cycleExplanations}");
            }
        }
        
        private static void EnsureAcyclic<TVertex, TEdge>(
            this BidirectionalGraph<TVertex, TEdge> executionGraph,
            TVertex vertex, 
            HashSet<TVertex> visited, 
            List<TVertex> stack, 
            List<Cycle<TVertex>> cycles)
            where TEdge : IEdge<TVertex>
        {
            // Do we have a circular dependency?
            if (stack.Contains(vertex))
            {
                var cycle = new Cycle<TVertex>
                            {
                                Vertex = vertex.ToString(), 
                                Path = stack.SkipWhile(x => !x.Equals(vertex))
                                            .Concat(new[] { vertex })
                                            .ToList()
                            };
             
                cycles.Add(cycle);
                visited.Add(vertex);
                return;
            }

            // If we've already evaluated this vertex, stop now.
            if (visited.Contains(vertex)) 
                return; 

            // Mark the current node as visited and part of recursion stack 
            visited.Add(vertex);
            stack.Add(vertex);

            try
            {
                var children = executionGraph
                              .OutEdges(vertex)
                              .Select(x => x.Target)
                              .ToList();

                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"Children of {vertex}: {string.Join(" => ", children.Select(x => x.ToString()))}");
                }
                
                foreach (var child in children)
                {
                    executionGraph.EnsureAcyclic(child, visited, stack, cycles);
                }
            }
            finally
            {
                stack.Remove(vertex);
            }
        }

        public class Cycle<TVertex>
        {
            public string Vertex { get; set; }
            public List<TVertex> Path { get; set; }
        }
    }
}
