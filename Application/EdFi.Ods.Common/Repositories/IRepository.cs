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
    public interface IRepository<TEntity>
        where TEntity : IHasIdentifier
    {
        /// <summary>
        ///     Gets an aggregate by it's unique identifier (either a natural key or assigned GUID).
        /// </summary>
        /// <param name="ids">The unique identifiers of the aggregate root entity to retrieve.</param>
        /// <returns>The entire domain aggregate.</returns>
        Task<IList<TEntity>> GetByIdsAsync(IList<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        ///     Gets multiple aggregate roots by a combination of "query by example" and/or advanced criteria and paging parameters.
        /// </summary>
        /// <param name="specification">An instance of the aggregate root entity type, representing exact match search criteria, or null if not used.</param>
        /// <param name="queryParameters">Addtional search criteria.</param>
        /// <returns>A list of aggregates matching the specified criteria.</returns>
        Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(TEntity specification, IQueryParameters queryParameters,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Updates an existing aggregate.
        /// </summary>
        /// <param name="entity">The aggregate root of the aggregate to be updated.</param>
        /// <param name="enforceOptimisticLock"></param>
        /// <returns>The persisted entity.</returns>
        Task<UpsertEntityResult<TEntity>> UpsertAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken);

        /// <summary>
        ///     Loads and then deletes the aggregate given the identifier and the last modified date (for optimistic locking purposes).
        /// </summary>
        /// <param name="id">The unique identifier of the aggregate root entity.</param>
        /// <param name="etag">The last known etag value of the resource to be deleted.</param>
        Task DeleteByIdAsync(Guid id, string etag, CancellationToken cancellationToken);

        /// <summary>
        ///     Loads and then deletes the aggregate given the identifier and the last modified date (for optimistic locking purposes).
        /// </summary>
        /// <param name="specification">The specification containing the primary key values of the entity to delete.</param>
        /// <param name="etag">The last known etag value of the resource to be deleted.</param>
        Task DeleteByKeyAsync(TEntity specification, string etag, CancellationToken cancellationToken);
    }
}
