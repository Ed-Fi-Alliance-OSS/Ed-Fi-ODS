// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Repositories
{
    /// <summary>
    /// Defines a method for retrieving an entity by its composite primary key values.
    /// </summary>
    /// <typeparam name="TEntity">The Type of the entity to be retrieved.</typeparam>
    public interface IGetEntityByKey<TEntity>
        where TEntity : IHasIdentifier // TODO: GKM: Pulled during addition of GetByKey pipeline. Needed? --> IDateVersionedEntity
    {
        /// <summary>
        /// Gets a single entity by its composite primary key values.
        /// </summary>
        /// <param name="specification">An entity instance that has all the primary key properties assigned with values.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        Task<TEntity> GetByKeyAsync(TEntity specification, CancellationToken cancellationToken);
    }
}
