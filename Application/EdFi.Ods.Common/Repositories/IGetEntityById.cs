// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Repositories
{
    /// <summary>
    /// Defines a method for retrieving and entity by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The Type of the entity to be retrieved.</typeparam>
    public interface IGetEntityById<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        /// <summary>
        /// Gets a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The value of the unique identifier.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
