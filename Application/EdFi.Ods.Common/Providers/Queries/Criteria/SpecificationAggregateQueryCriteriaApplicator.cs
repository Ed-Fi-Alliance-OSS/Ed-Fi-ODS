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
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Providers.Queries.Criteria;

/// <summary>
/// Applies criteria to an aggregate query based on the provided entity specification.
/// </summary>
public class SpecificationAggregateQueryCriteriaApplicator : IAggregateRootQueryCriteriaApplicator
{
    private readonly IDescriptorResolver _descriptorResolver;
    private readonly IPersonTypesProvider _personTypesProvider;
    private readonly IPersonEntitySpecification _personEntitySpecification;

    public SpecificationAggregateQueryCriteriaApplicator(
        IDescriptorResolver descriptorResolver, 
        IPersonTypesProvider personTypesProvider,
        IPersonEntitySpecification personEntitySpecification)
    {
        _descriptorResolver = descriptorResolver;
        _personTypesProvider = personTypesProvider;
        _personEntitySpecification = personEntitySpecification;
    }

    public void ApplyAdditionalParameters(
        QueryBuilder queryBuilder,
        Entity entity,
        AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters)
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
