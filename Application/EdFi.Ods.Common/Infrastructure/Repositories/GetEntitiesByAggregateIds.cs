// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public class GetEntitiesByAggregateIds<TEntity> : GetEntitiesBase<TEntity>, IGetEntitiesByAggregateIds<TEntity>
    where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
{
    private readonly IParameterListSetter _parameterListSetter;

    public GetEntitiesByAggregateIds(
        ISessionFactory sessionFactory,
        IDomainModelProvider domainModelProvider,
        IParameterListSetter parameterListSetter,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        ApiSettings apiSettings)
        : base(sessionFactory, domainModelProvider, dataManagementResourceContextProvider, apiSettings)
    {
        _parameterListSetter = Preconditions.ThrowIfNull(parameterListSetter, nameof(parameterListSetter));
    }

    public async Task<IList<TEntity>> GetByAggregateIdsAsync(IList<int> aggregateIds, CancellationToken cancellationToken)
    {
        using (new SessionScope(SessionFactory))
        {
            IEnumerable<TEntity> results;

            if (aggregateIds.Count == 1)
            {
                results = await GetAggregateResultsAsync(
                    "where a.AggregateId = :id",
                    q => q.SetParameter("id", aggregateIds[0]), cancellationToken);
            }
            else
            {
                results = await GetAggregateResultsAsync(
                    "where a.AggregateId IN (:ids)",
                    q => _parameterListSetter.SetParameterList(q ,"ids", aggregateIds),
                    cancellationToken,
                    "order by a.AggregateId");
            }

            // Process multiple results in the first-level cache to a list of complete aggregates
            return results.ToList();
        }
    }
}
