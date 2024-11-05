// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Infrastructure.Listeners;

namespace EdFi.Ods.Common.Repositories
{
    public class GetBySpecificationResult<TEntity>
        where TEntity : IHasIdentifier
    {
        public IList<ResultItem<TEntity>> Results { get; set; }

        public ResultMetadata ResultMetadata { get; set; }
    }

    public class ResultMetadata
    {
        public int TotalCount { get; set; }

        public string NextPageToken { get; set; }
    }

    // TODO: ODS-6551 - Review the need for this class vs. ItemData
    public class ResultItem<TEntity> : IDeserializable
    {
        public ResultItem(TEntity entity)
        {
            Entity = entity;
        }
    
        public ResultItem(TEntity entity, byte[] aggregateData)
        {
            Entity = entity;
            AggregateData = aggregateData;
        }
    
        public TEntity Entity { get; set; }

        public byte[] AggregateData { get; set; }

        public bool TryDeserialize<TTarget>(out TTarget deserialized)
        {
            if (AggregateData != null)
            {
                deserialized = MessagePackHelper.DecompressAndDeserializeAggregate<TTarget>(AggregateData);
                return true;
            }
    
            deserialized = default;
            return false;
        }
    }
}
