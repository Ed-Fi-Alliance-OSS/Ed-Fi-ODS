// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.Common;
using QuickGraph;
using QuickGraph.Algorithms;
using static System.Text.RegularExpressions.Regex;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class ModelDependencySort : IModelDependencySort
    {
        private readonly IResourceApi[] _apis;
        private readonly Lazy<AdjacencyGraph<Type, MEdge>> _graph;
        private readonly Type[] _models;
        private readonly List<string> _schemaNames;

        public ModelDependencySort(ISdkCategorizer categorizer, List<string> schemaNames = null)
        {
            _schemaNames = schemaNames;
            _models = categorizer.ModelTypes.ToArray();
            _apis = categorizer.ResourceApis.ToArray();
            _graph = new Lazy<AdjacencyGraph<Type, MEdge>>(BuildModelGraph);
        }

        public IEnumerable<Type> OrderedModels()
        {
            return _graph.Value.TopologicalSort();
        }

        public IEnumerable<IResourceApi> OrderedApis()
        {
            return from type in _graph.Value.TopologicalSort()
                   from api in _apis
                   where type == api.ModelType
                   select api;
        }

        private AdjacencyGraph<Type, MEdge> BuildModelGraph()
        {
            var edges = new List<MEdge>(
                _models.SelectMany(u => GetModelPropertyTypes(u).Select(v => new MEdge(v, u))));

            edges.AddRange(
                _models.SelectMany(u => GetModelListTypes(u).Select(v => new MEdge(v, u))));

            edges.AddRange(
                _models.SelectMany(u => GetTypeAndDescriptorPropertyTypes(u).Select(v => new MEdge(v, u))));

            edges.AddRange(
                _models.SelectMany(v => GetReferencedTypes(v).Select(u => new MEdge(v, u))));

            var edgeComparer = new MEdgeEqualityComparer();
            var graph = edges.Distinct(edgeComparer).ToAdjacencyGraph<Type, MEdge>();

            RemoveCyclesFromGraph(graph);

            return graph;
        }

        private static void RemoveCyclesFromGraph(IMutableVertexAndEdgeListGraph<Type, MEdge> graph)
        {
            IDictionary<Type, int> components;
            graph.StronglyConnectedComponents(out components);

            var cycles = components.GroupBy(x => x.Value, x => x.Key)
                                   .Where(x => x.Count() > 1)
                                   .Select(x => x.ToList());

            foreach (var cycle in cycles)
            {
                var clippedTypes = cycle.Where(
                    x => x.Name.EndsWith("Reference")
                         || x.GetProperties().Length == 1
                         && x.GetProperties().Single().PropertyType.Name
                             .EndsWith("Reference"));

                var edges = graph.Edges.Where(e => cycle.Contains(e.Target) && clippedTypes.Contains(e.Source));
                graph.RemoveEdgeIf(e => edges.Contains(e));
            }
        }

        private IEnumerable<Type> GetModelPropertyTypes(Type modelType)
        {
            return modelType.GetProperties()
                            .Where(p => _models.Contains(p.PropertyType))
                            .Select(p => p.PropertyType);
        }

        private IEnumerable<Type> GetModelListTypes(Type modelType)
        {
            return modelType.GetProperties().Select(p => p.PropertyType)
                            .Where(
                                 p => p.IsGenericType
                                      && typeof(List<>).IsAssignableFrom(p.GetGenericTypeDefinition())
                                      && _models.Contains(p.GetGenericArguments().Single()))
                            .Select(p => p.GetGenericArguments().Single());
        }

        private IEnumerable<Type> GetReferencedTypes(Type modelType)
        {
            return _models.Where(m => m.Name == $"{modelType.Name}Reference");
        }

        private IEnumerable<Type> GetTypeAndDescriptorPropertyTypes(Type modelType)
        {
            const string regex = @"([tT]ype|[dD]escriptor)$";

            var result = (from property in modelType.GetProperties()
                          from modelName in property.PossiblePropertyNames(_schemaNames)
                          from model in _models
                          where property.PropertyType == typeof(string)
                                && IsMatch(property.Name, regex)
                                && IsMatch(model.Name, regex)
                                && model.Name == modelName
                          select new
                            {
                                property, model
                            })
                        .GroupBy(x => x.property).ToList();

            //
            //  un-comment to see what properties didn't match too well...
            //
            //var mismatches = r1.Where(x => x.Count() > 1);
            //foreach (var mismatch in mismatches)
            //{
            //    var values = string.Join(", ", mismatch.OrderByDescending(y => y.model.Name.Length).Select(m => m.model.Name));
            //    Console.WriteLine($"{mismatch.Key.DeclaringType?.Name}.{mismatch.Key.Name}: {values}");
            //}

            // in case of an ambiguous match, take the model with the longest name.
            return result.Select(x => x.First().model);
        }

        private class MEdge : IEdge<Type>
        {
            public MEdge(Type source, Type target)
            {
                Source = source;
                Target = target;
            }

            public Type Source { get; }

            public Type Target { get; }
        }

        private class MEdgeEqualityComparer : IEqualityComparer<MEdge>
        {
            public bool Equals(MEdge x, MEdge y)
            {
                return GetHashCode(x) == GetHashCode(y);
            }

            public int GetHashCode(MEdge obj)
            {
                return $"{obj.Source.Name} {obj.Target.Name}".GetHashCode();
            }
        }
    }
}
