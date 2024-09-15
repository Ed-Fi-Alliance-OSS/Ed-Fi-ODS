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
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Specifications;
using NHibernate;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    public class PagedAggregateIdsQueryBuilderProvider : NHibernateRepositoryOperationBase, IAggregateRootQueryBuilderProvider
    {
        public const string RegistrationKey = "PagedAggregateIds";

        private readonly IDescriptorResolver _descriptorResolver;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly Dialect _dialect;
        private readonly DatabaseEngine _databaseEngine;
        private readonly IPersonTypesProvider _personTypesProvider;

        public PagedAggregateIdsQueryBuilderProvider(
            ISessionFactory sessionFactory, 
            IDescriptorResolver descriptorResolver, 
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider,
            Dialect dialect,
            DatabaseEngine databaseEngine)
            : base(sessionFactory)
        {
            _descriptorResolver = descriptorResolver;
            _personEntitySpecification = personEntitySpecification;
            _dialect = dialect;
            _databaseEngine = databaseEngine;
            _personTypesProvider = personTypesProvider;
        }

        /// <summary>
        /// Get a <see cref="QueryBuilder"/> containing the query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="aggregateRootEntity"></param>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The <see cref="QueryBuilder"/> instance representing the query.</returns>
        public QueryBuilder GetQueryBuilder(
            Entity aggregateRootEntity,
            AggregateRootWithCompositeKey specification,
            IQueryParameters queryParameters)
        {
            // -----------------------------------------------------------------------------
            // BEGIN potentially shared code
            // -----------------------------------------------------------------------------
            var idQueryBuilder = new QueryBuilder(_dialect);

            // var entityFullName = specification.GetApiModelFullName();
            //
            // if (!_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out var entity))
            // {
            //     throw new Exception($"Unable to find API model entity for '{entityFullName}'.");
            // }

            string rootTableAlias = aggregateRootEntity.IsDerived ? "b" : "r";

            // Get the fully qualified physical table name
            var schemaTableName = $"{aggregateRootEntity.Schema}.{aggregateRootEntity.TableName(_databaseEngine)}";

            // -----------------------------------------------------------------------------
            // END potentially shared code
            // -----------------------------------------------------------------------------
            
            // POTENTIAL Template method -- Build
            string[] selectColumns = GetColumnProjectionsForDistinctWithOrderBy().ToArray();

            idQueryBuilder.From(schemaTableName.Alias("r")).Select(selectColumns);

            // TODO: ODS-6444 - Derived entity may not be needed unless there is criteria to be applied that uses the derived type. This would eliminate a join with every page. Will need to include Discriminator value in join in lieu of join to base.

            // Add the join to the base type (TODO: Determine if needed, with caching considerations)
            if (aggregateRootEntity.IsDerived)
            {
                idQueryBuilder.Join(
                    $"{aggregateRootEntity.BaseEntity.Schema}.{aggregateRootEntity.BaseEntity.TableName(_databaseEngine)} AS b",
                    j =>
                    {
                        foreach (var propertyMapping in aggregateRootEntity.BaseAssociation.PropertyMappings)
                        {
                            j.On(
                                $"r.{propertyMapping.ThisProperty.ColumnNameByDatabaseEngine[_databaseEngine]}",
                                $"b.{propertyMapping.OtherProperty.ColumnNameByDatabaseEngine[_databaseEngine]}");
                        }

                        return j;
                    });
            }

            // -----------------------------------------------------------------------------
            // END ALL potentially shared code
            // -----------------------------------------------------------------------------

            // Order the results
            idQueryBuilder.OrderBy($"{rootTableAlias}.AggregateId");
            
            // END of Cacheable portion of query

            // TODO: ODS-6444 - Consider cloning the querybuilder at this point and introducing a seam for applying the additional parameters so that authorization strategies can also be incorporated and cloned

            // Add specification-based criteria
            ProcessSpecification(idQueryBuilder, specification, aggregateRootEntity);

            // Add special query fields
            ProcessQueryParameters(idQueryBuilder, queryParameters);

            return idQueryBuilder;

            IEnumerable<string> GetColumnProjectionsForDistinctWithOrderBy()
            {
                // Add the resource identifier (this is the value we need for the secondary "page" query)
                yield return $"{rootTableAlias}.Id";
                yield return $"{rootTableAlias}.AggregateId";
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

        private void ProcessSpecification(QueryBuilder queryBuilder, AggregateRootWithCompositeKey specification, Entity entity)
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

            bool ShouldIncludeInQueryCriteria(PropertyDescriptor property, object value, AggregateRootWithCompositeKey entity)
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
            
                object GetPropertyValue(AggregateRootWithCompositeKey entity, string propertyName)
                {
                    var properties = entity.ToDictionary();

                    return properties.Where(p => p.Key == propertyName).Select(p => p.Value).SingleOrDefault();
                }
            }
        }
    }
}