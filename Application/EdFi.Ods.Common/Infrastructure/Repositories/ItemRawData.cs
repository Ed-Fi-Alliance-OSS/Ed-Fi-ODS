// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Serialization;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public class ItemRawData
{
    private readonly Lazy<bool> _isDeserializable;

    public ItemRawData()
    {
        _isDeserializable =
            new Lazy<bool>(() => AggregateData != null && LastModifiedDate == AggregateData.ReadLastModifiedDate());
    }

    public int AggregateId { get; set; }

    public byte[] AggregateData { get; set; }

    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// Gets or sets the surrogate id value for the entity, if applicable (deserialized data may not yet contain the surrogate id values).
    /// </summary>
    public int SurrogateId { get; set; }

    /// <summary>
    /// Indicates whether the item has data to deserialize, and the data's LastModifiedDate matches the current state of the record. 
    /// </summary>
    /// <returns></returns>
    public bool IsDeserializable()
    {
        return _isDeserializable.Value;
    }
}
