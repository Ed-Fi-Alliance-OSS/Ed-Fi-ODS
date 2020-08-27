// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Repositories
{
    /// <summary>
    /// Defines a method for retrieving a list of entities by their identifiers.
    /// </summary>
    /// <typeparam name="TEntity">The Type of the entities to be retrieved.</typeparam>
    public interface IGetEntitiesByIds<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        /// <summary>
        /// Get a list of entities by their identifiers.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        /// <returns>The list of matching entities.</returns>
        Task<IList<TEntity>> GetByIdsAsync(IList<Guid> ids, CancellationToken cancellationToken);
    }
}
