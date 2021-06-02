// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    public class ResourceLoadGraphFactory : IResourceLoadGraphFactory
    {
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IResourceLoadGraphTransformer[] _graphTransformers;

        public ResourceLoadGraphFactory(IResourceModelProvider resourceModelProvider,
            IResourceLoadGraphTransformer[] graphTransformers)
        {
            _resourceModelProvider = resourceModelProvider;
            _graphTransformers = graphTransformers;
        }
        
        public BidirectionalGraph<Resource.Resource, AssociationViewEdge> CreateResourceLoadGraph()
        {
            var resourceModel = _resourceModelProvider.GetResourceModel();
            
            var resourceGraph = new BidirectionalGraph<Resource.Resource, AssociationViewEdge>();

            var resources = resourceModel.GetAllResources()
                .Where(r => !r.IsAbstract() && !r.FullName.IsEdFiSchoolYearType()) 
                .ToArray();
            
            resourceGraph.AddVertexRange(resources);

            var edges = resources
                // Abstract resources are already covered by their concrete resources in the model
                .Where(res => !res.IsAbstract())
                // Add edges for all references (incoming associations) and descriptor usages
                .SelectMany(
                    res =>

                        // Add all incoming reference in the entire resource
                        res.AllContainedReferences.SelectMany(AssociationViewEdge.CreateEdges)

                            // Add direct descriptor associations
                            .Concat(
                                res.AllContainedItemTypesOrSelf.SelectMany(
                                    rc => rc.Properties.Where(p => p.IsDirectLookup)
                                        .Select(
                                            p => new AssociationViewEdge(
                                                p.DescriptorResource,
                                                p.Parent.ResourceRoot,
                                                p.EntityProperty.IncomingAssociations.Single())))))

                // Eliminate redundant edges
                .Distinct(AssociationViewEdge.Comparer);
            
            resourceGraph.AddEdgeRange(edges.Where(e => !e.Source.FullName.IsEdFiSchoolYearType()));

            // Apply predefined graph transformations
            if (_graphTransformers.Any())
            {
                foreach (var graphTransformer in _graphTransformers)
                {
                    graphTransformer.Transform(resourceGraph);
                }
            }
            
            resourceGraph.BreakCycles(edge => edge.AssociationView.IsSoftDependency);

            return resourceGraph;
        }
    }

    public class AssociationViewEdge : IEdge<Resource.Resource>
    {
        public AssociationViewEdge(Resource.Resource source, Resource.Resource target, AssociationView associationView)
        {
            Source = source;
            Target = target;
            AssociationView = associationView;
        }

        private AssociationViewEdge(Reference reference)
        {
            Source = reference.ReferencedResource;
            Target = reference.Parent.ResourceRoot;
            AssociationView = reference.Association;
        }

        public Resource.Resource Source { get; }

        public Resource.Resource Target { get; }

        public AssociationView AssociationView { get; }

        public static IEnumerable<AssociationViewEdge> CreateEdges(Reference reference)
        {
            if (reference.ReferencedResource.IsAbstract())
            {
                // Need to expand and replace this to include all concrete types of the source instead
                var derivedEntities = reference.ReferencedResource.Entity.DerivedEntities;

                foreach (var derivedEntity in derivedEntities)
                {
                    var source = reference.Parent.ResourceModel.GetResourceByFullName(derivedEntity.FullName);
                    var target = reference.Parent.ResourceRoot;

                    yield return new AssociationViewEdge(source, target, reference.Association);
                }
            }
            else
            {
                yield return new AssociationViewEdge(reference);
            }
        }

        public override string ToString() => AssociationView.Association.ToString();

        private sealed class AssociationViewEdgeEqualityComparer : IEqualityComparer<AssociationViewEdge>
        {
            public bool Equals(AssociationViewEdge x, AssociationViewEdge y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return Equals(x.Source.FullName, y.Source.FullName)
                    && Equals(x.Target.FullName, y.Target.FullName);
            }

            public int GetHashCode(AssociationViewEdge obj)
            {
                return $"{obj.Source.FullName}|{obj.Target.FullName}".GetHashCode();
            }
        }

        public static IEqualityComparer<AssociationViewEdge> Comparer { get; } = new AssociationViewEdgeEqualityComparer();
    }
}