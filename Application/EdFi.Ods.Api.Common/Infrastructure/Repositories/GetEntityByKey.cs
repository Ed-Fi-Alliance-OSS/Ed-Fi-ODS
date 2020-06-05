// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Extensions;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Repositories;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    public class GetEntityByKey<TEntity> : GetEntitiesBase<TEntity>, IGetEntityByKey<TEntity>
        where TEntity : DomainObjectBase, IDateVersionedEntity, IHasIdentifier
    {
        public GetEntityByKey(ISessionFactory sessionFactory, IDomainModelProvider domainModelProvider)
            : base(sessionFactory, domainModelProvider) { }

        /// <summary>
        /// Gets a single entity by its composite primary key values.
        /// </summary>
        /// <param name="specification">An entity instance that has all the primary key properties assigned with values.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public async Task<TEntity> GetByKeyAsync(TEntity specification, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                TEntity persistedEntity = null;

                // Look up by composite key
                var entityWithKeyValues = specification as IHasPrimaryKeyValues;

                if (entityWithKeyValues == null)
                {
                    throw new BadRequestException(
                        $"The '{typeof(TEntity).Name}' entity does not support accessing primary key values.");
                }

                // Go try to get the existing entity
                var compositeKeyValues = entityWithKeyValues.GetPrimaryKeyValues();

                // Only look up by composite key if "Id" is not considered part of the "DomainSignature"
                if (!compositeKeyValues.Contains("Id"))
                {
                    persistedEntity = (await GetAggregateResultsAsync(
                            GetWhereClause(compositeKeyValues), q => q.SetParameters(compositeKeyValues), cancellationToken))
                        .SingleOrDefault();
                }

                if (persistedEntity != null)
                {
                    return persistedEntity;
                }

                // Does entity have an alternate key?
                var entityWithAlternateKeyValues = specification as IHasAlternateKeyValues;

                if (entityWithAlternateKeyValues == null)
                {
                    return null;
                }

                var alternateKeyValues = entityWithAlternateKeyValues.GetAlternateKeyValues();

                // Look up by alternate key
                if (alternateKeyValues.Count > 0)
                {
                    persistedEntity = (await GetAggregateResultsAsync(
                            GetWhereClause(alternateKeyValues), q => q.SetParameters(alternateKeyValues), cancellationToken))
                        .SingleOrDefault();
                }

                return persistedEntity;
            }
            
            string GetWhereClause(OrderedDictionary keyValues)
            {
                string criteria = string.Join(
                    " and ",
                    keyValues
                        .AsEnumerable()
                        .Select(e => $"a.{e.Key} = :{e.Key}"));

                return $" where {criteria}";
            }
        }
    }
}
