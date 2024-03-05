// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Domain;

public static class DomainModelConventionExtensions
{
    private static readonly ConcurrentDictionary<DomainModel, Entity[]> _personEntitiesByDomainModel = new();

    /// <summary>
    /// Gets the entities of the domain model that are person types.
    /// </summary>
    /// <param name="domainModel">The <see cref="DomainModel" /> to be evaluated.</param>
    /// <returns>An array of entities representing the person types.</returns>
    public static Entity[] GetPersonEntities(this DomainModel domainModel)
    {
        return _personEntitiesByDomainModel.GetOrAdd(domainModel, 
            dm => 
                dm.Aggregates
                    .Select(a => a.AggregateRoot)
                    .Where(e => 
                        e.Identifier.Properties.Count == 1 
                        && UniqueIdConventions.IsUSI(e.Identifier.Properties[0].PropertyName, e.Name))
                    .ToArray());
    }
}
