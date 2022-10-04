// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models;

public static class ResourceItemPredicateBuilder
{
    // IEnumerable.Contains
    private static readonly MethodInfo _containsMethodInfo = typeof(IEnumerable<string>).GetMethod(
        "Contains",
        new[]
        {
            typeof(IEnumerable<string>),
            typeof(string)
        });

    /// <summary>
    /// Builds a functional predicate that can be used to filter items from a collection based on the provided value
    /// filters (as defined by an API Profile).
    /// </summary>
    /// <param name="valueFilters"></param>
    /// <returns>A function that can be used to appropriately filter a collection.</returns>
    public static object Build(Type itemType, CollectionItemValueFilter[] valueFilters)
    {
        var itemExpression = Expression.Parameter(itemType, "x");

        if (valueFilters.Length == 0)
        {
            return null;
        }

        var filterExpressions = valueFilters.Select(
                filter =>
                {
                    var property = Expression.Property(itemExpression, filter.PropertyName);

                    var valueArray = Expression.NewArrayInit(typeof(string), filter.Values.Select(Expression.Constant));

                    var contains = Expression.Call(_containsMethodInfo, valueArray, property);

                    Expression filterExpression;

                    if (filter.FilterMode == ItemFilterMode.IncludeOnly)
                    {
                        filterExpression = contains;
                    }
                    else // ExcludeOnly
                    {
                        filterExpression = Expression.Not(contains);
                    }

                    return filterExpression;
                })
            .ToList();

        // Combine multiple filters using logical "And"
        Expression finalExpression = filterExpressions.Skip(1).Aggregate(filterExpressions.First(), Expression.AndAlso);

        // Compile and return the expression delegate
        return Expression.Lambda(finalExpression, itemExpression).Compile();
    }

    public static Func<TItem, bool> Build<TItem>(CollectionItemValueFilter[] valueFilters)
    {
        var itemExpression = Expression.Parameter(typeof(TItem), "x");

        if (valueFilters.Length == 0)
        {
            return null;
        }

        var filterExpressions = valueFilters.Select(
                filter =>
                {
                    var property = Expression.Property(itemExpression, filter.PropertyName);

                    var valueArray = Expression.NewArrayInit(typeof(string), filter.Values.Select(Expression.Constant));

                    var contains = Expression.Call(_containsMethodInfo, valueArray, property);

                    Expression filterExpression;

                    if (filter.FilterMode == ItemFilterMode.IncludeOnly)
                    {
                        filterExpression = contains;
                    }
                    else // ExcludeOnly
                    {
                        filterExpression = Expression.Not(contains);
                    }

                    return filterExpression;
                })
            .ToList();

        // Combine multiple filters using logical "And"
        Expression finalExpression = filterExpressions.Skip(1).Aggregate(filterExpressions.First(), Expression.AndAlso);

        // Compile and return the expression delegate
        return Expression.Lambda<Func<TItem, bool>>(finalExpression, itemExpression).Compile();
    }
}
