// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    public class EntityWithDataOperation : IEquatable<EntityWithDataOperation>
    {
        public EntityWithDataOperation(Entity entity, DataOperation dataOperation)
            : this(entity, dataOperation, null as Entity)
        {
        }

        public EntityWithDataOperation(Entity entity, DataOperation dataOperation, Entity contextualConcreteEntity)
            : this(entity, dataOperation, contextualConcreteEntity, null)
        {
        }

        public EntityWithDataOperation(
            Entity entity,
            DataOperation dataOperation,
            BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> aggregateGraph)
            : this(entity, dataOperation, null, aggregateGraph)
        {
        }

        public EntityWithDataOperation(
            Entity entity,
            DataOperation dataOperation,
            Entity contextualConcreteEntity,
            BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> aggregateGraph)
        {
            // NOTE: contextualConcreteEntity and aggregateGraph are not required
            Preconditions.ThrowIfNull(entity, nameof(entity));

            Entity = entity;
            DataOperation = dataOperation;
            ContextualConcreteEntity = contextualConcreteEntity;
            AggregateGraph = aggregateGraph;

            _toString = new Lazy<string>(BuildToStringValue);
        }

        public Entity Entity { get; }

        public DataOperation DataOperation { get; }

        public BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> AggregateGraph { get; }

        /// <summary>
        /// For operations on base entities, indicates the concrete entity currently in context (if any).
        /// </summary>
        public Entity ContextualConcreteEntity { get; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(EntityWithDataOperation other)
        {
            if (!ModelComparers.Entity.Equals(Entity, other.Entity))
            {
                return false;
            }

            if (DataOperation != other.DataOperation)
            {
                return false;
            }

            if (!ModelComparers.Entity.Equals(ContextualConcreteEntity, other.ContextualConcreteEntity))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Entity.Schema.GetHashCode();
                hash = hash * 23 + Entity.Name.GetHashCode();
                hash = hash * 23 + DataOperation.GetHashCode();

                if (ContextualConcreteEntity != null)
                {
                    hash = hash * 23 + ContextualConcreteEntity.Schema.GetHashCode();
                    hash = hash * 23 + ContextualConcreteEntity.Name.GetHashCode();
                }

                return hash;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            var entityWithDataOperation = obj as EntityWithDataOperation;

            if (entityWithDataOperation == null)
            {
                return false;
            }

            return Equals(entityWithDataOperation);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return _toString.Value;
        }

        private readonly Lazy<string> _toString;

        private string BuildToStringValue()
        {
            if (ContextualConcreteEntity == null)
            {
                return $"{Entity.FullName} ({DataOperation})";
            }

            return $"{Entity.FullName} ({DataOperation}) - {ContextualConcreteEntity.Name}";
        }
    }
}
