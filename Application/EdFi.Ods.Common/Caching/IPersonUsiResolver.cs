// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Defines a method for resolving the USIs for a set of UniqueId values.
/// </summary>
public interface IPersonUsiResolver
{
    /// <summary>
    /// Resolves the USI values for the supplied UniqueId values.
    /// </summary>
    /// <param name="personType">The type of person on which the identifier resolution should be performed.</param>
    /// <param name="lookups">A dictionary (keyed by UniqueId) containing entries for all the USI values to be resolved.</param>
    /// <returns>Nothing.</returns>
    // ReSharper disable once IdentifierTypo
    Task ResolveUsisAsync(string personType, IDictionary<string, int> lookups);
}
