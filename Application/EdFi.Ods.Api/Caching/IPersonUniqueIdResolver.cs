// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Defines a method for resolving the UniqueIds for a set of USI values.
/// </summary>
public interface IPersonUniqueIdResolver
{
    /// <summary>
    /// Resolves the UniqueId values for the supplied USI values.
    /// </summary>
    /// <param name="personType">The type of person on which the identifier resolution should be performed.</param>
    /// <param name="lookups">A dictionary (keyed by USI) containing entries for all the UniqueId values to be resolved.</param>
    /// <returns>Nothing.</returns>
    Task ResolveUniqueIdsAsync(string personType, IDictionary<int, string> lookups);
}
