// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;
using QuickGraph;

namespace EdFi.Ods.Api.Models.GraphML
{
    // ReSharper disable once InconsistentNaming
    public class GraphMLEdge : IEquatable<GraphMLEdge>, IEdge<GraphMLNode>
    {
        public GraphMLEdge(GraphMLNode source, GraphMLNode target)
        {
            Source = source;
            Target = target;
        }

        public GraphMLEdge(GraphMLNode source, GraphMLNode target, AssociationView edgeAssociationView)
            : this(source, target)
        {
            AssociationView = edgeAssociationView;
        }

        public AssociationView AssociationView { get; }

        public GraphMLNode Source { get; }

        public GraphMLNode Target { get; }

        #region Equality members
        public bool Equals(GraphMLEdge other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Source.Id == other.Source.Id && Target.Id == other.Target.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((GraphMLEdge)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Source, Target);
        
        #endregion
    }
}
