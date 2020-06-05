// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    /// <summary>
    /// Provides an implementation of the GetById method that works with NHibernate.
    /// </summary>
    /// <typeparam name="TEntity">The Type of the entity to retrieve.</typeparam>
    public class GetEntityById<TEntity> : NHibernateRepositoryOperationBase, IGetEntityById<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntitiesByIds<TEntity> _getEntitiesByIds;

        /// <summary>
        /// Initializes a new instance of the GetEntityById class using the specified session factory and IGetEntitiesByIds implementation.
        /// </summary>
        /// <param name="sessionFactory">The NHibernate Session Factory.</param>
        /// <param name="getEntitiesByIds">The "GetByIds" implementation to which to delegate.</param>
        public GetEntityById(ISessionFactory sessionFactory, IGetEntitiesByIds<TEntity> getEntitiesByIds)
            : base(sessionFactory)
        {
            _getEntitiesByIds = getEntitiesByIds;
        }

        /// <summary>
        /// Gets a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The value of the unique identifier.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _getEntitiesByIds.GetByIdsAsync(new[] {id}, cancellationToken)
                .ContinueWith(x => x.Result.SingleOrDefault(), cancellationToken);
        }
    }
}
