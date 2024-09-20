// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Dapper;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Specifications;
using NHibernate;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to build the query.</typeparam>
    public class PagedAggregateIdsCriteriaProvider<TEntity> : NHibernateRepositoryOperationBase, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        private readonly IDescriptorResolver _descriptorResolver;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly Dialect _dialect;
        private readonly DatabaseEngine _databaseEngine;
        private readonly IPersonTypesProvider _personTypesProvider;

        public PagedAggregateIdsCriteriaProvider(
            ISessionFactory sessionFactory, 
            IDescriptorResolver descriptorResolver, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider,
            IDomainModelProvider domainModelProvider,
            Dialect dialect,
            DatabaseEngine databaseEngine)
            : base(sessionFactory)
        {
            _descriptorResolver = descriptorResolver;
            _personEntitySpecification = personEntitySpecification;
            _domainModelProvider = domainModelProvider;
            _dialect = dialect;
            _databaseEngine = databaseEngine;
            _personTypesProvider = personTypesProvider;

            _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
        }

        private readonly int _defaultPageLimitSize;

        /// <summary>
        /// Get a <see cref="QueryBuilder"/> containing the query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The <see cref="QueryBuilder"/> instance representing the query.</returns>
        public QueryBuilder GetQueryBuilder(TEntity specification, IQueryParameters queryParameters)
        {
            var idQueryBuilder = new QueryBuilder(_dialect);

            var entityFullName = specification.GetApiModelFullName();
            
            if (!_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out var entity))
            {
                throw new Exception($"Unable to find API model entity for '{entityFullName}'.");
            }

            // Get the fully qualified physical table name
            var schemaTableName = $"{entity.Schema}.{entity.TableName(_databaseEngine)}";

            string[] selectColumns = GetColumnProjectionsForDistinctWithOrderBy(entity).ToArray();

            idQueryBuilder.From(schemaTableName.Alias("r"))
                .Distinct()
                .Select(selectColumns)
                .LimitOffset(queryParameters.Limit ?? _defaultPageLimitSize, queryParameters.Offset ?? 0);

            // TODO: ODS-6444 - In order for query caching to work, limit/offset must be parameterized in query (not embedded as literal values)

            // Add the join to the base type
            if (entity.IsDerived)
            {
                idQueryBuilder.Join(
                    $"{entity.BaseEntity.Schema}.{entity.BaseEntity.TableName(_databaseEngine)} AS b",
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

            // TODO: ODS-6444 - Consider cloning the querybuilder at this point and introducing a seam for applying the additional parameters so that authorization strategies can also be incorporated and cloned

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
                foreach (var identifierProperty in (entity.BaseEntity ?? entity).Identifier.Properties)
                {
                    string identifierColumnName = identifierProperty.ColumnName(_databaseEngine, identifierProperty.PropertyName);
                    
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

            void AddDefaultOrdering(QueryBuilder queryBuilder, Entity entity)
            {
                foreach (var identifierProperty in (entity.BaseEntity ?? entity).Identifier.Properties)
                {
                    string identifierColumnName = identifierProperty.ColumnName(_databaseEngine, identifierProperty.PropertyName);

                    if (entity.IsDerived)
                    {
                        queryBuilder.OrderBy($"b.{identifierColumnName}");
                    }
                    else
                    {
                        queryBuilder.OrderBy($"r.{identifierColumnName}");
                    }
                }
            }
            
            static void ProcessQueryParameters(QueryBuilder queryBuilder, IQueryParameters parameters)
            {
                foreach (IQueryCriteriaBase criteria in parameters.QueryCriteria)
                {
                    if (criteria is TextCriteria textCriteria)
                    {
                        MatchMode mode;

                        switch (textCriteria.MatchMode)
                        {
                            case TextMatchMode.Anywhere:
                                mode = MatchMode.Anywhere;

                                break;

                            case TextMatchMode.Start:
                                mode = MatchMode.Start;

                                break;

                            case TextMatchMode.End:
                                mode = MatchMode.End;

                                break;

                            //case TextMatchMode.Exact:
                            default:
                                mode = MatchMode.Exact;

                                break;
                        }

                        queryBuilder.WhereLike(textCriteria.PropertyName, textCriteria.Value, mode);
                    }
                }
            }
        }

        private void ProcessSpecification(QueryBuilder queryBuilder, TEntity specification, Entity entity)
        {
            if (specification != null)
            {
                var propertyValuePairs = specification.ToDictionary(
                    (descriptor, o) => ShouldIncludeInQueryCriteria(descriptor, o, specification));

                foreach (var key in propertyValuePairs.Keys)
                {
                    IHasLookupColumnPropertyMap map = specification as IHasLookupColumnPropertyMap;

                    if (map.IdPropertyByLookupProperty.TryGetValue(key, out LookupColumnDetails columnDetails))
                    {
                        string alias = (!entity.IsDerived || entity.PropertyByName.ContainsKey(columnDetails.PropertyName))
                            ? "r"
                            : "b";

                        // Look up the corresponding lookup id value from the cache
                        var lookupId = _descriptorResolver.GetDescriptorId(
                            columnDetails.LookupTypeName,
                            Convert.ToString(propertyValuePairs[key]));
                    
                        // Add criteria for the lookup Id value, to avoid need to incorporate an INNER JOIN into the query
                        if (lookupId != 0)
                        {
                            queryBuilder.Where($"{alias}.{columnDetails.PropertyName}", lookupId);
                        }
                        else
                        {
                            // Descriptor did not match any value -- criteria should exclude all entries
                            queryBuilder.WhereRaw("1 = 0");
                        }
                    }
                    else
                    {
                        string alias;
                        
                        if (!entity.PropertyByName.TryGetValue(key, out var entityProperty))
                        {
                            if (!entity.IsDerived || !entity.BaseEntity.PropertyByName.TryGetValue(key, out entityProperty))
                            {
                                throw new ArgumentException($"Property '{key}' was not found.");
                            }

                            alias = "b";
                        }
                        else
                        {
                            alias = "r";
                        }

                        // Add the property equality condition to the query criteria
                        if (propertyValuePairs[key] != null)
                        {
                            // Special handling required for money data types due to PostgreSQL
                            if (entityProperty.PropertyType.DbType == DbType.Currency)
                            {
                                DynamicParameters parameter = new();
                                parameter.Add($"@{key}", Convert.ToDecimal(propertyValuePairs[key]), DbType.Currency);
                                queryBuilder.Where($"{alias}.{key}", parameter);
                            }
                            else
                            {
                                queryBuilder.Where($"{alias}.{key}", propertyValuePairs[key]);
                            }
                        }
                        else
                        {
                            queryBuilder.WhereNull($"{alias}.{key}");
                        }
                    }
                }
            }

            bool ShouldIncludeInQueryCriteria(PropertyDescriptor property, object value, TEntity entity)
            {
                // Null values and underscore-prefixed properties are ignored for specification purposes
                if (value == null || property.Name.StartsWith("_") || "|Url|".Contains((string)property.Name))
                {
                    // TODO: Come up with better way to exclude non-data properties
                    return false;
                }

                if (property.Name.EndsWith("DescriptorId"))
                {
                    // DescriptorIds are not used directly from the specification because they might not be set if the value is invalid (rather, the Descriptor lookup is used)
                    return false;
                }
                
                Type valueType = value.GetType();

                // Only use value types (or strings), and non-default values (i.e. ignore 0's)
                var result = (valueType.IsValueType || valueType == typeof(string))
                    && (!value.Equals(valueType.GetDefaultValue())
                        || (UniqueIdConventions.IsUSI(property.Name)
                            && GetPropertyValue(entity, UniqueIdConventions.GetUniqueIdPropertyName(property.Name)) != null));

                // Don't include properties that are explicitly to be ignored
                result = result && !AggregateRootCriteriaProviderHelpers.PropertiesToIgnore.Contains(property.Name);

                // Don't include UniqueId properties when they appear on a Person entity
                result = result
                    && (!AggregateRootCriteriaProviderHelpers.GetUniqueIdProperties(_personTypesProvider).Contains(property.Name)
                        || _personEntitySpecification.IsPersonEntity(entity.GetType()));

                return result;
            
                object GetPropertyValue(TEntity entity, string propertyName)
                {
                    var properties = entity.ToDictionary();

                    return properties.Where(p => p.Key == propertyName).Select(p => p.Value).SingleOrDefault();
                }
            }
        }
    }
}