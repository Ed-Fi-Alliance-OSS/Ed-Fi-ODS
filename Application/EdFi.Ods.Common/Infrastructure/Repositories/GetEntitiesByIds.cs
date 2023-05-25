// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class GetEntitiesByIds<TEntity> : GetEntitiesBase<TEntity>, IGetEntitiesByIds<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IParameterListSetter _parameterListSetter;

        public GetEntitiesByIds(
            ISessionFactory sessionFactory,
            IDomainModelProvider domainModelProvider,
            IParameterListSetter parameterListSetter,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
            : base(sessionFactory, domainModelProvider, dataManagementResourceContextProvider)
        {
            _parameterListSetter = Preconditions.ThrowIfNull(parameterListSetter, nameof(parameterListSetter));
        }

        public async Task<IList<TEntity>> GetByIdsAsync(IList<Guid> ids, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                IEnumerable<TEntity> results;

                if (ids.Count == 1)
                {
                    results = await GetAggregateResultsAsync(
                        "where a.Id = :id",
                        q => q.SetParameter("id", ids[0]), cancellationToken);
                }
                else
                {
                    results = await GetAggregateResultsAsync(
                        "where a.Id IN (:ids)",
                        q => _parameterListSetter.SetParameterList(q ,"ids", ids),
                        cancellationToken,
                        "order by a.Id");
                }

                // Process multiple results in the first-level cache to a list of complete aggregates
                return results.ToList();
            }
        }
    }
}
