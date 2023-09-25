// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Provides a base class for storing the context of all the UniqueIds/USIs that need to be resolved during a request.
/// </summary>
/// <typeparam name="TKey">The type of the key of the underlying dictionary.</typeparam>
/// <typeparam name="TValue">The type of the value of the underlying dictionary.</typeparam>
public abstract class PersonIdentifierLookupContextBase<TKey, TValue>
{
    private readonly Lazy<IDictionary<string, IDictionary<TKey, TValue>>> _values = new(
        () => new Dictionary<string, IDictionary<TKey, TValue>>());

    protected IDictionary<string, IDictionary<TKey, TValue>> ValuesByPersonType
    {
        get => _values.Value;
    }

    /// <summary>
    /// Adds an entry to the context containing the key of the value to be retrieved.
    /// </summary>
    /// <param name="personType">The type of person for which an identifier lookup is needed.</param>
    /// <param name="value">The known identifier value which is the basis for looking up the associated identifier.</param>
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

    /// <summary>
    /// Indicates whether any lookups have been added to the context. 
    /// </summary>
    /// <returns><b>true</b> if there are any identifier values to be resolved; otherwise <b>false</b>.</returns>
    public bool Any()
    {
        return _values.IsValueCreated;
    }
}
