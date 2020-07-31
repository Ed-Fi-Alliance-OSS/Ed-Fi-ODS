// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel;
using System.Linq;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;

namespace EdFi.Ods.Api.NHibernate.Architecture.Criteria
{
    /// <summary>
    /// Contains common functionality for incorporating entity specifications and query parameters supplied by the API client
    /// into the <see cref="ICriteria" /> for servicing the request.  
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type" /> of the entity being queried.</typeparam>
    public abstract class AggregateRootCriteriaProviderBase<TEntity> : NHibernateRepositoryOperationBase
    {
        // NOTE: Embedded convention - Known person roles
        private static readonly string[] _uniqueIdProperties =
        {
            "StudentUniqueId",
            "StaffUniqueId",
            "ParentUniqueId"
        };

        private static readonly string[] _propertiesToIgnore =
        {
            "Offset",
            "Limit",
            "TotalCount",
            "Q",
            "SortBy",
            "SortDirection"
        };

        private readonly IDescriptorsCache _descriptorsCache;

        protected AggregateRootCriteriaProviderBase(ISessionFactory sessionFactory, IDescriptorsCache descriptorsCache)
            : base(sessionFactory)
        {
            _descriptorsCache = Preconditions.ThrowIfNull(descriptorsCache, nameof(descriptorsCache));
        }

        protected void ProcessSpecification(ICriteria queryCriteria, TEntity specification)
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
                        // Look up the corresponding lookup id value from the cache
                        var lookupId = _descriptorsCache.GetId(
                            columnDetails.LookupTypeName,
                            Convert.ToString(propertyValuePairs[key]));

                        // Add criteria for the lookup Id value, to avoid need to incorporate an INNER JOIN into the query
                        queryCriteria.Add(
                            propertyValuePairs[key] != null
                                ? Restrictions.Eq(columnDetails.PropertyName, lookupId)
                                : Restrictions.IsNull(key));
                    }
                    else
                    {
                        // Add the property equality condition to the query criteria
                        queryCriteria.Add(
                            propertyValuePairs[key] != null
                                ? Restrictions.Eq(key, propertyValuePairs[key])
                                : Restrictions.IsNull(key));
                    }
                }
            }
        }

        protected static void ProcessQueryParameters(ICriteria queryCriteria, IQueryParameters parameters)
        {
            foreach (IQueryCriteriaBase criteria in parameters.QueryCriteria)
            {
                TextCriteria textCriteria = criteria as TextCriteria;

                if (textCriteria != null)
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

                    queryCriteria.Add(Restrictions.Like(textCriteria.PropertyName, textCriteria.Value, mode));
                }
            }
        }

        private bool ShouldIncludeInQueryCriteria(PropertyDescriptor property, object value, TEntity entity)
        {
            // Null values and underscore-prefixed properties are ignored for specification purposes
            if (value == null || property.Name.StartsWith("_") || "|Url|".Contains(property.Name))
            {
                // TODO: Come up with better way to exclude non-data properties
                return false;
            }

            Type valueType = value.GetType();

            // Only use value types (or strings), and non-default values (i.e. ignore 0's)
            var result = (valueType.IsValueType || valueType == typeof(string))
                && (!value.Equals(valueType.GetDefaultValue())
                    || UniqueIdSpecification.IsUSI(property.Name)
                    && GetPropertyValue(entity, UniqueIdSpecification.GetUniqueIdPropertyName(property.Name)) != null);

            // Don't include properties that are explicitly to be ignored
            result = result && !_propertiesToIgnore.Contains(property.Name);

            // Don't include UniqueId properties when they appear on a Person entity
            result = result
                && (!_uniqueIdProperties.Contains(property.Name) || PersonEntitySpecification.IsPersonEntity(entity.GetType()));

            return result;
        }

        private object GetPropertyValue(TEntity entity, string propertyName)
        {
            var properties = entity.ToDictionary();

            return properties.Where(p => p.Key == propertyName).Select(p => p.Value).SingleOrDefault();
        }
    }
}
