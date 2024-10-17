// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.CustomViewBased;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class QueryBuilderExtensions
    {
        private static readonly CallContextStorage _callContextStorage = new();

        /// <summary>
        /// Applies a join-based filter to the criteria for the specified authorization view.
        /// </summary>
        /// <param name="queryBuilder">The <see cref="QueryBuilder" /> to which criteria should be applied.</param>
        /// <param name="parameters">The named parameters to be used to satisfy additional filtering requirements.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="subjectEndpointName">The name of the property to be joined for the entity being queried.</param>
        /// <param name="viewSourceEndpointName">The name of the property to be filtered using the claim values.</param> 
        /// <param name="viewTargetEndpointName">The name of the property to be joined for the other property as authorization view.</param> 
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        public static void ApplySingleColumnJoinFilter(
            this QueryBuilder queryBuilder,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias = null)
        {
            // Temporary logic to opt-in to join-based authorization approach
            if (_callContextStorage.GetValue<bool>("UseJoinAuth"))
            {
                ApplySingleColumnJoinFilterUsingJoins(queryBuilder, parameters, viewName, subjectEndpointName, viewSourceEndpointName, viewTargetEndpointName, joinType, authViewAlias);
                return;
            }

            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            authViewAlias = string.IsNullOrWhiteSpace(authViewAlias) ? $"authView{viewName}" : $"authView{authViewAlias}";

            // Create a CTE query for the authorization view
            var cte = new QueryBuilder(queryBuilder.Dialect);
            cte.From($"auth.{viewName} AS av");
            cte.Select($"av.{viewTargetEndpointName}");
            cte.Distinct();
            
            // Apply claims to the CTE query
            if (value is object[] arrayOfValues)
            {
                cte.WhereIn($"av.{viewSourceEndpointName}", arrayOfValues);
            }
            else
            {
                cte.Where($"av.{viewSourceEndpointName}", value);
            }

            // Add the CTE to the main query, with alias
            queryBuilder.With(authViewAlias, cte);

            // Apply join to the authorization CTE
            if (joinType == JoinType.InnerJoin)
            {
                queryBuilder.Join(
                    authViewAlias,
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else if (joinType == JoinType.LeftOuterJoin)
            {
                queryBuilder.LeftJoin(
                    authViewAlias,
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
                
                queryBuilder.Where(qb => qb.WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else
            {
                throw new NotSupportedException("Unsupported authorization view join type.");
            }
        }

        private static void ApplySingleColumnJoinFilterUsingJoins(
            this QueryBuilder queryBuilder,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias = null)
        {
            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            authViewAlias = string.IsNullOrWhiteSpace(authViewAlias) ? $"authView{viewName}" : $"authView{authViewAlias}";

            // Apply authorization join using ICriteria
            if (joinType == JoinType.InnerJoin)
            {
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else if (joinType == JoinType.LeftOuterJoin)
            {
                queryBuilder.LeftJoin(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else
            {
                throw new NotSupportedException("Unsupported authorization view join type.");
            }
            
            if (value is object[] arrayOfValues)
            {
                if (joinType == JoinType.InnerJoin)
                {
                    queryBuilder.WhereIn($"{authViewAlias}.{viewSourceEndpointName}", arrayOfValues);
                }
                else
                {
                    queryBuilder.Where(qb => 
                        qb.WhereIn($"{authViewAlias}.{viewSourceEndpointName}", arrayOfValues)
                            .WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
                }
            }
            else
            {
                if (joinType == JoinType.InnerJoin)
                {
                    queryBuilder.Where($"{authViewAlias}.{viewSourceEndpointName}", value);
                }
                else
                {
                    queryBuilder.Where(qb => 
                        qb.Where($"{authViewAlias}.{viewSourceEndpointName}", value)
                            .WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
                }
            }
        }

        /// <summary>
        /// Applies a join-based filter to the criteria for the specified custom authorization view.
        /// </summary>
        /// <param name="queryBuilder">The <see cref="QueryBuilder" /> to which criteria should be applied.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="subjectEndpointNames">The name of the property to be joined for the entity being queried.</param>
        /// <param name="viewTargetEndpointNames">The name of the property to be joined for the other property as authorization view.</param> 
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        /// <param name="authorizationStrategy">The authorization strategy instance (which may be an instance providing additional context for authorization).</param>
        public static void ApplyCustomViewJoinFilter(
            this QueryBuilder queryBuilder,
            string viewName,
            string[] subjectEndpointNames,
            string[] viewTargetEndpointNames,
            JoinType joinType,
            string authViewAlias,
            IAuthorizationStrategy authorizationStrategy)
        {
            if (authorizationStrategy is not CustomViewBasedAuthorizationStrategy customViewBasedAuthorizationStrategy)
            {
                throw new Exception(
                    $"The authorization strategy supplied to the '{nameof(ApplyCustomViewJoinFilter)}' was not of the expected type '{nameof(CustomViewBasedAuthorizationStrategy)}'.");
            }
            
            string authViewFullAlias = $"{CustomViewHelpers.GetAliasPrefix(viewName)}{authViewAlias}";

            if (subjectEndpointNames.Length == 1)
            {
                // Apply authorization join using the query builder
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewFullAlias}",
                    j => j.On($"r.{subjectEndpointNames[0]}", $"{authViewFullAlias}.{viewTargetEndpointNames[0]}"),
                    joinType);
            }
            else
            {
                // Apply authorization join using ICriteria
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewFullAlias}", j =>
                    {
                        for (int i = 0; i < subjectEndpointNames.Length; i++)
                        {
                            j.On($"r.{subjectEndpointNames[i]}", $"{authViewFullAlias}.{viewTargetEndpointNames[i]}");
                        }

                        return j;
                    },
                    joinType);
            }
        }
        
        /// <summary>
        /// Applies property-level filter expressions to the query builder as either Equal or In expressions based on the supplied parameters.
        /// </summary>
        /// <param name="whereQueryBuilder">The <see cref="QueryBuilder" /> for adding WHERE clause-only criteria.</param>
        /// <param name="parameters">The named parameters to be processed into the criteria query.</param>
        /// <param name="availableFilterProperties">The array of property names that can be used for filtering.</param>
        public static void ApplyPropertyFilters(this QueryBuilder whereQueryBuilder, IDictionary<string, object> parameters, params string[] availableFilterProperties)
        {
            foreach (var nameAndValue in parameters.Where(x => availableFilterProperties.Contains(x.Key, StringComparer.OrdinalIgnoreCase)))
            {
                if (nameAndValue.Value is object[] arrayOfValues)
                {
                    whereQueryBuilder.WhereIn($"{nameAndValue.Key}", arrayOfValues);
                }
                else
                {
                    whereQueryBuilder.Where($"{nameAndValue.Key}", nameAndValue.Value);
                }
            }
        }
    }
}
