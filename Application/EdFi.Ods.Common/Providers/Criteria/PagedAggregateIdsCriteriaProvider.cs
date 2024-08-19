// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to build the query.</typeparam>
    public class PagedAggregateIdsCriteriaProvider<TEntity> : AggregateRootCriteriaProviderBase<TEntity>, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly Dialect _dialect;
        private readonly DatabaseEngine _databaseEngine;

        public PagedAggregateIdsCriteriaProvider(
            ISessionFactory sessionFactory, 
            IDescriptorResolver descriptorResolver, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider,
            IDomainModelProvider domainModelProvider,
            Dialect dialect,
            DatabaseEngine databaseEngine)
            : base(sessionFactory, descriptorResolver, personEntitySpecification, personTypesProvider)
        {
            _domainModelProvider = domainModelProvider;
            _dialect = dialect;
            _databaseEngine = databaseEngine;

            _identifierColumnNames = new Lazy<string[]>(
                () =>
                {
                    var persister = (AbstractEntityPersister) SessionFactory.GetClassMetadata(typeof(TEntity));

                    if (persister.IdentifierColumnNames != null && persister.IdentifierColumnNames.Length > 0)
                    {
                        return persister.IdentifierColumnNames;
                    }

                    return new[] { "Id" };
                });

            _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
        }

        private readonly Lazy<string[]> _identifierColumnNames;
        private readonly int _defaultPageLimitSize;

        // /// <summary>
        // /// Get a <see cref="NHibernate.ICriteria"/> query that retrieves the Ids for the next page of data.
        // /// </summary>
        // /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        // /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        // /// <returns>The NHibernate <see cref="NHibernate.ICriteria"/> instance representing the query.</returns>
        // public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        // {
        //     var idQueryCriteria = Session.CreateCriteria<TEntity>("aggregateRoot")
        //         .SetProjection(Projections.Distinct(GetColumnProjectionsForDistinctWithOrderBy()))
        //         .SetFirstResult(queryParameters.Offset ?? 0)
        //         .SetMaxResults(queryParameters.Limit ?? _defaultPageLimitSize);
        //
        //     AddDefaultOrdering(idQueryCriteria);
        //
        //     // Add specification-based criteria
        //     ProcessSpecification(idQueryCriteria, specification);
        //
        //     // Add special query fields
        //     ProcessQueryParameters(idQueryCriteria, queryParameters);
        //
        //     return idQueryCriteria;
        //     
        //     IProjection GetColumnProjectionsForDistinctWithOrderBy()
        //     {
        //         var projections = Projections.ProjectionList();
        //     
        //         // Add the resource identifier (this is the value we need for the secondary "page" query)
        //         projections.Add(Projections.Property("Id"));
        //     
        //         // Add the order by (primary key) columns (required when using DISTINCT with ORDER BY)
        //         foreach (var identifierColumnName in _identifierColumnNames.Value)
        //         {
        //             projections.Add(Projections.Property(identifierColumnName));
        //         }
        //
        //         return projections;
        //     }
        // }

        /// <summary>
        /// Get a <see cref="NHibernate.ICriteria"/> query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="NHibernate.ICriteria"/> instance representing the query.</returns>
        public QueryBuilder GetQueryBuilder(TEntity specification, IQueryParameters queryParameters)
        {
            var idQueryBuilder = new QueryBuilder(_dialect);

            var entityFullName = specification.GetApiModelFullName();
            
            if (!_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out var entity))
            {
                throw new Exception($"Unable to find API model entity for '{entityFullName}'.");
            }

            // TODO: Need physical table name here -- entity.TableName()
            var tableName = entity.FullName.ToString();

            string[] selectColumns = GetColumnProjectionsForDistinctWithOrderBy(entity).ToArray();

            idQueryBuilder.From(tableName.Alias("r"))
                .Distinct()
                .Select(selectColumns)
                .LimitOffset(queryParameters.Limit ?? _defaultPageLimitSize, queryParameters.Offset ?? 0);

            // TODO: In order for query caching to work, limit/offset must be parameterized in query (not embedded as literal values)

            // Add the join to the base type
            if (entity.IsDerived)
            {
                idQueryBuilder.Join(
                    $"{entity.Schema}.{entity.BaseEntity.TableName(_databaseEngine)} AS b",
                    j =>
                    {
                        foreach (var propertyMapping in entity.BaseAssociation.PropertyMappings)
                        {
                            j.On(
                                $"r.{propertyMapping.ThisProperty.ColumnNameByDatabaseEngine[_databaseEngine]}",
                                $"b.{propertyMapping.OtherProperty.ColumnNameByDatabaseEngine[_databaseEngine]}");
                        }

                        return j;
                    });
            }

            AddDefaultOrdering(idQueryBuilder, entity);

            // TODO: Consider cloning the querybuilder at this point and introducing a seam for applying the additional parameters so that authorization strategies can also be incorporated and cloned

            // Add specification-based criteria
            ProcessSpecification(idQueryBuilder, specification, entity);

            // Add special query fields
            ProcessQueryParameters(idQueryBuilder, queryParameters);

            return idQueryBuilder;
            
            IEnumerable<string> GetColumnProjectionsForDistinctWithOrderBy(Entity entity)
            {
                // Add the resource identifier (this is the value we need for the secondary "page" query)
                yield return "Id";
            
                // Add the order by (primary key) columns (required when using DISTINCT with ORDER BY)
                // foreach (var identifierColumnName in _identifierColumnNames.Value)
                foreach (var identifierProperty in (entity.BaseEntity ?? entity).Identifier.Properties)
                {
                    string identifierColumnName = identifierProperty.ColumnName(_databaseEngine, "XYZ");
                    
                    if (entity.IsDerived)
                    {
                        yield return $"b.{identifierColumnName}";
                    }
                    else
                    {
                        yield return $"r.{identifierColumnName}";
                    }
                }
            }
        }

        // private void AddDefaultOrdering(ICriteria queryCriteria)
        // {
        //     foreach (var identifierColumnName in _identifierColumnNames.Value)
        //     {
        //         queryCriteria.AddOrder(Order.Asc(identifierColumnName));
        //     }
        // }

        private void AddDefaultOrdering(QueryBuilder queryBuilder, Entity entity)
        {
            // foreach (var identifierColumnName in _identifierColumnNames.Value)
            foreach (var identifierProperty in (entity.BaseEntity ?? entity).Identifier.Properties)
            {
                string identifierColumnName = identifierProperty.ColumnName(_databaseEngine, "XYZ");

                if (entity.IsDerived)
                {
                    queryBuilder.OrderBy($"b.{identifierColumnName}");
                }
                else
                {
                    queryBuilder.OrderBy(identifierColumnName);
                }
            }
        }
    }
}