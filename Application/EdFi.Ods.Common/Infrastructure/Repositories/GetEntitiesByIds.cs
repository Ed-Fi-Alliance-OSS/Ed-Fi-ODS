// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.FeatureManagement;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class GetEntitiesByIds<TEntity> : GetEntitiesBase<TEntity>, IGetEntitiesByIds<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IEntityDeserializer _entityDeserializer;
        private readonly IParameterListSetter _parameterListSetter;

        private readonly ILog _logger = LogManager.GetLogger(typeof(GetEntitiesByIds<TEntity>));

        public GetEntitiesByIds(
            ISessionFactory sessionFactory,
            IDomainModelProvider domainModelProvider,
            IParameterListSetter parameterListSetter,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IFeatureManager featureManager,
            Dialect dialect,
            DatabaseEngine databaseEngine,
            IEntityDeserializer entityDeserializer)
            : base(sessionFactory, domainModelProvider, dataManagementResourceContextProvider, featureManager, dialect, databaseEngine)
        {
            _entityDeserializer = entityDeserializer;
            _parameterListSetter = Preconditions.ThrowIfNull(parameterListSetter, nameof(parameterListSetter));
        }

        public async Task<IList<TEntity>> GetByIdsAsync(IList<Guid> ids, CancellationToken cancellationToken)
        {
            using var scope = new SessionScope(SessionFactory);

            IEnumerable<TEntity> results;

            if (ids.Count == 1)
            {
                // Only use optimized load if serialization feature enabled
                if (SerializationEnabled)
                {
                    // Get the item from serialized form
                    var singleItemQueryBuilder = GetSingleItemQueryBuilder();

                    singleItemQueryBuilder.Where("Id", ids[0]);
                    var singleItemTemplate = singleItemQueryBuilder.BuildTemplate();

                    var item = await scope.Session.Connection.QuerySingleOrDefaultAsync<ItemRawData<TEntity>>(
                        singleItemTemplate.RawSql,
                        singleItemTemplate.Parameters);

                    // No record found?
                    if (item == null)
                    {
                        return Array.Empty<TEntity>();
                    }

                    // If we can deserialize the item
                    if (item.IsDeserializable)
                    {
                        // Deserialize the entity
                        var entity = await _entityDeserializer.DeserializeAsync<TEntity>(item);

                        if (entity != null)
                        {
                            return [entity];
                        }
                    }
                }

                // Load the item from the ODS
                _logger.Debug("Loading resource from ODS using NHibernate...");

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
