// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Caching;

public abstract class LookupsContext<TKey, TValue>
{
    private readonly Lazy<IDictionary<string, IDictionary<TKey, TValue>>> _values = new(
        () => new Dictionary<string, IDictionary<TKey, TValue>>());

    protected IDictionary<string, IDictionary<TKey, TValue>> ValuesByPersonType
    {
        get => _values.Value;
    }

    public void AddLookup(string personType, TKey value)
    {
        // Don't add null keys for lookup
        if (value == null)
        {
            return;
        }
        
        if (!_values.Value.TryGetValue(personType, out var values))
        {
            _values.Value.Add(personType, new Dictionary<TKey, TValue> { { value, default } });

            return;
        }

        values[value] = default;
    }

    public bool Any()
    {
        return _values.IsValueCreated;
    }
}
