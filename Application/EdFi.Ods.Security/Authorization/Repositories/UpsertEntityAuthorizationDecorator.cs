// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Authorizes calls to the "Upsert" repository method.
    /// </summary>
    /// <typeparam name="T">The Type of entity being upserted.</typeparam>
    public class UpsertEntityAuthorizationDecorator<T>
        : IUpsertEntity<T>
        where T : IHasIdentifier, IDateVersionedEntity
    {
        private readonly IUpsertEntity<T> _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertEntityAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        public UpsertEntityAuthorizationDecorator(IUpsertEntity<T> next)
        {
            _next = next;
        }

        /// <summary>
        /// Authorizes a call to update an entity.
        /// </summary>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public async Task<UpsertEntityResult<T>> UpsertAsync(T entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            // We do not need to perform authorization because the UpsertEntity will call other 
            // methods (Create or Update) which will trigger the authorization.
            return await _next.UpsertAsync(entity, enforceOptimisticLock, cancellationToken);
        }
    }
}
